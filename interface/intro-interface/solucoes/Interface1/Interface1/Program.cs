using System;
using System.Globalization;
using Interface1.Entities;
using Interface1.Services;

namespace Interface1 
{
    internal class Program
    {
        // 1. Atributos

        // 2. Construtores
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dados do aluguel: ");
            Console.WriteLine("Car Model: ");
            string model = Console.ReadLine();
            Console.WriteLine("Pickup Date (dd/MM/yyyy hh:mm): \n");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //DateTime start = DateTime.ParseExact("25/08/2018 10:30:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            Console.WriteLine($"StartDate: {start} \n");
            Console.WriteLine("Return Date (dd/MM/yyyy hh:mm): \n");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //DateTime finish = DateTime.ParseExact("25/08/2018 14:40:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            Console.WriteLine($"FinishDate: {finish} \n");
            // Price
            Console.WriteLine("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Instanciamento do objeto
            CarRental carRental = new CarRental(start, finish, new Vehicle(model));
            // Instanciamos o serviço de aluguel passando a dependencia BrazilTaxService
            RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("INVOICE");
            Console.WriteLine(carRental.Invoice);


        }

        // 3. Métodos
    }
}