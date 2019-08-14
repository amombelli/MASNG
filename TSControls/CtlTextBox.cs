using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Tools;

namespace TSControls
{
    public partial class CtlTextBox : UserControl
    {
        public CtlTextBox()
        {
            InitializeComponent();
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                myTextBox.ForeColor = value;
            }
        }
        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                myTextBox.BackColor = value;
            }
        }

        private Font myFont = DefaultFont;

        private Font m_Font=DefaultFont;


        public override Font Font
        {
            get { return base.Font; }
            set { myTextBox.Font = value; }
        }

        public decimal SetValue
        {
            set
            {
                Valor = value;
                switch (_tipo)
                {
                    case TextBoxType.Moneda:
                        myTextBox.Text = value.ToString("C" + _cantidadDecimales);
                        break;
                    case TextBoxType.Decimal:
                        myTextBox.Text = value.ToString("N" + _cantidadDecimales);
                        break;
                    case TextBoxType.Entero:
                        myTextBox.Text = value.ToString("N0");
                        break;
                    case TextBoxType.Porcentaje:
                        myTextBox.Text = value.ToString("P" + _cantidadDecimales);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        //public override Font Font
        //{
        //    get => Font;
        //    set
        //    {
        //        m_Font = value;
        //        myTextBox.Font = Font;
        //    }
        //}


        public enum TextBoxType
        {
            Moneda,
            Decimal,
            Entero,
            Porcentaje
        };

        public enum Alineacion
        {
            Izquierda,
            Centro,
            Derecha
        };

        //-----------------------------------------------------------------------------------------
        private TextBoxType _tipo;
        private decimal _valorMin=decimal.MinValue;
        private decimal _valorMax = decimal.MaxValue;
        private decimal Valor=0;
        private bool HasValue = false;
        private int _cantidadDecimales = 0;
        private bool _allowBackspace;
        private bool _allowNegativo;
        private bool _locked;
        private Alineacion _textAlign = Alineacion.Centro;
        private Color _backColor;
        public decimal GetValueDecimal => Valor;

        //Propiedades Accesibles

        public Font TsFont
        {
            get => myFont;
            set
            {
                if (value == null)
                    value = DefaultFont;

                myFont = value;
                myTextBox.Font = value;
                base.Font = value;
            }
        }
        public Alineacion SetAlineacion
        {
            get => _textAlign;
            set
            {
                _textAlign = value;
                switch (value)
                {
                    case Alineacion.Izquierda:
                       myTextBox.TextAlign = HorizontalAlignment.Left;
                        break;
                    case Alineacion.Centro:
                        myTextBox.TextAlign = HorizontalAlignment.Center;
                        break;
                    case Alineacion.Derecha:
                        myTextBox.TextAlign = HorizontalAlignment.Right;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }
        public decimal ValorMinimo
        {
            get => _valorMin;
            set
            {
                _valorMin = value;
                _allowNegativo = _valorMin < 0;
            }
        }
        public decimal ValorMaximo
        {
            get => _valorMax;
            set
            {
                _valorMax = value;
                _allowNegativo = _valorMax < 0;
            }
           
        }
        public int SetDecimales
        {
            get => _cantidadDecimales;
            set
            {
                if (_cantidadDecimales < 0)
                {
                    _cantidadDecimales = 0;
                }
                else
                {
                    _cantidadDecimales = value;
                }
            }
        }
        public TextBoxType SetType
        {
            get => _tipo;
            set
            {
                _tipo = value;
                ConfiguraTipo();
            }
        }
        public bool XReadOnly
        {
            get => _locked;
            set
            {
                _locked = value;
                myTextBox.ReadOnly = value;
            }
        }
        private void ConfiguraTipo()
        {
            switch (_tipo)
            {
                case TextBoxType.Moneda:
                    _allowBackspace = true;
                    break;
                case TextBoxType.Decimal:
                    _allowBackspace = true;
                    break;
                case TextBoxType.Entero:
                    _allowBackspace = true;
                    _cantidadDecimales = 0;
                    break;
                case TextBoxType.Porcentaje:
                    _allowBackspace = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void CtlTextBox_Load(object sender, EventArgs e)
        {
            base.Size = myTextBox.Size;
        }
        public void Init(TextBoxType tipo, decimal? valorMinimo, decimal? valorMaximo,bool allowBackspace=true)
        {
            _allowBackspace = allowBackspace;
            _tipo = tipo;

            if (valorMinimo != null)
                _valorMin = valorMinimo.Value;

            if (valorMaximo != null)
                _valorMax = valorMaximo.Value;

            _allowNegativo = _valorMin < 0; //si el valor minimo es negativo permite negativo en forma Auto

        }
        private void myTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (SetType)
            {
                case TextBoxType.Moneda:
                    FormatAndConversions.SoloDecimalKeyPress(sender,e,_allowBackspace,_allowNegativo,true,false);
                    break;
                case TextBoxType.Decimal:
                    FormatAndConversions.SoloDecimalKeyPress(sender, e, _allowBackspace, _allowNegativo, false, false);
                    break;
                case TextBoxType.Entero:
                    FormatAndConversions.SoloEnteroKeyPress(sender,e);
                    break;
                case TextBoxType.Porcentaje:
                    FormatAndConversions.SoloDecimalKeyPress(sender, e, _allowBackspace, _allowNegativo, false, true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void myTextBox_Validating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox) sender;
            if (string.IsNullOrEmpty(txt.Text))
            {
                txt.Text = @"0";
            }
            switch (_tipo)
            {
                case TextBoxType.Moneda:
                    Valor = FormatAndConversions.CCurrencyADecimal(txt.Text);
                    txt.Text = Valor.ToString("C" + _cantidadDecimales);
                    break;
                case TextBoxType.Decimal:
                    Valor = Convert.ToDecimal(txt.Text);
                    txt.Text = Valor.ToString("N" + _cantidadDecimales);
                    break;
                case TextBoxType.Entero:
                    Valor = Convert.ToInt32(txt.Text);
                    txt.Text = Valor.ToString("N");
                    break;
                case TextBoxType.Porcentaje:
                    Valor = FormatAndConversions.CPorcentajeADecimal(txt.Text);
                    txt.Text = Valor.ToString("P" + _cantidadDecimales);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (Valor < _valorMin)
            {
                toolTip1.ToolTipTitle = "Valor fuera de Rango [-]";
                toolTip1.Show("El Valor Ingresado no cumple con las condiciones definidas",
                    txt, txt.Location, 1600);
                e.Cancel = true;
            }

            if (Valor > _valorMax)
            {
                toolTip1.ToolTipTitle = "Valor fuera de Rango [+]";
                toolTip1.Show("El Valor Ingresado no cumple con las condiciones definidas",
                    txt, txt.Location, 1600);
                e.Cancel = true;
            }



        }
        private void CtlTextBox_SizeChanged(object sender, EventArgs e)
        {
            myTextBox.Size = new Size(this.Width, this.Height);
        }
        private void myTextBox_SizeChanged(object sender, EventArgs e)
        {
            myTextBox.Size = new Size(this.Width, this.Height);
        }
        private void CtlTextBox_Resize(object sender, EventArgs e)
        {
            myTextBox.Size = new Size(this.Width, this.Height);
        }
    }
}
