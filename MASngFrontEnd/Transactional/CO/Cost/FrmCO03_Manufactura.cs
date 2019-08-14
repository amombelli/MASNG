using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Tecser.Business.MasterData;
using Tecser.Business.Security;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO03_Manufactura : Form
    {
        public FrmCO03_Manufactura()
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CO02", "CO02"))
                return;
            _material = null;
            InitializeComponent();
            cmbMaterial.Enabled = true;
            _tipoCosto = CostoBaseManager.TipoCosto.Reposicion;
        }


        public FrmCO03_Manufactura(string material, CostoBaseManager.TipoCosto tipoCosto)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CO02", "CO02"))
                return;
            _material = material;
            InitializeComponent();
            cmbMaterial.Enabled = false;
            _tipoCosto = tipoCosto;

        }

        //----------------------------------------------------------------------
        private string _material;
        private int _fcost;
        private string _idTotalLine = "*Total*";
        private List<T0038_CostoMfgExplo> _dataDgv;
        private CostoBaseManager.TipoCosto _tipoCosto;
        //-----------------------------------------------------------------------
        private void FrmCO03_Manufactura_Load(object sender, EventArgs e)
        {
            if (_tipoCosto == CostoBaseManager.TipoCosto.Reposicion)
            {
                rbUC.Checked = true;
            }
            else
            {
                rbCostoStandard.Checked = true;
            }

            ckVerSoloMonedaCosto.Checked = true;
            
            if (_material != null)
            {
                cmbMaterial.Text = _material;
                var matData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
                txtDescripcion.Text = matData.MAT_DESC;
                txtMtype.Text = matData.TIPO_MATERIAL;
                txtIdFormula.Text = matData.FORM_COSTO.ToString();
                if (string.IsNullOrEmpty(txtIdFormula.Text))
                {
                    MessageBox.Show(@"No se ha encontrado una version de Formula FCOST para este material",
                        @"FCOST Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFormulaDescription.Text = @"Formula Inexisnte";
                }
                else
                {
                    var form = new BOMManager().GetFormulaHeader(matData.FORM_COSTO.Value);
                    txtFormulaDescription.Text = form.DESC_FORMULA;
                }

                txtOrigen.Text = matData.ORIGEN;
                MapCostData(_tipoCosto);
            }
            else
            {
                this.cmbMaterial.SelectedIndexChanged -= new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
                BindingSource bs = new BindingSource();
                bs.DataSource = MaterialMasterManager.GetMfgMaterialList(false);
                cmbMaterial.DataSource = bs;
                cmbMaterial.SelectedIndex = -1;
                tc.Init((decimal) 0.01, 1000, 2, false, true, false);
                tc.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString();
                this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
            }
        }
        private void MapCostData(CostoBaseManager.TipoCosto tipoCosto)
        {
            var mfg = new CostoManufactura();
            var mfgCostSaved = mfg.GetCostSaved(_material);
            if (mfgCostSaved.FormulaId == -1)
            {
                MessageBox.Show(@"No se ha encontrado informacion de Costo de Manufactura Almancenado",
                    @"Sin Informacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSavedArs.Text = 0.ToString("C2");
                txtSavedUsd.Text = 0.ToString("C2");
                txtFechaSaved.Text = null;
                txtMonedaCost.Text = @"USD";
            }
            else
            {
                txtMonedaCost.Text = mfgCostSaved.MonedaCost;
                if (rbCostoStandard.Checked)
                {
                    txtSavedArs.Text = mfgCostSaved.StdArs.ToString("C2");
                    txtSavedUsd.Text = mfgCostSaved.StdUsd.ToString("C2");
                    txtFechaSaved.Text = mfgCostSaved.FechaRepo.ToString("d");
                }
                else
                {
                    txtSavedArs.Text = mfgCostSaved.RepoArs.ToString("C2");
                    txtSavedUsd.Text = mfgCostSaved.RepoUsd.ToString("C2");
                    txtFechaSaved.Text = mfgCostSaved.FechaRepo.ToString("d");
                }
            }

            var retorno =mfg.CalculaCostoNew(_material, tipoCosto, txtMonedaCost.Text, tc.ValueD,ckUpdateMfgCost.Checked);
            txtMfgArs.Text = retorno.ARS.ToString("C2");
            txtMfgUsd.Text = retorno.USD.ToString("C2");
            txtFechaUpdate.Text = retorno.Fecha.ToString("g");
            _dataDgv = mfg.GetBomItems(_material);
            var retorno2=SumaCostoTotal();
            CostBs.DataSource = _dataDgv.ToList();
            FormatoDatagridView(retorno2,dgvFormula);
            FormatoDatagridView(retorno2, dgvFormulaSimple);
        }
        private void CmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex ==-1)
            {
                _material = null;
                return;
            }
            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;

            _material = cmbMaterial.SelectedValue.ToString();
            var materialData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
            txtDescripcion.Text = materialData.MAT_DESC;
            txtOrigen.Text = materialData.ORIGEN;
            txtMtype.Text = materialData.TIPO_MATERIAL;
            if (materialData.FORM_COSTO == null)
            {
                _fcost = -1;
                txtFormulaDescription.Text = @"Seleccione una FCOST!";
                txtIdFormula.Text = null;
            }
            else
            {
                _fcost = materialData.FORM_COSTO.Value;
                var formdata = new BOMManager().GetFormulaHeader(_fcost);
                txtFormulaDescription.Text = formdata.DESC_FORMULA;
                txtIdFormula.Text = _fcost.ToString();
            }
            MapCostData(_tipoCosto);
            

            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
            ckVerSoloMonedaCosto.Checked = true;
            //rbUC.Checked = true;
        }
        private void RbUC_CheckedChanged(object sender, EventArgs e)
        {
            _tipoCosto = rbUC.Checked ? CostoBaseManager.TipoCosto.Reposicion : CostoBaseManager.TipoCosto.Standard;
            if (_material == null)
                return;
            MapCostData(_tipoCosto);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnModificarFormulaCosteo_Click(object sender, EventArgs e)
        {
            if (_material == null)
            {
                MessageBox.Show(@"Debe Seleccionar un material para visualizar la FCOST", @"Material sin Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            using (var f = new FrmCO05SeleccionaFormulaCosteo(_material))
            {
                f.ShowDialog();
            }
        }
        private void Tc_Validating(object sender, CancelEventArgs e)
        {
            if (_material != null)
            {
                MapCostData(rbCostoStandard.Checked
                    ? CostoBaseManager.TipoCosto.Standard
                    : CostoBaseManager.TipoCosto.Reposicion);
            }
        }
        private void DgvItemsData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //si el origen es fabricado abre una ventana nueva con la explosion
            var datagridview = (DataGridView)sender;
            if (datagridview.Columns[e.ColumnIndex].Index == datagridview.Columns[zOrigen.Name].Index)
            {
                if (datagridview[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    MessageBox.Show(@"Debe definir el Origen en el Material Master", @"Origen Desconocido",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (datagridview[e.ColumnIndex, e.RowIndex].Value.ToString() == "FAB")
                    {
                        var material_ = datagridview[zItem.Name, e.RowIndex].Value.ToString();
                        
                        using (var f0 = new FrmCO03_Manufactura(material_,_tipoCosto))
                        {
                            DialogResult dr = f0.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                //string custName = f0.CustomerName;
                                //SaveToFile(custName);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Proximamente se podra acceder al precio de reposicion", @"Sin Codificar",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void DgvFormulaSimple_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //si el origen es fabricado abre una ventana nueva con la explosion
            var datagridview = (DataGridView)sender;
            if (datagridview.Columns[e.ColumnIndex].Index == datagridview.Columns[x2Origen.Name].Index)
            {
                if (datagridview[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    MessageBox.Show(@"Debe definir el Origen en el Material Master", @"Origen Desconocido",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (datagridview[e.ColumnIndex, e.RowIndex].Value.ToString() == "FAB")
                    {
                        var material_ = datagridview[x2Material.Name, e.RowIndex].Value.ToString();
                        using (var f0 = new FrmCO03_Manufactura(material_,_tipoCosto))
                        {
                            DialogResult dr = f0.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                //string custName = f0.CustomerName;
                                //SaveToFile(custName);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Proximamente se podra acceder al precio de reposicion", @"Sin Codificar",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private CostoBaseManager.CostMini SumaCostoTotal()
        {
            //si no existe la linea de totales la agrega a la lista
            var dataTotal = _dataDgv.Find(c => c.MaterialItem == _idTotalLine);
            if (dataTotal == null)
            {
                var data = new T0038_CostoMfgExplo()
                {
                    MaterialItem = _idTotalLine,
                    FormulaProp = 0,
                    PropARS = 0,
                    PropUSD = 0
                };
                _dataDgv.Add(data);
            }

            //Calcula/Recalcula Total DGV
            decimal totalProp = 0;
            decimal costoARS = 0;
            decimal costoUSD = 0;
            foreach (var item in _dataDgv.Where(c => c.MaterialItem != _idTotalLine))
            {
                totalProp += item.FormulaProp;
                costoARS += item.PropARS;
                costoUSD += item.PropUSD;
            }
            var resultado = new CostoBaseManager.CostMini
            {
                ARS = costoARS,
                USD = costoUSD,
                Porcentaje = totalProp
            };
            return resultado;
        }
        private void FormatoDatagridView(CostoBaseManager.CostMini cost, DataGridView xdgv)
        {
            for (var i = 0; i < xdgv.Rows.Count; i++)
            {
                var miRow = xdgv.Rows[i];

                DataGridViewCell xxOrigen;
                string xxMaterial;
                DataGridViewCell xxfecha;
                if (xdgv.Name == "dgvFormula")
                {
                    xxOrigen = miRow.Cells[zOrigen.Name];
                    xxMaterial =miRow.Cells[zItem.Name].Value.ToString();
                    xxfecha = miRow.Cells[zFechaCosto.Name];
                }
                else
                {
                    xxOrigen = miRow.Cells[x2Origen.Name];
                    xxMaterial = miRow.Cells[x2Material.Name].Value.ToString();
                    xxfecha = miRow.Cells[x2fechaCosto.Name];
                }

                //*** Formato de Linea de Totales ***
                if (xxMaterial == _idTotalLine)
                {
                    //Completa Lineas Totales
                    if (xdgv.Name == "dgvFormula")
                    {
                        miRow.Cells[zFormPorc.Name].Value = cost.Porcentaje;
                        miRow.Cells[zPropArs.Name].Value = cost.ARS;
                        miRow.Cells[zPropUsd.Name].Value = cost.USD;
                    }
                    else
                    {
                        miRow.Cells[x2Porcentaje.Name].Value = cost.Porcentaje;
                        miRow.Cells[x2Costo.Name].Value = txtMonedaCost.Text == @"USD" ? cost.USD : cost.ARS;
                    }

                    //Colorea la linea de totales
                    for (var j = 0; j < xdgv.Columns.Count; j++)
                    {
                        xdgv.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                        xdgv.Rows[i].Cells[j].Style.ForeColor = Color.DarkBlue;
                    }
                    //Pinta los Forecolor para que no se vean los valores
                    if (xdgv.Name == "dgvFormula")
                    {
                        xdgv.Rows[i].Cells[costoARSDataGridViewTextBoxColumn.Name].Style.ForeColor = Color.Gray;
                        xdgv.Rows[i].Cells[costoUSDDataGridViewTextBoxColumn.Name].Style.ForeColor = Color.Gray;
                        xdgv.Rows[i].Cells[zFechaCosto.Name].Style.ForeColor = Color.Gray;
                    }
                    else
                    {
                        xdgv.Rows[i].Cells[x2Unit.Name].Style.ForeColor = Color.Gray;
                        xdgv.Rows[i].Cells[x2fechaCosto.Name].Style.ForeColor = Color.Gray;
                    }
                }
                else
                {
                    //Row de datos
                    if (xxOrigen.Value == null)
                    {
                        xxOrigen.Style.BackColor = Color.Beige;
                    }
                    else
                    {
                        if (xxOrigen.Value.ToString() == "FAB")
                        {
                            xxOrigen.Style.BackColor = Color.GreenYellow;
                        }
                        else
                        {
                            xxOrigen.Style.BackColor = Color.CornflowerBlue;
                        }
                    }

                    if (Convert.ToDateTime(xxfecha.Value).Date == Convert.ToDateTime(txtFechaUpdate.Text).Date)
                    {
                        xxfecha.Style.BackColor = Color.LightCoral;
                    }
                        

                }
            }
            xdgv.Refresh();
        }
        private void CkVerSoloMonedaCosto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckVerSoloMonedaCosto.Checked)
            {
                dgvFormulaSimple.Visible = true;
                dgvFormula.Visible = false;

                if (txtMonedaCost.Text == @"USD" ||string.IsNullOrEmpty(txtMonedaCost.Text))
                {
                    dgvFormulaSimple.Columns[x2Unit.Name].DataPropertyName = "CostoUSD";
                    dgvFormulaSimple.Columns[x2Costo.Name].DataPropertyName = "PropUSD";
                }
                else
                {
                    dgvFormulaSimple.Columns[x2Unit.Name].DataPropertyName = "CostoARS";
                    dgvFormulaSimple.Columns[x2Costo.Name].DataPropertyName = "PropARS";
                }
            }
            else
            {
                dgvFormula.Visible = true;
                dgvFormulaSimple.Visible = false;
            }
        }

        private void CkCalculoMemoria_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCalculoMemoria.Checked)
            {

            }
            else
            {

            }
        }

        private void BtnSetAsStandard_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show(@"Confirma definir este costo como standard?", @"Defnicion Costo Standard",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.No)
                return;

            //

            //

            MessageBox.Show(@"Se ha definido correctamente el costo como Standard", @"Defincion de Costo Standard",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
