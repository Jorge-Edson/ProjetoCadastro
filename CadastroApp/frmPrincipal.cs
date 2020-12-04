using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroApp
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario fu = new frmUsuario();
            fu.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente fc = new frmCliente();
            fc.ShowDialog();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFornecedor ff = new frmFornecedor();
            ff.ShowDialog();
        }

        private void usuáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRelatorioUsuario fru = new frmRelatorioUsuario();
            fru.ShowDialog();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRelatorioCliente frc = new frmRelatorioCliente();
            frc.ShowDialog();
        }

        private void fornecedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRelatorioFornecedor frf = new frmRelatorioFornecedor();
            frf.ShowDialog();
        }
    }
}
