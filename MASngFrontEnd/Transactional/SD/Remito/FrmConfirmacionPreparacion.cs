using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.SD;

namespace MASngFE.Transactional.SD.Remito
{
    public partial class FrmConfirmacionPreparacion : Form
    {
        public FrmConfirmacionPreparacion(int idRemito)
        {
            _idRemito = idRemito;
            InitializeComponent();
        }

        private readonly int _idRemito;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cboResponsablePrep.SelectedValue == null)
            {
                MessageBox.Show(@"Debe completar un responsable de preparacion", @"Responsable de Preparacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtCantidadBultos.Text))
            {
                MessageBox.Show(@"Debe Completar la cantidad de Bultos en la preparacion", @"Cantidad de Bultos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
                



            if (new RemitoStatusManager().SetStatusHeaderPreparado(_idRemito, Convert.ToInt32(txtCantidadBultos.Text),
                cboResponsablePrep.SelectedValue.ToString(), txtComentarioPreparacion.Text))
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                MessageBox.Show(
                    @"NO SE HA PODIDO CONFIRMAR la preparacion porque alguno de los items no tienen lote asignado o continene algun error",
                    @"Error en preparacion del Remito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void FrmConfirmacionPreparacion_Load(object sender, EventArgs e)
        {
            SetDefaultValues();
            LoadData();
        }

        private void LoadData()
        {
            var data = new RemitoGeneracionImpresion().GetRemitoHeader(_idRemito);
            txtCantidadBultos.Text = data.CANTBULTOS.ToString();
            txtComentarioPreparacion.Text = data.COM_PREP;

            if (data.PREPAREDBY == null)
            {
                cboResponsablePrep.SelectedValue = "";
            }
            else
            {
                cboResponsablePrep.DataSource = new HumanResourcesManager().GetListPermiteDespacho();
                cboResponsablePrep.SelectedValue = data.PREPAREDBY.Trim();
            }

            var cliente = new CustomerManager().GetCustomerShipToData(data.CODCLIENTREGA.Value);
            txtClienteDescripcion.Text = cliente.ClienteEntregaDesc;
            txtIdRemito.Text = _idRemito.ToString();
        }
        private void SetDefaultValues()
        {
            cboResponsablePrep.DataSource = new HumanResourcesManager().GetListPermiteDespacho();
            cboResponsablePrep.ValueMember = "ID_VEND";
            cboResponsablePrep.DisplayMember = "SHORTNAME";
        }

        private void txtCantidadBultos_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender,e);
        }
    }
}
