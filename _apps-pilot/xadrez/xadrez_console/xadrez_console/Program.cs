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
                Console.WriteLine("Bem Vindo ao Pandas Chess\n");

                // Inicia
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try
                    {
                        // Limpa e Imprime o Tabuleiro neste passo.
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        // Posição de Origem
                        Console.WriteLine("\nDigite posição origem:");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoOrigem(origem);

                        // Obter as posiçoes possíveis
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        // Limpa e imprime o tabuleiro com as posições possíveis.
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        // Posição de Destino
                        Console.WriteLine("\nDigite posição destino:");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDestino(origem, destino);

                        // Executa um movimento
                        partida.realizaJogada(origem, destino);

                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Aperte Enter para Continuar..");
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}