﻿using System;

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
						ListarSeries();
						break;
					case "2":
						ListarSeriesValidas();
						break;
					case "3":
						ListarSeriesExcluidas();
						break;
					case "4":
						InserirSerie();
						break;
					case "5":
						AtualizarSerie();
						break;
					case "6":
						ExcluirSerie();
						break;
					case "7":
						VisualizarSerie();
						break;
					case "8":
						QuantidadeDeSeries();
						break;
					case "9":
						QuantidadeDeSeriesValidas();
						break;
					case "10":
						QuantidadeDeSeriesExcluidas();
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

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar todas as séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void ListarSeriesValidas()
		{
			Console.WriteLine("Listar séries validas");

			var lista = repositorio.ListaValidas();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{                
				Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
			}
		}

		private static void ListarSeriesExcluidas()
		{
			Console.WriteLine("Listar séries excluidas");

			var lista = repositorio.ListaExcluidas();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{                
				Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

		private static void QuantidadeDeSeries()
		{
			Console.WriteLine("Quantidade de séries cadastradas");
			Console.WriteLine("#{0} séries", repositorio.QuantidadeSeries());
		}
		private static void QuantidadeDeSeriesValidas()
		{
			Console.WriteLine("Quantidade de séries validas");
			Console.WriteLine("#{0} séries", repositorio.QuantidadeSeriesValidas());
		}
		
		private static void QuantidadeDeSeriesExcluidas()
		{
			Console.WriteLine("Quantidade de séries excluidas");
			Console.WriteLine("#{0} séries", repositorio.QuantidadeSeriesExcluidas());
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1  - Listar todas as séries");
			Console.WriteLine("2  - Listar séries validas");
			Console.WriteLine("3  - Listar séries excluidas");
			Console.WriteLine("4  - Inserir nova série");
			Console.WriteLine("5  - Atualizar série");
			Console.WriteLine("6  - Excluir série");
			Console.WriteLine("7  - Visualizar série");
			Console.WriteLine("8  - Quantidade de séries");
			Console.WriteLine("9  - Quantidade de séries validas");
			Console.WriteLine("10 - Quantidade de séries excluidas");
			Console.WriteLine("C  - Limpar Tela");
			Console.WriteLine("X  - Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}