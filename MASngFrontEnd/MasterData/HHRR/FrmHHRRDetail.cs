using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using TecserEF.Entity;

namespace MASngFE.MasterData.HHRR
{
    public partial class FrmHHRRDetail : Form
    {
        public FrmHHRRDetail(int modo, string idEmployeeIniciales = null)
        {
            _modo = modo;
            _idEmployeeInicial = idEmployeeIniciales;
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private readonly int _modo;
        private string _idEmployeeInicial; //iniciales
        private string _shortname; //new employee key
        //-------------------------------------------------------------------------------------------------------------------------------

        private void FrmHHRRDetail_Load(object sender, EventArgs e)
        {
            ConfiguracionInicial();
            LoadComboBoxFromTextFile();
            ConfiguraSegunModo();
        }

        private void ConfiguracionInicial()
        {
            t0008REGIONBindingSource.DataSource = new AddressManager("AR").CompleteListRegions();
            t0010LOCALIDADBindingSource.DataSource = new AddressManager("AR").CompleteListLocalidad();
            t0086HHRRPOSICIONESBindingSource.DataSource = new HumanResourcesManager().GetPosicionesList();
            cmbPosicion.SelectedIndex = -1;
        }

        private void ConfiguraSegunModo()
        {
            btnAdministrarCargo.Enabled = false;
            btnBajaEmpleado.Enabled = false;
            btnGuardar.Enabled = false;
            txtIniciales.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtShortname.ReadOnly = true;
            dtpFechaIngreso.Enabled = false;

            switch (_modo)
            {
                case 1:
                    btnAdministrarCargo.Enabled = true;
                    btnBajaEmpleado.Enabled = true;
                    btnGuardar.Enabled = true;
                    txtIniciales.ReadOnly = false;
                    txtNombre.ReadOnly = false;
                    txtApellido.ReadOnly = false;
                    txtShortname.ReadOnly = false;
                    dtpFechaIngreso.Enabled = false;
                    dtpFechaIngreso.Value = DateTime.Today;
                    break;

                case 2:
                    btnAdministrarCargo.Enabled = true;
                    btnBajaEmpleado.Enabled = true;
                    btnGuardar.Enabled = true;
                    LoadDataFromDb();
                    if (ckEmpleadoActivo.Checked == true)
                        btnBajaEmpleado.Enabled = true;

                    break;

                case 3:
                    LoadDataFromDb();
                    break;
            }
        }

        private void LoadComboBoxFromTextFile()
        {
            try
            {
                string fileName = Environment.CurrentDirectory + @"\ConfigFiles\glsyj.txt";
                string[] pollLines = File.ReadAllLines(fileName);
                foreach (var line in pollLines)
                {
                    string[] tokens = line.Split(',');
                    cmbGLAP.Items.Add(tokens[0]);
                }
            }
            catch
            {
                // ignored
                MessageBox.Show(@"No se encontro el archivo de configuracion GLSYJ", @"Error de Configuracion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataFromDb()
        {
            //Carga Datos Generales T0085
            var dataGeneral = new HumanResourcesManager().GetEmployeeData(_idEmployeeInicial);
            var dataPersonal = new HumanResourcesManager().GetDatosPersonales(_idEmployeeInicial);

            if (dataGeneral == null)
            {
                MessageBox.Show(@"Ha Ocurrido un error Gravisimo al cargar los datos del empleado", @"Error HR01",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtIniciales.Text = _idEmployeeInicial; //Antigua Key pero lo quiero pasar a shortname
            _shortname = dataGeneral.SHORTNAME; //New Key

            txtNombre.Text = dataGeneral.NOMBRE;
            txtApellido.Text = dataGeneral.APELLIDO;
            txtShortname.Text = dataGeneral.SHORTNAME;
            txtShortname.Enabled = false;
            txtIniciales.Enabled = false;

            txtLegajo.Text = dataGeneral.GL; //No se puede cambiar porque tiene asociado los GL
            txtLegajo.Enabled = false;
            txtLegajoRaffone.Text = dataGeneral.LEGAJORAF;
            ckEmpleadoActivo.Checked = dataGeneral.ACTIVO;

            //Informacion Corporativa
            txtEmailCorporativo.Text = dataGeneral.EMAILCORP;
            //txtUsderAD.Text=
            //txtPasswordAD.Text=


            //Datos Personales
            if (dataPersonal != null)
            {
                txtDireccion.Text = dataPersonal.DireccionCalle;

                if (string.IsNullOrEmpty(dataPersonal.DireccionProvincia))
                {
                    cmbProvincia.SelectedIndex = -1;
                }
                else
                {
                    cmbProvincia.SelectedValue = dataPersonal.DireccionProvincia;
                }

                if (string.IsNullOrEmpty(dataPersonal.DireccionLocalidad))
                {
                    cmbLocalidad.SelectedIndex = -1;
                }
                else
                {
                    cmbLocalidad.SelectedValue = dataPersonal.DireccionLocalidad;
                }


                if (dataPersonal.FechaNacimiento != null)
                {
                    dtpFechaNacimiento.Value = dataPersonal.FechaNacimiento.Value;
                    dtpFechaNacimiento.ForeColor = Color.DarkBlue;
                }
                else
                {
                    dtpFechaNacimiento.ForeColor = Color.Red;
                }

                txtTelefonoContacto1.Text = dataPersonal.Telefono1;
                txtTelefonoContacto2.Text = dataPersonal.Telefono2;
                txtEmailPersonal.Text = dataPersonal.EmailPersonal;

                if (dataPersonal.UltimaActualizacionDireccion != null)
                    txtUltimaActualizacionDatosPersonales.Text =
                        dataPersonal.UltimaActualizacionDireccion.Value.ToString("d");
            }
            txtDni.Text = dataGeneral.DOCUMENTO;
            txtCuilEmpleado.Text = dataGeneral.CUIL;


            //General Footer
            if (dataGeneral.INGRESO != null)
                dtpFechaIngreso.Value = dataGeneral.INGRESO.Value;

            if (dataGeneral.FechaBaja != null)
                dtpFechaBaja.Value = dataGeneral.FechaBaja.Value;


            //Permisos y Funciones
            ckDispVendedor.Checked = dataGeneral.PERMITE_VENTA.Value;
            ckDispOperador.Checked = dataGeneral.PERMITE_OPERARIO.Value;
            ckDispCQ.Checked = dataGeneral.PERMITE_CCALIDAD.Value;
            ckDispDespacho.Checked = dataGeneral.PERMITE_DESPACHO.Value;
            ckDispCobranza.Checked = dataGeneral.PERMITE_COBRANZA.Value;
            ckDispIC.Checked = dataGeneral.PermiteIngresoIC.Value;

            if (dataGeneral.AutorizaSinCargo == null)
                dataGeneral.AutorizaSinCargo = false;

            ckAutorizaSinCargo.Checked = dataGeneral.AutorizaSinCargo.Value;

            ckDispVendedor.BackColor = !ckDispVendedor.Checked ? Color.Red : Color.GreenYellow;
            ckDispOperador.BackColor = !ckDispOperador.Checked ? Color.Red : Color.GreenYellow;
            ckDispCQ.BackColor = !ckDispCQ.Checked ? Color.Red : Color.GreenYellow;
            ckDispDespacho.BackColor = !ckDispDespacho.Checked ? Color.Red : Color.GreenYellow;
            ckDispCobranza.BackColor = !ckDispCobranza.Checked ? Color.Red : Color.GreenYellow;
            ckDispIC.BackColor = !ckDispIC.Checked ? Color.Red : Color.GreenYellow;
            ckAutorizaSinCargo.BackColor = !ckAutorizaSinCargo.Checked ? Color.Red : Color.GreenYellow;

            //Liquidacion SYJ

            if (dataGeneral.POSICION != null)
            {
                cmbPosicion.SelectedValue = dataGeneral.POSICION;
              MapPositionData(MapDataGeneral().POSICION.Value);
            }

            txtComisionPorcentaje.Text = dataGeneral.COMISION2_FIJA != null
                ? dataGeneral.COMISION2_FIJA.Value.ToString("P2")
                : 0.ToString("P2");

            cmbGLAP.Text = dataGeneral.GLAPSYJ;
            txtDescripcionGLAP.Text = new GlAccountStructureManager().GetGLDescription(cmbGLAP.Text);

            if (dataGeneral.VENDOR == null)
            {
                txtVendorId.Text = null;
                txtVendorDescription.Text = @"NO VENDOR ID CREADO";
            }
            else
            {
                var vendorData = new VendorManager().GetSpecificVendor(Convert.ToInt32(dataGeneral.VENDOR));
                txtVendorId.Text = vendorData.id_prov.ToString();
                txtVendorDescription.Text = vendorData.prov_rsocial;
            }

            txtVendorId.Text = dataGeneral.VENDOR.ToString();
            txtNumeroCuentaBanco.Text = dataGeneral.CUENTANUMERO;
            txtCBU.Text = dataGeneral.CBU;
            ckEmpleadoActivo.BackColor = ckEmpleadoActivo.Checked ? Color.GreenYellow : Color.Crimson;
        }

        private void MapPositionData(int posicion)
        {
            var dataPosicion = HumanResourcesManager.GetPosicioneData(posicion);
            txtCargo.Text = dataPosicion.IDPOSICION.ToString();
            txtTipoLiquidacion.Text = dataPosicion.TipoLiquidacion;

            if (dataPosicion.ValorHora == null)
                dataPosicion.ValorHora = 0;

            txtValorHora.Text = dataPosicion.ValorHora.Value.ToString("C2");

            if (dataPosicion.ValorMensual == null)
                dataPosicion.ValorMensual = 0;

            txtValorMensual.Text = dataPosicion.ValorMensual.Value.ToString("C2");


            if (dataPosicion.AdicionalBono1 == null)
                dataPosicion.AdicionalBono1 = 0;
            txtValorL2.Text = dataPosicion.AdicionalBono1.Value.ToString("C2");

            if (dataPosicion.AdicionalBono2 == null)
                dataPosicion.AdicionalBono2 = 0;

            if (dataPosicion.AdicionalPresentismo == null)
                dataPosicion.AdicionalPresentismo = 0;


            txtValorAdicional2.Text = dataPosicion.AdicionalPresentismo.Value.ToString("C2");

            ckFueraConvenio.Checked = !dataPosicion.EnConvenio;

            if (dataPosicion.UltimaActualizacion != null)
                txtTarifasUltimaActualizacion.Text = dataPosicion.UltimaActualizacion.Value.ToString("d");
        }

        #region Botones

        private void btnBajaEmpleado_Click(object sender, EventArgs e)
        {
            if (ckEmpleadoActivo.Checked)
            {
                MessageBox.Show(@"Para dar de baja un empleado debe colocarlo primero en INACTIVO", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var msg = MessageBox.Show(@"Confirma la baja del Empleado?", @"Baja de Empleado", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                if (new HumanResourcesManager().SetInactivo(_shortname, dtpFechaBaja.Value))
                {
                    MessageBox.Show(@"Se ha dado de baja correctamente al Empleado", @"HHRR", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    var rtn =new HumanResourcesManager().BajaCuentasGLEmpleados(_idEmployeeInicial);
                    if (rtn)
                        MessageBox.Show(@"Se han dado de baja las cuentas GL del Empleado en Cuestion", @"Baja Correcta",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show(@"Ha Ocurrido un error al dar de baja al empleado, o no se han realizado cambios",
                        @"HHRR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdministrarCargo_Click(object sender, EventArgs e)
        {
        }

        #endregion

        #region ValidacionControles

        private void txtIniciales_Leave(object sender, EventArgs e)
        {
            if (_modo != 1) return;
            if (HumanResourcesManager.CheckIfInicialAlreadyExist(txtIniciales.Text))
            {
                MessageBox.Show(@"El Valor INGRESADO ya existe y no puede estar duplicado", @"Valor Duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIniciales.Text = null;
                txtIniciales.Focus();
            }
        }

        private void txtShortname_TextChanged(object sender, EventArgs e)
        {
            if (_modo != 1) return;
            if (HumanResourcesManager.CheckIfShornameAlreadyExist(txtShortname.Text))
            {
                MessageBox.Show(@"El Valor ingresado ya existe y no puede estar duplicado", @"Valor Duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtShortname.Text = null;
                txtShortname.Focus();
            }
        }

        private void txtLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void txtLegajo_Leave(object sender, EventArgs e)
        {
            if (_modo != 1) return;
            if (string.IsNullOrEmpty(txtLegajo.Text))
                return;
            int data = Convert.ToInt32(txtLegajo.Text);
            if (HumanResourcesManager.CheckIfLegajoIdAlreadyExist(data))
            {
                MessageBox.Show(@"El Valor ingresado ya existe y no puede estar duplicado", @"Valor Duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLegajo.Text = null;
                txtLegajo.Focus();
            }
        }

        private void cmbGLAP_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescripcionGLAP.Text = new GlAccountStructureManager().GetGLDescription(cmbGLAP.Text);
        }

        private void txtComisionPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtComisionPorcentaje_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtComisionPorcentaje.Text))
                txtComisionPorcentaje.Text = "0";

            decimal porcentaje = FormatAndConversions.CPorcentajeADecimal(txtComisionPorcentaje.Text);

            if (porcentaje > (decimal) 0.5)
            {
                MessageBox.Show(@"El Valor de la comision excede el Maximo Permitido", @"Error en % de comision",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                MensajeError(txtComisionPorcentaje, "");
                porcentaje = 0;
            }

            txtComisionPorcentaje.Text = porcentaje.ToString("P2");
        }

        #endregion

        private T0085_PERSONAL MapDataGeneral()
        {
            var data = new T0085_PERSONAL()
            {
                ID_VEND = txtIniciales.Text,
                GL = txtLegajo.Text,
                ACTIVO = ckEmpleadoActivo.Checked,
                SHORTNAME = txtShortname.Text,
                GLAPSYJ = cmbGLAP.Text,
                APELLIDO = txtApellido.Text,
                EMAILCORP = txtEmailCorporativo.Text,
                DOCUMENTO = txtDni.Text,
                INGRESO = dtpFechaIngreso.Value,
                CBU = txtCBU.Text.Trim(),
                CUENTANUMERO = txtNumeroCuentaBanco.Text,
                CUIL = txtCuilEmpleado.Text,
                LEGAJORAF = txtLegajoRaffone.Text,
                NOMBRE = txtNombre.Text,
                PERMITE_CCALIDAD = ckDispCQ.Checked,
                PERMITE_COBRANZA = ckDispCobranza.Checked,
                PERMITE_DESPACHO = ckDispDespacho.Checked,
                PERMITE_OPERARIO = ckDispOperador.Checked,
                PERMITE_VENTA = ckDispVendedor.Checked,
                PermiteIngresoIC = ckDispIC.Checked,
                AutorizaSinCargo = ckAutorizaSinCargo.Checked,
            };

            if (string.IsNullOrEmpty(txtVendorId.Text) == false)
            {
                data.VENDOR = Convert.ToInt32(txtVendorId.Text);
            }

            if (cmbPosicion.SelectedValue != null)
            {
                data.POSICION = Convert.ToInt32(cmbPosicion.SelectedValue);
            }

            if (dtpFechaBaja.Value <= DateTime.Today)
            {
                data.FechaBaja = dtpFechaBaja.Value;
            }
            else
            {
                data.FechaBaja = null;
            }

            data.SYJ = false;
            data.SYJQ = false;

            if (txtTipoLiquidacion.Text == @"QUINCENAL")
                data.SYJQ = true;

            if (txtTipoLiquidacion.Text == @"MENSUAL")
                data.SYJ = true;

            var comisionPorcentaje = FormatAndConversions.CPorcentajeADecimal(txtComisionPorcentaje.Text);
            data.COMISION2_FIJA = comisionPorcentaje;
            return data;
        }
        private T0085_HHRR_DATOSPERSONALES MapDatosPersonales()
        {
            var data = new T0085_HHRR_DATOSPERSONALES()
            {
                IDEMPLEADO = txtIniciales.Text,
                CUIL = txtCuilEmpleado.Text.Trim(),
                DNI = txtDni.Text.Trim(),
                DireccionCalle = txtDireccion.Text,
                EmailPersonal = txtEmailPersonal.Text,
                Telefono1 = txtTelefonoContacto1.Text,
                Telefono2 = txtTelefonoContacto2.Text,
            };

            if (dtpFechaNacimiento.Value < DateTime.Today.AddDays(-6500))
            {
                data.FechaNacimiento = dtpFechaNacimiento.Value;
            }

            if (cmbLocalidad.SelectedValue != null)
            {
                data.DireccionLocalidad = cmbLocalidad.SelectedValue.ToString();
            }

            if (cmbProvincia.SelectedValue != null)
            {
                data.DireccionProvincia = cmbProvincia.SelectedValue.ToString();
            }

            if (String.IsNullOrEmpty(txtUltimaActualizacionDatosPersonales.Text) == false)
            {
                data.UltimaActualizacionDireccion = Convert.ToDateTime(txtUltimaActualizacionDatosPersonales.Text);
            }
            return data;
        }


        //Desde aca no revisado!


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaDataCompletaToSave() == false)
                return;

            bool resultado = false;

            resultado = new HumanResourcesManager().CreateUpdateGeneralData(MapDataGeneral());

            if (resultado)
            {
                MessageBox.Show(@"Se han actualizado correctamente los datos Generales", @"Actualizacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"No Se han actualizado datos Generales", @"Actualizacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            resultado = new HumanResourcesManager().CreateUpdatePersonalData(MapDatosPersonales());
            new HumanResourcesManager().CreateGLAccountsForEmployees(txtIniciales.Text);

            if (resultado)
            {
                MessageBox.Show(@"Se han actualizado correctamente los datos Personales", @"Actualizacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"No Se han actualizado datos Personales", @"Actualizacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidaDataCompletaToSave()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
                return MensajeError(txtNombre, "Nombres");

            if (string.IsNullOrEmpty(txtApellido.Text))
                return MensajeError(txtApellido, "Apellido");

            if (string.IsNullOrEmpty(txtShortname.Text))
                return MensajeError(txtShortname, "Shortname");

            if (string.IsNullOrEmpty(txtIniciales.Text))
                return MensajeError(txtIniciales, "Iniciales");

            if (string.IsNullOrEmpty(cmbGLAP.Text))
                return MensajeError(txtLegajo, "Legajo Interno /GL Account");


            if (ckEmpleadoActivo.Checked != true)
                ckEmpleadoActivo.Checked = false;

            if (string.IsNullOrEmpty(cmbGLAP.Text))
                return MensajeError(cmbGLAP, "GL/AP SYJ");

            return true;
        }

        private bool MensajeError(Control campo, string descripcionCampo, bool mostrarToolTip = true,
            bool mostrarMsg = false)
        {
            if (mostrarMsg)
            {
                MessageBox.Show(
                    $"El Campo {descripcionCampo} se encuentra INCOMPLETO o contiene datos no validos y no se puede continuar con la actualizacion de datos",
                    @"Datos Incompletos o Erroneos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (mostrarToolTip)
            {
                toolTip.ToolTipTitle = "Datos Incorrectos/Incompletos";
                toolTip.Show("Debe completar este campo para poder continuar", campo, campo.Location, 5000);
            }
            return false;
        }


        private void ckEmpleadoActivo_CheckedChanged(object sender, EventArgs e)
        {
            ckEmpleadoActivo.BackColor = ckEmpleadoActivo.Checked ? Color.GreenYellow : Color.Crimson;
        }
        private void txtLegajoRaffone_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void cmbPosicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPosicion.SelectedIndex !=-1)
            {
                txtCargo.Text = cmbPosicion.SelectedValue.ToString();
                MapPositionData(Convert.ToInt32(cmbPosicion.SelectedValue));
            }
        }
    }
}
