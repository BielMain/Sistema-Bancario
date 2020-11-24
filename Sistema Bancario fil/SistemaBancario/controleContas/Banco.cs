using System;
using System.Collections.Generic;
using System.Text;

namespace controleContas
{
    public class Banco
    {
        private string nome;
        private int numero;

        public Banco(string nome, int numero)
        {
            this.nome = nome;
            this.numero = numero;
        }
        public string NomeProp
        {
            get => nome;

            set => nome = value;
        }
        public int NumeroProp
        {
            get => numero;

            set => numero = value;
        }
    }
}

