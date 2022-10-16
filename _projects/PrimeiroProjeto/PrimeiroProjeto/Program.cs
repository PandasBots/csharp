using System;
using System.Collections.Generic;
// Para tratar números padrão EUA e BR
using System.Globalization;

namespace PrimeiroProjeto // Note: actual namespace depends on the project name.
{
    internal class Program
    {
            static void Main(string[] args)
            {
            /*
            // Cria o objeto 'p' do tipo Produto.
            Produto p = new Produto();

            // Pede os dados do produto
            Console.WriteLine("Entre com os dados do Produto:");
            Console.WriteLine("Nome: ");
            p.Nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            // A saída de WriteLine é uma string. Usamos Parse para transformar em Double.
            p.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Quantidade no estoque :");
            p.Quantidade = int.Parse(Console.ReadLine());
            // Exibe a descrição (ToString) do produto
            Console.WriteLine($"Dados do produto: {p}.");
            // Chamando o método que adiciona os novos produtos à variável Quantidade
            // Pede para adicionar e remover mais produtos
            Console.WriteLine("Quantidade a ser adicionada: ");
            int qtd = int.Parse(Console.ReadLine());
            p.AdicionarProdutos(qtd);
            // Exibe a descrição (ToString) do produto
            Console.WriteLine($"Dados atualizados do produto: {p}.");
            // Chamando o método que remove os novos produtos à variável Quantidade
            // Pede para adicionar e remover mais produtos
            Console.WriteLine("Quantidade a ser removida: ");
            int qtd_remove = int.Parse(Console.ReadLine());
            p.RemoverProdutos(qtd_remove);
            // Exibe a descrição (ToString) do produto
            Console.WriteLine($"Dados atualizados do produto: {p}.");
            

            // Chama Operação da Clásse Estática
            int raio = 3;
            double circ = ClasseEstatica.CalculaCircunferencia(raio);
            Console.WriteLine($"Circunferencia do circulo de raio: {raio} é: {circ}");

            Produto p = new Produto();
            
            List<string> list = new List<string>();
            list.Add("Maria");
            list.Add("Joao");
            list.Add("Altair");
            list.Add("Ana");
            list.Add("AnaAnaAnaAna");
            //Console.WriteLine(list);
            List<string> listResultado = new List<string>();
            listResultado = list.FindAll(x => x.Length >= 5);
            //listResultado = list.FindAll(x => x.Length == 5);
            listResultado.ForEach(Console.WriteLine);
            */

            // Matrizes
            double[,] mat = new double[2, 3];

            Console.WriteLine(mat.Length);
            Console.WriteLine(mat.Rank);
            Console.WriteLine(mat.GetLength(0));
            Console.WriteLine(mat.GetLength(1));




        }
    }  
}
