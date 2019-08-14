namespace MASngFE.Transactional.CO.Cost
{
    partial class FrmCO05SeleccionaFormulaCosteo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCO05SeleccionaFormulaCosteo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFormulaDescription = new System.Windows.Forms.TextBox();
            this.ckSoloFormulasActivas = new System.Windows.Forms.CheckBox();
            this.txtFormulaFCOST = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMonedaCosto = new System.Windows.Forms.ComboBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtTC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMtype = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificarFormulaCosteo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.BoMItemsBs = new System.Windows.Forms.BindingSource(this.components);
            this.BoMHeaderBs = new System.Windows.Forms.BindingSource(this.components);
            this.dgvHeader = new System.Windows.Forms.DataGridView();
            this.iDFORMULADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCFORMULADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fORMVERSIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTIVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lastUsedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logUpdatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.iDITEMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTEMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cANTIDADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cANTIDADPORCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uNIDADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExplosionCompleta = new System.Windows.Forms.Button();
            this.txtCostoARS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCostoUSD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ckRecalculoCosto = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoMItemsBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoMHeaderBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeader)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.txtFormulaDescription);
            this.panel1.Controls.Add(this.ckSoloFormulasActivas);
            this.panel1.Controls.Add(this.txtFormulaFCOST);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbMonedaCosto);
            this.panel1.Controls.Add(this.txtMaterial);
            this.panel1.Controls.Add(this.txtTC);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtOrigen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMtype);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 86);
            this.panel1.TabIndex = 111;
            // 
            // txtFormulaDescription
            // 
            this.txtFormulaDescription.Location = new System.Drawing.Point(122, 54);
            this.txtFormulaDescription.Name = "txtFormulaDescription";
            this.txtFormulaDescription.ReadOnly = true;
            this.txtFormulaDescription.Size = new System.Drawing.Size(294, 21);
            this.txtFormulaDescription.TabIndex = 109;
            // 
            // ckSoloFormulasActivas
            // 
            this.ckSoloFormulasActivas.AutoSize = true;
            this.ckSoloFormulasActivas.Location = new System.Drawing.Point(429, 56);
            this.ckSoloFormulasActivas.Name = "ckSoloFormulasActivas";
            this.ckSoloFormulasActivas.Size = new System.Drawing.Size(175, 19);
            this.ckSoloFormulasActivas.TabIndex = 108;
            this.ckSoloFormulasActivas.Text = "Ver SOLO Formulas Activas";
            this.ckSoloFormulasActivas.UseVisualStyleBackColor = true;
            this.ckSoloFormulasActivas.CheckedChanged += new System.EventHandler(this.CkSoloFormulasActivas_CheckedChanged);
            // 
            // txtFormulaFCOST
            // 
            this.txtFormulaFCOST.Location = new System.Drawing.Point(68, 54);
            this.txtFormulaFCOST.Name = "txtFormulaFCOST";
            this.txtFormulaFCOST.ReadOnly = true;
            this.txtFormulaFCOST.Size = new System.Drawing.Size(53, 21);
            this.txtFormulaFCOST.TabIndex = 107;
            this.txtFormulaFCOST.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 106;
            this.label3.Text = "FCOST";
            // 
            // cmbMonedaCosto
            // 
            this.cmbMonedaCosto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbMonedaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonedaCosto.FormattingEnabled = true;
            this.cmbMonedaCosto.Items.AddRange(new object[] {
            "USD",
            "ARS"});
            this.cmbMonedaCosto.Location = new System.Drawing.Point(351, 32);
            this.cmbMonedaCosto.Name = "cmbMonedaCosto";
            this.cmbMonedaCosto.Size = new System.Drawing.Size(65, 21);
            this.cmbMonedaCosto.TabIndex = 105;
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(68, 9);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(160, 21);
            this.txtMaterial.TabIndex = 104;
            // 
            // txtTC
            // 
            this.txtTC.Location = new System.Drawing.Point(549, 31);
            this.txtTC.Name = "txtTC";
            this.txtTC.Size = new System.Drawing.Size(57, 21);
            this.txtTC.TabIndex = 102;
            this.txtTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(466, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 103;
            this.label6.Text = "Tipo Cambio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 101;
            this.label5.Text = "Moneda Costo";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(68, 31);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.ReadOnly = true;
            this.txtOrigen.Size = new System.Drawing.Size(53, 21);
            this.txtOrigen.TabIndex = 92;
            this.txtOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 91;
            this.label2.Text = "Origen";
            // 
            // txtMtype
            // 
            this.txtMtype.Location = new System.Drawing.Point(549, 9);
            this.txtMtype.Name = "txtMtype";
            this.txtMtype.ReadOnly = true;
            this.txtMtype.Size = new System.Drawing.Size(57, 21);
            this.txtMtype.TabIndex = 90;
            this.txtMtype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(229, 9);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(318, 21);
            this.txtDescripcion.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 87;
            this.label1.Text = "Material";
            // 
            // btnModificarFormulaCosteo
            // 
            this.btnModificarFormulaCosteo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnModificarFormulaCosteo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarFormulaCosteo.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarFormulaCosteo.Image")));
            this.btnModificarFormulaCosteo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarFormulaCosteo.Location = new System.Drawing.Point(625, 44);
            this.btnModificarFormulaCosteo.Name = "btnModificarFormulaCosteo";
            this.btnModificarFormulaCosteo.Size = new System.Drawing.Size(100, 40);
            this.btnModificarFormulaCosteo.TabIndex = 110;
            this.btnModificarFormulaCosteo.Text = "Select\r\nFormula";
            this.btnModificarFormulaCosteo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarFormulaCosteo.UseVisualStyleBackColor = true;
            this.btnModificarFormulaCosteo.Click += new System.EventHandler(this.BtnModificarFormulaCosteo_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(625, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 109;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BoMItemsBs
            // 
            this.BoMItemsBs.DataSource = typeof(TecserEF.Entity.T0021_FORMULA_I);
            // 
            // BoMHeaderBs
            // 
            this.BoMHeaderBs.DataSource = typeof(TecserEF.Entity.T0020_FORMULA_H);
            // 
            // dgvHeader
            // 
            this.dgvHeader.AllowUserToAddRows = false;
            this.dgvHeader.AllowUserToDeleteRows = false;
            this.dgvHeader.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHeader.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDFORMULADataGridViewTextBoxColumn,
            this.dESCFORMULADataGridViewTextBoxColumn,
            this.fORMVERSIONDataGridViewTextBoxColumn,
            this.aCTIVADataGridViewTextBoxColumn,
            this.lastUsedDataGridViewTextBoxColumn,
            this.logUpdatedByDataGridViewTextBoxColumn});
            this.dgvHeader.DataSource = this.BoMHeaderBs;
            this.dgvHeader.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgvHeader.Location = new System.Drawing.Point(7, 5);
            this.dgvHeader.MultiSelect = false;
            this.dgvHeader.Name = "dgvHeader";
            this.dgvHeader.ReadOnly = true;
            this.dgvHeader.RowHeadersWidth = 20;
            this.dgvHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHeader.Size = new System.Drawing.Size(540, 217);
            this.dgvHeader.TabIndex = 112;
            this.dgvHeader.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHeader_CellContentClick);
            // 
            // iDFORMULADataGridViewTextBoxColumn
            // 
            this.iDFORMULADataGridViewTextBoxColumn.DataPropertyName = "ID_FORMULA";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.iDFORMULADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.iDFORMULADataGridViewTextBoxColumn.HeaderText = "FCOST";
            this.iDFORMULADataGridViewTextBoxColumn.Name = "iDFORMULADataGridViewTextBoxColumn";
            this.iDFORMULADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDFORMULADataGridViewTextBoxColumn.Width = 50;
            // 
            // dESCFORMULADataGridViewTextBoxColumn
            // 
            this.dESCFORMULADataGridViewTextBoxColumn.DataPropertyName = "DESC_FORMULA";
            this.dESCFORMULADataGridViewTextBoxColumn.HeaderText = "Descripcion Formula";
            this.dESCFORMULADataGridViewTextBoxColumn.Name = "dESCFORMULADataGridViewTextBoxColumn";
            this.dESCFORMULADataGridViewTextBoxColumn.ReadOnly = true;
            this.dESCFORMULADataGridViewTextBoxColumn.Width = 180;
            // 
            // fORMVERSIONDataGridViewTextBoxColumn
            // 
            this.fORMVERSIONDataGridViewTextBoxColumn.DataPropertyName = "FORM_VERSION";
            this.fORMVERSIONDataGridViewTextBoxColumn.HeaderText = "Ver.";
            this.fORMVERSIONDataGridViewTextBoxColumn.Name = "fORMVERSIONDataGridViewTextBoxColumn";
            this.fORMVERSIONDataGridViewTextBoxColumn.ReadOnly = true;
            this.fORMVERSIONDataGridViewTextBoxColumn.Width = 35;
            // 
            // aCTIVADataGridViewTextBoxColumn
            // 
            this.aCTIVADataGridViewTextBoxColumn.DataPropertyName = "ACTIVA";
            this.aCTIVADataGridViewTextBoxColumn.HeaderText = "Act";
            this.aCTIVADataGridViewTextBoxColumn.Name = "aCTIVADataGridViewTextBoxColumn";
            this.aCTIVADataGridViewTextBoxColumn.ReadOnly = true;
            this.aCTIVADataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aCTIVADataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aCTIVADataGridViewTextBoxColumn.Width = 30;
            // 
            // lastUsedDataGridViewTextBoxColumn
            // 
            this.lastUsedDataGridViewTextBoxColumn.DataPropertyName = "LastUsed";
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.lastUsedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.lastUsedDataGridViewTextBoxColumn.HeaderText = "Ultimo Uso";
            this.lastUsedDataGridViewTextBoxColumn.Name = "lastUsedDataGridViewTextBoxColumn";
            this.lastUsedDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUsedDataGridViewTextBoxColumn.Width = 110;
            // 
            // logUpdatedByDataGridViewTextBoxColumn
            // 
            this.logUpdatedByDataGridViewTextBoxColumn.DataPropertyName = "LogUpdatedBy";
            this.logUpdatedByDataGridViewTextBoxColumn.HeaderText = "LogUpdatedBy";
            this.logUpdatedByDataGridViewTextBoxColumn.Name = "logUpdatedByDataGridViewTextBoxColumn";
            this.logUpdatedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Thistle;
            this.panel2.Controls.Add(this.dgvHeader);
            this.panel2.Location = new System.Drawing.Point(4, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(556, 227);
            this.panel2.TabIndex = 113;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDITEMDataGridViewTextBoxColumn,
            this.iTEMDataGridViewTextBoxColumn,
            this.cANTIDADDataGridViewTextBoxColumn,
            this.cANTIDADPORCDataGridViewTextBoxColumn,
            this.uNIDADDataGridViewTextBoxColumn});
            this.dgvItems.DataSource = this.BoMItemsBs;
            this.dgvItems.GridColor = System.Drawing.Color.DarkBlue;
            this.dgvItems.Location = new System.Drawing.Point(11, 333);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Indigo;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvItems.RowHeadersWidth = 20;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(349, 275);
            this.dgvItems.TabIndex = 112;
            // 
            // iDITEMDataGridViewTextBoxColumn
            // 
            this.iDITEMDataGridViewTextBoxColumn.DataPropertyName = "ID_ITEM";
            this.iDITEMDataGridViewTextBoxColumn.HeaderText = "#";
            this.iDITEMDataGridViewTextBoxColumn.Name = "iDITEMDataGridViewTextBoxColumn";
            this.iDITEMDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDITEMDataGridViewTextBoxColumn.Width = 30;
            // 
            // iTEMDataGridViewTextBoxColumn
            // 
            this.iTEMDataGridViewTextBoxColumn.DataPropertyName = "ITEM";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.iTEMDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.iTEMDataGridViewTextBoxColumn.HeaderText = "Material";
            this.iTEMDataGridViewTextBoxColumn.Name = "iTEMDataGridViewTextBoxColumn";
            this.iTEMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cANTIDADDataGridViewTextBoxColumn
            // 
            this.cANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N3";
            this.cANTIDADDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.cANTIDADDataGridViewTextBoxColumn.HeaderText = "Cant";
            this.cANTIDADDataGridViewTextBoxColumn.Name = "cANTIDADDataGridViewTextBoxColumn";
            this.cANTIDADDataGridViewTextBoxColumn.ReadOnly = true;
            this.cANTIDADDataGridViewTextBoxColumn.Width = 60;
            // 
            // cANTIDADPORCDataGridViewTextBoxColumn
            // 
            this.cANTIDADPORCDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD_PORC";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "P3";
            this.cANTIDADPORCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.cANTIDADPORCDataGridViewTextBoxColumn.HeaderText = "Cant %";
            this.cANTIDADPORCDataGridViewTextBoxColumn.Name = "cANTIDADPORCDataGridViewTextBoxColumn";
            this.cANTIDADPORCDataGridViewTextBoxColumn.ReadOnly = true;
            this.cANTIDADPORCDataGridViewTextBoxColumn.Width = 70;
            // 
            // uNIDADDataGridViewTextBoxColumn
            // 
            this.uNIDADDataGridViewTextBoxColumn.DataPropertyName = "UNIDAD";
            this.uNIDADDataGridViewTextBoxColumn.HeaderText = "UoM";
            this.uNIDADDataGridViewTextBoxColumn.Name = "uNIDADDataGridViewTextBoxColumn";
            this.uNIDADDataGridViewTextBoxColumn.ReadOnly = true;
            this.uNIDADDataGridViewTextBoxColumn.Width = 45;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(4, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(556, 4);
            this.label4.TabIndex = 108;
            // 
            // btnExplosionCompleta
            // 
            this.btnExplosionCompleta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExplosionCompleta.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExplosionCompleta.Image = ((System.Drawing.Image)(resources.GetObject("btnExplosionCompleta.Image")));
            this.btnExplosionCompleta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExplosionCompleta.Location = new System.Drawing.Point(63, 79);
            this.btnExplosionCompleta.Name = "btnExplosionCompleta";
            this.btnExplosionCompleta.Size = new System.Drawing.Size(112, 40);
            this.btnExplosionCompleta.TabIndex = 115;
            this.btnExplosionCompleta.Text = "Explosion\r\nCompleta";
            this.btnExplosionCompleta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExplosionCompleta.UseVisualStyleBackColor = true;
            this.btnExplosionCompleta.Click += new System.EventHandler(this.BtnExplosionCompleta_Click);
            // 
            // txtCostoARS
            // 
            this.txtCostoARS.Location = new System.Drawing.Point(76, 53);
            this.txtCostoARS.Name = "txtCostoARS";
            this.txtCostoARS.ReadOnly = true;
            this.txtCostoARS.Size = new System.Drawing.Size(99, 20);
            this.txtCostoARS.TabIndex = 130;
            this.txtCostoARS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 129;
            this.label7.Text = "Costo ARS";
            // 
            // txtCostoUSD
            // 
            this.txtCostoUSD.Location = new System.Drawing.Point(76, 32);
            this.txtCostoUSD.Name = "txtCostoUSD";
            this.txtCostoUSD.ReadOnly = true;
            this.txtCostoUSD.Size = new System.Drawing.Size(99, 20);
            this.txtCostoUSD.TabIndex = 127;
            this.txtCostoUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 128;
            this.label8.Text = "Costo USD";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.ckRecalculoCosto);
            this.panel4.Controls.Add(this.txtCostoUSD);
            this.panel4.Controls.Add(this.btnExplosionCompleta);
            this.panel4.Controls.Add(this.txtCostoARS);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(374, 333);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(186, 132);
            this.panel4.TabIndex = 131;
            // 
            // ckRecalculoCosto
            // 
            this.ckRecalculoCosto.AutoSize = true;
            this.ckRecalculoCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckRecalculoCosto.Location = new System.Drawing.Point(8, 7);
            this.ckRecalculoCosto.Name = "ckRecalculoCosto";
            this.ckRecalculoCosto.Size = new System.Drawing.Size(121, 19);
            this.ckRecalculoCosto.TabIndex = 110;
            this.ckRecalculoCosto.Text = "Recalculo Costos";
            this.ckRecalculoCosto.UseVisualStyleBackColor = true;
            this.ckRecalculoCosto.CheckedChanged += new System.EventHandler(this.CkRecalculoCosto_CheckedChanged);
            // 
            // FrmCO05SeleccionaFormulaCosteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 611);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnModificarFormulaCosteo);
            this.Controls.Add(this.btnExit);
            this.Name = "FrmCO05SeleccionaFormulaCosteo";
            this.Text = "CO05 - Seleccion Formula Costeo";
            this.Load += new System.EventHandler(this.FrmCO05SeleccionaFormulaCosteo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoMItemsBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoMHeaderBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeader)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModificarFormulaCosteo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtTC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMtype;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource BoMItemsBs;
        private System.Windows.Forms.BindingSource BoMHeaderBs;
        private System.Windows.Forms.ComboBox cmbMonedaCosto;
        private System.Windows.Forms.TextBox txtFormulaFCOST;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDFORMULADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCFORMULADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fORMVERSIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUsedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logUpdatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDITEMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTEMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cANTIDADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cANTIDADPORCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uNIDADDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckSoloFormulasActivas;
        private System.Windows.Forms.Button btnExplosionCompleta;
        private System.Windows.Forms.TextBox txtCostoARS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCostoUSD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtFormulaDescription;
        private System.Windows.Forms.CheckBox ckRecalculoCosto;
    }
}