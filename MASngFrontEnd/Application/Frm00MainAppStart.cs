using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Forms;
using MASngFE.Forms.VendorSearchBase;
using MASngFE.MasterData;
using MASngFE.MasterData.BOM;
using MASngFE.MasterData.Customer_Master;
using MASngFE.Reports.ReportManager;
using MASngFE.Transactional.CO;
using MASngFE.Transactional.CO.Cost;
using MASngFE.Transactional.CO.GL;
using MASngFE.Transactional.CRM;
using MASngFE.Transactional.FI.Cobranza;
using MASngFE.Transactional.FI.CustomerNCD;
using MASngFE.Transactional.FI.Factura;
using MASngFE.Transactional.FI.FondoFijo;
using MASngFE.Transactional.FI.GestionCheques;
using MASngFE.Transactional.FI.Vendor.SinRemito;
using MASngFE.Transactional.FI.VendorNCD;
using MASngFE.Transactional.FI.VendorPRM;
using MASngFE.Transactional.HR;
using MASngFE.Transactional.MM.MRP;
using MASngFE.Transactional.MM.Orden_de_Compra;
using MASngFE.Transactional.MM.Requisicin;
using MASngFE.Transactional.QM;
using MASngFE.Transactional.SD.Hoja_de_Ruta;
using MASngFE.Transactional.SD.Remito;
using MASngFE.Transactional.SD.SalesOrder;
using Tecser.Business.DataFix;
using Tecser.Business.MainApp;
using Tecser.Business.Network;
using Tecser.Business.Security;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.MainDocumentData.Vendor;
using TecserEF.Entity;

namespace MASngFE.Application
{
    public partial class Frm00MainAppStart : Form
    {
        public Frm00MainAppStart()
        {
            InitializeComponent();
        }
        
        private void btnTcode_Click(object sender, EventArgs e)
        {
            GlobalApp.Tcode = txtTcode.Text.ToUpper().Truncate(20);
            SecurityLog.LogTransactionIn(GlobalApp.Tcode);  //Loguea transaccion ingresada.-
            RunTransaction();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            GlobalApp.Tcode = "MAIN";
            stbarTcode.Text = GlobalApp.Tcode;
            stbarUsername.Text = GlobalApp.AppUsername +@" [" + Environment.UserName +"] ";
            stbarComputer.Text = @" Computer: " + Environment.MachineName + @" IP: " + IpAddress.GetIpV4Address(Environment.MachineName);
            stbarAppVersion.Text = @"App Version: " + GlobalApp.AppVersion;
            stbarModo.Text = @"INDEFINIDO";
            
            switch (GlobalApp.Modo)
            {
                case Tecser.Business.MainApp.ModoApp.Produccion:
                    stbarModo.Text = @"PRODUCCION";
                    MessageBox.Show(@"Atencion: Esta ingresando al Sistema de Gestion MAS.NG en Modo Productivo", @"ENTORNO PRODUCTIVO PR1", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case Tecser.Business.MainApp.ModoApp.Desarrollo:
                    stbarModo.Text = @"DESARROLLO";
                    stbarModo.ForeColor = Color.Red;
                    break;
                case Tecser.Business.MainApp.ModoApp.Testeo:
                    stbarModo.Text = @"TESTEO";
                    stbarModo.ForeColor = Color.Yellow;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
        private void RunTransaction()
        {
            var xTcode = new TcodeManager();
            var response = xTcode.ValidateTransactionBeforeRun(GlobalApp.Tcode);

            //Si es FORM tiene que hacer la validacion del namespace en este assembly-
            //Obtengo el tipo en el FrontEnd y lo mando para la clase de Business
            if (response != TcodeManager.TcodeResponse.TxInvalida)
            {
                if (xTcode.TipoTransaccion() == "FORM")
                {
                    var myType = Type.GetType(xTcode.GetFormPath());
                    xTcode.SetType(myType);
                    if (myType == null)
                    {
                        response = TcodeManager.TcodeResponse.ErrorConfig;
                    }
                }
            }

            switch (response)
            {
                case TcodeManager.TcodeResponse.TxInvalida:
                    MessageBox.Show(@"El Nombre de la Transaccion es invalido", @"Error en Transaccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stbarTcode.Text = @"TX*INVALID";
                    break;
                case TcodeManager.TcodeResponse.SinPermisos:
                    MessageBox.Show(@"El Usuario no tiene permisos suficientes para ejecutar esta transaccion", @"Error en Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    stbarTcode.Text = @"NOTAUTHORIZED";
                    break;
                case TcodeManager.TcodeResponse.ErrorConfig:
                    MessageBox.Show(@"Error 3. -Transaccion no manejada debido a error en Config de Path", @"Error en Config", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    stbarTcode.Text = @"TX*OUTOFSERVICE";
                    break;
                case TcodeManager.TcodeResponse.TxOK:

                    if (xTcode.TipoTransaccion() == "FORM")
                    {
                        var f = xTcode.LunchFormOpen();
                        stbarTcode.Text = GlobalApp.Tcode;
                        f.Show();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void btnRemisionCliente_Click(object sender, EventArgs e)
        {
            var f = new FrmSD06SeleccionRemisionCliente();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new FrmCentroPreparacionRemitos();
            f.Show();
        }

        private void btnChangeCobraznaType_Click(object sender, EventArgs e)
        {
            var f = new FrmFI47ChangeCobranzaType();
            f.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void txtTcode_Enter(object sender, EventArgs e)
        {
            if (GlobalApp.Modo == Tecser.Business.MainApp.ModoApp.Produccion)
            {
                var result = IpAddress.GetPingStatus("192.168.0.210");
                txtServiceStatus.Text = result.Status.ToString() + @"  >>" + result.RoundtripTime;
                if (result.RoundtripTime > 50)
                {
                    txtServiceStatus.BackColor = Color.Red;
                }
                else if (result.RoundtripTime > 35)
                {
                    txtServiceStatus.BackColor = Color.Yellow;
                }
                else
                {
                    txtServiceStatus.BackColor = Color.Green;
                }
            }
        }

        private void btnCentroEntregas_Click(object sender, EventArgs e)
        {
            var f0 = new FrmCentroPreparacionHojaRuta();
            f0.Show();
        }
        
        private void tcode2_Click(object sender, EventArgs e)
        {
        }


        private void button24_Click(object sender, EventArgs e)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("FACT3", "FACTUSEARCH", true, true))
            {
                return;
            }
            var f0 = new FrmCustomerDocumentSearch();
            f0.Show();
        }


        private void button13_Click_1(object sender, EventArgs e)
        {
            var x = new CobranzaUtils().FixCobranzaDiasPp();
            MessageBox.Show($"Se actualizaron {x} registros");
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            new Email2().SendEmail();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            var x = new ImputacionCobranzas().ImputaCobranzaAutomatica(12571, ModoImputacion.Completa);
        }



    

        private void button23_Click_1(object sender, EventArgs e)
        {
            //Wave2 --> Nos fijamos si es una NCD!
            var start = DateTime.Now;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataInicial = db.T0207_SPLITFACTURAS.Where(c => c.TipoDocCancel == null && c.MONTO_APLICADO != 0 && c.XCK == "No Coincide datos Cobranza").OrderByDescending(c => c.INTDOC).Take(2000);
                foreach (var i in dataInicial)
                {
                    int n;
                    bool isNumeric = int.TryParse(i.NRECIBO, out n);
                    if (isNumeric)
                    {
                        var posibleNc = Convert.ToInt32(i.NRECIBO);
                        var nc = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == posibleNc);
                        if (nc == null)
                        {
                            i.XCK = "NoEsCobranza_w2!";
                        }
                        else
                        {
                            if (i.CLIENTE == nc.CLINUM.Value && i.TIPO == nc.TIPO)
                            {
                                i.USDImpu = nc.TC;
                                i.TipoDocCancel = "NC";
                                if (i.PFECHA == null)
                                {
                                    i.DiasImpu = (nc.FECHA.Value - i.FECHA_FACT.Value).Days;
                                }
                                else
                                {
                                    i.DiasImpu = (i.FECHA_FACT.Value - i.FECHA_FACT.Value).Days;
                                }

                                i.DiasPPCob = null;
                                i.IDCOB = null;
                                i.IDNC = posibleNc;
                                i.NumeroDoc = nc.NDOC;
                                i.XCK = "Wave2OK";
                            }
                            else
                            {
                                i.XCK = "No Coincide datos NC W2";
                            }
                        }
                    }
                    else
                    {
                        i.XCK = "NoNumerico";
                    }
                }
                var recsaved = db.SaveChanges();
                var finish = DateTime.Now;
                MessageBox.Show($"Finalizado = {(finish - start).Seconds} Segundos ##{recsaved} Records!");
            }
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            //Wave3 --> Nos fijamos si comienza con NC
            var start = DateTime.Now;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataInicial = db.T0207_SPLITFACTURAS.Where(c => c.TipoDocCancel == null && c.MONTO_APLICADO != 0 && c.XCK == "NoNumerico").OrderByDescending(c => c.INTDOC).Take(2000);
                foreach (var i in dataInicial)
                {
                    if (string.IsNullOrEmpty(i.NRECIBO))
                    {
                        i.XCK = "ImputadoVacio";
                    }
                    else
                    {
                        var data = i.NRECIBO.Substring(2);
                        int n;
                        bool isNumeric = int.TryParse(data, out n);
                        if (isNumeric)
                        {
                            var posibleNc = Convert.ToInt32(data);
                            var nc = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == posibleNc);
                            if (nc == null)
                            {
                                i.XCK = "NoEsCobranza_w3!";
                            }
                            else
                            {
                                if (i.CLIENTE == nc.CLINUM.Value && i.TIPO == nc.TIPO)
                                {
                                    i.USDImpu = nc.TC;
                                    i.TipoDocCancel = "NC";
                                    if (i.PFECHA == null)
                                    {
                                        i.DiasImpu = (nc.FECHA.Value - i.FECHA_FACT.Value).Days;
                                    }
                                    else
                                    {
                                        i.DiasImpu = (i.FECHA_FACT.Value - i.FECHA_FACT.Value).Days;
                                    }
                                    i.DiasPPCob = null;
                                    i.IDCOB = null;
                                    i.IDNC = posibleNc;
                                    i.NumeroDoc = nc.NDOC;
                                    i.XCK = "Wave3OK";
                                }
                                else
                                {
                                    i.XCK = "No Coincide datos NC w3";
                                }
                            }
                        }
                        else
                        {
                            i.XCK = "NoNumerico";
                        }
                    }
                }
                var recsaved = db.SaveChanges();
                var finish = DateTime.Now;
                MessageBox.Show($"Finalizado = {(finish - start).Seconds} Segundos ##{recsaved} Records!");
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            var f0 = new FrmFI80VendorNcdScreen1(1);
            f0.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            var f0 = new FrmImputacionFF();
            f0.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            var fx = new FrmFondoFijoConversion();
            fx.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("COBT", "COBITMP", true, true))
            {
                return;
            }

            var f = new FrmFI42CobranzaTemporal();
            f.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var f = new FrmFI43ConversionCobranzas();
            f.Show();
        }


        private void btnDevelopmentForm_Click(object sender, EventArgs e)
        {
            var f = new FrmDevelopmentForm();
            f.Show();
        }


        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void aboutApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"MOMBELLI APPLICATION SYSTEM NEXT-GENERATION", @"APP", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void MICustomerCreation_Click(object sender, EventArgs e)
        {
            GlobalApp.Tcode = "CL1";
            RunTransaction();
        }

        private void stbarModo_Click(object sender, EventArgs e)
        {
        }
        private void FrmMainAppStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            var resp = MessageBox.Show(@"Confirma el cierre de MASNg V2",
                @"Confirmacion de Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var y = new FrmFI40AjusteSaldoCliente(6);
            y.Show();
            //var x = new FrmPP30CalculoBOM(4799);
            //x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = new FrmVendorSearchBase();

            //var x = new FrmTestUserControl();
            x.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var f0  = new Form1();
            f0.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var f = new FrmForm1();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var x = new FrmApp13CheckWebServicesConfig();
            x.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var f = new FrmFI78ImportacionComprobantesAFIP();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var f = new FrmArba02();
            f.Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            var f = new FrmFI50VendorPRMMain();
            f.Show();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            var f = new FrmQm04IpList();
            f.Show();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            var f = new FrmQm21AddRegistroInspeccion();
            f.Show();

            var f2 = new FrmQm30QmListaMainH1();
            f2.Show();
        }

        private void BtnMRPTest_Click(object sender, EventArgs e)
        {
            var f = new FrmMRP02();
            f.Show();
        }

        private void BtnCODET_Click(object sender, EventArgs e)
        {

        }

        private void BtnCROLL_Click(object sender, EventArgs e)
        {

        }

        private void Button12_Click(object sender, EventArgs e)
        {
            new FrmCO02_Reposicion().Show();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            new FrmCO03_Manufactura().Show();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            new FrmCO07CostoStandard().Show();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            new FrmMDB05SearchByMP().Show();
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            new FrmMDB06MassFormActivate().Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
          
        }

        private void button17_Click_1(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            //new FixCompletaIdT400EnTablaCheRechazado();
            var f = new FrmFI53GestionChequeRechazado();
            f.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var f = new FrmFI54GestionEntregaRechazos();
            f.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            new FixCompletaIdT400EnTablaCheRechazado().FixIdCtaCteOldRecordChr();
            new FixCompletaIdT400EnTablaCheRechazado().FixCompletaChequeRechEntregado();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var f = new FrmHR05SYJH();
            f.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var f = new FrmHR07AnticiposLoad();
            f.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            var f = new FrmHR08PagoAdelantos();
            f.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            var f = new FrmFI60ContaCancel();
            f.Show();
        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            var f = new FrmCO30GLS();
            f.Show();
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            var f = new FrmCO20AbmGLAccounts();
            f.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            var f = new FrmMM55RequisicionMain();
            f.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            var f = new FrmMM54RequisicionList();
            f.Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            new FrmFI25RefacturacionDocumento().Show();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            var f = new FrmCRM03GescoMain();
            f.Show();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            var f = new FrmCRM02GescoSelect();
            f.Show();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            //new GescoMigrateOldData().FixMigrateDate();
            //new GescoMigrateOldData().MigraData();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            var f = new FrmCRM06GescoCtaCteEstiloCliente();
            f.Show();
        }

        private void button36_Click_1(object sender, EventArgs e)
        {
            //var q = new FrmSD02SalesOrderMain(0);




            //var w = new ControlsInForm().GetAll(q,typeof(TextBox));

            //new ControlsInForm().GetTextBoxInForm(typeof(FrmSD02SalesOrderMain));
            ////var z = new ControlsInForm().GetAll(FrmSD02SalesOrderMain,TextBox);
            //////var z = new ListOfControls(FrmSD02SalesOrderMain);
            //////GetAll(FrmSD02SalesOrderMain, Text);
            //////var 0 = z.GetAll(FrmSD02SalesOrderMain, TextBox);
            /////
            ///// 
            //var xxxx = new ControlesEnFormularios(q);
            //var p= xxxx.GetListOfControls();

            var f0 = new FrmApp02ControlsInForms();
            f0.Show();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            var f = new FrmCO08_CostManageControlCenter();
            f.Show();
        }
    }
}
