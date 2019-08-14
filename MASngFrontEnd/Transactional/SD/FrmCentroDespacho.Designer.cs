namespace MASngFE.Transactional.SD
{
    partial class FrmCentroDespacho
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCentroDespacho = new System.Windows.Forms.DataGridView();
            this.cDStructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SelectItem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idC7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idC6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fantasiaC7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialC7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCompromisoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.akaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgPedidosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgDespachadosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgPendientesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KgComprometidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KgStockTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusOvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localidadEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zonaEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCentroDespacho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cDStructureBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCentroDespacho
            // 
            this.dgvCentroDespacho.AllowUserToAddRows = false;
            this.dgvCentroDespacho.AllowUserToDeleteRows = false;
            this.dgvCentroDespacho.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCentroDespacho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCentroDespacho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCentroDespacho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectItem,
            this.idov,
            this.IdItem,
            this.idC7DataGridViewTextBoxColumn,
            this.idC6DataGridViewTextBoxColumn,
            this.fantasiaC7DataGridViewTextBoxColumn,
            this.razonSocialC7DataGridViewTextBoxColumn,
            this.fechaCompromisoDataGridViewTextBoxColumn,
            this.akaDataGridViewTextBoxColumn,
            this.primarioDataGridViewTextBoxColumn,
            this.kgPedidosDataGridViewTextBoxColumn,
            this.kgDespachadosDataGridViewTextBoxColumn,
            this.kgPendientesDataGridViewTextBoxColumn,
            this.KgComprometidos,
            this.KgStockTotal,
            this.statusOvDataGridViewTextBoxColumn,
            this.statusItemDataGridViewTextBoxColumn,
            this.direccionEntregaDataGridViewTextBoxColumn,
            this.localidadEntregaDataGridViewTextBoxColumn,
            this.zonaEntregaDataGridViewTextBoxColumn});
            this.dgvCentroDespacho.DataSource = this.cDStructureBindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCentroDespacho.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCentroDespacho.Location = new System.Drawing.Point(12, 12);
            this.dgvCentroDespacho.MultiSelect = false;
            this.dgvCentroDespacho.Name = "dgvCentroDespacho";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCentroDespacho.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCentroDespacho.RowHeadersWidth = 20;
            this.dgvCentroDespacho.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCentroDespacho.Size = new System.Drawing.Size(1235, 370);
            this.dgvCentroDespacho.TabIndex = 0;
            this.dgvCentroDespacho.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCentroDespacho_CellContentClick);
            // 
            // cDStructureBindingSource
            // 
            this.cDStructureBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.CDStructure);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectItem
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.NullValue = false;
            this.SelectItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.SelectItem.HeaderText = "Go";
            this.SelectItem.Name = "SelectItem";
            this.SelectItem.Width = 25;
            // 
            // idov
            // 
            this.idov.DataPropertyName = "IdOv";
            this.idov.HeaderText = "NumOV";
            this.idov.Name = "idov";
            this.idov.ReadOnly = true;
            this.idov.Width = 50;
            // 
            // IdItem
            // 
            this.IdItem.DataPropertyName = "IdItem";
            this.IdItem.HeaderText = "Item";
            this.IdItem.Name = "IdItem";
            this.IdItem.ReadOnly = true;
            this.IdItem.Width = 40;
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
            // fantasiaC7DataGridViewTextBoxColumn
            // 
            this.fantasiaC7DataGridViewTextBoxColumn.DataPropertyName = "FantasiaC7";
            this.fantasiaC7DataGridViewTextBoxColumn.HeaderText = "Cliente Entrega";
            this.fantasiaC7DataGridViewTextBoxColumn.Name = "fantasiaC7DataGridViewTextBoxColumn";
            this.fantasiaC7DataGridViewTextBoxColumn.ReadOnly = true;
            this.fantasiaC7DataGridViewTextBoxColumn.Width = 150;
            // 
            // razonSocialC7DataGridViewTextBoxColumn
            // 
            this.razonSocialC7DataGridViewTextBoxColumn.DataPropertyName = "RazonSocialC7";
            this.razonSocialC7DataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.razonSocialC7DataGridViewTextBoxColumn.Name = "razonSocialC7DataGridViewTextBoxColumn";
            this.razonSocialC7DataGridViewTextBoxColumn.ReadOnly = true;
            this.razonSocialC7DataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaCompromisoDataGridViewTextBoxColumn
            // 
            this.fechaCompromisoDataGridViewTextBoxColumn.DataPropertyName = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.HeaderText = "F.Compromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.Name = "fechaCompromisoDataGridViewTextBoxColumn";
            this.fechaCompromisoDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCompromisoDataGridViewTextBoxColumn.Width = 80;
            // 
            // akaDataGridViewTextBoxColumn
            // 
            this.akaDataGridViewTextBoxColumn.DataPropertyName = "Aka";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            this.akaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.akaDataGridViewTextBoxColumn.HeaderText = "Material";
            this.akaDataGridViewTextBoxColumn.Name = "akaDataGridViewTextBoxColumn";
            this.akaDataGridViewTextBoxColumn.ReadOnly = true;
            this.akaDataGridViewTextBoxColumn.Width = 80;
            // 
            // primarioDataGridViewTextBoxColumn
            // 
            this.primarioDataGridViewTextBoxColumn.DataPropertyName = "Primario";
            this.primarioDataGridViewTextBoxColumn.HeaderText = "Primario";
            this.primarioDataGridViewTextBoxColumn.Name = "primarioDataGridViewTextBoxColumn";
            this.primarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.primarioDataGridViewTextBoxColumn.Visible = false;
            // 
            // kgPedidosDataGridViewTextBoxColumn
            // 
            this.kgPedidosDataGridViewTextBoxColumn.DataPropertyName = "KgPedidos";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.kgPedidosDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.kgPedidosDataGridViewTextBoxColumn.HeaderText = "KG PEDIDOS";
            this.kgPedidosDataGridViewTextBoxColumn.Name = "kgPedidosDataGridViewTextBoxColumn";
            this.kgPedidosDataGridViewTextBoxColumn.ReadOnly = true;
            this.kgPedidosDataGridViewTextBoxColumn.Width = 55;
            // 
            // kgDespachadosDataGridViewTextBoxColumn
            // 
            this.kgDespachadosDataGridViewTextBoxColumn.DataPropertyName = "KgDespachados";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Silver;
            this.kgDespachadosDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.kgDespachadosDataGridViewTextBoxColumn.HeaderText = "KG DESPA";
            this.kgDespachadosDataGridViewTextBoxColumn.Name = "kgDespachadosDataGridViewTextBoxColumn";
            this.kgDespachadosDataGridViewTextBoxColumn.ReadOnly = true;
            this.kgDespachadosDataGridViewTextBoxColumn.Width = 55;
            // 
            // kgPendientesDataGridViewTextBoxColumn
            // 
            this.kgPendientesDataGridViewTextBoxColumn.DataPropertyName = "KgPendientes";
            this.kgPendientesDataGridViewTextBoxColumn.HeaderText = "KG PEND.";
            this.kgPendientesDataGridViewTextBoxColumn.Name = "kgPendientesDataGridViewTextBoxColumn";
            this.kgPendientesDataGridViewTextBoxColumn.ReadOnly = true;
            this.kgPendientesDataGridViewTextBoxColumn.Width = 55;
            // 
            // KgComprometidos
            // 
            this.KgComprometidos.DataPropertyName = "KgComprometidos";
            this.KgComprometidos.HeaderText = "KG COMPRO";
            this.KgComprometidos.Name = "KgComprometidos";
            this.KgComprometidos.ReadOnly = true;
            this.KgComprometidos.Width = 55;
            // 
            // KgStockTotal
            // 
            this.KgStockTotal.DataPropertyName = "KgStockTotal";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue;
            this.KgStockTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.KgStockTotal.HeaderText = "STOCK TOTAL";
            this.KgStockTotal.Name = "KgStockTotal";
            this.KgStockTotal.ReadOnly = true;
            this.KgStockTotal.Width = 55;
            // 
            // statusOvDataGridViewTextBoxColumn
            // 
            this.statusOvDataGridViewTextBoxColumn.DataPropertyName = "StatusOv";
            this.statusOvDataGridViewTextBoxColumn.HeaderText = "Estado OV";
            this.statusOvDataGridViewTextBoxColumn.Name = "statusOvDataGridViewTextBoxColumn";
            this.statusOvDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusItemDataGridViewTextBoxColumn
            // 
            this.statusItemDataGridViewTextBoxColumn.DataPropertyName = "StatusItem";
            this.statusItemDataGridViewTextBoxColumn.HeaderText = "Estado Item";
            this.statusItemDataGridViewTextBoxColumn.Name = "statusItemDataGridViewTextBoxColumn";
            this.statusItemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccionEntregaDataGridViewTextBoxColumn
            // 
            this.direccionEntregaDataGridViewTextBoxColumn.DataPropertyName = "DireccionEntrega";
            this.direccionEntregaDataGridViewTextBoxColumn.HeaderText = "Direccion Entrega";
            this.direccionEntregaDataGridViewTextBoxColumn.Name = "direccionEntregaDataGridViewTextBoxColumn";
            this.direccionEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            this.direccionEntregaDataGridViewTextBoxColumn.Visible = false;
            // 
            // localidadEntregaDataGridViewTextBoxColumn
            // 
            this.localidadEntregaDataGridViewTextBoxColumn.DataPropertyName = "LocalidadEntrega";
            this.localidadEntregaDataGridViewTextBoxColumn.HeaderText = "Localidad Entrega";
            this.localidadEntregaDataGridViewTextBoxColumn.Name = "localidadEntregaDataGridViewTextBoxColumn";
            this.localidadEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // zonaEntregaDataGridViewTextBoxColumn
            // 
            this.zonaEntregaDataGridViewTextBoxColumn.DataPropertyName = "ZonaEntrega";
            this.zonaEntregaDataGridViewTextBoxColumn.HeaderText = "Zona";
            this.zonaEntregaDataGridViewTextBoxColumn.Name = "zonaEntregaDataGridViewTextBoxColumn";
            this.zonaEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmCentroDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 492);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvCentroDespacho);
            this.Name = "FrmCentroDespacho";
            this.Text = "FrmCentroDespacho";
            this.Load += new System.EventHandler(this.FrmCentroDespacho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCentroDespacho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cDStructureBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCentroDespacho;
        private System.Windows.Forms.BindingSource cDStructureBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idov;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idC7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idC6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fantasiaC7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialC7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCompromisoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn akaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgPedidosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgDespachadosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgPendientesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KgComprometidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn KgStockTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusOvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidadEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zonaEntregaDataGridViewTextBoxColumn;
    }
}