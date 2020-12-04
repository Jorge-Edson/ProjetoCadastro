using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroApp
{
    public partial class frmRelatorioCliente : Form
    {
        public frmRelatorioCliente()
        {
            InitializeComponent();
        }

        private void frmRelatorioCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'CadastroDataSet.tb_cliente'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_clienteTableAdapter.Fill(this.CadastroDataSet.tb_cliente);

            this.reportViewer1.RefreshReport();
        }
    }
}
