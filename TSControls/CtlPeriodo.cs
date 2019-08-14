using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.TOOLS;

namespace TSControls
{
    public partial class CtlPeriodo : UserControl
    {
        public CtlPeriodo()
        {
            InitializeComponent();
        }

        private DateTime _fechaI; //fecha inicial
        private DateTime _fechaF; //fecha final
        private string _periodo;//periodo seleccionado

        public string Periodo
        {
            get => _periodo;
            set
            {
                _periodo = value;
                this.txtPeriodo.Text = value;
            }
        }
        
        private void txtPeriodo_Validating(object sender, CancelEventArgs e)
        {
            if (txtPeriodo.Text.Length == 0)
            {
                _periodo = null;
                _fechaI= DateTime.Today;
                _fechaF= DateTime.Today;
                return;
            }

            if (txtPeriodo.Text.Length != 6)
            {
                toolTipX.ToolTipTitle = "Periodo Invalido";
                toolTipX.Show("Debe proveer un periodo valido en formato AAAA-MM", txtPeriodo, 0, -20,
                    5000);
                e.Cancel = true;
            }

            int year = Convert.ToInt32(txtPeriodo.Text.Substring(0, 4));
            int month = Convert.ToInt32(txtPeriodo.Text.Substring(4, 2));
            

            if (year < 2006 || year > DateTime.Today.AddYears(2).Year)
            {
                toolTipX.ToolTipTitle = "Periodo Invalido";
                toolTipX.Show("Debe proveer un periodo valido en formato AAAA-MM - Año fuera de Rango", txtPeriodo, 0, -20,
                    5000);
                e.Cancel = true;
                return;
            }

            if (month < 1 || month > 12)
            {
                toolTipX.ToolTipTitle = "Periodo Invalido";
                toolTipX.Show("Debe proveer un periodo valido en formato AAAA-MM - MES fuera de Rango", txtPeriodo, 0, -20,
                    5000);
                e.Cancel = true;
                return;
            }


            _fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(txtPeriodo.Text);
            _fechaF = new PeriodoConversion().GetFechaUltimoDiaPeriodo(txtPeriodo.Text);
            _periodo = txtPeriodo.Text;
        }

        private void txtPeriodo_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                toolTipX.ToolTipTitle = "Periodo Invalido";
                toolTipX.Show("Debe proveer un periodo valido en formato AAAA-MM", txtPeriodo, 0, -20,
                    5000);
                e.Cancel = true;
            }
            else
            {
                //Aca se puede hacer cualquier validacion adicional sobre restricciones de fechas 
                DateTime userDate = (DateTime) e.ReturnValue;
                if (userDate < DateTime.Now)
                {
                    toolTipX.ToolTipTitle = "Periodo Invalido";
                    toolTipX.Show("La fecha es mayor a la de hoy", txtPeriodo, 0, -20,
                        5000);
                    e.Cancel = true;
                }
            }
        }
    }
}
