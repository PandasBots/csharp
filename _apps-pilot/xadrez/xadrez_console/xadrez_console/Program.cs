using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                // Mensagem Inicial
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Bem Vindo ao Pandas Chess\n");

                // Inicia
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    // limpa tela
                    Console.Clear();
                    // Imprimir
                    Tela.imprimirTabuleiro(partida.tab);
                    // Ler uma posiçao do xadrez no teclado. Transforma para pos de matriz.
                    Console.WriteLine("\nDigite posição origem:");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    Console.WriteLine("\nDigite posição destino:");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    // Executa um movimento
                    partida.executaMovimento(origem, destino);

                }





            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}