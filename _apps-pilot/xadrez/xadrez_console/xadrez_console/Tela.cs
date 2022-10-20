using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace xadrez_console
{
    class Tela
    {
        // Método que otimiza a impressão da partida
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine($"\nTurno: {partida.turno}");
            // Se partida estiver em xeque
            if (!partida.terminada)
            {
                Console.WriteLine($"\nAguardando jogada: {partida.jogadorAtual}");
                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }

        // Peças Capturadas
        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            // muda cores
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            // Volta a cor original
            Console.ForegroundColor = aux;
        }

        // Conjunto
        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
            {
                Console.Write($"{x} ");
            }
            Console.Write("]\n");
        }


        // Método que recebe um objeto da classe tabuleiro
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for(int i=0; i < tab.linhas; i++)
            {
                // Imprime a legenda do tabuleiro
                Console.Write($"{8 - i} ");
                for(int j=0; j < tab.colunas; j++)
                {
                    // Vamos imprimir o valor da matriz pecas de tab através do
                    // método público peca(linha, coluna).
                    imprimirPeca(tab.peca(i, j));
               }
                // Adiciona quebra de linha
                Console.WriteLine();
            }
            Console.Write($"   a   b   c   d   e   f   g   h");
        }
        // Metodo com sobrecarga para imprimir o tabuleiro com as posiçoes possíveis marcadas.
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                // Imprime a legenda do tabuleiro
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    // Vamos imprimir o valor da matriz pecas de tab através do
                    // método público peca(linha, coluna).
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                // Adiciona quebra de linha
                Console.WriteLine();
            }
            Console.Write($"   a   b   c   d   e   f   g   h");
            Console.BackgroundColor = fundoOriginal;
        }

        // Método para imprimir a cor da peça
        public static void imprimirPeca(Peca peca)
        {
            if(peca == null)
            {
                Console.Write("[ ] ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write($"{peca} ");
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{peca} ");
                    Console.ForegroundColor = aux;
                }
            }

        }

        // Método para ler a posição
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            // Usuário insere uma posição do xadrez
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse($"{s[1]}");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}

