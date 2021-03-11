using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio series = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
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
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por usar nossos serviços!!!" + Environment.NewLine);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine(series.RetornaPorId(id));
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série a ser excluida: ");
            int id = int.Parse(Console.ReadLine());

            var serie = series.RetornaPorId(id);

            Console.WriteLine($"Deseja mesmo excluir a série: #ID{serie.RetornaId()} - {serie.RetornaTitulo()}? (S/N)");

            string resposta = Console.ReadLine();

            if (resposta.ToUpper() == "S")
            {
                Console.WriteLine("Excluindo...");
                series.Exclui(id);
            }else
            {
                Console.WriteLine("Operação cancelada.");
            }
            
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da série:");
            int id = int.Parse(Console.ReadLine());

            foreach (int g in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{g} - {Enum.GetName(typeof(Genero),g)}");
            }

            Console.WriteLine("Digite o gênero entre as opções acima:");
            int genero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o título da série:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série:");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série:");
            string descricao = Console.ReadLine();

            series.Atualiza(id, new Serie(
                id: id,
                genero: (Genero)genero,
                titulo: titulo,
                ano: ano,
                descricao: descricao
            ));
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int g in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{g} - {Enum.GetName(typeof(Genero),g)}");
            }

            Console.WriteLine("Digite o gênero entre as opções acima:");
            int genero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o título da série:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série:");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série:");
            string descricao = Console.ReadLine();

            series.Insere(new Serie(
                id: series.ProximoId(),
                genero: (Genero)genero,
                titulo: titulo,
                ano: ano,
                descricao: descricao
            ));


        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = series.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada");
            }

            foreach (var serie in lista)
            {
                Console.WriteLine($"#ID {serie.RetornaId()}: - {serie.RetornaTitulo()} {(serie.EstaExcluido() ? "(Excluido)" : "")}");
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
        }
    }
}
