using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;

namespace MASngFE.Transactional.SD.SalesOrder
{
    public partial class FrmMM18CompromisoMaterial : Form
    {
        public FrmMM18CompromisoMaterial(int salesOrder,int idItemSalesOrder,string materialAKA, decimal kgPedidos)
        {
            _idSalesOrder = salesOrder;
            _idItemSalesOrder = idItemSalesOrder;
            _materialAKA = materialAKA;
            _materialPrimario = new MaterialMasterManager().GetPrimarioFromAka(materialAKA);
            _kgPedidos = kgPedidos;
            InitializeComponent();
        }

        private readonly int _idSalesOrder;
        private readonly int _idItemSalesOrder;
        private readonly string _materialAKA;
        private readonly string _materialPrimario;
        private readonly decimal _kgPedidos;
#pragma warning disable CS0169 // The field 'FrmCompromisoMaterial.kgReservados' is never used
        private decimal kgReservados;
#pragma warning restore CS0169 // The field 'FrmCompromisoMaterial.kgReservados' is never used
        private int idStockSeleccionado;
        private StockStatusManager.EstadoLote _estadoSeleccionado;
        private decimal kgSeleccionados;
        public decimal KgReservados { get; private set;}


        private void FrmCompromisoMaterial_Load(object sender, EventArgs e)
        {
            txtMaterial.Text = _materialAKA;
            txtSalesOrderNumber.Text = _idSalesOrder.ToString();
            txtKgSolicitiados.Text = _kgPedidos.ToString("N2");
            ckOnlyAvailable.Checked = true;
            dgvListaMateriales.DataSource = new StockList().GetAllByMaterial_DisponibleDespacho(_materialPrimario);
            btnComprometer.Enabled = true;
        }

        private void dgvListaMateriales_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            idStockSeleccionado = Convert.ToInt32(dgvListaMateriales[dgvListaMateriales.Columns["iDStockDataGridViewTextBoxColumn"].Index, e.RowIndex].Value);
            kgSeleccionados = Convert.ToDecimal(dgvListaMateriales[dgvListaMateriales.Columns["stockDataGridViewTextBoxColumn"].Index, e.RowIndex].Value);
            txtKgComprometer.Text = kgSeleccionados >= _kgPedidos ? _kgPedidos.ToString("N2") : kgSeleccionados.ToString("N2");
            _estadoSeleccionado =
                StockStatusManager.MapStatusFromText(dgvListaMateriales[dgvListaMateriales.Columns["estadoDataGridViewTextBoxColumn"].Index, e.RowIndex]
                    .Value.ToString());
        }
        private void txtKgComprometer_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender,e);
        }
        private void txtKgComprometer_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtKgComprometer.Text) > kgSeleccionados)
            {
                MessageBox.Show(@"Los Kg indicados a comprometer sobrepasan el stock seleccionado",
                    @"Error en Seleccion de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKgComprometer.Text = 0.ToString("N2");
            }

            if (Convert.ToDecimal(txtKgComprometer.Text) > _kgPedidos)
            {
                MessageBox.Show(@"Los Kg indicados a comprometer sobrepasan los Kg Solicitados por el Cliente",
                    @"Error en Seleccion de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKgComprometer.Text = 0.ToString("N2");
            }
        }
        private void btnComprometer_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtKgComprometer.Text) <= 0)
            {
                MessageBox.Show(@"No Hay KG seleccionados para comprometer",
                    @"Error en Seleccion de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKgComprometer.Text = 0.ToString("N2");
                return;
            }

            var dr = MessageBox.Show(@"Confirma la reserva de stock?", @"Reserva de Stock", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;

            //Reservar Stock para OV
            new StockBatchManagerSD().ComprometeStock(idStockSeleccionado, Convert.ToDecimal(txtKgComprometer.Text),
                _idSalesOrder, _idItemSalesOrder);
            KgReservados = new StockBatchManagerSD().GetKgComprometidosPorSalesOrder(_idSalesOrder, _idItemSalesOrder);
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void ckOnlyAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOnlyAvailable.Checked)
            {
                dgvListaMateriales.DataSource = new StockList().GetAllByMaterial_DisponibleDespacho(_materialPrimario);
                btnComprometer.Enabled = true;
            }
            else
            {
                dgvListaMateriales.DataSource = new StockList().GetAllByMaterial(_materialPrimario);
                btnComprometer.Enabled = false;
            }
        }

        private void btnLiberarCompromiso_Click(object sender, EventArgs e)
        {
            switch (_estadoSeleccionado)
            {
                case StockStatusManager.EstadoLote.Liberado:
                    MessageBox.Show(@"El Estado del lote seleccionado no permite esta acción!", @"Accion no permitida",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case StockStatusManager.EstadoLote.Restringido:
                    MessageBox.Show(@"El Estado del lote seleccionado no permite esta acción!", @"Accion no permitida",
                      MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case StockStatusManager.EstadoLote.FE:
                    MessageBox.Show(@"El Estado del lote seleccionado no permite esta acción!", @"Accion no permitida",
                      MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case StockStatusManager.EstadoLote.Comprometido:
                    if (MessageBox.Show(@"Confirma la liberacion de la linea de stock comprometida?", @"Liberar Stock Comprometido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        new StockBatchManagerSD().LiberaStockComprometido(idStockSeleccionado);
                    }
                    break;
                case StockStatusManager.EstadoLote.Reservado:
                    MessageBox.Show(@"El Estado del lote seleccionado no permite esta acción!", @"Accion no permitida",
                      MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case StockStatusManager.EstadoLote.ReservaPF:
                    MessageBox.Show(@"El Estado del lote seleccionado no permite esta acción!", @"Accion no permitida",
                      MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case StockStatusManager.EstadoLote.ReservaRE:
                    MessageBox.Show(@"El Estado del lote seleccionado no permite esta acción!", @"Accion no permitida",
                      MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            KgReservados = new StockBatchManagerSD().GetKgComprometidosPorSalesOrder(_idSalesOrder, _idItemSalesOrder);
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
