using System;

namespace series_crud
{
    class Program
    {
        static RepositorySerie repository = new RepositorySerie();

        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        RefreshSeries();
                        break;

                }
            }
        }

        private static void RefreshSeries()
        {
            Console.Write("Digite o id da série: ");

            int serieIndex = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(GenderEnum)))
            {
                Console.Write("{0}-{1}", i, Enum.GetName(typeof(GenderEnum), i));
            }
            Console.Write("Digite o genero entre os listados: ");
            int genderEntry = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string titleEntry = Console.ReadLine();

            Console.Write("Digite o Ano: ");
            int yearEntry = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição:  ");
            string descriptionEntry = Console.ReadLine();

            Series refreshSeries = new Series(
                id: repository.NextId(),
                gender: (GenderEnum)genderEntry,
                title: titleEntry,
                year: yearEntry,
                description: descriptionEntry);

            repository.Refresh(serieIndex, refreshSeries);
        }


    }
    private static void ListSeries()
    {
        Console.WriteLine("Listar séries");

        var list = repository._List();

        if (list.Count == 0)
        {
            Console.WriteLine("Nenhuma série cadastrada");
            return;
        }
        foreach (var series in list)
        {
            Console.WriteLine("#ID {0}: - {1}", series.returnId(), series.returnTitle());
        }
    }

    private static void InsertSeries()
    {
        Console.WriteLine("Inserir nova série");
        foreach (int i in Enum.GetValues(typeof(GenderEnum)))
        {
            Console.WriteLine("#ID {0}: - {1}", i, Enum.GetName(typeof(GenderEnum), i));
        }
        Console.Write("Digite o gênero entre as opções listadas: ");
        int genderEntry = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título: ");
        string titleEntry = Console.ReadLine();

        Console.Write("Digite o Ano: ");
        int yearEntry = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição:  ");
        string descriptionEntry = Console.ReadLine();

        Series newSeries = new Series(
            id: repository.NextId(),
            gender: (GenderEnum)genderEntry,
            title: titleEntry,
            year: yearEntry,
            description: descriptionEntry);

        repository.Insert(newSeries);
    }

    private static string GetUserOption()
    {
        Console.WriteLine();
        Console.WriteLine("Status de API [ON]");
        Console.WriteLine("Informe a opção desejada:");
        Console.WriteLine("1 - Listar Series");
        Console.WriteLine("2 - Inserir nova serie");
        Console.WriteLine("3 - Atualizar serie");
        Console.WriteLine("4 - Exclui serie");
        Console.WriteLine("5 - Visualizar serie");
        Console.WriteLine("C - Limpar a tela");
        Console.WriteLine("X - Sair");
        Console.WriteLine();

        string userOption = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return userOption;
    }
}
}
