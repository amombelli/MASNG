using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.MainDocumentData;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFI40AjusteSaldoCliente : Form
    {
        public FrmFI40AjusteSaldoCliente(int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------
        private readonly int _idCliente;
        private string _lx = null;
#pragma warning disable CS0414 // The field 'FrmFI40AjusteSaldoCliente._tdoc' is assigned but its value is never used
        private string _tdoc = null;
#pragma warning restore CS0414 // The field 'FrmFI40AjusteSaldoCliente._tdoc' is assigned but its value is never used
        //------------------------------------------------------------------------------------------------

        private void FrmFI40AjusteSaldoCliente_Load(object sender, EventArgs e)
        {
            DefaultValues();
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            var cli = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtFanta.Text = cli.cli_fantasia;
            txtRS.Text = cli.cli_rsocial;
            txtId6.Text = _idCliente.ToString();
            var ctacte = new CtaCteCustomer(_idCliente);
            txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            //
            grpTipoAjuste1.Enabled = true;
            grpTipoDocumento2.Enabled = false;
            grpTipoLXDocumento.Visible = false;
            grpTipoLxDocumentoOri.Visible = false;
            grpTipoDocumentoLxDest.Visible = false;
            //

        }

        private void DefaultValues()
        {
            
        }

        private void rbL2_CheckedChanged(object sender, EventArgs e)
        {
            _lx = rbL1.Checked ? "L1" : "L2";
            if (_lx == "L1")
            {
                txtNuevoSaldoCliOrigen.Text =
                    (FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text) -
                     FormatAndConversions.CCurrencyADecimal(txtImporteTraspaso.Text)).ToString("C2");
            }
            else
            {
                txtNuevoSaldoCliOrigen.Text =
                   (FormatAndConversions.CCurrencyADecimal(txtSaldoL2.Text) -
                    FormatAndConversions.CCurrencyADecimal(txtImporteTraspaso.Text)).ToString("C2");
            }
        }

        private void rbAjusteP_CheckedChanged(object sender, EventArgs e)
        {
            cmbClienteDestino.SelectedIndex = -1;
            txtIdCliO.Text = null;
            cmbClienteDestino.Enabled = false;
            txtIdCliDest.Text = null;
            txtClienteOrigienRs.Text = null;
            var rb = (RadioButton) sender;



            //if (_lx == null)
            //{
            //    MessageBox.Show(@"Debe Seleccionar Primaro Tipo de Documento L1 o L2", @"Seleccion Incompleta",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    rb.Checked = false;
            //    return;
            //}
            grpTipoLXDocumento.Visible = true;
            rbL1.Checked = false;
            rbL2.Checked = false;
            grpTipoLxDocumentoOri.Visible = false;
            grpTipoDocumentoLxDest.Visible = false;
            //rbL1Dest.Checked = false;
            //rbL2Dest.Checked = false;
            //rbL1Ori.Checked = false;
            //rbL2Ori.Checked = false;
            if (rbAjusteP.Checked)
            {
                //Ajuste Positivo
            }
            else
            {
                if (rbAjusteN.Checked)
                {
                    //Ajuste Negativo
                }
                else
                {
                    //Traspaso de Saldo
                    t0006MCLIENTESBindingSource.DataSource = new CustomerManager().GetCompleteListofBillTo();
                    cmbClienteDestino.Enabled = true;
                    cmbClienteDestino.SelectedIndex = -1;
                    txtIdCliO.Text = _idCliente.ToString();
                    txtIdCliDest.Text = null;
                    txtClienteOrigienRs.Text = txtRS.Text;
                }
            }
        }

        private void cmbClienteDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClienteDestino.SelectedIndex == -1)
            {
                txtNuevoSaldoCliDestino.Text = 0.ToString("C2");
                txtNuevoSaldoCliOrigen.Text = 0.ToString("C2");
                return;
            }
            txtIdCliDest.Text = cmbClienteDestino.SelectedValue.ToString();
            var ctacte = new CtaCteCustomer(Convert.ToInt32(cmbClienteDestino.SelectedValue));
            if (_lx == "L1")
            {
                txtNuevoSaldoCliOrigen.Text = txtSaldoL1.Text;
                txtNuevoSaldoCliDestino.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            }
            else
            {
                txtNuevoSaldoCliOrigen.Text = txtSaldoL2.Text;
                txtNuevoSaldoCliDestino.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            }
                return;



        }

        private void btnConfirmarTraspaso_Click(object sender, EventArgs e)
        {
            if (_lx == null)
            {
                MessageBox.Show($"Debe Seleccionar Tipo L1 o L2", @"Error en Tipoo de Documento",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cmbClienteDestino.SelectedIndex ==-1)
            {
                MessageBox.Show($"Debe Seleccionar un Cliente Destino", @"Error en Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var importe = FormatAndConversions.CCurrencyADecimal(txtImporteTraspaso.Text);
            if (importe == 0)
            {
                MessageBox.Show($"El Importe a traspasar no puede ser {importe.ToString("C2")}", @"Error en Importe",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtMotivoTraspaso.Text))
            {
                MessageBox.Show($"Debe proveer un motivo/explicacion del traspaso", @"Error en Descripcion",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtTC.Text))
                txtTC.Text = 44.ToString("N2");

            new TraspasoSaldoCliente().GeneraDocumentoTraspasoADiferenteCliente(_lx,Convert.ToInt32(txtIdCliO.Text),Convert.ToInt32(txtIdCliDest.Text),dtpFechaDoc.Value,Convert.ToDecimal(txtTC.Text),importe,txtMotivoTraspaso.Text,"ARS");

            MessageBox.Show(@"Se han Creado los documentos de ajuste correspondientes", @"Creacion de Documentos",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnConfirmarTraspaso.Enabled = false;

        }

        private void txtImporteTraspaso_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtImporteTraspaso.Text))
                txtImporteTraspaso.Text = 0.ToString("C2");

            decimal importeT = FormatAndConversions.CCurrencyADecimal(txtImporteTraspaso.Text);
            txtImporteTraspaso.Text = importeT.ToString("C2");
            if (importeT == 0)
            {
                toolTip1.ToolTipTitle = "Error en Importe";
                toolTip1.Show("El Importe a Traspasar no puede ser igual a $0.00",txtImporteTraspaso,txtImporteTraspaso.Location,5000);
                var ctacte = new CtaCteCustomer(Convert.ToInt32(cmbClienteDestino.SelectedValue));
                if (_lx == "L1")
                {
                    txtNuevoSaldoCliOrigen.Text = txtSaldoL1.Text;
                    txtNuevoSaldoCliDestino.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
                }
                else
                {
                    txtNuevoSaldoCliOrigen.Text = txtSaldoL2.Text;
                    txtNuevoSaldoCliDestino.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
                }
                btnConfirmarTraspaso.Enabled = false;
                e.Cancel = true;
            }
            else
            {
                txtNuevoSaldoCliOrigen.Text =
                    (FormatAndConversions.CCurrencyADecimal(txtNuevoSaldoCliOrigen.Text) - importeT)
                        .ToString("C2");

                txtNuevoSaldoCliDestino.Text =
                    (FormatAndConversions.CCurrencyADecimal(txtNuevoSaldoCliDestino.Text) + importeT)
                        .ToString("C2");
                btnConfirmarTraspaso.Enabled = true;
            }
        }

        private void txtImporteTraspaso_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender,e);
        }

        private void rbAjusteMismoTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAjusteMismoTipo.Checked)
            {
                grpTipoDocumento2.Enabled = true;
            }
            else
            {
                //Ajuste diferente tipo LxA a LxB
                grpTipoDocumento2.Enabled = false;
                grpTipoLxDocumentoOri.Visible = true;
                grpTipoDocumentoLxDest.Visible = true;
                rbAjusteN.Checked = false;
                rbAjusteP.Checked = false;
                rbTraspasoSaldo.Checked = false;
            }
        }



        private void rbL1Ori_CheckedChanged(object sender, EventArgs e)
        {
            grpTipoDocumentoLxDest.Visible = true;
            if (rbL1Ori.Checked)
            {
                rbL2Dest.Checked = true;
            }
            else
            {
                rbL1Dest.Checked = true;
            }
        }
    }
}
