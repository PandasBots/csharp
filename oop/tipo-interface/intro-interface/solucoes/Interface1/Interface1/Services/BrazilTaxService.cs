namespace Interface1.Services
{
    public class BrazilTaxService : ITaxService
    {

        // 3. Método
        public double Tax(double amount)
        {
            if(amount <= 100)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.15;
            }
        }

    }
}

