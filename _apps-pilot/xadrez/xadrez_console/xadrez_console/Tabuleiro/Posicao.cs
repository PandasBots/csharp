namespace Tabuleiro
{
    class Posicao
    {
        // 1. Atributos
        public int linha { get; set; }
        public int coluna { get; set; }
        // 2. Construtores
        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;

        }
        // 3. Métodos
        // Override o método ToString da Classe Object.
        // Mensagem que será impressa toda vez que mandarmos imprimir o objeto instanciado por esta classe.
        public override string ToString()
        {
            return $"{linha}, {coluna}";
        }
    }
}

