namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    partial class FrmFI32OpAddItemPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI32OpAddItemPago));
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAddItemPago = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumeroOP = new System.Windows.Forms.TextBox();
            this.cmbCuenta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.txtImporteOrigen = new System.Windows.Forms.TextBox();
            this.txtTipoCuenta = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(12, 13);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 41);
            this.btnSalir.TabIndex = 60;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAddItemPago
            // 
            this.btnAddItemPago.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItemPago.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItemPago.Image")));
            this.btnAddItemPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItemPago.Location = new System.Drawing.Point(12, 56);
            this.btnAddItemPago.Name = "btnAddItemPago";
            this.btnAddItemPago.Size = new System.Drawing.Size(93, 41);
            this.btnAddItemPago.TabIndex = 61;
            this.btnAddItemPago.Text = "AGREGAR";
            this.btnAddItemPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddItemPago.UseVisualStyleBackColor = true;
            this.btnAddItemPago.Click += new System.EventHandler(this.btnAddItemPago_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 125;
            this.label10.Text = "ORDEN DE PAGO #";
            // 
            // txtNumeroOP
            // 
            this.txtNumeroOP.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOP.Location = new System.Drawing.Point(99, 7);
            this.txtNumeroOP.Name = "txtNumeroOP";
            this.txtNumeroOP.ReadOnly = true;
            this.txtNumeroOP.Size = new System.Drawing.Size(87, 21);
            this.txtNumeroOP.TabIndex = 124;
            // 
            // cmbCuenta
            // 
            this.cmbCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCuenta.FormattingEnabled = true;
            this.cmbCuenta.Location = new System.Drawing.Point(99, 5);
            this.cmbCuenta.Name = "cmbCuenta";
            this.cmbCuenta.Size = new System.Drawing.Size(219, 23);
            this.cmbCuenta.TabIndex = 123;
            this.cmbCuenta.SelectedIndexChanged += new System.EventHandler(this.cmbCuenta_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 122;
            this.label3.Text = "CUENTA";
            // 
            // txtLX
            // 
            this.txtLX.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLX.Location = new System.Drawing.Point(188, 7);
            this.txtLX.Name = "txtLX";
            this.txtLX.ReadOnly = true;
            this.txtLX.Size = new System.Drawing.Size(26, 21);
            this.txtLX.TabIndex = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 127;
            this.label1.Text = "IMPORTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 130;
            this.label2.Text = "MONEDA";
            // 
            // txtMoneda
            // 
            this.txtMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneda.Location = new System.Drawing.Point(99, 29);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(46, 21);
            this.txtMoneda.TabIndex = 129;
            // 
            // txtImporteOrigen
            // 
            this.txtImporteOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteOrigen.Location = new System.Drawing.Point(99, 51);
            this.txtImporteOrigen.Name = "txtImporteOrigen";
            this.txtImporteOrigen.Size = new System.Drawing.Size(87, 21);
            this.txtImporteOrigen.TabIndex = 131;
            // 
            // txtTipoCuenta
            // 
            this.txtTipoCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCuenta.Location = new System.Drawing.Point(321, 6);
            this.txtTipoCuenta.Name = "txtTipoCuenta";
            this.txtTipoCuenta.ReadOnly = true;
            this.txtTipoCuenta.Size = new System.Drawing.Size(56, 21);
            this.txtTipoCuenta.TabIndex = 132;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtNumeroOP);
            this.panel1.Controls.Add(this.txtLX);
            this.panel1.Location = new System.Drawing.Point(6, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 37);
            this.panel1.TabIndex = 133;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.cmbCuenta);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtTipoCuenta);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtImporteOrigen);
            this.panel2.Controls.Add(this.txtMoneda);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(6, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 84);
            this.panel2.TabIndex = 134;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnAddItemPago);
            this.panel3.Location = new System.Drawing.Point(422, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(115, 111);
            this.panel3.TabIndex = 135;
            // 
            // FrmFI32OpAddItemPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(556, 147);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFI32OpAddItemPago";
            this.Text = "FI32 - Agregar CostItems de Pago a OP";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmOrdenPagoAddItemsPago_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAddItemPago;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNumeroOP;
        private System.Windows.Forms.ComboBox cmbCuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.TextBox txtImporteOrigen;
        private System.Windows.Forms.TextBox txtTipoCuenta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}