namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class teste
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string monthAndYear = Console.ReadLine();
            string month = monthAndYear.Split("/")[0];
            string year = monthAndYear.Split("/")[1];
        }
    }
}