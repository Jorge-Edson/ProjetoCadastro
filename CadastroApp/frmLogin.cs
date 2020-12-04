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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        public void StartForm()
        {
            Application.Run(new frmSplashScreen());
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            tb_usuarioTableAdapter.FillByLogin(cadastroDataSet.tb_usuario, txtUsuario.Text, txtSenha.Text);
            if (txtUsuario.Text == "adm" && txtSenha.Text == "123" || (tb_usuarioBindingSource.Count > 0))
            {
                frmPrincipal fp = new frmPrincipal();
                fp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!");
                txtUsuario.Focus();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'cadastroDataSet.tb_usuario'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_usuarioTableAdapter.Fill(this.cadastroDataSet.tb_usuario);

        }

        private void tb_usuarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_usuarioBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cadastroDataSet);

        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    }
}
