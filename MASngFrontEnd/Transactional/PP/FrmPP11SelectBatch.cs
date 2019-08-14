using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Transactional.WM;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP11SelectBatch : Form
    {
        public FrmPP11SelectBatch(string material, decimal kgRequeridosOF, int numeroOF,bool onlyKgMayorARequerido)
        {
            InitializeComponent();
            _kgRequeridosOF = kgRequeridosOF;
            _numeroOF = numeroOF;
            _onlyKgMayorReq = onlyKgMayorARequerido;
            txtMaterial.Text = material;
        }

        //------------------------------------------------------------------------------------------------
        private readonly decimal _kgRequeridosOF;
        private decimal _kgPendientesSeleccion;
        private decimal _kgLineaSeleccionada;
        private readonly bool _onlyKgMayorReq;
        private readonly int _numeroOF;
        private int _numeroOFReservadaLiberar = 0;
        private List<T0030_STOCK> _stockList = new List<T0030_STOCK>();
        public decimal KgSeleccionados = 0; //Estructura
        public int IdstockSeleccionado; //Estructura
        //------------------------------------------------------------------------------------------------

        private void RefrescaDataGridNew(bool getNewList = false)
        {
            var newList = new List<T0030_STOCK>();
            if (getNewList)
            {
                //trae de nuevo el listado de materiales
                if (ckSoloDisponible.Checked)
                {
                    _stockList = new StockList().GetAllByMaterial_DisponibleProduccion(txtMaterial.Text).ToList();
                    ckSoloDisponible.BackColor = Color.DarkSeaGreen;
                }
                else
                {
                    _stockList = new StockList().GetAllByMaterial(txtMaterial.Text).ToList();
                    ckSoloDisponible.BackColor = Color.Pink;
                }
            }

            if (ckSoloStockMayorIgual.Checked)
            {
                newList = _stockList.Where(c => c.Stock >= _kgRequeridosOF).ToList();
            }
            else
            {
                newList = _stockList;
            }

            t0030STOCKBindingSource.DataSource = newList.ToList();
            dgvStockDisponible.ClearSelection();
            IdstockSeleccionado = 0;
            _kgLineaSeleccionada = 0;
            _kgPendientesSeleccion = _kgRequeridosOF;
            KgSeleccionados = 0;

            txtKgAUtilizar.Text = 0.ToString("n2");
            txtKgLineaSeleccionada.Text = 0.ToString("N2");
            txtKgPendienteSeleccion.Text = _kgPendientesSeleccion.ToString("N2");
        }
        private void FrmSeleccionBatch_Load(object sender, EventArgs e)
        {
            txtKgRequeridos.Text = _kgRequeridosOF.ToString("N2");
            ckSoloDisponible.Checked = true;
            if (_onlyKgMayorReq)
            {
                ckSoloStockMayorIgual.Checked = true;
                ckSoloStockMayorIgual.Enabled = false;
            }
            txtKgAUtilizar.Text = 0.ToString("N2");
            KgSeleccionados = 0;
            IdstockSeleccionado = 0;
        }


        #region Botones

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IdstockSeleccionado = 0;
            KgSeleccionados = 0;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void BtnSelectLote_Click(object sender, EventArgs e)
        {
            if (KgSeleccionados <= 0)
            {
                MessageBox.Show(@"Los Kg a utilizar deben ser mayor a 0.00 Kg", @"Atencion con la Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnConsolidar_Click(object sender, EventArgs e)
        {
            new StockManager().OptimizaStockLiberado(txtMaterial.Text);
            RefrescaDataGridNew(true);
        }
        private void btnMoveStockLocation_Click(object sender, EventArgs e)
        {
            if (IdstockSeleccionado == 0)
            {
                MessageBox.Show(@"Debe Seleccionar una Linea de Stock", @"Error en Seleccion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var f2 = new FrmWm01MoveStock(IdstockSeleccionado, "OF");
            f2.ShowDialog();
            RefrescaDataGridNew(true);
        }
        private void btnLiberarSeleccion_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"El Lotes previamente seleccionado será liberado!", @"Liberacion de Reserva de Lote",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        #endregion


        private void txtKgAUtilizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtKgAUtilizar_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BtnSelectLote.Enabled = false;
            KgSeleccionados = 0;

            if (string.IsNullOrEmpty(txtKgAUtilizar.Text))
            {
                txtKgAUtilizar.Text = 0.ToString("N2");
                toolTip1.ToolTipTitle = "Seleccion Invalida";
                toolTip1.Show("Los Kg a Utilizar deben ser mayor a 0 (CERO) Kg.", txtKgAUtilizar,
                    txtKgAUtilizar.Location, 2000);
                KgSeleccionados = 0;
                return;
            }
            KgSeleccionados = Convert.ToDecimal(txtKgAUtilizar.Text);
            if (KgSeleccionados > _kgLineaSeleccionada)
            {
                toolTip1.ToolTipTitle = "Seleccion Invalida";
                toolTip1.Show("Los Kg a Utilizar no pueden sobrepasar la linea de stock seleccionada", txtKgAUtilizar,
                    txtKgAUtilizar.Location, 2000);
                KgSeleccionados = 0;
                e.Cancel = true;
                return;
            }

            txtKgPendienteSeleccion.Text = (_kgRequeridosOF - KgSeleccionados).ToString("N2");
            txtKgAUtilizar.Text = KgSeleccionados.ToString("N2");

            if (KgSeleccionados > 0)
            {
                BtnSelectLote.Enabled = true;
            }
        }
        private void dgvStockDisponible_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStockDisponible.SelectedCells.Count == 0)
                return;

            //Asignacion variables
            IdstockSeleccionado = Convert.ToInt32(dgvStockDisponible[0, e.RowIndex].Value);
            _kgLineaSeleccionada = decimal.Round(Convert.ToDecimal(dgvStockDisponible[3, e.RowIndex].Value), 2);
            txtKgLineaSeleccionada.Text = _kgLineaSeleccionada.ToString("N2");

            _numeroOFReservadaLiberar =
                Convert.ToInt32(dgvStockDisponible[dgvStockDisponible.Columns[reservaOFDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value);

            if (_kgLineaSeleccionada > _kgRequeridosOF)
            {
                txtKgAUtilizar.Text = txtKgRequeridos.Text;
                txtKgPendienteSeleccion.Text = 0.ToString("N2");
                KgSeleccionados = _kgRequeridosOF;
            }
            else
            {
                KgSeleccionados = _kgLineaSeleccionada;
                txtKgAUtilizar.Text = _kgLineaSeleccionada.ToString("N2");
                txtKgPendienteSeleccion.Text = (_kgRequeridosOF - _kgLineaSeleccionada).ToString("N2");

            }
        }
        private void ckSoloDisponible_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloDisponible.Checked)
            {
                //_stockList = new StockList().GetAllByMaterial_DisponibleProduccion(txtMaterial.Text).ToList();
                ckSoloDisponible.BackColor = Color.DarkSeaGreen;
                if (_onlyKgMayorReq)
                {
                    ckSoloStockMayorIgual.Checked = true;
                    ckSoloStockMayorIgual.Enabled = false;
                }
                else
                {
                    ckSoloStockMayorIgual.Enabled = false;
                }
                BtnSelectLote.Enabled = true;
            }
            else
            {
                ckSoloDisponible.BackColor = Color.Pink;
                ckSoloStockMayorIgual.Enabled = true;
                BtnSelectLote.Enabled = false;
            }
            RefrescaDataGridNew(true);
        }
        private void ckSoloStockMayorIgual_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloStockMayorIgual.Checked)
            {
                ckSoloStockMayorIgual.BackColor = Color.DarkSeaGreen;
                //visualizar solo stock >= Requerido
            }
            else
            {
                ckSoloStockMayorIgual.BackColor = Color.Pink;
                //Visualizar all the available stock
            }
            RefrescaDataGridNew();
        }
        private void dgvStockDisponible_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView) sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            int numeroOFReserva;

            if (datagridview[datagridview.Columns["reservaOFDataGridViewTextBoxColumn"].Index, e.RowIndex].Value == null)
            {
                numeroOFReserva = 0;
            }
            else
            {
                numeroOFReserva =
                    Convert.ToInt32(
                        datagridview[datagridview.Columns["reservaOFDataGridViewTextBoxColumn"].Index, e.RowIndex].Value);
            }

            switch (cellValue)
            {
                case "Liberar":
                    if (numeroOFReserva == 0)
                    {
                        MessageBox.Show(
                            @"Esta Accion no se puede realizar porque la linea de stock no esta reservada para ninguna OF",
                            @"Accion Invalida", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    if (numeroOFReserva == _numeroOF)
                    {
                        MessageBox.Show(
                            @"Para liberar una reserva de stock relacionada a la OF en curso, debe utilizar el boton Liberar LOTE que se encuentra fuera de esta grilla",
                            @"Accion Invalida", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    var dialogResult =
                        MessageBox.Show($"Confirma liberar este LOTE Reservado para OF# {numeroOFReserva}?",
                            @"Liberacion de Lote Reservado", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        new ReservaStockOF().LiberaStockReservadoOF(txtMaterial.Text,_numeroOFReservadaLiberar);
                        RefrescaDataGridNew(true);
                    }
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
                    
            }
        }
        private void txtFiltroLote_KeyUp(object sender, KeyEventArgs e)
        {
            t0030STOCKBindingSource.DataSource =
                _stockList.Where(c => c.Batch.ToUpper().Contains(txtFiltroLote.Text.ToUpper())).ToList();
        }

    }
}
