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

    }
}

