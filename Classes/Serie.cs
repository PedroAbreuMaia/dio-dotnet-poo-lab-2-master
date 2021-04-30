using System;
using System.Collections.Generic;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Atributos
		private Genero Genero { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
        private bool Excluido { get; set; }
		private List<Temporada> temporadas = new List<Temporada>();

        // Métodos
		public Serie(int id, Genero genero, string titulo, string descricao, int ano)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;
			if (this.temporadas.Count > 0)
			{
				retorno += "Temporadas: " + Environment.NewLine;
				int i = 1;
				foreach(var t in temporadas)
				{
					retorno += i + " - " +  t.ToString() + Environment.NewLine;
					i++;
				}
			}
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}

		public List<Temporada> retornaTemporadas()
		{
			return this.temporadas;
		}

        public void Excluir() {
            this.Excluido = true;
        }

		public void AdicionaTemporada(Temporada temporada) 
		{
			this.temporadas.Add(temporada);
		}
    }
}