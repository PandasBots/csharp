using tabuleiro;
// Usando conjuntos
using System.Collections.Generic;


namespace xadrez
{
    class PartidaDeXadrez
    {
        // 1. Atributos
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        // indica se a partida terminou
        public bool terminada { get; private set; }
        // Conjunto para coletar peças capturadas
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;


        // 2. Construtores
        public PartidaDeXadrez()
        {
            // Inicia o tabuleiro com 8x8 locais
            tab = new Tabuleiro(8, 8);
            // O primeiro turno é o 1
            turno = 1;
            // O jogador que está jogando. Inicialmente é branco
            jogadorAtual = Cor.Branca;
            // Instancia as peças
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            // Coloca as peças
            colocarPecas();
            // A partida não inicia como terminada
            terminada = false;
        }

        // 3. Métodos
        // Método que alterna entre jogadores
        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        // Método que retorna o conjunto de pecás capturadas de uma dada cor
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        // Método que retorna quem sao as pecas em jogo de uma dada cor
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

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
            // 5. Se capturou uma peça, ela entra no set das peças capturadas.
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
        }


        // Método chamado quando realizar uma jogada
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        // Valida posiçao de origem
        public void validarPosicaoOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida.");
            }
            if(jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua.");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis.");
            }
        }
        // Valida posiçao de destino
        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida.");
            }
        }

        //Coloca novas peças
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        // Método auxiliar para colocar peças usando notaçao de xadrez
        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));

            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));

        }
    }
}

