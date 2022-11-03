using System;
namespace HerancaExemplo.Entities
{
    class BusinessAccount : Account
    {
        // 1. Atributos
        public double LoanLimit { get; set; }
        // 2. Construtores
        public BusinessAccount()
        {
        }
        // Para o construtor do Business account, ao invés de atribuir cada variável, basta chamar base e inputar tais variáveis.
        public BusinessAccount(int number, string holder, double balance, double loanLimit) : base(number, holder, balance)
        {
            /*
            Number = number;
            Holder = holder;
            Balance = balance;
            */
            LoanLimit = loanLimit;
        }
        // 3. Operaçao
        // Empréstimo ocorre apenas se a quantia emprestada for menor do que o limite estabelecido.
        public void Loan(double amount)
        {
            if(amount <= LoanLimit)
            {
                Balance += amount;
            }
        }
    }
}



