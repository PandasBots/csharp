﻿namespace tabuleiro
{
    abstract class Peca
    {
        // 1. Atributos
        public Posicao posicao { get; set; }
        // Usamos protected para indicar que apenas ela mesma e suas subclasses podem modificar a cor.
        public Cor cor { get; protected set; }
        // Quantidade de movimentos que a peça já fez
        public int qteMovimentos { get; protected set; }
        // A peça está num tabuleiro
        public Tabuleiro tab { get; protected set; }

        // 2. Construtores
        // Veja que usamos THIS para especificar de qual variável estamos falando.
        // Uma alternativa seria usar variáveis com nomes diferentes, ou PascalCase.
        // Veja que ao criar uma peça a posição será nula. Pois isso será feito pelo método
        // colocarPeca do namespace Tabuleiro
        public Peca(Tabuleiro tab, Cor cor)
        {
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        // 3. Método
        // Incrementa a qtd de movimentos
        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }
        // Método para mover as peças. Retorna uma matriz de booleanos dizendo quais lugares a peça pode ir.
        // Método abstrato, pois é genérico demais. não possui um corpo por definição.
        public abstract bool[,] movimentosPossiveis();

    }
}

