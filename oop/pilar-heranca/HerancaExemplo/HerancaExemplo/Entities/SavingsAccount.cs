using System;
namespace HerancaExemplo.Entities
{
    // Herda Account
    class SavingsAccount : Account
    {
        // 1. Atributos
        public double InterestRate { get; set; }
        // 2. Construtores
        public SavingsAccount()
        {
        }
        public SavingsAccount(int number, string holder, double balance, double interestRate) : base(number, holder, balance)
        {
            InterestRate = interestRate;
        }
        // 3. Métodos
        // Atualiza o saldo com base na taxa de juros.
        public void UpdateBalance()
        {
            Balance += Balance * InterestRate;
        }

    }
}


