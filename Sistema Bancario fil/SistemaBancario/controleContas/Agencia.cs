using System;
using System.Collections.Generic;
using System.Text;

namespace controleContas
{
    public class Agencia
    {
        private int numero;
        private string telefone;
        private string cep;
        private Banco banco;
        public Agencia(int numero, string telefone, Banco banco, string cep)
        {
            this.banco = banco;
            this.numero = numero;
            this.cep = cep;
            this.telefone = telefone;
        }

        public Agencia(Banco banco1, int v1, string v2, string v3)
        {
        }

        public int NumeroProp
        {
            get => numero;
        }
        public string TelefoneProp
        {
            get => telefone;
        }
        public Banco BancoProp
        {
            get => banco;
        }
        public string CepProp
        {
            get => cep;
        }
    }
}
