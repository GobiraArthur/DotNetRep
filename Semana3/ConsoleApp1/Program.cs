using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<(string codigo, string nome, int estoque, double preco)> produtos = new List<(string, string, int, double)>();

        while (true)
        {
            Console.WriteLine("----- Menu -----");
            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Consultar");
            Console.WriteLine("3. Adicionar ao Estoque");
            Console.WriteLine("4. Subtrair do Estoque");
            Console.WriteLine("5.Relatérios");
            Console.WriteLine("0. Sair");

            int opcao = int.Parse(Console.ReadLine()!);

            switch (opcao)
            {
                case 1:
                    CadastrarProduto(produtos);
                    break;

                case 2:
                    ConsultarProduto(produtos);
                    break;

                case 3:
                    adicionarAoEstoque(produtos);
                    break;

                case 4:
                    subtrairDoEstoque(produtos);
                    break;
                case 5:
                    relatorios(produtos);
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarProduto(List<(string codigo, string nome, int estoque, double preco)> produtos)
    {
        Console.WriteLine("Qual o código do produto?");
        string codigo = Console.ReadLine()!;
        Console.WriteLine("Qual o nome do produto?");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Qual o estoque do produto?");
        int estoque = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Qual o preco do produto?");
        double preco;
        try
        {
            preco = double.Parse(Console.ReadLine()!);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Preço inválido");
            return;
        }
        var produto = (codigo, nome, estoque, preco);
        produtos.Add(produto);
        Console.WriteLine("Produto cadastrado com sucesso!");
    }

    static void ConsultarProduto(List<(string codigo, string nome, int estoque, double preco)> produtos)
    {
        Console.WriteLine("Qual o código do produto?");
        string cod = Console.ReadLine()!;
        foreach (var produto in produtos)
        {
            if (cod == produto.codigo)
            {
                Console.WriteLine($"Nome: {produto.nome}, Código: {produto.codigo}, Estoque: {produto.estoque}, Preço: {produto.preco}");
                return; 
            }
        }
        Console.WriteLine("Produto não encontrado!");
    }

    static void adicionarAoEstoque(List<(string codigo, string nome, int estoque, double preco)> produtos)
    {
        Console.WriteLine("Qual o código do produto?");
        string cod = Console.ReadLine()!;
        foreach (var produto in produtos)
        {
            if (cod == produto.codigo)
            {
                Console.WriteLine("Qual a quantidade a ser adicionada?");
                int qtd = int.Parse(Console.ReadLine()!);

                // Criar uma nova tupla com a quantidade atualizada
                var produtoAtualizado = (produto.codigo, produto.nome, produto.estoque + qtd, produto.preco);

                // Substituir a tupla antiga pela nova na lista
                int index = produtos.IndexOf(produto);
                produtos[index] = produtoAtualizado;

                Console.WriteLine("Estoque atualizado com sucesso!");
                return; 
            }
        }
        Console.WriteLine("Produto não encontrado!");
    }
    static void subtrairDoEstoque(List<(string codigo, string nome, int estoque, double preco)> produtos)
    {
        Console.WriteLine("Qual o código do produto?");
        string cod = Console.ReadLine()!;
        foreach (var produto in produtos)
        {
            if (cod == produto.codigo)
            {
                Console.WriteLine("Qual a quantidade a ser retirada?");
                int qtd = int.Parse(Console.ReadLine()!);

                if (qtd > produto.estoque)
                {
                    Console.WriteLine("Quantidade inválida!");
                    return;
                }

                // Criar uma nova tupla com a quantidade atualizada
                var produtoAtualizado = (produto.codigo, produto.nome, produto.estoque - qtd, produto.preco);

                // Substituir a tupla antiga pela nova na lista
                int index = produtos.IndexOf(produto);
                produtos[index] = produtoAtualizado;

                Console.WriteLine("Estoque atualizado com sucesso!");
                return; 
            }
        }
        Console.WriteLine("Produto não encontrado!");
    }
    static void relatorios(List<(string codigo, string nome, int estoque, double preco)> produtos){
        Console.WriteLine("Deseja qual tipo de relatório de estoque");
        Console.WriteLine("1. Valor do estoque");
        Console.WriteLine("2. Quantidade de produtos abaixo de um limite"); 
        Console.WriteLine("3. Listar min<produtos<max");
        Console.WriteLine("0. Sair");
        int opcao = int.Parse(Console.ReadLine()!);
        switch(opcao){
            case 1:
                double valortotal=0;
                foreach (var produto in produtos)
                {
                    valortotal+=produto.preco * produto.estoque;
                    Console.WriteLine("O valor total do estoque do produto " + produto.nome + " é: " + (produto.preco * produto.estoque));
                }

                Console.WriteLine("O valor total do estoque é: " + valortotal);
                break;

            case 2:
                Console.WriteLine("Qual o limite? ");
                int limite = int.Parse(Console.ReadLine()!);
                foreach (var produto in produtos)
                {
                    if(produto.estoque < limite){
                        Console.WriteLine( "O estoque do produto " + produto.nome + "é:  " + produto.estoque);
                    }
                }
                break;

            case 3:
                Console.WriteLine("Qual o limite mínimo? ");
                double min = double.Parse(Console.ReadLine()!);
                Console.WriteLine("Qual o limite máximo? ");
                double max = double.Parse(Console.ReadLine()!);
                foreach (var produto in produtos)
                {
                    if(produto.preco > min && produto.preco < max){
                        Console.WriteLine( "O produto " + produto.nome + "que custa:  " + produto.nome);
                    }
                }
                break;

        }
    }
}
