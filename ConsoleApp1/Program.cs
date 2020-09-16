using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            IPagamento meioPagemento = new ContaCorrente(3_000);

            if (meioPagemento.PossuiSaldo(10_000M))
                meioPagemento.Debitar(10_000M);

            meioPagemento = new CartaDeCredito();
            meioPagemento.Debitar(100);


            Console.WriteLine("Hello World!");
        }
    }


    //Contrato José
    public interface IPagamento
    {
        decimal Saldo { get;  set; }
        bool PossuiSaldo(decimal valorASerDebitado);
        void Debitar(decimal valor);
    }


    public class ContaCorrente : IPagamento
    {

        public ContaCorrente(decimal limite)
        {
            LimiteChequeEspecial = limite;
            Saldo = 1000 + LimiteChequeEspecial;
        }


        public decimal Saldo { get; set; } 
        public decimal LimiteChequeEspecial { get; set; }

        public void Debitar(decimal valor)
        {
            Saldo -= valor;
        }

        public bool PossuiSaldo(decimal valorASerDebitado)
        {
            return Saldo >= valorASerDebitado;
        }
    }


    public class CartaDeCredito : IPagamento
    {
        public decimal Saldo { get; set; } = 1000;

        public void Debitar(decimal valor)
        {
            Saldo -= valor;
        }

        public bool PossuiSaldo(decimal valorASerDebitado)
        {
            return Saldo >= valorASerDebitado;
        }
    }

    public class Pix : IPagamento
    {
        public decimal Saldo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Debitar(decimal valor)
        {
            throw new NotImplementedException();
        }

        public bool PossuiSaldo(decimal valorASerDebitado)
        {
            throw new NotImplementedException();
        }
    }
}
