namespace MASngFE.Transactional.SD.SalesOrder
{
    partial class FrmSD01SalesOrderSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSD01SalesOrderSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ckClienteActivo = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbFantasia = new System.Windows.Forms.RadioButton();
            this.rbRazon = new System.Windows.Forms.RadioButton();
            this.btnVerCliente = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDT6 = new System.Windows.Forms.ComboBox();
            this.cmbClienteT6 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.txtSalesOrderNumberSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListadoSO = new System.Windows.Forms.DataGridView();
            this.sODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idC7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idC6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteFantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteRazonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDescripcionT7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaSalesOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCompromisoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusSalesOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIEW = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EDIT = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dsSalesOrderListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnNuevaSO = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoSO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSalesOrderListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ckClienteActivo
            // 
            this.ckClienteActivo.AutoSize = true;
            this.ckClienteActivo.Checked = true;
            this.ckClienteActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckClienteActivo.Location = new System.Drawing.Point(493, 18);
            this.ckClienteActivo.Name = "ckClienteActivo";
            this.ckClienteActivo.Size = new System.Drawing.Size(125, 17);
            this.ckClienteActivo.TabIndex = 76;
            this.ckClienteActivo.TabStop = false;
            this.ckClienteActivo.Text = "Solo Clientes Activos";
            this.ckClienteActivo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbFantasia);
            this.groupBox1.Controls.Add(this.rbRazon);
            this.groupBox1.Controls.Add(this.btnVerCliente);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 47);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LISTAR CLIENTE POR";
            // 
            // rbFantasia
            // 
            this.rbFantasia.AutoSize = true;
            this.rbFantasia.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFantasia.Location = new System.Drawing.Point(116, 19);
            this.rbFantasia.Name = "rbFantasia";
            this.rbFantasia.Size = new System.Drawing.Size(114, 19);
            this.rbFantasia.TabIndex = 1;
            this.rbFantasia.TabStop = true;
            this.rbFantasia.Text = "NOMBRE FANTASIA";
            this.rbFantasia.UseVisualStyleBackColor = true;
            // 
            // rbRazon
            // 
            this.rbRazon.AutoSize = true;
            this.rbRazon.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRazon.Location = new System.Drawing.Point(16, 19);
            this.rbRazon.Name = "rbRazon";
            this.rbRazon.Size = new System.Drawing.Size(94, 19);
            this.rbRazon.TabIndex = 0;
            this.rbRazon.TabStop = true;
            this.rbRazon.Text = "RAZON SOCIAL";
            this.rbRazon.UseVisualStyleBackColor = true;
            this.rbRazon.CheckedChanged += new System.EventHandler(this.rbRazon_CheckedChanged);
            // 
            // btnVerCliente
            // 
            this.btnVerCliente.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerCliente.Location = new System.Drawing.Point(236, 18);
            this.btnVerCliente.Name = "btnVerCliente";
            this.btnVerCliente.Size = new System.Drawing.Size(79, 20);
            this.btnVerCliente.TabIndex = 72;
            this.btnVerCliente.TabStop = false;
            this.btnVerCliente.Text = "VER CLIENTE";
            this.btnVerCliente.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(11, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 79;
            this.label4.Text = "Nombre Cliente";
            // 
            // txtIDT6
            // 
            this.txtIDT6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtIDT6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtIDT6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtIDT6.DropDownWidth = 200;
            this.txtIDT6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDT6.FormattingEnabled = true;
            this.txtIDT6.Location = new System.Drawing.Point(377, 10);
            this.txtIDT6.Name = "txtIDT6";
            this.txtIDT6.Size = new System.Drawing.Size(79, 22);
            this.txtIDT6.TabIndex = 78;
            this.txtIDT6.SelectedIndexChanged += new System.EventHandler(this.txtIDT6_SelectedIndexChanged);
            // 
            // cmbClienteT6
            // 
            this.cmbClienteT6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbClienteT6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClienteT6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmbClienteT6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClienteT6.FormattingEnabled = true;
            this.cmbClienteT6.Location = new System.Drawing.Point(108, 10);
            this.cmbClienteT6.Name = "cmbClienteT6";
            this.cmbClienteT6.Size = new System.Drawing.Size(263, 22);
            this.cmbClienteT6.TabIndex = 77;
            this.cmbClienteT6.SelectedIndexChanged += new System.EventHandler(this.cmbClienteT6_SelectedIndexChanged);
            this.cmbClienteT6.Validating += new System.ComponentModel.CancelEventHandler(this.cmbClienteT6_Validating);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtSalesOrderNumberSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbClienteT6);
            this.panel1.Controls.Add(this.txtIDT6);
            this.panel1.Location = new System.Drawing.Point(12, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 62);
            this.panel1.TabIndex = 80;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAll.Image = ((System.Drawing.Image)(resources.GetObject("btnViewAll.Image")));
            this.btnViewAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewAll.Location = new System.Drawing.Point(666, 96);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(107, 42);
            this.btnViewAll.TabIndex = 89;
            this.btnViewAll.Text = "View\r\nALL";
            this.btnViewAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // txtSalesOrderNumberSearch
            // 
            this.txtSalesOrderNumberSearch.Location = new System.Drawing.Point(108, 34);
            this.txtSalesOrderNumberSearch.Name = "txtSalesOrderNumberSearch";
            this.txtSalesOrderNumberSearch.Size = new System.Drawing.Size(76, 20);
            this.txtSalesOrderNumberSearch.TabIndex = 82;
            this.txtSalesOrderNumberSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesOrderNumberSearch_KeyPress);
            this.txtSalesOrderNumberSearch.Leave += new System.EventHandler(this.txtSalesOrderNumberSearch_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 80;
            this.label1.Text = "Sales Order #";
            // 
            // dgvListadoSO
            // 
            this.dgvListadoSO.AllowUserToAddRows = false;
            this.dgvListadoSO.AllowUserToDeleteRows = false;
            this.dgvListadoSO.AutoGenerateColumns = false;
            this.dgvListadoSO.BackgroundColor = System.Drawing.Color.White;
            this.dgvListadoSO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoSO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sODataGridViewTextBoxColumn,
            this.idC7DataGridViewTextBoxColumn,
            this.idC6DataGridViewTextBoxColumn,
            this.clienteFantasiaDataGridViewTextBoxColumn,
            this.clienteRazonSocialDataGridViewTextBoxColumn,
            this.clienteDescripcionT7DataGridViewTextBoxColumn,
            this.fechaSalesOrderDataGridViewTextBoxColumn,
            this.fechaCompromisoDataGridViewTextBoxColumn,
            this.statusSalesOrderDataGridViewTextBoxColumn,
            this.statusEntregaDataGridViewTextBoxColumn,
            this.VIEW,
            this.EDIT});
            this.dgvListadoSO.DataSource = this.dsSalesOrderListBindingSource;
            this.dgvListadoSO.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvListadoSO.Location = new System.Drawing.Point(12, 131);
            this.dgvListadoSO.Name = "dgvListadoSO";
            this.dgvListadoSO.ReadOnly = true;
            this.dgvListadoSO.RowHeadersWidth = 20;
            this.dgvListadoSO.Size = new System.Drawing.Size(640, 480);
            this.dgvListadoSO.TabIndex = 88;
            this.dgvListadoSO.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoSO_CellContentClick);
            // 
            // sODataGridViewTextBoxColumn
            // 
            this.sODataGridViewTextBoxColumn.DataPropertyName = "SO";
            this.sODataGridViewTextBoxColumn.HeaderText = "SO#";
            this.sODataGridViewTextBoxColumn.Name = "sODataGridViewTextBoxColumn";
            this.sODataGridViewTextBoxColumn.ReadOnly = true;
            this.sODataGridViewTextBoxColumn.Width = 50;
            // 
            // idC7DataGridViewTextBoxColumn
            // 
            this.idC7DataGridViewTextBoxColumn.DataPropertyName = "IdC7";
            this.idC7DataGridViewTextBoxColumn.HeaderText = "IdC7";
            this.idC7DataGridViewTextBoxColumn.Name = "idC7DataGridViewTextBoxColumn";
            this.idC7DataGridViewTextBoxColumn.ReadOnly = true;
            this.idC7DataGridViewTextBoxColumn.Visible = false;
            // 
            // idC6DataGridViewTextBoxColumn
            // 
            this.idC6DataGridViewTextBoxColumn.DataPropertyName = "IdC6";
            this.idC6DataGridViewTextBoxColumn.HeaderText = "IdC6";
            this.idC6DataGridViewTextBoxColumn.Name = "idC6DataGridViewTextBoxColumn";
            this.idC6DataGridViewTextBoxColumn.ReadOnly = true;
            this.idC6DataGridViewTextBoxColumn.Visible = false;
            // 
            // clienteFantasiaDataGridViewTextBoxColumn
            // 
            this.clienteFantasiaDataGridViewTextBoxColumn.DataPropertyName = "ClienteFantasia";
            this.clienteFantasiaDataGridViewTextBoxColumn.HeaderText = "ClienteFantasia";
            this.clienteFantasiaDataGridViewTextBoxColumn.Name = "clienteFantasiaDataGridViewTextBoxColumn";
            this.clienteFantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteFantasiaDataGridViewTextBoxColumn.Visible = false;
            // 
            // clienteRazonSocialDataGridViewTextBoxColumn
            // 
            this.clienteRazonSocialDataGridViewTextBoxColumn.DataPropertyName = "ClienteRazonSocial";
            this.clienteRazonSocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.clienteRazonSocialDataGridViewTextBoxColumn.Name = "clienteRazonSocialDataGridViewTextBoxColumn";
            this.clienteRazonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteRazonSocialDataGridViewTextBoxColumn.Width = 150;
            // 
            // clienteDescripcionT7DataGridViewTextBoxColumn
            // 
            this.clienteDescripcionT7DataGridViewTextBoxColumn.DataPropertyName = "ClienteDescripcionT7";
            this.clienteDescripcionT7DataGridViewTextBoxColumn.HeaderText = "ClienteDescripcionT7";
            this.clienteDescripcionT7DataGridViewTextBoxColumn.Name = "clienteDescripcionT7DataGridViewTextBoxColumn";
            this.clienteDescripcionT7DataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteDescripcionT7DataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaSalesOrderDataGridViewTextBoxColumn
            // 
            this.fechaSalesOrderDataGridViewTextBoxColumn.DataPropertyName = "FechaSalesOrder";
            this.fechaSalesOrderDataGridViewTextBoxColumn.HeaderText = "Fecha SO";
            this.fechaSalesOrderDataGridViewTextBoxColumn.Name = "fechaSalesOrderDataGridViewTextBoxColumn";
            this.fechaSalesOrderDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaCompromisoDataGridViewTextBoxColumn
            // 
            this.fechaCompromisoDataGridViewTextBoxColumn.DataPropertyName = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.HeaderText = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.Name = "fechaCompromisoDataGridViewTextBoxColumn";
            this.fechaCompromisoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCompromisoDataGridViewTextBoxColumn.Visible = false;
            // 
            // statusSalesOrderDataGridViewTextBoxColumn
            // 
            this.statusSalesOrderDataGridViewTextBoxColumn.DataPropertyName = "StatusSalesOrder";
            this.statusSalesOrderDataGridViewTextBoxColumn.HeaderText = "Status SO";
            this.statusSalesOrderDataGridViewTextBoxColumn.Name = "statusSalesOrderDataGridViewTextBoxColumn";
            this.statusSalesOrderDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusEntregaDataGridViewTextBoxColumn
            // 
            this.statusEntregaDataGridViewTextBoxColumn.DataPropertyName = "StatusEntrega";
            this.statusEntregaDataGridViewTextBoxColumn.HeaderText = "Status Entrega";
            this.statusEntregaDataGridViewTextBoxColumn.Name = "statusEntregaDataGridViewTextBoxColumn";
            this.statusEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // VIEW
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VIEW.DefaultCellStyle = dataGridViewCellStyle2;
            this.VIEW.HeaderText = "View";
            this.VIEW.Name = "VIEW";
            this.VIEW.ReadOnly = true;
            this.VIEW.Text = "View";
            this.VIEW.ToolTipText = "Visualizar una Orden de Venta";
            this.VIEW.UseColumnTextForButtonValue = true;
            this.VIEW.Width = 50;
            // 
            // EDIT
            // 
            this.EDIT.HeaderText = "Edit";
            this.EDIT.Name = "EDIT";
            this.EDIT.ReadOnly = true;
            this.EDIT.Text = "Edit";
            this.EDIT.ToolTipText = "Editar una Orden de Venta";
            this.EDIT.UseColumnTextForButtonValue = true;
            this.EDIT.Width = 50;
            // 
            // dsSalesOrderListBindingSource
            // 
            this.dsSalesOrderListBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.DsSalesOrderList);
            // 
            // btnNuevaSO
            // 
            this.btnNuevaSO.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaSO.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaSO.Image")));
            this.btnNuevaSO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaSO.Location = new System.Drawing.Point(666, 53);
            this.btnNuevaSO.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevaSO.Name = "btnNuevaSO";
            this.btnNuevaSO.Size = new System.Drawing.Size(107, 42);
            this.btnNuevaSO.TabIndex = 91;
            this.btnNuevaSO.Text = "Nueva\r\nSO";
            this.btnNuevaSO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaSO.UseVisualStyleBackColor = true;
            this.btnNuevaSO.Click += new System.EventHandler(this.btnNuevaSO_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(666, 11);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 42);
            this.btnSalir.TabIndex = 90;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // FrmSD01_SalesOrderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 657);
            this.Controls.Add(this.btnNuevaSO);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.dgvListadoSO);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ckClienteActivo);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSD01SalesOrderSearch";
            this.Text = "SD01 - Sales Order Search";
            this.Load += new System.EventHandler(this.FrmSalesOrderSearch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoSO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSalesOrderListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckClienteActivo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbFantasia;
        private System.Windows.Forms.RadioButton rbRazon;
        private System.Windows.Forms.Button btnVerCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtIDT6;
        private System.Windows.Forms.ComboBox cmbClienteT6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvListadoSO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dsSalesOrderListBindingSource;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.TextBox txtSalesOrderNumberSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn sODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idC7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idC6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteFantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteRazonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDescripcionT7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaSalesOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCompromisoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusSalesOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn VIEW;
        private System.Windows.Forms.DataGridViewButtonColumn EDIT;
        private System.Windows.Forms.Button btnNuevaSO;
        private System.Windows.Forms.Button btnSalir;
    }
}