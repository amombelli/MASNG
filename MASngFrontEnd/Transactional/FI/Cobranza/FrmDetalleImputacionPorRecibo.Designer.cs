namespace MASngFE.Transactional.FI.Cobranza
{
    partial class FrmDetalleImputacionPorRecibo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.t0207SPLITFACTURASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId6 = new System.Windows.Forms.TextBox();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMoneda2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMontoPendienteImputacion = new System.Windows.Forms.TextBox();
            this.txtMoneda1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdCob = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalImputado = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiasPP = new System.Windows.Forms.TextBox();
            this.txtLx = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReciboOficial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReciboInterno = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTCRecibo = new System.Windows.Forms.TextBox();
            this.fACTSPLITDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fACTFECHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fACTMONEDADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tOTALDOCUMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mONTOAPLICADODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aplicadoPorcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDCTACTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasPPCob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasImpu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocCancel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0207SPLITFACTURASBindingSource)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(644, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 33);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AutoGenerateColumns = false;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fACTSPLITDataGridViewTextBoxColumn,
            this.tDOCDataGridViewTextBoxColumn,
            this.nDOCDataGridViewTextBoxColumn,
            this.fACTFECHADataGridViewTextBoxColumn,
            this.fACTMONEDADataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.tOTALDOCUMENTO,
            this.mONTOAPLICADODataGridViewTextBoxColumn,
            this.aplicadoPorcentaje,
            this.iDCTACTEDataGridViewTextBoxColumn,
            this.DiasPPCob,
            this.DiasImpu,
            this.TipoDocCancel});
            this.dgvLista.DataSource = this.t0207SPLITFACTURASBindingSource;
            this.dgvLista.Location = new System.Drawing.Point(3, 209);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersWidth = 20;
            this.dgvLista.Size = new System.Drawing.Size(729, 214);
            this.dgvLista.TabIndex = 1;
            // 
            // t0207SPLITFACTURASBindingSource
            // 
            this.t0207SPLITFACTURASBindingSource.DataSource = typeof(TecserEF.Entity.T0207_SPLITFACTURAS);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.txtRazonSocial);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtId6);
            this.panel5.Controls.Add(this.txtFantasia);
            this.panel5.Location = new System.Drawing.Point(3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(420, 56);
            this.panel5.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Razón Social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(94, 4);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(246, 21);
            this.txtRazonSocial.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fantasia";
            // 
            // txtId6
            // 
            this.txtId6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId6.Location = new System.Drawing.Point(342, 4);
            this.txtId6.Margin = new System.Windows.Forms.Padding(2);
            this.txtId6.Name = "txtId6";
            this.txtId6.ReadOnly = true;
            this.txtId6.Size = new System.Drawing.Size(46, 21);
            this.txtId6.TabIndex = 9;
            // 
            // txtFantasia
            // 
            this.txtFantasia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFantasia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFantasia.Location = new System.Drawing.Point(94, 27);
            this.txtFantasia.Margin = new System.Windows.Forms.Padding(2);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.ReadOnly = true;
            this.txtFantasia.Size = new System.Drawing.Size(246, 21);
            this.txtFantasia.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtTCRecibo);
            this.panel1.Controls.Add(this.txtMoneda2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtMontoPendienteImputacion);
            this.panel1.Controls.Add(this.txtMoneda1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtIdCob);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtTotalImputado);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtDiasPP);
            this.panel1.Controls.Add(this.txtLx);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtFecha);
            this.panel1.Controls.Add(this.txtImporte);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtReciboOficial);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtMoneda);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtReciboInterno);
            this.panel1.Location = new System.Drawing.Point(3, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 146);
            this.panel1.TabIndex = 78;
            // 
            // txtMoneda2
            // 
            this.txtMoneda2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoneda2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneda2.Location = new System.Drawing.Point(101, 114);
            this.txtMoneda2.Margin = new System.Windows.Forms.Padding(2);
            this.txtMoneda2.Name = "txtMoneda2";
            this.txtMoneda2.ReadOnly = true;
            this.txtMoneda2.Size = new System.Drawing.Size(38, 21);
            this.txtMoneda2.TabIndex = 86;
            this.txtMoneda2.TabStop = false;
            this.txtMoneda2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(5, 116);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 15);
            this.label10.TabIndex = 84;
            this.label10.Text = "Pendiente Imp.";
            // 
            // txtMontoPendienteImputacion
            // 
            this.txtMontoPendienteImputacion.BackColor = System.Drawing.SystemColors.Info;
            this.txtMontoPendienteImputacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoPendienteImputacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoPendienteImputacion.Location = new System.Drawing.Point(140, 114);
            this.txtMontoPendienteImputacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoPendienteImputacion.Name = "txtMontoPendienteImputacion";
            this.txtMontoPendienteImputacion.ReadOnly = true;
            this.txtMontoPendienteImputacion.Size = new System.Drawing.Size(88, 21);
            this.txtMontoPendienteImputacion.TabIndex = 85;
            this.txtMontoPendienteImputacion.TabStop = false;
            // 
            // txtMoneda1
            // 
            this.txtMoneda1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoneda1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneda1.Location = new System.Drawing.Point(101, 92);
            this.txtMoneda1.Margin = new System.Windows.Forms.Padding(2);
            this.txtMoneda1.Name = "txtMoneda1";
            this.txtMoneda1.ReadOnly = true;
            this.txtMoneda1.Size = new System.Drawing.Size(38, 21);
            this.txtMoneda1.TabIndex = 83;
            this.txtMoneda1.TabStop = false;
            this.txtMoneda1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(233, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "<<IDCOB";
            // 
            // txtIdCob
            // 
            this.txtIdCob.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtIdCob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdCob.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCob.Location = new System.Drawing.Point(167, 4);
            this.txtIdCob.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdCob.Name = "txtIdCob";
            this.txtIdCob.ReadOnly = true;
            this.txtIdCob.Size = new System.Drawing.Size(61, 21);
            this.txtIdCob.TabIndex = 0;
            this.txtIdCob.TabStop = false;
            this.txtIdCob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(5, 94);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 15);
            this.label9.TabIndex = 81;
            this.label9.Text = "Total Imputado";
            // 
            // txtTotalImputado
            // 
            this.txtTotalImputado.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalImputado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalImputado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalImputado.Location = new System.Drawing.Point(140, 92);
            this.txtTotalImputado.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalImputado.Name = "txtTotalImputado";
            this.txtTotalImputado.ReadOnly = true;
            this.txtTotalImputado.Size = new System.Drawing.Size(88, 21);
            this.txtTotalImputado.TabIndex = 82;
            this.txtTotalImputado.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(247, 116);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 15);
            this.label12.TabIndex = 80;
            this.label12.Text = "Dias PP Recibo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(325, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Tipo LX";
            // 
            // txtDiasPP
            // 
            this.txtDiasPP.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDiasPP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiasPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiasPP.Location = new System.Drawing.Point(345, 114);
            this.txtDiasPP.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiasPP.Name = "txtDiasPP";
            this.txtDiasPP.ReadOnly = true;
            this.txtDiasPP.Size = new System.Drawing.Size(60, 21);
            this.txtDiasPP.TabIndex = 79;
            this.txtDiasPP.TabStop = false;
            // 
            // txtLx
            // 
            this.txtLx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLx.Location = new System.Drawing.Point(378, 4);
            this.txtLx.Margin = new System.Windows.Forms.Padding(2);
            this.txtLx.Name = "txtLx";
            this.txtLx.ReadOnly = true;
            this.txtLx.Size = new System.Drawing.Size(27, 21);
            this.txtLx.TabIndex = 23;
            this.txtLx.TabStop = false;
            this.txtLx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(5, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Fecha Recibo";
            // 
            // txtFecha
            // 
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(101, 48);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(2);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(127, 21);
            this.txtFecha.TabIndex = 21;
            this.txtFecha.TabStop = false;
            // 
            // txtImporte
            // 
            this.txtImporte.BackColor = System.Drawing.SystemColors.Info;
            this.txtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporte.Location = new System.Drawing.Point(140, 70);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ReadOnly = true;
            this.txtImporte.Size = new System.Drawing.Size(88, 21);
            this.txtImporte.TabIndex = 20;
            this.txtImporte.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(5, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "IMPORTE";
            // 
            // txtReciboOficial
            // 
            this.txtReciboOficial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReciboOficial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReciboOficial.Location = new System.Drawing.Point(101, 26);
            this.txtReciboOficial.Margin = new System.Windows.Forms.Padding(2);
            this.txtReciboOficial.Name = "txtReciboOficial";
            this.txtReciboOficial.ReadOnly = true;
            this.txtReciboOficial.Size = new System.Drawing.Size(127, 21);
            this.txtReciboOficial.TabIndex = 16;
            this.txtReciboOficial.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(5, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Recibo Oficial#";
            // 
            // txtMoneda
            // 
            this.txtMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneda.Location = new System.Drawing.Point(101, 70);
            this.txtMoneda.Margin = new System.Windows.Forms.Padding(2);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(38, 21);
            this.txtMoneda.TabIndex = 18;
            this.txtMoneda.TabStop = false;
            this.txtMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(5, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Recibo Interno";
            // 
            // txtReciboInterno
            // 
            this.txtReciboInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReciboInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReciboInterno.Location = new System.Drawing.Point(101, 4);
            this.txtReciboInterno.Margin = new System.Windows.Forms.Padding(2);
            this.txtReciboInterno.Name = "txtReciboInterno";
            this.txtReciboInterno.ReadOnly = true;
            this.txtReciboInterno.Size = new System.Drawing.Size(61, 21);
            this.txtReciboInterno.TabIndex = 14;
            this.txtReciboInterno.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(265, 28);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 88;
            this.label11.Text = "USD Recibo";
            // 
            // txtTCRecibo
            // 
            this.txtTCRecibo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTCRecibo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTCRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTCRecibo.Location = new System.Drawing.Point(345, 26);
            this.txtTCRecibo.Margin = new System.Windows.Forms.Padding(2);
            this.txtTCRecibo.Name = "txtTCRecibo";
            this.txtTCRecibo.ReadOnly = true;
            this.txtTCRecibo.Size = new System.Drawing.Size(60, 21);
            this.txtTCRecibo.TabIndex = 87;
            this.txtTCRecibo.TabStop = false;
            // 
            // fACTSPLITDataGridViewTextBoxColumn
            // 
            this.fACTSPLITDataGridViewTextBoxColumn.DataPropertyName = "FACTSPLIT";
            this.fACTSPLITDataGridViewTextBoxColumn.HeaderText = "SPL";
            this.fACTSPLITDataGridViewTextBoxColumn.Name = "fACTSPLITDataGridViewTextBoxColumn";
            this.fACTSPLITDataGridViewTextBoxColumn.ReadOnly = true;
            this.fACTSPLITDataGridViewTextBoxColumn.Width = 30;
            // 
            // tDOCDataGridViewTextBoxColumn
            // 
            this.tDOCDataGridViewTextBoxColumn.DataPropertyName = "TDOC";
            this.tDOCDataGridViewTextBoxColumn.HeaderText = "TDOC";
            this.tDOCDataGridViewTextBoxColumn.Name = "tDOCDataGridViewTextBoxColumn";
            this.tDOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tDOCDataGridViewTextBoxColumn.Width = 40;
            // 
            // nDOCDataGridViewTextBoxColumn
            // 
            this.nDOCDataGridViewTextBoxColumn.DataPropertyName = "NDOC";
            this.nDOCDataGridViewTextBoxColumn.HeaderText = "NUMERO";
            this.nDOCDataGridViewTextBoxColumn.Name = "nDOCDataGridViewTextBoxColumn";
            this.nDOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.nDOCDataGridViewTextBoxColumn.Width = 90;
            // 
            // fACTFECHADataGridViewTextBoxColumn
            // 
            this.fACTFECHADataGridViewTextBoxColumn.DataPropertyName = "FECHA_FACT";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fACTFECHADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fACTFECHADataGridViewTextBoxColumn.HeaderText = "FECHA DOC";
            this.fACTFECHADataGridViewTextBoxColumn.Name = "fACTFECHADataGridViewTextBoxColumn";
            this.fACTFECHADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fACTMONEDADataGridViewTextBoxColumn
            // 
            this.fACTMONEDADataGridViewTextBoxColumn.DataPropertyName = "FACT_MONEDA";
            this.fACTMONEDADataGridViewTextBoxColumn.HeaderText = "MON";
            this.fACTMONEDADataGridViewTextBoxColumn.Name = "fACTMONEDADataGridViewTextBoxColumn";
            this.fACTMONEDADataGridViewTextBoxColumn.ReadOnly = true;
            this.fACTMONEDADataGridViewTextBoxColumn.Width = 40;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "TIPO";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 40;
            // 
            // tOTALDOCUMENTO
            // 
            this.tOTALDOCUMENTO.DataPropertyName = "FACT_MONTO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.tOTALDOCUMENTO.DefaultCellStyle = dataGridViewCellStyle2;
            this.tOTALDOCUMENTO.HeaderText = "IMP DOC";
            this.tOTALDOCUMENTO.Name = "tOTALDOCUMENTO";
            this.tOTALDOCUMENTO.ReadOnly = true;
            this.tOTALDOCUMENTO.Width = 80;
            // 
            // mONTOAPLICADODataGridViewTextBoxColumn
            // 
            this.mONTOAPLICADODataGridViewTextBoxColumn.DataPropertyName = "MONTO_APLICADO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Format = "C2";
            this.mONTOAPLICADODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.mONTOAPLICADODataGridViewTextBoxColumn.HeaderText = "APLICADO";
            this.mONTOAPLICADODataGridViewTextBoxColumn.Name = "mONTOAPLICADODataGridViewTextBoxColumn";
            this.mONTOAPLICADODataGridViewTextBoxColumn.ReadOnly = true;
            this.mONTOAPLICADODataGridViewTextBoxColumn.Width = 80;
            // 
            // aplicadoPorcentaje
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Format = "P2";
            dataGridViewCellStyle4.NullValue = "0";
            this.aplicadoPorcentaje.DefaultCellStyle = dataGridViewCellStyle4;
            this.aplicadoPorcentaje.HeaderText = "APLIC";
            this.aplicadoPorcentaje.Name = "aplicadoPorcentaje";
            this.aplicadoPorcentaje.ReadOnly = true;
            this.aplicadoPorcentaje.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.aplicadoPorcentaje.ToolTipText = "Porcentaje del Total Aplicado";
            this.aplicadoPorcentaje.Width = 75;
            // 
            // iDCTACTEDataGridViewTextBoxColumn
            // 
            this.iDCTACTEDataGridViewTextBoxColumn.DataPropertyName = "IDCTACTE";
            this.iDCTACTEDataGridViewTextBoxColumn.HeaderText = "IDCTACTE";
            this.iDCTACTEDataGridViewTextBoxColumn.Name = "iDCTACTEDataGridViewTextBoxColumn";
            this.iDCTACTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCTACTEDataGridViewTextBoxColumn.Visible = false;
            this.iDCTACTEDataGridViewTextBoxColumn.Width = 70;
            // 
            // DiasPPCob
            // 
            this.DiasPPCob.DataPropertyName = "DiasPPCob";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DiasPPCob.DefaultCellStyle = dataGridViewCellStyle5;
            this.DiasPPCob.HeaderText = "DPP";
            this.DiasPPCob.Name = "DiasPPCob";
            this.DiasPPCob.ReadOnly = true;
            this.DiasPPCob.Width = 40;
            // 
            // DiasImpu
            // 
            this.DiasImpu.DataPropertyName = "DiasImpu";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DiasImpu.DefaultCellStyle = dataGridViewCellStyle6;
            this.DiasImpu.HeaderText = "DIMP";
            this.DiasImpu.Name = "DiasImpu";
            this.DiasImpu.ReadOnly = true;
            this.DiasImpu.Width = 40;
            // 
            // TipoDocCancel
            // 
            this.TipoDocCancel.DataPropertyName = "TipoDocCancel";
            this.TipoDocCancel.HeaderText = "TDoc";
            this.TipoDocCancel.Name = "TipoDocCancel";
            this.TipoDocCancel.ReadOnly = true;
            this.TipoDocCancel.Width = 45;
            // 
            // FrmDetalleImputacionPorRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 428);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmDetalleImputacionPorRecibo";
            this.Text = "DETALLE DE IMPUTACION DE PAGO";
            this.Load += new System.EventHandler(this.FrmDetalleImputacionPagoFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0207SPLITFACTURASBindingSource)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.BindingSource t0207SPLITFACTURASBindingSource;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId6;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIdCob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReciboOficial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReciboInterno;
        private System.Windows.Forms.TextBox txtMoneda2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMontoPendienteImputacion;
        private System.Windows.Forms.TextBox txtMoneda1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalImputado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDiasPP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTCRecibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fACTSPLITDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fACTFECHADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fACTMONEDADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tOTALDOCUMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn mONTOAPLICADODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aplicadoPorcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCTACTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasPPCob;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasImpu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocCancel;
    }
}