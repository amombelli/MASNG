using System;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using MASngFE.Transactional.FI.Cobranza;
using Tecser.Business.MasterData;
using Tecser.Business.Security;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.MainDocumentData;

namespace MASngFE.Transactional.FI.Factura
{
    public partial class FrmDetalleDocumentoFI : Form
    {
        public FrmDetalleDocumentoFI(int idFactura, int modo = 0)
        {
            _idFactura = idFactura;
            InitializeComponent();
        }

        private readonly int _idFactura;
        private int _idCliente;
        private ManageDocumentType.TipoDocumento _tipoDocumento;
        private string _tipoLx;
        private DocumentFIStatusManager.StatusHeader _estadoDocumento;

        private void FrmDetalleDocumentoFI_Load(object sender, EventArgs e)
        {
            LoadHeaderData();
        }

        private void LoadHeaderData()
        {
            var h = new CustomerDocumentSearch().GetHeaderData(_idFactura);
            var cli = new CustomerManager().GetCustomerBillToData(h.Cliente.Value);
            ckVerPreciosOV.Checked = true;
            ckVerGLAccount.Checked = false;
            ckFacturaAlter.Checked = false;
            txtRazonSocial.Text = h.RAZONSOC;
            txtFantasia.Text = cli.cli_fantasia;
            _idCliente = cli.IDCLIENTE;
            txtId6.Text = cli.IDCLIENTE.ToString();
            txtNumeroCuit.Text = cli.CUIT;
            txtDireccion.Text = cli.Direccion_facturacion;
            txtLocalidad.Text = cli.Direfactu_Localidad;
            txtProvincia.Text = cli.Direfactu_Provincia;
            txtMon.Text = h.FacturaMoneda;
            txtImporteTotal.Text = h.TotalFacturaN.ToString("c2");
            txtEstado.Text = h.StatusFactura;
            _estadoDocumento = new DocumentFIStatusManager().MapStatusHeaderFromText(h.StatusFactura);
            txtLx.Text = h.TIPOFACT;
            txtTC.Text = h.TC.Value.ToString("N2");
            txtNumeroDocumento.Text = h.NumeroDoc;
            txtNumeroRemito.Text = h.Remito;

            if (h.TC != null || h.TC != 0)
            {
                if (h.FacturaMoneda == "ARS")
                {
                    txtImporteUSD.Text = (h.TotalFacturaB / h.TC.Value).ToString("C2");
                    pRECIOTFACTUSDDataGridViewTextBoxColumn.Visible = false;
                    pRECIOUFACTUSDDataGridViewTextBoxColumn.Visible = false;
                    pRECIOTFACTARSDataGridViewTextBoxColumn.Visible = true;
                    pRECIOUFACTARSDataGridViewTextBoxColumn.Visible = true;
                }
                else
                {
                    txtImporteUSD.Text = h.TotalFacturaN.ToString("C2");
                    pRECIOTFACTUSDDataGridViewTextBoxColumn.Visible = true;
                    pRECIOUFACTUSDDataGridViewTextBoxColumn.Visible = true;
                    pRECIOTFACTARSDataGridViewTextBoxColumn.Visible = false;
                    pRECIOUFACTARSDataGridViewTextBoxColumn.Visible = false;
                }
            }

            dtpFecha.Value = h.FECHA.Value;
            _tipoDocumento = ManageDocumentType.GetTipoDocumentoFromTDoc(h.TIPO_DOC, h.TIPOFACT);
            txtTipoDoc.Text = ManageDocumentType.GetDocumentDescriptionHardCode(_tipoDocumento);
            _tipoLx = h.TIPOFACT;

            if (h.TIPOFACT == "L1")
            {
                ckImprimirSaldoL2.Enabled = false;
            }
            else
            {
                ckImprimirSaldoL2.Enabled = true;
                ckImprimirSaldoL2.Checked = true;
            }

            gLIDataGridViewTextBoxColumn.Visible = false;
            gLVDataGridViewTextBoxColumn.Visible = false;

            t0401FACTURAIBindingSource.DataSource = new CustomerDocumentSearch().GetItemData(_idFactura);
            dgvItems.ClearSelection();

            txtImporteInicial.Text = h.TotalFacturaB.ToString("C2");
            txtImporteDescuento.Text = h.Descuento.Value.ToString("C2");

            if (h.Descuento.Value > 0)
            {
                txtDescuentoPorcentaje.Text = (h.Descuento.Value / h.TotalFacturaB).ToString("P2");
            }

            txtSubtotal.Text = (h.TotalFacturaB - h.Descuento.Value).ToString("C2");
            txtBaseImponible.Text = h.TotalImpo.ToString("C2");
            txtIva21.Text = h.TotalIVA21.ToString("C2");
            txtImporteIIBB.Text = h.TotalIIBB.ToString("C2");
            txtTotalFactura.Text = h.TotalFacturaN.ToString("C2");

            if (h.IIBB_PORC == null)
            {
                txtAlicuotaIIBB.Text = 0.ToString("P2");
            }
            else
            {
                txtAlicuotaIIBB.Text = h.IIBB_PORC.Value.ToString("P2");
            }

            if (h.IdCtaCte == null)
            {
                MessageBox.Show(@"Este Documento no tiene IdCtaCte en T0400!", @"Arreglar");
                return;
            }

            txtCAE.Text = h.CAE;
            if (h.CAE_VTO != null)
                txtCAEVencimiento.Text = h.CAE_VTO.Value.ToString("d");
            txtZterm.Text = h.ZTERM;
            //
            var ctacteData = new ImputacionCobranzas();
            var sinImpu = ctacteData.GetSaldoAImputar208(h.Cliente.Value, h.TIPOFACT);
            var pendPago = ctacteData.GetSaldoPendientePagoDocumento(h.IdCtaCte.Value);
            txtMontoSinImputar.Text = sinImpu.ToString("C2");
            txtSaldoImpago.Text = pendPago.ToString("C2");

            if (sinImpu > 0 && pendPago > 0)
            {
                btnImputar.Enabled = true;
            }
            else
            {
                btnImputar.Enabled = false;
            }


            var info = new CobranzaUtils().GetInfoDiasPPFromTable201(h.IdCtaCte.Value);
            if (info.DiasPP_FacturaRecibo == null || info.DiasPP_ReciboPago == null)
            {
                var diasPP = new CobranzaUtils().DiasPromedioPagoFacturaImputada(h.IdCtaCte.Value);
                txtDiasPPFactura.Text = diasPP.DiasPP_FacturaRecibo.ToString();
                txtDiasPPRecibo.Text = diasPP.DiasPP_ReciboPago.ToString();
                txtDiasPPTotal.Text = (diasPP.DiasPP_FacturaRecibo + diasPP.DiasPP_ReciboPago).ToString();
                new CobranzaUtils().SetInfoDiasPPToTable201(h.IdCtaCte.Value, diasPP.DiasPP_FacturaRecibo,
                    diasPP.DiasPP_ReciboPago);
            }
            else
            {
                txtDiasPPFactura.Text = info.DiasPP_FacturaRecibo.ToString();
                txtDiasPPRecibo.Text = info.DiasPP_ReciboPago.ToString();
                txtDiasPPTotal.Text = (info.DiasPP_FacturaRecibo + info.DiasPP_ReciboPago).ToString();
            }
        }

        private void ckVerGLAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (ckVerGLAccount.Checked)
            {
                gLIDataGridViewTextBoxColumn.Visible = true;
                gLVDataGridViewTextBoxColumn.Visible = true;
            }
            else
            {
                gLIDataGridViewTextBoxColumn.Visible = false;
                gLVDataGridViewTextBoxColumn.Visible = false;
            }
        }

        private void ckVerPreciosOV_CheckedChanged(object sender, EventArgs e)
        {
            if (ckVerPreciosOV.Checked)
            {
                pRECIOUCOTIZDataGridViewTextBoxColumn.Visible = true;
                mONEDACOTIZDataGridViewTextBoxColumn.Visible = true;
            }
            else
            {
                pRECIOUCOTIZDataGridViewTextBoxColumn.Visible = false;
                mONEDACOTIZDataGridViewTextBoxColumn.Visible = false;
            }
        }

        private void ckFacturaAlter_CheckedChanged(object sender, EventArgs e)
        {
            if (ckFacturaAlter.Checked)
            {
                if (txtMon.Text == @"ARS")
                {
                    pRECIOTFACTUSDDataGridViewTextBoxColumn.Visible = true;
                    pRECIOUFACTUSDDataGridViewTextBoxColumn.Visible = true;
                }
                else
                {
                    pRECIOTFACTARSDataGridViewTextBoxColumn.Visible = true;
                    pRECIOUFACTARSDataGridViewTextBoxColumn.Visible = true;
                }
            }
            else
            {
                if (txtMon.Text == @"ARS")
                {
                    pRECIOTFACTUSDDataGridViewTextBoxColumn.Visible = false;
                    pRECIOUFACTUSDDataGridViewTextBoxColumn.Visible = false;
                }
                else
                {
                    pRECIOTFACTARSDataGridViewTextBoxColumn.Visible = false;
                    pRECIOUFACTARSDataGridViewTextBoxColumn.Visible = false;
                }
            }
        }

        private bool CheckAllowToPrint()
        {
            return true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!CheckAllowToPrint())
                return;

            if (txtLx.Text == @"L1")
            {
                if (ckPreimpreso.Checked)
                {
                    var f = new RpvFacturaL1(_idFactura, ckMensajeMora.Checked,
                        txtObservacionesAdicionalesImprimir.Text, ckImpresionConsolidada.Checked);
                    f.Show();
                }
                else
                {
                    var f = new RpvFacturaL1_PDF(_idFactura, ckMensajeMora.Checked,
                        txtObservacionesAdicionalesImprimir.Text, ckImpresionConsolidada.Checked);
                    f.Show();
                }
            }
            else
            {
                var f = new RpvNcdl2(_idFactura, ckImprimirSaldoL2.Checked,
                    ckImpresionConsolidada.Checked);
                f.Show();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImputar_Click(object sender, EventArgs e)
        {
            var f0 = new FrmImputacionCobranzas(_idCliente);
            f0.ShowDialog();
        }

        private void btnVerImputacion_Click(object sender, EventArgs e)
        {
            var f0 = new FrmDetalleImputacionPorFactura(_idFactura);
            f0.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
        }

        private bool ValidaCancelacion()
        {


            if (_estadoDocumento == DocumentFIStatusManager.StatusHeader.Aprobada && _tipoLx == "L1")
            {
                MessageBox.Show(@"El Documento se encuentra con CAE generado. No se puede CANCELAR", @"Accion No Permitida",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_tipoLx == "L1")
            {

            }
            else
            {

            }

            return true;






















































        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!CheckAllowToPrint())
                return;

            if (txtLx.Text == @"L1")
            {
                if (ckPreimpreso.Checked)
                {
                    var f = new RpvFacturaL1(_idFactura, ckMensajeMora.Checked,
                        txtObservacionesAdicionalesImprimir.Text, ckImpresionConsolidada.Checked);
                    f.Show();
                }
                else
                {
                    var f = new RpvFacturaL1_PDF(_idFactura, ckMensajeMora.Checked,
                        txtObservacionesAdicionalesImprimir.Text, ckImpresionConsolidada.Checked);
                    f.Show();
                }
            }
            else
            {
                var f = new RpvNcdl2(_idFactura, ckImprimirSaldoL2.Checked,
                    ckImpresionConsolidada.Checked);
                f.Show();
            }
        }

        private void btnCancelDoc_Click(object sender, EventArgs e)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("FAC2", "CANCELDOC", true, true))
            {
                MessageBox.Show(@"El Usuario no esta habilitado para cancelar un documento", @"Permisos Insuficientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            if (!ValidaCancelacion())
                return;

            var resp = MessageBox.Show(@"Confirma la Cancelacion del Documento?",
                @"Cancelacion de Documentos Contabilizados",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            var resultado=new CustomerInvoice("FAC2",0).CancelaDocumentoFI(_idFactura);
            if (resultado)
                MessageBox.Show(@"Se ha Anulado Correctamente el Documento", @"Anulacion Exitosa", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
    }
}