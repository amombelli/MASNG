namespace MASngFE.MasterData.Customer_Master
{
    partial class FrmMdc01CustomerSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMdc01CustomerSearch));
            this.btnSalir = new System.Windows.Forms.Button();
            this.T0006DgvBs = new System.Windows.Forms.BindingSource(this.components);
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.iDCLIENTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clirsocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clifantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTIVODataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.@__Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.uCustomerSearch1 = new MASngFE._UserControls.UCustomerSearch();
            this.uSemaforo41 = new MASngFE._UserControls.USemaforo4();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(582, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 100;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // T0006DgvBs
            // 
            this.T0006DgvBs.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AutoGenerateColumns = false;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCLIENTEDataGridViewTextBoxColumn,
            this.clirsocialDataGridViewTextBoxColumn,
            this.clifantasiaDataGridViewTextBoxColumn,
            this.aCTIVODataGridViewCheckBoxColumn,
            this.@__Accion});
            this.dgvClientes.DataSource = this.T0006DgvBs;
            this.dgvClientes.Location = new System.Drawing.Point(3, 119);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersWidth = 20;
            this.dgvClientes.Size = new System.Drawing.Size(575, 381);
            this.dgvClientes.TabIndex = 101;
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            // 
            // iDCLIENTEDataGridViewTextBoxColumn
            // 
            this.iDCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "IDCLIENTE";
            this.iDCLIENTEDataGridViewTextBoxColumn.HeaderText = "Id6";
            this.iDCLIENTEDataGridViewTextBoxColumn.Name = "iDCLIENTEDataGridViewTextBoxColumn";
            this.iDCLIENTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCLIENTEDataGridViewTextBoxColumn.Width = 40;
            // 
            // clirsocialDataGridViewTextBoxColumn
            // 
            this.clirsocialDataGridViewTextBoxColumn.DataPropertyName = "cli_rsocial";
            this.clirsocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.clirsocialDataGridViewTextBoxColumn.Name = "clirsocialDataGridViewTextBoxColumn";
            this.clirsocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.clirsocialDataGridViewTextBoxColumn.Width = 200;
            // 
            // clifantasiaDataGridViewTextBoxColumn
            // 
            this.clifantasiaDataGridViewTextBoxColumn.DataPropertyName = "cli_fantasia";
            this.clifantasiaDataGridViewTextBoxColumn.HeaderText = "Fantasia";
            this.clifantasiaDataGridViewTextBoxColumn.Name = "clifantasiaDataGridViewTextBoxColumn";
            this.clifantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.clifantasiaDataGridViewTextBoxColumn.Width = 160;
            // 
            // aCTIVODataGridViewCheckBoxColumn
            // 
            this.aCTIVODataGridViewCheckBoxColumn.DataPropertyName = "ACTIVO";
            this.aCTIVODataGridViewCheckBoxColumn.HeaderText = "Activo";
            this.aCTIVODataGridViewCheckBoxColumn.Name = "aCTIVODataGridViewCheckBoxColumn";
            this.aCTIVODataGridViewCheckBoxColumn.ReadOnly = true;
            this.aCTIVODataGridViewCheckBoxColumn.Width = 60;
            // 
            // __Accion
            // 
            this.@__Accion.HeaderText = "Accion";
            this.@__Accion.Name = "__Accion";
            this.@__Accion.ReadOnly = true;
            this.@__Accion.ToolTipText = "Ejecuta la accion seleccionada";
            this.@__Accion.UseColumnTextForButtonValue = true;
            this.@__Accion.Width = 60;
            // 
            // uCustomerSearch1
            // 
            this.uCustomerSearch1.Location = new System.Drawing.Point(1, -2);
            this.uCustomerSearch1.Name = "uCustomerSearch1";
            this.uCustomerSearch1.Size = new System.Drawing.Size(577, 119);
            this.uCustomerSearch1.TabIndex = 0;
            // 
            // uSemaforo41
            // 
            this.uSemaforo41.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.uSemaforo41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uSemaforo41.Location = new System.Drawing.Point(651, 48);
            this.uSemaforo41.Name = "uSemaforo41";
            this.uSemaforo41.Size = new System.Drawing.Size(23, 23);
            this.uSemaforo41.TabIndex = 102;
            // 
            // FrmMdc01CustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 504);
            this.Controls.Add(this.uSemaforo41);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.uCustomerSearch1);
            this.Name = "FrmMdc01CustomerSearch";
            this.Text = "MDC01 Busqueda de Cliente > Customer Master Data";
            this.Load += new System.EventHandler(this.FrmMDC01CustomerSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private _UserControls.UCustomerSearch uCustomerSearch1;
        private System.Windows.Forms.Button btnSalir;
        public System.Windows.Forms.BindingSource T0006DgvBs;
        public System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCLIENTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clirsocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clifantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVODataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn __Accion;
        private _UserControls.USemaforo4 uSemaforo41;
    }
}