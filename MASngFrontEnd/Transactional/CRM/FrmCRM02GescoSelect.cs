using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Transactional.CRM;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.CRM
{
    public partial class FrmCRM02GescoSelect : Form
    {
        public FrmCRM02GescoSelect()
        {
            InitializeComponent();
        }

        private List<GescoStructure> _list = new List<GescoStructure>();

        private void FrmCRM02GescoSelect_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _list = new GescoListManager().PopulateGescoList();
            gescoStructureBindingSource.DataSource =
                _list.Where(c => c.SaldoTotal != 0).OrderByDescending(c => c.SaldoTotal);
            Cursor.Current = Cursors.Default;
            rbMayorDeuda.Checked = true;
        }

        private void rbCallRequest_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton) sender;
            switch (rb.Name)
            {
                case "rbCallRequest":
                    gescoStructureBindingSource.DataSource= _list.Where(c => c.CallRequest);
                    break;
                case "rbConciliacionRequest":
                    gescoStructureBindingSource.DataSource = _list.Where(c => c.ConciliarCtaRequest);
                    break;
                case "rbDocumentosImpagos":
                    gescoStructureBindingSource.DataSource = _list.OrderByDescending(c => c.DocumentosImpagos);
                    break;
                case "rbLimiteExcedido":
                    gescoStructureBindingSource.DataSource = _list.Where(c =>c.LimiteCredito !=null && ( c.LimiteCredito < c.SaldoTotal))
                        .OrderByDescending(c => c.LimiteCredito.Value);
                    break;
                case "rbMayorDeuda":
                    gescoStructureBindingSource.DataSource = _list.OrderByDescending(c => c.SaldoTotal);
                    break;
                case "rbProximaLlamada":
                    gescoStructureBindingSource.DataSource = _list.Where(c => c.ProximaLlamada != null).OrderByDescending(c => c.ProximaLlamada.Value);
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListadoGesco_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idCliente = Convert.ToInt32(datagridview[idClienteDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "VER":
                    var f0 = new FrmCRM03GescoMain(2, idCliente);
                    f0.Show();
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
    }
}
