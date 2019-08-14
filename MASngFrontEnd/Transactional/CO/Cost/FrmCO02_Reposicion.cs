using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Security;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO02_Reposicion : Form
    {
        public FrmCO02_Reposicion()
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CO01", "CO01"))
                return;
            InitializeComponent();
        }

        private string _material;

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCO02_Reposicion_Load(object sender, EventArgs e)
        {
            this.cmbMaterial.SelectedIndexChanged -= new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
            BindingSource bs = new BindingSource();
            bs.DataSource = MaterialMasterManager.GetCompraMaterialList(false);
            cmbMaterial.DataSource = bs;
            cmbMaterial.SelectedIndex = -1;
            tc.Init((decimal)0.01,1000,2,false,true,false);
            tc.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString();
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
        }

        private void MapCostData()
        {
            var repositionCost = new CostoReposicion();
            var repoCost= repositionCost.GetCosto(_material, tc.ValueD,false);
            if (repoCost.Kg <= 0)
            {
                var rsp = MessageBox.Show(
                    @"No se ha encontrado informacion de Ultima Compra. Se intenta obtener info automaticamente",
                    @"Datos No Encontrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                repositionCost.FixObtieneCostoUcFromUltimoRegistro(_material);
                repoCost = repositionCost.GetCosto(_material, tc.ValueD,false);
            }
            txtCostoUCARS.Text = repoCost.ARS.ToString("C2");
            txtCostoUCUSD.Text = repoCost.USD.ToString("C2");
            txtFechaUC.Text = repoCost.Fecha.ToString("d");
            txtKGUC.Text = repoCost.Kg.ToString("N2");
            txtProveedorUC.Text = repoCost.VendorUc;
            txtMonedaUC.Text = repoCost.MonedaCosto;
            if (txtMonedaUC.Text == @"USD")
            {
                txtCostoUCARS.BackColor = Color.DarkGray;
                txtCostoUCUSD.BackColor = Color.Yellow;
            }
            else
            {
                txtCostoUCARS.BackColor = Color.Yellow;
                txtCostoUCUSD.BackColor = Color.DarkGray;
            }

            txtVarPrecioArs.Text = repoCost.VarArs.ToString("C2");
            txtVarPrecioUsd.Text = repoCost.VarUsd.ToString("C2");
            ckManualUpdated.Checked = repoCost.ManualUpdated;
            txtFechaUpdAnterior.Text = repoCost.FechaCostoAnterior.ToString("g");

        }
        private void CmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex != -1)
            {
                _material = cmbMaterial.SelectedValue.ToString();
                new CostoReposicion().FixCostosReposicionCeroOldVersion(_material);
                var materialData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
                txtDescripcion.Text = materialData.MAT_DESC;
                txtOrigen.Text = materialData.ORIGEN;
                txtMtype.Text = materialData.TIPO_MATERIAL;
                MapCostData();
                costoUltimasComprasBindingSource.DataSource = new CostoReposicion().GetListadoUC(_material, 10);

            }
            else
            {
                //Blanquea Info Costos
                txtCostoUCARS.Text = 0.ToString("C2");
                txtCostoUCUSD.Text = 0.ToString("C2");
                txtFechaUC.Text = null;
                txtKGUC.Text = 0.ToString("N2");
                txtProveedorUC.Text = null;
                _material = null;
                txtOrigen.Text = null;
                txtDescripcion.Text = null;
                txtCostoUCARS.BackColor = Color.DarkGray;
                txtCostoUCUSD.BackColor = Color.DarkGray;
                costoUltimasComprasBindingSource.DataSource = null;
                txtVarPrecioArs.Text = 0.ToString("C2");
                txtVarPrecioUsd.Text = 0.ToString("C2");
                ckManualUpdated.Checked = false;
                txtFechaUpdAnterior.Text = null;
            }
        }
        private void CmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbMaterial);
        }

        private void BtnVerDetalleUC_Click(object sender, EventArgs e)
        {
            using (var f = new FrmCO05HistorialCostoReposicion(_material))
            {
                f.ShowDialog();
            }
        }

        private void Tc_Validating(object sender, CancelEventArgs e)
        {
            if (_material != null)
            {
                MapCostData();
            }
        }

        private void BtnUpdateUC_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"No se encuentra desarrollada la funcionalidad de Modificacion Costo Ultima Compra",
                @"Sin Codificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSetAsStandard_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(@"Desea definir este costo como el costo standard?",
                @"Definicion de Costo Standard", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            var costo = FormatAndConversions.CCurrencyADecimal(txtMonedaUC.Text == @"USD" ? txtCostoUCUSD.Text : txtCostoUCARS.Text);
            new CostoStandard().AddUpdateCosto(_material, txtMonedaUC.Text, costo, tc.ValueD, false,CostoStandard.CostDeterminatedBy.MRepo);

            MessageBox.Show(@"Se ha definido el costo de Ultima Compra como Costo Standard", @"Actualizacion Existosa",
                MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
