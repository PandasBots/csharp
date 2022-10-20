namespace tabuleiro
{
    class Tabuleiro
    {
        // 1. Atributos
        public int linhas { get; set; }
        public int colunas { get; set; }
        // Matriz de peças, que só a classe tabuleiro pode alterar.
        private Peca[,] pecas;

        // 2. Construtores
        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        // 3. Métodos
        // Como a matricas Peca é privada, vamos criar um método público isolado
        // para retornar o valor da matriz na posição desejada.
        public Peca peca(int linha, int coluna)
        {
            // Retorna o elemento da matriz pecas na posicao linha/coluna
            return pecas[linha, coluna];
        }
        // Sobrecarga do método peca. OU seja, mesmo nome de método, mas é chamado de acordo com o número de parâmetros.
        public Peca peca(Posicao pos)
        {
            // Retorna o elemento da matriz pecas na posicao linha/coluna
            return pecas[pos.linha, pos.coluna];
        }
        // Método para colocar peças no tabuleiro
        public void colocarPeca(Peca p, Posicao pos)
        {
            // Melhoria: Só posso colocar peça onde não existe outra peça.
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe peça nesta posição");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }
        // Retirar Peça do tabuleiro e marca a posição como nula.
        public Peca retirarPeca(Posicao pos)
        {
            // Se determinada posição é nula, então a peça já está retirada.
            if (peca(pos) == null)
            {
                return null;
            }
            // Caso contrário, marcamos a posição da peça como nula e retornamos a peça.
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        // Exceções
        // Verifica se uma peça existe numa determinada posição.
        public bool existePeca(Posicao pos)
        {
            // primeiro verifica a posição esta dentro do tabuleiro.
            validarPosicao(pos);
            // Retorna true ou false dependendo se a peca na posicao pos existe ou não.
            return peca(pos) != null;
        }
        // Posicao dentro do tabuleiro
        public bool posicaoValida(Posicao pos)
        {
            if(pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição Inválida");
            }
        }
    }
}

