using tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        // Método que recebe um objeto da classe tabuleiro
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for(int i=0; i < tab.linhas; i++)
            {
                for(int j=0; j < tab.colunas; j++)
                {
                    if(tab.peca(i,j) == null)
                    {
                        Console.Write("[] ");
                    }
                    else
                    {
                        // Vamos imprimir o valor da matriz pecas de tab através do
                        // método público peca(linha, coluna).
                        Console.Write($"{tab.peca(i, j)} ");
                    }

                }
                // Adiciona quebra de linha
                Console.WriteLine();
            }
        }
    }
}

