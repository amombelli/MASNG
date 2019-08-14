namespace MASngFE.Transactional.FI.GestionCheques
{
    partial class FrmRechazarCheque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.cmbCuentaOrigen = new System.Windows.Forms.ComboBox();
            this.t0150CUENTASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtGL = new System.Windows.Forms.TextBox();
            this.dgvListaCheques = new System.Windows.Forms.DataGridView();
            this.iDCHEQUEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHE_FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mONEDADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHENUMERODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHEBANCODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLIENTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHRECHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMENTARIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idClienteRecibidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaTxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0154CHEQUESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNumeroAsiento = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpFechaRechazo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGastos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMotivoRechazo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdCheque = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpFechaRecibido = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtClienteRazonSocial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtidCliente = new System.Windows.Forms.TextBox();
            this.dtpFechaCheque = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.txtImporteCh = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFilterChNum = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0154CHEQUESBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(979, 106);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(89, 38);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Location = new System.Drawing.Point(463, 19);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(89, 38);
            this.btnRechazar.TabIndex = 6;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // cmbCuentaOrigen
            // 
            this.cmbCuentaOrigen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCuentaOrigen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCuentaOrigen.DataSource = this.t0150CUENTASBindingSource;
            this.cmbCuentaOrigen.DisplayMember = "ID_CUENTA";
            this.cmbCuentaOrigen.FormattingEnabled = true;
            this.cmbCuentaOrigen.Location = new System.Drawing.Point(114, 6);
            this.cmbCuentaOrigen.Name = "cmbCuentaOrigen";
            this.cmbCuentaOrigen.Size = new System.Drawing.Size(235, 23);
            this.cmbCuentaOrigen.TabIndex = 0;
            this.cmbCuentaOrigen.ValueMember = "ID_CUENTA";
            this.cmbCuentaOrigen.SelectedIndexChanged += new System.EventHandler(this.cmbCuentaOrigen_SelectedIndexChanged);
            // 
            // t0150CUENTASBindingSource
            // 
            this.t0150CUENTASBindingSource.DataSource = typeof(TecserEF.Entity.T0150_CUENTAS);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cuenta Cheque";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.txtGL);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbCuentaOrigen);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 37);
            this.panel1.TabIndex = 4;
            // 
            // txtGL
            // 
            this.txtGL.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtGL.ForeColor = System.Drawing.Color.Navy;
            this.txtGL.Location = new System.Drawing.Point(353, 7);
            this.txtGL.Name = "txtGL";
            this.txtGL.ReadOnly = true;
            this.txtGL.Size = new System.Drawing.Size(79, 21);
            this.txtGL.TabIndex = 15;
            // 
            // dgvListaCheques
            // 
            this.dgvListaCheques.AllowUserToAddRows = false;
            this.dgvListaCheques.AllowUserToDeleteRows = false;
            this.dgvListaCheques.AutoGenerateColumns = false;
            this.dgvListaCheques.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvListaCheques.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvListaCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaCheques.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCHEQUEDataGridViewTextBoxColumn,
            this.CHE_FECHA,
            this.mONEDADataGridViewTextBoxColumn,
            this.iMPORTEDataGridViewTextBoxColumn,
            this.cHENUMERODataGridViewTextBoxColumn,
            this.cHEBANCODataGridViewTextBoxColumn,
            this.cLIENTEDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.cHRECHDataGridViewTextBoxColumn,
            this.cOMENTARIODataGridViewTextBoxColumn,
            this.idClienteRecibidoDataGridViewTextBoxColumn,
            this.cuentaTxDataGridViewTextBoxColumn});
            this.dgvListaCheques.DataSource = this.t0154CHEQUESBindingSource;
            this.dgvListaCheques.GridColor = System.Drawing.Color.Black;
            this.dgvListaCheques.Location = new System.Drawing.Point(12, 106);
            this.dgvListaCheques.MultiSelect = false;
            this.dgvListaCheques.Name = "dgvListaCheques";
            this.dgvListaCheques.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaCheques.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvListaCheques.RowHeadersWidth = 20;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaCheques.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvListaCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaCheques.Size = new System.Drawing.Size(944, 412);
            this.dgvListaCheques.TabIndex = 1;
            this.dgvListaCheques.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaCheques_CellEnter);
            // 
            // iDCHEQUEDataGridViewTextBoxColumn
            // 
            this.iDCHEQUEDataGridViewTextBoxColumn.DataPropertyName = "IDCHEQUE";
            this.iDCHEQUEDataGridViewTextBoxColumn.HeaderText = "IDCHE";
            this.iDCHEQUEDataGridViewTextBoxColumn.Name = "iDCHEQUEDataGridViewTextBoxColumn";
            this.iDCHEQUEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCHEQUEDataGridViewTextBoxColumn.Width = 60;
            // 
            // CHE_FECHA
            // 
            this.CHE_FECHA.DataPropertyName = "CHE_FECHA";
            this.CHE_FECHA.HeaderText = "Fecha Ac";
            this.CHE_FECHA.Name = "CHE_FECHA";
            this.CHE_FECHA.ReadOnly = true;
            this.CHE_FECHA.Width = 90;
            // 
            // mONEDADataGridViewTextBoxColumn
            // 
            this.mONEDADataGridViewTextBoxColumn.DataPropertyName = "MONEDA";
            this.mONEDADataGridViewTextBoxColumn.HeaderText = "MON";
            this.mONEDADataGridViewTextBoxColumn.Name = "mONEDADataGridViewTextBoxColumn";
            this.mONEDADataGridViewTextBoxColumn.ReadOnly = true;
            this.mONEDADataGridViewTextBoxColumn.Width = 50;
            // 
            // iMPORTEDataGridViewTextBoxColumn
            // 
            this.iMPORTEDataGridViewTextBoxColumn.DataPropertyName = "IMPORTE";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.Format = "C2";
            this.iMPORTEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.iMPORTEDataGridViewTextBoxColumn.HeaderText = "IMPORTE";
            this.iMPORTEDataGridViewTextBoxColumn.Name = "iMPORTEDataGridViewTextBoxColumn";
            this.iMPORTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iMPORTEDataGridViewTextBoxColumn.Width = 90;
            // 
            // cHENUMERODataGridViewTextBoxColumn
            // 
            this.cHENUMERODataGridViewTextBoxColumn.DataPropertyName = "CHE_NUMERO";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cHENUMERODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.cHENUMERODataGridViewTextBoxColumn.HeaderText = "Ch NUM";
            this.cHENUMERODataGridViewTextBoxColumn.Name = "cHENUMERODataGridViewTextBoxColumn";
            this.cHENUMERODataGridViewTextBoxColumn.ReadOnly = true;
            this.cHENUMERODataGridViewTextBoxColumn.Width = 80;
            // 
            // cHEBANCODataGridViewTextBoxColumn
            // 
            this.cHEBANCODataGridViewTextBoxColumn.DataPropertyName = "CHE_BANCO";
            this.cHEBANCODataGridViewTextBoxColumn.HeaderText = "Bco";
            this.cHEBANCODataGridViewTextBoxColumn.Name = "cHEBANCODataGridViewTextBoxColumn";
            this.cHEBANCODataGridViewTextBoxColumn.ReadOnly = true;
            this.cHEBANCODataGridViewTextBoxColumn.Width = 50;
            // 
            // cLIENTEDataGridViewTextBoxColumn
            // 
            this.cLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CLIENTE";
            this.cLIENTEDataGridViewTextBoxColumn.HeaderText = "CLIENTE";
            this.cLIENTEDataGridViewTextBoxColumn.Name = "cLIENTEDataGridViewTextBoxColumn";
            this.cLIENTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cLIENTEDataGridViewTextBoxColumn.Width = 160;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "TIPO";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 50;
            // 
            // cHRECHDataGridViewTextBoxColumn
            // 
            this.cHRECHDataGridViewTextBoxColumn.DataPropertyName = "CH_RECH";
            this.cHRECHDataGridViewTextBoxColumn.HeaderText = "Rech";
            this.cHRECHDataGridViewTextBoxColumn.Name = "cHRECHDataGridViewTextBoxColumn";
            this.cHRECHDataGridViewTextBoxColumn.ReadOnly = true;
            this.cHRECHDataGridViewTextBoxColumn.Width = 50;
            // 
            // cOMENTARIODataGridViewTextBoxColumn
            // 
            this.cOMENTARIODataGridViewTextBoxColumn.DataPropertyName = "COMENTARIO";
            this.cOMENTARIODataGridViewTextBoxColumn.HeaderText = "COMENTARIO";
            this.cOMENTARIODataGridViewTextBoxColumn.Name = "cOMENTARIODataGridViewTextBoxColumn";
            this.cOMENTARIODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idClienteRecibidoDataGridViewTextBoxColumn
            // 
            this.idClienteRecibidoDataGridViewTextBoxColumn.DataPropertyName = "IdClienteRecibido";
            this.idClienteRecibidoDataGridViewTextBoxColumn.HeaderText = "IDCLI";
            this.idClienteRecibidoDataGridViewTextBoxColumn.Name = "idClienteRecibidoDataGridViewTextBoxColumn";
            this.idClienteRecibidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idClienteRecibidoDataGridViewTextBoxColumn.Width = 60;
            // 
            // cuentaTxDataGridViewTextBoxColumn
            // 
            this.cuentaTxDataGridViewTextBoxColumn.DataPropertyName = "CuentaTx";
            this.cuentaTxDataGridViewTextBoxColumn.HeaderText = "CuentaTx";
            this.cuentaTxDataGridViewTextBoxColumn.Name = "cuentaTxDataGridViewTextBoxColumn";
            this.cuentaTxDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuentaTxDataGridViewTextBoxColumn.Width = 80;
            // 
            // t0154CHEQUESBindingSource
            // 
            this.t0154CHEQUESBindingSource.DataSource = typeof(TecserEF.Entity.T0154_CHEQUES);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MistyRose;
            this.panel2.Controls.Add(this.txtNumeroAsiento);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.dtpFechaRechazo);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtGastos);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnRechazar);
            this.panel2.Controls.Add(this.txtIva);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtMotivoRechazo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtImporte);
            this.panel2.Location = new System.Drawing.Point(388, 539);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 147);
            this.panel2.TabIndex = 6;
            // 
            // txtNumeroAsiento
            // 
            this.txtNumeroAsiento.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtNumeroAsiento.Location = new System.Drawing.Point(452, 101);
            this.txtNumeroAsiento.Name = "txtNumeroAsiento";
            this.txtNumeroAsiento.Size = new System.Drawing.Size(100, 21);
            this.txtNumeroAsiento.TabIndex = 12;
            this.txtNumeroAsiento.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(300, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 15);
            this.label14.TabIndex = 13;
            this.label14.Text = "Numero Asiento Rechazo";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpFechaRechazo
            // 
            this.dtpFechaRechazo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRechazo.Location = new System.Drawing.Point(113, 5);
            this.dtpFechaRechazo.Name = "dtpFechaRechazo";
            this.dtpFechaRechazo.Size = new System.Drawing.Size(115, 21);
            this.dtpFechaRechazo.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Motivo Rechazo";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtGastos
            // 
            this.txtGastos.BackColor = System.Drawing.SystemColors.Info;
            this.txtGastos.Location = new System.Drawing.Point(113, 81);
            this.txtGastos.Name = "txtGastos";
            this.txtGastos.Size = new System.Drawing.Size(100, 21);
            this.txtGastos.TabIndex = 4;
            this.txtGastos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIva_KeyPress);
            this.txtGastos.Leave += new System.EventHandler(this.txtGastos_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gastos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha Rechazo";
            // 
            // txtIva
            // 
            this.txtIva.BackColor = System.Drawing.SystemColors.Info;
            this.txtIva.Location = new System.Drawing.Point(113, 104);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(100, 21);
            this.txtIva.TabIndex = 5;
            this.txtIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIva_KeyPress);
            this.txtIva.Leave += new System.EventHandler(this.txtGastos_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Importe Cheque";
            // 
            // txtMotivoRechazo
            // 
            this.txtMotivoRechazo.Location = new System.Drawing.Point(113, 28);
            this.txtMotivoRechazo.Name = "txtMotivoRechazo";
            this.txtMotivoRechazo.Size = new System.Drawing.Size(243, 21);
            this.txtMotivoRechazo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "IVA Gastos";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtImporte
            // 
            this.txtImporte.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtImporte.ForeColor = System.Drawing.Color.Navy;
            this.txtImporte.Location = new System.Drawing.Point(113, 58);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ReadOnly = true;
            this.txtImporte.Size = new System.Drawing.Size(100, 21);
            this.txtImporte.TabIndex = 0;
            this.txtImporte.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "IDCH";
            // 
            // txtIdCheque
            // 
            this.txtIdCheque.Location = new System.Drawing.Point(293, 5);
            this.txtIdCheque.Name = "txtIdCheque";
            this.txtIdCheque.ReadOnly = true;
            this.txtIdCheque.Size = new System.Drawing.Size(63, 21);
            this.txtIdCheque.TabIndex = 8;
            this.txtIdCheque.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.dtpFechaRecibido);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtClienteRazonSocial);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtidCliente);
            this.panel3.Controls.Add(this.dtpFechaCheque);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtIdCheque);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtBanco);
            this.panel3.Controls.Add(this.txtImporteCh);
            this.panel3.Location = new System.Drawing.Point(12, 539);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(370, 147);
            this.panel3.TabIndex = 12;
            // 
            // dtpFechaRecibido
            // 
            this.dtpFechaRecibido.Enabled = false;
            this.dtpFechaRecibido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRecibido.Location = new System.Drawing.Point(114, 116);
            this.dtpFechaRecibido.Name = "dtpFechaRecibido";
            this.dtpFechaRecibido.Size = new System.Drawing.Size(114, 21);
            this.dtpFechaRecibido.TabIndex = 15;
            this.dtpFechaRecibido.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 15);
            this.label12.TabIndex = 16;
            this.label12.Text = "Recibido fecha:";
            // 
            // txtClienteRazonSocial
            // 
            this.txtClienteRazonSocial.ForeColor = System.Drawing.Color.Navy;
            this.txtClienteRazonSocial.Location = new System.Drawing.Point(165, 93);
            this.txtClienteRazonSocial.Name = "txtClienteRazonSocial";
            this.txtClienteRazonSocial.ReadOnly = true;
            this.txtClienteRazonSocial.Size = new System.Drawing.Size(191, 21);
            this.txtClienteRazonSocial.TabIndex = 14;
            this.txtClienteRazonSocial.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "Recibido Por:";
            // 
            // txtidCliente
            // 
            this.txtidCliente.ForeColor = System.Drawing.Color.Navy;
            this.txtidCliente.Location = new System.Drawing.Point(114, 93);
            this.txtidCliente.Name = "txtidCliente";
            this.txtidCliente.ReadOnly = true;
            this.txtidCliente.Size = new System.Drawing.Size(48, 21);
            this.txtidCliente.TabIndex = 12;
            this.txtidCliente.TabStop = false;
            // 
            // dtpFechaCheque
            // 
            this.dtpFechaCheque.Enabled = false;
            this.dtpFechaCheque.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCheque.Location = new System.Drawing.Point(113, 5);
            this.dtpFechaCheque.Name = "dtpFechaCheque";
            this.dtpFechaCheque.Size = new System.Drawing.Size(115, 21);
            this.dtpFechaCheque.TabIndex = 7;
            this.dtpFechaCheque.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "Banco";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "Fecha Cheque";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "Importe Cheque";
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(113, 28);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.ReadOnly = true;
            this.txtBanco.Size = new System.Drawing.Size(243, 21);
            this.txtBanco.TabIndex = 10;
            this.txtBanco.TabStop = false;
            // 
            // txtImporteCh
            // 
            this.txtImporteCh.ForeColor = System.Drawing.Color.Navy;
            this.txtImporteCh.Location = new System.Drawing.Point(113, 51);
            this.txtImporteCh.Name = "txtImporteCh";
            this.txtImporteCh.ReadOnly = true;
            this.txtImporteCh.Size = new System.Drawing.Size(100, 21);
            this.txtImporteCh.TabIndex = 0;
            this.txtImporteCh.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Gainsboro;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(12, 521);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(188, 15);
            this.label13.TabIndex = 13;
            this.label13.Text = "Datos Cheque Seleccionado";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.btnLimpiar);
            this.panel4.Controls.Add(this.btnBuscar);
            this.panel4.Controls.Add(this.txtFilterChNum);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Location = new System.Drawing.Point(12, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(452, 37);
            this.panel4.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 15);
            this.label15.TabIndex = 2;
            this.label15.Text = "Numero Cheque";
            // 
            // txtFilterChNum
            // 
            this.txtFilterChNum.BackColor = System.Drawing.SystemColors.Control;
            this.txtFilterChNum.ForeColor = System.Drawing.Color.Navy;
            this.txtFilterChNum.Location = new System.Drawing.Point(114, 6);
            this.txtFilterChNum.Name = "txtFilterChNum";
            this.txtFilterChNum.Size = new System.Drawing.Size(79, 21);
            this.txtFilterChNum.TabIndex = 16;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnBuscar.Location = new System.Drawing.Point(212, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnLimpiar.Location = new System.Drawing.Point(289, 5);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmRechazarCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1076, 868);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvListaCheques);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmRechazarCheque";
            this.Text = "FI18 - Rechazo de Cheques x Cuenta Bancos [CHR]";
            this.Load += new System.EventHandler(this.FrmRechazarCheque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0154CHEQUESBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCuentaOrigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvListaCheques;
        private System.Windows.Forms.BindingSource t0154CHEQUESBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGastos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdCheque;
        private System.Windows.Forms.BindingSource t0150CUENTASBindingSource;
        private System.Windows.Forms.DateTimePicker dtpFechaRechazo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMotivoRechazo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpFechaRecibido;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtClienteRazonSocial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtidCliente;
        private System.Windows.Forms.DateTimePicker dtpFechaCheque;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.TextBox txtImporteCh;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCHEQUEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHE_FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn mONEDADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHENUMERODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHEBANCODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLIENTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHRECHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMENTARIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClienteRecibidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaTxDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtGL;
        private System.Windows.Forms.TextBox txtNumeroAsiento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtFilterChNum;
        private System.Windows.Forms.Label label15;
    }
}