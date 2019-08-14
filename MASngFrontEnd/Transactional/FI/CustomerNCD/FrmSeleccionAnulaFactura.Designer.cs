namespace MASngFE.Transactional.FI.CustomerNCD
{
    partial class FrmSeleccionAnulaFactura
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.dgvListadoFacturas = new System.Windows.Forms.DataGridView();
            this.t0400FACTURAHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId6 = new System.Windows.Forms.TextBox();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.iDFACTURADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDAFIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPOFACTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusFacturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facturaMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFacturaBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalIVA21DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalIIBBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFacturaNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0400FACTURAHBindingSource)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(935, 54);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(89, 40);
            this.btnSalir.TabIndex = 77;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Location = new System.Drawing.Point(935, 13);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(89, 40);
            this.btnSeleccion.TabIndex = 76;
            this.btnSeleccion.Text = "SELECCION";
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNumeroDocumento);
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 36);
            this.panel1.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numero Doc";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroDocumento.Location = new System.Drawing.Point(94, 8);
            this.txtNumeroDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.ReadOnly = true;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(61, 21);
            this.txtNumeroDocumento.TabIndex = 0;
            // 
            // dgvListadoFacturas
            // 
            this.dgvListadoFacturas.AllowUserToAddRows = false;
            this.dgvListadoFacturas.AllowUserToDeleteRows = false;
            this.dgvListadoFacturas.AutoGenerateColumns = false;
            this.dgvListadoFacturas.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvListadoFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListadoFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDFACTURADataGridViewTextBoxColumn,
            this.tIPODOCDataGridViewTextBoxColumn,
            this.nDAFIPDataGridViewTextBoxColumn,
            this.fECHADataGridViewTextBoxColumn,
            this.tIPOFACTDataGridViewTextBoxColumn,
            this.statusFacturaDataGridViewTextBoxColumn,
            this.facturaMonedaDataGridViewTextBoxColumn,
            this.tCDataGridViewTextBoxColumn,
            this.totalFacturaBDataGridViewTextBoxColumn,
            this.descuentoDataGridViewTextBoxColumn,
            this.totalIVA21DataGridViewTextBoxColumn,
            this.totalIIBBDataGridViewTextBoxColumn,
            this.totalFacturaNDataGridViewTextBoxColumn,
            this.remitoDataGridViewTextBoxColumn});
            this.dgvListadoFacturas.DataSource = this.t0400FACTURAHBindingSource;
            this.dgvListadoFacturas.GridColor = System.Drawing.Color.MidnightBlue;
            this.dgvListadoFacturas.Location = new System.Drawing.Point(12, 119);
            this.dgvListadoFacturas.MultiSelect = false;
            this.dgvListadoFacturas.Name = "dgvListadoFacturas";
            this.dgvListadoFacturas.ReadOnly = true;
            this.dgvListadoFacturas.RowHeadersWidth = 20;
            this.dgvListadoFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoFacturas.Size = new System.Drawing.Size(1012, 389);
            this.dgvListadoFacturas.TabIndex = 74;
            this.dgvListadoFacturas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoFacturas_CellEnter);
            // 
            // t0400FACTURAHBindingSource
            // 
            this.t0400FACTURAHBindingSource.DataSource = typeof(TecserEF.Entity.T0400_FACTURA_H);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.txtRazonSocial);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtId6);
            this.panel5.Controls.Add(this.txtFantasia);
            this.panel5.Location = new System.Drawing.Point(12, 18);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(435, 56);
            this.panel5.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Razón Social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(94, 4);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(246, 21);
            this.txtRazonSocial.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fantasia";
            // 
            // txtId6
            // 
            this.txtId6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId6.Location = new System.Drawing.Point(342, 4);
            this.txtId6.Margin = new System.Windows.Forms.Padding(2);
            this.txtId6.Name = "txtId6";
            this.txtId6.ReadOnly = true;
            this.txtId6.Size = new System.Drawing.Size(46, 21);
            this.txtId6.TabIndex = 9;
            // 
            // txtFantasia
            // 
            this.txtFantasia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFantasia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFantasia.Location = new System.Drawing.Point(94, 27);
            this.txtFantasia.Margin = new System.Windows.Forms.Padding(2);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.ReadOnly = true;
            this.txtFantasia.Size = new System.Drawing.Size(246, 21);
            this.txtFantasia.TabIndex = 7;
            // 
            // iDFACTURADataGridViewTextBoxColumn
            // 
            this.iDFACTURADataGridViewTextBoxColumn.DataPropertyName = "IDFACTURA";
            this.iDFACTURADataGridViewTextBoxColumn.HeaderText = "ID Fact";
            this.iDFACTURADataGridViewTextBoxColumn.Name = "iDFACTURADataGridViewTextBoxColumn";
            this.iDFACTURADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDFACTURADataGridViewTextBoxColumn.Width = 60;
            // 
            // tIPODOCDataGridViewTextBoxColumn
            // 
            this.tIPODOCDataGridViewTextBoxColumn.DataPropertyName = "TIPO_DOC";
            this.tIPODOCDataGridViewTextBoxColumn.HeaderText = "TD";
            this.tIPODOCDataGridViewTextBoxColumn.Name = "tIPODOCDataGridViewTextBoxColumn";
            this.tIPODOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODOCDataGridViewTextBoxColumn.Width = 40;
            // 
            // nDAFIPDataGridViewTextBoxColumn
            // 
            this.nDAFIPDataGridViewTextBoxColumn.DataPropertyName = "ND_AFIP";
            this.nDAFIPDataGridViewTextBoxColumn.HeaderText = "Doc #";
            this.nDAFIPDataGridViewTextBoxColumn.Name = "nDAFIPDataGridViewTextBoxColumn";
            this.nDAFIPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fECHADataGridViewTextBoxColumn
            // 
            this.fECHADataGridViewTextBoxColumn.DataPropertyName = "FECHA";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fECHADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fECHADataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fECHADataGridViewTextBoxColumn.Name = "fECHADataGridViewTextBoxColumn";
            this.fECHADataGridViewTextBoxColumn.ReadOnly = true;
            this.fECHADataGridViewTextBoxColumn.Width = 80;
            // 
            // tIPOFACTDataGridViewTextBoxColumn
            // 
            this.tIPOFACTDataGridViewTextBoxColumn.DataPropertyName = "TIPOFACT";
            this.tIPOFACTDataGridViewTextBoxColumn.HeaderText = "LX";
            this.tIPOFACTDataGridViewTextBoxColumn.Name = "tIPOFACTDataGridViewTextBoxColumn";
            this.tIPOFACTDataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPOFACTDataGridViewTextBoxColumn.Width = 35;
            // 
            // statusFacturaDataGridViewTextBoxColumn
            // 
            this.statusFacturaDataGridViewTextBoxColumn.DataPropertyName = "StatusFactura";
            this.statusFacturaDataGridViewTextBoxColumn.HeaderText = "Status Doc";
            this.statusFacturaDataGridViewTextBoxColumn.Name = "statusFacturaDataGridViewTextBoxColumn";
            this.statusFacturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // facturaMonedaDataGridViewTextBoxColumn
            // 
            this.facturaMonedaDataGridViewTextBoxColumn.DataPropertyName = "FacturaMoneda";
            this.facturaMonedaDataGridViewTextBoxColumn.HeaderText = "Mon";
            this.facturaMonedaDataGridViewTextBoxColumn.Name = "facturaMonedaDataGridViewTextBoxColumn";
            this.facturaMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.facturaMonedaDataGridViewTextBoxColumn.Width = 40;
            // 
            // tCDataGridViewTextBoxColumn
            // 
            this.tCDataGridViewTextBoxColumn.DataPropertyName = "TC";
            this.tCDataGridViewTextBoxColumn.HeaderText = "TC";
            this.tCDataGridViewTextBoxColumn.Name = "tCDataGridViewTextBoxColumn";
            this.tCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tCDataGridViewTextBoxColumn.Width = 50;
            // 
            // totalFacturaBDataGridViewTextBoxColumn
            // 
            this.totalFacturaBDataGridViewTextBoxColumn.DataPropertyName = "TotalFacturaB";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.totalFacturaBDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.totalFacturaBDataGridViewTextBoxColumn.HeaderText = "Imp Bruto";
            this.totalFacturaBDataGridViewTextBoxColumn.Name = "totalFacturaBDataGridViewTextBoxColumn";
            this.totalFacturaBDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalFacturaBDataGridViewTextBoxColumn.Width = 80;
            // 
            // descuentoDataGridViewTextBoxColumn
            // 
            this.descuentoDataGridViewTextBoxColumn.DataPropertyName = "Descuento";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "0";
            this.descuentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.descuentoDataGridViewTextBoxColumn.HeaderText = "Desc";
            this.descuentoDataGridViewTextBoxColumn.Name = "descuentoDataGridViewTextBoxColumn";
            this.descuentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.descuentoDataGridViewTextBoxColumn.Width = 80;
            // 
            // totalIVA21DataGridViewTextBoxColumn
            // 
            this.totalIVA21DataGridViewTextBoxColumn.DataPropertyName = "TotalIVA21";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "0";
            this.totalIVA21DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.totalIVA21DataGridViewTextBoxColumn.HeaderText = "Imp IVA";
            this.totalIVA21DataGridViewTextBoxColumn.Name = "totalIVA21DataGridViewTextBoxColumn";
            this.totalIVA21DataGridViewTextBoxColumn.ReadOnly = true;
            this.totalIVA21DataGridViewTextBoxColumn.Width = 80;
            // 
            // totalIIBBDataGridViewTextBoxColumn
            // 
            this.totalIIBBDataGridViewTextBoxColumn.DataPropertyName = "TotalIIBB";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = "0";
            this.totalIIBBDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.totalIIBBDataGridViewTextBoxColumn.HeaderText = "Imp IIBB";
            this.totalIIBBDataGridViewTextBoxColumn.Name = "totalIIBBDataGridViewTextBoxColumn";
            this.totalIIBBDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalIIBBDataGridViewTextBoxColumn.Width = 80;
            // 
            // totalFacturaNDataGridViewTextBoxColumn
            // 
            this.totalFacturaNDataGridViewTextBoxColumn.DataPropertyName = "TotalFacturaN";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = "0";
            this.totalFacturaNDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.totalFacturaNDataGridViewTextBoxColumn.HeaderText = "Total NETO";
            this.totalFacturaNDataGridViewTextBoxColumn.Name = "totalFacturaNDataGridViewTextBoxColumn";
            this.totalFacturaNDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalFacturaNDataGridViewTextBoxColumn.Width = 80;
            // 
            // remitoDataGridViewTextBoxColumn
            // 
            this.remitoDataGridViewTextBoxColumn.DataPropertyName = "Remito";
            this.remitoDataGridViewTextBoxColumn.HeaderText = "Remito";
            this.remitoDataGridViewTextBoxColumn.Name = "remitoDataGridViewTextBoxColumn";
            this.remitoDataGridViewTextBoxColumn.ReadOnly = true;
            this.remitoDataGridViewTextBoxColumn.Width = 80;
            // 
            // FrmSeleccionAnulaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1031, 510);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnSeleccion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvListadoFacturas);
            this.Controls.Add(this.panel5);
            this.Name = "FrmSeleccionAnulaFactura";
            this.Text = "SELECCION DE FACTURA A ANULAR";
            this.Load += new System.EventHandler(this.FrmSeleccionAnulaFactura_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0400FACTURAHBindingSource)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.DataGridView dgvListadoFacturas;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId6;
        private System.Windows.Forms.TextBox txtFantasia;
#pragma warning disable CS0169 // The field 'FrmSeleccionAnulaFactura.pVAFIPDataGridViewTextBoxColumn' is never used
        private System.Windows.Forms.DataGridViewTextBoxColumn pVAFIPDataGridViewTextBoxColumn;
#pragma warning restore CS0169 // The field 'FrmSeleccionAnulaFactura.pVAFIPDataGridViewTextBoxColumn' is never used
        private System.Windows.Forms.BindingSource t0400FACTURAHBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDFACTURADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDAFIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPOFACTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusFacturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturaMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFacturaBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalIVA21DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalIIBBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFacturaNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remitoDataGridViewTextBoxColumn;
    }
}