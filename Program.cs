using System;
using System.Collections.Generic;

class Program {
    public static void Main(string[] args) {
        Console.WriteLine(">>Jaykelly Games - Controle de Estoque<<");

        List<Jogos> listaDeJogos = new List<Jogos>();

        while (true) {
            Console.WriteLine("[1] - Novo Jogo");
            Console.WriteLine("[2] - Listar Jogos");
            Console.WriteLine("[3] - Remover Jogo");
            Console.WriteLine("[4] - Entrada de Jogos");
            Console.WriteLine("[5] - Saída de Jogos");
            Console.WriteLine("[0] - Sair do Sistema");

            Console.WriteLine("O que você deseja fazer?");
            int menu = int.Parse(Console.ReadLine());

            if (menu == 1) {
                Console.WriteLine("Digite o título do jogo:");
                string titulo = Console.ReadLine();
                Console.WriteLine("Digite o Gênero do jogo:");
                string genero = Console.ReadLine();
                Console.WriteLine("Digite a plataforma do jogo:");
                string plataforma = Console.ReadLine();
                Console.WriteLine("Digite o preço do jogo:");
                double preco = double.Parse(Console.ReadLine());
                Console.WriteLine("Digite a quantidade no estoque:");
                int estoque = int.Parse(Console.ReadLine());
                Jogos novoJogo = new Jogos(titulo, genero, plataforma, preco, estoque);
                listaDeJogos.Add(novoJogo);
                Console.WriteLine("Produto adicionado com sucesso!!");
            }

            else if (menu == 2) {
                Console.WriteLine(">> Lista de Jogos <<");
                foreach (var jogos in listaDeJogos) {
                    Console.WriteLine("\nTítulo: " +  jogos.Titulo + "\nGênero: " + jogos.Genero + "\nPlataforma: " + jogos.Plataforma + "\nPreço: R$ " + jogos.Preco + "\nQuantidade em estoque: " + jogos.Estoque);
                }
                Console.WriteLine("----------------------------");
            }
            else if (menu == 3) {
                Console.WriteLine("Qual jogo deseja remover?");
                string titulo = Console.ReadLine();
                Jogos jogoRemover = listaDeJogos.Find(p => p.Titulo == titulo);
                if (jogoRemover != null) {
                    listaDeJogos.Remove(jogoRemover);
                    Console.WriteLine("Jogo Removido!!");
                }
                else {
                    Console.WriteLine("Jogo não encontrado!");
                }
            }
            else if (menu == 4) {
                Console.WriteLine("Digite o nome do jogo:");
                string titulo = Console.ReadLine();
                Console.WriteLine("Qual a quantidade que deseja inserir?");
                int quantidade = int.Parse(Console.ReadLine());
                Jogos jogo = listaDeJogos.Find(p => p.Titulo == titulo);

                if (jogo != null) {
                    jogo.Estoque += quantidade;
                    Console.WriteLine("Estoque atualizado com sucesso!");
                }
                else {
                    Console.WriteLine("Jogo não encontrado!");
                }
            }
            else if (menu == 5) {
                Console.WriteLine("Digite o nome do jogo:");
                string titulo = Console.ReadLine();
                Console.WriteLine("Qual a quantidade que deseja retirar?");
                int quantidade = int.Parse(Console.ReadLine());
                Jogos jogo = listaDeJogos.Find(p => p.Titulo == titulo);
                if (jogo != null) {
                    if (quantidade <= jogo.Estoque) {
                        jogo.Estoque -= quantidade;
                        Console.WriteLine("Estoque atualizado com sucesso!");
                    }
                    else {
                        Console.WriteLine("Quantidade insuficiente em estoque!");
                    }
                }
                else {
                    Console.WriteLine("Jogo não encontrado!");
                }
            }
            else if (menu == 0) {
                Console.WriteLine("<<Sistema Finalizado>>");
                break;
            }
            else {
                Console.WriteLine("Opção inválida!");
            }
        }
    }
}

class Jogos {
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string Plataforma { get; set; }
    public double Preco { get; set; }
    public int Estoque { get; set; }

    public Jogos(string titulo, string genero, string plataforma, double preco, int estoque) {
        Titulo = titulo;
        Genero = genero;
        Plataforma = plataforma;
        Preco = preco;
        Estoque = estoque;
    }
}

