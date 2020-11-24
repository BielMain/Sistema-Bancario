using System;
using System.Collections.Generic;
using System.Text;

namespace controleContas
{
    public class Cliente
    {
        private string nome;
        private string cpf;
        private int anoNascimento;

        public Cliente(string nome, string cpf, int anoNascimento)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.anoNascimento = anoNascimento;
        }
        public string NomeProp
        {
            get => nome;
            set => nome = value;
        }
        public string CpfProp
        {
            get
            {
                return cpf;
            }
            set
            {
                if (value.Length != 11)
                {
                    Console.WriteLine("Cpf deve conter 11 digitos apenas!");
                }
                else
                {
                    cpf = value;
                }
            }
        }
        public int AnoNascimentoProp
        {
            get
            {
                return anoNascimento;
            }
            set
            {
                anoNascimento = value;
            }
        }
    }
}