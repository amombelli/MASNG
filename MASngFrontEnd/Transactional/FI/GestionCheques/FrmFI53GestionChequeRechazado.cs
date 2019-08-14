using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI;

namespace MASngFE.Transactional.FI.GestionCheques
{
    public partial class FrmFI53GestionChequeRechazado : Form
    {
        public FrmFI53GestionChequeRechazado()
        {
            InitializeComponent();
        }

        private void FrmFI53GestionChequeRechazado_Load(object sender, EventArgs e)
        {
            bsChequesRech.DataSource = new ChequesManager().GetListaChequesRechazados();
        }
    }
}
