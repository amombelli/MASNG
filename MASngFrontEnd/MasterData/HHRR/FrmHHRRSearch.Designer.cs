namespace MASngFE.MasterData.HHRR
{
    partial class FrmHHRRSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbShortname = new System.Windows.Forms.ComboBox();
            this.t0085PERSONALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ckSoloActivos = new System.Windows.Forms.CheckBox();
            this.btnNewEmployee = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.NOMBRES = new System.Windows.Forms.Label();
            this.APELLIDO = new System.Windows.Forms.Label();
            this.txtApellidoEmpleado = new System.Windows.Forms.TextBox();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.t0085PERSONALBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "SHORTNAME";
            // 
            // cmbShortname
            // 
            this.cmbShortname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbShortname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbShortname.DataSource = this.t0085PERSONALBindingSource;
            this.cmbShortname.DisplayMember = "SHORTNAME";
            this.cmbShortname.FormattingEnabled = true;
            this.cmbShortname.Location = new System.Drawing.Point(92, 10);
            this.cmbShortname.Name = "cmbShortname";
            this.cmbShortname.Size = new System.Drawing.Size(179, 23);
            this.cmbShortname.TabIndex = 1;
            this.cmbShortname.ValueMember = "ID_VEND";
            // 
            // t0085PERSONALBindingSource
            // 
            this.t0085PERSONALBindingSource.DataSource = typeof(TecserEF.Entity.T0085_PERSONAL);
            // 
            // ckSoloActivos
            // 
            this.ckSoloActivos.AutoSize = true;
            this.ckSoloActivos.Location = new System.Drawing.Point(455, 12);
            this.ckSoloActivos.Name = "ckSoloActivos";
            this.ckSoloActivos.Size = new System.Drawing.Size(172, 19);
            this.ckSoloActivos.TabIndex = 2;
            this.ckSoloActivos.Text = "SOLO EMPLEADOS ACTIVOS";
            this.ckSoloActivos.UseVisualStyleBackColor = true;
            this.ckSoloActivos.CheckedChanged += new System.EventHandler(this.ckSoloActivos_CheckedChanged);
            // 
            // btnNewEmployee
            // 
            this.btnNewEmployee.Location = new System.Drawing.Point(660, 9);
            this.btnNewEmployee.Name = "btnNewEmployee";
            this.btnNewEmployee.Size = new System.Drawing.Size(108, 40);
            this.btnNewEmployee.TabIndex = 3;
            this.btnNewEmployee.Text = "NUEVO EMPLEADO";
            this.btnNewEmployee.UseVisualStyleBackColor = true;
            this.btnNewEmployee.Click += new System.EventHandler(this.btnNewEmployee_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(660, 55);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(108, 40);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0085PERSONALBindingSource, "NOMBRE", true));
            this.txtNombre.Location = new System.Drawing.Point(92, 35);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(179, 23);
            this.txtNombre.TabIndex = 7;
            // 
            // NOMBRES
            // 
            this.NOMBRES.AutoSize = true;
            this.NOMBRES.Location = new System.Drawing.Point(12, 38);
            this.NOMBRES.Name = "NOMBRES";
            this.NOMBRES.Size = new System.Drawing.Size(61, 15);
            this.NOMBRES.TabIndex = 8;
            this.NOMBRES.Text = "NOMBRES";
            // 
            // APELLIDO
            // 
            this.APELLIDO.AutoSize = true;
            this.APELLIDO.Location = new System.Drawing.Point(12, 63);
            this.APELLIDO.Name = "APELLIDO";
            this.APELLIDO.Size = new System.Drawing.Size(58, 15);
            this.APELLIDO.TabIndex = 10;
            this.APELLIDO.Text = "APELLIDO";
            // 
            // txtApellidoEmpleado
            // 
            this.txtApellidoEmpleado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0085PERSONALBindingSource, "APELLIDO", true));
            this.txtApellidoEmpleado.Location = new System.Drawing.Point(92, 60);
            this.txtApellidoEmpleado.Name = "txtApellidoEmpleado";
            this.txtApellidoEmpleado.ReadOnly = true;
            this.txtApellidoEmpleado.Size = new System.Drawing.Size(179, 23);
            this.txtApellidoEmpleado.TabIndex = 9;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(660, 101);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(108, 40);
            this.btnVisualizar.TabIndex = 11;
            this.btnVisualizar.Text = "VISUALIZAR";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // txtId
            // 
            this.txtId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0085PERSONALBindingSource, "ID_VEND", true));
            this.txtId.Location = new System.Drawing.Point(277, 10);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(63, 23);
            this.txtId.TabIndex = 12;
            // 
            // FrmHHRRSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 160);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.APELLIDO);
            this.Controls.Add(this.txtApellidoEmpleado);
            this.Controls.Add(this.NOMBRES);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNewEmployee);
            this.Controls.Add(this.ckSoloActivos);
            this.Controls.Add(this.cmbShortname);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmHHRRSearch";
            this.Text = "BUSQUEDA DE EMPLEADO - HR";
            this.Load += new System.EventHandler(this.FrmHHRRSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0085PERSONALBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbShortname;
        private System.Windows.Forms.BindingSource t0085PERSONALBindingSource;
        private System.Windows.Forms.CheckBox ckSoloActivos;
        private System.Windows.Forms.Button btnNewEmployee;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label NOMBRES;
        private System.Windows.Forms.Label APELLIDO;
        private System.Windows.Forms.TextBox txtApellidoEmpleado;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.TextBox txtId;
    }
}