using System;
using System.Globalization;

namespace PrimeiroProjeto
{
    public class Produto
    {
        // Atributos do objeto instanciado pela classe Produto
        public string Nome;
        public double Preco;
        public int Quantidade;

        // Função que retorna o preço x quantidade
        public double ValorTotalEmEstoque()
        {
            return Preco * Quantidade;
        }

        // Função que atualiza o atributo Quantidade
        public void AdicionarProdutos(int qtdAdicionada)
        {
            Quantidade = Quantidade + qtdAdicionada;
        }

        //
        public void RemoverProdutos(int qtdRemovida)
        {
            Quantidade = Quantidade - qtdRemovida;
        }

        //ToString
        public override string ToString()
        {
            return $"Produto: {Nome}, Preço: {Preco:F2}, Quantidade: {Quantidade}, Estoque: {ValorTotalEmEstoque()}";
        }

    }
}

