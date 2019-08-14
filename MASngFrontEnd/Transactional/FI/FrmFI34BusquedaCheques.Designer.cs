namespace MASngFE.Transactional.FI
{
    partial class FrmFI34BusquedaCheques
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI34BusquedaCheques));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckL1 = new System.Windows.Forms.CheckBox();
            this.ckL2 = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.dgvListaCheques = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.ckVerDisponible = new System.Windows.Forms.CheckBox();
            this.ckVerNoDisponible = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckInterior = new System.Windows.Forms.CheckBox();
            this.ckNoInterior = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiasAcredMax = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCheques)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumber
            // 
            this.txtNumber.ForeColor = System.Drawing.Color.Navy;
            this.txtNumber.Location = new System.Drawing.Point(113, 5);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(57, 20);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero Cheque";
            // 
            // ckL1
            // 
            this.ckL1.AutoSize = true;
            this.ckL1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckL1.Location = new System.Drawing.Point(204, 4);
            this.ckL1.Name = "ckL1";
            this.ckL1.Size = new System.Drawing.Size(38, 19);
            this.ckL1.TabIndex = 2;
            this.ckL1.Text = "L1";
            this.ckL1.UseVisualStyleBackColor = true;
            this.ckL1.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            // 
            // ckL2
            // 
            this.ckL2.AutoSize = true;
            this.ckL2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckL2.Location = new System.Drawing.Point(204, 27);
            this.ckL2.Name = "ckL2";
            this.ckL2.Size = new System.Drawing.Size(38, 19);
            this.ckL2.TabIndex = 3;
            this.ckL2.Text = "L2";
            this.ckL2.UseVisualStyleBackColor = true;
            this.ckL2.CheckedChanged += new System.EventHandler(this.ckL2_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(823, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "ID Cheque";
            // 
            // txtId
            // 
            this.txtId.ForeColor = System.Drawing.Color.Navy;
            this.txtId.Location = new System.Drawing.Point(113, 27);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(57, 20);
            this.txtId.TabIndex = 6;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtId_KeyPress);
            // 
            // dgvListaCheques
            // 
            this.dgvListaCheques.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaCheques.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaCheques.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaCheques.Location = new System.Drawing.Point(3, 57);
            this.dgvListaCheques.Name = "dgvListaCheques";
            this.dgvListaCheques.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvListaCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaCheques.Size = new System.Drawing.Size(817, 646);
            this.dgvListaCheques.TabIndex = 8;
            this.dgvListaCheques.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaCheques_CellContentClick_1);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(823, 44);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 40);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Exportar";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ckVerDisponible
            // 
            this.ckVerDisponible.AutoSize = true;
            this.ckVerDisponible.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckVerDisponible.Location = new System.Drawing.Point(560, 4);
            this.ckVerDisponible.Name = "ckVerDisponible";
            this.ckVerDisponible.Size = new System.Drawing.Size(161, 19);
            this.ckVerDisponible.TabIndex = 10;
            this.ckVerDisponible.Text = "Ver Cheques Disponibles";
            this.ckVerDisponible.UseVisualStyleBackColor = true;
            this.ckVerDisponible.CheckedChanged += new System.EventHandler(this.ckVerDisponible_CheckedChanged);
            // 
            // ckVerNoDisponible
            // 
            this.ckVerNoDisponible.AutoSize = true;
            this.ckVerNoDisponible.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckVerNoDisponible.ForeColor = System.Drawing.Color.Red;
            this.ckVerNoDisponible.Location = new System.Drawing.Point(560, 28);
            this.ckVerNoDisponible.Name = "ckVerNoDisponible";
            this.ckVerNoDisponible.Size = new System.Drawing.Size(181, 19);
            this.ckVerNoDisponible.TabIndex = 11;
            this.ckVerNoDisponible.Text = "Ver Cheques NO Disponibles";
            this.ckVerNoDisponible.UseVisualStyleBackColor = true;
            this.ckVerNoDisponible.CheckedChanged += new System.EventHandler(this.ckVerNoDisponible_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDiasAcredMax);
            this.panel1.Controls.Add(this.ckInterior);
            this.panel1.Controls.Add(this.ckNoInterior);
            this.panel1.Controls.Add(this.ckVerDisponible);
            this.panel1.Controls.Add(this.ckVerNoDisponible);
            this.panel1.Controls.Add(this.ckL1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ckL2);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.txtNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(817, 54);
            this.panel1.TabIndex = 12;
            // 
            // ckInterior
            // 
            this.ckInterior.AutoSize = true;
            this.ckInterior.Checked = true;
            this.ckInterior.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckInterior.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckInterior.Location = new System.Drawing.Point(268, 5);
            this.ckInterior.Name = "ckInterior";
            this.ckInterior.Size = new System.Drawing.Size(77, 19);
            this.ckInterior.TabIndex = 12;
            this.ckInterior.Text = "INTERIOR";
            this.ckInterior.UseVisualStyleBackColor = true;
            this.ckInterior.CheckedChanged += new System.EventHandler(this.CkInterior_CheckedChanged);
            // 
            // ckNoInterior
            // 
            this.ckNoInterior.AutoSize = true;
            this.ckNoInterior.Checked = true;
            this.ckNoInterior.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckNoInterior.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNoInterior.Location = new System.Drawing.Point(268, 28);
            this.ckNoInterior.Name = "ckNoInterior";
            this.ckNoInterior.Size = new System.Drawing.Size(54, 19);
            this.ckNoInterior.TabIndex = 13;
            this.ckNoInterior.Text = "CABA";
            this.ckNoInterior.UseVisualStyleBackColor = true;
            this.ckNoInterior.CheckedChanged += new System.EventHandler(this.CkNoInterior_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(377, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Dias Acred MAX";
            // 
            // txtDiasAcredMax
            // 
            this.txtDiasAcredMax.ForeColor = System.Drawing.Color.Navy;
            this.txtDiasAcredMax.Location = new System.Drawing.Point(476, 26);
            this.txtDiasAcredMax.Name = "txtDiasAcredMax";
            this.txtDiasAcredMax.Size = new System.Drawing.Size(44, 20);
            this.txtDiasAcredMax.TabIndex = 14;
            this.txtDiasAcredMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiasAcredMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDiasAcredMax_KeyPress);
            this.txtDiasAcredMax.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDiasAcredMax_Validating);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(823, 85);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 79;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // FrmFI34BusquedaCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 706);
            this.ControlBox = false;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvListaCheques);
            this.Name = "FrmFI34BusquedaCheques";
            this.Text = "FI34 - Listado de CHEQUES ";
            this.Load += new System.EventHandler(this.FrmBusquedaCheques_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCheques)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckL1;
        private System.Windows.Forms.CheckBox ckL2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.DataGridView dgvListaCheques;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox ckVerDisponible;
        private System.Windows.Forms.CheckBox ckVerNoDisponible;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckInterior;
        private System.Windows.Forms.CheckBox ckNoInterior;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiasAcredMax;
        private System.Windows.Forms.Button btnExit;
    }
}