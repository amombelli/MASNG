using System;
using System.Windows.Forms;
using Tecser.Business.DataFix;
using Tecser.Business.Transactional.SD;

namespace MASngFE.Transactional.SD
{
    public partial class FrmCentroDespacho : Form
    {
        public FrmCentroDespacho(int modo=0)
        {
            InitializeComponent();
        }

        private void FrmCentroDespacho_Load(object sender, EventArgs e)
        {
            InicializaConRepositoryFix.Init();
            dgvCentroDespacho.DataSource = new CDListManager().GetListPendientesDespacho();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvCentroDespacho.DataSource = null;
            dgvCentroDespacho.DataSource = new CDListManager().GetListPendientesDespacho();
        }

        private void dgvCentroDespacho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
