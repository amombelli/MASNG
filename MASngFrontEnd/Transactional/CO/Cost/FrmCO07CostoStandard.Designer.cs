namespace MASngFE.Transactional.CO.Cost
{
    partial class FrmCO07CostoStandard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCO07CostoStandard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMtype = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCostDeterminedBy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCostoUsd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCostoArs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckManualUpdated = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCostoReferencia = new System.Windows.Forms.TextBox();
            this.txtMonedaReferencia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFechaCostoRef = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCostoRefUsd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCostoRefArs = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnUpdateUC = new System.Windows.Forms.Button();
            this.btnSetAsStandard = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tc = new MASngFE._UserControls.DecimalTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tc);
            this.panel1.Controls.Add(this.txtOrigen);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtMtype);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.cmbMaterial);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 86);
            this.panel1.TabIndex = 88;
            // 
            // txtOrigen
            // 
            this.txtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrigen.Location = new System.Drawing.Point(68, 30);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.ReadOnly = true;
            this.txtOrigen.Size = new System.Drawing.Size(57, 21);
            this.txtOrigen.TabIndex = 92;
            this.txtOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 15);
            this.label14.TabIndex = 91;
            this.label14.Text = "Origen";
            // 
            // txtMtype
            // 
            this.txtMtype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMtype.Location = new System.Drawing.Point(591, 7);
            this.txtMtype.Name = "txtMtype";
            this.txtMtype.ReadOnly = true;
            this.txtMtype.Size = new System.Drawing.Size(57, 21);
            this.txtMtype.TabIndex = 90;
            this.txtMtype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Location = new System.Drawing.Point(229, 7);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(360, 21);
            this.txtDescripcion.TabIndex = 89;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.BackColor = System.Drawing.Color.White;
            this.cmbMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(68, 7);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(159, 21);
            this.cmbMaterial.TabIndex = 88;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
            this.cmbMaterial.Validating += new System.ComponentModel.CancelEventHandler(this.CmbMaterial_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 87;
            this.label1.Text = "Material";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSlateGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(658, 19);
            this.label6.TabIndex = 134;
            this.label6.Text = "COSTO STANDARD (STD)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.txtCostDeterminedBy);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtMoneda);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtFecha);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtCostoUsd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtCostoArs);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(1, 250);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 105);
            this.panel2.TabIndex = 133;
            // 
            // txtCostDeterminedBy
            // 
            this.txtCostDeterminedBy.Location = new System.Drawing.Point(120, 74);
            this.txtCostDeterminedBy.Name = "txtCostDeterminedBy";
            this.txtCostDeterminedBy.ReadOnly = true;
            this.txtCostDeterminedBy.Size = new System.Drawing.Size(129, 20);
            this.txtCostDeterminedBy.TabIndex = 102;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 103;
            this.label4.Text = "Determinacion Costo";
            // 
            // txtMoneda
            // 
            this.txtMoneda.Location = new System.Drawing.Point(274, 8);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(43, 20);
            this.txtMoneda.TabIndex = 100;
            this.txtMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(226, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 101;
            this.label9.Text = "Moneda";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(120, 52);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(129, 20);
            this.txtFecha.TabIndex = 96;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 97;
            this.label5.Text = "Fecha";
            // 
            // txtCostoUsd
            // 
            this.txtCostoUsd.Location = new System.Drawing.Point(120, 30);
            this.txtCostoUsd.Name = "txtCostoUsd";
            this.txtCostoUsd.ReadOnly = true;
            this.txtCostoUsd.Size = new System.Drawing.Size(77, 20);
            this.txtCostoUsd.TabIndex = 92;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 93;
            this.label3.Text = "Costo USD";
            // 
            // txtCostoArs
            // 
            this.txtCostoArs.Location = new System.Drawing.Point(120, 8);
            this.txtCostoArs.Name = "txtCostoArs";
            this.txtCostoArs.ReadOnly = true;
            this.txtCostoArs.Size = new System.Drawing.Size(77, 20);
            this.txtCostoArs.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Costo ARS";
            // 
            // ckManualUpdated
            // 
            this.ckManualUpdated.AutoSize = true;
            this.ckManualUpdated.Enabled = false;
            this.ckManualUpdated.Location = new System.Drawing.Point(501, 252);
            this.ckManualUpdated.Name = "ckManualUpdated";
            this.ckManualUpdated.Size = new System.Drawing.Size(148, 17);
            this.ckManualUpdated.TabIndex = 103;
            this.ckManualUpdated.Text = "Actualizado Manualmente";
            this.ckManualUpdated.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.txtCostoReferencia);
            this.panel3.Controls.Add(this.txtMonedaReferencia);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtFechaCostoRef);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtCostoRefUsd);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtCostoRefArs);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(1, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(324, 113);
            this.panel3.TabIndex = 134;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 13);
            this.label16.TabIndex = 105;
            this.label16.Text = "Costo Referencia";
            // 
            // txtCostoReferencia
            // 
            this.txtCostoReferencia.Location = new System.Drawing.Point(120, 3);
            this.txtCostoReferencia.Name = "txtCostoReferencia";
            this.txtCostoReferencia.ReadOnly = true;
            this.txtCostoReferencia.Size = new System.Drawing.Size(129, 20);
            this.txtCostoReferencia.TabIndex = 104;
            // 
            // txtMonedaReferencia
            // 
            this.txtMonedaReferencia.Location = new System.Drawing.Point(120, 24);
            this.txtMonedaReferencia.Name = "txtMonedaReferencia";
            this.txtMonedaReferencia.ReadOnly = true;
            this.txtMonedaReferencia.Size = new System.Drawing.Size(43, 20);
            this.txtMonedaReferencia.TabIndex = 100;
            this.txtMonedaReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 101;
            this.label10.Text = "Moneda";
            // 
            // txtFechaCostoRef
            // 
            this.txtFechaCostoRef.Location = new System.Drawing.Point(120, 87);
            this.txtFechaCostoRef.Name = "txtFechaCostoRef";
            this.txtFechaCostoRef.ReadOnly = true;
            this.txtFechaCostoRef.Size = new System.Drawing.Size(129, 20);
            this.txtFechaCostoRef.TabIndex = 96;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 97;
            this.label11.Text = "Fecha";
            // 
            // txtCostoRefUsd
            // 
            this.txtCostoRefUsd.Location = new System.Drawing.Point(120, 66);
            this.txtCostoRefUsd.Name = "txtCostoRefUsd";
            this.txtCostoRefUsd.ReadOnly = true;
            this.txtCostoRefUsd.Size = new System.Drawing.Size(77, 20);
            this.txtCostoRefUsd.TabIndex = 92;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 93;
            this.label12.Text = "Costo USD";
            // 
            // txtCostoRefArs
            // 
            this.txtCostoRefArs.Location = new System.Drawing.Point(120, 45);
            this.txtCostoRefArs.Name = "txtCostoRefArs";
            this.txtCostoRefArs.ReadOnly = true;
            this.txtCostoRefArs.Size = new System.Drawing.Size(77, 20);
            this.txtCostoRefArs.TabIndex = 91;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 91;
            this.label13.Text = "Costo ARS";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Yellow;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(1, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(658, 19);
            this.label15.TabIndex = 135;
            this.label15.Text = "COSTO DE REFERENCIA";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdateUC
            // 
            this.btnUpdateUC.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUC.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateUC.Image")));
            this.btnUpdateUC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateUC.Location = new System.Drawing.Point(331, 250);
            this.btnUpdateUC.Name = "btnUpdateUC";
            this.btnUpdateUC.Size = new System.Drawing.Size(100, 40);
            this.btnUpdateUC.TabIndex = 104;
            this.btnUpdateUC.Text = "Update\r\n UC";
            this.btnUpdateUC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateUC.UseVisualStyleBackColor = true;
            // 
            // btnSetAsStandard
            // 
            this.btnSetAsStandard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSetAsStandard.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetAsStandard.Image = ((System.Drawing.Image)(resources.GetObject("btnSetAsStandard.Image")));
            this.btnSetAsStandard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetAsStandard.Location = new System.Drawing.Point(665, 43);
            this.btnSetAsStandard.Name = "btnSetAsStandard";
            this.btnSetAsStandard.Size = new System.Drawing.Size(100, 40);
            this.btnSetAsStandard.TabIndex = 132;
            this.btnSetAsStandard.Text = "SET as\r\nSTANDARD";
            this.btnSetAsStandard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSetAsStandard.UseVisualStyleBackColor = true;
            this.btnSetAsStandard.Click += new System.EventHandler(this.BtnSetAsStandard_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(665, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 131;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 15);
            this.label8.TabIndex = 94;
            this.label8.Text = "T/C";
            // 
            // tc
            // 
            this.tc.BackColor = System.Drawing.SystemColors.Control;
            this.tc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tc.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tc.Location = new System.Drawing.Point(68, 53);
            this.tc.Name = "tc";
            this.tc.Size = new System.Drawing.Size(57, 21);
            this.tc.TabIndex = 93;
            this.tc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmCO07CostoStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 361);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnUpdateUC);
            this.Controls.Add(this.ckManualUpdated);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSetAsStandard);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCO07CostoStandard";
            this.Text = "CO07 Costo Standard";
            this.Load += new System.EventHandler(this.FrmCO07CostoStandard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMtype;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetAsStandard;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCostoUsd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCostoArs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckManualUpdated;
        private System.Windows.Forms.Button btnUpdateUC;
        private System.Windows.Forms.TextBox txtCostDeterminedBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCostoReferencia;
        private System.Windows.Forms.TextBox txtMonedaReferencia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFechaCostoRef;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCostoRefUsd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCostoRefArs;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private _UserControls.DecimalTextBox tc;
    }
}