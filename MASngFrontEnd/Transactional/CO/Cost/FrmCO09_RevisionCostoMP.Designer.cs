namespace MASngFE.Transactional.CO.Cost
{
    partial class FrmCO09_RevisionCostoMP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCO09_RevisionCostoMP));
            this.btnModificarFormulaCosteo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.t0035CostRollBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mOrigenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monedaCostoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costRollIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitarioRepoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitarioStdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitarioPPPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordAddedOnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordAddedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costRollDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manualUpdatedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.costRepoDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costStdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPppDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panIdentificacionCliente = new System.Windows.Forms.Panel();
            this.ckBillToActivo = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtFantasia6 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtId6_ = new System.Windows.Forms.TextBox();
            this.txtmodo = new System.Windows.Forms.TextBox();
            this.txtfn = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.ckActivo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0035CostRollBindingSource)).BeginInit();
            this.panIdentificacionCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModificarFormulaCosteo
            // 
            this.btnModificarFormulaCosteo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnModificarFormulaCosteo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarFormulaCosteo.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarFormulaCosteo.Image")));
            this.btnModificarFormulaCosteo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarFormulaCosteo.Location = new System.Drawing.Point(688, 52);
            this.btnModificarFormulaCosteo.Name = "btnModificarFormulaCosteo";
            this.btnModificarFormulaCosteo.Size = new System.Drawing.Size(100, 40);
            this.btnModificarFormulaCosteo.TabIndex = 121;
            this.btnModificarFormulaCosteo.Text = "Modificar\r\nFCOST";
            this.btnModificarFormulaCosteo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarFormulaCosteo.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(688, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 120;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materialDataGridViewTextBoxColumn,
            this.mTypeDataGridViewTextBoxColumn,
            this.mOrigenDataGridViewTextBoxColumn,
            this.monedaCostoDataGridViewTextBoxColumn,
            this.fCostDataGridViewTextBoxColumn,
            this.costRollIdDataGridViewTextBoxColumn,
            this.costoUnitarioRepoDataGridViewTextBoxColumn,
            this.costoUnitarioStdDataGridViewTextBoxColumn,
            this.costoUnitarioPPPDataGridViewTextBoxColumn,
            this.recordAddedOnDataGridViewTextBoxColumn,
            this.recordAddedByDataGridViewTextBoxColumn,
            this.costRollDateDataGridViewTextBoxColumn,
            this.manualUpdatedDataGridViewCheckBoxColumn,
            this.costRepoDateDataGridViewTextBoxColumn,
            this.costStdDateDataGridViewTextBoxColumn,
            this.costPppDateDataGridViewTextBoxColumn});
            this.dgvData.DataSource = this.t0035CostRollBindingSource;
            this.dgvData.GridColor = System.Drawing.Color.Black;
            this.dgvData.Location = new System.Drawing.Point(6, 120);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 20;
            this.dgvData.Size = new System.Drawing.Size(782, 478);
            this.dgvData.TabIndex = 122;
            // 
            // t0035CostRollBindingSource
            // 
            this.t0035CostRollBindingSource.DataSource = typeof(TecserEF.Entity.T0035_CostRoll);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightCoral;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(846, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(3, 606);
            this.label4.TabIndex = 123;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.LightCoral;
            this.label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label58.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(2, 2);
            this.label58.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(847, 3);
            this.label58.TabIndex = 124;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightCoral;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 606);
            this.label1.TabIndex = 125;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            this.materialDataGridViewTextBoxColumn.Width = 120;
            // 
            // mTypeDataGridViewTextBoxColumn
            // 
            this.mTypeDataGridViewTextBoxColumn.DataPropertyName = "MType";
            this.mTypeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.mTypeDataGridViewTextBoxColumn.Name = "mTypeDataGridViewTextBoxColumn";
            this.mTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.mTypeDataGridViewTextBoxColumn.Width = 40;
            // 
            // mOrigenDataGridViewTextBoxColumn
            // 
            this.mOrigenDataGridViewTextBoxColumn.DataPropertyName = "MOrigen";
            this.mOrigenDataGridViewTextBoxColumn.HeaderText = "Ori";
            this.mOrigenDataGridViewTextBoxColumn.Name = "mOrigenDataGridViewTextBoxColumn";
            this.mOrigenDataGridViewTextBoxColumn.ReadOnly = true;
            this.mOrigenDataGridViewTextBoxColumn.Width = 40;
            // 
            // monedaCostoDataGridViewTextBoxColumn
            // 
            this.monedaCostoDataGridViewTextBoxColumn.DataPropertyName = "MonedaCosto";
            this.monedaCostoDataGridViewTextBoxColumn.HeaderText = "Mon";
            this.monedaCostoDataGridViewTextBoxColumn.Name = "monedaCostoDataGridViewTextBoxColumn";
            this.monedaCostoDataGridViewTextBoxColumn.ReadOnly = true;
            this.monedaCostoDataGridViewTextBoxColumn.Width = 35;
            // 
            // fCostDataGridViewTextBoxColumn
            // 
            this.fCostDataGridViewTextBoxColumn.DataPropertyName = "FCost";
            this.fCostDataGridViewTextBoxColumn.HeaderText = "FCost";
            this.fCostDataGridViewTextBoxColumn.Name = "fCostDataGridViewTextBoxColumn";
            this.fCostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costRollIdDataGridViewTextBoxColumn
            // 
            this.costRollIdDataGridViewTextBoxColumn.DataPropertyName = "CostRollId";
            this.costRollIdDataGridViewTextBoxColumn.HeaderText = "CostRollId";
            this.costRollIdDataGridViewTextBoxColumn.Name = "costRollIdDataGridViewTextBoxColumn";
            this.costRollIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoUnitarioRepoDataGridViewTextBoxColumn
            // 
            this.costoUnitarioRepoDataGridViewTextBoxColumn.DataPropertyName = "CostoUnitarioRepo";
            this.costoUnitarioRepoDataGridViewTextBoxColumn.HeaderText = "CostoUnitarioRepo";
            this.costoUnitarioRepoDataGridViewTextBoxColumn.Name = "costoUnitarioRepoDataGridViewTextBoxColumn";
            this.costoUnitarioRepoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoUnitarioStdDataGridViewTextBoxColumn
            // 
            this.costoUnitarioStdDataGridViewTextBoxColumn.DataPropertyName = "CostoUnitarioStd";
            this.costoUnitarioStdDataGridViewTextBoxColumn.HeaderText = "CostoUnitarioStd";
            this.costoUnitarioStdDataGridViewTextBoxColumn.Name = "costoUnitarioStdDataGridViewTextBoxColumn";
            this.costoUnitarioStdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoUnitarioPPPDataGridViewTextBoxColumn
            // 
            this.costoUnitarioPPPDataGridViewTextBoxColumn.DataPropertyName = "CostoUnitarioPPP";
            this.costoUnitarioPPPDataGridViewTextBoxColumn.HeaderText = "CostoUnitarioPPP";
            this.costoUnitarioPPPDataGridViewTextBoxColumn.Name = "costoUnitarioPPPDataGridViewTextBoxColumn";
            this.costoUnitarioPPPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // recordAddedOnDataGridViewTextBoxColumn
            // 
            this.recordAddedOnDataGridViewTextBoxColumn.DataPropertyName = "RecordAddedOn";
            this.recordAddedOnDataGridViewTextBoxColumn.HeaderText = "RecordAddedOn";
            this.recordAddedOnDataGridViewTextBoxColumn.Name = "recordAddedOnDataGridViewTextBoxColumn";
            this.recordAddedOnDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // recordAddedByDataGridViewTextBoxColumn
            // 
            this.recordAddedByDataGridViewTextBoxColumn.DataPropertyName = "RecordAddedBy";
            this.recordAddedByDataGridViewTextBoxColumn.HeaderText = "RecordAddedBy";
            this.recordAddedByDataGridViewTextBoxColumn.Name = "recordAddedByDataGridViewTextBoxColumn";
            this.recordAddedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costRollDateDataGridViewTextBoxColumn
            // 
            this.costRollDateDataGridViewTextBoxColumn.DataPropertyName = "CostRollDate";
            this.costRollDateDataGridViewTextBoxColumn.HeaderText = "CostRollDate";
            this.costRollDateDataGridViewTextBoxColumn.Name = "costRollDateDataGridViewTextBoxColumn";
            this.costRollDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // manualUpdatedDataGridViewCheckBoxColumn
            // 
            this.manualUpdatedDataGridViewCheckBoxColumn.DataPropertyName = "ManualUpdated";
            this.manualUpdatedDataGridViewCheckBoxColumn.HeaderText = "ManualUpdated";
            this.manualUpdatedDataGridViewCheckBoxColumn.Name = "manualUpdatedDataGridViewCheckBoxColumn";
            this.manualUpdatedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // costRepoDateDataGridViewTextBoxColumn
            // 
            this.costRepoDateDataGridViewTextBoxColumn.DataPropertyName = "CostRepoDate";
            this.costRepoDateDataGridViewTextBoxColumn.HeaderText = "CostRepoDate";
            this.costRepoDateDataGridViewTextBoxColumn.Name = "costRepoDateDataGridViewTextBoxColumn";
            this.costRepoDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costStdDateDataGridViewTextBoxColumn
            // 
            this.costStdDateDataGridViewTextBoxColumn.DataPropertyName = "CostStdDate";
            this.costStdDateDataGridViewTextBoxColumn.HeaderText = "CostStdDate";
            this.costStdDateDataGridViewTextBoxColumn.Name = "costStdDateDataGridViewTextBoxColumn";
            this.costStdDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costPppDateDataGridViewTextBoxColumn
            // 
            this.costPppDateDataGridViewTextBoxColumn.DataPropertyName = "CostPppDate";
            this.costPppDateDataGridViewTextBoxColumn.HeaderText = "CostPppDate";
            this.costPppDateDataGridViewTextBoxColumn.Name = "costPppDateDataGridViewTextBoxColumn";
            this.costPppDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // panIdentificacionCliente
            // 
            this.panIdentificacionCliente.BackColor = System.Drawing.Color.Lavender;
            this.panIdentificacionCliente.Controls.Add(this.ckBillToActivo);
            this.panIdentificacionCliente.Controls.Add(this.label19);
            this.panIdentificacionCliente.Controls.Add(this.txtFantasia6);
            this.panIdentificacionCliente.Controls.Add(this.label20);
            this.panIdentificacionCliente.Controls.Add(this.txtRazonSocial);
            this.panIdentificacionCliente.Controls.Add(this.label21);
            this.panIdentificacionCliente.Controls.Add(this.txtId6_);
            this.panIdentificacionCliente.Controls.Add(this.txtmodo);
            this.panIdentificacionCliente.Controls.Add(this.txtfn);
            this.panIdentificacionCliente.Controls.Add(this.label37);
            this.panIdentificacionCliente.Controls.Add(this.label38);
            this.panIdentificacionCliente.Controls.Add(this.ckActivo);
            this.panIdentificacionCliente.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panIdentificacionCliente.Location = new System.Drawing.Point(9, 7);
            this.panIdentificacionCliente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panIdentificacionCliente.Name = "panIdentificacionCliente";
            this.panIdentificacionCliente.Size = new System.Drawing.Size(834, 57);
            this.panIdentificacionCliente.TabIndex = 126;
            // 
            // ckBillToActivo
            // 
            this.ckBillToActivo.AutoCheck = false;
            this.ckBillToActivo.AutoSize = true;
            this.ckBillToActivo.BackColor = System.Drawing.Color.Transparent;
            this.ckBillToActivo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBillToActivo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ckBillToActivo.Location = new System.Drawing.Point(558, 6);
            this.ckBillToActivo.Name = "ckBillToActivo";
            this.ckBillToActivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckBillToActivo.Size = new System.Drawing.Size(138, 19);
            this.ckBillToActivo.TabIndex = 86;
            this.ckBillToActivo.Text = "Cliente BILLTO Activo";
            this.ckBillToActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckBillToActivo.UseVisualStyleBackColor = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Navy;
            this.label19.Location = new System.Drawing.Point(10, 32);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 14);
            this.label19.TabIndex = 8;
            this.label19.Text = "Nombre Fantasia";
            // 
            // txtFantasia6
            // 
            this.txtFantasia6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtFantasia6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFantasia6.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtFantasia6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtFantasia6.Location = new System.Drawing.Point(107, 28);
            this.txtFantasia6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFantasia6.Name = "txtFantasia6";
            this.txtFantasia6.ReadOnly = true;
            this.txtFantasia6.Size = new System.Drawing.Size(201, 23);
            this.txtFantasia6.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.DarkBlue;
            this.label20.Location = new System.Drawing.Point(33, 8);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 14);
            this.label20.TabIndex = 6;
            this.label20.Text = "GUID Activo";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazonSocial.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRazonSocial.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtRazonSocial.Location = new System.Drawing.Point(107, 4);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(201, 23);
            this.txtRazonSocial.TabIndex = 5;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(436, 8);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 15);
            this.label21.TabIndex = 2;
            this.label21.Text = "CID#6";
            // 
            // txtId6_
            // 
            this.txtId6_.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtId6_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId6_.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtId6_.Enabled = false;
            this.txtId6_.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId6_.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtId6_.Location = new System.Drawing.Point(478, 4);
            this.txtId6_.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtId6_.Name = "txtId6_";
            this.txtId6_.ReadOnly = true;
            this.txtId6_.Size = new System.Drawing.Size(49, 22);
            this.txtId6_.TabIndex = 1;
            this.txtId6_.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtmodo
            // 
            this.txtmodo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtmodo.Location = new System.Drawing.Point(762, 4);
            this.txtmodo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtmodo.Name = "txtmodo";
            this.txtmodo.ReadOnly = true;
            this.txtmodo.Size = new System.Drawing.Size(18, 23);
            this.txtmodo.TabIndex = 81;
            this.txtmodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtmodo.UseWaitCursor = true;
            // 
            // txtfn
            // 
            this.txtfn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtfn.Location = new System.Drawing.Point(762, 28);
            this.txtfn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtfn.Name = "txtfn";
            this.txtfn.ReadOnly = true;
            this.txtfn.Size = new System.Drawing.Size(35, 23);
            this.txtfn.TabIndex = 84;
            this.txtfn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtfn.UseWaitCursor = true;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(717, 8);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(39, 15);
            this.label37.TabIndex = 82;
            this.label37.Text = "Modo";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(717, 32);
            this.label38.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(20, 15);
            this.label38.TabIndex = 85;
            this.label38.Text = "Fn";
            // 
            // ckActivo
            // 
            this.ckActivo.AutoCheck = false;
            this.ckActivo.AutoSize = true;
            this.ckActivo.BackColor = System.Drawing.Color.Transparent;
            this.ckActivo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckActivo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ckActivo.Location = new System.Drawing.Point(570, 31);
            this.ckActivo.Name = "ckActivo";
            this.ckActivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckActivo.Size = new System.Drawing.Size(126, 19);
            this.ckActivo.TabIndex = 33;
            this.ckActivo.Text = "DIRECCION ACTIVA";
            this.ckActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckActivo.UseVisualStyleBackColor = false;
            // 
            // FrmCO09_RevisionCostoMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 610);
            this.Controls.Add(this.panIdentificacionCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnModificarFormulaCosteo);
            this.Controls.Add(this.btnExit);
            this.Name = "FrmCO09_RevisionCostoMP";
            this.Text = "CO09 - Revision Costos Materia Prima";
            this.Load += new System.EventHandler(this.FrmCO09_RevisionCostoMP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0035CostRollBindingSource)).EndInit();
            this.panIdentificacionCliente.ResumeLayout(false);
            this.panIdentificacionCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModificarFormulaCosteo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.BindingSource t0035CostRollBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mOrigenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monedaCostoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costRollIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioRepoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioStdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioPPPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordAddedOnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordAddedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costRollDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn manualUpdatedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costRepoDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costStdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPppDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panIdentificacionCliente;
        private System.Windows.Forms.CheckBox ckBillToActivo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtFantasia6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtId6_;
        private System.Windows.Forms.TextBox txtmodo;
        private System.Windows.Forms.TextBox txtfn;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.CheckBox ckActivo;
    }
}