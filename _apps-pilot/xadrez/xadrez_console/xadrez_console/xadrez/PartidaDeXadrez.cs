using tabuleiro;


namespace xadrez
{
    class PartidaDeXadrez
    {
        // 1. Atributos
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        // indica se a partida terminou
        public bool terminada { get; private set; }


        // 2. Construtores
        public PartidaDeXadrez()
        {
            // Inicia o tabuleiro com 8x8 locais
            tab = new Tabuleiro(8, 8);
            // O primeiro turno é o 1
            turno = 1;
            // O jogador atual é branco
            jogadorAtual = Cor.Branca;
            // Coloca as peças
            colocarPecas();
            // A partida não inicia como terminada
            terminada = false;
        }

        // 3. Métodos
        // Mover a peça de uma posição para outra. Retira a peça e depois coloca a peça.
        public void executaMovimento(Posicao origem, Posicao destino)
        {
            // 1. retira a peça da origem se houver
            Peca p = tab.retirarPeca(origem);
            // 2. Incrementa a qtd de movimentos
            p.incrementarQteMovimentos();
            // 3. Retirar a peça de destino se houver
            Peca pecaCapturada = tab.retirarPeca(destino);
            // 4. Colocar a peça de origem no destino
            tab.colocarPeca(p, destino);
        }
        // Método auxiliar para colocar peças usando notaçao de xadrez
        private void colocarPecas()
        {
            // Colocar as peças iniciais indicando a notação xadrez e a convertendo.
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('a', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('h', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('h', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());


        }
    }
}

