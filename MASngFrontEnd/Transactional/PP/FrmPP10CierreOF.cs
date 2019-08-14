using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.DataFix;
using Tecser.Business.MainApp;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;
using TextBox = System.Windows.Forms.TextBox;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP10CierreOF : Form
    {
        public FrmPP10CierreOF(int numeroOF)
        {
            InitializeComponent();
            _numeroOF = numeroOF;
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        private readonly int _numeroOF;
        //private PlanFabricacionStatusManager statusPF;
        private readonly decimal margenVariacionMP = (decimal)0.05;     //5% CONFIGURACION
        private readonly decimal mermaMaxima = (decimal)0.1;           //10% CONFIGURACION
        //
        private decimal _kgMPUsadaReal = 0;
        private decimal _kgMPRecalculoFormula = 0;
        private decimal _variacionMPPorcentual = 0;
        private bool _statusRecalculoMP = false;
        private bool _statusMermaFabricacion = false;
        private decimal _kgTotalCierreOF = 0;
        private decimal _kgIngresadosTemporal = 0;
        private decimal KgAIngresar = 0;        //Valor a Ingresar en el Cierre de OF
        //
        private readonly Color _colorStatusStockOK = Color.LightBlue;
        private readonly Color _colorStatusSinStock = Color.LightPink;
        private readonly Color _colorStatusUnknown = Color.LightGoldenrodYellow;
        private readonly Color _colorStatusConfirmado = Color.LightGreen;
        //--------------------------------------------------------------------------------------------------------------------------------
        public List<T0072_FORMULA_TEMP> _lstFormula = new List<T0072_FORMULA_TEMP>();
        private List<T0072_FORMULA_TEMP> _lstDescuentoStock = new List<T0072_FORMULA_TEMP>();
#pragma warning disable CS0414 // The field 'FrmPP10CierreOF._listaAdded' is assigned but its value is never used
        private bool _listaAdded = false; //Utilizado para la reserva de batches en descuento de stock
#pragma warning restore CS0414 // The field 'FrmPP10CierreOF._listaAdded' is assigned but its value is never used
        //--------------------------------------------------------------------------------------------------------------------------------

        private void FrmIngresoProduccion_Load(object sender, EventArgs e)
        {
            ConfiguraCombobox();
            DisabledAll();
            CargaDatosOF();
            AccionStatus();
        }
        private void ConfiguraCombobox()
        {
            
            //t0010ContainerBindingSource.DataSource = new ContainerManager().GetAllContainer(true);
            //cmbContainer.SelectedIndex = -1;
            
            cmbOperador.ValueMember = "SHORTNAME";
            cmbOperador.DisplayMember = "SHORTNAME";
            cmbOperador.DataSource = new HumanResourcesManager().GetListAllActiveOperario();

            cmbRecurso.ValueMember = "idrecurso";
            cmbRecurso.DisplayMember = "nombrerecurso";
            cmbRecurso.DataSource = new RecursosProduccion().GetListRecursosProduccion();

            //t0010MATERIALESBindingSource.DataSource = new MaterialMasterManager().GetCompleteListofMaterial();
            //cmbPrimarioAdd.SelectedIndex = -1;

            cmbSloc.DataSource = new Ubicaciones().GetUbicacionesStockDisponibleProduccion("CERR");
            cmbSloc.DisplayMember = "SLOC_DESC";
            cmbSloc.ValueMember = "SLOC";
            cmbSloc.SelectedValue = "STBY";

            var estado = new StockEstadoManager();
            cmbEstadoLote.DataSource = estado.GetListEstadoDisponibleEs();
            cmbEstadoLote.DisplayMember = "ESTADO";
            cmbEstadoLote.ValueMember = "ESTADO";
            cmbEstadoLote.SelectedValue = estado.GetEstadoDefaultProduccion();
            
        }
        private void LockControlsAfterClose()
        {
            dtpFechaIngresoProduccion.Enabled = false;
            cmbRecurso.Enabled = false;
            cmbOperador.Enabled = false;
            txtNumeroLote.ReadOnly = true;
            cmbEstadoLote.Enabled = false;
            cmbSloc.Enabled = false;
        }

        private void DisabledAll()
        {
            txtEstadoOF.Text = null;
            txtMaterialEtiqueta.Text = null;
            txtMaterialFabricado.Text = null;
            txtKgPlanificados.Text = null;
            txtKgingresados.Text = null;
            cmbOperador.Text = "";
            cmbRecurso.Text = "";
            btnSetEnProceso.Enabled = false;
            dtpFechaIngresoProduccion.Value = DateTime.Today;
            cmbOperador.Enabled = false;
            cmbRecurso.Enabled = false;
        }
        private void CargaDatosOF()
        {
            var dataOf = PlanProduccionListManager.GetOFData(_numeroOF);
            txtNumeroOF.Text = _numeroOF.ToString();
            if (dataOf != null)
            {
                txtMaterialEtiqueta.Text = dataOf.MATETIQUETA;
                if (dataOf.MATETIQUETA == dataOf.MATERIAL)
                {
                    txtMaterialEtiqueta.ForeColor = Color.Black;
                    txtMaterialEtiqueta.BackColor = Color.Gainsboro;
                }
                else
                {
                    txtMaterialEtiqueta.ForeColor = Color.OrangeRed;
                    txtMaterialEtiqueta.BackColor = Color.Black;
                }

                txtMaterialFabricado.Text = dataOf.MATERIAL;
                txtEstadoOF.Text = dataOf.STATUS;

                if (dataOf.FPLAN != null)
                    dtpFechaPlanificacion.Value = dataOf.FPLAN.Value;

                if (dataOf.FechaFabricacion != null)
                    dtpFechaIngresoProduccion.Value = dataOf.FechaFabricacion.Value;

                txtKgPlanificados.Text = dataOf.KG_FABRICAR.ToString();
                //
                _kgIngresadosTemporal = new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF);
                txtKgTotalIngresoTemporal.Text =
                    new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF, true).ToString("N2");

                if (dataOf.KG_Fabricados == null)
                {
                    dataOf.KG_Fabricados = 0;
                }

                if (dataOf.KG_Fabricados.Value != _kgIngresadosTemporal)
                {
                    PFFixKgTemporales.FixKgTemporalesIngresados(_numeroOF, _kgIngresadosTemporal);
                    MessageBox.Show(@"Se han corregido los Kg Temporales Ingresados en la OF", @"Alerta Fix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtKgingresados.Text = _kgIngresadosTemporal.ToString("N2");
                txtKgTotalIngresoTemporal.Text = _kgIngresadosTemporal.ToString("N2");

                if (dataOf.Operario != null)
                    cmbOperador.SelectedValue = dataOf.Operario;

                if (dataOf.RECURSO != null)
                    cmbRecurso.SelectedValue = dataOf.RECURSO;

                if (string.IsNullOrEmpty(dataOf.NumLote))
                {
                    txtNumeroLote.Text = _numeroOF.ToString();
                }
                else
                {
                    txtNumeroLote.Text = dataOf.NumLote;
                }

                _lstFormula = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF).ToList();

                //Container data
                if (!string.IsNullOrEmpty(dataOf.Env01))
                {

                }

                if (dataOf.CantidadBatches == null)
                    dataOf.CantidadBatches = 1;

                txtBatchQuantity.Text = dataOf.CantidadBatches.Value.ToString();

                if (dataOf.CalculoMP <= 0)
                {
                    //recalcula mp
                    new OrdenFabricacionBOMManager().RecalculaMateriaPrimaFormula(_numeroOF, dataOf.KG_FABRICAR.Value);
                    new PlanProduccionManager().SetKgRecalculo(_numeroOF, dataOf.KG_FABRICAR.Value);
                    _kgMPRecalculoFormula = dataOf.KG_FABRICAR.Value;
                    txtRecalculoFormula.Text = _kgMPRecalculoFormula.ToString("N2");
                    RefrescaDgvCompleto();
                    RefrescaEstadisticasProduccion();
                }
                else
                {
                    //preguntar?
                    _kgMPRecalculoFormula = dataOf.CalculoMP;
                    txtRecalculoFormula.Text = _kgMPRecalculoFormula.ToString("N2");
                    RefrescaDgvCompleto();
                    RefrescaEstadisticasProduccion();
                }
            }
        }
        private void AccionStatus()
        {
            dtpFechaIngresoProduccion.Enabled = false;
            cmbRecurso.Enabled = false;
            cmbOperador.Enabled = false;
            txtNumeroLote.ReadOnly = true;
            cmbEstadoLote.Enabled = false;
            cmbSloc.Enabled = false;

            txtRecalculoFormula.ReadOnly = true;
            txtKGTotalFabricados.ReadOnly = true;
            btnCerrarOF.Enabled = false;
            btnSetEnProceso.Enabled = false;
            btnSetStandBy.Enabled = false;

            btnExit.Enabled = true;


            switch (PlanProduccionStatusManager.MapStatusOfFromText2(txtEstadoOF.Text))
            {
                case PlanProduccionStatusManager.StatusOf.Pendiente:
                    txtEstadoOF.BackColor = Color.Gray;
                    txtEstadoOF.ForeColor = Color.DarkBlue;
                    MessageBox.Show(
                        @"La Orden de Fabricacion se encuentra en estado PENDIENTE - Debe planificarla primero",
                        @"Orden Fabricacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case PlanProduccionStatusManager.StatusOf.Formulada:
                    txtEstadoOF.BackColor = Color.DarkGray;
                    txtEstadoOF.ForeColor = Color.OrangeRed;
                    MessageBox.Show(
                        @"La Orden de Fabricacion se encuentra en estado FORMULADA. Se debe planear Primero",
                        @"Orden Fabricacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case PlanProduccionStatusManager.StatusOf.Planeado:
                    txtEstadoOF.BackColor = Color.LightGreen;
                    txtEstadoOF.ForeColor = Color.LightBlue;
                    btnSetEnProceso.Enabled = true;
                    btnSetStandBy.Enabled = true;
                    cmbOperador.Enabled = true;
                    cmbRecurso.Enabled = true;
                    cmbSloc.Enabled = true;
                    cmbEstadoLote.Enabled = true;
                    dtpFechaIngresoProduccion.Enabled = true;
                    txtRecalculoFormula.ReadOnly = false;
                    txtKGTotalFabricados.ReadOnly = false;

                    if (RefrescaDisponibilidadStockOF() == false)
                    {
                        MessageBox.Show(@"ATENCION: NO Se encuentra stock correcto para descontar", @"Orden Fabricacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    //MessageBox.Show(String.Format("Se han arreglado {0} items sin IdFormula por compatibilidad con version vieja", PpFix.FixIdItemNull(_numeroOF)), @"AutoFix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case PlanProduccionStatusManager.StatusOf.Proceso:
                    txtEstadoOF.BackColor = Color.DarkBlue;
                    txtEstadoOF.ForeColor = Color.White;
                    btnSetEnProceso.Enabled = false;
                    btnSetStandBy.Enabled = true;
                    cmbOperador.Enabled = true;
                    cmbRecurso.Enabled = true;
                    cmbSloc.Enabled = true;
                    cmbEstadoLote.Enabled = true;
                    dtpFechaIngresoProduccion.Enabled = true;
                    txtRecalculoFormula.ReadOnly = false;
                    txtKGTotalFabricados.ReadOnly = false;

                   // RefrescaDgvCompleto();
                    if (new ProductionPlanningStockManager(_numeroOF).SetAndCheckStatusStockMateriasPrimasOF() == false)
                    {
                        MessageBox.Show(@"ATENCION: NO Se encuentra stock correcto para descontar", @"Orden Fabricacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                   // RefrescaDgvCompleto();
                   
                    break;

                case PlanProduccionStatusManager.StatusOf.Cerrada:
                    txtEstadoOF.BackColor = Color.OrangeRed;
                    txtEstadoOF.ForeColor = Color.White;
                    btnSetEnProceso.Enabled = false;
                    cmbOperador.Enabled = false;
                    cmbRecurso.Enabled = false;
                    cmbSloc.Enabled = false;
                    cmbEstadoLote.Enabled = false;

                    btnSetEnProceso.Enabled = false;
                    btnSetStandBy.Enabled = false;
                    //
                    dtpFechaIngresoProduccion.Enabled = false;
                    SetDataSourceIngresoTemporal();


                    var f = new FrmPP16DetallesOFCerrada(_numeroOF);
                    f.Show();
                    this.Close();
                    break;
                case PlanProduccionStatusManager.StatusOf.Cancelada:
                    txtEstadoOF.BackColor = Color.Orange;
                    txtEstadoOF.ForeColor = Color.Red;
                    break;
                case PlanProduccionStatusManager.StatusOf.StandBy:
                    txtEstadoOF.BackColor = Color.LightPink;
                    txtEstadoOF.ForeColor = Color.White;
                    btnSetEnProceso.Enabled = true;

                    SetDataSourceIngresoTemporal();
                    RefrescaDgvCompleto();

                    break;

                case PlanProduccionStatusManager.StatusOf.Error:
                    txtEstadoOF.BackColor = Color.Red;
                    txtEstadoOF.ForeColor = Color.OrangeRed;
                    break;
                case PlanProduccionStatusManager.StatusOf.Finalizada:
                    txtEstadoOF.BackColor = Color.OrangeRed;
                    txtEstadoOF.ForeColor = Color.White;
                    SetDataSourceIngresoTemporal();

                    var f1 = new FrmPP16DetallesOFCerrada(_numeroOF);
                    f1.Show();
                    this.Close();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #region EventosCampos

        #endregion

        #region ValidacionCampo

        private void txtNumeroOF_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }



        #endregion

        #region Botones

        private void btnIngresoProduccionTemporal_Click(object sender, EventArgs e)
        {
            //if (ValidaCompletitudIngresoTemporal() == false)
            //    return;

            //DialogResult dialogResult = MessageBox.Show(string.Format(@"Confirma el ingreso en forma TEMPORAL (Sin descuento de Stock) de {0} KG?", txtKgIngresoTemporal.Text), @"Ingreso de Stock", MessageBoxButtons.YesNo);

            //if (dialogResult == DialogResult.Yes)
            //{
            //    if (string.IsNullOrEmpty(txtCantidadParadas.Text))
            //        txtCantidadParadas.Text = @"0";

            //    if (string.IsNullOrEmpty(txtMinutosParados.Text))
            //        txtMinutosParados.Text = @"0";

            //    if (string.IsNullOrEmpty(txtNumeroPasadas.Text))
            //        txtNumeroPasadas.Text = @"0";

            //    if (string.IsNullOrEmpty(txtCantidadParadas.Text))
            //        txtCantidadParadas.Text = @"0";

            //    new IngresoStockProduccion().IngresoStockProductoFabricado(_numeroOF, dtpFechaIngresoProduccion.Value, Convert.ToDecimal(txtKgIngresoTemporal.Text), txtNumeroLote.Text, cmbSloc.SelectedValue.ToString(), Convert.ToInt32(cmbRecurso.SelectedValue), cmbOperador.SelectedValue.ToString(), cmbEstadoLote.SelectedValue.ToString(), "ES", txtObservacionIngreso.Text, cantidadStops: Convert.ToInt32(txtCantidadParadas.Text), minutosStop: Convert.ToInt32(txtMinutosParados.Text), numeroPasadas: Convert.ToInt32(txtNumeroPasadas.Text), limpiezaCabezal: ckLimpiezaCabezal.Checked, limpiezaCompleta: ckLimpiezaCompleta.Checked);

            //    MessageBox.Show(@"Se ha ingresado correctamente el stock temporal indicado", "Ingreso Stock Temporal", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    SetDataSourceIngresoTemporal();
               
            //    CargaDatosOF();
            //    AccionStatus();
            //}
            //else if (dialogResult == DialogResult.No)
            //{
            //    return;
            //}
        }

        #endregion

        private bool ValidaCompletitudIngresoDefinitivo()
        {
            if (cmbOperador.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Operador Responsable de la Operacion", @"Ingreso de Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbSloc.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccionar una ubicacion para el ingreso del stock", @"Ingreso de Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbRecurso.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccionar el Recursos de Produccion donde se realizo la Operacion",
                    @"Ingreso de Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (String.IsNullOrEmpty(txtNumeroLote.Text))
            {
                MessageBox.Show(@"El Numero de Lote no puede estar incompleto", @"Ingreso de Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (dtpFechaIngresoProduccion.Value > DateTime.Today)
            {
                MessageBox.Show(@"La de fecha de Produccion es Incorrecta", @"Ingreso de Stock", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (dtpFechaIngresoProduccion.Value.AddDays(10) <= DateTime.Today)
            {
                DialogResult dialogResult = MessageBox.Show(
                    @"Confirma que la fecha de ingreso es correcta? (>10 dias)", @"Ingreso de Stock",
                    MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return false;
            }

            if (RefrescaDisponibilidadStockOF() == false)
            {
                MessageBox.Show(@"No se puede continuar porque hay items que no tienen stock disponible O se encuentra en estado Desconocido (Unknown)!", @"Validacion de Stock", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (String.IsNullOrEmpty(txtKGTotalFabricados.Text))
            {
                MessageBox.Show(@"Debe Completar la cantidad de Kg a Ingresar", @"Ingreso de Stock", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (Convert.ToDecimal(txtKGTotalFabricados.Text) <= 0)
            {
                MessageBox.Show(@"Los Kg a Ingresar son Incorrectos", @"Ingreso de Stock", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            return true;
        }
        private void txtNumeroLote_DoubleClick(object sender, EventArgs e)
        {
            txtNumeroLote.ReadOnly = false;
        }
        private void SetDataSourceIngresoTemporal()
        {
           
        }
        /// <summary>
        /// Esta funciona refresca completamente el DGV
        /// Incluye refresco de stock
        /// </summary>
        public void RefrescaDgvCompleto()
        {
            dgvFormulaIngreso.DataSource = null;
            var lstTmp = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF);


            //recalcula batch-size
            if (string.IsNullOrEmpty(txtBatchQuantity.Text))
                txtBatchQuantity.Text = 1.ToString();

            var batchqty = Convert.ToInt32(txtBatchQuantity.Text);
            if (batchqty <= 0)
                batchqty = 1;

            
            //Sumariza
            decimal kgFormula = 0;
            decimal porFormula = 0;
            _kgMPUsadaReal = 0;
#pragma warning disable CS0219 // The variable 'ErrorCalculo' is assigned but its value is never used
            bool ErrorCalculo = false;
#pragma warning restore CS0219 // The variable 'ErrorCalculo' is assigned but its value is never used

            foreach (var item in lstTmp)
            {
                if (item.Primario.StartsWith("B"))
                {
                    //No Toma en cuenta informacion de containers/insumos
                }
                else
                {
                    if (item.CantidadKGReal != null) _kgMPUsadaReal += item.CantidadKGReal.Value;
                    if (item.CantidadKG != null) kgFormula += item.CantidadKG.Value;
                    if (item.CantidadPor != null) porFormula += item.CantidadPor.Value;
                }
            }

            //Agrega linea de totales
            lstTmp.Add(new T0072_FORMULA_TEMP()
            {
                Primario = "TOTAL >>", CantidadKGReal = Decimal.Round(_kgMPUsadaReal, 2), CantidadKG = Decimal.Round(kgFormula, 2), CantidadPor = Decimal.Round(porFormula, 2),
            });

            dgvFormulaIngreso.DataSource = lstTmp;
            for (var i = 0; i < dgvFormulaIngreso.Columns.Count; i++)
            {
                dgvFormulaIngreso.Rows[dgvFormulaIngreso.Rows.Count - 1].Cells[i].Style.BackColor = Color.Gray;
                dgvFormulaIngreso.Rows[dgvFormulaIngreso.Rows.Count - 1].Cells[i].Style.ForeColor = Color.DarkBlue;
            }

            this.dgvFormulaIngreso.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
            for (var i = 0; i < dgvFormulaIngreso.Rows.Count - 1; i++)
            {
                dgvFormulaIngreso[dgvFormulaIngreso.Columns[__kgBatch.Name].Index, i].Value =Math.Round((decimal) dgvFormulaIngreso[dgvFormulaIngreso.Columns[dgvkgreal.Name].Index, i].Value/batchqty, 2);
                if ((bool) dgvFormulaIngreso.Rows[i].Cells[6].Value == true)
                {
                    dgvFormulaIngreso.Rows[i].Cells[6].Style.BackColor = Color.Red;
                    //dgvFormulaIngreso.Rows[dgvFormulaIngreso.Rows.Count - 1].Cells[i].Style.ForeColor = Color.DarkBlue;
                }
                else
                {
                    dgvFormulaIngreso.Rows[i].Cells[6].Style.BackColor = Color.White;
                }


                if ((bool) dgvFormulaIngreso.Rows[i].Cells[7].Value == true)
                {
                    dgvFormulaIngreso.Rows[i].Cells[7].Style.BackColor = Color.MediumSeaGreen;
                    dgvFormulaIngreso.Rows[i].Cells[7].Style.ForeColor = Color.Blue;
                }
                else
                {
                    dgvFormulaIngreso.Rows[i].Cells[7].Style.BackColor = Color.White;
                }

                if ((bool) dgvFormulaIngreso.Rows[i].Cells[5].Value == true)
                {
                    dgvFormulaIngreso.Rows[i].Cells[5].Style.BackColor = Color.MediumSeaGreen;
                }
                else
                {
                    dgvFormulaIngreso.Rows[i].Cells[5].Style.BackColor = Color.White;
                }


                dgvFormulaIngreso.Rows[i].Cells[3].Style.ForeColor = Color.Black;

                if ((decimal) dgvFormulaIngreso.Rows[i].Cells[3].Value == 0)
                {
                    dgvFormulaIngreso.Rows[i].Cells[3].Style.BackColor = Color.LightGray;
                }
                else
                {
                    if ((decimal) dgvFormulaIngreso.Rows[i].Cells[3].Value < 0)
                    {
                        dgvFormulaIngreso.Rows[i].Cells[3].Style.BackColor = Color.Red;
                        dgvFormulaIngreso.Rows[i].Cells[3].Style.ForeColor = Color.White;
                        ErrorCalculo = true;
                    }
                    else
                    {
                        dgvFormulaIngreso.Rows[i].Cells[3].Style.BackColor = Color.LightBlue;
                    }
                }

                //Columna Form%
                if ((decimal) dgvFormulaIngreso.Rows[i].Cells[1].Value == 0)
                {
                    dgvFormulaIngreso.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                }
                else
                {
                    if ((decimal) dgvFormulaIngreso.Rows[i].Cells[3].Value == 0)
                    {
                        dgvFormulaIngreso.Rows[i].Cells[1].Style.BackColor = Color.Orange;
                    }
                    else
                    {
                        dgvFormulaIngreso.Rows[i].Cells[1].Style.BackColor = Color.White;
                    }
                }
                //Si es Container
                if (dgvFormulaIngreso.Rows[i].Cells[0].Value.ToString().StartsWith("B"))
                {
                    dgvFormulaIngreso.Rows[i].Cells[0].Style.BackColor = Color.Gold;
                    dgvFormulaIngreso.Rows[i].Cells[1].Style.BackColor = Color.Gold;
                    dgvFormulaIngreso.Rows[i].Cells[2].Style.BackColor = Color.Gold;
                    dgvFormulaIngreso.Rows[i].Cells[3].Style.BackColor = Color.Gold;
                }
            }
            var stockOK=RefrescaDisponibilidadStockOF(-1,true);
            if (!stockOK)
            {
                MessageBox.Show(
                    @"Al Menos una Linea se encuentra con error en el STOCK.- Para Continuar con el Cierre de la OF Se debe solucionar este problema",
                    @"ATENCION Con el STOCK Disponible", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            RefrescaEstadisticasProduccion();
            this.dgvFormulaIngreso.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
        }
        private void dgvFormulaIngreso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var myDgv = (DataGridView) sender;

            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                //Column LOTE
                var materialX = myDgv[myDgv.Columns["dgvmaterial"].Index, e.RowIndex].Value.ToString();
                var kg = (decimal) myDgv[myDgv.Columns["dgvkgreal"].Index, e.RowIndex].Value;

                if (kg == 0)
                {
                    MessageBox.Show(@"Para Seleccionar un Lote debe completar primero los Kg Reales a descontar/Reservar de material", @"Seleccion Invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string lotePrevio = null;
                if (myDgv[myDgv.Columns[dgvlote.Name].Index, e.RowIndex].Value != null)
                {
                    lotePrevio = myDgv[myDgv.Columns[dgvlote.Name].Index, e.RowIndex].Value.ToString();
                }


                //En esta etapa solo dejaremos seleccionar un lote cuando pueda asignarse por completo
                var f2 = new FrmPP11SelectBatch(materialX, kg, _numeroOF, true);
                var dr = f2.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var idstock = f2.IdstockSeleccionado;
                    var stockfound = StockManager.GetStockLine(idstock);
                    decimal kgSeleccionado = f2.KgSeleccionados;

                    if (string.IsNullOrEmpty(lotePrevio) == false)
                    {
                        var y = new ReservaStockOF().LiberaStockReservadoOF(materialX, _numeroOF, lotePrevio);
                        MessageBox.Show($"Se han liberado {y} linea/s de Stock Relacionada/s con esta OF y Lote #{lotePrevio}# Anteriormente Seleccionado", @"ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (stockfound.Stock == kgSeleccionado)
                    {
                        //Toma linea entera
                        new ReservaStockOF().ReservarStockOF(idstock, _numeroOF, kgSeleccionado);
                    }
                    else
                    {
                        //Hace split en stock
                        new StockManager().SplitStock(idstock, kgSeleccionado);
                        new ReservaStockOF().ReservarStockOF(idstock, _numeroOF, kgSeleccionado);
                    }

                    var kgPendientesDescuento = decimal.Round(kg - kgSeleccionado, 2);
                    if (kgPendientesDescuento > 0)
                    {
                        var item = new T0072_FORMULA_TEMP
                        {
                            CantidadKGReal = kgPendientesDescuento, Primario = materialX, idItemFormula = _lstDescuentoStock.Count + 1, BatchNumber = null, StatusStock = null, OF = _numeroOF, idStockReservado = null
                        };
                        _lstDescuentoStock.Add(item);
                        _listaAdded = true;
                    }

                    new StockBatchManagerOF().AsignaLoteReservadoMateriaPrimaEnOF(_numeroOF, (int) dgvFormulaIngreso[dgvFormulaIngreso.Columns["idItemFormula"].Index, e.RowIndex].Value, idstock);
                    RefrescaDgvCompleto();
                    RefrescaDisponibilidadStockOF();
                    RefrescaDgvCompleto();
                }
                else if (dr == DialogResult.Abort)
                {
                    //Libera el lote 
                    new StockBatchManagerOF().LiberacionLoteOrdenFabricacionIndividual(_numeroOF, (int) dgvFormulaIngreso[dgvFormulaIngreso.Columns["idItemFormula"].Index, e.RowIndex].Value);

                    RefrescaDgvCompleto();
                    RefrescaDisponibilidadStockOF();
                    RefrescaDgvCompleto();
                }
                else
                {
                    MessageBox.Show(@"Se ha Cancelado la seleccion de Lote", @"Seleccion de Lote Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            RefrescaDgvCompleto();
            RefrescaDisponibilidadStockOF();
            RefrescaDgvCompleto();
        }

        /// <summary>
        /// Identifica automaticamente si existe un unico lote para descontar. Sino abre el form para 
        /// seleccionar lote
        /// </summary>
        /// <returns></returns>
        private int IdentificaStockDescuento(int numeroOF, string material, decimal kg)
        {
            decimal kgDescontar = kg;
            int idstockSeleccionado = new IngresoStockProduccion().IdentificaUnicoLoteAutomaticoOF(numeroOF, material, kg);

            if (idstockSeleccionado > 0)
            {
                //encontro un lote - lo asigna y lo devuelve
                new ReservaStockOF().ReservarStockOF(idstockSeleccionado, numeroOF, kgDescontar);
                return idstockSeleccionado;
            }
            else
            {
                //no encontro un lote - abre el form para la seleccion del mismo
                using (var f0 = new FrmPP11SelectBatch(material, kgDescontar, numeroOF, false))
                {
                    DialogResult dr = f0.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        var idstock = f0.IdstockSeleccionado;
                        var stockfound = StockManager.GetStockLine(idstock);
                        var kgSeleccionado = decimal.Round(f0.KgSeleccionados, 2);
                        var kgRestante = decimal.Round((kgDescontar - kgSeleccionado), 2);

                        if (stockfound.Stock == kgSeleccionado)
                        {
                            //Toma linea entera
                            new ReservaStockOF().ReservarStockOF(idstock, _numeroOF, kgSeleccionado);
                            if (kgRestante > 0)
                            {
                                var item = new T0072_FORMULA_TEMP
                                {
                                    CantidadKGReal = kgRestante, Primario = material, idItemFormula = _lstDescuentoStock.Count + 1, BatchNumber = null, StatusStock = null, OF = _numeroOF, idStockReservado = null
                                };
                                _lstDescuentoStock.Add(item);
                                _listaAdded = true;
                            }
                        }
                        else if (decimal.Round((decimal) stockfound.Stock, 2) > kgSeleccionado)
                        {
                            //Hace split en stock
                            new StockManager().SplitStock(idstock, kgSeleccionado);
                            new ReservaStockOF().ReservarStockOF(idstock, _numeroOF, kgSeleccionado);
                            if (kgDescontar > kgSeleccionado)
                            {
                                //Hace split en listatemporal
                                new ReservaStockOF().ReservarStockOF(idstock, _numeroOF, kgSeleccionado);
                                var item = new T0072_FORMULA_TEMP
                                {
                                    CantidadKGReal = kgRestante, Primario = material, idItemFormula = _lstDescuentoStock.Count + 1, BatchNumber = null, StatusStock = null, OF = _numeroOF, idStockReservado = null
                                };
                                _lstDescuentoStock.Add(item);
                                _listaAdded = true;
                            }
                        }
                        else
                        {
                            //Agrega linea a descontar en listatemporal
                            new ReservaStockOF().ReservarStockOF(idstock, _numeroOF, kgSeleccionado);
                            var item = new T0072_FORMULA_TEMP
                            {
                                CantidadKGReal = kgRestante, Primario = material, idItemFormula = _lstDescuentoStock.Count + 1, BatchNumber = null, StatusStock = null, OF = _numeroOF, idStockReservado = null
                            };
                            _lstDescuentoStock.Add(item);
                            _listaAdded = true;
                        }
                        return idstock;
                    }
                    //Cancelo la seleccion!
                    return -1;
                }
            }
        }


        /// <summary>
        /// Vuelve a chequear disponiblidad de stock y refresaca el DGV.
        /// Devuelve false si algo de lo que estaba reservado ya no lo esta
        /// </summary>
        private bool RefrescaDisponibilidadStockOF(int numeroLinea = -1, bool asignaColoresDgv=false)
        {
            var stockDisponible = new ProductionPlanningStockManager(_numeroOF).SetAndCheckStatusStockMateriasPrimasOF(numeroLinea);
            if (asignaColoresDgv)
            {
                AsignaColoresStatusStock(numeroLinea);
            }
            return stockDisponible;
        }
        private void AsignaColoresStatusStock(int numeroLinea =-1)
        {
            if (numeroLinea != -1)
            {
                AsignaColorStatusStock(numeroLinea);
            }
            else
            {
                for (var a = 0; a < dgvFormulaIngreso.Rows.Count - 1; a++)
                {
                    AsignaColorStatusStock(a);
                }
            }
        }

        //funcion privada no invokar sola
        private void AsignaColorStatusStock(int a)
        {
            //Si alguna MP no tiene statusStock asigna UNKWNOWN
            if (dgvFormulaIngreso.Rows[a].Cells[10].Value == null)
                dgvFormulaIngreso.Rows[a].Cells[10].Value = StatusStockDescuento.Unknown.ToString();


            var status = ProductionPlanningStockManager.MapStatusOfFromText(dgvFormulaIngreso.Rows[a].Cells[10].Value.ToString());

            switch (status)
            {
                case StatusStockDescuento.StockOK:
                    dgvFormulaIngreso.Rows[a].Cells[10].Style.BackColor = _colorStatusStockOK;
                    break;
                case StatusStockDescuento.SinStock:
                    dgvFormulaIngreso.Rows[a].Cells[10].Style.BackColor = _colorStatusSinStock;
                    break;
                case StatusStockDescuento.Confirmado:
                    dgvFormulaIngreso.Rows[a].Cells[10].Style.BackColor = _colorStatusConfirmado;
                    break;
                case StatusStockDescuento.Unknown:
                    dgvFormulaIngreso.Rows[a].Cells[10].Style.BackColor = _colorStatusUnknown;
                    dgvFormulaIngreso.Rows[a].Cells[10].Style.ForeColor = Color.DarkOrange;
                    break;
                default:
                    dgvFormulaIngreso.Rows[a].Cells[10].Style.BackColor = Color.Red;
                    dgvFormulaIngreso.Rows[a].Cells[10].Style.ForeColor = Color.DarkOrange;
                    dgvFormulaIngreso.Rows[a].Cells[10].Value = "Error";
                    throw new ArgumentOutOfRangeException();
            }
        }

        #region validacionesKeyPress

        private void txtNumeroPasadas_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void txtCantidadParadas_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void txtKGTotalFabricados_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        #endregion

        private void txtKGTotalFabricados_Leave(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// Remueve el stock reservado + Ingreso del stock + Log
        /// </summary>
        /// <returns></returns>
        private bool IngresoFinalProduccion_Log()
        {
            var log = new MmLog();
            bool resultadoDescuento=true;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int idstock;
                for (var a = 0; a < _lstDescuentoStock.Count - 1; a++)
                {
                    if (_lstDescuentoStock[a].CantidadKGReal > 0)
                    {
                        idstock = _lstDescuentoStock[a].idStockReservado.Value;
                        var resultStock = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstock);
                        if (resultStock != null)
                        {
                            if (resultStock.Material != _lstDescuentoStock[a].Primario)
                            {
                                //No coinciden los datos de la linea reservada
                                resultadoDescuento = false;
                            }
                            else
                            {
                                if (Math.Round(resultStock.Stock, 1) !=
                                    Math.Round(_lstDescuentoStock[a].CantidadKGReal.Value, 1))
                                {
                                    //No coinciden los Kg de la linea reservada
                                    resultadoDescuento = false;
                                }
                                else
                                {
                                    log.LogMovimientoT40(_lstDescuentoStock[a].Primario, dtpFechaIngresoProduccion.Value,
                                        Convert.ToInt32(MmLog.TipoMovimiento.ConsumoMP), "OF", _numeroOF.ToString(),
                                        resultStock.Stock*-1, "ES", resultStock.SLOC, resultStock.Estado, "E", "LX",
                                        resultStock.Batch);
                                    db.T0030_STOCK.Remove(resultStock);
                                }
                            }
                        }
                        else
                        {
                            //La linea de stock reservada ya no se encuentra disponible
                            resultadoDescuento = false;
                        }
                    }
                }

                if (resultadoDescuento==false)
                {
                    //Revierte all LOG descuento MP
                    log.RevierteLogDescuentoMP(_numeroOF);
                    return false;
                }
                
                //Continua con el descuento
               db.SaveChanges();

                //Define cuantos Kg tiene que ingresar ahora
                var kgFabricados = Convert.ToDecimal(txtKGTotalFabricados.Text);
                var kgYaIngresados = new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF);
                var kgAIngresarAHORA = kgFabricados - kgYaIngresados;

                if (kgAIngresarAHORA > 0)
                {
                    new IngresoStockProduccion().IngresoStockProductoFabricado(_numeroOF,
                        dtpFechaIngresoProduccion.Value, kgAIngresarAHORA, txtNumeroLote.Text,
                        cmbSloc.SelectedValue.ToString(), Convert.ToInt32(cmbRecurso.SelectedValue),
                        cmbOperador.SelectedValue.ToString(), cmbEstadoLote.SelectedValue.ToString(), "ES",
                        txtObservacionIngreso.Text, tipoMovimiento: MmLog.TipoMovimiento.IngresoStockProduccion);

                    //Abajo esta el ingreso completo- pero removi los adicionales de cantidad de paradas, etc...

                    //new IngresoStockProduccion().IngresoStockProductoFabricado(_numeroOF,
                    //    dtpFechaIngresoProduccion.Value, kgAIngresar, txtNumeroLote.Text,
                    //    cmbSloc.SelectedValue.ToString(), Convert.ToInt32(cmbRecurso.SelectedValue),
                    //    cmbOperador.SelectedValue.ToString(), cmbEstadoLote.SelectedValue.ToString(), "ES",
                    //    txtObservacionIngreso.Text, cantidadStops: Convert.ToInt32(txtCantidadParadas.Text),
                    //    minutosStop: Convert.ToInt32(txtMinutosParados.Text),
                    //    numeroPasadas: Convert.ToInt32(txtNumeroPasadas.Text),
                    //    limpiezaCabezal: ckLimpiezaCabezal.Checked, limpiezaCompleta: ckLimpiezaCompleta.Checked,
                    //    tipoMovimiento: MmLog.TipoMovimiento.IngresoStockProduccion);
                }


                return true;
            }
        }

        private void BlanqueaDatosAfterProductionIn()
        {
            txtNumeroOF.Text = null;
            txtEstadoOF.Text = null;
            txtMaterialFabricado.Text = null;
            txtMaterialEtiqueta.Text = null;
            txtKgPlanificados.Text = null;
            //txtKgTotalMP.Text = null;
            //txtKgIngresoTemporal.Text = null;
            txtKgingresados.Text = null;
            txtKGTotalFabricados.Text = null;
            //cmbEstadoLote.Text = null;
            cmbRecurso.Text = null;
            cmbOperador.Text = null;
            txtNumeroLote.Text = null;
            //cmbSloc.Text = null;
            //dgvIngresoTemporal.DataSource = null;
            //dgvIngresoTemporal.DataSource = null;
            //btnIngresoProduccionTemporal.Enabled = false;
           
        }

        //Asigna lotes para las materias primas que no tienen el status de CONFIRMADO
        private bool AsignacionFinaldeLotes()
        {
            if (RefrescaDisponibilidadStockOF() == false)
            {
                MessageBox.Show(
                    @"ATENCION: No se puede continuar porque EXISTEN ITEMS que no tienen stock disponible O se encuentran en estado Desconocido (Unknown)!",
                    @"Error en la Validacion de STOCK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            var statusOKDescontar = true; //True significa que todos los items se puede descontar
#pragma warning disable CS0219 // The variable 'kgADescontar' is assigned but its value is never used
            decimal kgADescontar = 0; //Son los Kg que tiene que descontar del material
#pragma warning restore CS0219 // The variable 'kgADescontar' is assigned but its value is never used


            _lstDescuentoStock = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF);
            //Lista temoporal donde asignara los batches a descontar 
            _listaAdded = false; //Flag que indica si se agrego algun item en la lista (x split)

            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = false;
                var lstLocal = new List<T0072_FORMULA_TEMP>(_lstDescuentoStock); //para poder refrescar el DgV


                //Primero pone la lista en estado StockOK para items ==0 (no descontara items)
                foreach (var item0 in lstLocal.Where(c => c.CantidadKGReal == 0))
                {
                    item0.StatusStock = StatusStockDescuento.StockOK.ToString();
                }

                //Recorre la lista de punta a punta - si el item no tiene estado asigna UNKNOWN
                //Y recorre actuando sobre items que no estan en estado CONFIRMADO.
                foreach (var item in lstLocal.Where(c => c.CantidadKGReal > 0))
                {
                    if (String.IsNullOrEmpty(item.StatusStock))
                        item.StatusStock = StatusStockDescuento.Unknown.ToString();

                    if (item.StatusStock == StatusStockDescuento.Confirmado.ToString())
                    {
                        //Si el status es "Confirmado" ya esta listo para descontar - no hay que hacer
                        statusOKDescontar = true;
                    }
                    else
                    {
                        var idstk = IdentificaStockDescuento(_numeroOF, item.Primario, item.CantidadKGReal.Value);
                        if (idstk > 0)
                        {
                            var stkfound = StockManager.GetStockLine(idstk);
                            item.BatchNumber = stkfound.Batch;
                            item.idStockReservado = idstk;
                            item.StatusStock = StatusStockDescuento.Confirmado.ToString();
                            item.CantidadKGReal = stkfound.Stock;
                            keepGoing = true;
                        }
                        else
                        {
                            //Si devuelve -1 es porque se cancelo la seleccion.
                            statusOKDescontar = false;
                            item.StatusStock = null;
                        }
                    }
                }
            }

            if (statusOKDescontar == true)
            {
                //Abre la pantalle de confirmacion de lotes
                using (
                    var f1 = new FrmPP15ConfirmacionLotesCierreOF(_numeroOF, _lstDescuentoStock, _kgTotalCierreOF,
                        (_kgTotalCierreOF - _kgIngresadosTemporal)))
                {
                    DialogResult dr = f1.ShowDialog();
                    switch (dr)
                    {
                        case DialogResult.None:
                            return false;
                        case DialogResult.OK:
                            _kgMPUsadaReal = f1.TotalKgMPUsada;
                            return true;
                        case DialogResult.Cancel:
                            new ReservaStockOF().LiberaStockReservadoOF(_numeroOF,true,55);
                            MessageBox.Show(
                                @"Se ha CANCELADO el ingreso de Stock y Liberado todos los Lotes comprometidos para esta OF",
                                @"Ingreso de Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    @"No se puede continuar con el proceso porque existen materias primas sin seleccion de LOTE o con Stock Inexistente",
                    @"Ingreso de Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }
        private void dgvFormulaIngreso_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;  //Header

            var celdaModificada = e.ColumnIndex;
            decimal kgReal=0;
            decimal kgBatch=0;
            var cantidadBatch = string.IsNullOrEmpty(txtBatchQuantity.Text) ? 1 : Convert.ToInt32(txtBatchQuantity.Text);


            if (celdaModificada == 12)
            {
                //Modifcando Kg-Batch
                if (string.IsNullOrEmpty(dgvFormulaIngreso[dgvFormulaIngreso.Columns[__kgBatch.Name].Index, e.RowIndex].Value.ToString()))
                {
                    dgvFormulaIngreso[dgvFormulaIngreso.Columns[__kgBatch.Name].Index, e.RowIndex].Value = 0.ToString("N2");
                }
                kgBatch =Convert.ToDecimal(dgvFormulaIngreso[dgvFormulaIngreso.Columns[__kgBatch.Name].Index, e.RowIndex].Value);
                kgReal = kgBatch*cantidadBatch;
                //Recalcula cantidad KgReal como si lo estuviera modificando 
                dgvFormulaIngreso[dgvFormulaIngreso.Columns["dgvkgreal"].Index, e.RowIndex].Value = kgReal;
                return;
            }
            else
            {
                //Modificando Kg-Real
                if (string.IsNullOrEmpty(dgvFormulaIngreso[dgvFormulaIngreso.Columns["dgvkgreal"].Index, e.RowIndex].Value.ToString()))
                {
                    dgvFormulaIngreso[dgvFormulaIngreso.Columns["dgvkgreal"].Index, e.RowIndex].Value = 0.ToString("N2");
                }
                kgReal =Convert.ToDecimal(dgvFormulaIngreso[dgvFormulaIngreso.Columns["dgvkgreal"].Index, e.RowIndex].Value);
            }



            bool manualAdded = (bool) dgvFormulaIngreso[dgvFormulaIngreso.Columns[Added.Name].Index, e.RowIndex].Value;
            var iditem = (int) dgvFormulaIngreso[dgvFormulaIngreso.Columns["idItemFormula"].Index, e.RowIndex].Value;

            if (kgReal == 0)
            {
                if (manualAdded == false)
                {
                    MessageBox.Show(
                        @"Este Item ya no sera tenido en cuenta para el recalculo de formula. Para Incluirlo nuevamente en el recalculo automatico coloque un valor cualquiera diferente a CERO",
                        @"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new OrdenFabricacionBOMManager().UpdateKgReal(_numeroOF, iditem, kgReal, true);
                }
                else
                {
                    new OrdenFabricacionBOMManager().UpdateKgReal(_numeroOF, iditem, kgReal);
                }
            }
            else
            {
                if (manualAdded == false)
                {
                    new OrdenFabricacionBOMManager().UpdateKgReal(_numeroOF, iditem, kgReal);
                }
                else
                {
                    new OrdenFabricacionBOMManager().UpdateKgReal(_numeroOF, iditem, kgReal, true);
                }
            }

            //Si tenia lote asignado lo blanquea
            if (dgvFormulaIngreso[dgvFormulaIngreso.Columns["dgvlote"].Index, e.RowIndex].Value != null)
            {
                dgvFormulaIngreso[dgvFormulaIngreso.Columns["dgvlote"].Index, e.RowIndex].Value = null;
            }
            RefrescaDisponibilidadStockOF(iditem);
            RefrescaDgvCompleto();
        }


        /// <summary>
        /// Asegurarse que el dato en el DGV sera del tipo autorizado
        /// </summary>
        private void dgvFormulaIngreso_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvFormulaIngreso.CurrentCell.ColumnIndex == (int) dgvFormulaIngreso.Columns["dgvkgreal"].Index)
                //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (dgvFormulaIngreso.CurrentCell.ColumnIndex == (int)dgvFormulaIngreso.Columns[__kgBatch.Name].Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, false);
        }
        
        
        #region Botones
        private void btnSetEnProceso_Click(object sender, EventArgs e)
        {
            PlanProduccionStatusManager.SetStatusEnProceso(_numeroOF);
        }
        private void btnSetStandBy_Click(object sender, EventArgs e)
        {
            PlanProduccionStatusManager.SetStatusEnProceso(_numeroOF);
        }
        private void btnCerrarOF_Click(object sender, EventArgs e)
        {
            if (_statusMermaFabricacion == false)
            {
                MessageBox.Show(
                    @"No se puede ingresar la produccion hasta que este solucionado el valor de la Merma de Produccion",
                    @"Error en Merma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_statusRecalculoMP == false)
            {
                MessageBox.Show(@"No se puede ingresar la produccion hasta que este recalculada la Formula con el valor correcto de MP",
                    @"Error en Merma de MP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ValidaCompletitudIngresoDefinitivo() == false)
                return;

            var msg =
                MessageBox.Show(
                    @"Confirma el CIERRE de la Orden Produccion?" + Environment.NewLine +
                    $"Se ingresará en este momento un total de {_kgTotalCierreOF - _kgIngresadosTemporal} Kg. Y Se cerrara la OF por un total de {_kgTotalCierreOF} Kg.",
                    @"Cierre de Orden de Produccion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.No)
                return;

            if (AsignacionFinaldeLotes())
            {
                if (IngresoFinalProduccion_Log())
                {
                    PlanProduccionStatusManager.SetStatusCerrado(_numeroOF,Convert.ToInt32(txtBatchQuantity.Text));
                    new OrdenFabricacionBOMManager().RecalculaPorcentajeRealUtilizado(_numeroOF, _kgMPUsadaReal);

                    if (ckPlanificarAutoDiferencia.Checked)
                    {
                        var msg1 =
                            MessageBox.Show(
                                $"Confirma la creacion de una nueva OF por un total de {Convert.ToDecimal(txtKgPlanificados.Text) - _kgTotalCierreOF} Kg?",
                                @"Auto-Planning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msg1 == DialogResult.No)
                            return;

                        var x = new PlanProduccionManager().AddPlanProduccion(txtMaterialFabricado.Text,
                            txtMaterialEtiqueta.Text, Convert.ToDecimal(txtKgPlanificados.Text) - _kgTotalCierreOF, 0,
                            DateTime.Today.AddDays(2), "Auto x diferencia OF#" + _numeroOF, "CERR",
                            PlanProduccionManager.MotivoFabricacion.Stock, null, false, false);
                        if (x > 0)
                        {
                            MessageBox.Show($"Se ha agregado automaticamente la OF# {x} al plan de produccion",
                                @"Auto-Planning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Ha Ocurrido un error al agregar la OF Automatica al plan de produccion",
                                @"Auto-Planning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    if (ckMermaPurga.Checked)
                    {
                        MessageBox.Show(
                            @"La funcionalidad de agregado automatico de purga aun no se encuentra desarrollada.- Consulte nuevamente en un tiempo. Gracias",
                            @"Funcion no desarrollada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    MessageBox.Show(@"Se ha CERRADO correctamente la Orden de Fabricacion", @"Cierre Existoso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCerrarOF.Enabled = false;

                    //Libera stock que pueda haber llegado a quedar "tomado"
                    new ReservaStockOF().LiberaStockReservadoOF(_numeroOF,false,55);
                    int numeroFormula =
                        new TecserData(GlobalApp.CnnApp).T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == _numeroOF).Formula.Value;
                    new BOMManager().SetUltimoUso(numeroFormula,dtpFechaIngresoProduccion.Value);
                    //Actualiza Ultimo USO

                }
                else
                {
                    MessageBox.Show(
                        @"Por un error en la reserva de Materias Primas se ha cancelado el Ingreso/Cierre de la Orden de Fabricacion",
                        @"Cierre FALLIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnIngresoTemporal_Click(object sender, EventArgs e)
        {
            var f = new FrmPP09IngresoTemporal(_numeroOF);
            f.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAyer_Click(object sender, EventArgs e)
        {
            dtpFechaIngresoProduccion.Value = DateTime.Today.AddDays(-1);
        }
        private void btnCancelarIngresoKg_Click(object sender, EventArgs e)
        {
            var f = new FrmPP16DetallesOFCerrada(_numeroOF);
            f.Show();
            this.Close();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            RefrescaDisponibilidadStockOF(-1, true);
        }
        private void btnVerIngresoTemporal_Click(object sender, EventArgs e)
        {
            if (_kgIngresadosTemporal == 0)
            {
                MessageBox.Show(
                    @"No Se puede Ver el detalle del Ingreso Temporal porque esta OF no tiene Ingresos Temporales",
                    @"Temporales Inexistentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var f = new FrmPP12DetalleIngresoTemporal(_numeroOF);
            f.ShowDialog();

        }
        private void btnVerReservasStock_Click(object sender, EventArgs e)
        {
            var f = new FrmPP13VisualizarStockReservadoPF(_numeroOF);
            f.ShowDialog();
        }
        private void btnAgregarMaterialExtra_Click(object sender, EventArgs e)
        {
            var f = new FrmPP14AgregarMaterialPF(_numeroOF, this);
            f.ShowDialog();
        }
        #endregion

        private void txtRecalculoFormula_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecalculoFormula.Text))
            {
                txtRecalculoFormula.Text = 0.ToString("N2");
                toolTip1.ToolTipTitle = "Error en la Seleccion de Kg";
                toolTip1.Show("La Cantidad de Kg para el recalculo de MP debe ser mayor a 0 Kg.", txtRecalculoFormula, txtRecalculoFormula.Location, 5000);
                e.Cancel = false;
                return;
            }

            var kgRecalculoMP = Convert.ToDecimal(txtRecalculoFormula.Text);

            if (kgRecalculoMP < 0)
            {
                toolTip1.ToolTipTitle = "Error en la Seleccion de Kg";
                toolTip1.Show("La materia prima calculada debe ser MAYOR a 0 Kg.", txtRecalculoFormula, txtRecalculoFormula.Location, 5000);
                e.Cancel = true;
                return;
            }

            if (kgRecalculoMP < (_kgIngresadosTemporal - _kgIngresadosTemporal*margenVariacionMP))
            {
                toolTip1.ToolTipTitle = "Error en la Seleccion de Kg";
                toolTip1.Show("La materia prima calculada es menor a los Kg ya ingresados en forma TEMPORAL", txtRecalculoFormula, txtRecalculoFormula.Location, 5000);
                e.Cancel = true;
                return;
            }

            var dr = MessageBox.Show($"Confirma el recalculo automatico de formula para {kgRecalculoMP} Kg?", @"Recalculo Automatico de Formula", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                _kgMPRecalculoFormula = kgRecalculoMP;
                RefrescaEstadisticasProduccion();

                toolTip1.ToolTipTitle = "Atencion!";
                toolTip1.ToolTipIcon = ToolTipIcon.Info;
                toolTip1.Show("La grilla del consumo de materias primas no se ha recalculado en forma automatica debido a su eleccion. Si el total ya ingresado individualmente en cada materia prima coincide, el proceso estara correcto para continuar",txtRecalculoFormula,txtRecalculoFormula.Location,6000);
                return;
            }

            new OrdenFabricacionBOMManager().RecalculaMateriaPrimaFormula(_numeroOF, kgRecalculoMP);
            new PlanProduccionManager().SetKgRecalculo(_numeroOF,kgRecalculoMP);
            _kgMPRecalculoFormula = kgRecalculoMP;
            RefrescaDgvCompleto();
            e.Cancel = false;
        }
        private void txtKGTotalFabricados_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
#pragma warning disable CS0219 // The variable 'margenRecalculo' is assigned but its value is never used
            decimal margenRecalculo = (decimal) 1.10;
#pragma warning restore CS0219 // The variable 'margenRecalculo' is assigned but its value is never used
            if (string.IsNullOrEmpty(txtKGTotalFabricados.Text))
                txtKGTotalFabricados.Text = 0.ToString("N2");

            //Ingreso Temporal
            if (string.IsNullOrEmpty(txtKgingresados.Text)) 
                txtKgingresados.Text = 0.ToString("N2");

            _kgTotalCierreOF = Convert.ToDecimal(txtKGTotalFabricados.Text);

            if (_kgTotalCierreOF == 0)
            {
                //escapatoria
                toolTip1.ToolTipTitle = "Kg Incorrectos";
                toolTip1.Show("Los Kg a Ingresar no pueden ser 0 - Corrija y Recalcule para continuar...",
                    txtKgingresados, txtKgingresados.Location, 5000);
                e.Cancel = false;
                return;
            }

            if (_kgTotalCierreOF < 0)
            {
                toolTip1.ToolTipTitle = "Kg Incorrectos";
                toolTip1.Show("Los Kg a Ingresar no pueden ser Menor a 0Kg",
                    txtKgingresados, txtKgingresados.Location, 5000);
                e.Cancel = true;
                return;
            }

            _kgIngresadosTemporal = Convert.ToDecimal(txtKgingresados.Text);
            KgAIngresar = _kgTotalCierreOF - _kgIngresadosTemporal;
            

            if (KgAIngresar < 0)
            {
                MessageBox.Show(@"Los Totales Fabricados para cerrar esta OF son menores a la sumatoria de Kg Temporales ya Ingresados",
                    @"Ingreso de Produccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            if (Math.Round(_kgMPUsadaReal,1) < Math.Round(_kgTotalCierreOF,1))
            {
                MessageBox.Show(
                    @"Los KG Totales Fabricados generan MERMA NEGATIVA (Se usa menos MP y magicamente aparecen mas KG???",
                    @"Error en Calculo de Utilizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            if (_kgMPUsadaReal > (_kgTotalCierreOF + (_kgTotalCierreOF*mermaMaxima)))
            {
                MessageBox.Show(
                    @"Los Kg Fabricados sobrepasan el límite máximo autorizado de Merma para ingreso de produccion",
                    @"Ingreso de Produccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            RefrescaEstadisticasProduccion();
        }
        private void RefrescaEstadisticasProduccion()
        {
            txtKgMpConsumoReal.Text = _kgMPUsadaReal.ToString("N2");
            txtRecalculoFormula.Text = _kgMPRecalculoFormula.ToString("N2");
            var variacionMPKg = Math.Round(Math.Abs(_kgMPRecalculoFormula - _kgMPUsadaReal),2);

            if (_kgMPRecalculoFormula != 0)
            {
                _variacionMPPorcentual = variacionMPKg/_kgMPRecalculoFormula;
            }
            txtVariacionMPPorcentual.Text = _variacionMPPorcentual.ToString("P2");
            txtMpVarMax.Text = margenVariacionMP.ToString("P1");
            if (_variacionMPPorcentual <= margenVariacionMP)
            {
                _statusRecalculoMP = true;
                txtStatusRecalculo.Text = @"APROBADO";
                txtStatusRecalculo.ForeColor = Color.Green;
            }
            else
            {
                _statusRecalculoMP = false;
                txtStatusRecalculo.Text = @"RECALCULAR";
                txtStatusRecalculo.ForeColor = Color.Red;
            }
            //
            decimal mermaKg = Math.Round(_kgMPUsadaReal - _kgTotalCierreOF,2);
            txtMermaKg.Text = mermaKg.ToString("N2");
            txtMermaMax.Text = mermaMaxima.ToString("P1");
            if (_kgTotalCierreOF == 0)
            {
                txtKGTotalFabricados.Text = 0.ToString("N2");
                txtMermaKg.Text = _kgMPUsadaReal.ToString("N2");
                txtMermaPorcentaje.Text = 1.ToString("P2");
                _statusMermaFabricacion = false;
                txtStatusAprobacion.Text = @"RECHAZADO";
                txtStatusRecalculo.ForeColor = Color.Red;
            }
            else
            {
                var mermaPorcentual = mermaKg / _kgMPUsadaReal;
                txtMermaPorcentaje.Text = mermaPorcentual.ToString("P2");
                if (mermaPorcentual <= mermaMaxima)
                {
                    _statusMermaFabricacion = true;
                    txtStatusAprobacion.Text = @"APROBADO";
                    txtStatusAprobacion.ForeColor = Color.Green;
                }
                else
                {
                    _statusMermaFabricacion = false;
                    txtStatusAprobacion.Text = @"RECHAZADO";
                    txtStatusRecalculo.ForeColor = Color.Orange;
                }
            }

            if (mermaKg ==0)
            {
                ckMermaPurga.Checked = false;
                ckMermaPurga.Enabled = false;
            }
            else
            {
                ckMermaPurga.Enabled = true;
            }

            decimal ingresoNow = (_kgTotalCierreOF - _kgIngresadosTemporal);
            txtIngresoKgAhora.Text = ingresoNow.ToString("N2");
            if (ingresoNow > 0)
            {
                txtIngresoKgAhora.BackColor = Color.GreenYellow;
                txtIngresoKgAhora.ForeColor = Color.DarkBlue;
            }
            else
            {
                txtIngresoKgAhora.BackColor = Color.Orange;
                txtIngresoKgAhora.ForeColor= Color.Red;
            }
            decimal variacionFabVsPlan=1000000;
            var varKgPlan = Convert.ToDecimal(txtKgPlanificados.Text) - _kgTotalCierreOF;
            if (Convert.ToDecimal(txtKgPlanificados.Text)!=0)
                variacionFabVsPlan = varKgPlan / Convert.ToDecimal(txtKgPlanificados.Text);
            txtVariacionFabConPlan.Text = (Math.Abs(varKgPlan) / Convert.ToDecimal(txtKgPlanificados.Text)).ToString("P2");
            if (varKgPlan <= 0)
            {
                ckPlanificarAutoDiferencia.Checked = false;
                ckPlanificarAutoDiferencia.Enabled = false;
            }
            else
            {
                if (Math.Abs(variacionFabVsPlan) > (decimal)0.10)
                {
                    ckPlanificarAutoDiferencia.Checked = true;
                }
                else
                {
                    ckPlanificarAutoDiferencia.Checked = false;
                }
            }
            if (_statusMermaFabricacion == false || _statusRecalculoMP == false)
            {
                btnCerrarOF.Enabled = false;
            }
            else
            {
                btnCerrarOF.Enabled = true;
            }
        }
        private void btnRecalcularCantidadReal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBatchQuantity.Text))
                txtBatchQuantity.Text = 1.ToString();

            RefrescaDgvCompleto();
        }
        private void txtBatchQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender,e);
        }

        private void txtRecalculoFormula_Enter(object sender, EventArgs e)
        {
            //////
            _kgIngresadosTemporal = new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF);
            txtKgingresados.Text = _kgIngresadosTemporal.ToString("N2");
            txtKgTotalIngresoTemporal.Text = txtKgingresados.Text;

        }

        private void txtKGTotalFabricados_Enter(object sender, EventArgs e)
        {
            /////
            _kgIngresadosTemporal = new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF);
            txtKgingresados.Text = _kgIngresadosTemporal.ToString("N2");
            txtKgTotalIngresoTemporal.Text = txtKgingresados.Text;
        }

        private void btnGenerarBOM_Click(object sender, EventArgs e)
        {
        }
    }
}
