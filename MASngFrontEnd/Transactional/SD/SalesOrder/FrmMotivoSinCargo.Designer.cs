namespace MASngFE.Transactional.SD.SalesOrder
{
    partial class FrmMotivoSinCargo
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
            this.rbMuestraSinCargo = new System.Windows.Forms.RadioButton();
            this.cmbAutorizo = new System.Windows.Forms.ComboBox();
            this.t0085PERSONALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtSalesOrder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbCambioMaterial = new System.Windows.Forms.RadioButton();
            this.rbBonificacionEspecial = new System.Windows.Forms.RadioButton();
            this.rbReproceso = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.t0085PERSONALBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbMuestraSinCargo
            // 
            this.rbMuestraSinCargo.AutoSize = true;
            this.rbMuestraSinCargo.Location = new System.Drawing.Point(11, 10);
            this.rbMuestraSinCargo.Name = "rbMuestraSinCargo";
            this.rbMuestraSinCargo.Size = new System.Drawing.Size(140, 17);
            this.rbMuestraSinCargo.TabIndex = 1;
            this.rbMuestraSinCargo.TabStop = true;
            this.rbMuestraSinCargo.Text = "MUESTRA SIN CARGO";
            this.rbMuestraSinCargo.UseVisualStyleBackColor = true;
            this.rbMuestraSinCargo.CheckedChanged += new System.EventHandler(this.rbCambioMaterial_CheckedChanged);
            // 
            // cmbAutorizo
            // 
            this.cmbAutorizo.DataSource = this.t0085PERSONALBindingSource;
            this.cmbAutorizo.DisplayMember = "SHORTNAME";
            this.cmbAutorizo.FormattingEnabled = true;
            this.cmbAutorizo.Location = new System.Drawing.Point(122, 192);
            this.cmbAutorizo.Name = "cmbAutorizo";
            this.cmbAutorizo.Size = new System.Drawing.Size(156, 21);
            this.cmbAutorizo.TabIndex = 2;
            this.cmbAutorizo.ValueMember = "SHORTNAME";
            this.cmbAutorizo.SelectedIndexChanged += new System.EventHandler(this.cmbAutorizo_SelectedIndexChanged);
            // 
            // t0085PERSONALBindingSource
            // 
            this.t0085PERSONALBindingSource.DataSource = typeof(TecserEF.Entity.T0085_PERSONAL);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CLIENTE";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Location = new System.Drawing.Point(81, 4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(293, 20);
            this.txtCliente.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(292, 88);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 32);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.txtItem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSalesOrder);
            this.panel1.Controls.Add(this.txtCliente);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMaterial);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 74);
            this.panel1.TabIndex = 6;
            // 
            // txtItem
            // 
            this.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItem.Location = new System.Drawing.Point(154, 48);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(36, 20);
            this.txtItem.TabIndex = 11;
            // 
            // txtSalesOrder
            // 
            this.txtSalesOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesOrder.Location = new System.Drawing.Point(81, 48);
            this.txtSalesOrder.Name = "txtSalesOrder";
            this.txtSalesOrder.Size = new System.Drawing.Size(70, 20);
            this.txtSalesOrder.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "ORDEN #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "MATERIAL";
            // 
            // txtMaterial
            // 
            this.txtMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterial.Location = new System.Drawing.Point(81, 26);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(109, 20);
            this.txtMaterial.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.rbCambioMaterial);
            this.panel2.Controls.Add(this.rbBonificacionEspecial);
            this.panel2.Controls.Add(this.rbReproceso);
            this.panel2.Controls.Add(this.rbMuestraSinCargo);
            this.panel2.Location = new System.Drawing.Point(2, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 108);
            this.panel2.TabIndex = 12;
            // 
            // rbCambioMaterial
            // 
            this.rbCambioMaterial.AutoSize = true;
            this.rbCambioMaterial.Location = new System.Drawing.Point(11, 79);
            this.rbCambioMaterial.Name = "rbCambioMaterial";
            this.rbCambioMaterial.Size = new System.Drawing.Size(203, 17);
            this.rbCambioMaterial.TabIndex = 4;
            this.rbCambioMaterial.TabStop = true;
            this.rbCambioMaterial.Text = "CAMBIO DE MATERIAL SIN CARGO";
            this.rbCambioMaterial.UseVisualStyleBackColor = true;
            this.rbCambioMaterial.CheckedChanged += new System.EventHandler(this.rbCambioMaterial_CheckedChanged);
            // 
            // rbBonificacionEspecial
            // 
            this.rbBonificacionEspecial.AutoSize = true;
            this.rbBonificacionEspecial.Location = new System.Drawing.Point(11, 56);
            this.rbBonificacionEspecial.Name = "rbBonificacionEspecial";
            this.rbBonificacionEspecial.Size = new System.Drawing.Size(154, 17);
            this.rbBonificacionEspecial.TabIndex = 3;
            this.rbBonificacionEspecial.TabStop = true;
            this.rbBonificacionEspecial.Text = "BONIFICACION ESPECIAL";
            this.rbBonificacionEspecial.UseVisualStyleBackColor = true;
            this.rbBonificacionEspecial.CheckedChanged += new System.EventHandler(this.rbCambioMaterial_CheckedChanged);
            // 
            // rbReproceso
            // 
            this.rbReproceso.AutoSize = true;
            this.rbReproceso.Location = new System.Drawing.Point(11, 33);
            this.rbReproceso.Name = "rbReproceso";
            this.rbReproceso.Size = new System.Drawing.Size(154, 17);
            this.rbReproceso.TabIndex = 2;
            this.rbReproceso.TabStop = true;
            this.rbReproceso.Text = "REPROCESO SIN CARGO";
            this.rbReproceso.UseVisualStyleBackColor = true;
            this.rbReproceso.CheckedChanged += new System.EventHandler(this.rbCambioMaterial_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "AUTORIZADO POR";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(292, 123);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(94, 32);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FrmMotivoSinCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 244);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbAutorizo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMotivoSinCargo";
            this.Text = "MOTIVO ENTREGA SIN CARGO *";
            this.Load += new System.EventHandler(this.FrmMotivoSinCargo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0085PERSONALBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbMuestraSinCargo;
        private System.Windows.Forms.ComboBox cmbAutorizo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtSalesOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbCambioMaterial;
        private System.Windows.Forms.RadioButton rbBonificacionEspecial;
        private System.Windows.Forms.RadioButton rbReproceso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.BindingSource t0085PERSONALBindingSource;
    }
}