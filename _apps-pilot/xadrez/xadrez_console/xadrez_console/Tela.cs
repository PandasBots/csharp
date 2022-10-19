using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        // Método que recebe um objeto da classe tabuleiro
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for(int i=0; i < tab.linhas; i++)
            {
                // Imprime a legenda do tabuleiro
                Console.Write($"{8 - i} ");
                for(int j=0; j < tab.colunas; j++)
                {
                    if (tab.peca(i,j) == null)
                    {
                        Console.Write("[ ] ");
                    }
                    else
                    {
                        // Vamos imprimir o valor da matriz pecas de tab através do
                        // método público peca(linha, coluna).
                        imprimirPeca(tab.peca(i, j));
                    }

                }
                // Adiciona quebra de linha
                Console.WriteLine();
            }
            Console.Write($"   a   b   c   d   e   f   g   h");
        }

        // Método para imprimir a cor da peça
        public static void imprimirPeca(Peca peca)
        {
            if(peca.cor == Cor.Branca)
            {
                Console.Write($"{ peca} ");
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{peca} ");
                Console.ForegroundColor = aux;

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

