using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.VBTools;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmFI42CobranzaTemporal : Form
    {
        public FrmFI42CobranzaTemporal()
        {
            InitializeComponent();
            this.txtNumeroTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroTax_KeyUp);
            this.txtNumeroTax.TextChanged += new System.EventHandler(this.txtNumeroTax_TextChanged);
            this.txtNumeroTax.DragLeave += new System.EventHandler(this.txtNumeroTax_Leave);
            this.txtCodigoTax.TextChanged += new System.EventHandler(this.txtCodigoTax_TextChanged);
            this.txtCodigoTax.Leave += new System.EventHandler(this.txtCodigoTax_Leave);
            this.cmbTipoTax.SelectedIndexChanged += new System.EventHandler(this.cmbTipoTax_SelectedIndexChanged);
            this.cmbId6.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.SelectedIndexChanged +=
                new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.txtNumeroTax.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.t0006MCLIENTESBindingSource,
                "CUIT", true));
            this.txtCodigoTax.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.t0006MCLIENTESBindingSource,
                "TTAX", true));
        }

        //--------------------------------------------------------------------------------------------------
        private int? _id6;
        private readonly List<T0206_COBRANZA_I> _listaCob = new List<T0206_COBRANZA_I>();
        private List<T0150_CUENTAS> _listaCuentas = new List<T0150_CUENTAS>();
        private List<T0160_BANCOS> _listaBancos = new List<T0160_BANCOS>();
        private decimal _tc;
        private decimal _importeRecibo;
        private bool _todoValidado;
        private string _tipoLx;
        //--------------------------------------------------------------------------------------------------

        #region Funcionalidad ComboboxBusqueda

        private void txtNumeroTax_KeyUp(object sender, KeyEventArgs e)
        {
            //cuando es tipo 80 y 11 caracteres lo valida
            if (txtNumeroTax.Text.Length == 11 && txtCodigoTax.Text == @"80")
            {
                ValidaCuitCorrecto();
            }
        }
        private void txtNumeroTax_TextChanged(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }
        private void txtNumeroTax_Leave(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }
        private void txtCodigoTax_TextChanged(object sender, EventArgs e)
        {
            cmbTipoTax.Text = txtCodigoTax.Text == @"80" ? @"CUIT" : @"NI";
        }
        private void txtCodigoTax_Leave(object sender, EventArgs e)
        {
        }
        private void cmbTipoTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoTax.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                if (cmbTipoTax.Text == @"CUIT")
                {
                    txtCodigoTax.Text = @"80";
                    txtNumeroTax.BackColor = Color.LightGoldenrodYellow;
                }
                else
                {
                    txtCodigoTax.Text = @"00";
                    txtNumeroTax.BackColor = Color.DarkGray;
                    txtNumeroTax.Text = @"00000000000";
                }
            }
        }
        private void cmbRazonSocial_TextUpdate(object sender, EventArgs e)
        {
            var combo = (ComboBox) sender;
            if (string.IsNullOrEmpty(combo.Text))
            {
                BlanqueaSeleccion();
            }
        }
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                //BlanqueaSeleccion();
                cmbFantasia.SelectedIndex = -1;
                cmbId6.SelectedIndex = -1;
                _id6 = null;
                return;
            }

            _id6 = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            ValidaCuitCorrecto();

            var ctacte = new CtaCteCustomer(_id6.Value);
            txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            txtSaldoL1.BackColor = ctacte.GetResultadoCtaCte("L1").SaldoColor;
            txtSaldoL2.BackColor = ctacte.GetResultadoCtaCte("L2").SaldoColor;
            txtSaldoTotal.Text =
                (FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtSaldoL2.Text)).ToString("C2");
        }

        private void ValidaCuitCorrecto()
        {
            if (txtNumeroTax.Text.Length == 11 && txtNumeroTax.Text != @"00000000000")
            {
                if (new CuitValidation().ValidarCuit(txtNumeroTax.Text) == true)
                {
                    txtTaxValido.Text = @"VALIDO";
                    txtTaxValido.BackColor = Color.LightGreen;
                }
                else
                {
                    txtTaxValido.Text = @"INVALIDO";
                    txtTaxValido.BackColor = Color.Crimson;
                }
            }
            else
            {
                txtTaxValido.Text = @"SIN VALIDAR";
                txtTaxValido.BackColor = Color.Orange;
            }
        }
        private void BlanqueaSeleccion()
        {
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            cmbTipoTax.SelectedIndex = -1;
            cmbId6.SelectedIndex = -1;
            txtNumeroTax.Text = null;
            txtCodigoTax.Text = null;
            _id6 = null;
        }
        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            var f = new FrmBusquedaAvanzadaCliente();
            f.ShowDialog();
        }

        #endregion

        private void FrmIngresoConbranzaTemporal_Load(object sender, EventArgs e)
        {
            dgvCobranzaItems.CellValueChanged += new DataGridViewCellEventHandler(dgvCobranzaItems_CellValueChanged);
            t0006MCLIENTESBindingSource.DataSource = new CustomerManager().GetCompleteListofBillTo();
            t0206COBRANZAIBindingSource.DataSource = _listaCob;
            _listaCuentas = new CuentasManager().GetListCuentasAvailableCobranza();
            cUENTA.DataSource = _listaCuentas;
            _listaBancos = new BankManager().GetBankList(true);
            _tc = new ExchangeRateManager().GetExchangeRate(dtpFechaCobranza.Value);
            txtXRate.Text = _tc.ToString("N2");
            //
            cmbCobrador.DataSource = new HumanResourcesManager().GetListAllActiveCobrador();
            cmbIngresadoPor.DataSource = new HumanResourcesManager().GetListEmployees();
            cmbIngresadoPor.SelectedValue = Environment.UserName;
            cmbCobrador.SelectedIndex = -1;
            cmbRazonSocial.SelectedIndex = -1;
            //
            txtStatus.Text = CobranzaTemporalManager.StatusCobranzaTemporal.Inicial.ToString();
            btnImprimir.Enabled = false;
        }



        //Formateo de propiedades segun tipo de cuenta seleccionada
        private void FormatCheque(int numeroRow)
        {
            dgvCobranzaItems.CellValueChanged -= new DataGridViewCellEventHandler(dgvCobranzaItems_CellValueChanged);
            //Liberamos All
            //dgvCobranzaItems.Rows[numeroRow].Cells[iMPITEMDataGridViewTextBoxColumn.Name].Value = 0;
            //dgvCobranzaItems.Rows[numeroRow].Cells[iMPRECIBODataGridViewTextBoxColumn.Name].Value = 0;
            dgvCobranzaItems.Rows[numeroRow].Cells[iMPITEMDataGridViewTextBoxColumn.Name].ReadOnly = false;
            dgvCobranzaItems.Rows[numeroRow].Cells[iMPITEMDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.GhostWhite;

            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUENUMERODataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUENUMERODataGridViewTextBoxColumn.Name].ReadOnly = false;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUENUMERODataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.GhostWhite;

            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEFECHADataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEFECHADataGridViewTextBoxColumn.Name].ReadOnly = false;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEFECHADataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.GhostWhite;

            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUECUITDataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUECUITDataGridViewTextBoxColumn.Name].ReadOnly = false;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUECUITDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.GhostWhite;

            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEBANCODataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEBANCODataGridViewTextBoxColumn.Name].ReadOnly = false;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEBANCODataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.GhostWhite;
            ;

            dgvCobranzaItems.Rows[numeroRow].Cells[__chequeInterior.Name].Value = false;
            dgvCobranzaItems.Rows[numeroRow].Cells[__chequeInterior.Name].ReadOnly = false;
            dgvCobranzaItems.Rows[numeroRow].Cells[__chequeInterior.Name].Style.BackColor =
                Color.GhostWhite;

            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUETITULARDataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUETITULARDataGridViewTextBoxColumn.Name].ReadOnly = false;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUETITULARDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.GhostWhite;

            dgvCobranzaItems.Rows[numeroRow].Cells[iDCHDataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[iDCHDataGridViewTextBoxColumn.Name].ReadOnly = false;
            dgvCobranzaItems.Rows[numeroRow].Cells[iDCHDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.GhostWhite;

            //dgvCobranzaItems.Rows[numeroRow].Cells[tCITEMDataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[tCITEMDataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[tCITEMDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[ESTADO.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[ESTADO.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[ESTADO.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.CellValueChanged += new DataGridViewCellEventHandler(dgvCobranzaItems_CellValueChanged);
        }
        private void FormatEfectivo(int numeroRow)
        {
            dgvCobranzaItems.CellValueChanged -= new DataGridViewCellEventHandler(dgvCobranzaItems_CellValueChanged);

            dgvCobranzaItems.Rows[numeroRow].Cells[iMPITEMDataGridViewTextBoxColumn.Name].ReadOnly = false;
            dgvCobranzaItems.Rows[numeroRow].Cells[iMPITEMDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.GhostWhite;


            //Bloqueamos
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUENUMERODataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUENUMERODataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUENUMERODataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEFECHADataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEFECHADataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEFECHADataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUECUITDataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUECUITDataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUECUITDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEBANCODataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEBANCODataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEBANCODataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;
            ;

            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUETITULARDataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUETITULARDataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUETITULARDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[iDCHDataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[iDCHDataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[iDCHDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            //dgvCobranzaItems.Rows[numeroRow].Cells[tCITEMDataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[tCITEMDataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[tCITEMDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[__chequeInterior.Name].Value = false;
            dgvCobranzaItems.Rows[numeroRow].Cells[__chequeInterior.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[__chequeInterior.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[ESTADO.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[ESTADO.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[ESTADO.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.CellValueChanged += new DataGridViewCellEventHandler(dgvCobranzaItems_CellValueChanged);
        }
        private void FormatCuentaNoManejada(int numeroRow)
        {
            dgvCobranzaItems.CellValueChanged -= new DataGridViewCellEventHandler(dgvCobranzaItems_CellValueChanged);

            //Bloqueamos ALL
            //dgvCobranzaItems.Rows[numeroRow].Cells[iMPITEMDataGridViewTextBoxColumn.Name].Value = null;
            //dgvCobranzaItems.Rows[numeroRow].Cells[iMPRECIBODataGridViewTextBoxColumn.Name].Value = null;

            dgvCobranzaItems.Rows[numeroRow].Cells[iMPITEMDataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[iMPITEMDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUENUMERODataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUENUMERODataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUENUMERODataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[tCITEMDataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[tCITEMDataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[tCITEMDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[__chequeInterior.Name].Value = false;
            dgvCobranzaItems.Rows[numeroRow].Cells[__chequeInterior.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[__chequeInterior.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[ESTADO.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[ESTADO.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[ESTADO.Name].Style.BackColor =
                Color.LightGray;


            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEFECHADataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEFECHADataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEFECHADataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUECUITDataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUECUITDataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUECUITDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEBANCODataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEBANCODataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUEBANCODataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;
            ;
            
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUETITULARDataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUETITULARDataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[cHEQUETITULARDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.Rows[numeroRow].Cells[iDCHDataGridViewTextBoxColumn.Name].Value = null;
            dgvCobranzaItems.Rows[numeroRow].Cells[iDCHDataGridViewTextBoxColumn.Name].ReadOnly = true;
            dgvCobranzaItems.Rows[numeroRow].Cells[iDCHDataGridViewTextBoxColumn.Name].Style.BackColor =
                Color.LightGray;

            dgvCobranzaItems.CellValueChanged += new DataGridViewCellEventHandler(dgvCobranzaItems_CellValueChanged);
        }


        /// <summary>
        /// Al modificar la celda CUENTA se acciona
        /// </summary>
        private void dgvCobranzaItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Esto solo actua con el combobox de CUENTAS
            var currentcell = dgvCobranzaItems.CurrentCellAddress;
            if (e.ColumnIndex == dgvCobranzaItems[cUENTA.Name,e.RowIndex].ColumnIndex)
            {
                var cellValue = (DataGridViewComboBoxCell) dgvCobranzaItems.Rows[e.RowIndex].Cells[cUENTA.Name];
                if (cellValue.Value != null)
                {
                    dgvCobranzaItems.Rows[e.RowIndex].Cells[lINEDataGridViewTextBoxColumn.Name].Value = e.RowIndex + 1;
                    dgvCobranzaItems.Rows[e.RowIndex].Cells[tCITEMDataGridViewTextBoxColumn.Name].Value = _tc;
                    switch (cellValue.Value.ToString())
                    {
                        case "ARS":
                            FormatEfectivo(e.RowIndex);
                            dgvCobranzaItems.Rows[e.RowIndex].Cells[mONITEMDataGridViewTextBoxColumn.Name].Value =
                                "ARS";
                            break;
                        case "CHE":
                            FormatCheque(e.RowIndex);
                            dgvCobranzaItems.Rows[e.RowIndex].Cells[mONITEMDataGridViewTextBoxColumn.Name].Value =
                                "ARS";
                            break;
                        case "GAL":
                            FormatEfectivo(e.RowIndex);
                            dgvCobranzaItems.Rows[e.RowIndex].Cells[mONITEMDataGridViewTextBoxColumn.Name].Value =
                                "ARS";
                            FormatEfectivo(e.RowIndex);
                            break;
                        case "SAN":
                            FormatEfectivo(e.RowIndex);
                            dgvCobranzaItems.Rows[e.RowIndex].Cells[mONITEMDataGridViewTextBoxColumn.Name].Value =
                                "ARS";
                            FormatEfectivo(e.RowIndex);
                            break;
                        case "RIB":
                            FormatEfectivo(e.RowIndex);
                            dgvCobranzaItems.Rows[e.RowIndex].Cells[mONITEMDataGridViewTextBoxColumn.Name].Value =
                                "ARS";
                            FormatEfectivo(e.RowIndex);
                            break;
                        case "RGA":
                            FormatEfectivo(e.RowIndex);
                            dgvCobranzaItems.Rows[e.RowIndex].Cells[mONITEMDataGridViewTextBoxColumn.Name].Value =
                                "ARS";
                            FormatEfectivo(e.RowIndex);
                            break;
                        case "USD":
                            FormatEfectivo(e.RowIndex);
                            dgvCobranzaItems.Rows[e.RowIndex].Cells[mONITEMDataGridViewTextBoxColumn.Name].Value =
                                "USD";
                            FormatEfectivo(e.RowIndex);
                            break;
                        case "RIVA":
                            FormatEfectivo(e.RowIndex);
                            dgvCobranzaItems.Rows[e.RowIndex].Cells[mONITEMDataGridViewTextBoxColumn.Name].Value =
                                "ARS";
                            break;
                        default:
                            FormatCuentaNoManejada(e.RowIndex);
                            MessageBox.Show($@"Esta cuenta no esta siendo manejada {cellValue.Value.ToString()}",
                                @"Configuracion Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }

                    var cuentaDescripcion = (DataGridViewTextBoxCell) dgvCobranzaItems.Rows[currentcell.Y].Cells[2];
                    var x = _listaCuentas.SingleOrDefault(c => c.ID_CUENTA == cellValue.Value.ToString());
                    cuentaDescripcion.Value = x.CUENTA_DESC;
                    dgvCobranzaItems.Rows[currentcell.Y].Cells[currentcell.X + 1].Style.BackColor = Color.LightGray;
                }
                else
                {
                    
                }
            }
        }
        private void dgvCobranzaItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var currentcell = dgvCobranzaItems.CurrentCellAddress;
            if (dgvCobranzaItems.CurrentCell.ColumnIndex == 9)
            {
                //validacion de CUIT
                if (dgvCobranzaItems.CurrentCell.Value == null)
                    return;

                var numeroCuit = dgvCobranzaItems.CurrentCell.Value.ToString();
                dgvCobranzaItems.Rows[currentcell.Y].Cells[currentcell.X].Style.BackColor =
                    new CuitValidation().ValidarCuit(numeroCuit) ? Color.MediumSpringGreen : Color.Salmon;
            }

            if (dgvCobranzaItems.CurrentCell.ColumnIndex == 10)
            {
                //Completa la descripcion del BANCO
                var bankId = dgvCobranzaItems.CurrentCell.Value.ToString();
                var bankDescription = (DataGridViewTextBoxCell) dgvCobranzaItems.Rows[currentcell.Y].Cells[11];
                var x = _listaBancos.Find(c => c.ID_BANCO == bankId);
                if (x != null)
                {
                    dgvCobranzaItems.Rows[currentcell.Y].Cells[currentcell.X].Style.BackColor = Color.MediumSpringGreen;
                    bankDescription.Value = x.BCO_SHORTDESC;
                }
                else
                {
                    bankDescription.Value = "Banco no Encontrado";
                    dgvCobranzaItems.Rows[currentcell.Y].Cells[currentcell.X].Style.BackColor = Color.Salmon;
                }
            }
        }
        
        //Validacion de datos al salir (validar la celda del DGV)
        private void dgvCobranzaItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
                return;
            var valorCuenta =  dgvCobranzaItems.Rows[e.RowIndex].Cells[cUENTA.Name].Value;
            if (valorCuenta == null)
            {
                //el combobox de tipo de cuenta no esta completo - no permite completar nada 
                //chequeo si estoy en 'tipo cuenta' o en otra columna
                if (e.ColumnIndex!=dgvCobranzaItems.Rows[e.RowIndex].Cells[cUENTA.Name].ColumnIndex)
                {
                    //Estoy en una columna diferente a 'Cuenta' pero la columna Importe por default es 0
                    //por lo que chequea que el valor sea 0 para permitir salir
                    if (e.ColumnIndex == dgvCobranzaItems.Columns[iMPITEMDataGridViewTextBoxColumn.Name].Index)
                    {
                        //Estoy en la columna de IMPORTE
                        if (e.FormattedValue.ToString()!="0")
                        {
                            MessageBox.Show(@"Deje este campo en 0 y complete el tipo de cuenta para continuar",
                                @"Orden de Completitud Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (e.ColumnIndex == dgvCobranzaItems.Columns[iMPRECIBODataGridViewTextBoxColumn.Name].Index)
                    {
                        //Estoy en la columna de IMPORTE
                        if (e.FormattedValue.ToString() != "0")
                        {
                            MessageBox.Show(@"Deje este campo en 0 y complete el tipo de cuenta para continuar",
                                @"Orden de Completitud Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                        }
                        else
                        {
                            return;
                        }
                    }



                    //Estamos en otra colunmna diferente a IMPORTE - Tiene que ser vacio para poder salir!
                    if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        //La unica manera de salir de acá es dejando el valor vacio y salir
                        MessageBox.Show(@"Deje este campo vacio y complete el tipo de cuenta para continuar",
                            @"Orden de Completitud Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            //var currentcell = dgvCobranzaItems.CurrentCellAddress;
            if (dgvCobranzaItems.CurrentCell.ColumnIndex == 4)
            {
                //validacion importe moneda recibo
                var value = e.FormattedValue.ToString();
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    e.Cancel = true;
                    MessageBox.Show(@"El Importe NO PUEDE ser Nulo", @"Error en Importe", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    _listaCob[e.RowIndex].IMP_ITEM = 0;
                    _listaCob[e.RowIndex].IMP_RECIBO = 0;
                }
                else
                {
                    if (value.StartsWith("$") == true)
                    {
                        value = value.Remove(0, 1);
                    }

                    value = value.Trim();
                    decimal valueDecimal;
                    if (!Decimal.TryParse(value, out valueDecimal))
                    {
                        e.Cancel = true;
                        MessageBox.Show(@"Error en el formato del Importe", @"Error en Importe");
                    }

                    if (_listaCob[e.RowIndex].MON_ITEM == "USD")
                    {
                        _listaCob[e.RowIndex].IMP_RECIBO = valueDecimal * _listaCob[e.RowIndex].TC_ITEM.Value;
                    }
                    else
                    {
                        _listaCob[e.RowIndex].IMP_RECIBO = valueDecimal;
                    }

                    RecalculaImporteRecibo();
                }
            }

            if (dgvCobranzaItems.CurrentCell.ColumnIndex == 8)
            {
                //validacion de Fecha del Cheque
                var value = e.FormattedValue.ToString();
                if (string.IsNullOrEmpty(value))
                {
                    _listaCob[e.RowIndex].CHEQUE_FECHA = null;
                    e.Cancel = true;
                    MessageBox.Show(@"La fecha no puede ser NULA", @"Error en Fecha (Valor Nulo)", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DateTime valueDate;
                    if (!DateTime.TryParse(value, out valueDate))
                    {
                        MessageBox.Show(@"Error en el formato de la FECHA", @"Error en Fecha");
                        e.Cancel = true;
                    }
                    else
                    {
                        if (valueDate < DateTime.Today.AddDays(-30))
                        {
                            MessageBox.Show(@"Atencion la fecha del Cheque es Incorrecta o el Cheque esta vencido",
                                @"Error en Fecha de Cheque");
                            e.Cancel = true;
                        }

                        if (valueDate > DateTime.Today.AddDays(365))
                        {
                            MessageBox.Show(@"Atencion la fecha del Cheque es Incorrecta - No puede superar 365 dias a fecha Actual",
                                @"Error en Fecha de Cheque");
                            e.Cancel = true;
                        }
                    }
                    _listaCob[e.RowIndex].CHEQUE_FECHA = valueDate;
                }
            }
        }


        /// <summary>
        /// Realiza la validacion Global del DGV para habilitar o no el boton de Confirmar
        /// </summary>
        private void dgvCobranzaItems_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var rowValidada = false;
            var dataCuenta = dgvCobranzaItems.Rows[e.RowIndex].Cells[cUENTA.Name].Value;

            if (dataCuenta == null)
            {
                btnConfirmar.Enabled = false;
                return;
            }

            switch (dataCuenta.ToString())
            {
                case "ARS":
                    rowValidada = ValidaEfectivoRowComplete(e.RowIndex);
                    break;
                case "RIB":
                    rowValidada = ValidaEfectivoRowComplete(e.RowIndex);
                    break;
                case "RIVA":
                    rowValidada = ValidaEfectivoRowComplete(e.RowIndex);
                    break;
                case "RGA":
                    rowValidada = ValidaEfectivoRowComplete(e.RowIndex);
                    break;
                case "CHE":
                    rowValidada = ValidaChequeRowComplete(e.RowIndex);
                    break;

                default:
                    break;
            }

            if (rowValidada)
            {
                dgvCobranzaItems.Rows[e.RowIndex].Cells[ESTADO.Name].Value = "VALIDADO";
                dgvCobranzaItems.Rows[e.RowIndex].Cells[ESTADO.Name].Style.BackColor = Color.FromArgb(48, 119, 92);
            }
            else
            {
                dgvCobranzaItems.Rows[e.RowIndex].Cells[ESTADO.Name].Style.BackColor = Color.Salmon;
                dgvCobranzaItems.Rows[e.RowIndex].Cells[ESTADO.Name].Value = "INCOMPLETO";
            }

            //---  Validacion Global ---
            _todoValidado = true;

            for (var i = 0; i < dgvCobranzaItems.RowCount - 1; i++)
            {
                if (dgvCobranzaItems.Rows[i].Cells[ESTADO.Name].Value.ToString() == "INCOMPLETO")
                    _todoValidado = false;
            }

            btnConfirmar.Enabled = _todoValidado;
        }

        private void RecalculaImporteRecibo()
        {
            _importeRecibo = 0;
            var cantidadRowsDgv = dgvCobranzaItems.RowCount - 1;
            for (var i = 0; i < cantidadRowsDgv; i++)
            {
                _importeRecibo +=
                    Convert.ToDecimal(dgvCobranzaItems.Rows[i].Cells[iMPRECIBODataGridViewTextBoxColumn.Name].Value);
            }

            txtImporteReciboManual.Text = _importeRecibo.ToString("C2");

            var _importeCheck = (decimal) 0;
            if (!string.IsNullOrEmpty(txtImporteReciboCheck.Text))
            {
                _importeCheck = FormatAndConversions.CCurrencyADecimal(txtImporteReciboCheck.Text);
            }

            var diferencia = _importeRecibo - _importeCheck;
            txtImporteDiferencia.Text = (_importeRecibo - _importeCheck).ToString("C2");
            if (diferencia == 0)
            {
                txtImporteDiferencia.BackColor = Color.GreenYellow;
            }
            else
            {
                txtImporteDiferencia.BackColor = Color.Orange;
            }
        }
        private bool ValidaChequeRowComplete(int row)
        {
            if (ValidaEfectivoRowComplete(row) == false)
                return false;

            var numeroCheque = dgvCobranzaItems.Rows[row].Cells[iMPRECIBODataGridViewTextBoxColumn.Name].Value;
            if (numeroCheque == null)
            {
                return false;
            }

            var fechaCheque = dgvCobranzaItems.Rows[row].Cells[cHEQUEFECHADataGridViewTextBoxColumn.Name].Value;
            if (fechaCheque == null)
            {
                return false;
            }

            var cuitCheque = dgvCobranzaItems.Rows[row].Cells[cHEQUECUITDataGridViewTextBoxColumn.Name].Value;
            if (cuitCheque == null)
            {
                return false;
            }

            if (new CuitValidation().ValidarCuit(cuitCheque.ToString()) == false)
            {
                return false;
            }

            var bankCheque = dgvCobranzaItems.Rows[row].Cells[cHEQUEBANCODataGridViewTextBoxColumn.Name].Value;
            if (bankCheque == null)
            {
                return false;
            }

            var bank = _listaBancos.Find(c => c.ID_BANCO == bankCheque.ToString());
            if (bank == null)
                return false;

            return true;
        }
        private bool ValidaEfectivoRowComplete(int row)
        {
            var importeR = dgvCobranzaItems.Rows[row].Cells[iMPRECIBODataGridViewTextBoxColumn.Name].Value;
            if (importeR == null)
            {
                return false;
            }
            return FormatAndConversions.CCurrencyADecimal(importeR.ToString()) > 0;
        }
   
        private List<T1206_CobranzaConvertirItems> MapCobranzaList()
        {
            List<T1206_CobranzaConvertirItems> lista = new List<T1206_CobranzaConvertirItems>();
            foreach (var item in _listaCob)
            {
                var data = new T1206_CobranzaConvertirItems()
                {
                    idCobTem = Convert.ToInt32(txtNumeroReciboInterno.Text),
                    CuentaItem = item.CUENTA,
                    ImporteRecibo = item.IMP_RECIBO.Value,
                    GLItem = new CuentasManager().GetGL(item.CUENTA),
                    MonedaItem = item.MON_ITEM,
                    ImporteMoneda = item.IMP_ITEM,
                    TipoCambio = item.TC_ITEM,
                    idItem = item.LINE,
                };

                if (item.CUENTA == "CHE")
                {
                    data.CodigoPostalCheque = "0000";
                    data.Cuit = item.CHEQUE_CUIT;
                    data.FechaAcreditacion = item.CHEQUE_FECHA;
                    data.NumeroBanco = item.CHEQUE_BANCO;
                    data.NumeroCheque = item.CHEQUE_NUMERO;
                    data.NumeroCuenta = null;
                    data.IdCheque = 0;
                    if (item.CHEQUE_INTERIOR.ToUpper() == "FALSE" || item.CHEQUE_INTERIOR.ToUpper().Equals("NO"))
                    {
                        data.ChequeInterior = false;
                    }
                    else
                    {
                        data.ChequeInterior = true;
                    }
                }
                lista.Add(data);
            }
            return lista;
        }

           private bool ValidaOkRegistrar()
        {
            if (_id6 == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Cliente para el ingreso de la Cobranza", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_tipoLx == null)
            {
                MessageBox.Show(@"Debe Seleccionar L1/L2", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (rbL1.Checked == false && rbL2.Checked == false)
            {
                MessageBox.Show(@"Debe Seleccionar L1/L2", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (rbL1.Checked)
            {
                if (string.IsNullOrEmpty(txtNumeroReciboProvisorioL1.Text))
                {
                    MessageBox.Show(@"En L1 debe proveer numero recibo provisorio", @"Datos Incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            if (cmbCobrador.SelectedValue == null)
            {
                MessageBox.Show(@"Debe proveer el nombre del Cobrador que recibio el dinero o hizo la cobranza",
                    @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtImporteReciboCheck.Text))
            {
                txtImporteReciboCheck.Text = 0.ToString("C2");
            }

            var importeManual = FormatAndConversions.CCurrencyADecimal(txtImporteReciboCheck.Text);
            var importeAuto = FormatAndConversions.CCurrencyADecimal(txtImporteReciboManual.Text);

            if (importeAuto != importeManual)
            {
                MessageBox.Show(
                    @"El Importe Ingresado en Forma Manual NO COINCIDE con la SUMATORIA de valores INGRESADOS!",
                    @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (!_todoValidado)
            {
                MessageBox.Show(
                    @"La Grilla no contiene ITEMS de cobranza o alguna de las lineas no se encuentran VALIDADAS",
                    @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void rbL1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbL1.Checked)
            {
                _tipoLx = "L1";
                txtNumeroReciboProvisorioL1.Enabled = true;
            }
            else
            {
                if (rbL2.Checked)
                {
                    _tipoLx = "L2";
                    txtNumeroReciboProvisorioL1.Enabled = false;
                }
                else
                {
                    _tipoLx = null;
                }
            }
        }


        private void txtImporteReciboCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }


        #region Botones
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var f0 = new RpvReciboTemporal(Convert.ToInt32(txtNumeroReciboInterno.Text));
            f0.Show();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaOkRegistrar() == false)
                return;

            var respuesta =
                MessageBox.Show($@"Confirmar el INGRESO DE Cobranza por IMPORTE {txtImporteReciboManual.Text} ?",
                    @"Ingreso Cobranza Temporal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            txtNumeroReciboInterno.Text = new CobranzaTemporalManager().SaveNewHeader(_id6.Value, _tipoLx,
                    _importeRecibo, txtNumeroReciboProvisorioL1.Text, dtpFechaCobranza.Value,
                    cmbIngresadoPor.SelectedValue.ToString(),
                    cmbCobrador.SelectedValue.ToString(), Convert.ToDecimal(txtXRate.Text), "ARS",
                    txtObservaciones.Text)
                .ToString();


            new CobranzaTemporalManager().SaveItems(Convert.ToInt32(txtNumeroReciboInterno.Text), MapCobranzaList());
            dgvCobranzaItems.Enabled = false;
            btnConfirmar.Enabled = false;
            MessageBox.Show(
                $@"La Cobranza se ha Registrado Correctamente con el Numero Interno Temporal #{txtNumeroReciboInterno.Text}",
                @"Registro de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnImprimir.Enabled = true;
        }
        #endregion



        private void dgvCobranzaItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvCobranzaItems[e.ColumnIndex, e.RowIndex].Value.ToString();
                //int numeroFormula = Convert.ToInt32(dgvFormulaList[dgvFormulaList.Columns["iDFORMULADataGridViewTextBoxColumn"].Index, e.RowIndex].Value);

                switch (cellValue)
                {
                    case "DEL":
                    {
                        var iditem =
                            Convert.ToInt32(dgvCobranzaItems[lINEDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
                        var x = _listaCob.Find(c => c.LINE == iditem);
                        if (x == null)
                            return;

                        _listaCob.Remove(x);
                        RecalculaImporteRecibo();
                        //UpdateListWithCalculosImportes();
                        //CompletaFormateaDataGridView();
                        //                    SumaImportes(ckAutoIVA21.Checked);
                        //t0407RendicionFFIBindingSource.DataSource = _lItems.ToList();
                        //                    //dgvDetalleItems.DataSource = t0404VENDORFACTIBindingSource.DataSource;
                    }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }
        private void dgvCobranzaItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Voy a validar que antes de ingresar un valor este seleccionada la cuenta
            if (e.ColumnIndex != dgvCobranzaItems[cUENTA.Name, e.RowIndex].ColumnIndex)
            {
                if (e.ColumnIndex == 0)
                    return;

                var cuenta1 = (DataGridViewComboBoxCell)dgvCobranzaItems.Rows[e.RowIndex].Cells[cUENTA.Name];
                if (cuenta1.Value == null)
                {
                    MessageBox.Show(@"Debe seleccionar primero la 'Cuenta' para poder continuar", @"Orden de Completitud Incorrecto",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
            }
        }
    }
}

              