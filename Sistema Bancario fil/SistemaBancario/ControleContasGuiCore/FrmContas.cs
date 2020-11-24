using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controleContas;

namespace ControleContasGuiCore
{
    public partial class FrmContas : Form
    {
        List<Conta> contas = new List<Conta>();
        public List<Cliente> clientes = new List<Cliente>();

        Banco banco = null;
        Agencia agencia = null;
        public FrmContas()
        {
            InitializeComponent();

            banco = new Banco("Bank", 11001);
            agencia = new Agencia(banco, 123, "10000101", "12345678912");
            clientes.Add(new Cliente("Pedro", "12345678901", 2000));
            clientes.Add(new Cliente("Kenia", "10987654321", 1999));

            lstContas.Items.Clear();
            lstContas.Items.Add("Numero\tSaldo\tTitular");

            cmbTitular.Items.Clear();
            clientes.ForEach(delegate (Cliente cli)
            {
                cmbTitular.Items.Add(cli.NomeProp);
            }
            );
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (cmbTitular.SelectedItem == null || txtNumero.Text == "" || txtSaldo.Text == "")
            {
                MessageBox.Show("Os campos não podem estar vazios", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente titular = clientes.Find(delegate (Cliente cli) {
                return cli.NomeProp == cmbTitular.SelectedItem.ToString();
            }
            );

            Conta conta = new Conta(agencia, titular, Convert.ToInt32(txtNumero.Text.ToString()), Convert.ToInt32(txtSaldo.Text.ToString()));
            contas.Add(conta);

            lstContas.Items.Add(conta.NumeroProp + "\t" + conta.SaldoProp + "\t" + conta.TitularProp.NomeProp);

            Clear();
        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult sair = MessageBox.Show("Confirma saída? ", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sair.Equals(DialogResult.Yes))
            {
                Application.Exit();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            txtNumero.Text = "";
            txtSaldo.Text = "";
            cmbTitular.SelectedItem = null;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmClientes novoClienteForm = new FrmClientes(clientes);
            novoClienteForm.ShowDialog();
            this.clientes = novoClienteForm.GetClientes;

            cmbTitular.Items.Clear();
            clientes.ForEach(delegate (Cliente cli)
            {
                cmbTitular.Items.Add(cli.NomeProp);
            });
        }
        private void txtNumConta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSaldo_KeyPress(int input, object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        public List<Cliente> GetClientes()
        {
            return clientes;
        }

        public void AddCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }


    }
}


