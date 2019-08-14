﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData;
using MASngFE.MasterData.Customer_Master;
using Tecser.Business.DataFix;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional;
using Tecser.Business.Transactional.CRM;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.SD.SalesOrder
{
    public partial class FrmSD02SalesOrderMain : Form
    {
        //--------------------------------------------------------------------------------
        private readonly int _modo;
        public int IdClienteT6 { get; }
        private int IdCliente7 { get; set; }
        public int NumeroSO { get; private set; }       //Nueva SO# 0
        private SalesOrderStatusManager.StatusHeader StatusSO { get; set; }
        public List<T0046_OV_ITEM> Items { get; set; } = new List<T0046_OV_ITEM>();
        //--------------------------------------------------------------------------------
        public int Modo
        {
            get { return _modo; }
        }
        
        
        //Constructores

        public FrmSD02SalesOrderMain(int idClienteT6)
        {
            //Creacion de nueva Sales Order
            _modo = 1;
            IdClienteT6 = idClienteT6;
            NumeroSO = 0;
            InitializeComponent();
        }
        
        public FrmSD02SalesOrderMain(int modo, int idSo)
        {
            //Edicion y Visualizacion de Sales Order
            _modo = modo;
            NumeroSO = idSo;
            IdCliente7 = new SalesOrderDataManager().GetDataHeaderFromDb(idSo).CLIENTE.Value;
            IdClienteT6 = new CustomerManager().GetId6FromCustomerT7(IdCliente7);
            InitializeComponent();
        }
        private void FrmSalesOrderMain_Load(object sender, EventArgs e)
        {
            ConfiguraDefault();
            LoadDataSegunModo();
            LoadDataChequeRechazado();
        }

        private void ConfiguraDefault()
        {
            //Configura combobox
            var persona = new HumanResourcesManager();
            cmbVendedor.DataSource = persona.GetListAllActiveVendedor().ToList();
            cmbVendedor.ValueMember = "ID_VEND";
            cmbVendedor.DisplayMember = "SHORTNAME";

            cmbUsuario.Text = GlobalApp.AppUsername;
            cmbUsuario.Enabled = false;
            //
            t0046OVITEMBindingSource.DataSource = Items.ToList();
            dgvSoItems.DataSource = t0046OVITEMBindingSource.DataSource;
        }
        public void RefrescaDgv()
        {
            t0046OVITEMBindingSource.DataSource = Items.ToList();
            dgvSoItems.DataSource = Items.ToList(); //esto lo saque recien .. revisar
        }
        private void SetValuesNewSalesOrder()
        {
            dtpFechaSO.Value = DateTime.Today;
            cmbEnvio.Text = @"ENVIO s/CARGO";
            cmbMetodoIngreso.Text = @"TELEFONO";
            txtSalesOrderNumero.Text = null;
            StatusSO = SalesOrderStatusManager.StatusHeader.Inicial;
            txtEstadoSO.Text = StatusSO.ToString();
        }
        private void ConfiguraComportamientoSegunModo()
        {
            txtComentarioSalesOrder.Enabled = false;
            dtpFechaSO.Enabled = false;
            cmbMetodoIngreso.Enabled = false;
            cmbUsuario.Enabled = false;
            txtNumeroOC.Enabled = false;
            cmbVendedor.Enabled = false;
            cmbEnvio.Enabled = false;
            //dgvSoItems.Enabled = false;

            btnAddNewItem.Enabled = false;
            BtnEmitirSO.Enabled = false;
            BtnCancelarSO.Enabled = false;

            switch (Modo)
            {
                case 1:
                    //En este modo el Status debiera ser solo Inicial
                    txtComentarioSalesOrder.Enabled = true;
                    dtpFechaSO.Enabled = true;
                    cmbMetodoIngreso.Enabled = true;
                    txtNumeroOC.Enabled = true;
                    cmbVendedor.Enabled = true;
                    cmbEnvio.Enabled = true;
                    dgvSoItems.Enabled = true;
                    btnAddNewItem.Enabled = true;
                    BtnEmitirSO.Enabled = true;
                    break;
                case 2:
                    switch (StatusSO)
                    {
                        case SalesOrderStatusManager.StatusHeader.Inicial:
                            txtComentarioSalesOrder.Enabled = true;
                            dtpFechaSO.Enabled = true;
                            cmbMetodoIngreso.Enabled = true;
                            txtNumeroOC.Enabled = true;
                            cmbVendedor.Enabled = true;
                            cmbEnvio.Enabled = true;
                            dgvSoItems.Enabled = true;
                            btnAddNewItem.Enabled = true;
                            txtModoUso.Text = @"EDICION";
                            txtModoUso.BackColor = Color.Orange;
                            BtnCancelarSO.Enabled = true;
                            BtnEmitirSO.Enabled = true;
                            break;
                        case SalesOrderStatusManager.StatusHeader.Emitida:
                            txtComentarioSalesOrder.Enabled = true;
                            dtpFechaSO.Enabled = true;
                            cmbMetodoIngreso.Enabled = true;
                            txtNumeroOC.Enabled = true;
                            cmbVendedor.Enabled = true;
                            cmbEnvio.Enabled = true;
                            dgvSoItems.Enabled = true;
                            btnAddNewItem.Enabled = true;
                            txtModoUso.Text = @"EDICION";
                            txtModoUso.BackColor = Color.Orange;
                            BtnCancelarSO.Enabled = true;
                            break;
                        case SalesOrderStatusManager.StatusHeader.Cerrada:
                            MessageBox.Show(
                                @"El Modo de edicion no está permitido en una Sales Order que se encuentra Cerrada" +
                                Environment.NewLine + @"Se procedera a cargar en modo Visualizacion",
                                @"Restriccion en Modo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtModoUso.Text = @"VISUALIZACION";
                            txtModoUso.BackColor = Color.Chartreuse;

                            break;
                        case SalesOrderStatusManager.StatusHeader.Cancelada:
                            MessageBox.Show(
                                @"El Modo de edicion no está permitido en una Sales Order que se encuentra Cancelada" +
                                Environment.NewLine + @"Se procedera a cargar en modo Visualizacion",
                                @"Restriccion en Modo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtModoUso.Text = @"VISUALIZACION";
                            txtModoUso.BackColor = Color.Chartreuse;

                            break;
                        case SalesOrderStatusManager.StatusHeader.Proceso:
                            MessageBox.Show(
                                @"El Modo de edicion esta limitado en una Sales Order que se encuentra en Proceso" +
                                Environment.NewLine + @"Se procedera a cargar en modo Visualizacion",
                                @"Restriccion en Modo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //limitado
                            txtComentarioSalesOrder.Enabled = true;
                            dtpFechaSO.Enabled = true; //NO PERMITE CAMBIAR FECHA DE SO.-
                            cmbMetodoIngreso.Enabled = true;
                            txtNumeroOC.Enabled = true;
                            cmbVendedor.Enabled = true;
                            cmbEnvio.Enabled = true;
                            dgvSoItems.Enabled = true;
                            btnAddNewItem.Enabled = true;
                            txtModoUso.Text = @"EDICION LIM";
                            txtModoUso.BackColor = Color.Crimson;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;

                case 3:
                    break;
            }
        }
        private void LoadDataSegunModo()
        {
            switch (Modo)
            {
                case 1:
                    if (AsignaClienteT7() == false)
                        this.Close();
                    LoadCustomerData();
                    if (ckBloqueoSO.Checked)
                    {
                        MessageBox.Show(@"El Cliente se encuentra bloqueado para ingreso de nuevas NP. No se puede continuar hasta tanto no se haya resuelto el problema administrativo",
                            @"Bloqueo de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    SetValuesNewSalesOrder();
                    ConfiguraComportamientoSegunModo();
                    txtModoUso.Text = @"NUEVA SO";
                    txtModoUso.BackColor = Color.Yellow;
                    break;

                case 2:
                    LoadCustomerData();
                    LoadSalesOrderHeader();
                    LoadSalesOrderItems();
                    ConfiguraComportamientoSegunModo();
                    break;
                case 3:
                    LoadCustomerData();
                    LoadSalesOrderHeader();
                    LoadSalesOrderItems();
                    ConfiguraComportamientoSegunModo();
                    txtModoUso.Text = @"VISUALIZACION";
                    txtModoUso.BackColor = Color.Chartreuse;
                    break;

                default:
                    break;
            }
        }
        private void LoadSalesOrderHeader()
        {
            var header = new SalesOrderDataManager().GetDataHeaderFromDb(NumeroSO);
            if (header.FECHA_OV != null) dtpFechaSO.Value = header.FECHA_OV.Value;
            cmbMetodoIngreso.Text = header.MetodoIngreso;
            cmbUsuario.Text = header.LOG_USER;
            txtNumeroOC.Text = header.NumeroOC;
            cmbVendedor.Text = header.Vendedor;
            cmbMetodoIngreso.Text = header.MetodoIngreso;
            txtEstadoSO.Text = header.StatusOV;
            StatusSO = SalesOrderStatusManager.MapStatusHeaderFromText(header.StatusOV);
            txtSalesOrderNumero.Text = NumeroSO.ToString();
        }
        private void LoadSalesOrderItems()
        {
            dgvSoItems.DataSource = new SalesOrderDataManager().GetDataItemsFromDb(NumeroSO).ToList();
            Items = new SalesOrderDataManager().GetDataItemsFromDb(NumeroSO).ToList();
        }
        private bool AsignaClienteT7()
        {
            var listT7 = new CustomerManager().GetShipToListFromBillTo(IdClienteT6);

            if (listT7.Count == 0)
            {
                MessageBox.Show(
                    @"No existen direcciones de entrega activa para el cliente seleccionado. - CL2 Editar -- Activar",
                    @"Error en Direccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (listT7.Count > 1)
            {
                using (var f0 = new FrmCustomerShipToSelection(IdClienteT6))
                {
                    DialogResult dr = f0.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        IdCliente7 = f0.SelectedCustomer;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(
                            @"Se ha cancelado la seleccion de SHIPTO" + Environment.NewLine + @"No se puede continuar",
                            @"Seleccion de SHIPTO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                }
            }
            else
            {
                IdCliente7 = listT7[0].ID_CLI_ENTREGA;
                return true;
            }
        }
        private void LoadCustomerData()
        {
            var data6 = new CustomerManager().GetCustomerBillToData(IdClienteT6);
            txtClienteRazonSocial.Text = data6.cli_rsocial;
            txtid6.Text = IdClienteT6.ToString();
            txtClienteFantasia.Text = data6.cli_fantasia;

            txtCuit.Text = data6.CUIT;
            txtDireccionFacturacion.Text = data6.DireFactu_Num;
            txtNumeroFacturacion.Text = data6.DireFactu_Num;
            txtProvinciaFacturacion.Text = data6.Direfactu_Provincia;
            txtPartidoFacturacion.Text = data6.Direfactu_Partido;
            txtLocalidadFacturacion.Text = data6.Direfactu_Localidad;
            txtCodigoPostalFacturacion.Text = data6.ZIP;
            txtZonaFacturacion.Text = data6.Direfactu_Zona;
            //
            txtZtermL1.Text = data6.ZTERML1;
            txtZTermL2.Text = data6.ZTERML2;

            if (data6.AllowL1 == null)
                data6.AllowL1 = false;


            if (data6.AllowL2 == null)
                data6.AllowL2 = false;


            if (data6.AllowL5 == null)
                data6.AllowL5 = false;
            
            ckL1.Checked = data6.AllowL1.Value;
            ckL2.Checked = data6.AllowL2.Value;
            ckL5.Checked = data6.AllowL5.Value;

            ckLimiteCreditoAuto.Checked = data6.AutoCreditLimit;
            txtLimiteCreditoAutoDays.Text = 0.ToString(); //luego lo modifico
            if (data6.AutoCreditLimit)
            {
                txtLimiteCreditoAutoDays.Text = data6.AutoCreditLimitDays.ToString();
                if (data6.Limite_credito != null)
                {
                    txtLimiteCreditoManual.Text = data6.Limite_credito.Value.ToString("C2");
                    MessageBox.Show(@"Atencion politica de Credito Superpuesta", @"Aviso Limite Credito Superpuesto");
                }
            }
            else
            {
                txtLimiteCreditoManual.Text = @"N/A";
                if (data6.Limite_credito == null)
                {
                    txtLimiteCreditoManual.Text = 0.ToString("C2");
                    MessageBox.Show(@"Notifique que el Cliente no tiene seteada una politica de credito",
                        @"Aviso datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    txtLimiteCreditoManual.Text = data6.Limite_credito.Value.ToString("C2");
                }
            }
            
            semPedidoAutorizado.SetLights = data6.BLK_PEDIDO ? CtlSemaforo.ColoresSemaforo.Rojo : CtlSemaforo.ColoresSemaforo.Verde;
            semDespachoAutorizado.SetLights = data6.BLK_DELIVERY ? CtlSemaforo.ColoresSemaforo.Rojo : CtlSemaforo.ColoresSemaforo.Verde;
            
            ckClienteActivo.BackColor = ckClienteActivo.Checked ? Color.LimeGreen : Color.OrangeRed;



            txtid7.Text = IdCliente7.ToString();
            var limiteCredito = data6.Limite_credito == null ? 0 : Convert.ToDecimal(data6.Limite_credito);
            txtLimiteCreditoManual.Text = limiteCredito.ToString("C2");
            //
            var data7 = new CustomerManager().GetCustomerShipToData(IdCliente7);
            if (data7 == null)
                return;
            ckDireccionEntregaActiva.Checked = data7.Activo;
            ckDireccionEntregaActiva.BackColor = ckDireccionEntregaActiva.Checked ? Color.LimeGreen : Color.OrangeRed;
            if (ckDireccionEntregaActiva.Checked)
            {
                semDireccionEntregaActiva.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
            }
            else
            {
                semDireccionEntregaActiva.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
            }
            txtClienteEntrega.Text = data7.ClienteEntregaDesc;
            txtDireccionEntrega.Text = data7.Direccion_Entrega;
            txtLocalidadEntrega.Text = data7.DireEntre_Localidad;
            txtProvinciaEntrega.Text = data7.DireEntre_Provincia;
            txtZipEntrega.Text = data7.ZIP;
            txtZonaEntrega.Text = data7.DireEntre_Zona;
            if (data7.Vendedor == null)
            {
                MessageBox.Show(@"Atencion los datos del Vendedor no esta completo", @"Datos no Completos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                cmbVendedor.SelectedValue = data7.Vendedor;
            }
            //
            var ctacte = new CtaCteCustomer(IdClienteT6);
            var saldoL1 = ctacte.GetResultadoCtaCte("L1").SaldoResumen;
            var saldoL2 = ctacte.GetResultadoCtaCte("L2").SaldoResumen;
            var deudaTotal = saldoL1 + saldoL2;
            txtDeudaTotal.Text =deudaTotal.ToString("C2");
            
            var creditManager = new CustomerCreditLimiteManager();
            txtAutoCreditLimitValue.Text = CustomerCreditLimiteManager
                .GetAutoCreditLimit(IdClienteT6, Convert.ToInt32(txtLimiteCreditoAutoDays.Text)).ToString("C2");
            if (deudaTotal > CustomerCreditLimiteManager.GetCreditLimit(IdClienteT6))
            {
                //redLimite.Visible = true;
                txtSituacionCrediticia.Text = @"Excede Limite";
                semCredito.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                MessageBox.Show(
                    @"Atencion el Cliente Excede Limite de Credito Asignado. Requiere Autorizacion para Iniciar Proceso",
                    @"Excede Limite", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txtSituacionCrediticia.Text = @"Normal";
                semCredito.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                //greenLimite.Visible = true;
            }
            GetCRMData();
        }

        private void GetCRMData()
        {
            txtCrmInfo.Text =new CRMMensajeInterno().GetMensajeInterno(IdClienteT6);
            var GescoHeader = new Gesco().GetHeader(IdClienteT6);
            ckGescoLlamarPago.Value = GescoHeader.RequestCall;
            ckGescoConciliarCuenta.Value = GescoHeader.RequestConciliation;
        }

        private void LoadDataChequeRechazado()
        {
            var chR = new ChequeRechazadoManager();
            var numChSinEntregar = chR.CantidadChequesSinEntregarCliente(IdClienteT6);
            if (numChSinEntregar == 0)
            {
                semRechSinEntregar.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
            }
            else
            {
                semRechSinEntregar.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                MessageBox.Show($@"El Cliente posee {numChSinEntregar} Cheque/s Sin Entregar",
                    @"Cheques Rechazados S/E", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var saldosChr = chR.SaldoChequeRechazadoSinLevantar(IdClienteT6);
            semRechSinLevantar.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
            if (saldosChr.SaldoChSinNotaDebito > 0)
            {
                MessageBox.Show($@"El Cliente posee cheques rechazados sin la generacion de la NOTA DE DEBITO!",
                    @"Cheques Rechazados S/ND", MessageBoxButtons.OK, MessageBoxIcon.Information);
                semRechSinLevantar.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
            }

            if (saldosChr.SaldoChEntregado > 0)
            {
                MessageBox.Show($@"El Cliente posee saldo de cheque rechazado impago {saldosChr.SaldoChEntregado}",
                    @"Cheques Rechazados S/ND - PEDIR AUTORIZACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                semRechSinLevantar.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
            }
            else
            {
                semRechSinLevantar.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
            }


        }

        private void btnAgregarMaterial_Click(object sender, EventArgs e)
        {
            if (NumeroSO == 0)
            {
                GeneraNumeroSalesOrder();
                if (NumeroSO == 0)
                {
                    MessageBox.Show(@"No se ha podido inicializar la Sales Order debido a algun error interno",
                        @"Error en Inicializacion de Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            new FixPreciosSalesOrder().FixPrecios();
            if (Modo <= 2)
            {
                var f0 = new FrmSD03SoDetalleItem(this, Items.Count + 1, 1);
                f0.ShowDialog();
                BtnEmitirSO.Enabled = true;
            }
            else
            {
                MessageBox.Show(@"Esta funcionalidad no se encuentra disponible en este MODO",
                    @"Funcionalidad no disponible", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void GeneraNumeroSalesOrder()
        {
            NumeroSO = new SalesOrderDataManager().InicializaSalesOrderDb(IdCliente7, StatusSO.ToString());
            if (NumeroSO > 0)
            {
                txtSalesOrderNumero.Text = NumeroSO.ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvSoItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;
            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var idItem =
                Convert.ToInt32(
                    dgvSoItems[dgvSoItems.Columns["iDITEMDataGridViewTextBoxColumn"].Index, e.RowIndex].Value);

            switch (senderGrid.CurrentCell.Value.ToString())
            {
                case "DETALLE":
                    var modo = Modo == 1 ? 2 : Modo;
                    var f0 = new FrmSD03SoDetalleItem(this, idItem, modo);
                    f0.ShowDialog();
                    break;

                case "Edit":

                    break;

                default:
                    MessageBox.Show(@"Este boton no se encuentra manejado", @"Aplicacion en desarrollo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnVerCliente_Click(object sender, EventArgs e)
        {
            using (var f = new FrmMdc02BillTo(3, IdClienteT6, "MDC"))
            {
                f.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modo < 3)
            {
                var x = MessageBox.Show(
                    @"Atencion: Si se ha modificado items sin emitir, los mismos nos seran guardados" +
                    Environment.NewLine + @"Confirma la Salida?", @"Confirme Salida", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (x == DialogResult.No)
                    return;
            }
            this.Close();
        }

        private void cmbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVendedor.SelectedIndex == -1)
                return;

            if (cmbVendedor.SelectedValue != null)
            {
                var d = (T0085_PERSONAL) cmbVendedor.SelectedItem;
                txtVendedorName.Text = d.NOMBRE + " " + d.APELLIDO;
            }
        }

        private void cmbVendedor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedValue == null && combo.Text != string.Empty)
                e.Cancel = true;
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            if (NumeroSO == 0)
            {
                GeneraNumeroSalesOrder();
                if (NumeroSO == 0)
                {
                    MessageBox.Show(@"No se ha podido inicializar la Sales Order debido a algun error interno",
                        @"Error en Inicializacion de Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            new FixPreciosSalesOrder().FixPrecios();
            if (Modo <= 2)
            {
                using (var f0 = new FrmSD03SoDetalleItem(this, Items.Count + 1, 1))
                {
                    f0.ShowDialog();
                }
                BtnCancelarSO.Enabled = true;
            }
            else
            {
                MessageBox.Show(@"No es posible agregar Items en Visualizacion de SO",
                    @"Accion No Permitida", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnVerGesco_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"pendiente de construccion.- notifique a AM");
        }

        private void btnGrabarGescoData_Click(object sender, EventArgs e)
        {
            new CRMMensajeInterno().SetMensajeInterno(IdClienteT6, txtCrmInfo.Text, true);
            MessageBox.Show(@"Los Valores se han Actualizado Correctamente!", @"Actualizacion GESCO",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnModificaLimiteCredito_Click(object sender, EventArgs e)
        {

        }

        private void btnAdministracionBloqueos_Click(object sender, EventArgs e)
        {

        }

        private void BtnEmitirSO_Click(object sender, EventArgs e)
        {
            if (Items.Count == 0)
            {
                MessageBox.Show(@"Atencion.- No Existen Items para Emitir!", @"Error al Emitir", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            
            if (txtEstadoSO.Text == SalesOrderStatusManager.StatusHeader.Inicial.ToString())
            {
                //Emision de Header
                var respuesta = MessageBox.Show(@"Confirma la creacion de Sales Order?", @"Creacion de Orden de Venta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.No)
                    return;

                new SalesOrderDataManager().EmiteSalesOrderHeader(NumeroSO, dtpFechaSO.Value,
                    txtComentarioSalesOrder.Text,
                    cmbVendedor.Text, txtNumeroOC.Text, cmbMetodoIngreso.Text);
                txtEstadoSO.Text = SalesOrderStatusManager.StatusHeader.Emitida.ToString();
            }
            
            new SalesOrderDataManager().EmiteSalesOrderItems(NumeroSO);
            MessageBox.Show(@"Se ha EMITIDO correctamente la Orden de Venta (Sales Order", @"Emision de Sales Order",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvSoItems.DataSource = new SalesOrderDataManager().GetDataItemsFromDb(NumeroSO).ToList();
        }

        private void BtnCancelarOrdenVenta_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(@"Confirma la cancelacion de esta orden de venta?",
                @"Cancelacion de Orden de Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            if (SalesOrderStatusManager.SetStatusSalesOrderCancelado(NumeroSO))
            {
                MessageBox.Show(@"Se ha cancelado la Orden de Venta", @"Cancelacion de Sales Order",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtEstadoSO.Text = SalesOrderStatusManager.StatusHeader.Cancelada.ToString();
                StatusSO = SalesOrderStatusManager.StatusHeader.Cancelada;
            }
        }
    }
}
