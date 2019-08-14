namespace MASngFE.Transactional.CRM
{
    partial class FrmCRM02GescoSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCRM02GescoSelect));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCallRequest = new System.Windows.Forms.RadioButton();
            this.rbConciliacionRequest = new System.Windows.Forms.RadioButton();
            this.rbLimiteExcedido = new System.Windows.Forms.RadioButton();
            this.rbProximaLlamada = new System.Windows.Forms.RadioButton();
            this.rbDocumentosImpagos = new System.Windows.Forms.RadioButton();
            this.rbMayorDeuda = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvListadoGesco = new System.Windows.Forms.DataGridView();
            this.idClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteRsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteFantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoL1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoL2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limiteCreditoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentosImpagosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conciliarCtaRequestDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.callRequestDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.proximaLlamadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VER = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gescoStructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoGesco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gescoStructureBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.rbCallRequest);
            this.panel1.Controls.Add(this.rbConciliacionRequest);
            this.panel1.Controls.Add(this.rbLimiteExcedido);
            this.panel1.Controls.Add(this.rbProximaLlamada);
            this.panel1.Controls.Add(this.rbDocumentosImpagos);
            this.panel1.Controls.Add(this.rbMayorDeuda);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(4, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 53);
            this.panel1.TabIndex = 159;
            // 
            // rbCallRequest
            // 
            this.rbCallRequest.AutoSize = true;
            this.rbCallRequest.Location = new System.Drawing.Point(454, 25);
            this.rbCallRequest.Name = "rbCallRequest";
            this.rbCallRequest.Size = new System.Drawing.Size(100, 18);
            this.rbCallRequest.TabIndex = 99;
            this.rbCallRequest.TabStop = true;
            this.rbCallRequest.Text = "CALL Request!";
            this.rbCallRequest.UseVisualStyleBackColor = true;
            this.rbCallRequest.CheckedChanged += new System.EventHandler(this.rbCallRequest_CheckedChanged);
            // 
            // rbConciliacionRequest
            // 
            this.rbConciliacionRequest.AutoSize = true;
            this.rbConciliacionRequest.Location = new System.Drawing.Point(235, 25);
            this.rbConciliacionRequest.Name = "rbConciliacionRequest";
            this.rbConciliacionRequest.Size = new System.Drawing.Size(152, 18);
            this.rbConciliacionRequest.TabIndex = 97;
            this.rbConciliacionRequest.TabStop = true;
            this.rbConciliacionRequest.Text = "Conciliacion Requerida";
            this.rbConciliacionRequest.UseVisualStyleBackColor = true;
            this.rbConciliacionRequest.CheckedChanged += new System.EventHandler(this.rbCallRequest_CheckedChanged);
            // 
            // rbLimiteExcedido
            // 
            this.rbLimiteExcedido.AutoSize = true;
            this.rbLimiteExcedido.Location = new System.Drawing.Point(235, 4);
            this.rbLimiteExcedido.Name = "rbLimiteExcedido";
            this.rbLimiteExcedido.Size = new System.Drawing.Size(110, 18);
            this.rbLimiteExcedido.TabIndex = 96;
            this.rbLimiteExcedido.TabStop = true;
            this.rbLimiteExcedido.Text = "Limite Excedido";
            this.rbLimiteExcedido.UseVisualStyleBackColor = true;
            this.rbLimiteExcedido.CheckedChanged += new System.EventHandler(this.rbCallRequest_CheckedChanged);
            // 
            // rbProximaLlamada
            // 
            this.rbProximaLlamada.AutoSize = true;
            this.rbProximaLlamada.Location = new System.Drawing.Point(454, 4);
            this.rbProximaLlamada.Name = "rbProximaLlamada";
            this.rbProximaLlamada.Size = new System.Drawing.Size(118, 18);
            this.rbProximaLlamada.TabIndex = 98;
            this.rbProximaLlamada.TabStop = true;
            this.rbProximaLlamada.Text = "Proxima Llamada";
            this.rbProximaLlamada.UseVisualStyleBackColor = true;
            this.rbProximaLlamada.CheckedChanged += new System.EventHandler(this.rbCallRequest_CheckedChanged);
            // 
            // rbDocumentosImpagos
            // 
            this.rbDocumentosImpagos.AutoSize = true;
            this.rbDocumentosImpagos.Location = new System.Drawing.Point(12, 25);
            this.rbDocumentosImpagos.Name = "rbDocumentosImpagos";
            this.rbDocumentosImpagos.Size = new System.Drawing.Size(152, 18);
            this.rbDocumentosImpagos.TabIndex = 95;
            this.rbDocumentosImpagos.TabStop = true;
            this.rbDocumentosImpagos.Text = "# Documentos Impagos";
            this.rbDocumentosImpagos.UseVisualStyleBackColor = true;
            this.rbDocumentosImpagos.CheckedChanged += new System.EventHandler(this.rbCallRequest_CheckedChanged);
            // 
            // rbMayorDeuda
            // 
            this.rbMayorDeuda.AutoSize = true;
            this.rbMayorDeuda.Location = new System.Drawing.Point(12, 4);
            this.rbMayorDeuda.Name = "rbMayorDeuda";
            this.rbMayorDeuda.Size = new System.Drawing.Size(97, 18);
            this.rbMayorDeuda.TabIndex = 94;
            this.rbMayorDeuda.TabStop = true;
            this.rbMayorDeuda.Text = "Mayor Deuda";
            this.rbMayorDeuda.UseVisualStyleBackColor = true;
            this.rbMayorDeuda.CheckedChanged += new System.EventHandler(this.rbCallRequest_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(-172, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(70, 22);
            this.textBox1.TabIndex = 93;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-250, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 14);
            this.label4.TabIndex = 44;
            this.label4.Text = "Numero RC";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(904, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 42);
            this.btnClose.TabIndex = 160;
            this.btnClose.Text = "SALIR";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvListadoGesco
            // 
            this.dgvListadoGesco.AllowUserToAddRows = false;
            this.dgvListadoGesco.AllowUserToDeleteRows = false;
            this.dgvListadoGesco.AutoGenerateColumns = false;
            this.dgvListadoGesco.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvListadoGesco.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListadoGesco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListadoGesco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idClienteDataGridViewTextBoxColumn,
            this.clienteRsDataGridViewTextBoxColumn,
            this.clienteFantasiaDataGridViewTextBoxColumn,
            this.saldoL1DataGridViewTextBoxColumn,
            this.saldoL2DataGridViewTextBoxColumn,
            this.saldoTotalDataGridViewTextBoxColumn,
            this.limiteCreditoDataGridViewTextBoxColumn,
            this.documentosImpagosDataGridViewTextBoxColumn,
            this.conciliarCtaRequestDataGridViewCheckBoxColumn,
            this.callRequestDataGridViewCheckBoxColumn,
            this.proximaLlamadaDataGridViewTextBoxColumn,
            this.VER});
            this.dgvListadoGesco.DataSource = this.gescoStructureBindingSource;
            this.dgvListadoGesco.GridColor = System.Drawing.Color.DarkSeaGreen;
            this.dgvListadoGesco.Location = new System.Drawing.Point(4, 65);
            this.dgvListadoGesco.Name = "dgvListadoGesco";
            this.dgvListadoGesco.ReadOnly = true;
            this.dgvListadoGesco.RowHeadersWidth = 20;
            this.dgvListadoGesco.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvListadoGesco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoGesco.Size = new System.Drawing.Size(1007, 617);
            this.dgvListadoGesco.TabIndex = 162;
            this.dgvListadoGesco.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoGesco_CellContentClick);
            // 
            // idClienteDataGridViewTextBoxColumn
            // 
            this.idClienteDataGridViewTextBoxColumn.DataPropertyName = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.HeaderText = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.Name = "idClienteDataGridViewTextBoxColumn";
            this.idClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idClienteDataGridViewTextBoxColumn.Visible = false;
            // 
            // clienteRsDataGridViewTextBoxColumn
            // 
            this.clienteRsDataGridViewTextBoxColumn.DataPropertyName = "ClienteRs";
            this.clienteRsDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.clienteRsDataGridViewTextBoxColumn.Name = "clienteRsDataGridViewTextBoxColumn";
            this.clienteRsDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteRsDataGridViewTextBoxColumn.Width = 180;
            // 
            // clienteFantasiaDataGridViewTextBoxColumn
            // 
            this.clienteFantasiaDataGridViewTextBoxColumn.DataPropertyName = "ClienteFantasia";
            this.clienteFantasiaDataGridViewTextBoxColumn.HeaderText = "Fantasia";
            this.clienteFantasiaDataGridViewTextBoxColumn.Name = "clienteFantasiaDataGridViewTextBoxColumn";
            this.clienteFantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteFantasiaDataGridViewTextBoxColumn.Width = 180;
            // 
            // saldoL1DataGridViewTextBoxColumn
            // 
            this.saldoL1DataGridViewTextBoxColumn.DataPropertyName = "SaldoL1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C0";
            dataGridViewCellStyle2.NullValue = "0";
            this.saldoL1DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.saldoL1DataGridViewTextBoxColumn.HeaderText = "SaldoL1";
            this.saldoL1DataGridViewTextBoxColumn.Name = "saldoL1DataGridViewTextBoxColumn";
            this.saldoL1DataGridViewTextBoxColumn.ReadOnly = true;
            this.saldoL1DataGridViewTextBoxColumn.Width = 70;
            // 
            // saldoL2DataGridViewTextBoxColumn
            // 
            this.saldoL2DataGridViewTextBoxColumn.DataPropertyName = "SaldoL2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C0";
            dataGridViewCellStyle3.NullValue = "0";
            this.saldoL2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.saldoL2DataGridViewTextBoxColumn.HeaderText = "SaldoL2";
            this.saldoL2DataGridViewTextBoxColumn.Name = "saldoL2DataGridViewTextBoxColumn";
            this.saldoL2DataGridViewTextBoxColumn.ReadOnly = true;
            this.saldoL2DataGridViewTextBoxColumn.Width = 70;
            // 
            // saldoTotalDataGridViewTextBoxColumn
            // 
            this.saldoTotalDataGridViewTextBoxColumn.DataPropertyName = "SaldoTotal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Format = "C0";
            dataGridViewCellStyle4.NullValue = "0";
            this.saldoTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.saldoTotalDataGridViewTextBoxColumn.HeaderText = "SaldoTotal";
            this.saldoTotalDataGridViewTextBoxColumn.Name = "saldoTotalDataGridViewTextBoxColumn";
            this.saldoTotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.saldoTotalDataGridViewTextBoxColumn.Width = 70;
            // 
            // limiteCreditoDataGridViewTextBoxColumn
            // 
            this.limiteCreditoDataGridViewTextBoxColumn.DataPropertyName = "LimiteCredito";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "C0";
            dataGridViewCellStyle5.NullValue = "0";
            this.limiteCreditoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.limiteCreditoDataGridViewTextBoxColumn.HeaderText = "Credito";
            this.limiteCreditoDataGridViewTextBoxColumn.Name = "limiteCreditoDataGridViewTextBoxColumn";
            this.limiteCreditoDataGridViewTextBoxColumn.ReadOnly = true;
            this.limiteCreditoDataGridViewTextBoxColumn.Width = 70;
            // 
            // documentosImpagosDataGridViewTextBoxColumn
            // 
            this.documentosImpagosDataGridViewTextBoxColumn.DataPropertyName = "DocumentosImpagos";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.documentosImpagosDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.documentosImpagosDataGridViewTextBoxColumn.HeaderText = "#Impagos";
            this.documentosImpagosDataGridViewTextBoxColumn.Name = "documentosImpagosDataGridViewTextBoxColumn";
            this.documentosImpagosDataGridViewTextBoxColumn.ReadOnly = true;
            this.documentosImpagosDataGridViewTextBoxColumn.Width = 70;
            // 
            // conciliarCtaRequestDataGridViewCheckBoxColumn
            // 
            this.conciliarCtaRequestDataGridViewCheckBoxColumn.DataPropertyName = "ConciliarCtaRequest";
            this.conciliarCtaRequestDataGridViewCheckBoxColumn.HeaderText = "CONCIL";
            this.conciliarCtaRequestDataGridViewCheckBoxColumn.Name = "conciliarCtaRequestDataGridViewCheckBoxColumn";
            this.conciliarCtaRequestDataGridViewCheckBoxColumn.ReadOnly = true;
            this.conciliarCtaRequestDataGridViewCheckBoxColumn.Width = 50;
            // 
            // callRequestDataGridViewCheckBoxColumn
            // 
            this.callRequestDataGridViewCheckBoxColumn.DataPropertyName = "CallRequest";
            this.callRequestDataGridViewCheckBoxColumn.HeaderText = "CALL";
            this.callRequestDataGridViewCheckBoxColumn.Name = "callRequestDataGridViewCheckBoxColumn";
            this.callRequestDataGridViewCheckBoxColumn.ReadOnly = true;
            this.callRequestDataGridViewCheckBoxColumn.Width = 50;
            // 
            // proximaLlamadaDataGridViewTextBoxColumn
            // 
            this.proximaLlamadaDataGridViewTextBoxColumn.DataPropertyName = "ProximaLlamada";
            this.proximaLlamadaDataGridViewTextBoxColumn.HeaderText = "ProximaLlamada";
            this.proximaLlamadaDataGridViewTextBoxColumn.Name = "proximaLlamadaDataGridViewTextBoxColumn";
            this.proximaLlamadaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // VER
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            this.VER.DefaultCellStyle = dataGridViewCellStyle7;
            this.VER.HeaderText = "VER";
            this.VER.Name = "VER";
            this.VER.ReadOnly = true;
            this.VER.Text = "VER";
            this.VER.ToolTipText = "Ingresar al GESCO";
            this.VER.UseColumnTextForButtonValue = true;
            this.VER.Width = 50;
            // 
            // gescoStructureBindingSource
            // 
            this.gescoStructureBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.GescoStructure);
            // 
            // FrmCRM02GescoSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 687);
            this.Controls.Add(this.dgvListadoGesco);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCRM02GescoSelect";
            this.Text = "CRM02 - Gestion Cobranzas - Seleccion";
            this.Load += new System.EventHandler(this.FrmCRM02GescoSelect_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoGesco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gescoStructureBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbConciliacionRequest;
        private System.Windows.Forms.RadioButton rbLimiteExcedido;
        private System.Windows.Forms.RadioButton rbDocumentosImpagos;
        private System.Windows.Forms.RadioButton rbMayorDeuda;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvListadoGesco;
        private System.Windows.Forms.BindingSource gescoStructureBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteRsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteFantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoL1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoL2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn limiteCreditoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentosImpagosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn conciliarCtaRequestDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn callRequestDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proximaLlamadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn VER;
        private System.Windows.Forms.RadioButton rbCallRequest;
        private System.Windows.Forms.RadioButton rbProximaLlamada;
    }
}