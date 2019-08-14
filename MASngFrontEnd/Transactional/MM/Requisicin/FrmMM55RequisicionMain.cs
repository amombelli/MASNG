using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.MM;

namespace MASngFE.Transactional.MM.Requisicin
{
    public partial class FrmMM55RequisicionMain : Form
    {
        private int _idRc;
        private RcStatusManagement.Status statusRc;

        public FrmMM55RequisicionMain()
        {
            InitializeComponent();
            txtFechaRc.Text = DateTime.Today.ToString("d");
            txtSolicitadoPor.Text = GlobalApp.AppUsername;
            txtStatusRc.Text = RcStatusManagement.Status.Inicial.ToString();
            txtNumeroOC.Text = null;
            statusRc = RcStatusManagement.Status.Inicial;
            _idRc = 0;
        }

        public FrmMM55RequisicionMain(int idRc)
        {
            _idRc = idRc;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AccionSegunStatus()
        {
            btnGenerarRc.Enabled = false;
            btnGenerarOC.Enabled = false;
            btnCancelarRc.Enabled = false;
            btnAutorizarOC.Enabled = false;
            cmbMaterial.Enabled = false;
            uKgConteo.ReadOnly = true;
            ckConteo.Enabled = false;
            uKgRC.ReadOnly = true;
            txtComentarioRc.ReadOnly = true;
            txtComentarioOc.ReadOnly = true;
            switch (statusRc)
            {
                case RcStatusManagement.Status.Inicial:
                    btnGenerarRc.Enabled = true;
                    cmbMaterial.Enabled = true;
                    uKgConteo.ReadOnly = false;
                    ckConteo.Enabled = true;
                    uKgRC.ReadOnly = false;
                    txtComentarioRc.ReadOnly = false;
                    break;
                case RcStatusManagement.Status.Cancelado:
                    break;
                case RcStatusManagement.Status.RCGenerada:
                    btnAutorizarOC.Enabled = true;
                    btnCancelarRc.Enabled = true;
                    txtComentarioOc.ReadOnly = false;
                    break;
                case RcStatusManagement.Status.Aprobado:
                    btnGenerarOC.Enabled = true;
                    break;
                case RcStatusManagement.Status.OCGenerada:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void LoadRcData()
        {
            var dat = new RcManagement().GetRequisicion(_idRc);
            txtNumeroRc.Text = _idRc.ToString();
            txtStatusRc.Text = dat.StatusRc;
            statusRc = RcStatusManagement.MapTextToStatus(dat.StatusRc);
            txtNumeroOC.Text = dat.NumeroOC.ToString();
            if (dat.NumeroOC != null)
            {
                var oc = new OrdenCompraManager().GetDataOcHeader(dat.NumeroOC.Value);
                txtStatusOC.Text = oc.STATUSOC;
            }

            txtFechaRc.Text = dat.FechaRc.ToString("d");
            txtSolicitadoPor.Text = dat.UserRc;
            cmbMaterial.SelectedItem = dat.Material;
            var matdata = new MaterialMasterManager().GetPrimarioInfo(dat.Material);

            txtMaterialDescripcion.Text = matdata.MAT_DESC;
            txtStockMinimo.Text = matdata.StockMinimo.ToString();
            txtKgStockAuto.Text = "";
            if (dat.KgStockRevisado != null)
            {
                uKgConteo.ValueD = dat.KgStockRevisado.Value;
            }

            uKgRC.ValueD = dat.KgRequeridos;
            txtComentarioRc.Text = dat.ComentarioRc;
            txtRcAprobada.Text = dat.AproboOC;
            txtFechaAprobacionRc.Text = dat.FechaAproboOC.ToString();
            txtComentarioOc.Text = dat.CometarioOC;
        }

        private void FrmMM55RequisicionMain_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = MaterialMasterManager.GetCompraMaterialList(true);
            cmbMaterial.DataSource = bs;
            cmbMaterial.SelectedIndex = -1;
            uKgConteo.Init(0,100000,true,false,false);
            uKgRC.Init(0, 100000, true, false, false);

            if (_idRc > 0)
            {
                LoadRcData();
            }
            AccionSegunStatus();

            


        }


        private void btnGenerarRc_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedValue == null)
            {
                MessageBox.Show(@"Debe completar el Material Requerido", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (uKgRC.ValueD <= 0)
            {
                MessageBox.Show(@"Debe proveer una sugerencia de Kg a Comprar", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            

            var resp = MessageBox.Show(@"Confirma la generacion de la Requisicion de Compra (RC)?",
                @"Confirmacion de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            decimal? kgconteo = null;
            if (ckConteo.Value == true)
            {
                kgconteo = uKgConteo.ValueD;
            }

            var idx = new RcManagement().CreateNewRc(cmbMaterial.SelectedValue.ToString(), kgconteo, uKgRC.ValueD,
                txtComentarioRc.Text);

            txtNumeroRc.Text = idx.ToString();
            statusRc = RcStatusManagement.Status.RCGenerada;
            txtStatusRc.Text = statusRc.ToString();
            _idRc = idx;
            AccionSegunStatus();


        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                txtMaterialDescripcion.Text = null;
                txtKgStockAuto.Text = null;
                txtStockMinimo.Text = null;
                uKgConteo.Text = null;
                return;
            }

            var matdata = new MaterialMasterManager().GetPrimarioInfo(cmbMaterial.SelectedValue.ToString());
            txtMaterialDescripcion.Text = matdata.MAT_DESC;
            txtStockMinimo.Text = matdata.StockMinimo.ToString();
            txtKgStockAuto.Text = new StockAvilability().AvailableStockForProduccion(matdata.IDMATERIAL, "CERR")
                .ToString("N2");
        }

        private void uKgConteo_Validated(object sender, EventArgs e)
        {
            ckConteo.Value = uKgConteo.ValueD > 0;
        }

        private void cmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedValue == null && combo.Text != string.Empty)
                e.Cancel = true;
        }

        private void btnCancelarRc_Click(object sender, EventArgs e)
        {
            new RcStatusManagement().SetCancelado(_idRc);

            AccionSegunStatus();
        }

        private void btnAutorizarOC_Click(object sender, EventArgs e)
        {
            if (uKgRC.ValueD <= 0)
            {
                MessageBox.Show(@"No se puede autorizar una OC con Kg = 0", @"Datos Incorectos", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            new RcStatusManagement().SetRCAprobada(_idRc,txtComentarioRc.Text);
           
            AccionSegunStatus();
        }

        private void btnGenerarOC_Click(object sender, EventArgs e)
        {
            //

            AccionSegunStatus();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
