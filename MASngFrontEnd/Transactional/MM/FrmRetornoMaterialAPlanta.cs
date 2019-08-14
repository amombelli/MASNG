using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using Tecser.Business.VBTools;
using TecserEF.Entity;

namespace MASngFE.Transactional.MM
{
    public partial class FrmRetornoMaterialAPlanta : Form
    {
        public FrmRetornoMaterialAPlanta(int modo,int idH)
        {
            _idh = idH;
            InitializeComponent();
        }
        public FrmRetornoMaterialAPlanta(int modo=0)
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
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
        }

        private int? _id6;
        private int _idh;
        private DateTime? _fechaDocumento;
        private MotivoDevolucion.Motivo _motivoIngreso;

        private T0360_RTN _data = new T0360_RTN();

        //-------------------------    Funcionalidad de Combos ------------------------------------

        #region Funcionalidad de Combos

        //1.-Definir Variable private int? _id6;
        //2.-Agregar Binding
        // NumeroTax (keyUP/TextChanged/Leave)
        // CodigoTax (TextChanged/Leave)
        //2.-Atencion cmbRazonSocial_TextUpdate asignado a 3 Combos

        ///**Funcionalidad validacion / CUIT
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
                _id6 = null;
                return;
            }
            _id6 = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            //txtGLAp.Text = new GLAccountManagement().GetApVendorGl(_id6.Value);
            ValidaCuitCorrecto();

            //var ctacte = new CtaCteCustomer(_id6.Value);
            //txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            //txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            //txtSaldoL1.BackColor = ctacte.GetResultadoCtaCte("L1").SaldoColor;
            //txtSaldoL2.BackColor = ctacte.GetResultadoCtaCte("L2").SaldoColor;
            //txtSaldoTotal.Text = (FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text) + FormatAndConversions.CCurrencyADecimal(txtSaldoL2.Text)).ToString("C2");
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
            //  }
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

        //Fin Funcionalidad Combobox!

        #endregion

        #region Funcionalidad Fecha

        private void mskFechaFactura_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            DateTime dt;
            if (DateTime.TryParseExact(mskFechaFactura.Text,
                "d/M/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt))
            {
                //valid date
                txtFechaValidada.BackColor = Color.GreenYellow;
                _fechaDocumento = dt;
            }
            else
            {
                //invalid date
                toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
                toolTip1.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA",
                    mskFechaFactura,
                    mskFechaFactura.Location, 5000);

                txtFechaValidada.BackColor = Color.OrangeRed;
                _fechaDocumento = null;
            }
        }

        private void mskFechaFactura_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtFechaValidada.BackColor = Color.OrangeRed;
            _fechaDocumento = null;

            toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
            toolTip1.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA",
                mskFechaFactura,
                mskFechaFactura.Location, 5000);
        }

        #endregion

        private void MapData()
        {
            var x = new T0360_RTN()
            {
                IDCLI = _id6.Value,
                CLIENTE = cmbRazonSocial.Text,
                MATERIAL = cmbMaterial.SelectedValue.ToString(),
                FECHA = _fechaDocumento,
                KG = Convert.ToDecimal(txtKgRecibidos.Text),
                LOTE = txtNumeroLote.Text,
                RECIBIO = cmbRecibidoPor.SelectedValue.ToString(),
                UBICACION = cmbSLOC.SelectedValue.ToString(),
                MOTIVO = Convert.ToInt32(_motivoIngreso).ToString(),
                COMENTARIO = txtMotivoDevolucion.Text,
                TIPO_MOV = "LX",
                IDX = _idh,
            };
            _data = x;
        }
        private void FrmRetornoMaterialAPlanta_Load(object sender, EventArgs e)
        {
            t0006MCLIENTESBindingSource.DataSource = new CustomerManager().GetCompleteListofBillTo(true);
            t0011MATERIALESAKABindingSource.DataSource = new MaterialMasterManager().GetCompleteListofAka(true);
            t0028SLOCBindingSource.DataSource = new StorageLocationManager().ListOfLoc();
            t0085PERSONALBindingSource.DataSource = new HumanResourcesManager().GetListEmployees(true);
            cmbRecibidoPor.SelectedIndex = -1;
            cmbAprobadoPor.SelectedIndex = -1;
            cmbMaterial.SelectedIndex = -1;
            cmbSLOC.SelectedValue = "LAB1";
            cmbSLOC.Enabled = false;
            BlanqueaSeleccion();
        }
        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            var f = new FrmBusquedaAvanzadaCliente();
            f.ShowDialog();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!AllowReception())
                return;

            var pregunta = MessageBox.Show(@"Confirma el RE-INGRESO del Material Seleccionado?",
                @"Confirmacion de Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (pregunta == DialogResult.No)
                return;

            MapData();
            _idh=new ManageRetornoMaterial().GuardaRtn(_data);
            if (_idh > 0)
            {
                txtIdH.Text = _idh.ToString();
                new StockABM().AltaNewStockLine(_data.MATERIAL, _data.LOTE, _data.KG.Value,
                    StockStatusManager.EstadoLote.Restringido, cmbSLOC.SelectedValue.ToString(), "RTN1", false,
                    txtMotivoDevolucion.Text);
                var id40 =new MmLog().LogMMAltaNewStockDevolucion(_motivoIngreso, _idh);
                new ManageRetornoMaterial().UpdateId40(_idh,id40);
                MessageBox.Show(@"Se ha ingresado el Stock en Forma Correcta!", @"Re-Ingreso de Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIngresar.Enabled = false;
            }
        }

        private bool AllowReception()
        {
            if (_id6 == null || _id6 == 0)
            {
                MessageBox.Show(@"Debe Selecionar un Cliente", @"Validacion de Re-Ingreso de Materiales",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbMaterial.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe Selecionar un Material", @"Validacion de Re-Ingreso de Materiales",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtKgRecibidos.Text))
            {
                txtKgRecibidos.Text = 0.ToString("n2");
            }

            if (Convert.ToDecimal(txtKgRecibidos.Text) <= 0)
            {
                MessageBox.Show(@"La cantidad a Recibir debe ser mayor a 0 Kg.", @"Kg a Ingresar Incorrectos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtNumeroLote.Text))
            {
                MessageBox.Show(@"Debe Completar un numero de Lote", @"Validacion de Re-Ingreso de Materiales",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_fechaDocumento == null)
            {
                MessageBox.Show(@"Debe Completar una Fecha de Ingreso", @"Validacion de Re-Ingreso de Materiales",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var ckMotivoSeleccionado = grpMotivo.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (ckMotivoSeleccionado == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Motivo", @"Kg a Ingresar Incorrectos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbRecibidoPor.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe Seleccionar quien fue el responsable de Recibir el Material",
                    @"Validacion de Re-Ingreso de Materiales",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private void txtKgRecibidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtKgRecibidos_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgRecibidos.Text))
            {
                txtKgRecibidos.Text = 0.ToString("n2");
            }
            if (Convert.ToDecimal(txtKgRecibidos.Text) <= 0)
            {
                MessageBox.Show(@"La cantidad a Recibir debe ser mayor a 0 Kg.", @"Kg a Ingresar Incorrectos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rbOtro_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = grpMotivo.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);

            if (checkedButton == null)
                return;

            switch (checkedButton.Name)
            {
                case "rbAdmin":
                    _motivoIngreso = MotivoDevolucion.Motivo.ErrorAdmnitrativo;
                    break;
                case "rbFE":
                    _motivoIngreso = MotivoDevolucion.Motivo.FE;
                    break;
                case "rbOtro":
                    _motivoIngreso = MotivoDevolucion.Motivo.Otro;
                    break;
                case "rbPedidoIncorrecto":
                    _motivoIngreso = MotivoDevolucion.Motivo.PedidoIncorrecto;
                    break;
                case "rbStockSobrante":
                    _motivoIngreso = MotivoDevolucion.Motivo.SobranteCliente;
                    break;

                default:
                    break;
            }

            //var ckMnc = grpMotivo.Controls.OfType<RadioButton>()
            //    .FirstOrDefault(r => r.Checked);
            //btnIngresar.Enabled = ckMnc != null && HabilitaBotonContinuar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimirRecepcion_Click(object sender, EventArgs e)
        {

        }

        private void txtNumeroLote_Leave(object sender, EventArgs e)
        {
            MessageBox.Show(@"Validar que el Lote sea Correcto", @"en proceso");
            return;
        }
    }

  
}
