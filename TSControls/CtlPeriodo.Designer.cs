namespace TSControls
{
    partial class CtlPeriodo
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtPeriodo = new System.Windows.Forms.MaskedTextBox();
            this.toolTipX = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.AllowPromptAsInput = false;
            this.txtPeriodo.BeepOnError = true;
            this.txtPeriodo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtPeriodo.Location = new System.Drawing.Point(0, 0);
            this.txtPeriodo.Mask = "0000-00";
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(51, 21);
            this.txtPeriodo.TabIndex = 33;
            this.txtPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPeriodo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtPeriodo.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.txtPeriodo_TypeValidationCompleted);
            this.txtPeriodo.Validating += new System.ComponentModel.CancelEventHandler(this.txtPeriodo_Validating);
            // 
            // CtlPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPeriodo);
            this.Name = "CtlPeriodo";
            this.Size = new System.Drawing.Size(105, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtPeriodo;
        private System.Windows.Forms.ToolTip toolTipX;
    }
}
