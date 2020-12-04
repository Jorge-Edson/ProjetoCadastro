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
    public partial class frmPesquisarUsuario : Form
    {
        public frmPesquisarUsuario()
        {
            InitializeComponent();
        }

        private void tb_usuarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_usuarioBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cadastroDataSet1);

        }

        private void frmPesquisarUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'cadastroDataSet1.tb_usuario'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_usuarioTableAdapter.Fill(this.cadastroDataSet1.tb_usuario);

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                this.tb_usuarioTableAdapter.Fill(this.cadastroDataSet1.tb_usuario);
            }
            else
            {
                this.tb_usuarioTableAdapter.FillByNome(this.cadastroDataSet1.tb_usuario, "%" + txtNome.Text + "%");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_usuarioDataGridView_DoubleClick(object sender, EventArgs e)
        {
            frmUsuario.codigo = int.Parse(tb_usuarioDataGridView.CurrentRow.Cells[0].Value.ToString());
            Close();
        }
    }
}
