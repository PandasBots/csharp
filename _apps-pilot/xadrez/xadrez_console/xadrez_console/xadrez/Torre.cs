using tabuleiro;
namespace xadrez
{
    class Rei : Peca
    {
        // Construtor
        // Ao receber um tabuleiro e uma cor, ele repassa para o método da classe base: Peca.
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        // Métodos
        public override string ToString()
        {
            return "K";
        }
    }
}

