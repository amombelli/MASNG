using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;

namespace MASngFE.Transactional.SD.SalesOrder
{
    public enum MotivoSc
    {
        Muestra,
        Reproceso,
        BonificacionEspecial,
        Cambio,
        NoAplica,
    };
    public partial class FrmMotivoSinCargo : Form
    {
        public FrmMotivoSinCargo(int idOv, int idItem, string material, int idCliente)
        {
            InitializeComponent();
            txtSalesOrder.Text = idOv.ToString();
            txtItem.Text = idItem.ToString();
            txtMaterial.Text = material;
            _idCliente = idCliente;
        }

        private readonly int _idCliente;
        public MotivoSc Motivo;
        public string Autorizo;
        private void FrmMotivoSinCargo_Load(object sender, EventArgs e)
        {
            var cliente = new CustomerManager().GetCustomerBillToData(_idCliente).cli_rsocial;
            txtCliente.Text = cliente;
            t0085PERSONALBindingSource.DataSource = new HumanResourcesManager().GetListAutorizaOperacionesSinCargo();
            cmbAutorizo.DataSource = t0085PERSONALBindingSource;
            rbMuestraSinCargo.Checked = true;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void cmbAutorizo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAutorizo.SelectedIndex == -1)
            {
                Autorizo = null;
                return;
            }
            Autorizo = cmbAutorizo.SelectedValue.ToString();
        }

        private void rbCambioMaterial_CheckedChanged(object sender, EventArgs e)
        {
            var boton = (RadioButton) sender;
            switch (boton.Name)
            {
                case "rbMuestraSinCargo":
                    Motivo = MotivoSc.Muestra;
                    break;
                case "rbBonificacionEspecial":
                    Motivo = MotivoSc.BonificacionEspecial;
                    break;
                case "rbCambioMaterial":
                    Motivo = MotivoSc.Cambio;
                    break;
                case "rbReproceso":
                    Motivo = MotivoSc.Reproceso;
                    break;
                default:
                    Motivo = MotivoSc.NoAplica;
                    break;
            }
        }
    }
}
