using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MASngFE.Transactional.Cierre
{
    public partial class FrmFI70ImportacionOriginal : Form
    {
        public FrmFI70ImportacionOriginal(DataTable dt)
        {
            _dt = dt;
            InitializeComponent();
        }

        private DataTable _dt = new DataTable();

        private void FrmFI70ImportacionOriginal_Load(object sender, EventArgs e)
        {
            dgv1.DataSource = _dt;
        }
    }
}
