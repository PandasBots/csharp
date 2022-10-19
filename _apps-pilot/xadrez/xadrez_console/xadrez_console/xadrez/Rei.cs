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
            // 1. Posição Norte da peça
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            // Se a posição estiver dentro dos limites, e pode mover, então atribuimos true para a matriz de posições que a peça pode mover aqui.
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // 2. Posição NE da peça
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // 2. Posição Leste da peça
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // 2. Posição SE da peça
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // 2. Posição Sul da peça
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // 2. Posição Sudoeste da peça
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // 2. Posição Oeste da peça
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // 2. Posição Noroeste da peça
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            return mat;

        }
    }
}

