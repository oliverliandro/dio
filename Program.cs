// See https://aka.ms/new-console-template for more information
using System.Collections;
using Repositorios;
using Classes;
using Enums;

class Program
{
    static SerieRepositorio repositorio = new SerieRepositorio();

    static void Main()
    {
        Menu();
    }


    static void Menu()
    {
        Console.Clear();
        string opcaoUsuario = ObterOpcaoUsuario();


        switch (opcaoUsuario)
        {
            case "1":
                ListaSeries();
                break;
            case "2":
                InserirSerir();
                break;
            case "3":
                AtualizarSerie();
                break;
            case "4":
                ExcluirSerie();
                break;
            case "5":
                VisualizarSerie();
                break;
            case "X":
                Sair();
                break;
            default:
                Menu();
                break;
        }

    }

    private static void Sair()
    {
        Console.WriteLine("Obrigado por utilizar os nossos serviços.");
        Console.WriteLine();

        Thread.Sleep(3000);

        Environment.Exit(0);
    }

    private static void VisualizarSerie()
    {
        Console.Clear();
        Console.Write("Digite o código da Serie que deseja consultar: ");
        int id = int.Parse(Console.ReadLine());

        var serie = repositorio.RetornaPorId(id);

        Console.Clear();
        Console.WriteLine(serie.ToString());

        Console.WriteLine("Aperte qualquer tecla para voltar ao Menu Inicial.");
        Console.ReadKey();

        Menu();
    }

    private static void ExcluirSerie()
    {
        Console.Clear();
        Console.Write("Digite o código da Serie que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());

        var serie = repositorio.RetornaPorId(id);

        if (serie == null)
        {
            Console.WriteLine("Serie não localizada!");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Dados da serie a ser excluida: ");
            Console.WriteLine(serie.ToString());
            Console.WriteLine();
            Console.Write("Confirma a exclusão? (S - SIM / N - NÃO)");
            string confirmado = Console.ReadLine().ToUpper();

            if (confirmado == "S")
            {
                repositorio.Excluir(serie.Id);
                Console.WriteLine("Serie excluída com sucesso");
            }
            else
            {
                Console.WriteLine("Operação Cancelada");
            }
        }

        Console.WriteLine("Aperte qualquer tecla para voltar ao Menu Inicial.");
        Console.ReadKey();

        Menu();
    }

    private static void AtualizarSerie()
    {
        Console.Clear();
        Console.Write("Digite o código da Serie que deseja atualizar: ");
        int id = int.Parse(Console.ReadLine());
        var serieAtual = repositorio.RetornaPorId(id);

        if (serieAtual == null)
        {
            Console.WriteLine("Série não localizada.");
        }
        else
        {

            Console.WriteLine();
            Console.WriteLine("Dados da Serie antes da alteração");
            Console.WriteLine();
            Console.WriteLine(serieAtual.ToString());

            Console.WriteLine();

            foreach (int indice in Enum.GetValues(typeof(E_Genero)))
            {
                Console.WriteLine($"{indice} - {Enum.GetName(typeof(E_Genero), indice)}");
            }

            Console.Write("Escolha um genero acima para a série: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento série: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string descricao = Console.ReadLine();


            var serie = new Serie(id, (E_Genero)genero, titulo, descricao, ano);

            Console.WriteLine("**************************************************************");
            Console.WriteLine();
            Console.WriteLine("Dados da Serie Após da alteração");
            Console.WriteLine();
            Console.WriteLine(serie.ToString());
            Console.WriteLine();
            Console.Write("Confirma a atualização da Serie? (S-SIM / N-NÃO)");
            string confirmado = Console.ReadLine().ToUpper();

            if (confirmado == "S")
            {
                repositorio.Atualizar(id, serie);
                Console.WriteLine("Serie Atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Operação Cancelada");
            }
        }
        Console.WriteLine("Aperte qualquer tecla para voltar ao Menu Inicial.");
        Console.ReadKey();

        Menu();
    }

    static void InserirSerir()
    {

        Console.Clear();
        foreach (int indice in Enum.GetValues(typeof(E_Genero)))
        {
            Console.WriteLine($"{indice} - {Enum.GetName(typeof(E_Genero), indice)}");
        }

        Console.Write("Escolha um genero acima para a série: ");
        int genero = int.Parse(Console.ReadLine());

        Console.Write("Digite o titulo da série: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite o Ano de lançamento série: ");
        int ano = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string descricao = Console.ReadLine();

        var novaSerie = new Serie(repositorio.ProximoId(), (E_Genero)genero, titulo, descricao, ano);


        Console.WriteLine("");
        Console.WriteLine("Dados da serie");
        Console.WriteLine(novaSerie.ToString());
        Console.WriteLine("");

        Console.Write("Confirma a inclusão da série: (S-SIM / N-NÃO) ");
        string confirmado = Console.ReadLine().ToUpper();

        if (confirmado == "S")
        {
            repositorio.Inserir(novaSerie);
            Console.WriteLine("Serie gravada com sucesso!");
        }
        else
        {
            Console.WriteLine("Operação Cancelada");
        }

        Console.WriteLine("");
        Console.WriteLine("Aperte qualquer tecla para voltar ao Menu Inicial.");

        Console.ReadKey();

        Menu();
    }

    static void ListaSeries()
    {
        Console.Clear();
        var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhuma série cadastrada.");

        }

        foreach (var serie in lista)
        {
            Console.WriteLine($"#ID : {serie.RetornaId()} - {serie.RetornaTitulo()}");
        }

        Console.WriteLine();

        Console.WriteLine("Aperte qualquer tecla para voltar ao Menu Inicial.");
        Console.ReadKey();
        Menu();
    }

    static string ObterOpcaoUsuario()

    {
        Console.WriteLine();
        Console.WriteLine("Digital Series a seu dispor!!!");
        Console.WriteLine("Informe a opção desejada:");

        Console.WriteLine("1 - Listar séries");
        Console.WriteLine("2 - Inserir nova série");
        Console.WriteLine("3 - Atualizar série");
        Console.WriteLine("4 - Excluir série");
        Console.WriteLine("5 - Visualizar série");
        Console.WriteLine("X - Sair");
        Console.WriteLine("");

        string opcao = Console.ReadLine().ToUpper();
        return opcao;
    }

}