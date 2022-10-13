using System;

namespace HelpClass // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Instancia objeto da classe triangulo
            Triangulo x;
            x = new Triangulo();
            x.A = 3;
            x.B = 4;
            x.C = 5;
            Console.WriteLine(x.A);
            // Chama o método do cálculo da área
            double areaX = x.Area();
            Console.WriteLine(areaX);
        }
    }
}