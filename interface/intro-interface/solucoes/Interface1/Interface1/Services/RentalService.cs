using Interface1.Entities;

namespace Interface1.Services
{
    public class RentalService
    {
        // 1. Atributos
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }
        private ITaxService _taxService;

        // private BrazilTaxService _brazilTaxService = new BrazilTaxService();

        // 2. Construtores
        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        // 3. Métodos
        public void ProcessInvoice(CarRental carRental)
        {
            // Duraçao da Locação
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
            double basicPayment = 0.0;
            if(duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }
            // Calculo do imposto - Usando o serviço da interface
            double tax = _taxService.Tax(basicPayment);
            // Instancia o invoice e associa com carRental
            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}

