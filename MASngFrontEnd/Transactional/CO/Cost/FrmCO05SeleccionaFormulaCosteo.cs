using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MASngFE.Transactional.FI.CustomerNCD;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity.DataStructure;
using TecserSQL.Data.MasterData;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO05SeleccionaFormulaCosteo : Form
    {
        public FrmCO05SeleccionaFormulaCosteo(string material)
        {
            _material = material;
            InitializeComponent();
        }
        //---------------------------------------------------------------------------------
        private readonly string _material;
        private int? _fCostAlmacenada;
        private int? _formulaSeleccionadaNew;
        //---------------------------------------------------------------------------------


        private void SeleccionayColoreaDgv()
        {
            if (_fCostAlmacenada != null)
            {
                var seleccion = false;
                dgvHeader.ClearSelection();
                for (var i = 0; i < dgvHeader.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvHeader.Rows[i].Cells[iDFORMULADataGridViewTextBoxColumn.Name].Value) ==
                        _fCostAlmacenada.Value)
                    {
                        dgvHeader.Rows[i].Selected = true;
                        seleccion = true;
                    }

                    if (Convert.ToBoolean(dgvHeader.Rows[i].Cells[aCTIVADataGridViewTextBoxColumn.Name].Value))
                    {
                        dgvHeader.Rows[i].Cells[aCTIVADataGridViewTextBoxColumn.Name].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        dgvHeader.Rows[i].Cells[aCTIVADataGridViewTextBoxColumn.Name].Style.BackColor = Color.Orange;
                    }
                }

                if (seleccion == false)
                {
                    MessageBox.Show(@"Atencion la Formula Seleccionada para Costeo NO se encuentra activa",
                        @"FCOST Inactiva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void FrmCO05SeleccionaFormulaCosteo_Load(object sender, EventArgs e)
        {
            this.dgvHeader.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHeader_CellEnter);
            this.ckSoloFormulasActivas.CheckedChanged -= new System.EventHandler(this.CkSoloFormulasActivas_CheckedChanged);
            this.ckRecalculoCosto.CheckedChanged -= new System.EventHandler(this.CkRecalculoCosto_CheckedChanged);
            //Inicializa Screen
            ckSoloFormulasActivas.Checked = true;
            ckRecalculoCosto.Checked = true;
            txtMaterial.Text = _material;
            var matdata = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
            txtDescripcion.Text = matdata.MAT_DESC;
            txtOrigen.Text = matdata.ORIGEN;
            txtMtype.Text = matdata.TIPO_MATERIAL;
            txtTC.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("N2");
            cmbMonedaCosto.SelectedItem = @"USD";

            if (matdata.FORM_COSTO == null || matdata.FORM_COSTO == 0)
            {
                _fCostAlmacenada = null;
                txtFormulaFCOST.Text = null;
                MessageBox.Show(@"Atencion no existe una formula para costeo seleccionada", @"FCOST Inexistente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFormulaDescription.Text = @"FCOST NO Seleccionada";
                //return;
            }
            else
            {
                _fCostAlmacenada = matdata.FORM_COSTO;
                txtFormulaFCOST.Text = _fCostAlmacenada.ToString();
                txtFormulaDescription.Text = new BOMManager().GetFormulaHeader(_fCostAlmacenada.Value).DESC_FORMULA;
            }
            this.dgvHeader.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHeader_CellEnter);
            BoMHeaderBs.DataSource =new BOMManager().GetListFormulasFromMaterial(_material, ckSoloFormulasActivas.Checked);
            this.ckSoloFormulasActivas.CheckedChanged += new System.EventHandler(this.CkSoloFormulasActivas_CheckedChanged);
            this.ckRecalculoCosto.CheckedChanged += new System.EventHandler(this.CkRecalculoCosto_CheckedChanged);
            SeleccionayColoreaDgv();
            if (_fCostAlmacenada!=null)
            CalculoCostoMemoria(_fCostAlmacenada.Value);
        }

        private void DgvHeader_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var idFormula = Convert.ToInt32(dgvHeader[iDFORMULADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            BoMItemsBs.DataSource = new BOMManager().GetFormulaItems(idFormula);
            _formulaSeleccionadaNew = Convert.ToInt32(dgvHeader[iDFORMULADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            dgvItems.ClearSelection();
        }

        private void CalculoCostoMemoria(int formulaCalculo)
        {
            if (formulaCalculo < 0)
                return;

            if (string.IsNullOrEmpty(txtTC.Text))
                txtTC.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("N2");

            if (cmbMonedaCosto.SelectedItem == null)
                cmbMonedaCosto.SelectedItem = "USD";
            
            var costoMfg = new CostMfgMemoria();
            costoMfg.CalculaMfgCost(formulaCalculo, cmbMonedaCosto.SelectedItem.ToString(),
                Convert.ToDecimal(txtTC.Text));

            txtCostoARS.Text = costoMfg.CostoARS.ToString("C2");
            txtCostoUSD.Text = costoMfg.CostoUSD.ToString("C2");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            _formulaSeleccionadaNew = Convert.ToInt32(datagridview[iDFORMULADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            if (ckRecalculoCosto.Checked)
                CalculoCostoMemoria(_formulaSeleccionadaNew.Value);
            
            
            
            
            //if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var T7YcellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            //_formulaSeleccionadaNew = Convert.ToInt32(datagridview[iDFORMULADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            //BoMItemsBs.DataSource = new BOMManager().GetFormulaItems(_fCostAlmacenada.Value);
        }

        private void BtnModificarFormulaCosteo_Click(object sender, EventArgs e)
        {
            if (_fCostAlmacenada == _formulaSeleccionadaNew)
            {
                MessageBox.Show(@"La Formula Seleccionada es la misma que ya estaba seleccionada!", @"FCOST sin Modificar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resp= MessageBox.Show(@"Confirma la modificacion de la formula de Costeo [FCOST]?", @"Modificacion de FCOST",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resp == DialogResult.No)
                return;

            var Cmfg = new CostoManufactura();
            Cmfg.UpdateFCost(_formulaSeleccionadaNew.Value);
            Cmfg.CalculaCosto(_material);


        }

        private void CkSoloFormulasActivas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloFormulasActivas.Checked)
            {
                BoMHeaderBs.DataSource = new BOMManager().GetListFormulasFromMaterial(_material, true);
            }
            else
            {
                BoMHeaderBs.DataSource = new BOMManager().GetListFormulasFromMaterial(_material, false);
            }
            SeleccionayColoreaDgv();
        }

        private void BtnExplosionCompleta_Click(object sender, EventArgs e)
        {
            if (_formulaSeleccionadaNew == null)
            {
                MessageBox.Show(
                    @"No Existe una Formula [FCOST] Seleccionada para poder visualizar la explosion completa de formula",
                    @"FCOST No Seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!ckRecalculoCosto.Checked)
            {
                MessageBox.Show(
                    @"No Se Encuentra Seleccioanda la Opcion de Recalculo",
                    @"Recalculo FCOST No Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }



            using (var f = new FrmCO06MfgCostExplosion(_material, _formulaSeleccionadaNew.Value))
            {
                f.ShowDialog();
            }
        }

        private void CkRecalculoCosto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckRecalculoCosto.Checked)
            {
                CalculoCostoMemoria(_formulaSeleccionadaNew.Value);
            }
            else
            {
                
            }
        }
    }
}
