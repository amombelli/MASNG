using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;
using TecserSQL.Data.MasterData;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO07CostoStandard : Form
    {
        public FrmCO07CostoStandard()
        {
            InitializeComponent();
        }

        private string _material;


        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSetAsStandard_Click(object sender, EventArgs e)
        {

        }

        private void CmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                txtCostoArs.Text = 0.ToString("C2");
                txtCostoUsd.Text = 0.ToString("C2");
                txtMoneda.Text = @"USD";
                txtFecha.Text = null;
                txtCostDeterminedBy.Text = null;
                return;
            }

            _material = cmbMaterial.SelectedValue.ToString();
            var matData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
            txtDescripcion.Text = matData.MAT_DESC;
            txtOrigen.Text = matData.ORIGEN;
            txtMtype.Text = matData.TIPO_MATERIAL;
            //
            var xcosto = new CostoStandard().GetCosto(_material, Convert.ToDecimal(tc.Text));
            txtCostoArs.Text = xcosto.CostoARS.ToString("C3");
            txtCostoUsd.Text = xcosto.CostoUSD.ToString("C3");
            txtMoneda.Text = xcosto.Moneda;
            txtCostDeterminedBy.Text = xcosto.CostDetermination;
            txtFecha.Text = xcosto.FechaCosto.ToString("d");

            //Define costo de referencia
            if (txtOrigen.Text == @"FAB")
            {
                if (matData.FORM_COSTO == null)
                {
                    //no se puede obtener costo
                    MessageBox.Show(
                        @"No se puede obtener un costo de referencia de manufactura porque el material no tiene definido un FCOST",
                        @"Material sin FCOST", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (matData.FORM_COSTO.Value < 1)
                    {
                        MessageBox.Show(
                            @"No se puede obtener un costo de referencia de manufactura porque el material no tiene definido un FCOST",
                            @"Material sin FCOST", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var mfg = new CostMfgMemoria();
                    mfg.CalculaMfgCost(matData.FORM_COSTO.Value, txtMoneda.Text,tc.ValueD);
                    txtCostoRefArs.Text = mfg.CostoARS.ToString("C3");
                    txtCostoRefUsd.Text = mfg.CostoUSD.ToString("C3");
                    txtMonedaReferencia.Text = "";
                    txtFechaCostoRef.Text = "";
                }
                
            }
            else
            {
                var costo2 = new CostoReposicion().GetCosto(_material, tc.ValueD, true);
                txtCostoRefArs.Text = costo2.ARS.ToString("C3");
                txtCostoRefUsd.Text = costo2.USD.ToString("C3");
                txtMonedaReferencia.Text = costo2.MonedaCosto;
                txtFechaCostoRef.Text = costo2.Fecha.ToString("g");
            }
        }

        private void FrmCO07CostoStandard_Load(object sender, EventArgs e)
        {
            tc.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("N2");
            this.cmbMaterial.SelectedIndexChanged -= new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
            BindingSource bs = new BindingSource();
            bs.DataSource = MaterialMasterManager.GetMaterialList(false);
            cmbMaterial.DataSource = bs;
            cmbMaterial.SelectedIndex = -1;
            tc.Init((decimal)0.01, 1000, 2, false, true, false);
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);



        }

        private void CmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbMaterial);
        }

    }
}
