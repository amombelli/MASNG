namespace MASngFE.Transactional.CO
{
    partial class FrmCierre1
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNewFormula = new System.Windows.Forms.Button();
            this.txtPeriodo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFechaDesde = new System.Windows.Forms.TextBox();
            this.txtFechaHasta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckConciliacionCob = new System.Windows.Forms.CheckBox();
            this.ckConciliacionFact = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImporteCobGral = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImporteFactuGral = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImporteFactGral400 = new System.Windows.Forms.TextBox();
            this.txtImporteCobGral205 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvResumenData = new System.Windows.Forms.DataGridView();
            this.periodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cob205DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cob201DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factu400DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factu201DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.okCobDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.okFactuDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.retornoConciliacionBs = new System.Windows.Forms.BindingSource(this.components);
            this.txtCantidadPeriodos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckL2 = new System.Windows.Forms.CheckBox();
            this.ckL1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.retornoConciliacionBs)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNewFormula);
            this.panel3.Location = new System.Drawing.Point(1061, 174);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(113, 90);
            this.panel3.TabIndex = 30;
            // 
            // btnNewFormula
            // 
            this.btnNewFormula.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewFormula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewFormula.Location = new System.Drawing.Point(6, 5);
            this.btnNewFormula.Name = "btnNewFormula";
            this.btnNewFormula.Size = new System.Drawing.Size(100, 40);
            this.btnNewFormula.TabIndex = 26;
            this.btnNewFormula.Text = "CREAR\r\nBOM";
            this.btnNewFormula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewFormula.UseVisualStyleBackColor = true;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.AllowPromptAsInput = false;
            this.txtPeriodo.BeepOnError = true;
            this.txtPeriodo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtPeriodo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtPeriodo.Location = new System.Drawing.Point(92, 30);
            this.txtPeriodo.Mask = "0000-00";
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(51, 20);
            this.txtPeriodo.TabIndex = 32;
            this.txtPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPeriodo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.toolTip1.SetToolTip(this.txtPeriodo, "Formato 2018-12");
            this.txtPeriodo.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.txtPeriodo_TypeValidationCompleted);
            this.txtPeriodo.Validating += new System.ComponentModel.CancelEventHandler(this.txtPeriodo_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Periodo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Fecha Desde";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(92, 52);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.txtFechaDesde.TabIndex = 35;
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(92, 73);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.txtFechaHasta.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Fecha Hasta";
            // 
            // ckConciliacionCob
            // 
            this.ckConciliacionCob.AutoSize = true;
            this.ckConciliacionCob.Location = new System.Drawing.Point(454, 8);
            this.ckConciliacionCob.Name = "ckConciliacionCob";
            this.ckConciliacionCob.Size = new System.Drawing.Size(258, 17);
            this.ckConciliacionCob.TabIndex = 38;
            this.ckConciliacionCob.Text = "ResumenConciliacionGeneral General Cobranzas";
            this.ckConciliacionCob.UseVisualStyleBackColor = true;
            // 
            // ckConciliacionFact
            // 
            this.ckConciliacionFact.AutoSize = true;
            this.ckConciliacionFact.Location = new System.Drawing.Point(454, 31);
            this.ckConciliacionFact.Name = "ckConciliacionFact";
            this.ckConciliacionFact.Size = new System.Drawing.Size(323, 17);
            this.ckConciliacionFact.TabIndex = 39;
            this.ckConciliacionFact.Text = "ResumenConciliacionGeneral General Facturacion [FA-NC-ND]";
            this.ckConciliacionFact.UseVisualStyleBackColor = true;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(92, 8);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Fecha Hoy";
            // 
            // txtImporteCobGral
            // 
            this.txtImporteCobGral.Location = new System.Drawing.Point(108, 128);
            this.txtImporteCobGral.Name = "txtImporteCobGral";
            this.txtImporteCobGral.ReadOnly = true;
            this.txtImporteCobGral.Size = new System.Drawing.Size(109, 20);
            this.txtImporteCobGral.TabIndex = 43;
            this.txtImporteCobGral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Importe Cobranza";
            // 
            // txtImporteFactuGral
            // 
            this.txtImporteFactuGral.Location = new System.Drawing.Point(108, 150);
            this.txtImporteFactuGral.Name = "txtImporteFactuGral";
            this.txtImporteFactuGral.ReadOnly = true;
            this.txtImporteFactuGral.Size = new System.Drawing.Size(109, 20);
            this.txtImporteFactuGral.TabIndex = 45;
            this.txtImporteFactuGral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Importe Factura";
            // 
            // txtImporteFactGral400
            // 
            this.txtImporteFactGral400.Location = new System.Drawing.Point(220, 150);
            this.txtImporteFactGral400.Name = "txtImporteFactGral400";
            this.txtImporteFactGral400.ReadOnly = true;
            this.txtImporteFactGral400.Size = new System.Drawing.Size(109, 20);
            this.txtImporteFactGral400.TabIndex = 47;
            this.txtImporteFactGral400.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtImporteCobGral205
            // 
            this.txtImporteCobGral205.Location = new System.Drawing.Point(220, 128);
            this.txtImporteCobGral205.Name = "txtImporteCobGral205";
            this.txtImporteCobGral205.ReadOnly = true;
            this.txtImporteCobGral205.Size = new System.Drawing.Size(109, 20);
            this.txtImporteCobGral205.TabIndex = 46;
            this.txtImporteCobGral205.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(224, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "SubModulo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(116, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "CTACTE";
            // 
            // dgvResumenData
            // 
            this.dgvResumenData.AllowUserToAddRows = false;
            this.dgvResumenData.AllowUserToDeleteRows = false;
            this.dgvResumenData.AutoGenerateColumns = false;
            this.dgvResumenData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumenData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.periodoDataGridViewTextBoxColumn,
            this.cob205DataGridViewTextBoxColumn,
            this.cob201DataGridViewTextBoxColumn,
            this.factu400DataGridViewTextBoxColumn,
            this.factu201DataGridViewTextBoxColumn,
            this.okCobDataGridViewCheckBoxColumn,
            this.okFactuDataGridViewCheckBoxColumn});
            this.dgvResumenData.DataSource = this.retornoConciliacionBs;
            this.dgvResumenData.Location = new System.Drawing.Point(4, 175);
            this.dgvResumenData.Name = "dgvResumenData";
            this.dgvResumenData.ReadOnly = true;
            this.dgvResumenData.Size = new System.Drawing.Size(679, 451);
            this.dgvResumenData.TabIndex = 50;
            this.dgvResumenData.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResumenData_CellContentDoubleClick);
            // 
            // periodoDataGridViewTextBoxColumn
            // 
            this.periodoDataGridViewTextBoxColumn.DataPropertyName = "Periodo";
            this.periodoDataGridViewTextBoxColumn.HeaderText = "Periodo";
            this.periodoDataGridViewTextBoxColumn.Name = "periodoDataGridViewTextBoxColumn";
            this.periodoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cob205DataGridViewTextBoxColumn
            // 
            this.cob205DataGridViewTextBoxColumn.DataPropertyName = "Cob205";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.cob205DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.cob205DataGridViewTextBoxColumn.HeaderText = "Cob205";
            this.cob205DataGridViewTextBoxColumn.Name = "cob205DataGridViewTextBoxColumn";
            this.cob205DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cob201DataGridViewTextBoxColumn
            // 
            this.cob201DataGridViewTextBoxColumn.DataPropertyName = "Cob201";
            dataGridViewCellStyle2.Format = "C2";
            this.cob201DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cob201DataGridViewTextBoxColumn.HeaderText = "Cob201";
            this.cob201DataGridViewTextBoxColumn.Name = "cob201DataGridViewTextBoxColumn";
            this.cob201DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factu400DataGridViewTextBoxColumn
            // 
            this.factu400DataGridViewTextBoxColumn.DataPropertyName = "Factu400";
            dataGridViewCellStyle3.Format = "C2";
            this.factu400DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.factu400DataGridViewTextBoxColumn.HeaderText = "Factu400";
            this.factu400DataGridViewTextBoxColumn.Name = "factu400DataGridViewTextBoxColumn";
            this.factu400DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factu201DataGridViewTextBoxColumn
            // 
            this.factu201DataGridViewTextBoxColumn.DataPropertyName = "Factu201";
            dataGridViewCellStyle4.Format = "C2";
            this.factu201DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.factu201DataGridViewTextBoxColumn.HeaderText = "Factu201";
            this.factu201DataGridViewTextBoxColumn.Name = "factu201DataGridViewTextBoxColumn";
            this.factu201DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // okCobDataGridViewCheckBoxColumn
            // 
            this.okCobDataGridViewCheckBoxColumn.DataPropertyName = "OkCob";
            this.okCobDataGridViewCheckBoxColumn.HeaderText = "OkCob";
            this.okCobDataGridViewCheckBoxColumn.Name = "okCobDataGridViewCheckBoxColumn";
            this.okCobDataGridViewCheckBoxColumn.ReadOnly = true;
            this.okCobDataGridViewCheckBoxColumn.Width = 60;
            // 
            // okFactuDataGridViewCheckBoxColumn
            // 
            this.okFactuDataGridViewCheckBoxColumn.DataPropertyName = "OkFactu";
            this.okFactuDataGridViewCheckBoxColumn.HeaderText = "OkFactu";
            this.okFactuDataGridViewCheckBoxColumn.Name = "okFactuDataGridViewCheckBoxColumn";
            this.okFactuDataGridViewCheckBoxColumn.ReadOnly = true;
            this.okFactuDataGridViewCheckBoxColumn.Width = 60;
            // 
            // retornoConciliacionBs
            // 
            this.retornoConciliacionBs.DataSource = typeof(Tecser.Business.Transactional.Cierre.RetornaConciliacion);
            // 
            // txtCantidadPeriodos
            // 
            this.txtCantidadPeriodos.Location = new System.Drawing.Point(164, 30);
            this.txtCantidadPeriodos.Name = "txtCantidadPeriodos";
            this.txtCantidadPeriodos.Size = new System.Drawing.Size(28, 20);
            this.txtCantidadPeriodos.TabIndex = 51;
            this.txtCantidadPeriodos.Text = "1";
            this.txtCantidadPeriodos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidadPeriodos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadPeriodos_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "#";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ckL2);
            this.panel1.Controls.Add(this.ckL1);
            this.panel1.Location = new System.Drawing.Point(194, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 41);
            this.panel1.TabIndex = 53;
            // 
            // ckL2
            // 
            this.ckL2.AutoSize = true;
            this.ckL2.Location = new System.Drawing.Point(9, 22);
            this.ckL2.Name = "ckL2";
            this.ckL2.Size = new System.Drawing.Size(38, 17);
            this.ckL2.TabIndex = 1;
            this.ckL2.Text = "L2";
            this.ckL2.UseVisualStyleBackColor = true;
            this.ckL2.CheckedChanged += new System.EventHandler(this.ckL2_CheckedChanged);
            // 
            // ckL1
            // 
            this.ckL1.AutoSize = true;
            this.ckL1.Location = new System.Drawing.Point(9, 3);
            this.ckL1.Name = "ckL1";
            this.ckL1.Size = new System.Drawing.Size(38, 17);
            this.ckL1.TabIndex = 0;
            this.ckL1.Text = "L1";
            this.ckL1.UseVisualStyleBackColor = true;
            this.ckL1.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.txtPeriodo);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCantidadPeriodos);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtFechaDesde);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtFechaHasta);
            this.panel2.Controls.Add(this.txtFecha);
            this.panel2.Location = new System.Drawing.Point(4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 101);
            this.panel2.TabIndex = 54;
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun.Location = new System.Drawing.Point(1074, 52);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 40);
            this.btnRun.TabIndex = 31;
            this.btnRun.Text = "RUN";
            this.btnRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(1074, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // FrmCierre1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 1061);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvResumenData);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtImporteFactGral400);
            this.Controls.Add(this.txtImporteCobGral205);
            this.Controls.Add(this.txtImporteFactuGral);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtImporteCobGral);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ckConciliacionFact);
            this.Controls.Add(this.ckConciliacionCob);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmCierre1";
            this.Text = "FrmCierre1";
            this.Load += new System.EventHandler(this.FrmCierre1_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.retornoConciliacionBs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNewFormula;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.MaskedTextBox txtPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFechaDesde;
        private System.Windows.Forms.TextBox txtFechaHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckConciliacionCob;
        private System.Windows.Forms.CheckBox ckConciliacionFact;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtImporteCobGral;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImporteFactuGral;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtImporteFactGral400;
        private System.Windows.Forms.TextBox txtImporteCobGral205;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvResumenData;
        private System.Windows.Forms.BindingSource retornoConciliacionBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cob205DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cob201DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factu400DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factu201DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn okCobDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn okFactuDataGridViewCheckBoxColumn;
        private System.Windows.Forms.TextBox txtCantidadPeriodos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckL2;
        private System.Windows.Forms.CheckBox ckL1;
        private System.Windows.Forms.Panel panel2;
    }
}