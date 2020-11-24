using System;
using System.Collections.Generic;
using System.Text;

namespace controleContas
{
    
    public class Conta
    {
        private int numero;
        public decimal saldo;
        private Cliente titular;
        private Agencia agencia;

        public Conta(Agencia agencia, Cliente titular, int numero, decimal saldo)
        {
            if (saldo < 10.0m)
            {
                Console.WriteLine("O saldo está abaixo do permitido!");
                this.saldo = saldo;
            }
            else
            {
                this.saldo = saldo;
            }

            if (titular == null)
            {
                throw new System.ArgumentException("O cliente não pode ser nulo");
            }

            if (agencia == null)
            {
                throw new System.ArgumentException("A agencia não pode ser nula");
            }

            this.numero = numero;
            this.titular = titular;
            this.agencia = agencia;

        }

        public int NumeroProp
        {
            get => numero;

            set => numero = value;
        }

        public decimal SaldoProp
        {
            get
            {
                return saldo;
            }
            set
            {
                if (value >= 0.0m)
                {
                    saldo = value;
                }
                else
                {
                    Console.WriteLine("O saldo não pode ser negativo. ");
                }
            }
        }
        public Cliente TitularProp
        {
            get => titular;

            set => titular = value;
        }
        public void deposito(decimal valor)
        {
            if (valor > 0)
            {
                saldo += valor;
            }
        }
        public void transferir(Conta contato, decimal valor)
        {
            if (saldo - valor < 0.0m)
            {
                Console.WriteLine("O saldo não pode ficar negativo");
                return;
            }
            else
            {
                contato.deposito(valor);
                this.SaldoProp -= valor;
            }
        }
        public void saque(decimal valor)
        {
            if (saldo - valor > 0.0m)
            {
                saldo -= valor + 0.10m;
            }
            else
            {
                Console.WriteLine("Você não pode ficar com o saldo negativo");
            }
        }
    }
}











