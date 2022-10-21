namespace Interface1.Entities
{
    public class CarRental
    {
        // 1. Atributos
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        // 2. Construtores
        // Invoice será gerado como nulo, então não entra no construtor.
        public CarRental(DateTime start, DateTime finish, Vehicle vehicle)
        {
            Start = start;
            Finish = finish;
            Vehicle = vehicle;
            // Não é necessário, pois o objeto não instanciado recebe nulo.
            Invoice = null;
        }
    }
}

