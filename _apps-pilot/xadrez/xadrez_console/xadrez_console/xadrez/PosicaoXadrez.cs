using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {
        // 1. Atributos
        public char coluna { get; set; }
        public int linha { get; set; }

        // 2. Construtores
        public PosicaoXadrez(char coluna, int linha)
        {
            this.linha = linha;
            this.coluna = coluna;
        }


        // 3. Métodos
        public override string ToString()
        {
            return $"{coluna}{linha}";
        }
        // Converte coordenadas xadrez-matriz
        public Posicao toPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a');
        }
    }
}

