using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.DataFix;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.GestionCheques
{
    public partial class FrmRechazarCheque : Form
    {
        public FrmRechazarCheque(int modo=0)
        {
            InitializeComponent();
        }
        private int? _idChequeSeleccionado;
        private List<T0154_CHEQUES> _chList = new List<T0154_CHEQUES>();

        private void FrmRechazarCheque_Load(object sender, EventArgs e)
        {
            ConfiguraData();
        }
        private void ConfiguraData()
        {
            cmbCuentaOrigen.DataSource =
                new CuentasManager().GetListCuentasAvailableTransferencia()
                    .Where(c => c.CUENTA_TIPO == "TRANSF")
                    .ToList();

            cmbCuentaOrigen.SelectedIndex = -1;
            txtGastos.Text = 0.ToString("C2");
            txtMotivoRechazo.Text = null;
            txtIva.Text = 0.ToString("C2");
            txtImporte.Text = 0.ToString("C2");
            t0154CHEQUESBindingSource.DataSource = _chList;
        }
        private void cmbCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCuentaOrigen.SelectedIndex == -1)
            {
                _chList= new ChequesManager().GetListChequesNoDisponibles().ToList();
               // t0154CHEQUESBindingSource.DataSource = _chList;
                txtGL.Text = null;
                btnRechazar.Enabled = false;
                txtFilterChNum.Text = null;
                return;
            }
            _chList= new ChequesManager().GetListChequesNoDisponibles(cmbCuentaOrigen.SelectedValue.ToString()).ToList();
            txtGL.Text = new CuentasManager().GetGL(cmbCuentaOrigen.SelectedValue.ToString());
            btnRechazar.Enabled = true;
            t0154CHEQUESBindingSource.DataSource = _chList;
        }
        private void dgvListaCheques_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _idChequeSeleccionado = Convert.ToInt32(dgvListaCheques[dgvListaCheques.Columns["iDCHEQUEDataGridViewTextBoxColumn"].Index, e.RowIndex].Value);
            }
            else
            {
                _idChequeSeleccionado = null;
            }

            if (_idChequeSeleccionado != null)
            {
                txtIdCheque.Text = _idChequeSeleccionado.ToString();
                var chdata = new ChequesManager().GetCheque(_idChequeSeleccionado.Value);
                txtImporte.Text = chdata.IMPORTE.Value.ToString("C2");
                txtImporteCh.Text = chdata.IMPORTE.Value.ToString("C2");
                dtpFechaCheque.Value = chdata.CHE_FECHA;
                dtpFechaRecibido.Value = chdata.FECHA_RECIBIDO;

                if (chdata.IdClienteRecibido == null)
                {
                    MessageBox.Show(@"Aplicando el Fix del IdCliente", @"Fix Id Cliente", MessageBoxButtons.OK,
                        MessageBoxIcon.Information); //todo remover este fix algun dia
                    new FixIdClienteTablaCheque().FixIdCliente(_idChequeSeleccionado.Value);
                    chdata = new ChequesManager().GetCheque(_idChequeSeleccionado.Value);
                }

                txtidCliente.Text = chdata.IdClienteRecibido.ToString();
                txtClienteRazonSocial.Text = chdata.CLIENTE;
                txtBanco.Text = chdata.T0160_BANCOS.BCO_SHORTDESC;
            }

        }
        private bool ValidaData()
        {
            if (_idChequeSeleccionado == null)
            {
                MessageBox.Show(@"Debe Seleccionar un cheque para Rechazar", @"Rechazo de Cheques", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (FormatAndConversions.CCurrencyADecimal(txtGastos.Text) == 0)
            {
                var preg = MessageBox.Show(@"Confirma el ingreso del cheque rechazado con Gastos $0.00?",
                    @"Rechazo de Cheques", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                if (preg == DialogResult.No)
                {
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtMotivoRechazo.Text))
            {
                MessageBox.Show(@"Debe Completar el motivo del Rechazo", @"Rechazo de Cheques", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (ValidaData() == false)
                return;

            var importeRechazoTotal = FormatAndConversions.CCurrencyADecimal(txtImporte) + FormatAndConversions.CCurrencyADecimal(txtGastos.Text)+
                FormatAndConversions.CCurrencyADecimal(txtIva);

            var resp = MessageBox.Show($"Confirma el Rechazo del Cheque Banco {txtBanco.Text} por Importe Cheque {txtImporteCh.Text}  - Importe Total Rechazo {importeRechazoTotal.ToString("C2")}?", @"Rechazo Cheque", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            var chrmng = new ChequeRechazadoManager();
            chrmng.AddChequeRechazado(_idChequeSeleccionado.Value, dtpFechaRechazo.Value,
                txtMotivoRechazo.Text.ToUpper());

            chrmng.SetChequeRechazadoTablaCheque(_idChequeSeleccionado.Value, txtMotivoRechazo.Text.ToUpper());

            var asiento = new AsientoGenerico("CHR").CreaAsientoChequeRechazado(_idChequeSeleccionado.Value,
                txtMotivoRechazo.Text, txtGL.Text, dtpFechaRechazo.Value,
                FormatAndConversions.CCurrencyADecimal(txtGastos.Text),
                FormatAndConversions.CCurrencyADecimal(txtIva));

            chrmng.CompleteNumeroAsientoRechazo(_idChequeSeleccionado.Value,asiento.IdDocu);

            if (asiento.IdDocu > 0)
            {
                MessageBox.Show(@"Se ha generado correctamente el Rechazo Seleccionado", @"Rechazo Correcto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumeroAsiento.Text = asiento.IdDocu.ToString();
            }

            MessageBox.Show(@"Se ha Rechazado el Cheque Correctamente - Recuerde hacer la ND correspondiente", @"CHR-OK",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            //limpieza datos
            dgvListaCheques.ClearSelection();
            txtIdCheque.Text = null;
            txtBanco.Text = null;
            txtImporteCh.Text = 0.ToString("C2");
            txtClienteRazonSocial.Text = null;
            txtidCliente.Text = null;
            _idChequeSeleccionado = null;

        }
        private void txtIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender,e);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtGastos_Leave(object sender, EventArgs e)
        {
            var data = (TextBox) sender;
            if (string.IsNullOrEmpty(data.Text))
            {
                data.Text = 0.ToString("C2");
                return;
            }
            decimal valor = FormatAndConversions.CCurrencyADecimal(data);
            data.Text = valor.ToString("C2");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilterChNum.Text))
            {
                t0154CHEQUESBindingSource.DataSource =
                    _chList.Where(c => c.CHE_NUMERO == txtFilterChNum.Text).ToList();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            t0154CHEQUESBindingSource.DataSource = _chList.ToList();
        }
    }
}