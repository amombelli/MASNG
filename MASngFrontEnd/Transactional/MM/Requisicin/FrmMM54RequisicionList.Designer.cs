namespace MASngFE.Transactional.MM.Requisicin
{
    partial class FrmMM54RequisicionList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.t0068RequisicionCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idRcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusRcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgStockRevisadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgRequeridosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarioRcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VER = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0068RequisicionCompraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AutoGenerateColumns = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRcDataGridViewTextBoxColumn,
            this.fechaRcDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.statusRcDataGridViewTextBoxColumn,
            this.kgStockRevisadoDataGridViewTextBoxColumn,
            this.kgRequeridosDataGridViewTextBoxColumn,
            this.comentarioRcDataGridViewTextBoxColumn,
            this.numeroOCDataGridViewTextBoxColumn,
            this.VER});
            this.dgvList.DataSource = this.t0068RequisicionCompraBindingSource;
            this.dgvList.GridColor = System.Drawing.Color.DarkGreen;
            this.dgvList.Location = new System.Drawing.Point(2, 46);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidth = 20;
            this.dgvList.Size = new System.Drawing.Size(786, 392);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            // 
            // t0068RequisicionCompraBindingSource
            // 
            this.t0068RequisicionCompraBindingSource.DataSource = typeof(TecserEF.Entity.T0068RequisicionCompra);
            // 
            // idRcDataGridViewTextBoxColumn
            // 
            this.idRcDataGridViewTextBoxColumn.DataPropertyName = "idRc";
            this.idRcDataGridViewTextBoxColumn.HeaderText = "RC#";
            this.idRcDataGridViewTextBoxColumn.Name = "idRcDataGridViewTextBoxColumn";
            this.idRcDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRcDataGridViewTextBoxColumn.Width = 40;
            // 
            // fechaRcDataGridViewTextBoxColumn
            // 
            this.fechaRcDataGridViewTextBoxColumn.DataPropertyName = "FechaRc";
            dataGridViewCellStyle13.Format = "d";
            dataGridViewCellStyle13.NullValue = null;
            this.fechaRcDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.fechaRcDataGridViewTextBoxColumn.HeaderText = "Fecha RC";
            this.fechaRcDataGridViewTextBoxColumn.Name = "fechaRcDataGridViewTextBoxColumn";
            this.fechaRcDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaRcDataGridViewTextBoxColumn.Width = 80;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Blue;
            this.materialDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusRcDataGridViewTextBoxColumn
            // 
            this.statusRcDataGridViewTextBoxColumn.DataPropertyName = "StatusRc";
            this.statusRcDataGridViewTextBoxColumn.HeaderText = "StatusRc";
            this.statusRcDataGridViewTextBoxColumn.Name = "statusRcDataGridViewTextBoxColumn";
            this.statusRcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kgStockRevisadoDataGridViewTextBoxColumn
            // 
            this.kgStockRevisadoDataGridViewTextBoxColumn.DataPropertyName = "KgStockRevisado";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = "0";
            this.kgStockRevisadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.kgStockRevisadoDataGridViewTextBoxColumn.HeaderText = "KGReview";
            this.kgStockRevisadoDataGridViewTextBoxColumn.Name = "kgStockRevisadoDataGridViewTextBoxColumn";
            this.kgStockRevisadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.kgStockRevisadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // kgRequeridosDataGridViewTextBoxColumn
            // 
            this.kgRequeridosDataGridViewTextBoxColumn.DataPropertyName = "KgRequeridos";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle16.Format = "N2";
            this.kgRequeridosDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.kgRequeridosDataGridViewTextBoxColumn.HeaderText = "Kg RC";
            this.kgRequeridosDataGridViewTextBoxColumn.Name = "kgRequeridosDataGridViewTextBoxColumn";
            this.kgRequeridosDataGridViewTextBoxColumn.ReadOnly = true;
            this.kgRequeridosDataGridViewTextBoxColumn.Width = 80;
            // 
            // comentarioRcDataGridViewTextBoxColumn
            // 
            this.comentarioRcDataGridViewTextBoxColumn.DataPropertyName = "ComentarioRc";
            this.comentarioRcDataGridViewTextBoxColumn.HeaderText = "ObservRC";
            this.comentarioRcDataGridViewTextBoxColumn.Name = "comentarioRcDataGridViewTextBoxColumn";
            this.comentarioRcDataGridViewTextBoxColumn.ReadOnly = true;
            this.comentarioRcDataGridViewTextBoxColumn.Width = 150;
            // 
            // numeroOCDataGridViewTextBoxColumn
            // 
            this.numeroOCDataGridViewTextBoxColumn.DataPropertyName = "NumeroOC";
            this.numeroOCDataGridViewTextBoxColumn.HeaderText = "OC #";
            this.numeroOCDataGridViewTextBoxColumn.Name = "numeroOCDataGridViewTextBoxColumn";
            this.numeroOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroOCDataGridViewTextBoxColumn.Width = 70;
            // 
            // VER
            // 
            this.VER.DataPropertyName = "idRc";
            this.VER.HeaderText = "VER";
            this.VER.Name = "VER";
            this.VER.ReadOnly = true;
            this.VER.Text = "VER";
            this.VER.ToolTipText = "Visualizar Requisicion";
            this.VER.UseColumnTextForButtonValue = true;
            this.VER.Width = 50;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(794, 46);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 39);
            this.btnClose.TabIndex = 104;
            this.btnClose.Text = "Salir";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmMM54RequisicionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvList);
            this.Name = "FrmMM54RequisicionList";
            this.Text = "MM54 - Lista de Requisiciones de Compra";
            this.Load += new System.EventHandler(this.FrmMM54RequisicionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0068RequisicionCompraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.BindingSource t0068RequisicionCompraBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusRcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgStockRevisadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgRequeridosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarioRcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn VER;
        private System.Windows.Forms.Button btnClose;
    }
}