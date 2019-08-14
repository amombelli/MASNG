using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Transactional.CO.Costos;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO08_CostManageControlCenter : Form
    {
        public FrmCO08_CostManageControlCenter()
        {
            InitializeComponent();
        }

        private Guid? costRollId = null;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCostoRepoMP_Click(object sender, EventArgs e)
        {
            var f1 = new FrmCO09_RevisionCostoMP();
            f1.Show();
        }

        private void btnLoadLastCR_Click(object sender, EventArgs e)
        {
            var headerData = new CostRollManager().GetCostRollHeaderActivo();
            if (headerData == null)
            {
                MessageBox.Show(@"No Existe ninguna version ACTIVA de Cost Roll para cargar",
                    @"Cost Roll Activo No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetValuesIndeterminado();
                return;
            }
            else
            {
                costRollId = headerData.idCostRoll;
            }
            UpdateStatus();
            MessageBox.Show(@"Los Datos del Ultimo Cost Roll Activo se han cargado correctamente", @"Datos Cargados",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SetValuesIndeterminado()
        {
            txtStatusEstructura.Text = @"Indeterminada";
            sEstructuraCreada.SetLights = CtlSemaforo.ColoresSemaforo.Azul;
            txtStatusCompras.Text = @"Indeterminada";
            cStatusCompras.SetLights = CtlSemaforo.ColoresSemaforo.Azul;
            txtRunTimeCompras.Text = 0.ToString();
            txtStatusFormulas.Text = @"Indeterminada";
            sCostosFormulasFinalizado.SetLights = CtlSemaforo.ColoresSemaforo.Azul;
            txtRunTimeFormulas.Text = 0.ToString();
            btnRunMp.Enabled = false;
            btnRunExplosion.Enabled = false;
        }
        private void UpdateStatus()
        {
            btnRunMp.Enabled = false;
            btnRunExplosion.Enabled = false;

            if (costRollId == null)
            {
                SetValuesIndeterminado();
            }
            else
            {
                var headerData = new CostRollManager().GetCostRollHeaderActivo();
                if (headerData == null)
                {
                    SetValuesIndeterminado();
                    costRollId = null;
                    return;
                }
                
                //header data
                costRollId = headerData.idCostRoll;
                txtGuidActivo.Text = headerData.idCostRoll.ToString();
                txtCostRollDescripcion.Text = headerData.Comentario;
                txtFecha.Text = headerData.FechaCostRoll.ToString("G");
                //
                txtRegistrosMP.Text = new CostRollExplosion().RetornaRegistrosT0035Compras().ToString();
                txtRegistrosFAB.Text = new CostRollExplosion().RetornaRegistrosT0035Fabricados().ToString();
                txtRegistrosExplosion.Text = new CostRollExplosion().RetornaRegistrosExplosion().ToString();
                txtRegistrosT0035.Text = new CostRollExplosion().RetornaRegistrosT0035().ToString();
                
                if (Convert.ToInt32(txtRegistrosExplosion.Text) > 0)
                {
                    txtStatusEstructura.Text = @"Finalizado";
                    sEstructuraCreada.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                    btnRunMp.Enabled = true;
                }
                else
                {
                    txtStatusEstructura.Text = @"Incomleta";
                    sEstructuraCreada.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                }

                if (headerData.RunTimeCompras > 0)
                {
                    txtStatusCompras.Text = @"Finalizado";
                    txtRunTimeCompras.Text = headerData.RunTimeCompras.Value.ToString();
                    btnRunExplosion.Enabled = true;
                    cStatusCompras.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                }
                else
                {
                    txtStatusCompras.Text = @"Pendiente";
                    txtRunTimeCompras.Text = 0.ToString();
                    cStatusCompras.SetLights = CtlSemaforo.ColoresSemaforo.Amarillo;
                }

                if (headerData.RunTimeFabricado > 0)
                {
                    txtStatusFormulas.Text = @"Finalizado";
                    txtRunTimeFormulas.Text = headerData.RunTimeFabricado.ToString();
                    sCostosFormulasFinalizado.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                }
                else
                {
                    txtStatusFormulas.Text = @"Pendiente";
                    txtRunTimeFormulas.Text = 0.ToString();
                    sCostosFormulasFinalizado.SetLights = CtlSemaforo.ColoresSemaforo.Amarillo;
                }
            }
        }
        private void btnRunMp_Click(object sender, EventArgs e)
        {
            if (costRollId == null)
            {
                MessageBox.Show(
                    @"No Existe ningun CostRoll-Cargado" + Environment.NewLine +
                    @"Cree un nuevo CostRoll para continuar", @"Cost Roll Inexistente", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(txtRunTimeFormulas.Text) > 0)
            {
                var resp = MessageBox.Show(
                    @"Esta seguro que quiere Ejecutar Nuevamente el CostRoll para MP. Esto eliminará toda la informacion de costos de Productos Terminados y tendra que volver a Ejecutarlo",
                    @"Confirmacion de Re-Costeo de MP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return;
            }
            new CostRollManager().CostRollRunMP(costRollId.Value);
            UpdateStatus();
        }
        private void btnCreateNewCostRoll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCostRollDescripcion.Text))
            {
                MessageBox.Show(@"Confirme una Descripcion para Identificar este Cost-Roll", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            var q = MessageBox.Show(
                @"Confirma la Ejecución de un nuevo Cost-Roll - Esta operacion ELIMINARA toda la informacion de costos anterior y tendra que re-ejecutarse todo el Costeo nuevamente",
                @"Confirmacion de Ejecucion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (q == DialogResult.No)
                return;
            
            costRollId = new CostRollManager().CreateNewCostRollHeader(txtCostRollDescripcion.Text);
            if (new CostRollManager().GeneraEstructuraCostRollNueva(costRollId.Value))
            {
                MessageBox.Show(@"Se ha regenerado toda la estructura de costos nuevamente en forma Exitosa",
                    @"Cost-Roll Estructura Lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Ha Ocurrido un Error y los Datos no se han podido crear. No se puede Continuar",
                    @"Cost-Roll Estructura Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateStatus();
        }
        private void FrmCO08_CostManageControlCenter_Load(object sender, EventArgs e)
        {
            UpdateStatus();
        }
        private void btnRunExplosion_MouseCaptureChanged(object sender, EventArgs e)
        {
            var runtime = new CostRollExplosion().SetCostForAllManufacturedMaterials(costRollId.Value);
            MessageBox.Show($@"Se ha Finalizao Correctamente el Costeo - COST-ROLL en {runtime.ToString()} segundos");
            UpdateStatus();
        }
        private void btnRepoMfg_Click(object sender, EventArgs e)
        {

        }
    }
}
