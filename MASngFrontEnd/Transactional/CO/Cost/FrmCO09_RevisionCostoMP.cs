using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Transactional.CO.Costos;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO09_RevisionCostoMP : Form
    {
        public FrmCO09_RevisionCostoMP()
        {
            InitializeComponent();
        }

        private void FrmCO09_RevisionCostoMP_Load(object sender, EventArgs e)
        {
            var activo = new CostRollManager().GetCostRollHeaderActivo();
            t0035CostRollBindingSource.DataSource = new CostRollManager().GetListCostRollMateriasPrimas(activo.idCostRoll).ToList();
        }
    }
}
