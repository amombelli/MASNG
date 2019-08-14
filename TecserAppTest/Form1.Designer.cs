namespace TecserAppTest
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctlTextBox3 = new TSControls.CtlTextBox();
            this.ctlTextBox2 = new TSControls.CtlTextBox();
            this.ctlTextBox1 = new TSControls.CtlTextBox();
            this.ctlAlarmClock1 = new TSControls.CtlAlarmClock();
            this.SuspendLayout();
            // 
            // ctlTextBox3
            // 
            this.ctlTextBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlTextBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctlTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTextBox3.Location = new System.Drawing.Point(143, 191);
            this.ctlTextBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlTextBox3.Name = "ctlTextBox3";
            this.ctlTextBox3.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlTextBox3.SetDecimales = 0;
            this.ctlTextBox3.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.ctlTextBox3.Size = new System.Drawing.Size(459, 117);
            this.ctlTextBox3.TabIndex = 3;
            this.ctlTextBox3.TsFont = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTextBox3.ValorMaximo = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.ctlTextBox3.ValorMinimo = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.ctlTextBox3.XReadOnly = false;
            // 
            // ctlTextBox2
            // 
            this.ctlTextBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlTextBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ctlTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTextBox2.Location = new System.Drawing.Point(32232, 32628);
            this.ctlTextBox2.Margin = new System.Windows.Forms.Padding(950, 882, 950, 882);
            this.ctlTextBox2.Name = "ctlTextBox2";
            this.ctlTextBox2.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlTextBox2.SetDecimales = 0;
            this.ctlTextBox2.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.ctlTextBox2.Size = new System.Drawing.Size(23034, 80);
            this.ctlTextBox2.TabIndex = 2;
            this.ctlTextBox2.TsFont = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTextBox2.ValorMaximo = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.ctlTextBox2.ValorMinimo = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.ctlTextBox2.XReadOnly = false;
            // 
            // ctlTextBox1
            // 
            this.ctlTextBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlTextBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ctlTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTextBox1.Location = new System.Drawing.Point(5888, 5048);
            this.ctlTextBox1.Margin = new System.Windows.Forms.Padding(48, 44, 48, 44);
            this.ctlTextBox1.Name = "ctlTextBox1";
            this.ctlTextBox1.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlTextBox1.SetDecimales = 0;
            this.ctlTextBox1.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.ctlTextBox1.Size = new System.Drawing.Size(790, 31);
            this.ctlTextBox1.TabIndex = 1;
            this.ctlTextBox1.TsFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTextBox1.ValorMaximo = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.ctlTextBox1.ValorMinimo = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.ctlTextBox1.XReadOnly = false;
            // 
            // ctlAlarmClock1
            // 
            this.ctlAlarmClock1.AlarmSet = true;
            this.ctlAlarmClock1.AlarmTime = new System.DateTime(2020, 1, 10, 11, 22, 0, 0);
            this.ctlAlarmClock1.ClockBackColor = System.Drawing.Color.Blue;
            this.ctlAlarmClock1.ClockForeColor = System.Drawing.Color.Empty;
            this.ctlAlarmClock1.Location = new System.Drawing.Point(18, 32);
            this.ctlAlarmClock1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlAlarmClock1.Name = "ctlAlarmClock1";
            this.ctlAlarmClock1.Size = new System.Drawing.Size(393, 118);
            this.ctlAlarmClock1.TabIndex = 0;
            this.ctlAlarmClock1.Load += new System.EventHandler(this.ctlAlarmClock1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.ctlTextBox3);
            this.Controls.Add(this.ctlTextBox2);
            this.Controls.Add(this.ctlTextBox1);
            this.Controls.Add(this.ctlAlarmClock1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TSControls.CtlAlarmClock ctlAlarmClock1;
        private TSControls.CtlTextBox ctlTextBox1;
        private TSControls.CtlTextBox ctlTextBox2;
        private TSControls.CtlTextBox ctlTextBox3;
    }
}

