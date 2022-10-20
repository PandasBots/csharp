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
        // Indica se partida está em xeque
        public bool xeque { get; private set; }
        public Peca vulneravelEnPassant { get; private set; }


        // 2. Construtores
        public PartidaDeXadrez()
        {
            // Inicia o tabuleiro com 8x8 locais
            tab = new Tabuleiro(8, 8);
            // O primeiro turno é o 1
            turno = 1;
            // O jogador que está jogando. Inicialmente é branco
            jogadorAtual = Cor.Branca;
            // A partida não inicia como terminada nem com xeque
            terminada = false;
            xeque = false;
            vulneravelEnPassant = null;
            // Instancia as peças
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            // Coloca as peças
            colocarPecas();

        }

        // 3. Métodos

        // ----- Coloca Peças ----- //
        //Coloca novas peças
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        // Método auxiliar para colocar peças usando notaçao de xadrez
        private void colocarPecas()
        {
            colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Dama(tab, Cor.Branca));
            // Usamos diz para passar o objeto partida, que é o próprio objeto desta classe.
            colocarNovaPeca('e', 1, new Rei(tab, Cor.Branca, this));
            colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('a', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('b', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('c', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('d', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('e', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('f', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('g', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('h', 2, new Peao(tab, Cor.Branca, this));

            colocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Dama(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Rei(tab, Cor.Preta, this));
            colocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('a', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('b', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('c', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('d', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('e', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('f', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('g', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('h', 7, new Peao(tab, Cor.Preta, this));
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
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        // ----- VALIDACOES ----- //
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
            if (!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida.");
            }
        }

        // ----- XEQUE ----- //
        // Descobre qual a cor oposta a uma dada cor.
        private Cor adversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }
        // Devolve o rei de uma dada cor
        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                // Verifica se a subclasse de Peça é uma isntancia de Rei, subclasse.
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }
        // Matriz que retorna os movimentos possíveis de todas as peças de uma dada cor
        public bool estaEmXeque(Cor cor)
        {
            Peca K = rei(cor);
            
            if(K == null)
            {
                throw new TabuleiroException($"Não tem rei da cor {cor} em jogo");
            }
            foreach(Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                // Neste caso estamos em cheque
                if (mat[K.posicao.linha, K.posicao.coluna])
                {
                    return true;
                }
            }
            // Varremos todas e não achamos. Então nao está em xeque.
            return false;
        }
        // Lógica do Xeque Mate
        public bool testeXequemate(Cor cor)
        {
            // SE o rei desta cor não está sequer em xeque, então não será xequemate.
            if (!estaEmXeque(cor))
            {
                return false;
            }
            foreach(Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();
                for (int i = 0; i<tab.linhas; i++)
                {
                    for (int j = 0; j<tab.colunas; j++)
                    {
                        // Se o movimento é possível
                        if (mat[i, j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            // Depois de todos os testes conclui que está em xequemate.
            return true;
        }
      

        // ----- LÓGICA MOVIMENTAÇÃO ----- //
        // Método que alterna entre jogadores
        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }
        // Mover a peça de uma posição para outra. Retira a peça e depois coloca a peça.
        // Este método retorna a peça capturada. Util para desfazer um movimento inválido por exemplo.
        public Peca executaMovimento(Posicao origem, Posicao destino)
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
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }

            // #jogadaespecial roque pequeno
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Peca T = tab.retirarPeca(origemT);
                T.incrementarQteMovimentos();
                tab.colocarPeca(T, destinoT);
            }

            // #jogadaespecial roque grande
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                Peca T = tab.retirarPeca(origemT);
                T.incrementarQteMovimentos();
                tab.colocarPeca(T, destinoT);
            }

            // #jogadaespecial en passant
            if (p is Peao)
            {
                if (origem.coluna != destino.coluna && pecaCapturada == null)
                {
                    Posicao posP;
                    if (p.cor == Cor.Branca)
                    {
                        posP = new Posicao(destino.linha + 1, destino.coluna);
                    }
                    else
                    {
                        posP = new Posicao(destino.linha - 1, destino.coluna);
                    }
                    pecaCapturada = tab.retirarPeca(posP);
                    capturadas.Add(pecaCapturada);
                }
            }

            return pecaCapturada;
        }


        // Método que retira a peça do destino e devolve pra origem. Devolve as capturadas.
        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQteMovimentos();
            // Se uma peça foi capturada.
            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);
        }

        // Método chamado quando realizar uma jogada
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            // Se capturei uma peça, verificar se com esse movimento fiquei em xeque.
            Peca pecaCapturada = executaMovimento(origem, destino);
            // Testa se está em xeque
            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            Peca p = tab.peca(destino);

            // #jogadaespecial promocao
            if (p is Peao)
            {
                if ((p.cor == Cor.Branca && destino.linha == 0) || (p.cor == Cor.Preta && destino.linha == 7))
                {
                    p = tab.retirarPeca(destino);
                    pecas.Remove(p);
                    Peca dama = new Dama(tab, p.cor);
                    tab.colocarPeca(dama, destino);
                    pecas.Add(dama);
                }
            }
            // Testa se está em xequemate
            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (testeXequemate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                mudaJogador();
            }

            // #jogadaespecial en passant
            if (p is Peao && (destino.linha == origem.linha - 2 || destino.linha == origem.linha + 2))
            {
                vulneravelEnPassant = p;
            }
            else
            {
                vulneravelEnPassant = null;
            }

        }
    }
}

