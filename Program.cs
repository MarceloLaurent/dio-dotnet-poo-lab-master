using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        CreateSerie();
                        break;

                    case "2":
                        GetAllSeries();
                        break;

                    case "3":
                        GetByIdSerie();
                        break;

                    case "4":
                        UpdateSerie();
                        break;

                    case "5":
                        DeleteSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                    throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

    private static void CreateSerie()
        {
            Console.WriteLine("Inserir nova série");
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite os gêneros entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o ano de Início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a nota de avaliação da série (0 - 10): ");
            float entradaAvaliacao = float.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: repositorio.NextId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: entradaAno,
                avaliacao: entradaAvaliacao);

                repositorio.Create(novaSerie);
        }

        private static void GetAllSeries()
        {
            Console.WriteLine("Listar Séries.");

            var lista = repositorio.GetAll();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                if(serie.Excluido == false)
                {
                    Console.WriteLine("#ID {0}: {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }
        }

        private static void GetByIdSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.GetById(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void UpdateSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite os gêneros entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o ano de Início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a nota de avaliação da série (0 - 10): ");
            float entradaAvaliacao = float.Parse(Console.ReadLine());

            Serie updateSerie = new Serie(id: repositorio.NextId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: entradaAno,
                avaliacao: entradaAvaliacao);

                repositorio.Update(indiceSerie, updateSerie);
        }

        private static void DeleteSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Delete(indiceSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Inserir nova série");
			Console.WriteLine("2- Listar séries");
			Console.WriteLine("3- Visualizar série");
			Console.WriteLine("4- Atualizar série");
			Console.WriteLine("5- Excluir série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
