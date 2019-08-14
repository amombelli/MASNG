namespace MASngFE.Transactional.SD.Remito
{
    partial class FrmConfirmacionPreparacion
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
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtIdRemito = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboResponsablePrep = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidadBultos = new System.Windows.Forms.TextBox();
            this.txtComentarioPreparacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtClienteDescripcion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(543, 6);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(83, 35);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtIdRemito
            // 
            this.txtIdRemito.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdRemito.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdRemito.Location = new System.Drawing.Point(132, 4);
            this.txtIdRemito.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdRemito.Name = "txtIdRemito";
            this.txtIdRemito.ReadOnly = true;
            this.txtIdRemito.Size = new System.Drawing.Size(80, 20);
            this.txtIdRemito.TabIndex = 1;
            this.txtIdRemito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(543, 41);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 35);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "RESPONSABLE DE PREPARACION";
            // 
            // cboResponsablePrep
            // 
            this.cboResponsablePrep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboResponsablePrep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboResponsablePrep.BackColor = System.Drawing.SystemColors.Info;
            this.cboResponsablePrep.FormattingEnabled = true;
            this.cboResponsablePrep.Location = new System.Drawing.Point(196, 91);
            this.cboResponsablePrep.Margin = new System.Windows.Forms.Padding(2);
            this.cboResponsablePrep.Name = "cboResponsablePrep";
            this.cboResponsablePrep.Size = new System.Drawing.Size(114, 21);
            this.cboResponsablePrep.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "IDENTIFICACION REMITO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "CANTIDAD DE BULTOS";
            // 
            // txtCantidadBultos
            // 
            this.txtCantidadBultos.BackColor = System.Drawing.SystemColors.Info;
            this.txtCantidadBultos.Location = new System.Drawing.Point(196, 114);
            this.txtCantidadBultos.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidadBultos.Name = "txtCantidadBultos";
            this.txtCantidadBultos.Size = new System.Drawing.Size(40, 20);
            this.txtCantidadBultos.TabIndex = 8;
            this.txtCantidadBultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidadBultos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadBultos_KeyPress);
            // 
            // txtComentarioPreparacion
            // 
            this.txtComentarioPreparacion.BackColor = System.Drawing.SystemColors.Info;
            this.txtComentarioPreparacion.Location = new System.Drawing.Point(196, 136);
            this.txtComentarioPreparacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtComentarioPreparacion.Name = "txtComentarioPreparacion";
            this.txtComentarioPreparacion.Size = new System.Drawing.Size(302, 20);
            this.txtComentarioPreparacion.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "OBSERVACIONES PREPARACION";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "CLIENTE ENTREGA";
            // 
            // txtClienteDescripcion
            // 
            this.txtClienteDescripcion.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteDescripcion.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteDescripcion.Location = new System.Drawing.Point(132, 25);
            this.txtClienteDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtClienteDescripcion.Name = "txtClienteDescripcion";
            this.txtClienteDescripcion.ReadOnly = true;
            this.txtClienteDescripcion.Size = new System.Drawing.Size(320, 20);
            this.txtClienteDescripcion.TabIndex = 11;
            // 
            // FrmConfirmacionPreparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(632, 162);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtClienteDescripcion);
            this.Controls.Add(this.txtComentarioPreparacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCantidadBultos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboResponsablePrep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtIdRemito);
            this.Controls.Add(this.btnConfirmar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmConfirmacionPreparacion";
            this.Text = "PREPARACION DEL PEDIDO";
            this.Load += new System.EventHandler(this.FrmConfirmacionPreparacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtIdRemito;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboResponsablePrep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidadBultos;
        private System.Windows.Forms.TextBox txtComentarioPreparacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtClienteDescripcion;
    }
}