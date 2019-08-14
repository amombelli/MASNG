using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.SuperMD;

namespace MASngFE.MasterData.HHRR
{
    public partial class FrmHHRRSearch : Form
    {
        public FrmHHRRSearch(int modo)
        {
            _modo = modo;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------
        private readonly int _modo;

        //-----------------------------------------------------------------------------------------------
        private void FrmHHRRSearch_Load(object sender, EventArgs e)
        {
            ConfiguraInicial();
            ConfigiraSegunModo();
        }

        private void ConfiguraInicial()
        {
            ckSoloActivos.Checked = true;
            ckSoloActivos.BackColor = Color.GreenYellow;
            t0085PERSONALBindingSource.DataSource = new HumanResourcesManager().GetListEmployees(ckSoloActivos.Checked);
        }

        private void ConfigiraSegunModo()
        {
            switch (_modo)
            {
                case 0:
                    break;

                case 1:

                    break;

                case 2:
                    btnNewEmployee.Enabled = false;
                    break;

                case 3:
                    btnModificar.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void ckSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            ckSoloActivos.BackColor = ckSoloActivos.Checked ? Color.GreenYellow : Color.Crimson;
            t0085PERSONALBindingSource.DataSource = new HumanResourcesManager().GetListEmployees(ckSoloActivos.Checked);
        }


        //desde aca no revisado



        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            var f = new FrmHHRRDetail(1);
            f.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var f = new FrmHHRRDetail(2,txtId.Text);
            f.Show();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            var f = new FrmHHRRDetail(3, txtId.Text);
            f.Show();
        }
    }
}
