using System;
using System.Drawing;
using System.Windows.Forms;
using MASngFE.MasterData.BOM;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MasterData.Material_Master;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP02PlanificacionOF : Form
    {
        public FrmPP02PlanificacionOF(int numeroOF)
        {
            _numeroOF = numeroOF;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------
        private readonly int _numeroOF;
        private decimal _kgAFabricar;
        private T0070_PLANPRODUCCION _ofData = new T0070_PLANPRODUCCION();
        //-----------------------------------------------------------------------------------------------------------------
        
        private void FrmPlanProduccionOF_Load(object sender, EventArgs e)
        {
            ckAutoFormulacion.Checked = true;
            ConfiguraComboBox();
            LoadOFData();
            AccionSegunEstadoOF();
        }

        private void ConfiguraComboBox()
        {
            cmbOperador.DisplayMember = "SHORTNAME";
            cmbOperador.ValueMember = "SHORTNAME";
            cmbOperador.DataSource = new HumanResourcesManager().GetListAllActiveOperario();
            cmbOperador.SelectedIndex = -1;

            cmbRecursoProduccion.DisplayMember = "DescRecurso";
            cmbRecursoProduccion.ValueMember = "idRecurso";
            cmbRecursoProduccion.DataSource = new RecursosProduccion().GetListRecursosProduccion();
            cmbRecursoProduccion.SelectedIndex = -1;

            t0010ContainerBindingSource.DataSource = new ContainerManager().GetAllContainer();
        }
        private void AccionSegunEstadoOF()
        {
            //Deshabilita todos los botones
            btnVerFormulas1.Enabled = false;
            btnSeleccionarFormula1.Enabled = false;
            btnModificarTamañoBatch1.Enabled = false;
            btnPlanear.Enabled = false;
            btnImprimirFormula.Enabled = false;
            btnExit.Enabled = true;
            btnStandBy.Enabled = false;
            btnCancelarOF.Enabled = false;
            dtpFechaPlan.Enabled = false;
            cmbRecursoProduccion.Enabled = false;
            cmbOperador.Enabled = false;
            txtNumeroLote.ReadOnly = true;
            txtNotaOrdenFabricacion.Enabled = false;
            txtObservacionPF.Enabled = false;
            
            try
            {
                switch (PlanProduccionStatusManager.MapStatusOfFromText2(txtStatus.Text))
                {
                    case PlanProduccionStatusManager.StatusOf.Pendiente:
                        txtObservacionPF.Enabled = true;
                        btnVerFormulas1.Enabled = true;
                        btnCancelarOF.Enabled = true;
                        CompletaDatosFormulaSeleccionada();
                        var cantFormActiva = Convert.ToInt32(txtNumeroFormulasActivas.Text);
                        MensajeNoFormulas();
                        if (cantFormActiva > 1)
                        {
                            btnSeleccionarFormula1.Enabled = true;
                        }
                        else
                        {
                            if (cantFormActiva == 1)
                            {
                                if (ckAutoFormulacion.Checked)
                                {
                                    AutoFormulacion();
                                    AccionSegunEstadoOF();
                                }
                                else
                                {
                                    btnSeleccionarFormula1.Enabled = true;
                                }
                            }
                            else
                            {
                                MensajeNoFormulas();
                            }
                        }
                        break;
                    case PlanProduccionStatusManager.StatusOf.Formulada:
                        txtNotaOrdenFabricacion.Enabled = true;
                        txtObservacionPF.Enabled = true;
                        btnVerFormulas1.Enabled = true;
                        btnModificarTamañoBatch1.Enabled = true;
                        btnPlanear.Enabled = true;
                        btnImprimirFormula.Enabled = true;
                        btnStandBy.Enabled = true;
                        btnCancelarOF.Enabled = true;
                        dtpFechaPlan.Enabled = true;
                        cmbRecursoProduccion.Enabled = true;
                        cmbOperador.Enabled = true;
                        txtNumeroLote.ReadOnly = false;

                        int cantFormActiva1 = Convert.ToInt32(txtNumeroFormulaSeleccionada.Text);

                        if (cantFormActiva1 == 1)
                        {
                            btnSeleccionarFormula1.Enabled = !ckAutoFormulacion.Checked;
                        }
                        else
                        {
                            btnSeleccionarFormula1.Enabled = true;

                        }
                        lblStockNoDisponible.Visible = new ProductionPlanningStockManager(_numeroOF)
                            .ChequeaStockDisponibleMateriaPrimaOrdenFabricacion() == false;
                        t0072Bs.DataSource = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF);
                        break;

                    case PlanProduccionStatusManager.StatusOf.Planeado:
                        txtNotaOrdenFabricacion.Enabled = true;
                        txtObservacionPF.Enabled = true;
                        btnVerFormulas1.Enabled = false;
                        btnSeleccionarFormula1.Enabled = false;
                        btnModificarTamañoBatch1.Enabled = false;
                        btnPlanear.Enabled = false;
                        btnImprimirFormula.Enabled = true;
                        btnStandBy.Enabled = true;
                        btnCancelarOF.Enabled = true;
                        dtpFechaPlan.Enabled = true;
                        cmbRecursoProduccion.Enabled = true;
                        cmbOperador.Enabled = true;
                        txtNumeroLote.ReadOnly = false;

                        lblStockNoDisponible.Visible = new ProductionPlanningStockManager(_numeroOF)
                            .ChequeaStockDisponibleMateriaPrimaOrdenFabricacion() == false;
                        t0072Bs.DataSource = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF);
                        break;

                    case PlanProduccionStatusManager.StatusOf.Proceso:
                        txtNotaOrdenFabricacion.Enabled = true;
                        txtObservacionPF.Enabled = true;
                        btnImprimirFormula.Enabled = true;
                        dtpFechaPlan.Enabled = true;
                        cmbRecursoProduccion.Enabled = true;
                        cmbOperador.Enabled = true;
                        txtNumeroLote.ReadOnly = false;
                        t0072Bs.DataSource = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF);
                        break;
                    case PlanProduccionStatusManager.StatusOf.Cerrada:
                        t0072Bs.DataSource = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF);
                       break;

                    case PlanProduccionStatusManager.StatusOf.Cancelada:
                        break;

                    case PlanProduccionStatusManager.StatusOf.StandBy:
                        btnVerFormulas1.Enabled = true;
                        txtNotaOrdenFabricacion.Enabled = true;
                        txtObservacionPF.Enabled = true;
                        dtpFechaPlan.Enabled = true;
                        cmbRecursoProduccion.Enabled = true;
                        cmbOperador.Enabled = true;
                        txtNumeroLote.ReadOnly = false;
                        btnPlanear.Enabled = true;
                        btnModificarTamañoBatch1.Enabled = true;
                        btnCancelarOF.Enabled = true;
                        btnSeleccionarFormula1.Enabled = true;
                        t0072Bs.DataSource = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF);
                        break;

                    case PlanProduccionStatusManager.StatusOf.Error:
                        break;
                    case PlanProduccionStatusManager.StatusOf.Finalizada:

                        // completar aca!!

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Error en el Estado de la Orden de Fabricacion");
                throw;
            }
        }
        private void LoadOFData()
        {
            _ofData = PlanProduccionListManager.GetOFData(_numeroOF);
            
            //Carga Informacion Header
            txtnumeroOF.Text = _numeroOF.ToString();
            txtMaterialPrimario.Text = _ofData.MATERIAL;
            txtMaterialEtiqueta.Text = _ofData.MATETIQUETA;

            if (_ofData.MATERIAL != _ofData.MATETIQUETA)
            {
                txtMaterialEtiqueta.ForeColor = Color.Red;         
            }


            txtStatus.Text = _ofData.STATUS;
            txtStatusLab.Text = _ofData.CQLAB ?? @"Pendiente";

            if (_ofData.KG_Fabricados == null)
            {
                _ofData.KG_Fabricados = 0;
            }
            txtKgFabricadosIngresados.Text = _ofData.KG_Fabricados.Value.ToString("N2");

            //** PANEL 1
            if (_ofData.KG_FABRICAR_O == null)
            {
                _ofData.KG_FABRICAR_O = 0;
            }
            txtKgFabricarOri.Text = _ofData.KG_FABRICAR.Value.ToString("N2");
            txtPlanPara.Text = _ofData.PLANPARA;
            if (_ofData.OV != null)
            {
                txtOrdenVentaNumero.Text = _ofData.OV.Value.ToString();
                txtClienteFantasia.Text = _ofData.CLIENTE;
            }
            else
            {
                txtOrdenVentaNumero.Text = @"------";
                txtClienteFantasia.Text = @"Sin Informacion";
            }
            txtObservacionPF.Text = _ofData.ObsPlan;
            txtObservacionPF.BackColor = txtObservacionPF.Text.Length > 1 ? Color.GreenYellow : Color.White;

            //panel Formulacion

            txtNumeroFormulasTotales.Text = new BOMManager().GetNumberOfBOM(txtMaterialPrimario.Text).ToString();
            txtNumeroFormulasActivas.Text = new BOMManager().GetNumberOfBOM(txtMaterialPrimario.Text, true).ToString();
            
            if (_ofData.Formula == null || _ofData.Formula <= 0)
            {
                //No hay formula seleccionada
                txtNumeroFormulaSeleccionada.Text = null;
                txtDescripcionFormulaSeleccionada.Text = @"OF Sin Formulacion";
                txtFechaUltimaFormulacion.Text = @"Sin Informacion";
                gFormulacionGreen.Visible = false;
                gFormulacionRed.Visible = true;
                lblAutomaticFormulation.Visible = false;
            }
            else
            {
                //Hay Formula seleccionada
                txtNumeroFormulaSeleccionada.Text = _ofData.Formula.Value.ToString();
                CompletaDatosFormulaSeleccionada();
            }


            //Panel Seleccion BatchInfo
            if (_ofData.CantidadBatches == null)
            {
                _ofData.CantidadBatches = 1;
            }

            if (_ofData.KG_FABRICAR == null)
            {
                _ofData.KG_FABRICAR = _ofData.KG_FABRICAR_O;
            }
            _kgAFabricar = _ofData.KG_FABRICAR.Value;
            txtKgFabricarBatch.Text = _ofData.KG_FABRICAR.Value.ToString("N2");
            txtBatchQuantity.Text = _ofData.CantidadBatches.Value.ToString("D");
            txtBatchSize.Text = (_ofData.KG_FABRICAR/_ofData.CantidadBatches).Value.ToString("N2");
            ckReservaAutomatica.Checked = true;
            
            //Container Info
            var container = new ContainerManager().MaterialContainer(_ofData.MATETIQUETA);
            if (_ofData.CantEnv01 == null)
                _ofData.CantEnv01 = 0;

            if (string.IsNullOrEmpty(container))
            {
                MessageBox.Show(
                    @"El Material a Fabricar no tiene CONTAINER asigando. Por favor seleccione uno o actualice el Material Master",
                    @"Asignacion de Container", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbContainer.SelectedIndex = -1;
                cmbContainer.Enabled = true;
                ckUpdateContainer.Checked = true;
                txtContainerId.Text = null;
                txtCantidadContainers.Text = 0.ToString();
            }
            else
            {
                txtContainerId.Text = container;
                cmbContainer.SelectedValue = container;
                cmbContainer.Enabled = false;
                ckUpdateContainer.Checked = false;
                if (_ofData.CantEnv01 == 0)
                {
                    _ofData.CantEnv01 = new ContainerManager().DeterminaCantidadContainers(txtContainerId.Text,
                        _kgAFabricar);
                }
                txtCantidadContainers.Text = _ofData.CantEnv01.Value.ToString();
            }
            
            //t0072Bs.DataSource = 
            
            //Panel Planificacion Produccion
            txtFechaCompromisoPlan.Text = _ofData.FCOMPROMISO?.ToString("d") ?? @"SIN FECHA";
            dtpFechaPlan.Value = _ofData.FPLAN ?? DateTime.Today;

            if (_ofData.RECURSO != null)
            {
                cmbRecursoProduccion.SelectedValue = _ofData.RECURSO;
            }
            else
            {
                cmbRecursoProduccion.Text = null;
            }


            if (_ofData.Operario != null)
            {
                cmbOperador.SelectedValue = _ofData.Operario;
            }
            else
            {
                cmbOperador.Text = null;
            }

            txtNumeroLote.Text = _ofData.NumLote ?? _numeroOF.ToString();

            txtKgPlaneados.Text = _ofData.KG_FABRICAR.Value.ToString("N2");
            

            
            txtNumeroFormulaSeleccionada.Text = _ofData.Formula.ToString();

            if (_ofData.KG_FABRICAR_O == null || _ofData.KG_FABRICAR_O == 0)
            {
                new PlanProduccionManager().FixKgOriginales(_numeroOF, (decimal) _ofData.KG_FABRICAR);
                txtKgFabricarOri.Text = _ofData.KG_FABRICAR.ToString();
                txtKgFabricarBatch.Text = _ofData.KG_FABRICAR.ToString();
            }
            else
            {
                txtKgFabricarOri.Text = _ofData.KG_FABRICAR_O.ToString();
                txtKgFabricarBatch.Text = _ofData.KG_FABRICAR.ToString();
            }
            
            _kgAFabricar = _ofData.KG_FABRICAR.Value;
            txtNotaOrdenFabricacion.Text = _ofData.ObsPlaneacion;
            txtNotaOrdenFabricacion.BackColor = txtNotaOrdenFabricacion.Text.Length > 1 ? Color.LightGreen : Color.White;



            //Fin ScreenLoad
            txtNumeroClientes.Text = MrpManager.CantidadClientesLlevanMaterial(txtMaterialPrimario.Text, 2, 180).ToString();
            txtConsumoU30.Text = MrpManager.ConsumoTotalMaterial(txtMaterialPrimario.Text, 30).ToString();
            txtConsumoU60.Text = MrpManager.ConsumoTotalMaterial(txtMaterialPrimario.Text, 60).ToString();
            txtConsumoP30.Text = MrpManager.ConsumoPromedioTotalMaterial(txtMaterialPrimario.Text, 180).ToString();
        }

        #region Formulacion

        private void CompletaDatosFormulaSeleccionada()
        {
            var formulaSeleccionada = string.IsNullOrEmpty(txtNumeroFormulaSeleccionada.Text) ? 0 : Convert.ToInt32(txtNumeroFormulaSeleccionada.Text);
            if (formulaSeleccionada == 0)
            {
                gFormulacionGreen.Visible = false;
                gFormulacionRed.Visible = true;
                lblAutomaticFormulation.Visible = false;
                txtNumeroFormulaSeleccionada.Text = null;
                txtDescripcionFormulaSeleccionada.Text = @"Formula NO Seleccionada";
                txtFechaUltimaFormulacion.Text = @"Sin Informacion";
                return;
            }

            var bomHeader = new BOMManager().GetFormulaHeader(Convert.ToInt32(txtNumeroFormulaSeleccionada.Text));
            txtDescripcionFormulaSeleccionada.Text = bomHeader.DESC_FORMULA;
            txtFechaUltimaFormulacion.Text = bomHeader.LastUsed?.ToString("d") ?? @"Sin Informacion";
            gFormulacionGreen.Visible = true;
            gFormulacionRed.Visible = false;
            //lblAutomaticFormulation.Visible = false; (no sabe si fue automatica)
        }
        private void AutoFormulacion()
        {
            var cantFActivas = new BOMManager().GetNumberOfBOM(txtMaterialPrimario.Text, true);
            if (cantFActivas != 1)
                return;
            var numeroFormulaSeleccionada = new BOMManager().GetBOMIdFormulaActiva(txtMaterialPrimario.Text);
            txtNumeroFormulaSeleccionada.Text = numeroFormulaSeleccionada.ToString();
            CompletaDatosFormulaSeleccionada();
            lblAutomaticFormulation.Visible = true;

            //Formulacion incluye alta T0072 + alta T0073 
            PlanProduccionStatusManager.SetStatusFormulada(_numeroOF, numeroFormulaSeleccionada);
            txtStatus.Text = PlanProduccionStatusManager.StatusOf.Formulada.ToString();
        }
        private void MensajeNoFormulas()
        {
            var cantFormTotal = Convert.ToInt32(txtNumeroFormulasTotales.Text);
            var cantFormActivas = Convert.ToInt32(txtNumeroFormulasActivas.Text);
            if (cantFormTotal == 0)
            {
                MessageBox.Show(
                    @"No Existe ninguna formula para la fabricacion de este producto. Comuniquese con LAB para que genere una alternativa valida de fabricacion",
                    @"Producto Sin Formulas", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (cantFormActivas == 0)
                {
                    MessageBox.Show(
                        @"No Existe ninguna FORMULACION ACTIVA para la fabricacion de este producto. Comuniquese con LAB para que ACTIVE una alternativa valida de fabricacion",
                        @"Producto Sin Formula ACTIVA", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }
        private void btnSeleccionarFormula1_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmPP07SeleccionFormulaAFabricar(txtMaterialPrimario.Text, _numeroOF))
            {
                DialogResult dr = frm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    txtNumeroFormulaSeleccionada.Text = frm.FormulaSeleccionada.ToString();
                    CompletaDatosFormulaSeleccionada();
                    lblAutomaticFormulation.Visible = false;
                    //Formulacion incluye alta T0072 + alta T0073 
                    PlanProduccionStatusManager.SetStatusFormulada(_numeroOF,
                        Convert.ToInt32(txtNumeroFormulaSeleccionada.Text));
                    txtStatus.Text = PlanProduccionStatusManager.StatusOf.Formulada.ToString();
                    AccionSegunEstadoOF();
                }
                else
                {
                    if (dr == DialogResult.Cancel)
                    {
                        CancelaFormulacion();
                    }
                    else
                    {

                    }
                }
            }
        }


        private void CancelaFormulacion()
        {
            PlanProduccionStatusManager.SetStatusPendiente(_numeroOF);
            txtNumeroFormulaSeleccionada.Text = null;
            txtStatus.Text = PlanProduccionStatusManager.StatusOf.Pendiente.ToString();
            AccionSegunEstadoOF();
        }
        #endregion

        private void btnImprimirFormula_Click(object sender, EventArgs e)
        {
            var f2 = new RpvOrdenFabricacion(Convert.ToInt32(_numeroOF));
            f2.Show();
        }
        private bool ValidaInfoOKToPlan()
        {
            if (_kgAFabricar <= 0)
            {
                MessageBox.Show(@"Complete los Kg a Fabricar", @"Error en Kg a Fabricar", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbRecursoProduccion.SelectedIndex == -1)
            {
                MessageBox.Show(@"Complete el Recursos de Produccion a Utilizar", @"Error en Kg a Fabricar", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbOperador.SelectedIndex == -1)
            {
                MessageBox.Show(@"Complete el Operador Responsable del Proceso de Fabricacion", @"Error en Kg a Fabricar", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtNumeroLote.Text))
            {
                MessageBox.Show(@"Complete el Numero de Lote (default = Numero OF)", @"Error en Kg a Fabricar", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbContainer.SelectedIndex == -1)
            {
                toolTip1.ToolTipTitle = "Datos Incompletos";
                toolTip1.Show("Debe Seleccionar el tipo de contenedor (Bolsa) Utilizado para envasar la produccion", cmbContainer, cmbContainer.Location, 5000);
                return false;
            }

            if (string.IsNullOrEmpty(txtCantidadContainers.Text))
                txtCantidadContainers.Text = 1.ToString();

            return true;
        }
        private void btnPlanear_Click(object sender, EventArgs e)
        {
            if (ValidaInfoOKToPlan() == false)
                return;
            
            if (PlanProduccionStatusManager.PlanearOrdenFabricacion(_numeroOF, dtpFechaPlan.Value,
                Convert.ToInt32(cmbRecursoProduccion.SelectedValue), cmbOperador.SelectedValue.ToString(),
                txtObservacionPF.Text,cmbContainer.SelectedValue.ToString(),Convert.ToInt32(txtCantidadContainers.Text)))
            {
                MessageBox.Show(@"Se ha planeado la Orden de Fabricacion", @"Orden de Fabricacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (ckUpdateContainer.Checked)
                {
                    new ContainerManager().SetContainerToMaterial(_ofData.MATETIQUETA,
                        cmbContainer.SelectedValue.ToString());
                }
                txtStatus.Text = PlanProduccionStatusManager.StatusOf.Planeado.ToString();
                AccionSegunEstadoOF();
            }
        }
        private void btnStandBy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Desea colocar la OF en Estado StandBy ?" + Environment.NewLine +
                @"Se LIBERARAN Todlos los Stock Reservados.", @"Confirmacion Cambio de Estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                txtStatus.Text = PlanProduccionStatusManager.StatusOf.StandBy.ToString();
                PlanProduccionStatusManager.SetStatusStandBy(_numeroOF);
                new ReservaStockOF().LiberaStockReservadoOF(_numeroOF,true,55);
                AccionSegunEstadoOF();
            }
        }
        private void btnCancelarOF_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmPP04CancelaOF(_numeroOF))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    new ReservaStockOF().LiberaStockReservadoOF(_numeroOF, true, 55);
                    txtStatus.Text = PlanProduccionStatusManager.StatusOf.Cancelada.ToString();
                    AccionSegunEstadoOF();
                }
                else
                {
                }
            }
        }



        //-Revisado 2019-04-08
        private void cmbContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbContainer.SelectedIndex == -1)
            {
                txtContainerId.Text = null;
                txtCantidadContainers.Text = @"0";
            }
            else
            {
                txtContainerId.Text = cmbContainer.SelectedValue.ToString();
                txtCantidadContainers.Text =
                        new ContainerManager().DeterminaCantidadContainers(txtContainerId.Text, Convert.ToDecimal(_kgAFabricar)).ToString();
                }

            }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckUpdateContainer_CheckedChanged(object sender, EventArgs e)
        {
            if (ckUpdateContainer.Checked)
                ckUpdateContainer.BackColor= Color.GreenYellow;
            ckUpdateContainer.BackColor=Color.LightPink;
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtObservacionPF_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtObservacionPF.Text.Length > 100)
            {
                toolTip1.ToolTipTitle = "Excede Longitud Maxima";
                toolTip1.Show("El Campo excede la cantidad maxima de 100 caracteres",txtObservacionPF,txtObservacionPF.Location,5000);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(txtObservacionPF.Text) == false)
            {
                new PlanProduccionManager().UpdateComentarioPF(_numeroOF, txtObservacionPF.Text);
            }
        }

        private void btnModificarTamañoBatch1_Click(object sender, EventArgs e)
        {
            var f2 = new FrmPP05ModificaBatchSize(_numeroOF, ckReservaAutomatica.Checked);
            if (f2.ShowDialog() == DialogResult.OK)
            {
                txtBatchSize.Text = f2.BatchSize.ToString("N1");
                txtBatchQuantity.Text = f2.CantidadBatches.ToString("N0");
                txtKgFabricarBatch.Text = f2.KgFabricarNew.ToString("N2");
                txtKgPlaneados.Text = txtKgFabricarBatch.Text;
                t0072Bs.DataSource = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF);
                _kgAFabricar = f2.KgFabricarNew;

                if (new ProductionPlanningStockManager(_numeroOF).ChequeaStockDisponibleMateriaPrimaOrdenFabricacion() == false)
                {
                    lblStockNoDisponible.Visible = true;
                }
                else
                {
                    lblStockNoDisponible.Visible = false;
                }
                if (string.IsNullOrEmpty(txtContainerId.Text))
                {
                    txtCantidadContainers.Text = @"0";
                }
                else
                {
                    txtCantidadContainers.Text =
                        new ContainerManager().DeterminaCantidadContainers(txtContainerId.Text, f2.KgFabricarNew).ToString();
                }
            }
        }

        private void ckReservaAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            if (ckReservaAutomatica.Checked)
            {
                ckReservaAutomatica.BackColor = Color.LightGreen;
            }
            else
            {
                ckReservaAutomatica.BackColor=Color.LightPink;
            }
        }

        private void btnVerFormulas1_Click(object sender, EventArgs e)
        {
            var f = new FrmMdb01BomSearch(3,txtMaterialPrimario.Text);
            f.ShowDialog();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void txtUltimaFabricacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDetalleIngreso_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funcionalidad en Progreso");
        }

        private void btnCQLab_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funcionalidad en Progreso");

        }

        private void dgvFormulaSeleccionada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                var materialP = dgvFormulaSeleccionada[dgvFormulaSeleccionada.Columns[__primario.Name].Index, e.RowIndex].Value.ToString();
                if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                {
                    MessageBox.Show(@"Aca se mostrar la informacion del Stock disponible");
                    //HACIENDO CLICK EN ITEM --> REEMPLAZAR MATERIAL 

                    //var f2 = new FrmSeleccionBatch(materialP, kg, _numeroOF, idItem, "OF");
                    //DialogResult dr = f2.ShowDialog();
                    //if (dr == DialogResult.OK)
                    //{
                    //    //Se ha seleccionado un LOTE
                    //    var linea = _lst.Find(c => c.idItemFormula == idItem);
                    //    linea.BatchNumber = f2.LoteSeleccioando;
                    //    linea.idStockReservado = f2.IdStockSeleccionado;
                    //    RecalculaDatosDgvFormula(false);
                    //    RecalculaDatosDgvPrint();
                    //    //FormatoDgvPrint();
                    //}
                }
            }
            else
            {

            }
        }

        private void txtCantidadContainers_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender,e);
        }

        private void txtNotaOrdenFabricacion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtNotaOrdenFabricacion.Text.Length > 150)
            {
                toolTip1.ToolTipTitle = "Excede Longitud Maxima";
                toolTip1.Show("El Campo excede la cantidad maxima de 150 caracteres", txtNotaOrdenFabricacion, txtNotaOrdenFabricacion.Location, 5000);
                e.Cancel = true;
                return;
            }

            if (string.IsNullOrEmpty(txtObservacionPF.Text) == false)
            {
                new PlanProduccionManager().UpdateComentarioImpresion(_numeroOF, txtObservacionPF.Text);
            }
        }
    }
}

