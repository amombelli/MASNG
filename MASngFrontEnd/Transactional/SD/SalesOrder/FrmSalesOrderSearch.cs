using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.SD.SalesOrder
{
    public partial class FrmSD01SalesOrderSearch : Form
    {
        public FrmSD01SalesOrderSearch()
        {
            InitializeComponent();
        }

        public FrmSD01SalesOrderSearch(int modo)
        {
            _modo = modo;
            InitializeComponent();
        }

        private readonly int _modo;
        private IEnumerable<DsSalesOrderList> _soList = new List<DsSalesOrderList>();
        private void rbRazon_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = groupBox1.Controls.OfType<RadioButton>()
                          .FirstOrDefault(r => r.Checked);
            //var customer = new Customers();
            switch (checkedButton.Name)
            {
                case "rbFantasia":
                    cmbClienteT6.DisplayMember = "CLI_FANTASIA";
                    break;
                case "rbRazon":
                    cmbClienteT6.DisplayMember = "CLI_RSOCIAL";
                    break;
                default:
                    break;
            }
        }
        private void FrmSalesOrderSearch_Load(object sender, EventArgs e)
        {
            ConfiguraDefaultValues();
        }
        private void UnBindCombobox()
        {
            this.cmbClienteT6.SelectedIndexChanged -= new System.EventHandler(this.cmbClienteT6_SelectedIndexChanged);
        }
        private void BindCombobox()
        {
            this.cmbClienteT6.SelectedIndexChanged += new System.EventHandler(this.cmbClienteT6_SelectedIndexChanged);
        }
        private void ConfiguraDefaultValues()
        {
            UnBindCombobox();
            cmbClienteT6.ValueMember = "IDCLIENTE";
            cmbClienteT6.DisplayMember = "CLI_RSOCIAL";
            cmbClienteT6.DataSource = new CustomerManager().GetCompleteListofBillTo(ckClienteActivo.Checked).ToList();
            cmbClienteT6.Text = "";
           
            txtIDT6.ValueMember = "IDCLIENTE";
            txtIDT6.DisplayMember = "IDCLIENTE";
            txtIDT6.DataSource= new CustomerManager().GetCompleteListofBillTo(ckClienteActivo.Checked).ToList();
            txtIDT6.Text = "";

            txtSalesOrderNumberSearch.Text = null;
            
            //default values
            rbRazon.Checked = true;
            ckClienteActivo.Checked = true;
            dgvListadoSO.DataSource = null;

            btnSalir.Enabled = true;
            btnNuevaSO.Enabled = false;
            btnVerCliente.Enabled = false;
            ckClienteActivo.Enabled = false;
            //dgvListadoSO.Enabled = false;
            //groupBox1.Enabled = false;
            dsSalesOrderListBindingSource.DataSource = _soList;
            dgvListadoSO.DataSource = dsSalesOrderListBindingSource;

            BindCombobox();

            switch (_modo)
            {
                case 1:
                    btnNuevaSO.Enabled = true;
                    btnVerCliente.Enabled = true;

                    break;

                case 2:
                    dgvListadoSO.Enabled = true;
                    break;


                case 3:

                    break;

                default:

                    break;

            }

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbClienteT6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClienteT6.SelectedIndex >= 0)
            {
                txtIDT6.SelectedValue = cmbClienteT6.SelectedValue;
                //dsSalesOrderListBindingSource.DataSource = new DsSalesOrderList().GetByCustomer(Convert.ToInt32(txtIDT6.Text));
                _soList = new DsSalesOrderList().GetByCustomer(Convert.ToInt32(txtIDT6.SelectedValue), GlobalApp.CnnApp);
                dsSalesOrderListBindingSource.DataSource = _soList;
            }
        }
        private void txtIDT6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtIDT6.SelectedIndex > 0)
            {
                cmbClienteT6.SelectedValue = txtIDT6.SelectedValue;
            }
        }
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            cmbClienteT6.Text = null;
            txtSalesOrderNumberSearch.Text = null;
            txtIDT6.Text = null;
            _soList = new DsSalesOrderList().GetAllData(GlobalApp.CnnApp);
            dsSalesOrderListBindingSource.DataSource = _soList;
        }
        private void txtSalesOrderNumberSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender,e);
        }
        private void txtSalesOrderNumberSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSalesOrderNumberSearch.Text))
            {
                dsSalesOrderListBindingSource.DataSource = _soList;
            }
            else
            {
                var salesSearch = Convert.ToInt32(txtSalesOrderNumberSearch.Text);
                dsSalesOrderListBindingSource.DataSource = _soList.Where(c => c.SO == salesSearch).ToList();
            }
                

        }
        private void dgvListadoSO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var idSalesOrder = Convert.ToInt32(dgvListadoSO[dgvListadoSO.Columns[0].Index, e.RowIndex].Value);

            switch (senderGrid.CurrentCell.Value.ToString())
            {
                case "View":
                    var f0 = new FrmSD02SalesOrderMain(3,idSalesOrder);
                    f0.Show();
                    this.Close();
                    break;

                case "Edit":
                    if (_modo == 3)
                    {
                        MessageBox.Show(@"Este modo no está disponible en esta transaccion", @"Modo no disponible",
                            MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    var f1 = new FrmSD02SalesOrderMain(2, idSalesOrder);
                    f1.Show();
                    this.Close();
                    break;
                default:
                    MessageBox.Show(@"Este boton no se encuentra manejado", @"Aplicacion en desarrollo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private void btnNewSalesOrder_Click(object sender, EventArgs e)
        {

           
        }


        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevaSO_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDT6.Text))
            {
                MessageBox.Show(@"Para crear una nueva Sales Order (SO) debe seleccionar el cliente",
                    @"Creacion de nueva Sales Order / Orden de Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var f0 = new FrmSD02SalesOrderMain(Convert.ToInt32(txtIDT6.Text));
            f0.Show();
            this.Close();

        }

        private void cmbClienteT6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbClienteT6);
        }
    }
}
