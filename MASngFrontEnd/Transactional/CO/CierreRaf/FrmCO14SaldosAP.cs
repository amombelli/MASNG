﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.Cierre;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmCO14SaldosAP : Form
    {
        private readonly string _periodo;
        private readonly string _tipoLx;
        private DateTime _fechaD;
        private DateTime _fechaH;
        private List<EstructuraSaldosProveedores> _lista = new List<EstructuraSaldosProveedores>();

        public FrmCO14SaldosAP(string periodo, string tipoLx)
        {
            _periodo = periodo;
            _tipoLx = tipoLx;
            InitializeComponent();
        }

        private void FrmCO14SaldosAP_Load(object sender, EventArgs e)
        {
            txtPeriodo.Text = _periodo;
            txtFechaDesde.Text = new PeriodoConversion().GetFechaPrimerDiaPeriodo(txtPeriodo.Text).ToShortDateString();
            txtFechaHasta.Text = new PeriodoConversion().GetFechaUltimoDiaPeriodo(txtPeriodo.Text).ToShortDateString();
            ckL1.Checked = true;
            ckL2.Checked = false;

            _fechaD = new PeriodoConversion().GetFechaPrimerDiaPeriodo(_periodo);
            _fechaH = new PeriodoConversion().GetFechaUltimoDiaPeriodo(_periodo).AddDays(1); //traia problemas con el ultimo dia + horas

            var lista = new VendorConcil().GetListadoSaldosFinales(_tipoLx);
            dgvStructuraBs.DataSource = lista;
            txtSaldoAPHoy.Text = lista.Sum(c => c.DeudaTotalARS).ToString("C2");
            lperiodo.Text = txtPeriodo.Text;
        }

        private void btnDetalleAP_Click(object sender, EventArgs e)
        {
            var lista = new VendorConcil().GetListadoSaldosFinales(_tipoLx);
            dgvStructuraBs.DataSource = lista;
            txtSaldoAPHoy.Text = lista.Sum(c => c.DeudaTotalARS).ToString("C2");

        }

        private void btnSaldosIniciales_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPeriodo.Text))
            {
                MessageBox.Show(@"Complete el Periodo");
                return;
            }
            var lista = new VendorConcil().GetListadoDetalladoComposicionSaldos(_tipoLx,
                txtPeriodo.Text);
            txtSaldoAPeriodoAP.Text = lista.Sum(c => c.DeudaTotalARS).ToString("C2");
            lperiodo.Text = txtPeriodo.Text;

            if (ckVerDetalleAP.Checked)
            {
                dgvStructuraBs.DataSource = lista;
            }
            else
            {
                dgvStructuraBs.DataSource = new VendorConcil().GetListadoSumarizadoComposicionSaldos(lista);
            }
        }

        private void btnSaldosFinales_Click(object sender, EventArgs e)
        {
            dgvStructuraBs.DataSource = new VendorConcil().Accion(_tipoLx, _periodo);
        }
    }
}
