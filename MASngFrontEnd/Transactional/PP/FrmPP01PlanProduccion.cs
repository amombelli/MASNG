using System;
using System.ComponentModel;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using MASngFE.Transactional.MM;
using Tecser.Business.DataFix;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP01PlanProduccion : Form
    {
        public FrmPP01PlanProduccion()
        {
            InitializeComponent();
            _ckStatus = new bool[9] {false, false, false, false, false, false, false, false,false};
        }
        public FrmPP01PlanProduccion(int modo = 0)
        {
            InitializeComponent();
            this.dgvPF.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPF_CellValueChanged);
            _ckStatus = new bool[9] {false, false, false, false, false, false, false, false,false};
        }

        //-------------------------------------------------------------------------------------------------
        private bool[] _ckStatus;


        //-------------------------------------------------------------------------------------------------

        private void MapStatus(bool pendiente, bool formulado, bool planeado, bool proceso, bool cerrado, bool cancelado,
            bool standby, bool error, bool finalizado)
        {
            _ckStatus = new bool[9]
            {
                pendiente, formulado, planeado, proceso, cerrado, cancelado, standby, error, finalizado
            };
        }
        private void RefreshDatagridview()
        {
            var data = new PlanProduccionListManager().GetListPFPorEstado(_ckStatus, top: Convert.ToInt32(txtMaxRecords.Text));
            dgvPF.DataSource = new MySortableBindingList<T0070_PLANPRODUCCION>(data);
        }

        private void FrmPlanProduccion_Load(object sender, EventArgs e)
        {
            //Perfil Planner
            ckPendiente.Checked = true;
            ckFormulado.Checked = true;
            ckPlaneado.Checked = true;
            ckProceso.Checked = true;
            ckStandBy.Checked = true;
            
            MapStatus(ckPendiente.Checked, ckFormulado.Checked, ckPlaneado.Checked, ckProceso.Checked, ckCerrado.Checked,
                ckCancelado.Checked, ckStandBy.Checked, ckError.Checked, ckFinalizado.Checked);

            PFFixAddCustomerInPF.FixCompletaCustomerOV();
            PFFixAddCustomerInPF.FixCompletaTDOC();
            
           RefreshDatagridview();

        }


        //Al Hacer click en Botones del DataGridview
        private void dgvPF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = dgvPF[e.ColumnIndex, e.RowIndex].Value.ToString();

                switch (cellValue)
                {
                    case "ES":
                        var f = new FrmPP10CierreOF(Convert.ToInt32(dgvPF[0, e.RowIndex].Value));
                        f.Show();
                        break;

                    case "PRTN":
                        var f2 = new RpvOrdenFabricacion(Convert.ToInt32(dgvPF[0, e.RowIndex].Value));
                        f2.Show();
                        break;

                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        //Al Hacer DobleClick en Celdas del DataGridview
        private void dgvPF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dgvPF.Columns[e.ColumnIndex].Name;
            var numeroCeldaStatus = dgvPF.Columns["StatusColumn"].Index;
            if (e.RowIndex == -1)
            {
                this.dgvPF.Sort(this.dgvPF.Columns["StatusColumn"], ListSortDirection.Ascending);
            }
            if (e.RowIndex >= 0)
            {
                var statusOrdenFabricacion = PlanProduccionStatusManager.MapStatusOfFromText2(dgvPF[numeroCeldaStatus, e.RowIndex].Value.ToString());
                int idPlan = Convert.ToInt32(dgvPF[0, e.RowIndex].Value);

                switch (cell.ToUpper())
                {
                    case "STATUSCOLUMN":
                        AccionBoton(Convert.ToInt32(dgvPF[0, e.RowIndex].Value), statusOrdenFabricacion);
                        break;
                    case "KGFABRICARDATAGRIDVIEWTEXTBOXCOLUMN":
                        if (statusOrdenFabricacion == PlanProduccionStatusManager.StatusOf.Pendiente ||
                            statusOrdenFabricacion == PlanProduccionStatusManager.StatusOf.StandBy)
                        {
                            using (var form1 = new FrmPP18UpdateKgFabricar(idPlan))
                            {
                                var resx = form1.ShowDialog();
                                if (resx == DialogResult.OK)
                                {
                                    RefreshDatagridview();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(
                                @"Para utilizar esta funcion la orden de fabricacion debe estar en estado Pendiente o StandBy",
                                @"No Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    default:
                        MessageBox.Show(
                            @"Esta Celda no realiza ninguna funcion al hacer doble click. Para planear haga doble click en STATUS",
                            @"Boton no programado aun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }
        private void AccionBoton(int numeroOF, PlanProduccionStatusManager.StatusOf statusOrdenFabricacion)
        {
            var f2 = new FrmPP02PlanificacionOF(numeroOF);
            f2.Show();


            switch (statusOrdenFabricacion)
            {
                case PlanProduccionStatusManager.StatusOf.Pendiente:
                    break;
                case PlanProduccionStatusManager.StatusOf.Formulada:
                    break;
                case PlanProduccionStatusManager.StatusOf.Planeado:
                    break;
                case PlanProduccionStatusManager.StatusOf.Proceso:
                    break;
                case PlanProduccionStatusManager.StatusOf.Cerrada:
                    break;
                case PlanProduccionStatusManager.StatusOf.Cancelada:
                    break;
                case PlanProduccionStatusManager.StatusOf.StandBy:
                    break;
                case PlanProduccionStatusManager.StatusOf.Error:
                    break;
                    case PlanProduccionStatusManager.StatusOf.Finalizada:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("statusOrdenFabricacion", statusOrdenFabricacion, null);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAltaOrdenFabricacion_Click(object sender, EventArgs e)
        {
            using (var form = new FrmPP03AltaOFManual())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    RefreshDatagridview();

                   // T0070Bs.DataSource = new PlanProduccionListManager().GetListPFPorEstado(_ckStatus,top: Convert.ToInt32(txtMaxRecords.Text));
                }
            }
        }

        private void dgvPF_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string observaciones = null;
            if (dgvPF[dgvPF.Columns["obsPlanDataGridViewTextBoxColumn"].Index, e.RowIndex].Value == null)
            {
                observaciones = null;
            }
            else
            {
                observaciones = dgvPF[dgvPF.Columns["obsPlanDataGridViewTextBoxColumn"].Index, e.RowIndex].Value.ToString();
            }
            
            new PlanProduccionManager().UpdateComentarioPF(Convert.ToInt32(dgvPF[0, e.RowIndex].Value), observaciones);
            this.dgvPF.CellValueChanged -=
    new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPF_CellValueChanged);

        }
        private void dgvPF_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPF.SelectedRows.Count != 1)
                return;

            if (e.ColumnIndex < 0)
                return;

            var senderGrid = (DataGridView) sender;

            var cell = dgvPF.Columns[e.ColumnIndex].Name;
            switch (cell)
            {
                case "obsPlanDataGridViewTextBoxColumn":
                    this.dgvPF.CellValueChanged +=
                        new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPF_CellValueChanged);
                    break;
            }
        }
          private void btnExportExcel_Click(object sender, EventArgs e)
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
        private void CopyAlltoClipboard()
        {
            dgvPF.SelectAll();
            DataObject dataObj = dgvPF.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        
        #region Filtros
        //KEYPRESS
        private void txtIdRecurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtMaxRecords_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtNumeroOF_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        //FILTROS
        private void ckPendiente_CheckedChanged(object sender, EventArgs e)
        {
            _ckStatus = new bool[9]
            {
                ckPendiente.Checked, ckFormulado.Checked, ckPlaneado.Checked, ckProceso.Checked, ckCerrado.Checked,
                ckCancelado.Checked, ckStandBy.Checked, ckError.Checked,ckFinalizado.Checked
            };

            var material = txtMaterial.Text;
            var numeroOF = string.IsNullOrEmpty(txtNumeroOF.Text) ? 0 : Convert.ToInt32(txtNumeroOF.Text);
            var idRecurso = string.IsNullOrEmpty(txtIdRecurso.Text) ? 0 : Convert.ToInt32(txtIdRecurso.Text);

            var data = new PlanProduccionListManager().GetListPFPorEstado2(_ckStatus, material, numeroOF,
                Convert.ToInt32(txtMaxRecords.Text), idRecurso);
            dgvPF.DataSource = new MySortableBindingList<T0070_PLANPRODUCCION>(data);
        }
        private void txtIdRecurso_TextChanged(object sender, EventArgs e)
        {
            var material = txtMaterial.Text;
            var numeroOF = string.IsNullOrEmpty(txtNumeroOF.Text) ? 0 : Convert.ToInt32(txtNumeroOF.Text);
            var idRecurso = string.IsNullOrEmpty(txtIdRecurso.Text) ? 0 : Convert.ToInt32(txtIdRecurso.Text);
            var data = new PlanProduccionListManager().GetListPFPorEstado2(_ckStatus, material, numeroOF,
                Convert.ToInt32(txtMaxRecords.Text), idRecurso);
            dgvPF.DataSource = new MySortableBindingList<T0070_PLANPRODUCCION>(data);
        }
        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {
            var material = txtMaterial.Text;
            var numeroOF = string.IsNullOrEmpty(txtNumeroOF.Text) ? 0 : Convert.ToInt32(txtNumeroOF.Text);
            var idRecurso = string.IsNullOrEmpty(txtIdRecurso.Text) ? 0 : Convert.ToInt32(txtIdRecurso.Text);
            var data = new PlanProduccionListManager().GetListPFPorEstado2(_ckStatus, material, numeroOF,
                Convert.ToInt32(txtMaxRecords.Text), idRecurso);
            dgvPF.DataSource = new MySortableBindingList<T0070_PLANPRODUCCION>(data);
        }
        private void txtLote_TextChanged(object sender, EventArgs e)
        {
            var material = txtMaterial.Text;
            var numeroOF = string.IsNullOrEmpty(txtNumeroOF.Text) ? 0 : Convert.ToInt32(txtNumeroOF.Text);
            var idRecurso = string.IsNullOrEmpty(txtIdRecurso.Text) ? 0 : Convert.ToInt32(txtIdRecurso.Text);
            var data = new PlanProduccionListManager().GetListPFPorEstado2(_ckStatus, material, numeroOF,
                Convert.ToInt32(txtMaxRecords.Text), idRecurso);
            dgvPF.DataSource = new MySortableBindingList<T0070_PLANPRODUCCION>(data);
        }
        private void txtMaxRecords_Leave(object sender, EventArgs e)
        {
            var material = txtMaterial.Text;
            var numeroOF = string.IsNullOrEmpty(txtNumeroOF.Text) ? 0 : Convert.ToInt32(txtNumeroOF.Text);
            var idRecurso = string.IsNullOrEmpty(txtIdRecurso.Text) ? 0 : Convert.ToInt32(txtIdRecurso.Text);
            var data = new PlanProduccionListManager().GetListPFPorEstado2(_ckStatus, material, numeroOF,
                Convert.ToInt32(txtMaxRecords.Text), idRecurso);
            dgvPF.DataSource = new MySortableBindingList<T0070_PLANPRODUCCION>(data);
        }

        //--- BOTONES de Filtro
        private void btnNada_Click(object sender, EventArgs e)
        {
            ckPendiente.Checked = false;
            ckFormulado.Checked = false;
            ckPlaneado.Checked = false;
            ckProceso.Checked = false;
            ckCerrado.Checked = false;
            ckCancelado.Checked = false;
            ckStandBy.Checked = false;
            ckError.Checked = false;
            ckFinalizado.Checked = false;

            _ckStatus = new bool[9]
            {
                false, false, false, false, false, false, false, false, false
            };
        }
        private void btnPlannerProfile_Click(object sender, EventArgs e)
        {
            ckCerrado.Checked = false;
            ckCancelado.Checked = false;
            ckError.Checked = false;
            ckFinalizado.Checked = false;

            ckPendiente.Checked = true;
            ckFormulado.Checked = true;
            ckPlaneado.Checked = true;
            ckProceso.Checked = true;
            ckStandBy.Checked = true;

            _ckStatus = new bool[9]
            {
                ckPendiente.Checked, ckFormulado.Checked, ckPlaneado.Checked, ckProceso.Checked, ckCerrado.Checked,
                ckCancelado.Checked, ckStandBy.Checked, ckError.Checked,ckFinalizado.Checked
            };

        }
        private void btnProfile2_Click(object sender, EventArgs e)
        {
            ckPendiente.Checked = false;
            ckFormulado.Checked = false;
            ckPlaneado.Checked = false;
            ckProceso.Checked = false;
            ckCerrado.Checked = true;
            ckCancelado.Checked = false;
            ckStandBy.Checked = false;
            ckError.Checked = false;
            ckFinalizado.Checked = true;

            _ckStatus = new bool[9]
            {
                ckPendiente.Checked, ckFormulado.Checked, ckPlaneado.Checked, ckProceso.Checked, ckCerrado.Checked,
                ckCancelado.Checked, ckStandBy.Checked, ckError.Checked,ckFinalizado.Checked
            };
        }
        private void btnAllProfile_Click(object sender, EventArgs e)
        {
            ckPendiente.Checked = true;
            ckFormulado.Checked = true;
            ckPlaneado.Checked = true;
            ckProceso.Checked = true;
            ckCerrado.Checked = true;
            ckCancelado.Checked = true;
            ckStandBy.Checked = true;
            ckError.Checked = true;
            ckFinalizado.Checked = true;

            _ckStatus = new bool[9]
            {
                true,true,true,true,true,true,true,true,true
            };
        }

        #endregion

        private void btnMM00_Click(object sender, EventArgs e)
        {
            var f0 = new FrmCq();
            f0.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funcionalidad No Implementada Aun");
        }

        private void btnIngresarTemporal_Click(object sender, EventArgs e)
        {
            var f= new FrmPP09IngresoTemporal();
            f.Show();
            this.Close();
        }
    }
}

