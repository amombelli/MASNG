namespace MASngFE.Transactional.CO.Cost
{
    partial class FrmCO06MfgCostExplosion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.itemsBs = new System.Windows.Forms.BindingSource(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCostoStandard = new System.Windows.Forms.RadioButton();
            this.rbUC = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tc = new MASngFE._UserControls.DecimalTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMonedaCost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFormulaDescription = new System.Windows.Forms.TextBox();
            this.txtIdFormula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMtype = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.materialFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoPropDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCostoUSD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCostoARS = new System.Windows.Forms.TextBox();
            this.txtmaterial = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBs)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materialFDataGridViewTextBoxColumn,
            this.itemMPDataGridViewTextBoxColumn,
            this.monedaDataGridViewTextBoxColumn,
            this.costoUnitDataGridViewTextBoxColumn,
            this.propDataGridViewTextBoxColumn,
            this.costoPropDataGridViewTextBoxColumn});
            this.dgvItems.DataSource = this.itemsBs;
            this.dgvItems.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvItems.Location = new System.Drawing.Point(5, 140);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersWidth = 20;
            this.dgvItems.Size = new System.Drawing.Size(500, 442);
            this.dgvItems.TabIndex = 0;
            // 
            // itemsBs
            // 
            this.itemsBs.DataSource = typeof(TecserEF.Entity.DataStructure.CostItems);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(665, 93);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 119;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Khaki;
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Location = new System.Drawing.Point(5, 89);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(285, 45);
            this.panel5.TabIndex = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCostoStandard);
            this.groupBox1.Controls.Add(this.rbUC);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 39);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbCostoStandard
            // 
            this.rbCostoStandard.AutoSize = true;
            this.rbCostoStandard.Location = new System.Drawing.Point(164, 13);
            this.rbCostoStandard.Name = "rbCostoStandard";
            this.rbCostoStandard.Size = new System.Drawing.Size(98, 17);
            this.rbCostoStandard.TabIndex = 1;
            this.rbCostoStandard.TabStop = true;
            this.rbCostoStandard.Text = "Costo Standard";
            this.rbCostoStandard.UseVisualStyleBackColor = true;
            // 
            // rbUC
            // 
            this.rbUC.AutoSize = true;
            this.rbUC.Location = new System.Drawing.Point(12, 13);
            this.rbUC.Name = "rbUC";
            this.rbUC.Size = new System.Drawing.Size(102, 17);
            this.rbUC.TabIndex = 0;
            this.rbUC.TabStop = true;
            this.rbUC.Text = "Reposicion (UC)";
            this.rbUC.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.txtmaterial);
            this.panel1.Controls.Add(this.tc);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtMonedaCost);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtFormulaDescription);
            this.panel1.Controls.Add(this.txtIdFormula);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtOrigen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMtype);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(5, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 85);
            this.panel1.TabIndex = 121;
            // 
            // tc
            // 
            this.tc.BackColor = System.Drawing.SystemColors.Control;
            this.tc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tc.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tc.Location = new System.Drawing.Point(693, 53);
            this.tc.Name = "tc";
            this.tc.Size = new System.Drawing.Size(57, 21);
            this.tc.TabIndex = 122;
            this.tc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(610, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 103;
            this.label6.Text = "Tipo Cambio";
            // 
            // txtMonedaCost
            // 
            this.txtMonedaCost.Location = new System.Drawing.Point(693, 31);
            this.txtMonedaCost.Name = "txtMonedaCost";
            this.txtMonedaCost.ReadOnly = true;
            this.txtMonedaCost.Size = new System.Drawing.Size(57, 21);
            this.txtMonedaCost.TabIndex = 100;
            this.txtMonedaCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(600, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 101;
            this.label5.Text = "Moneda Costo";
            // 
            // txtFormulaDescription
            // 
            this.txtFormulaDescription.Location = new System.Drawing.Point(130, 53);
            this.txtFormulaDescription.Name = "txtFormulaDescription";
            this.txtFormulaDescription.ReadOnly = true;
            this.txtFormulaDescription.Size = new System.Drawing.Size(460, 21);
            this.txtFormulaDescription.TabIndex = 95;
            // 
            // txtIdFormula
            // 
            this.txtIdFormula.Location = new System.Drawing.Point(68, 53);
            this.txtIdFormula.Name = "txtIdFormula";
            this.txtIdFormula.ReadOnly = true;
            this.txtIdFormula.Size = new System.Drawing.Size(61, 21);
            this.txtIdFormula.TabIndex = 94;
            this.txtIdFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 93;
            this.label3.Text = "Formula";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(68, 31);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.ReadOnly = true;
            this.txtOrigen.Size = new System.Drawing.Size(61, 21);
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
            this.txtMtype.Location = new System.Drawing.Point(693, 9);
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
            this.txtDescripcion.Size = new System.Drawing.Size(463, 21);
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
            // materialFDataGridViewTextBoxColumn
            // 
            this.materialFDataGridViewTextBoxColumn.DataPropertyName = "Padre";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialFDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.materialFDataGridViewTextBoxColumn.HeaderText = "MaterialF";
            this.materialFDataGridViewTextBoxColumn.Name = "materialFDataGridViewTextBoxColumn";
            this.materialFDataGridViewTextBoxColumn.ReadOnly = true;
            this.materialFDataGridViewTextBoxColumn.Width = 110;
            // 
            // itemMPDataGridViewTextBoxColumn
            // 
            this.itemMPDataGridViewTextBoxColumn.DataPropertyName = "ItemMP";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.itemMPDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.itemMPDataGridViewTextBoxColumn.HeaderText = "Item MP";
            this.itemMPDataGridViewTextBoxColumn.Name = "itemMPDataGridViewTextBoxColumn";
            this.itemMPDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemMPDataGridViewTextBoxColumn.Width = 110;
            // 
            // monedaDataGridViewTextBoxColumn
            // 
            this.monedaDataGridViewTextBoxColumn.DataPropertyName = "Moneda";
            this.monedaDataGridViewTextBoxColumn.HeaderText = "Mon";
            this.monedaDataGridViewTextBoxColumn.Name = "monedaDataGridViewTextBoxColumn";
            this.monedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.monedaDataGridViewTextBoxColumn.Width = 40;
            // 
            // costoUnitDataGridViewTextBoxColumn
            // 
            this.costoUnitDataGridViewTextBoxColumn.DataPropertyName = "CostoUnit";
            dataGridViewCellStyle8.Format = "C3";
            dataGridViewCellStyle8.NullValue = "0";
            this.costoUnitDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.costoUnitDataGridViewTextBoxColumn.HeaderText = "C.Unit";
            this.costoUnitDataGridViewTextBoxColumn.Name = "costoUnitDataGridViewTextBoxColumn";
            this.costoUnitDataGridViewTextBoxColumn.ReadOnly = true;
            this.costoUnitDataGridViewTextBoxColumn.Width = 70;
            // 
            // propDataGridViewTextBoxColumn
            // 
            this.propDataGridViewTextBoxColumn.DataPropertyName = "Prop";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "P4";
            this.propDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.propDataGridViewTextBoxColumn.HeaderText = "Prop";
            this.propDataGridViewTextBoxColumn.Name = "propDataGridViewTextBoxColumn";
            this.propDataGridViewTextBoxColumn.ReadOnly = true;
            this.propDataGridViewTextBoxColumn.Width = 70;
            // 
            // costoPropDataGridViewTextBoxColumn
            // 
            this.costoPropDataGridViewTextBoxColumn.DataPropertyName = "CostoProp";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.Format = "C4";
            dataGridViewCellStyle10.NullValue = "0";
            this.costoPropDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.costoPropDataGridViewTextBoxColumn.HeaderText = "Costo";
            this.costoPropDataGridViewTextBoxColumn.Name = "costoPropDataGridViewTextBoxColumn";
            this.costoPropDataGridViewTextBoxColumn.ReadOnly = true;
            this.costoPropDataGridViewTextBoxColumn.Width = 70;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 125;
            this.label4.Text = "Costo ARS";
            // 
            // txtCostoUSD
            // 
            this.txtCostoUSD.Location = new System.Drawing.Point(406, 93);
            this.txtCostoUSD.Name = "txtCostoUSD";
            this.txtCostoUSD.ReadOnly = true;
            this.txtCostoUSD.Size = new System.Drawing.Size(99, 20);
            this.txtCostoUSD.TabIndex = 123;
            this.txtCostoUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(340, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 124;
            this.label7.Text = "Costo USD";
            // 
            // txtCostoARS
            // 
            this.txtCostoARS.Location = new System.Drawing.Point(406, 114);
            this.txtCostoARS.Name = "txtCostoARS";
            this.txtCostoARS.ReadOnly = true;
            this.txtCostoARS.Size = new System.Drawing.Size(99, 20);
            this.txtCostoARS.TabIndex = 126;
            this.txtCostoARS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtmaterial
            // 
            this.txtmaterial.Location = new System.Drawing.Point(68, 9);
            this.txtmaterial.Name = "txtmaterial";
            this.txtmaterial.ReadOnly = true;
            this.txtmaterial.Size = new System.Drawing.Size(160, 21);
            this.txtmaterial.TabIndex = 123;
            // 
            // FrmCO06MfgCostExplosion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 588);
            this.ControlBox = false;
            this.Controls.Add(this.txtCostoARS);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.txtCostoUSD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvItems);
            this.Name = "FrmCO06MfgCostExplosion";
            this.Text = "CO06 Explosion de Costo de Manufactura";
            this.Load += new System.EventHandler(this.FrmCO06MfgCostExplosion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBs)).EndInit();
            this.panel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.BindingSource itemsBs;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCostoStandard;
        private System.Windows.Forms.RadioButton rbUC;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn propDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoPropDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private _UserControls.DecimalTextBox tc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMonedaCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFormulaDescription;
        private System.Windows.Forms.TextBox txtIdFormula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMtype;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCostoUSD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCostoARS;
        private System.Windows.Forms.TextBox txtmaterial;
    }
}