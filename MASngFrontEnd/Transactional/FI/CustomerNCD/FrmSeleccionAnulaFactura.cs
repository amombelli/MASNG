using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.MainDocumentData;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmSeleccionAnulaFactura : Form
    {
        public FrmSeleccionAnulaFactura(int idCliente, string tipoLx)
        {
            _idCliente = idCliente;
            _tipoLx = tipoLx;
            InitializeComponent();

        }

        private int _idCliente;
        private string _tipoLx;
        public int? IdFacturaSeleccionada;



        private void FrmSeleccionAnulaFactura_Load(object sender, EventArgs e)
        {
            CompletaData();
            t0400FACTURAHBindingSource.DataSource =
                new NCDAnulaDocumento().GetListaDocumentos(_idCliente, _tipoLx).ToList();


        }

        private void CompletaData()
        {
            var clidata = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtRazonSocial.Text = clidata.cli_rsocial;
            txtFantasia.Text = clidata.cli_fantasia;
            txtId6.Text = _idCliente.ToString();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;

        }

        private void dgvListadoFacturas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdFacturaSeleccionada =Convert.ToInt32(dgvListadoFacturas[dgvListadoFacturas.Columns["iDFACTURADataGridViewTextBoxColumn"].Index, e.RowIndex].Value);
            }
            else
            {
                IdFacturaSeleccionada = null;
            }
        }
    }
}
