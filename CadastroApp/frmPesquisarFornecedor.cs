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
    public partial class frmPesquisarFornecedor : Form
    {
        public frmPesquisarFornecedor()
        {
            InitializeComponent();
        }

        private void tb_fornecedorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_fornecedorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cadastroDataSet);

        }

        private void frmPesquisarFornecedor_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'cadastroDataSet.tb_fornecedor'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_fornecedorTableAdapter.Fill(this.cadastroDataSet.tb_fornecedor);
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                this.tb_fornecedorTableAdapter.Fill(this.cadastroDataSet.tb_fornecedor);
            }
            else
            {
                this.tb_fornecedorTableAdapter.FillByNome(this.cadastroDataSet.tb_fornecedor, "%" + txtNome.Text + "%");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_fornecedorDataGridView_DoubleClick(object sender, EventArgs e)
        {
            frmFornecedor.codigo = int.Parse(tb_fornecedorDataGridView.CurrentRow.Cells[0].Value.ToString());
            Close();
        }
    }
}
