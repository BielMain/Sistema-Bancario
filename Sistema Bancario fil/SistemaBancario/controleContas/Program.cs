using System;


namespace controleContas
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco("Bank", 100001);
            Agencia agencia = new Agencia(banco, 123, "10000002", "01010101012");

            Cliente cliente1 = new Cliente("Debora", "01010101010", 2000);
            Cliente cliente2 = new Cliente("Sergio", "02020202020", 1999);

            Conta conta1 = new Conta(agencia, cliente1, 12345, 120m);
            Conta conta2 = new Conta(agencia, cliente2, 65414, 0m);

            Console.WriteLine("A conta de número {0} tem saldo {1:C2}", conta1.NumeroProp, conta1.SaldoProp);
            Console.WriteLine("A conta de número {0} tem saldo {1:C2}", conta2.NumeroProp, conta2.SaldoProp);

            Conta maiorSaldo;
            if (conta1.SaldoProp > conta2.SaldoProp)
            {
                maiorSaldo = conta1;
            }
            else
            {
                maiorSaldo = conta2;
            }

            Console.WriteLine("Conta {0} tem o maior saldo", maiorSaldo.NumeroProp);
            Console.Read();
        }
    }
}
