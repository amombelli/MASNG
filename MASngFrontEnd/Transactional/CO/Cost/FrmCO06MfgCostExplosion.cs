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
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO06MfgCostExplosion : Form
    {
        private readonly string _material;
        private readonly int _formulaId;
        private readonly List<CostItems> _lista;

        public FrmCO06MfgCostExplosion(string material, int formulaId)
        {
            _material = material;
            _formulaId = formulaId;
            InitializeComponent();
        }

        private void FrmCO06MfgCostExplosion_Load(object sender, EventArgs e)
        {
            txtmaterial.Text = _material;
            var matData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
            txtDescripcion.Text = matData.MAT_DESC;
            txtOrigen.Text = matData.ORIGEN;
            txtIdFormula.Text = _formulaId.ToString();
            var formData = new BOMManager().GetFormulaHeader(_formulaId);
            txtFormulaDescription.Text = formData.DESC_FORMULA;
            txtMonedaCost.Text = @"USD";
            tc.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("N2");
            rbUC.Checked = true;
            
            var costoMfg = new CostMfgMemoria();
            costoMfg.CalculaMfgCost(_formulaId, txtMonedaCost.Text,
                Convert.ToDecimal(tc.Text));

            txtCostoARS.Text = costoMfg.CostoARS.ToString("C2");
            txtCostoUSD.Text = costoMfg.CostoUSD.ToString("C2");
            itemsBs.DataSource = costoMfg.CostItems;






        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
