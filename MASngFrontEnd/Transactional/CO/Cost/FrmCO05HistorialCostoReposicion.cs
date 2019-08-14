using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.PP;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO05HistorialCostoReposicion : Form
    {
        private readonly string _material;
        private decimal tc;

        public FrmCO05HistorialCostoReposicion(string material)
        {
            _material = material;
            InitializeComponent();
        }

        public FrmCO05HistorialCostoReposicion()
        {
            InitializeComponent();
        }

        private void FrmCO05HistorialCostoReposicion_Load(object sender, EventArgs e)
        {
            tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            txtTc.Text = tc.ToString("N2");
            if (!string.IsNullOrEmpty(_material))
            {
                //Apertura con material
                cmbMaterial.Text = _material;
                cmbMaterial.Enabled = false;
                var matData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
                txtDescripcion.Text = matData.MAT_DESC;
                txtMtype.Text = matData.TIPO_MATERIAL;
                txtOrigen.Text = matData.ORIGEN;
                CompleteData(_material);
                costoUltimasComprasBindingSource.DataSource = new CostoReposicion().GetListadoUC(_material, 10);
            }
        }

        private void CompleteData(string material)
        {
            var repo = new CostoReposicion().GetCostoReposicionUc(material,tc);
            txtCostoARS.Text = repo.ARS.ToString("C2");
            txtCostoUSD.Text = repo.USD.ToString("C2");
            txtMonedaCost.Text = repo.MonedaCosto;
            txtFechaUpdate.Text = repo.Fecha.ToString("d");
            

            var std = new CostoStandard().GetCosto(material);
            txtStdARS.Text = std.CostoARS.ToString("C2");
            txtStdUSD.Text = std.CostoUSD.ToString("C2");
            


            //txtMfgArs.Text = mfgCost.ARS.ToString("C2");
            //txtMfgUsd.Text = mfgCost.USD.ToString("C2");
            //txtFechaUpdate.Text = mfgCost.Fecha.ToString("d");
            //txtUserLog.Text = mfgCost.User;
            //txtMonedaCost.Text = mfgCost.MonedaCost;
            //txtTC.Text = mfgCost.TC.ToString("N2");
            //txtIdFormula.Text = mfgCost.FormulaId.ToString();
            //txtOrigen.Text = mfgCost.Origen;
            //CostBs.DataSource = new CostoManufactura().GetExplosionListLevel1(material);
            //if (mfgCost.FormulaId > 1)
            //{
            //    var formData = new BOMManager().GetFormulaHeader(mfgCost.FormulaId);
            //    txtFormulaDescription.Text = formData.DESC_FORMULA;
            //}
            //else
            //{
            //    txtFechaUpdate.Text = @"Formula No Seleccionada";
            //}
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender,e);
        }

        private void TxtTc_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTc.Text))
            {
                tc = 1;
            }
            else
            {
                tc = Convert.ToDecimal(txtTc.Text);
                if (tc <= 0)
                    tc = 1;
            }
            txtTc.Text = 1.ToString("n2");
        }
    }
}
