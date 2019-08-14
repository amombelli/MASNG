using System.Windows.Forms;

namespace MASngFE.Transactional.PP
{
    partial class FrmPP02PlanificacionOF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP02PlanificacionOF));
            this.txtMaterialPrimario = new System.Windows.Forms.TextBox();
            this.txtMaterialEtiqueta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroFormulaSeleccionada = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroFormulasTotales = new System.Windows.Forms.TextBox();
            this.txtNumeroFormulasActivas = new System.Windows.Forms.TextBox();
            this.txtNumeroLote = new System.Windows.Forms.TextBox();
            this.txtnumeroOF = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtClienteFantasia = new System.Windows.Forms.TextBox();
            this.txtOrdenVentaNumero = new System.Windows.Forms.TextBox();
            this.txtPlanPara = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtUltimaFabricacion = new System.Windows.Forms.TextBox();
            this.txtConsumoU30 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtConsumoU60 = new System.Windows.Forms.TextBox();
            this.txtNumeroClientes = new System.Windows.Forms.TextBox();
            this.txtConsumoP30 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.dgvFormulaSeleccionada = new System.Windows.Forms.DataGridView();
            this.idItemFormulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__primario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadBaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__kg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__reproceso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.@__added = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.@__recalculo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.t0072Bs = new System.Windows.Forms.BindingSource(this.components);
            this.txtKgFabricarOri = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtObservacionPF = new System.Windows.Forms.TextBox();
            this.panelFormulacion = new System.Windows.Forms.Panel();
            this.ckAutoFormulacion = new System.Windows.Forms.CheckBox();
            this.lblAutomaticFormulation = new System.Windows.Forms.Label();
            this.gFormulacionGreen = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSeleccionarFormula1 = new System.Windows.Forms.Button();
            this.gFormulacionRed = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnVerFormulas1 = new System.Windows.Forms.Button();
            this.txtFechaUltimaFormulacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescripcionFormulaSeleccionada = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnPlanear = new System.Windows.Forms.Button();
            this.btnImprimirFormula = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnModificarTamañoBatch1 = new System.Windows.Forms.Button();
            this.ckReservaAutomatica = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtBatchQuantity = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtKgFabricarBatch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.txtFechaCompromisoPlan = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtKgPlaneados = new System.Windows.Forms.TextBox();
            this.cmbOperador = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRecursoProduccion = new System.Windows.Forms.ComboBox();
            this.dtpFechaPlan = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtNotaOrdenFabricacion = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.btnCancelarOF = new System.Windows.Forms.Button();
            this.btnStandBy = new System.Windows.Forms.Button();
            this.lblStockNoDisponible = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.txtContainerId = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtCantidadContainers = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbContainer = new System.Windows.Forms.ComboBox();
            this.t0010ContainerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ckUpdateContainer = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStatusLab = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtKgFabricadosIngresados = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label29 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panelMRP = new System.Windows.Forms.Panel();
            this.label36 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.ck1SeleccionFormula = new System.Windows.Forms.CheckBox();
            this.ck2DeterminacionBatch = new System.Windows.Forms.CheckBox();
            this.ck3PlanRecursos = new System.Windows.Forms.CheckBox();
            this.ck5CierreOF = new System.Windows.Forms.CheckBox();
            this.ck4Fabricacion = new System.Windows.Forms.CheckBox();
            this.ck6AprobacionLab = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnDetalleIngreso = new System.Windows.Forms.Button();
            this.btnCQLab = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulaSeleccionada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0072Bs)).BeginInit();
            this.panelFormulacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gFormulacionGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gFormulacionRed)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0010ContainerBindingSource)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelMRP.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaterialPrimario
            // 
            this.txtMaterialPrimario.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMaterialPrimario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaterialPrimario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialPrimario.Location = new System.Drawing.Point(272, 5);
            this.txtMaterialPrimario.Name = "txtMaterialPrimario";
            this.txtMaterialPrimario.ReadOnly = true;
            this.txtMaterialPrimario.Size = new System.Drawing.Size(207, 19);
            this.txtMaterialPrimario.TabIndex = 1;
            // 
            // txtMaterialEtiqueta
            // 
            this.txtMaterialEtiqueta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMaterialEtiqueta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaterialEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialEtiqueta.Location = new System.Drawing.Point(274, 33);
            this.txtMaterialEtiqueta.Name = "txtMaterialEtiqueta";
            this.txtMaterialEtiqueta.ReadOnly = true;
            this.txtMaterialEtiqueta.Size = new System.Drawing.Size(207, 19);
            this.txtMaterialEtiqueta.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label3.Location = new System.Drawing.Point(9, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total Formulas";
            // 
            // txtNumeroFormulaSeleccionada
            // 
            this.txtNumeroFormulaSeleccionada.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNumeroFormulaSeleccionada.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtNumeroFormulaSeleccionada.Location = new System.Drawing.Point(138, 94);
            this.txtNumeroFormulaSeleccionada.Name = "txtNumeroFormulaSeleccionada";
            this.txtNumeroFormulaSeleccionada.ReadOnly = true;
            this.txtNumeroFormulaSeleccionada.Size = new System.Drawing.Size(63, 21);
            this.txtNumeroFormulaSeleccionada.TabIndex = 6;
            this.txtNumeroFormulaSeleccionada.TabStop = false;
            this.txtNumeroFormulaSeleccionada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label4.Location = new System.Drawing.Point(8, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "# Formula Seleccionada";
            // 
            // txtNumeroFormulasTotales
            // 
            this.txtNumeroFormulasTotales.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNumeroFormulasTotales.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtNumeroFormulasTotales.Location = new System.Drawing.Point(91, 3);
            this.txtNumeroFormulasTotales.Name = "txtNumeroFormulasTotales";
            this.txtNumeroFormulasTotales.ReadOnly = true;
            this.txtNumeroFormulasTotales.Size = new System.Drawing.Size(34, 21);
            this.txtNumeroFormulasTotales.TabIndex = 9;
            this.txtNumeroFormulasTotales.TabStop = false;
            this.txtNumeroFormulasTotales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumeroFormulasActivas
            // 
            this.txtNumeroFormulasActivas.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNumeroFormulasActivas.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtNumeroFormulasActivas.Location = new System.Drawing.Point(91, 26);
            this.txtNumeroFormulasActivas.Name = "txtNumeroFormulasActivas";
            this.txtNumeroFormulasActivas.ReadOnly = true;
            this.txtNumeroFormulasActivas.Size = new System.Drawing.Size(34, 21);
            this.txtNumeroFormulasActivas.TabIndex = 10;
            this.txtNumeroFormulasActivas.TabStop = false;
            this.txtNumeroFormulasActivas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumeroLote
            // 
            this.txtNumeroLote.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroLote.Location = new System.Drawing.Point(123, 93);
            this.txtNumeroLote.Name = "txtNumeroLote";
            this.txtNumeroLote.ReadOnly = true;
            this.txtNumeroLote.Size = new System.Drawing.Size(84, 22);
            this.txtNumeroLote.TabIndex = 14;
            this.txtNumeroLote.TabStop = false;
            this.txtNumeroLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtnumeroOF
            // 
            this.txtnumeroOF.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtnumeroOF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtnumeroOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumeroOF.ForeColor = System.Drawing.Color.Red;
            this.txtnumeroOF.Location = new System.Drawing.Point(66, 5);
            this.txtnumeroOF.Name = "txtnumeroOF";
            this.txtnumeroOF.ReadOnly = true;
            this.txtnumeroOF.Size = new System.Drawing.Size(86, 19);
            this.txtnumeroOF.TabIndex = 12;
            this.txtnumeroOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(630, 6);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(130, 19);
            this.txtStatus.TabIndex = 22;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // txtClienteFantasia
            // 
            this.txtClienteFantasia.BackColor = System.Drawing.Color.Gainsboro;
            this.txtClienteFantasia.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtClienteFantasia.Location = new System.Drawing.Point(117, 52);
            this.txtClienteFantasia.Name = "txtClienteFantasia";
            this.txtClienteFantasia.ReadOnly = true;
            this.txtClienteFantasia.Size = new System.Drawing.Size(261, 21);
            this.txtClienteFantasia.TabIndex = 20;
            // 
            // txtOrdenVentaNumero
            // 
            this.txtOrdenVentaNumero.BackColor = System.Drawing.Color.Gainsboro;
            this.txtOrdenVentaNumero.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtOrdenVentaNumero.Location = new System.Drawing.Point(46, 52);
            this.txtOrdenVentaNumero.Name = "txtOrdenVentaNumero";
            this.txtOrdenVentaNumero.ReadOnly = true;
            this.txtOrdenVentaNumero.Size = new System.Drawing.Size(70, 21);
            this.txtOrdenVentaNumero.TabIndex = 18;
            this.txtOrdenVentaNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlanPara
            // 
            this.txtPlanPara.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPlanPara.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtPlanPara.Location = new System.Drawing.Point(117, 30);
            this.txtPlanPara.Name = "txtPlanPara";
            this.txtPlanPara.ReadOnly = true;
            this.txtPlanPara.Size = new System.Drawing.Size(72, 21);
            this.txtPlanPara.TabIndex = 16;
            this.txtPlanPara.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 14);
            this.label10.TabIndex = 15;
            this.label10.Text = "Fabricacion Para";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label23.Location = new System.Drawing.Point(224, 50);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(103, 13);
            this.label23.TabIndex = 23;
            this.label23.Text = "ULTIMA FABRICACION";
            this.label23.Click += new System.EventHandler(this.label23_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label17.Location = new System.Drawing.Point(15, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(131, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "CONSUMO U30 /PROM U30";
            // 
            // txtUltimaFabricacion
            // 
            this.txtUltimaFabricacion.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtUltimaFabricacion.Location = new System.Drawing.Point(333, 47);
            this.txtUltimaFabricacion.Name = "txtUltimaFabricacion";
            this.txtUltimaFabricacion.ReadOnly = true;
            this.txtUltimaFabricacion.Size = new System.Drawing.Size(95, 21);
            this.txtUltimaFabricacion.TabIndex = 24;
            this.txtUltimaFabricacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUltimaFabricacion.TextChanged += new System.EventHandler(this.txtUltimaFabricacion_TextChanged);
            // 
            // txtConsumoU30
            // 
            this.txtConsumoU30.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtConsumoU30.Location = new System.Drawing.Point(152, 3);
            this.txtConsumoU30.Name = "txtConsumoU30";
            this.txtConsumoU30.ReadOnly = true;
            this.txtConsumoU30.Size = new System.Drawing.Size(63, 21);
            this.txtConsumoU30.TabIndex = 12;
            this.txtConsumoU30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label22.Location = new System.Drawing.Point(49, 51);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(97, 13);
            this.label22.TabIndex = 21;
            this.label22.Text = "CANTIDAD CLIENTES";
            // 
            // txtConsumoU60
            // 
            this.txtConsumoU60.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtConsumoU60.Location = new System.Drawing.Point(152, 25);
            this.txtConsumoU60.Name = "txtConsumoU60";
            this.txtConsumoU60.ReadOnly = true;
            this.txtConsumoU60.Size = new System.Drawing.Size(63, 21);
            this.txtConsumoU60.TabIndex = 18;
            this.txtConsumoU60.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumeroClientes
            // 
            this.txtNumeroClientes.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtNumeroClientes.Location = new System.Drawing.Point(152, 47);
            this.txtNumeroClientes.Name = "txtNumeroClientes";
            this.txtNumeroClientes.ReadOnly = true;
            this.txtNumeroClientes.Size = new System.Drawing.Size(63, 21);
            this.txtNumeroClientes.TabIndex = 22;
            this.txtNumeroClientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtConsumoP30
            // 
            this.txtConsumoP30.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtConsumoP30.Location = new System.Drawing.Point(215, 3);
            this.txtConsumoP30.Name = "txtConsumoP30";
            this.txtConsumoP30.ReadOnly = true;
            this.txtConsumoP30.Size = new System.Drawing.Size(63, 21);
            this.txtConsumoP30.TabIndex = 20;
            this.txtConsumoP30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label27.Location = new System.Drawing.Point(201, 32);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(83, 13);
            this.label27.TabIndex = 36;
            this.label27.Text = "STOCK LIBERADO";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label28.Location = new System.Drawing.Point(201, 10);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(95, 13);
            this.label28.TabIndex = 34;
            this.label28.Text = "Stock Total (Actual)";
            // 
            // textBox26
            // 
            this.textBox26.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.textBox26.Location = new System.Drawing.Point(306, 29);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(72, 21);
            this.textBox26.TabIndex = 37;
            // 
            // textBox27
            // 
            this.textBox27.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.textBox27.Location = new System.Drawing.Point(306, 7);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(72, 21);
            this.textBox27.TabIndex = 35;
            // 
            // dgvFormulaSeleccionada
            // 
            this.dgvFormulaSeleccionada.AllowUserToAddRows = false;
            this.dgvFormulaSeleccionada.AllowUserToDeleteRows = false;
            this.dgvFormulaSeleccionada.AutoGenerateColumns = false;
            this.dgvFormulaSeleccionada.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFormulaSeleccionada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormulaSeleccionada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idItemFormulaDataGridViewTextBoxColumn,
            this.@__primario,
            this.cantidadBaseDataGridViewTextBoxColumn,
            this.@__porcentaje,
            this.@__kg,
            this.batchNumberDataGridViewTextBoxColumn,
            this.@__reproceso,
            this.@__added,
            this.@__recalculo});
            this.dgvFormulaSeleccionada.DataSource = this.t0072Bs;
            this.dgvFormulaSeleccionada.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFormulaSeleccionada.Location = new System.Drawing.Point(403, 176);
            this.dgvFormulaSeleccionada.MultiSelect = false;
            this.dgvFormulaSeleccionada.Name = "dgvFormulaSeleccionada";
            this.dgvFormulaSeleccionada.ReadOnly = true;
            this.dgvFormulaSeleccionada.RowHeadersWidth = 10;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFormulaSeleccionada.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvFormulaSeleccionada.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFormulaSeleccionada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormulaSeleccionada.Size = new System.Drawing.Size(435, 367);
            this.dgvFormulaSeleccionada.TabIndex = 0;
            this.dgvFormulaSeleccionada.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaSeleccionada_CellDoubleClick);
            // 
            // idItemFormulaDataGridViewTextBoxColumn
            // 
            this.idItemFormulaDataGridViewTextBoxColumn.DataPropertyName = "idItemFormula";
            this.idItemFormulaDataGridViewTextBoxColumn.HeaderText = "Id#";
            this.idItemFormulaDataGridViewTextBoxColumn.Name = "idItemFormulaDataGridViewTextBoxColumn";
            this.idItemFormulaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idItemFormulaDataGridViewTextBoxColumn.Width = 35;
            // 
            // __primario
            // 
            this.@__primario.DataPropertyName = "Primario";
            this.@__primario.HeaderText = "Primario";
            this.@__primario.Name = "__primario";
            this.@__primario.ReadOnly = true;
            this.@__primario.Width = 85;
            // 
            // cantidadBaseDataGridViewTextBoxColumn
            // 
            this.cantidadBaseDataGridViewTextBoxColumn.DataPropertyName = "CantidadBase";
            dataGridViewCellStyle9.Format = "N2";
            this.cantidadBaseDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.cantidadBaseDataGridViewTextBoxColumn.HeaderText = "Base";
            this.cantidadBaseDataGridViewTextBoxColumn.Name = "cantidadBaseDataGridViewTextBoxColumn";
            this.cantidadBaseDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadBaseDataGridViewTextBoxColumn.Visible = false;
            this.cantidadBaseDataGridViewTextBoxColumn.Width = 40;
            // 
            // __porcentaje
            // 
            this.@__porcentaje.DataPropertyName = "CantidadPor";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "P2";
            dataGridViewCellStyle10.NullValue = "0";
            this.@__porcentaje.DefaultCellStyle = dataGridViewCellStyle10;
            this.@__porcentaje.HeaderText = "%";
            this.@__porcentaje.Name = "__porcentaje";
            this.@__porcentaje.ReadOnly = true;
            this.@__porcentaje.Width = 50;
            // 
            // __kg
            // 
            this.@__kg.DataPropertyName = "CantidadKG";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = "0";
            this.@__kg.DefaultCellStyle = dataGridViewCellStyle11;
            this.@__kg.HeaderText = "KG";
            this.@__kg.Name = "__kg";
            this.@__kg.ReadOnly = true;
            this.@__kg.Width = 50;
            // 
            // batchNumberDataGridViewTextBoxColumn
            // 
            this.batchNumberDataGridViewTextBoxColumn.DataPropertyName = "BatchNumber";
            this.batchNumberDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.batchNumberDataGridViewTextBoxColumn.Name = "batchNumberDataGridViewTextBoxColumn";
            this.batchNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // __reproceso
            // 
            this.@__reproceso.DataPropertyName = "Repro";
            this.@__reproceso.HeaderText = "[R]";
            this.@__reproceso.Name = "__reproceso";
            this.@__reproceso.ReadOnly = true;
            this.@__reproceso.Width = 25;
            // 
            // __added
            // 
            this.@__added.DataPropertyName = "Added";
            this.@__added.HeaderText = "[+]";
            this.@__added.Name = "__added";
            this.@__added.ReadOnly = true;
            this.@__added.Width = 25;
            // 
            // __recalculo
            // 
            this.@__recalculo.DataPropertyName = "Recalculo";
            this.@__recalculo.HeaderText = "[!]";
            this.@__recalculo.Name = "__recalculo";
            this.@__recalculo.ReadOnly = true;
            this.@__recalculo.Width = 25;
            // 
            // t0072Bs
            // 
            this.t0072Bs.DataSource = typeof(TecserEF.Entity.T0072_FORMULA_TEMP);
            // 
            // txtKgFabricarOri
            // 
            this.txtKgFabricarOri.BackColor = System.Drawing.Color.Gainsboro;
            this.txtKgFabricarOri.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgFabricarOri.Location = new System.Drawing.Point(117, 7);
            this.txtKgFabricarOri.Name = "txtKgFabricarOri";
            this.txtKgFabricarOri.ReadOnly = true;
            this.txtKgFabricarOri.Size = new System.Drawing.Size(72, 22);
            this.txtKgFabricarOri.TabIndex = 6;
            this.txtKgFabricarOri.TabStop = false;
            this.txtKgFabricarOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(9, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 14);
            this.label19.TabIndex = 5;
            this.label19.Text = "KG a Fabricar [ORI]";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(2, 170);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(384, 19);
            this.label14.TabIndex = 28;
            this.label14.Text = "OBSERVACION (SE VISUALIZA EN LISTA PF)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtObservacionPF
            // 
            this.txtObservacionPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacionPF.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacionPF.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtObservacionPF.Location = new System.Drawing.Point(3, 190);
            this.txtObservacionPF.Multiline = true;
            this.txtObservacionPF.Name = "txtObservacionPF";
            this.txtObservacionPF.Size = new System.Drawing.Size(383, 28);
            this.txtObservacionPF.TabIndex = 27;
            this.txtObservacionPF.Validating += new System.ComponentModel.CancelEventHandler(this.txtObservacionPF_Validating);
            // 
            // panelFormulacion
            // 
            this.panelFormulacion.BackColor = System.Drawing.Color.White;
            this.panelFormulacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFormulacion.Controls.Add(this.ckAutoFormulacion);
            this.panelFormulacion.Controls.Add(this.lblAutomaticFormulation);
            this.panelFormulacion.Controls.Add(this.gFormulacionGreen);
            this.panelFormulacion.Controls.Add(this.label7);
            this.panelFormulacion.Controls.Add(this.label4);
            this.panelFormulacion.Controls.Add(this.btnSeleccionarFormula1);
            this.panelFormulacion.Controls.Add(this.gFormulacionRed);
            this.panelFormulacion.Controls.Add(this.label12);
            this.panelFormulacion.Controls.Add(this.txtNumeroFormulaSeleccionada);
            this.panelFormulacion.Controls.Add(this.btnVerFormulas1);
            this.panelFormulacion.Controls.Add(this.txtFechaUltimaFormulacion);
            this.panelFormulacion.Controls.Add(this.label2);
            this.panelFormulacion.Controls.Add(this.label3);
            this.panelFormulacion.Controls.Add(this.label11);
            this.panelFormulacion.Controls.Add(this.txtNumeroFormulasTotales);
            this.panelFormulacion.Controls.Add(this.txtNumeroFormulasActivas);
            this.panelFormulacion.Controls.Add(this.txtDescripcionFormulaSeleccionada);
            this.panelFormulacion.Location = new System.Drawing.Point(3, 251);
            this.panelFormulacion.Name = "panelFormulacion";
            this.panelFormulacion.Size = new System.Drawing.Size(384, 168);
            this.panelFormulacion.TabIndex = 25;
            // 
            // ckAutoFormulacion
            // 
            this.ckAutoFormulacion.AutoSize = true;
            this.ckAutoFormulacion.Checked = true;
            this.ckAutoFormulacion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAutoFormulacion.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.ckAutoFormulacion.Location = new System.Drawing.Point(8, 49);
            this.ckAutoFormulacion.Name = "ckAutoFormulacion";
            this.ckAutoFormulacion.Size = new System.Drawing.Size(241, 17);
            this.ckAutoFormulacion.TabIndex = 171;
            this.ckAutoFormulacion.Text = "Formulacion Automatica (Cuando sea Posible)";
            this.ckAutoFormulacion.UseVisualStyleBackColor = true;
            // 
            // lblAutomaticFormulation
            // 
            this.lblAutomaticFormulation.BackColor = System.Drawing.Color.Navy;
            this.lblAutomaticFormulation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAutomaticFormulation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutomaticFormulation.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.lblAutomaticFormulation.Location = new System.Drawing.Point(169, 68);
            this.lblAutomaticFormulation.Name = "lblAutomaticFormulation";
            this.lblAutomaticFormulation.Size = new System.Drawing.Size(65, 19);
            this.lblAutomaticFormulation.TabIndex = 58;
            this.lblAutomaticFormulation.Text = "*AUTO*";
            this.lblAutomaticFormulation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gFormulacionGreen
            // 
            this.gFormulacionGreen.Image = global::MASngFE.Properties.Resources.iconGreen;
            this.gFormulacionGreen.Location = new System.Drawing.Point(138, 65);
            this.gFormulacionGreen.Name = "gFormulacionGreen";
            this.gFormulacionGreen.Size = new System.Drawing.Size(25, 26);
            this.gFormulacionGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.gFormulacionGreen.TabIndex = 165;
            this.gFormulacionGreen.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label7.Location = new System.Drawing.Point(9, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 169;
            this.label7.Text = "Status Formulacion";
            // 
            // btnSeleccionarFormula1
            // 
            this.btnSeleccionarFormula1.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnSeleccionarFormula1.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionarFormula1.Image")));
            this.btnSeleccionarFormula1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarFormula1.Location = new System.Drawing.Point(274, 6);
            this.btnSeleccionarFormula1.Name = "btnSeleccionarFormula1";
            this.btnSeleccionarFormula1.Size = new System.Drawing.Size(100, 40);
            this.btnSeleccionarFormula1.TabIndex = 166;
            this.btnSeleccionarFormula1.Text = "Seleccionar\r\nFormula";
            this.btnSeleccionarFormula1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionarFormula1.UseVisualStyleBackColor = true;
            this.btnSeleccionarFormula1.Click += new System.EventHandler(this.btnSeleccionarFormula1_Click);
            // 
            // gFormulacionRed
            // 
            this.gFormulacionRed.Image = global::MASngFE.Properties.Resources.iconRed;
            this.gFormulacionRed.Location = new System.Drawing.Point(138, 65);
            this.gFormulacionRed.Name = "gFormulacionRed";
            this.gFormulacionRed.Size = new System.Drawing.Size(25, 26);
            this.gFormulacionRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.gFormulacionRed.TabIndex = 164;
            this.gFormulacionRed.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label12.Location = new System.Drawing.Point(8, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Ultima VEZ Utilizada";
            // 
            // btnVerFormulas1
            // 
            this.btnVerFormulas1.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnVerFormulas1.Image = ((System.Drawing.Image)(resources.GetObject("btnVerFormulas1.Image")));
            this.btnVerFormulas1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerFormulas1.Location = new System.Drawing.Point(167, 6);
            this.btnVerFormulas1.Name = "btnVerFormulas1";
            this.btnVerFormulas1.Size = new System.Drawing.Size(100, 40);
            this.btnVerFormulas1.TabIndex = 167;
            this.btnVerFormulas1.Text = "VER\r\nFormulas";
            this.btnVerFormulas1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerFormulas1.UseVisualStyleBackColor = true;
            this.btnVerFormulas1.Click += new System.EventHandler(this.btnVerFormulas1_Click);
            // 
            // txtFechaUltimaFormulacion
            // 
            this.txtFechaUltimaFormulacion.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFechaUltimaFormulacion.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtFechaUltimaFormulacion.Location = new System.Drawing.Point(138, 140);
            this.txtFechaUltimaFormulacion.Name = "txtFechaUltimaFormulacion";
            this.txtFechaUltimaFormulacion.ReadOnly = true;
            this.txtFechaUltimaFormulacion.Size = new System.Drawing.Size(96, 21);
            this.txtFechaUltimaFormulacion.TabIndex = 14;
            this.txtFechaUltimaFormulacion.TabStop = false;
            this.txtFechaUltimaFormulacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Total ACTIVAS";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label11.Location = new System.Drawing.Point(8, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Descripcion Formulacion";
            // 
            // txtDescripcionFormulaSeleccionada
            // 
            this.txtDescripcionFormulaSeleccionada.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDescripcionFormulaSeleccionada.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtDescripcionFormulaSeleccionada.Location = new System.Drawing.Point(138, 117);
            this.txtDescripcionFormulaSeleccionada.Name = "txtDescripcionFormulaSeleccionada";
            this.txtDescripcionFormulaSeleccionada.ReadOnly = true;
            this.txtDescripcionFormulaSeleccionada.Size = new System.Drawing.Size(208, 21);
            this.txtDescripcionFormulaSeleccionada.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.RoyalBlue;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(382, 5);
            this.label6.TabIndex = 168;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 233);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(384, 19);
            this.label13.TabIndex = 26;
            this.label13.Text = "1 - FORMULACION";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlanear
            // 
            this.btnPlanear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlanear.Image = ((System.Drawing.Image)(resources.GetObject("btnPlanear.Image")));
            this.btnPlanear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlanear.Location = new System.Drawing.Point(1132, 65);
            this.btnPlanear.Name = "btnPlanear";
            this.btnPlanear.Size = new System.Drawing.Size(100, 40);
            this.btnPlanear.TabIndex = 31;
            this.btnPlanear.Text = "PLANEAR";
            this.btnPlanear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlanear.UseVisualStyleBackColor = true;
            this.btnPlanear.Click += new System.EventHandler(this.btnPlanear_Click);
            // 
            // btnImprimirFormula
            // 
            this.btnImprimirFormula.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirFormula.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirFormula.Image")));
            this.btnImprimirFormula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirFormula.Location = new System.Drawing.Point(1132, 106);
            this.btnImprimirFormula.Name = "btnImprimirFormula";
            this.btnImprimirFormula.Size = new System.Drawing.Size(100, 40);
            this.btnImprimirFormula.TabIndex = 32;
            this.btnImprimirFormula.Text = "Imprimir\r\nFormula";
            this.btnImprimirFormula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirFormula.UseVisualStyleBackColor = true;
            this.btnImprimirFormula.Click += new System.EventHandler(this.btnImprimirFormula_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.PaleVioletRed;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(2, 423);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(385, 19);
            this.label15.TabIndex = 33;
            this.label15.Text = "2 - SELECCION BATCH INFO";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnModificarTamañoBatch1);
            this.panel2.Controls.Add(this.ckReservaAutomatica);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.txtBatchQuantity);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.txtBatchSize);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.txtKgFabricarBatch);
            this.panel2.Location = new System.Drawing.Point(2, 441);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(385, 103);
            this.panel2.TabIndex = 26;
            // 
            // btnModificarTamañoBatch1
            // 
            this.btnModificarTamañoBatch1.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnModificarTamañoBatch1.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarTamañoBatch1.Image")));
            this.btnModificarTamañoBatch1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarTamañoBatch1.Location = new System.Drawing.Point(273, 6);
            this.btnModificarTamañoBatch1.Name = "btnModificarTamañoBatch1";
            this.btnModificarTamañoBatch1.Size = new System.Drawing.Size(100, 40);
            this.btnModificarTamañoBatch1.TabIndex = 170;
            this.btnModificarTamañoBatch1.Text = "Modificar\r\nBatch";
            this.btnModificarTamañoBatch1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarTamañoBatch1.UseVisualStyleBackColor = true;
            this.btnModificarTamañoBatch1.Click += new System.EventHandler(this.btnModificarTamañoBatch1_Click);
            // 
            // ckReservaAutomatica
            // 
            this.ckReservaAutomatica.AutoSize = true;
            this.ckReservaAutomatica.Checked = true;
            this.ckReservaAutomatica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckReservaAutomatica.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.ckReservaAutomatica.Location = new System.Drawing.Point(6, 78);
            this.ckReservaAutomatica.Name = "ckReservaAutomatica";
            this.ckReservaAutomatica.Size = new System.Drawing.Size(264, 17);
            this.ckReservaAutomatica.TabIndex = 20;
            this.ckReservaAutomatica.Text = "Reserva Automatica de Lotes  (Cuando sea Posible)";
            this.ckReservaAutomatica.UseVisualStyleBackColor = true;
            this.ckReservaAutomatica.CheckedChanged += new System.EventHandler(this.ckReservaAutomatica_CheckedChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label31.Location = new System.Drawing.Point(7, 52);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(103, 13);
            this.label31.TabIndex = 18;
            this.label31.Text = "Cantidad de Batches";
            // 
            // txtBatchQuantity
            // 
            this.txtBatchQuantity.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtBatchQuantity.Location = new System.Drawing.Point(127, 49);
            this.txtBatchQuantity.Name = "txtBatchQuantity";
            this.txtBatchQuantity.ReadOnly = true;
            this.txtBatchQuantity.Size = new System.Drawing.Size(37, 21);
            this.txtBatchQuantity.TabIndex = 19;
            this.txtBatchQuantity.TabStop = false;
            this.txtBatchQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label30.Location = new System.Drawing.Point(7, 29);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(111, 13);
            this.label30.TabIndex = 16;
            this.label30.Text = "Tamaño del Batch [KG]";
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtBatchSize.Location = new System.Drawing.Point(127, 26);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.ReadOnly = true;
            this.txtBatchSize.Size = new System.Drawing.Size(75, 21);
            this.txtBatchSize.TabIndex = 17;
            this.txtBatchSize.TabStop = false;
            this.txtBatchSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label18.Location = new System.Drawing.Point(7, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(115, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "KG Total Fabricar [New]";
            // 
            // txtKgFabricarBatch
            // 
            this.txtKgFabricarBatch.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtKgFabricarBatch.Location = new System.Drawing.Point(127, 3);
            this.txtKgFabricarBatch.Name = "txtKgFabricarBatch";
            this.txtKgFabricarBatch.ReadOnly = true;
            this.txtKgFabricarBatch.Size = new System.Drawing.Size(75, 21);
            this.txtKgFabricarBatch.TabIndex = 14;
            this.txtKgFabricarBatch.TabStop = false;
            this.txtKgFabricarBatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label44);
            this.panel3.Controls.Add(this.txtFechaCompromisoPlan);
            this.panel3.Controls.Add(this.label33);
            this.panel3.Controls.Add(this.txtKgPlaneados);
            this.panel3.Controls.Add(this.cmbOperador);
            this.panel3.Controls.Add(this.txtNumeroLote);
            this.panel3.Controls.Add(this.cmbRecursoProduccion);
            this.panel3.Controls.Add(this.dtpFechaPlan);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Location = new System.Drawing.Point(855, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 148);
            this.panel3.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(5, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Numero de Lote";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(5, 120);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(76, 13);
            this.label44.TabIndex = 173;
            this.label44.Text = "KG PLANEADOS";
            // 
            // txtFechaCompromisoPlan
            // 
            this.txtFechaCompromisoPlan.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtFechaCompromisoPlan.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaCompromisoPlan.Location = new System.Drawing.Point(123, 3);
            this.txtFechaCompromisoPlan.Name = "txtFechaCompromisoPlan";
            this.txtFechaCompromisoPlan.ReadOnly = true;
            this.txtFechaCompromisoPlan.Size = new System.Drawing.Size(118, 22);
            this.txtFechaCompromisoPlan.TabIndex = 40;
            this.txtFechaCompromisoPlan.TabStop = false;
            this.txtFechaCompromisoPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(5, 9);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(97, 13);
            this.label33.TabIndex = 42;
            this.label33.Text = "Fecha Compromiso";
            // 
            // txtKgPlaneados
            // 
            this.txtKgPlaneados.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtKgPlaneados.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgPlaneados.ForeColor = System.Drawing.Color.DeepPink;
            this.txtKgPlaneados.Location = new System.Drawing.Point(123, 117);
            this.txtKgPlaneados.Name = "txtKgPlaneados";
            this.txtKgPlaneados.ReadOnly = true;
            this.txtKgPlaneados.Size = new System.Drawing.Size(63, 21);
            this.txtKgPlaneados.TabIndex = 172;
            this.txtKgPlaneados.TabStop = false;
            this.txtKgPlaneados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbOperador
            // 
            this.cmbOperador.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOperador.FormattingEnabled = true;
            this.cmbOperador.Location = new System.Drawing.Point(123, 71);
            this.cmbOperador.Name = "cmbOperador";
            this.cmbOperador.Size = new System.Drawing.Size(141, 21);
            this.cmbOperador.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(855, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 15);
            this.label1.TabIndex = 57;
            this.label1.Text = "OBSERVACION EN IMPRESION DE ORDEN DE FABRICACION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbRecursoProduccion
            // 
            this.cmbRecursoProduccion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecursoProduccion.FormattingEnabled = true;
            this.cmbRecursoProduccion.Location = new System.Drawing.Point(123, 49);
            this.cmbRecursoProduccion.Name = "cmbRecursoProduccion";
            this.cmbRecursoProduccion.Size = new System.Drawing.Size(141, 21);
            this.cmbRecursoProduccion.TabIndex = 40;
            // 
            // dtpFechaPlan
            // 
            this.dtpFechaPlan.CalendarFont = new System.Drawing.Font("Calibri", 8.25F);
            this.dtpFechaPlan.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPlan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPlan.Location = new System.Drawing.Point(123, 27);
            this.dtpFechaPlan.Name = "dtpFechaPlan";
            this.dtpFechaPlan.Size = new System.Drawing.Size(118, 21);
            this.dtpFechaPlan.TabIndex = 40;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(5, 74);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(52, 13);
            this.label24.TabIndex = 18;
            this.label24.Text = "Operador";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(5, 52);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(114, 13);
            this.label25.TabIndex = 16;
            this.label25.Text = "Recurso de Produccion";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(5, 31);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(107, 13);
            this.label26.TabIndex = 13;
            this.label26.Text = "Fecha PLANIFICACION";
            // 
            // txtNotaOrdenFabricacion
            // 
            this.txtNotaOrdenFabricacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotaOrdenFabricacion.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtNotaOrdenFabricacion.Location = new System.Drawing.Point(855, 249);
            this.txtNotaOrdenFabricacion.Multiline = true;
            this.txtNotaOrdenFabricacion.Name = "txtNotaOrdenFabricacion";
            this.txtNotaOrdenFabricacion.Size = new System.Drawing.Size(270, 31);
            this.txtNotaOrdenFabricacion.TabIndex = 40;
            this.txtNotaOrdenFabricacion.Validating += new System.ComponentModel.CancelEventHandler(this.txtNotaOrdenFabricacion_Validating);
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Crimson;
            this.label32.Location = new System.Drawing.Point(855, 64);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(270, 19);
            this.label32.TabIndex = 35;
            this.label32.Text = "3 -PLANIFICACION PRODUCCION";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelarOF
            // 
            this.btnCancelarOF.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarOF.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarOF.Image")));
            this.btnCancelarOF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarOF.Location = new System.Drawing.Point(1132, 188);
            this.btnCancelarOF.Name = "btnCancelarOF";
            this.btnCancelarOF.Size = new System.Drawing.Size(100, 40);
            this.btnCancelarOF.TabIndex = 44;
            this.btnCancelarOF.Text = "CANCELAR";
            this.btnCancelarOF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarOF.UseVisualStyleBackColor = true;
            this.btnCancelarOF.Click += new System.EventHandler(this.btnCancelarOF_Click);
            // 
            // btnStandBy
            // 
            this.btnStandBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStandBy.Image = ((System.Drawing.Image)(resources.GetObject("btnStandBy.Image")));
            this.btnStandBy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStandBy.Location = new System.Drawing.Point(1132, 147);
            this.btnStandBy.Name = "btnStandBy";
            this.btnStandBy.Size = new System.Drawing.Size(100, 40);
            this.btnStandBy.TabIndex = 46;
            this.btnStandBy.Text = "Posponer\r\nFabricacion";
            this.btnStandBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStandBy.UseVisualStyleBackColor = true;
            this.btnStandBy.Click += new System.EventHandler(this.btnStandBy_Click);
            // 
            // lblStockNoDisponible
            // 
            this.lblStockNoDisponible.BackColor = System.Drawing.Color.Crimson;
            this.lblStockNoDisponible.Cursor = System.Windows.Forms.Cursors.No;
            this.lblStockNoDisponible.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockNoDisponible.ForeColor = System.Drawing.Color.White;
            this.lblStockNoDisponible.Location = new System.Drawing.Point(3, 582);
            this.lblStockNoDisponible.Name = "lblStockNoDisponible";
            this.lblStockNoDisponible.Size = new System.Drawing.Size(1228, 34);
            this.lblStockNoDisponible.TabIndex = 47;
            this.lblStockNoDisponible.Text = "ATENCION : NO HAY STOCK DISPONIBLE SUFICIENTE PARA FABRICAR";
            this.lblStockNoDisponible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStockNoDisponible.Visible = false;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(7, 5);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(88, 13);
            this.label34.TabIndex = 40;
            this.label34.Text = "CONTENEDOR STD";
            // 
            // txtContainerId
            // 
            this.txtContainerId.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContainerId.Location = new System.Drawing.Point(386, 2);
            this.txtContainerId.Name = "txtContainerId";
            this.txtContainerId.ReadOnly = true;
            this.txtContainerId.Size = new System.Drawing.Size(106, 21);
            this.txtContainerId.TabIndex = 48;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(499, 5);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(31, 13);
            this.label35.TabIndex = 49;
            this.label35.Text = "CANT";
            // 
            // txtCantidadContainers
            // 
            this.txtCantidadContainers.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadContainers.Location = new System.Drawing.Point(536, 2);
            this.txtCantidadContainers.Name = "txtCantidadContainers";
            this.txtCantidadContainers.Size = new System.Drawing.Size(52, 21);
            this.txtCantidadContainers.TabIndex = 50;
            this.txtCantidadContainers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidadContainers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadContainers_KeyPress);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cmbContainer);
            this.panel5.Controls.Add(this.label35);
            this.panel5.Controls.Add(this.label34);
            this.panel5.Controls.Add(this.txtCantidadContainers);
            this.panel5.Controls.Add(this.txtContainerId);
            this.panel5.Controls.Add(this.ckUpdateContainer);
            this.panel5.Location = new System.Drawing.Point(3, 546);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(845, 28);
            this.panel5.TabIndex = 51;
            // 
            // cmbContainer
            // 
            this.cmbContainer.DataSource = this.t0010ContainerBindingSource;
            this.cmbContainer.DisplayMember = "ContainerDescription";
            this.cmbContainer.FormattingEnabled = true;
            this.cmbContainer.Location = new System.Drawing.Point(101, 2);
            this.cmbContainer.Name = "cmbContainer";
            this.cmbContainer.Size = new System.Drawing.Size(283, 21);
            this.cmbContainer.TabIndex = 51;
            this.cmbContainer.ValueMember = "ContainerId";
            this.cmbContainer.SelectedIndexChanged += new System.EventHandler(this.cmbContainer_SelectedIndexChanged);
            // 
            // t0010ContainerBindingSource
            // 
            this.t0010ContainerBindingSource.DataSource = typeof(TecserEF.Entity.T0010_Container);
            // 
            // ckUpdateContainer
            // 
            this.ckUpdateContainer.AutoSize = true;
            this.ckUpdateContainer.Location = new System.Drawing.Point(631, 4);
            this.ckUpdateContainer.Name = "ckUpdateContainer";
            this.ckUpdateContainer.Size = new System.Drawing.Size(196, 17);
            this.ckUpdateContainer.TabIndex = 52;
            this.ckUpdateContainer.Text = "Actualizar Default  Container en MM";
            this.ckUpdateContainer.UseVisualStyleBackColor = true;
            this.ckUpdateContainer.CheckedChanged += new System.EventHandler(this.ckUpdateContainer_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1131, 392);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 53;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelHeader.Controls.Add(this.label8);
            this.panelHeader.Controls.Add(this.txtStatusLab);
            this.panelHeader.Controls.Add(this.label43);
            this.panelHeader.Controls.Add(this.txtKgFabricadosIngresados);
            this.panelHeader.Controls.Add(this.label37);
            this.panelHeader.Controls.Add(this.label38);
            this.panelHeader.Controls.Add(this.label39);
            this.panelHeader.Controls.Add(this.label40);
            this.panelHeader.Controls.Add(this.txtStatus);
            this.panelHeader.Controls.Add(this.txtnumeroOF);
            this.panelHeader.Controls.Add(this.txtMaterialPrimario);
            this.panelHeader.Controls.Add(this.txtMaterialEtiqueta);
            this.panelHeader.Location = new System.Drawing.Point(3, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1229, 59);
            this.panelHeader.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(848, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "ESTADO LAB";
            // 
            // txtStatusLab
            // 
            this.txtStatusLab.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtStatusLab.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatusLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusLab.Location = new System.Drawing.Point(968, 5);
            this.txtStatusLab.Name = "txtStatusLab";
            this.txtStatusLab.ReadOnly = true;
            this.txtStatusLab.Size = new System.Drawing.Size(130, 19);
            this.txtStatusLab.TabIndex = 26;
            this.txtStatusLab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(523, 30);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(142, 20);
            this.label43.TabIndex = 23;
            this.label43.Text = "KG FABRICADOS";
            // 
            // txtKgFabricadosIngresados
            // 
            this.txtKgFabricadosIngresados.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtKgFabricadosIngresados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKgFabricadosIngresados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgFabricadosIngresados.ForeColor = System.Drawing.Color.Crimson;
            this.txtKgFabricadosIngresados.Location = new System.Drawing.Point(684, 31);
            this.txtKgFabricadosIngresados.Name = "txtKgFabricadosIngresados";
            this.txtKgFabricadosIngresados.ReadOnly = true;
            this.txtKgFabricadosIngresados.Size = new System.Drawing.Size(76, 19);
            this.txtKgFabricadosIngresados.TabIndex = 24;
            this.txtKgFabricadosIngresados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(177, 30);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(89, 20);
            this.label37.TabIndex = 12;
            this.label37.Text = "ETIQUETA";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(523, 5);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(101, 20);
            this.label38.TabIndex = 6;
            this.label38.Text = "ESTADO OF";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(177, 4);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(89, 20);
            this.label39.TabIndex = 2;
            this.label39.Text = "PRIMARIO";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(16, 4);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(44, 20);
            this.label40.TabIndex = 1;
            this.label40.Text = "OF #";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.LightGray;
            this.panel7.Controls.Add(this.label27);
            this.panel7.Controls.Add(this.txtOrdenVentaNumero);
            this.panel7.Controls.Add(this.textBox27);
            this.panel7.Controls.Add(this.textBox26);
            this.panel7.Controls.Add(this.label29);
            this.panel7.Controls.Add(this.label28);
            this.panel7.Controls.Add(this.txtClienteFantasia);
            this.panel7.Controls.Add(this.txtPlanPara);
            this.panel7.Controls.Add(this.txtKgFabricarOri);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(2, 81);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(385, 78);
            this.panel7.TabIndex = 55;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(9, 56);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(31, 14);
            this.label29.TabIndex = 17;
            this.label29.Text = "OV #";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.DarkBlue;
            this.label20.Location = new System.Drawing.Point(392, 62);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(5, 483);
            this.label20.TabIndex = 58;
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMRP
            // 
            this.panelMRP.BackColor = System.Drawing.Color.Pink;
            this.panelMRP.Controls.Add(this.label36);
            this.panelMRP.Controls.Add(this.label23);
            this.panelMRP.Controls.Add(this.label17);
            this.panelMRP.Controls.Add(this.txtConsumoU30);
            this.panelMRP.Controls.Add(this.txtUltimaFabricacion);
            this.panelMRP.Controls.Add(this.txtConsumoU60);
            this.panelMRP.Controls.Add(this.txtConsumoP30);
            this.panelMRP.Controls.Add(this.txtNumeroClientes);
            this.panelMRP.Controls.Add(this.label22);
            this.panelMRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMRP.Location = new System.Drawing.Point(403, 81);
            this.panelMRP.Name = "panelMRP";
            this.panelMRP.Size = new System.Drawing.Size(435, 72);
            this.panelMRP.TabIndex = 56;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.label36.Location = new System.Drawing.Point(64, 30);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(82, 13);
            this.label36.TabIndex = 19;
            this.label36.Text = "CONSUMO U180";
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label45.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.DarkBlue;
            this.label45.Location = new System.Drawing.Point(843, 62);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(5, 483);
            this.label45.TabIndex = 169;
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ck1SeleccionFormula
            // 
            this.ck1SeleccionFormula.AutoSize = true;
            this.ck1SeleccionFormula.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ck1SeleccionFormula.FlatAppearance.BorderSize = 4;
            this.ck1SeleccionFormula.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ck1SeleccionFormula.Location = new System.Drawing.Point(862, 395);
            this.ck1SeleccionFormula.Name = "ck1SeleccionFormula";
            this.ck1SeleccionFormula.Size = new System.Drawing.Size(116, 17);
            this.ck1SeleccionFormula.TabIndex = 170;
            this.ck1SeleccionFormula.Text = "1 - Formulacion OK";
            this.ck1SeleccionFormula.UseVisualStyleBackColor = true;
            // 
            // ck2DeterminacionBatch
            // 
            this.ck2DeterminacionBatch.AutoSize = true;
            this.ck2DeterminacionBatch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ck2DeterminacionBatch.FlatAppearance.BorderSize = 4;
            this.ck2DeterminacionBatch.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ck2DeterminacionBatch.Location = new System.Drawing.Point(862, 416);
            this.ck2DeterminacionBatch.Name = "ck2DeterminacionBatch";
            this.ck2DeterminacionBatch.Size = new System.Drawing.Size(184, 17);
            this.ck2DeterminacionBatch.TabIndex = 171;
            this.ck2DeterminacionBatch.Text = "2 - Determinacion Batch Qty/Size";
            this.ck2DeterminacionBatch.UseVisualStyleBackColor = true;
            // 
            // ck3PlanRecursos
            // 
            this.ck3PlanRecursos.AutoSize = true;
            this.ck3PlanRecursos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ck3PlanRecursos.FlatAppearance.BorderSize = 4;
            this.ck3PlanRecursos.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ck3PlanRecursos.Location = new System.Drawing.Point(862, 437);
            this.ck3PlanRecursos.Name = "ck3PlanRecursos";
            this.ck3PlanRecursos.Size = new System.Drawing.Size(164, 17);
            this.ck3PlanRecursos.TabIndex = 172;
            this.ck3PlanRecursos.Text = "3 - Planificacion de Recursos";
            this.ck3PlanRecursos.UseVisualStyleBackColor = true;
            // 
            // ck5CierreOF
            // 
            this.ck5CierreOF.AutoSize = true;
            this.ck5CierreOF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ck5CierreOF.FlatAppearance.BorderSize = 4;
            this.ck5CierreOF.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ck5CierreOF.Location = new System.Drawing.Point(862, 479);
            this.ck5CierreOF.Name = "ck5CierreOF";
            this.ck5CierreOF.Size = new System.Drawing.Size(85, 17);
            this.ck5CierreOF.TabIndex = 173;
            this.ck5CierreOF.Text = "5 - Cierre OF";
            this.ck5CierreOF.UseVisualStyleBackColor = true;
            // 
            // ck4Fabricacion
            // 
            this.ck4Fabricacion.AutoSize = true;
            this.ck4Fabricacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ck4Fabricacion.FlatAppearance.BorderSize = 4;
            this.ck4Fabricacion.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ck4Fabricacion.Location = new System.Drawing.Point(862, 458);
            this.ck4Fabricacion.Name = "ck4Fabricacion";
            this.ck4Fabricacion.Size = new System.Drawing.Size(96, 17);
            this.ck4Fabricacion.TabIndex = 174;
            this.ck4Fabricacion.Text = "4 - Fabricacion";
            this.ck4Fabricacion.UseVisualStyleBackColor = true;
            // 
            // ck6AprobacionLab
            // 
            this.ck6AprobacionLab.AutoSize = true;
            this.ck6AprobacionLab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ck6AprobacionLab.FlatAppearance.BorderSize = 4;
            this.ck6AprobacionLab.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ck6AprobacionLab.Location = new System.Drawing.Point(862, 500);
            this.ck6AprobacionLab.Name = "ck6AprobacionLab";
            this.ck6AprobacionLab.Size = new System.Drawing.Size(151, 17);
            this.ck6AprobacionLab.TabIndex = 175;
            this.ck6AprobacionLab.Text = "6 - Aprobacion Laboratorio";
            this.ck6AprobacionLab.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(403, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(435, 18);
            this.label9.TabIndex = 176;
            this.label9.Text = "FORMULA COMPLETA A UTILIZAR ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.Location = new System.Drawing.Point(403, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(435, 18);
            this.label16.TabIndex = 177;
            this.label16.Text = "MRP DATA";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDetalleIngreso
            // 
            this.btnDetalleIngreso.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleIngreso.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalleIngreso.Image")));
            this.btnDetalleIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalleIngreso.Location = new System.Drawing.Point(1131, 229);
            this.btnDetalleIngreso.Name = "btnDetalleIngreso";
            this.btnDetalleIngreso.Size = new System.Drawing.Size(100, 40);
            this.btnDetalleIngreso.TabIndex = 178;
            this.btnDetalleIngreso.Text = "Detalle\r\nIngreso";
            this.btnDetalleIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleIngreso.UseVisualStyleBackColor = true;
            this.btnDetalleIngreso.Click += new System.EventHandler(this.btnDetalleIngreso_Click);
            // 
            // btnCQLab
            // 
            this.btnCQLab.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCQLab.Image = ((System.Drawing.Image)(resources.GetObject("btnCQLab.Image")));
            this.btnCQLab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCQLab.Location = new System.Drawing.Point(1131, 270);
            this.btnCQLab.Name = "btnCQLab";
            this.btnCQLab.Size = new System.Drawing.Size(100, 40);
            this.btnCQLab.TabIndex = 179;
            this.btnCQLab.Text = "CQ\r\nLAB";
            this.btnCQLab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCQLab.UseVisualStyleBackColor = true;
            this.btnCQLab.Click += new System.EventHandler(this.btnCQLab_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label21.Location = new System.Drawing.Point(2, 64);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(386, 18);
            this.label21.TabIndex = 180;
            this.label21.Text = "ENCABEZADO ORDEN DE FABRICACION";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPP02PlanificacionOF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1244, 624);
            this.ControlBox = false;
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnCQLab);
            this.Controls.Add(this.btnDetalleIngreso);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ck6AprobacionLab);
            this.Controls.Add(this.ck4Fabricacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ck5CierreOF);
            this.Controls.Add(this.ck3PlanRecursos);
            this.Controls.Add(this.ck2DeterminacionBatch);
            this.Controls.Add(this.ck1SeleccionFormula);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.txtNotaOrdenFabricacion);
            this.Controls.Add(this.dgvFormulaSeleccionada);
            this.Controls.Add(this.panelMRP);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnPlanear);
            this.Controls.Add(this.btnImprimirFormula);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnStandBy);
            this.Controls.Add(this.btnCancelarOF);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtObservacionPF);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panelFormulacion);
            this.Controls.Add(this.lblStockNoDisponible);
            this.MaximizeBox = false;
            this.Name = "FrmPP02PlanificacionOF";
            this.Text = "PP02 - Planificacion de Orden de Fabricacion";
            this.Load += new System.EventHandler(this.FrmPlanProduccionOF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulaSeleccionada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0072Bs)).EndInit();
            this.panelFormulacion.ResumeLayout(false);
            this.panelFormulacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gFormulacionGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gFormulacionRed)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0010ContainerBindingSource)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panelMRP.ResumeLayout(false);
            this.panelMRP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMaterialPrimario;
        private System.Windows.Forms.TextBox txtMaterialEtiqueta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroFormulaSeleccionada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroFormulasTotales;
        private System.Windows.Forms.TextBox txtNumeroFormulasActivas;
        private System.Windows.Forms.TextBox txtNumeroLote;
        private System.Windows.Forms.TextBox txtnumeroOF;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtClienteFantasia;
        private System.Windows.Forms.TextBox txtOrdenVentaNumero;
        private System.Windows.Forms.TextBox txtPlanPara;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelFormulacion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFechaUltimaFormulacion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescripcionFormulaSeleccionada;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtUltimaFabricacion;
        private System.Windows.Forms.TextBox txtConsumoU30;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtConsumoU60;
        private System.Windows.Forms.TextBox txtNumeroClientes;
        private System.Windows.Forms.TextBox txtConsumoP30;
        private System.Windows.Forms.TextBox txtObservacionPF;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtKgFabricarOri;
        private System.Windows.Forms.Button btnPlanear;
        private System.Windows.Forms.Button btnImprimirFormula;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtBatchQuantity;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtBatchSize;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtKgFabricarBatch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbOperador;
        private System.Windows.Forms.ComboBox cmbRecursoProduccion;
        private System.Windows.Forms.DateTimePicker dtpFechaPlan;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnCancelarOF;
        private System.Windows.Forms.TextBox txtNotaOrdenFabricacion;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnStandBy;
        private Label lblStockNoDisponible;
        private CheckBox ckReservaAutomatica;
        private DataGridView dgvFormulaSeleccionada;
        private BindingSource t0072Bs;
        private Label label34;
        private TextBox txtContainerId;
        private Label label35;
        private TextBox txtCantidadContainers;
        private Panel panel5;
        private ComboBox cmbContainer;
        private BindingSource t0010ContainerBindingSource;
        private CheckBox ckUpdateContainer;
        private Button btnExit;
        private ToolTip toolTip1;
        private Panel panelHeader;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label40;
        private Panel panel7;
        private Label label1;
        private PictureBox gFormulacionGreen;
        private Label label7;
        private Label label6;
        private Button btnSeleccionarFormula1;
        private PictureBox gFormulacionRed;
        private Button btnVerFormulas1;
        private Label label2;
        private Label lblAutomaticFormulation;
        private Button btnModificarTamañoBatch1;
        private Label label44;
        private TextBox txtKgPlaneados;
        private Label label43;
        private TextBox txtKgFabricadosIngresados;
        private Label label20;
        private Panel panelMRP;
        private TextBox txtFechaCompromisoPlan;
        private Label label45;
        private CheckBox ck1SeleccionFormula;
        private CheckBox ck2DeterminacionBatch;
        private CheckBox ck3PlanRecursos;
        private CheckBox ck5CierreOF;
        private CheckBox ck4Fabricacion;
        private CheckBox ck6AprobacionLab;
        private Label label5;
        private Label label8;
        private TextBox txtStatusLab;
        private Label label29;
        private CheckBox ckAutoFormulacion;
        private Label label36;
        private Label label9;
        private Label label16;
        private Button btnDetalleIngreso;
        private Button btnCQLab;
        private DataGridViewTextBoxColumn idItemFormulaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn __primario;
        private DataGridViewTextBoxColumn cantidadBaseDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn __porcentaje;
        private DataGridViewTextBoxColumn __kg;
        private DataGridViewTextBoxColumn batchNumberDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn __reproceso;
        private DataGridViewCheckBoxColumn __added;
        private DataGridViewCheckBoxColumn __recalculo;
        private Label label21;
    }
}