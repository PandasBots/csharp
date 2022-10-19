using System;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem Vindo ao Pandas Chess");
            // Variável
            Tabuleiro tab = new Tabuleiro(8, 8);

            // Chamar a Tela e Imprimir o Tabuleiro
            Tela.imprimirTabuleiro(tab);

        }
    }
}