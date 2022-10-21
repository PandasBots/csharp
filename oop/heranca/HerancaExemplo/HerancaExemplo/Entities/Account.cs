using System;
namespace HerancaExemplo.Entities
{
    class Account
    {
        // 1. Atributos
        public int Number { get; protected set; }
        public string Holder { get; protected set; }
        public double Balance { get; protected set; }
        // 2. Construtores
        // Padrão
        public Account()
        {
        }
        // Construtor com argumentos
        public Account(int number, string holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }
        // 3. Operações
        // Saque: Retira do saldo
        public void Withdraw(double amount)
        {
            Balance -= amount;
        }
        // Depósito: Acrescente ao saldo
        public void Deposit(double amount)
        {
            Balance += amount;
        }
    }
}

