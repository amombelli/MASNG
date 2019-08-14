namespace MASngFE.Transactional.PP
{
    partial class FrmPP11SelectBatch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP11SelectBatch));
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckSoloDisponible = new System.Windows.Forms.CheckBox();
            this.dgvStockDisponible = new System.Windows.Forms.DataGridView();
            this.iDStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reservaOFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnLiberarDgv = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0030STOCKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtKgRequeridos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKgLineaSeleccionada = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKgAUtilizar = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSelectLote = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKgPendienteSeleccion = new System.Windows.Forms.TextBox();
            this.btnLiberarSeleccion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltroLote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ckSoloStockMayorIgual = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnMoveStockLocation = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnConsolidar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDisponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaterial
            // 
            this.txtMaterial.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterial.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtMaterial.Location = new System.Drawing.Point(135, 4);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(164, 21);
            this.txtMaterial.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Material A Descontar";
            // 
            // ckSoloDisponible
            // 
            this.ckSoloDisponible.AutoSize = true;
            this.ckSoloDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloDisponible.Location = new System.Drawing.Point(10, 32);
            this.ckSoloDisponible.Name = "ckSoloDisponible";
            this.ckSoloDisponible.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckSoloDisponible.Size = new System.Drawing.Size(354, 19);
            this.ckSoloDisponible.TabIndex = 2;
            this.ckSoloDisponible.Text = "Visualizar Solo Stock Habilitado para Descuento Produccion";
            this.ckSoloDisponible.UseVisualStyleBackColor = true;
            this.ckSoloDisponible.CheckedChanged += new System.EventHandler(this.ckSoloDisponible_CheckedChanged);
            // 
            // dgvStockDisponible
            // 
            this.dgvStockDisponible.AllowUserToAddRows = false;
            this.dgvStockDisponible.AllowUserToDeleteRows = false;
            this.dgvStockDisponible.AutoGenerateColumns = false;
            this.dgvStockDisponible.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockDisponible.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockDisponible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockDisponible.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDStockDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.batchDataGridViewTextBoxColumn,
            this.stockDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.sLOCDataGridViewTextBoxColumn,
            this.reservaOFDataGridViewTextBoxColumn,
            this.BtnSelect,
            this.btnLiberarDgv});
            this.dgvStockDisponible.DataSource = this.t0030STOCKBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStockDisponible.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStockDisponible.GridColor = System.Drawing.SystemColors.GrayText;
            this.dgvStockDisponible.Location = new System.Drawing.Point(1, 148);
            this.dgvStockDisponible.MultiSelect = false;
            this.dgvStockDisponible.Name = "dgvStockDisponible";
            this.dgvStockDisponible.ReadOnly = true;
            this.dgvStockDisponible.RowHeadersWidth = 30;
            this.dgvStockDisponible.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockDisponible.Size = new System.Drawing.Size(552, 224);
            this.dgvStockDisponible.TabIndex = 3;
            this.dgvStockDisponible.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockDisponible_CellContentClick);
            this.dgvStockDisponible.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockDisponible_CellEnter);
            // 
            // iDStockDataGridViewTextBoxColumn
            // 
            this.iDStockDataGridViewTextBoxColumn.DataPropertyName = "IDStock";
            this.iDStockDataGridViewTextBoxColumn.HeaderText = "IDStock";
            this.iDStockDataGridViewTextBoxColumn.Name = "iDStockDataGridViewTextBoxColumn";
            this.iDStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDStockDataGridViewTextBoxColumn.Visible = false;
            this.iDStockDataGridViewTextBoxColumn.Width = 30;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            this.materialDataGridViewTextBoxColumn.HeaderText = "MATERIAL";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // batchDataGridViewTextBoxColumn
            // 
            this.batchDataGridViewTextBoxColumn.DataPropertyName = "Batch";
            this.batchDataGridViewTextBoxColumn.HeaderText = "LOTE #";
            this.batchDataGridViewTextBoxColumn.Name = "batchDataGridViewTextBoxColumn";
            this.batchDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchDataGridViewTextBoxColumn.Width = 80;
            // 
            // stockDataGridViewTextBoxColumn
            // 
            this.stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            this.stockDataGridViewTextBoxColumn.HeaderText = "KG";
            this.stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            this.stockDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockDataGridViewTextBoxColumn.Width = 50;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "ESTADO";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // sLOCDataGridViewTextBoxColumn
            // 
            this.sLOCDataGridViewTextBoxColumn.DataPropertyName = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.HeaderText = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.Name = "sLOCDataGridViewTextBoxColumn";
            this.sLOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.sLOCDataGridViewTextBoxColumn.Width = 40;
            // 
            // reservaOFDataGridViewTextBoxColumn
            // 
            this.reservaOFDataGridViewTextBoxColumn.DataPropertyName = "ReservaOF";
            this.reservaOFDataGridViewTextBoxColumn.HeaderText = "RESERVA OF#";
            this.reservaOFDataGridViewTextBoxColumn.Name = "reservaOFDataGridViewTextBoxColumn";
            this.reservaOFDataGridViewTextBoxColumn.ReadOnly = true;
            this.reservaOFDataGridViewTextBoxColumn.Width = 90;
            // 
            // BtnSelect
            // 
            this.BtnSelect.HeaderText = "SELECT";
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.ReadOnly = true;
            this.BtnSelect.Text = "SELECT";
            this.BtnSelect.UseColumnTextForButtonValue = true;
            this.BtnSelect.Visible = false;
            this.BtnSelect.Width = 60;
            // 
            // btnLiberarDgv
            // 
            this.btnLiberarDgv.HeaderText = "ACCION";
            this.btnLiberarDgv.Name = "btnLiberarDgv";
            this.btnLiberarDgv.ReadOnly = true;
            this.btnLiberarDgv.Text = "Liberar";
            this.btnLiberarDgv.ToolTipText = "Liberar este Stock Reservado";
            this.btnLiberarDgv.UseColumnTextForButtonValue = true;
            this.btnLiberarDgv.Width = 60;
            // 
            // t0030STOCKBindingSource
            // 
            this.t0030STOCKBindingSource.DataSource = typeof(TecserEF.Entity.T0030_STOCK);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(196, 46);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Regresar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtKgRequeridos
            // 
            this.txtKgRequeridos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKgRequeridos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgRequeridos.Location = new System.Drawing.Point(135, 28);
            this.txtKgRequeridos.Name = "txtKgRequeridos";
            this.txtKgRequeridos.ReadOnly = true;
            this.txtKgRequeridos.Size = new System.Drawing.Size(71, 21);
            this.txtKgRequeridos.TabIndex = 5;
            this.txtKgRequeridos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "KG Seleccionados";
            // 
            // txtKgLineaSeleccionada
            // 
            this.txtKgLineaSeleccionada.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtKgLineaSeleccionada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKgLineaSeleccionada.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgLineaSeleccionada.Location = new System.Drawing.Point(120, 8);
            this.txtKgLineaSeleccionada.Name = "txtKgLineaSeleccionada";
            this.txtKgLineaSeleccionada.ReadOnly = true;
            this.txtKgLineaSeleccionada.Size = new System.Drawing.Size(71, 23);
            this.txtKgLineaSeleccionada.TabIndex = 7;
            this.txtKgLineaSeleccionada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "KG A Utilizar";
            // 
            // txtKgAUtilizar
            // 
            this.txtKgAUtilizar.BackColor = System.Drawing.Color.White;
            this.txtKgAUtilizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKgAUtilizar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgAUtilizar.ForeColor = System.Drawing.Color.Navy;
            this.txtKgAUtilizar.Location = new System.Drawing.Point(120, 33);
            this.txtKgAUtilizar.Name = "txtKgAUtilizar";
            this.txtKgAUtilizar.Size = new System.Drawing.Size(71, 23);
            this.txtKgAUtilizar.TabIndex = 9;
            this.txtKgAUtilizar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKgAUtilizar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKgAUtilizar_KeyPress);
            this.txtKgAUtilizar.Validating += new System.ComponentModel.CancelEventHandler(this.txtKgAUtilizar_Validating);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnSelectLote);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtKgPendienteSeleccion);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtKgLineaSeleccionada);
            this.panel1.Controls.Add(this.txtKgAUtilizar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Location = new System.Drawing.Point(556, 167);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 94);
            this.panel1.TabIndex = 17;
            // 
            // BtnSelectLote
            // 
            this.BtnSelectLote.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelectLote.ForeColor = System.Drawing.Color.ForestGreen;
            this.BtnSelectLote.Image = ((System.Drawing.Image)(resources.GetObject("BtnSelectLote.Image")));
            this.BtnSelectLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSelectLote.Location = new System.Drawing.Point(196, 4);
            this.BtnSelectLote.Name = "BtnSelectLote";
            this.BtnSelectLote.Size = new System.Drawing.Size(100, 40);
            this.BtnSelectLote.TabIndex = 41;
            this.BtnSelectLote.Text = "Confirmar\r\nSeleccion";
            this.BtnSelectLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSelectLote.UseVisualStyleBackColor = true;
            this.BtnSelectLote.Click += new System.EventHandler(this.BtnSelectLote_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "KG Pendientes";
            // 
            // txtKgPendienteSeleccion
            // 
            this.txtKgPendienteSeleccion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtKgPendienteSeleccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKgPendienteSeleccion.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgPendienteSeleccion.Location = new System.Drawing.Point(120, 58);
            this.txtKgPendienteSeleccion.Name = "txtKgPendienteSeleccion";
            this.txtKgPendienteSeleccion.ReadOnly = true;
            this.txtKgPendienteSeleccion.Size = new System.Drawing.Size(71, 23);
            this.txtKgPendienteSeleccion.TabIndex = 19;
            this.txtKgPendienteSeleccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLiberarSeleccion
            // 
            this.btnLiberarSeleccion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLiberarSeleccion.BackgroundImage")));
            this.btnLiberarSeleccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLiberarSeleccion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiberarSeleccion.ForeColor = System.Drawing.Color.Red;
            this.btnLiberarSeleccion.Location = new System.Drawing.Point(753, 266);
            this.btnLiberarSeleccion.Name = "btnLiberarSeleccion";
            this.btnLiberarSeleccion.Size = new System.Drawing.Size(100, 40);
            this.btnLiberarSeleccion.TabIndex = 42;
            this.btnLiberarSeleccion.Text = "Liberar\r\nLote";
            this.btnLiberarSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLiberarSeleccion.UseVisualStyleBackColor = true;
            this.btnLiberarSeleccion.Click += new System.EventHandler(this.btnLiberarSeleccion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Filtrar Por Lote #";
            // 
            // txtFiltroLote
            // 
            this.txtFiltroLote.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFiltroLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroLote.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtFiltroLote.Location = new System.Drawing.Point(135, 6);
            this.txtFiltroLote.Name = "txtFiltroLote";
            this.txtFiltroLote.Size = new System.Drawing.Size(99, 21);
            this.txtFiltroLote.TabIndex = 18;
            this.txtFiltroLote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltroLote_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Crimson;
            this.label5.Location = new System.Drawing.Point(240, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "** Buscar Lote (new!)";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtMaterial);
            this.panel2.Controls.Add(this.txtKgRequeridos);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(1, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(860, 56);
            this.panel2.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "KG Requeridos OF";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.ckSoloStockMayorIgual);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtFiltroLote);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.ckSoloDisponible);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(1, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(860, 82);
            this.panel3.TabIndex = 22;
            // 
            // ckSoloStockMayorIgual
            // 
            this.ckSoloStockMayorIgual.AutoSize = true;
            this.ckSoloStockMayorIgual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloStockMayorIgual.Location = new System.Drawing.Point(10, 57);
            this.ckSoloStockMayorIgual.Name = "ckSoloStockMayorIgual";
            this.ckSoloStockMayorIgual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckSoloStockMayorIgual.Size = new System.Drawing.Size(354, 19);
            this.ckSoloStockMayorIgual.TabIndex = 21;
            this.ckSoloStockMayorIgual.Text = "Visualizar Solo Lineas con Stock Mayor o Igual al Requerido";
            this.ckSoloStockMayorIgual.UseVisualStyleBackColor = true;
            this.ckSoloStockMayorIgual.CheckedChanged += new System.EventHandler(this.ckSoloStockMayorIgual_CheckedChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Purple;
            this.label10.Location = new System.Drawing.Point(556, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(305, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "** DETALLES DE LA SELECCION **";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMoveStockLocation
            // 
            this.btnMoveStockLocation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMoveStockLocation.BackgroundImage")));
            this.btnMoveStockLocation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMoveStockLocation.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveStockLocation.ForeColor = System.Drawing.Color.Red;
            this.btnMoveStockLocation.Location = new System.Drawing.Point(15, 3);
            this.btnMoveStockLocation.Name = "btnMoveStockLocation";
            this.btnMoveStockLocation.Size = new System.Drawing.Size(100, 40);
            this.btnMoveStockLocation.TabIndex = 42;
            this.btnMoveStockLocation.Text = "Mover\r\nSTOCK";
            this.btnMoveStockLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMoveStockLocation.UseVisualStyleBackColor = true;
            this.btnMoveStockLocation.Click += new System.EventHandler(this.btnMoveStockLocation_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnConsolidar);
            this.panel4.Controls.Add(this.btnMoveStockLocation);
            this.panel4.Location = new System.Drawing.Point(1, 374);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(552, 50);
            this.panel4.TabIndex = 43;
            // 
            // btnConsolidar
            // 
            this.btnConsolidar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsolidar.BackgroundImage")));
            this.btnConsolidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConsolidar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsolidar.ForeColor = System.Drawing.Color.Navy;
            this.btnConsolidar.Location = new System.Drawing.Point(441, 3);
            this.btnConsolidar.Name = "btnConsolidar";
            this.btnConsolidar.Size = new System.Drawing.Size(100, 40);
            this.btnConsolidar.TabIndex = 43;
            this.btnConsolidar.Text = "Unificar\r\nLotes";
            this.btnConsolidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsolidar.UseVisualStyleBackColor = true;
            this.btnConsolidar.Click += new System.EventHandler(this.btnConsolidar_Click);
            // 
            // FrmPP11SelectBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 427);
            this.Controls.Add(this.btnLiberarSeleccion);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvStockDisponible);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FrmPP11SelectBatch";
            this.Text = "PP11 - SELECCION DE LOTE PARA CIERRE DE OF";
            this.Load += new System.EventHandler(this.FrmSeleccionBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDisponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckSoloDisponible;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtKgRequeridos;
        private System.Windows.Forms.DataGridView dgvStockDisponible;
        private System.Windows.Forms.BindingSource t0030STOCKBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKgLineaSeleccionada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKgAUtilizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtKgPendienteSeleccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltroLote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnSelectLote;
        private System.Windows.Forms.CheckBox ckSoloStockMayorIgual;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnMoveStockLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reservaOFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn BtnSelect;
        private System.Windows.Forms.DataGridViewButtonColumn btnLiberarDgv;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnConsolidar;
        private System.Windows.Forms.Button btnLiberarSeleccion;
    }
}