using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
        private List<Serie> listaSerie = new List<Serie>();
		private int nextId = 0;
		public void Atualiza(int id, Serie objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Serie objeto)
		{
			listaSerie.Add(objeto);
			nextId++;
		}

		public void InsereTemporada(int id, Temporada objeto) {
			listaSerie[id].AdicionaTemporada(objeto);
		}

		public List<Serie> Lista()
		{
			return listaSerie;
		}

		public List<Serie> ListaValidas()
		{
			return listaSerie.FindAll(x => x.retornaExcluido() == false);
		}

		public List<Serie> ListaExcluidas()
		{
			return listaSerie.FindAll(x => x.retornaExcluido() == true);
		}

		public int ProximoId()
		{
			return this.nextId;
		}

		public Serie RetornaPorId(int id)
		{
			return listaSerie.Find(x => x.Id == id);
		}

		public int QuantidadeSeries() 
		{
			return this.ProximoId();
		}

		public int QuantidadeSeriesValidas() 
		{
			var seriesValidas = this.ListaValidas();
			return seriesValidas.Count;
		}

		public int QuantidadeSeriesExcluidas() 
		{
			var seriesExcluidas = this.ListaExcluidas();
			return seriesExcluidas.Count;
		}
	}
}