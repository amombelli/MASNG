using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI.MainDocumentData;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmSeleccionMaterialNcd : Form
    {
        public FrmSeleccionMaterialNcd(int idCliente, string tipoLx)
        {
            _idCliente = idCliente;
            _tipoLx = tipoLx;
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------
        private readonly int _idCliente;
        private readonly string _tipoLx;
        public decimal KgNotaCredito;
        public int IdFactura;
        public int IdFacturaItem;
        public int IdDevolucion;
        private string _materialDev;
        private List<T0401_FACTURA_I> _listaItems = new List<T0401_FACTURA_I>();

        //----------------------------------------------------------------------------------------

        private void FrmSeleccionMaterialNcd_Load(object sender, EventArgs e)
        {
            _listaItems = new NcdSeleccionItemsKg().GetItemList(_idCliente, _tipoLx);
            t0401FACTURAIBindingSource.DataSource = _listaItems;
            t0360RTNBindingSource.DataSource = new ManageRetornoMaterial().GetDevolucionesFromCustomer(_idCliente);
            dgvSeleccionItem.DataSource = t0401FACTURAIBindingSource;
            dgvSeleccionDevolucion.DataSource = t0360RTNBindingSource;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmSeleccionMaterialNcd_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender,e);
        }
        private void txtKgNotaCredito_Leave(object sender, EventArgs e)
        {
            ValidaKgOK();
        }
        private bool ValidaKgOK()
        {
            if (string.IsNullOrEmpty(txtKgFacturados.Text))
            {
                txtKgFacturados.Text = 0.ToString("N2");
            }

            if (string.IsNullOrEmpty(txtKgNotaCredito.Text))
            {
                txtKgNotaCredito.Text = 0.ToString("N2");
            }
            var kgFactura = Convert.ToDecimal(txtKgFacturados.Text);
            KgNotaCredito = Convert.ToDecimal(txtKgNotaCredito.Text);
            if (KgNotaCredito > kgFactura)
            {
                MessageBox.Show(@"Los Kg de la nota de credito no pueden ser mayores a los Kg previamente facturados",
                    @"Error en Kg", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtKgNotaCredito.Text = 0.ToString("n2");
                return false;
            }
            if (KgNotaCredito <= 0)
            {
                MessageBox.Show(@"Los Kg de la nota de credito no pueden ser Negativos o 0",
                    @"Error en Kg", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtKgNotaCredito.Text = 0.ToString("n2");
                return false;
            }
            txtKgNotaCredito.Text = KgNotaCredito.ToString("n2");
            return true;



        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaKgOK() == false)
                return;

            IdFacturaItem = Convert.ToInt32(txtIdItem.Text);

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
        private void dgvSeleccionItem_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nameX = "iDFacturaDataGridViewTextBoxColumn";
                txtIdFactura.Text = dgvSeleccionItem[dgvSeleccionItem.Columns[nameX].Index, e.RowIndex].Value.ToString();
                IdFactura = Convert.ToInt32(dgvSeleccionItem[dgvSeleccionItem.Columns[nameX].Index, e.RowIndex].Value);
            }
            else
            {
                txtIdFactura.Text = @"0";
                IdFactura = 0;
                IdFacturaItem = 0;
            }
        }

        private void dgvSeleccionDevolucion_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string nameX = null;
            if (e.RowIndex >= 0)
            {
                nameX = iDXDataGridViewTextBoxColumn.Name.ToString();
                var z = dgvSeleccionDevolucion[dgvSeleccionDevolucion.Columns[nameX].Index, e.RowIndex].Value.ToString();
                //txtIdFactura.Text = dgvSeleccionItem[dgvSeleccionItem.Columns[nameX].Index, e.RowIndex].Value.ToString();
                IdDevolucion = Convert.ToInt32(dgvSeleccionDevolucion[dgvSeleccionDevolucion.Columns[nameX].Index, e.RowIndex].Value);

                nameX = mATERIALDataGridViewTextBoxColumn.Name.ToString();
                //txtIdFactura.Text = dgvSeleccionItem[dgvSeleccionItem.Columns[nameX].Index, e.RowIndex].Value.ToString();
                _materialDev = (dgvSeleccionDevolucion[dgvSeleccionDevolucion.Columns[nameX].Index, e.RowIndex].Value).ToString();
                //var listaMat = _listaItems.Where(c => c.ITEM.ToUpper().Equals(_materialDev.ToUpper())).ToList();
                t0401FACTURAIBindingSource.DataSource = _listaItems.Where(c => c.ITEM.ToUpper().Equals(_materialDev.ToUpper())).ToList() ;
              //  dgvSeleccionItem.DataSource = t0401FACTURAIBindingSource;

            }
        }
    }
}
