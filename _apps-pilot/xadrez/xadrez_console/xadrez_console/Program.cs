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

                // Instanciar Tabuleiro Vazio
                Tabuleiro tab = new Tabuleiro(8, 8);
                // Colocar as peças iniciais
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 9));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 2));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));

                // Chamar a Tela e Imprimir o Tabuleiro
                Tela.imprimirTabuleiro(tab);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}