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
            return "[K]";
        }
        // Método que verifica se pode mover
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            // Peça pode mover quando a casa está livre ou quando houver uma peça adversária (captura).
            return p == null || p.cor != cor;
        }
        // Método dos movimentos. Herda da classe Peca abstrata.
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            // Posicoes onde a peça pode mover
            Posicao pos = new Posicao(0, 0);
            // Movimento acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            // Enquanto estou dentro do tabuleiro, ou enquanto houver casa livre ou peça adversária.
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                // Força parada se encontrar peça adversária
                if(tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha -= 1;
            }
            // Movimento abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            // Enquanto estou dentro do tabuleiro, ou enquanto houver casa livre ou peça adversária.
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                // Força parada se encontrar peça adversária
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha += 1;
            }
            // Movimento direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            // Enquanto estou dentro do tabuleiro, ou enquanto houver casa livre ou peça adversária.
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                // Força parada se encontrar peça adversária
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna += 1;
            }
            // Movimento esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            // Enquanto estou dentro do tabuleiro, ou enquanto houver casa livre ou peça adversária.
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                // Força parada se encontrar peça adversária
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna -= 1;
            }
            return mat;

        }
    }
}

