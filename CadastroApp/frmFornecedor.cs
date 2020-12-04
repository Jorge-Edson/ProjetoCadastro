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
    public partial class frmFornecedor : Form
    {
        public frmFornecedor()
        {
            InitializeComponent();
        }

        public static int codigo;

        private void Habilitar()
        {
            cd_fornecedorTextBox.Enabled = false;
            nm_fornecedorTextBox.Enabled = true;
            ds_enderecoTextBox.Enabled = true;
            nm_bairroTextBox.Enabled = true;
            nm_cidadeTextBox.Enabled = true;
            sg_estadoTextBox.Enabled = true;
            cd_cepTextBox.Enabled = true;
            ds_telefoneTextBox.Enabled = true;
            nm_contatoTextBox.Enabled = true;
            cd_cnpjTextBox.Enabled = true;
            cd_ieTextBox.Enabled = true;
            cd_cpfTextBox.Enabled = true;
            cd_rgTextBox.Enabled = true;
            ds_emailTextBox.Enabled = true;
            sg_tipofornecedorTextBox.Enabled = true;
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
            cd_fornecedorTextBox.Enabled = false;
            nm_fornecedorTextBox.Enabled = false;
            ds_enderecoTextBox.Enabled = false;
            nm_bairroTextBox.Enabled = false;
            nm_cidadeTextBox.Enabled = false;
            sg_estadoTextBox.Enabled = false;
            cd_cepTextBox.Enabled = false;
            ds_telefoneTextBox.Enabled = false;
            nm_contatoTextBox.Enabled = false;
            cd_cnpjTextBox.Enabled = false;
            cd_ieTextBox.Enabled = false;
            cd_cpfTextBox.Enabled = false;
            cd_rgTextBox.Enabled = false;
            ds_emailTextBox.Enabled = false;
            sg_tipofornecedorTextBox.Enabled = false;
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

        private void tb_fornecedorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_fornecedorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cadastroDataSet);

        }

        private void frmFornecedor_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'cadastroDataSet.tb_fornecedor'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_fornecedorTableAdapter.Fill(this.cadastroDataSet.tb_fornecedor);
            Desabilitar();

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            tb_fornecedorBindingSource.MovePrevious();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            tb_fornecedorBindingSource.MoveNext();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Habilitar();
            tb_fornecedorBindingSource.AddNew();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Habilitar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            tb_fornecedorBindingSource.RemoveCurrent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Validate();
            tb_fornecedorBindingSource.EndEdit();
            tb_fornecedorTableAdapter.Update(this.cadastroDataSet.tb_fornecedor);
            Desabilitar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_fornecedorBindingSource.CancelEdit();
            Desabilitar();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            int reg;
            codigo = 0;

            frmPesquisarFornecedor fpf = new frmPesquisarFornecedor();
            fpf.ShowDialog();

            if (codigo > 0)
            {
                reg = tb_fornecedorBindingSource.Find("cd_fornecedor", codigo);
                tb_fornecedorBindingSource.Position = reg;
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

            strDados = "FICHA DE FORNECEDOR" + (char)10 + (char)10;
            strDados = strDados + "Código: " + cd_fornecedorTextBox.Text + (char)10;
            strDados = strDados + "Nome: " + nm_fornecedorTextBox.Text + (char)10;
            strDados = strDados + "Endereço" + ds_enderecoTextBox.Text + (char)10;
            strDados = strDados + "Bairro: " + nm_bairroTextBox.Text + (char)10;
            strDados = strDados + "Cidade: " + nm_cidadeTextBox.Text + (char)10;
            strDados = strDados + "Estado: " + sg_estadoTextBox.Text + (char)10;
            strDados = strDados + "CEP: " + cd_cepTextBox.Text + (char)10;
            strDados = strDados + "Contato: " + nm_contatoTextBox.Text + (char)10;
            strDados = strDados + "Telefone: " + ds_telefoneTextBox.Text + (char)10;
            strDados = strDados + "CNPJ: " + cd_cnpjTextBox.Text + (char)10;
            strDados = strDados + "IE: " + cd_ieTextBox.Text + (char)10;
            strDados = strDados + "CPF: " + cd_cpfTextBox.Text + (char)10;
            strDados = strDados + "RG: " + cd_rgTextBox.Text + (char)10;
            strDados = strDados + "Email: " + ds_emailTextBox.Text + (char)10;
            strDados = strDados + "Tipo de Cliente: " + sg_tipofornecedorTextBox.Text + (char)10;

            objImpressao.DrawString(strDados, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 50);
            objImpressao.DrawLine(new System.Drawing.Pen(Brushes.Black, 1), 50, 80, 780, 80);
        }
    }
}
