using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.Cobranza;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmDetalleImputacionPorRecibo : Form
    {
        public FrmDetalleImputacionPorRecibo(int idCobranza)
        {
            _idCob = idCobranza;
            InitializeComponent();
        }
        //--------------------------------------------------------------
        private readonly int _idCob;

        //--------------------------------------------------------------

        private void FrmDetalleImputacionPagoFactura_Load(object sender, EventArgs e)
        {
            t0207SPLITFACTURASBindingSource.DataSource = new CobranzaUtils().GetListaImputacionPorRecibo(_idCob);
            LoadHeaderData();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadHeaderData()
        {
            var cobH = new CobranzaSearch().GetCobranzaHeader(_idCob);
            var cli = new CustomerManager().GetCustomerBillToData(cobH.CLIENTE.Value);
            var ctacte = new CobranzaUtils().GetT0201FromCobranza(_idCob);
            if (ctacte != null)
            {
                txtMontoPendienteImputacion.Text = Math.Abs(ctacte.SALDOFACTURA).ToString("C2");
                if (ctacte.SALDOFACTURA == 0)
                {
                    //ckCobranzaImputada.Checked = true;
                    //ckCobranzaImputada.BackColor = Color.GreenYellow;
                    //btnImputarCobranza.Enabled = false;
                    txtMontoPendienteImputacion.BackColor=Color.GreenYellow;
                }
                else
                {
                    //ckCobranzaImputada.Checked = false;
                    //ckCobranzaImputada.BackColor = Color.Orange;
                    //btnImputarCobranza.Enabled = true;
                    txtMontoPendienteImputacion.BackColor = Color.OrangeRed;
                }
            }
            else
            {
                //ckCobranzaImputada.BackColor = Color.Pink;
                //txtMontoPendienteImputacion.Text = @"Error!";
            }
            txtRazonSocial.Text = cli.cli_rsocial;
            txtFantasia.Text = cli.cli_fantasia;
            txtId6.Text = cli.IDCLIENTE.ToString();
            txtIdCob.Text = _idCob.ToString();
            txtFecha.Text = cobH.FECHA.Value.ToString("d");
            txtImporte.Text = cobH.Monto.Value.ToString("C2");
            txtMoneda.Text = cobH.MON;
            txtMoneda1.Text = txtMoneda2.Text = txtMoneda.Text;
            txtReciboInterno.Text = cobH.NRECIBO;
            txtReciboOficial.Text = cobH.NRECIBOOFI;
            txtTotalImputado.Text = (cobH.Monto.Value + ctacte.SALDOFACTURA).ToString("C2");
            txtLx.Text = cobH.CUENTA;
            txtDiasPP.Text = cobH.DIAS_PP.ToString();
            txtTCRecibo.Text = cobH.TC.Value.ToString("N2");

            CalculaPorcentajeApplicacion();
        }

        private void CalculaPorcentajeApplicacion()
        {
          //Define formato para resaltar
            //DataGridViewCellStyle highlightStyle = new DataGridViewCellStyle
            //{
            //    //ForeColor = Color.Red,
            //    BackColor = Color.DarkKhaki,
            //    //Font = new Font(dgvLista.Font, FontStyle.Bold)
            //    Format = "P2",
            //    NullValue = 0,
            //};

            foreach (DataGridViewRow row in dgvLista.Rows)
            {
                // Calculate total cost.
                decimal porcentajeAppl =
                    Math.Round(((decimal)row.Cells[mONTOAPLICADODataGridViewTextBoxColumn.Name].Value /
                    (decimal)row.Cells[tOTALDOCUMENTO.Name].Value),4);

                // Display the value.
                row.Cells[aplicadoPorcentaje.Name].Value = porcentajeAppl;

                // Highlight the cell if the vcalue is big.
                if (porcentajeAppl == 1)
                {
                   row.Cells[aplicadoPorcentaje.Name].Style.BackColor = Color.LightBlue;
                }
            }
        }
    }
}
