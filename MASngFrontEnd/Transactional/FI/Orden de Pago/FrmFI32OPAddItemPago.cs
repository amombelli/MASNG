using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.OrdenPago;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    public partial class FrmFI32OpAddItemPago : Form
    {
        public FrmFI32OpAddItemPago(FrmFI31OPMainScreen frm, int numeroOP, string tipoLx)
        {
            InitializeComponent();
            _numeroOP = numeroOP;
            txtLX.Text = tipoLx;
            _f = frm;
        }

        private readonly int _numeroOP;
        private readonly FrmFI31OPMainScreen _f;

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }


        private void ConfiguraCmb()
        {
            cmbCuenta.ValueMember = "ID_CUENTA";
            cmbCuenta.DisplayMember = "CUENTA_DESC";
            cmbCuenta.DataSource = new CuentasManager().GetListCuentasAvailableOP();
        }

        private void FrmOrdenPagoAddItemsPago_Load(object sender, EventArgs e)
        {
            txtNumeroOP.Text = _numeroOP.ToString();
            ConfiguraCmb();
        }

        private void btnAddItemPago_Click(object sender, EventArgs e)
        {
            var op = new OrdenPagoManageDatos(_numeroOP);
            decimal numero;
            if (decimal.TryParse(txtImporteOrigen.Text, out numero) == true)
            {
                op.AddItemPago(cmbCuenta.SelectedValue.ToString(), numero);

                new OPImputaFacturas(_numeroOP).ImputaFacturasOP();
                _f.RefreshDgvItemsdePago();
                _f.RecalculaTotalesOP();


               // _f.RecalculaDgvItemsOrdenPago();
               // _f.RecalculaDgvFacturasAPagar();
            }
            else
            {
                
            }
        }

        private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dataCuenta = new CuentasManager().GetSpecificCuentaInfo(cmbCuenta.SelectedValue.ToString());
            txtMoneda.Text = dataCuenta.CUENTA_MONEDA;
            txtTipoCuenta.Text = dataCuenta.CUENTA_TIPO;
            switch (txtTipoCuenta.Text)
            {
                case "CHEQUE":
                    btnAddItemPago.Enabled = false;
                    var f2 = new FrmFI34BusquedaCheques(_f,txtLX.Text, "OP", Convert.ToInt32(txtNumeroOP.Text));
                    f2.Show();
                    this.Close();

                    break;
                default:
                    btnAddItemPago.Enabled = true;
                    break;


            }
        }
    }
}
