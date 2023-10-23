﻿using System.Collections;
using System.Collections.Generic;

class Program
{
    struct Banda
    {
        public string nome;
        public string genero;
        public int integrantes;
        public int ranking;
    }
    static void addBanda(List<Banda> lista)
    {
        Banda banda = new Banda();
        Console.WriteLine("Digite o nome da Banda: ");
        banda.nome = Console.ReadLine();
        Console.WriteLine("Digite o gênero musical: ");
        banda.genero = Console.ReadLine();
        Console.WriteLine("Digite a quantidade de integrantes: ");
        banda.integrantes = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite a posição no Ranking: ");
        banda.ranking = int.Parse(Console.ReadLine());
        lista.Add(banda);
    }
    static void listarBanda(List<Banda> lista)
    {
        int qtd = lista.Count();

        Console.WriteLine("Bandas Cadastradas");

        for (int i = 0; i < qtd; i++)
        {
            Console.WriteLine("Nome da Banda: " + lista[i].nome);
            Console.WriteLine("Gênero Musical: " + lista[i].genero);
            Console.WriteLine("Quantidade de Integrantes: " + lista[i].integrantes);
            Console.WriteLine("Posição no Ranking: " + lista[i].ranking);
        }
    }

    static void buscarRanking(List<Banda> lista, int posicao)
    {
        int qtd = lista.Count();
        bool flag = false;
        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].ranking == posicao)
            {
                flag = true;
                Console.WriteLine("Nome da Banda: " + lista[i].nome);
                Console.WriteLine("Gênero Musical: " + lista[i].genero);
                Console.WriteLine("Quantidade de Integrantes: " + lista[i].integrantes);
                Console.WriteLine("Posição no Ranking: " + lista[i].ranking);
            }
        }
        if (!flag)
        {
            Console.WriteLine($"Posição {posicao} não consta na lista.");
        }
    }
    static void buscarGenero(List<Banda> lista, string genero)
    {
        int qtd = lista.Count();
        bool flag = false;
        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].genero.ToUpper().Equals(genero.ToUpper()))
            {
                flag = true;
                Console.WriteLine("Nome da Banda: " + lista[i].nome);
                Console.WriteLine("Gênero Musical: " + lista[i].genero);
                Console.WriteLine("Quantidade de Integrantes: " + lista[i].integrantes);
                Console.WriteLine("Posição no Ranking: " + lista[i].ranking);
            }
        }
        if (!flag)
        {
            Console.WriteLine($"Bandas de {genero} não encontradas.");
        }
    }
    static void buscarNome(List<Banda> lista, string nome)
    {
        int qtd = lista.Count();
        bool flag = false;
        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].nome.ToUpper().Equals(nome.ToUpper()))
            {
                flag = true;
                Console.WriteLine("Nome da Banda: " + lista[i].nome);
                Console.WriteLine("Gênero Musical: " + lista[i].genero);
                Console.WriteLine("Quantidade de Integrantes: " + lista[i].integrantes);
                Console.WriteLine("Posição no Ranking: " + lista[i].ranking);
            }
        }
        if (!flag)
        {
            Console.WriteLine($"Banda {nome} não encontrada.");
        }
    }
    static void excluirBanda(List<Banda> lista, string nome)
    {
        int qtd = lista.Count();
        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].nome.ToUpper().Equals(nome.ToUpper()))
            {
                Console.WriteLine("Tem certeza que deseja excluir a banda? [S/N]");
                char resp = char.Parse(Console.ReadLine());
               
                if(resp == 'S' || resp == 's')
                {
                    lista.RemoveAt(i);
                    Console.WriteLine("Banda Removida com sucesso");
                }
                else if(resp == 'N' || resp == 'n')
                {
                    Console.WriteLine("Operação Cancelada");
                }
                else
                {
                    Console.WriteLine("Entrada inválida");
                }
                
            }
        }
    }
    static void alterarBanda(List<Banda> lista, string nome)
    {
        int qtd = lista.Count();
        bool flag = false;
        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].nome.ToUpper().Equals(nome.ToUpper()))
            {
                flag = true;
                Banda banda = new Banda();
                Console.WriteLine("Digite o nome Nova da Banda: ");
                banda.nome = Console.ReadLine();
                Console.WriteLine("Digite o gênero musical: ");
                banda.genero = Console.ReadLine();
                Console.WriteLine("Digite a quantidade de integrantes: ");
                banda.integrantes = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a posição no Ranking: ");
                banda.ranking = int.Parse(Console.ReadLine());
                lista[i] = banda;
            }
        }
        if (!flag)
        {
            Console.WriteLine($"Banda {nome} não encontrada.");
        }
    }

    static void salvarDados(List<Banda> bandas, string nomeArquivo)
    {

        using (StreamWriter writer = new StreamWriter(nomeArquivo))
        {
            foreach (Banda banda in bandas)
            {
                writer.WriteLine($"{banda.nome},{banda.genero},{banda.integrantes},{banda.ranking}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");


    }

    static void carregarDados(List<Banda> bandas, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                Banda banda = new Banda
                {
                    nome = campos[0],
                    genero = campos[1],
                    integrantes = int.Parse(campos[2]),
                    ranking = int.Parse(campos[3])
                };
                bandas.Add(banda);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }
    static int menu()
    {
        Console.WriteLine("Menu Principal: ");
        Console.WriteLine("1 - Adicionar Bandas:");
        Console.WriteLine("2 - Listar Bandas:");
        Console.WriteLine("3 - Buscar por posição no Ranking:");
        Console.WriteLine("4 - Buscar por Gênero:");
        Console.WriteLine("5 - Buscar por nome da Banda:");
        Console.WriteLine("6 - Excluir Banda:");
        Console.WriteLine("7 - Alterar Banda:");
        Console.WriteLine("0 - Sair:");
        Console.WriteLine();
        Console.WriteLine("Digite a opção que deseja escolher: ");
        int op = int.Parse(Console.ReadLine());
        return op;
    }

    static void Main()
    {
        List<Banda> listaBandas = new List<Banda>();

        int escolha = 0;

        do
        {
            escolha = menu();
            switch (escolha)
            {
                case 1:
                    addBanda(listaBandas);
                    break;
                case 2:
                    listarBanda(listaBandas);
                    break;
                case 3:
                    Console.WriteLine("Digite a posição do Ranking: ");
                    int posicao = int.Parse(Console.ReadLine());
                    buscarRanking(listaBandas, posicao);
                    break;
                case 4:
                    Console.WriteLine("Digite o Gênero: ");
                    string genero = Console.ReadLine();
                    buscarGenero(listaBandas, genero);
                    break;
                case 5:
                    Console.WriteLine("Digite o Nome da Banda: ");
                    string nome = Console.ReadLine();
                    buscarNome(listaBandas, nome);
                    break;
                case 6:
                    Console.WriteLine("Digite o Nome da Banda: ");
                    nome = Console.ReadLine();
                    excluirBanda(listaBandas, nome);
                    break;
                case 7:
                    Console.WriteLine("Digite o Nome da Banda: ");
                    nome = Console.ReadLine();
                    alterarBanda(listaBandas, nome);
                    break;
                case 0:
                    salvarDados(listaBandas, "dados.txt");
                    break;
                default:
                    Console.WriteLine("Opção Inválida.");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        } while (escolha != 0);
    }
}