
namespace Interface1.Entities
{
    public class Invoice
    {
        // 1. Atributos
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        // 2. Construtores
        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        // 3. Métodos
        public double TotalPayment
        {
            get { return BasicPayment + Tax; }
        }

        public override string ToString()
        {
            return $"Basic Payment: {BasicPayment:F2}\nTax: {Tax:F2}\nTotalPayment: {TotalPayment:F2}";
        }
    }
}

