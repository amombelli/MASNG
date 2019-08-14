using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MASngFE.Transactional.FI.Orden_de_Pago;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.OrdenPago;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI
{
    public partial class FrmFI34BusquedaCheques : Form
    {
        public FrmFI34BusquedaCheques()
        {
            InitializeComponent();
        }

        public FrmFI34BusquedaCheques(string lx, string modo)
        {
            InitializeComponent();
            _lx = lx;
            _modo = modo;
        }

        public FrmFI34BusquedaCheques(string lx, string modo, int id)
        {
            InitializeComponent();
            _lx = lx;
            _modo = modo;
            _id = id;
        }

        public FrmFI34BusquedaCheques(FrmFI31OPMainScreen frm, string lx, string modo, int id)
        {
            InitializeComponent();
            _lx = lx;
            _modo = modo;
            _id = id;
            _f = frm;
        }

        //-------------------------------------------------------------------------------------------------------------
        private string _lx;
        private readonly string _modo; //OP
        private readonly int _id; //numero de OP...
        private List<T0154_CHEQUES> _listaCheques = new List<T0154_CHEQUES>();
        private readonly FrmFI31OPMainScreen _f;
        //-------------------------------------------------------------------------------------------------------------


        private void FrmBusquedaCheques_Load(object sender, EventArgs e)
        {
            switch (_modo)
            {
                case "OP":
                    //OP modo para agregar cheques a una orden de pago
                    btnAdd.Enabled = true;
                    if (_lx == "L1")
                    {
                        ckL1.Checked = true;
                        ckL2.Checked = false;
                    }
                    else
                    {
                        ckL1.Checked = false;
                        ckL2.Checked = true;
                    }
                    ConfiguraDgvCheques();
                    ckVerDisponible.Checked = true;
                    ckVerNoDisponible.Checked = false;
                    ckNoInterior.Checked = true;
                    ckInterior.Checked = true;
                    
                    int idChequeSelect = -1;
                    if (!string.IsNullOrEmpty(txtId.Text))
                    {
                        idChequeSelect = Convert.ToInt32(txtId.Text);
                    }

                    DateTime? fechaMaxAcred = null;
                    if (!string.IsNullOrEmpty(txtDiasAcredMax.Text))
                    {
                        fechaMaxAcred = DateTime.Today.AddDays(Convert.ToInt32(txtDiasAcredMax.Text));
                    }

                    dgvListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada(_lx,
                        ckVerDisponible.Checked, ckVerNoDisponible.Checked, txtNumber.Text, idChequeSelect,
                        fechaMaxAcred, ckInterior.Checked, ckNoInterior.Checked);

                    break;
                default:

                    MessageBox.Show(@"Situacion no manejada aun", @"Sin implementar", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    break;
            }
        }

        private void ConfiguraDgvCheques()
        {
            dgvListaCheques.AutoGenerateColumns = false;
            dgvListaCheques.ColumnHeadersVisible = true;
            dgvListaCheques.AllowUserToResizeColumns = false;
            dgvListaCheques.AllowUserToAddRows = false;
            dgvListaCheques.AllowUserToDeleteRows = false;
            dgvListaCheques.RowHeadersWidth = 25;
            dgvListaCheques.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            var ckbox = new DataGridViewCheckBoxColumn
            {
                Name = "DISPO",
                DataPropertyName = "DISPONIBLE",
                ReadOnly = true,
                Width = 50
            };

            var ckInterior = new DataGridViewCheckBoxColumn
            {
                Name = "INTE",
                DataPropertyName = "INTERIOR",
                ReadOnly = true,
                Width = 50
            };


            var columna = new DataGridViewTextBoxColumn[9];

            for (var i = 0; i < 9; i++)
            {
                columna[i] = new DataGridViewTextBoxColumn();
            }

            columna[0].Name = "IDCH";
            columna[0].DataPropertyName = "IDCHEQUE";
            columna[0].ReadOnly = true;
            //
            columna[1].Name = "IMPORTE";
            columna[1].DataPropertyName = "IMPORTE";
            columna[1].ReadOnly = true;
            columna[1].DefaultCellStyle.Format = "$0.00##";

            //
            columna[2].Name = "BANCO";
            columna[2].DataPropertyName = "BANCO";
            columna[2].ReadOnly = true;
            columna[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //
            columna[3].Name = "# CHE";
            columna[3].DataPropertyName = "NUMERO";
            columna[3].ReadOnly = true;
            //
            columna[4].Name = "FECHA ACRED";
            columna[4].DataPropertyName = "FECHA_ACREDITACION";
            columna[4].ReadOnly = true;
            //
            columna[5].Name = "LX";
            columna[5].DataPropertyName = "TIPO";
            columna[5].ReadOnly = true;
            columna[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //
            columna[6].Name = "COMENTARIO";
            columna[6].DataPropertyName = "COMENTARIO";
            columna[6].ReadOnly = true;
            //
            columna[7].Name = "CLIENTE";
            columna[7].DataPropertyName = "CLIENTE";
            columna[7].ReadOnly = true;
            columna[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //
            columna[8].Name = "RECIBIDO";
            columna[8].DataPropertyName = "FECHA_RECIBIDO";
            columna[8].ReadOnly = true;
            //

            for (var i = 0; i < 9; i++)
            {
                dgvListaCheques.Columns.Add(columna[i]);
            }

            dgvListaCheques.Columns[0].Width = 50; //ID CHEQUE
            dgvListaCheques.Columns[1].Width = 60; //IMPORTE
            dgvListaCheques.Columns[2].Width = 100; //BANCO
            dgvListaCheques.Columns[3].Width = 50; //# CHEQUE
            dgvListaCheques.Columns[4].Width = 75; //FECHA ACRED
            dgvListaCheques.Columns[5].Width = 25; //TIPO 
            dgvListaCheques.Columns[6].Width = 80; //COMENTARIO
            dgvListaCheques.Columns[7].Width = 80; //CLIENTE
            dgvListaCheques.Columns[8].Width = 75; //Fecha Recibido


            dgvListaCheques.Columns.Add(ckbox);
            dgvListaCheques.Columns.Add(ckInterior);

            var buttonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "btnAddCheque",
                Text = "Agregar",
                Width = 65,
                UseColumnTextForButtonValue = true
            };

            dgvListaCheques.Columns.Add(buttonColumn);
        }

        private void AplicaFiltros()
        {
            int idChequeSelect = -1;
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                idChequeSelect = Convert.ToInt32(txtId.Text);
            }

            DateTime? fechaMaxAcred = null;
            if (!string.IsNullOrEmpty(txtDiasAcredMax.Text))
            {
                fechaMaxAcred = DateTime.Today.AddDays(Convert.ToInt32(txtDiasAcredMax.Text));
            }

            dgvListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada(_lx,
                ckVerDisponible.Checked, ckVerNoDisponible.Checked, txtNumber.Text, idChequeSelect,
                fechaMaxAcred, ckInterior.Checked, ckNoInterior.Checked);
        }

        private void ckL1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckL1.Checked == ckL2.Checked)
            {
                _lx = "L5";
            }
            else
            {
                if (ckL1.Checked == true)
                {
                    _lx = "L1";
                }
                else
                {
                    _lx = "L2";
                }
            }
            AplicaFiltros();
        }
        private void ckL2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckL1.Checked == ckL2.Checked)
            {
                _lx = "L5";
            }
            else
            {
                if (ckL1.Checked == true)
                {
                    _lx = "L1";
                }
                else
                {
                    _lx = "L2";
                }
            }
            AplicaFiltros();
        }
        private void ckVerDisponible_CheckedChanged(object sender, EventArgs e)
        {
           AplicaFiltros();
        }
        private void ckVerNoDisponible_CheckedChanged(object sender, EventArgs e)
        {
           AplicaFiltros();
        }
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            txtId.Text = null;
            int idChequeSelect = -1;
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                idChequeSelect = Convert.ToInt32(txtId.Text);
            }

            DateTime? fechaMaxAcred = null;
            if (!string.IsNullOrEmpty(txtDiasAcredMax.Text))
            {
                fechaMaxAcred = DateTime.Today.AddDays(Convert.ToInt32(txtDiasAcredMax.Text));
            }

            dgvListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada(_lx,
                ckVerDisponible.Checked, ckVerNoDisponible.Checked, txtNumber.Text, idChequeSelect,
                fechaMaxAcred, ckInterior.Checked, ckNoInterior.Checked);
        }
        private void txtId_TextChanged(object sender, EventArgs e)
        {
            txtNumber.Text = null;
            AplicaFiltros();
        }
        private void dgvListaCheques_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;
            var valor = Convert.ToDecimal(dgvListaCheques[1, e.RowIndex].Value);
            var idCheque = Convert.ToInt32(dgvListaCheques[0, e.RowIndex].Value);
            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            {
                switch (e.ColumnIndex)
                {
                    case 11: //Boton Agregar Cheque
                        switch (_modo)
                        {
                            case "OP":
                                //Boton Agregar Cheque a Orden de Pago
                                if (!new ChequesManager().GetIfDisponible(idCheque))
                                {
                                    MessageBox.Show(@"El Cheque seleccionado ya no está disponible",
                                        @"Cheque no Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                DialogResult dialogResult =
                                    MessageBox.Show($"Confirma agregar cheque por importe ${valor}",
                                        @"Confirmacion", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    AddChequeAOrdenPago(valor,idCheque);
                                }
                                else
                                {
                                    //No confirmo agregado de cheques a OP
                                }

                                break;

                            default:
                                MessageBox.Show(@"Modo no manejada aun", @"Sin Implementar", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                break;
                        }

                        break;

                    default:
                        MessageBox.Show(@"Situacion no manejada aun", @"Sin Implementar", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddChequeAOrdenPago(decimal importe, int idCheque)
        {
            new OrdenPagoManageDatos(_id).AddItemPago("CHE", importe, idCheque);
            new OPImputaFacturas(_id).ImputaFacturasOP();
            new ChequesManager().UtilizaChequeEnOrdenPago(idCheque, _id);
            _f.RefreshDgvItemsdePago();
            _f.RecalculaTotalesOP();
            _f.RefreshDgvFacturasEnOP();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"!");
        }

        private void CopyAlltoClipboard()
        {
            dgvListaCheques.SelectAll();
            DataObject dataObj = dgvListaCheques.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            CopyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application(); 
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range cr = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            cr.Select();
            xlWorkSheet.PasteSpecial(cr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void CkNoInterior_CheckedChanged(object sender, EventArgs e)
        {
            AplicaFiltros();
        }

        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender,e);
        }

        private void TxtDiasAcredMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender,e);
        }

        private void TxtDiasAcredMax_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiasAcredMax.Text))
            {
                //
            }
            else
            {
                if (Convert.ToDecimal(txtDiasAcredMax.Text) > 365)
                {
                    MessageBox.Show(@"Dias Maximos de Acreditacion no pueden superar los 365 dias");
                    e.Cancel = true;
                }
            }
        }

        private void CkInterior_CheckedChanged(object sender, EventArgs e)
        {
            AplicaFiltros();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
