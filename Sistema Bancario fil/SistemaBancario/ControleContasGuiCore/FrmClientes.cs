using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using controleContas;

namespace ControleContasGuiCore
{
    public partial class FrmClientes : Form
    {
        private List<Cliente> clientes;

        public FrmClientes(List<Cliente> clientes)
        {
            InitializeComponent();

            this.clientes = clientes;

            lstClientes.Items.Clear();
            lstClientes.Items.Add("Nome\tCPF\t\tAno");
            clientes.ForEach(delegate (Cliente cli)
            {
                lstClientes.Items.Add(cli.NomeProp + "\t" + cli.CpfProp + "\t" + cli.AnoNascimentoProp);
            }
            );
        }

        public List<Cliente> GetClientes
        {
            get => clientes;
        }

        private void txtAnoNasc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult sair = MessageBox.Show("Confirma Saida ?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (sair.Equals(DialogResult.Yes))
            {
                Application.Exit();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtData.Clear();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text == "" || txtNome.Text == "" || txtData.Text == "")
            {
                MessageBox.Show("Os campos não podem estar vazios", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtCPF.Text.Length < 11)
            {
                MessageBox.Show("O CPF não pode ter 'Menos' de 11 digitos e deve ser somente numerico!", "CPF inválido!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtCPF.Text.Length > 11)
            {
                MessageBox.Show("O CPF não pode ter 'Mais' que 11 digitos e deve ser somente numerico!", "CPF inválido!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente cliente = new Cliente(txtNome.Text, txtCPF.Text, Convert.ToInt32(txtData.Text));
            clientes.Add(cliente);
            lstClientes.Items.Add(cliente.NomeProp + "\t" + cliente.CpfProp + "\t" + cliente.AnoNascimentoProp);
        }


    }
}