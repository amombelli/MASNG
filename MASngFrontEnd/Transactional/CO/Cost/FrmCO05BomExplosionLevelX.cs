using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecserEF.Entity;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO05BomExplosionLevelX : Form
    {
        private readonly string _material;
        private readonly int _level;

        public FrmCO05BomExplosionLevelX(string material, int level)
        {
            _material = material;
            _level = level;
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCO05BomExplosionLevelX_Load(object sender, EventArgs e)
        {
            CostBs.DataSource = "";
            
        }
    }
}
