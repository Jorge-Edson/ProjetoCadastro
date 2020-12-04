﻿using System;
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
    public partial class frmPesquisarCliente : Form
    {
        public frmPesquisarCliente()
        {
            InitializeComponent();
        }

        private void tb_clienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_clienteBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cadastroDataSet);

        }

        private void frmPesquisarCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'cadastroDataSet.tb_cliente'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_clienteTableAdapter.Fill(this.cadastroDataSet.tb_cliente);

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                this.tb_clienteTableAdapter.Fill(this.cadastroDataSet.tb_cliente);
            }
            else
            {
                this.tb_clienteTableAdapter.FillByNome(this.cadastroDataSet.tb_cliente, "%" + txtNome.Text + "%");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_clienteDataGridView_DoubleClick(object sender, EventArgs e)
        {
            frmCliente.codigo = int.Parse(tb_clienteDataGridView.CurrentRow.Cells[0].Value.ToString());
            Close();
        }
    }
}
