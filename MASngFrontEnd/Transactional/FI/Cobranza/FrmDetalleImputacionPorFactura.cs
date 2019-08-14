using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.MainDocumentData;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmDetalleImputacionPorFactura : Form
    {
        public FrmDetalleImputacionPorFactura(int idFactura)
        {
            _idFactura = idFactura;
            InitializeComponent();
        }

        //------------------------------------------------------------------------
        private readonly int _idFactura;
        private int _idCtaCte;

        //------------------------------------------------------------------------
        private void FrmDetalleImputacionPorFactura_Load(object sender, EventArgs e)
        {
            LoadHeaderData();
            t0207SPLITFACTURASBindingSource.DataSource =
                new ImputacionCobranzas().GetListaRecibosImputanFactura(_idCtaCte);

            CalculaPorcentajeApplicacion();


        }


        private void LoadHeaderData()
        {
            var dataF = new CustomerInvoice("FAC", _idFactura).GetHeaderData();
            var cli = new CustomerManager().GetCustomerBillToData(dataF.Cliente.Value);
   
            txtRazonSocial.Text = cli.cli_rsocial;
            txtFantasia.Text = cli.cli_fantasia;
            txtId6.Text = cli.IDCLIENTE.ToString();
            txtFecha.Text = dataF.FECHA.Value.ToString("d");
            _idCtaCte = dataF.IdCtaCte.Value;
            txtLx.Text = dataF.TIPOFACT;
            txtTdoc.Text = dataF.TIPO_DOC;

            if (txtLx.Text == @"L1")
            {
                txtNumeroDoc.Text = dataF.PV_AFIP + @"-" + dataF.ND_AFIP;
            }
            else
            {
                txtNumeroDoc.Text = dataF.Remito;
            }
            txtTc.Text = dataF.TC.Value.ToString("n2");
            var SaldoPendienteDoc = new ImputacionCobranzas().GetSaldoPendientePagoDocumento(_idCtaCte);
            txtMoneda.Text = txtMon1.Text = dataF.FacturaMoneda;
            txtImporte.Text = dataF.TotalFacturaN.ToString("C2");
            var imputado = dataF.TotalFacturaN - SaldoPendienteDoc;
            txtImputado.Text = imputado.ToString("C2");
            txtPorcentajeImputado.Text = (imputado/dataF.TotalFacturaN).ToString("P2");
            if (dataF.TotalFacturaN - imputado == 0)
            {
                txtImputado.BackColor = Color.GreenYellow;
            }
            else
            {
                txtImputado.BackColor= Color.Orange;
            }


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
                    (decimal)row.Cells[tOTALDOCUMENTO.Name].Value), 4);

                // Display the value.
                row.Cells[aplicadoPorcentaje.Name].Value = porcentajeAppl;

                // Highlight the cell if the vcalue is big.
                if (porcentajeAppl == 1)
                {
                    row.Cells[aplicadoPorcentaje.Name].Style.BackColor = Color.LightBlue;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
