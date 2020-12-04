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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        public static int codigo;

        private void Habilitar()
        {
            cd_usuarioTextBox.Enabled = false;
            nm_usuarioTextBox.Enabled = true;
            sg_nivelTextBox.Enabled = true;
            nm_loginTextBox.Enabled = true;
            cd_senhaTextBox.Enabled = true;
            btnAnterior.Enabled = false;
            btnProximo.Enabled = false;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnPesquisar.Enabled = false;
            btnImprimir.Enabled = false;
            btnSair.Enabled = false;
        }

        private void Desabilitar()
        {
            cd_usuarioTextBox.Enabled = false;
            nm_usuarioTextBox.Enabled = false;
            sg_nivelTextBox.Enabled = false;
            nm_loginTextBox.Enabled = false;
            cd_senhaTextBox.Enabled = false;
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnNovo.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnPesquisar.Enabled = true;
            btnImprimir.Enabled = true;
            btnSair.Enabled = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'cadastroDataSet.tb_usuario'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_usuarioTableAdapter.Fill(this.cadastroDataSet.tb_usuario);
            Desabilitar();
        }

        private void tb_usuarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            tb_usuarioBindingSource.MovePrevious();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            tb_usuarioBindingSource.MoveNext();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Habilitar();
            tb_usuarioBindingSource.AddNew();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Habilitar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            tb_usuarioBindingSource.RemoveCurrent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Validate();
            tb_usuarioBindingSource.EndEdit();
            tb_usuarioTableAdapter.Update(this.cadastroDataSet.tb_usuario);
            Desabilitar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_usuarioBindingSource.CancelEdit();
            Desabilitar();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            int reg;
            codigo = 0;

            frmPesquisarUsuario fpu = new frmPesquisarUsuario();
            fpu.ShowDialog();

            if (codigo > 0)
            {
                reg = tb_usuarioBindingSource.Find("cd_usuario", codigo);
                tb_usuarioBindingSource.Position = reg;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics objImpressao = e.Graphics;
            string strDados;

            strDados = "FICHA DE USUÁRIO" + (char)10 + (char)10;
            strDados = strDados + "Código: " + cd_usuarioTextBox.Text + (char)10;
            strDados = strDados + "Nome: " + nm_usuarioTextBox.Text + (char)10;
            strDados = strDados + "Nível" + sg_nivelTextBox.Text + (char)10;
            strDados = strDados + "Login: " + nm_loginTextBox.Text + (char)10;

            objImpressao.DrawString(strDados, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 50);
            objImpressao.DrawLine(new System.Drawing.Pen(Brushes.Black, 1), 50, 80, 780, 80);
        }
    }
}
