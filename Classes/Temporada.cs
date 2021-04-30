namespace DIO.Series
{
    public class Temporada
    {
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private int NumeroEpisodios { get; set; }

        public Temporada (string descricao, int ano, int numeroEpisodios)
        {
            this.Descricao = descricao;
            this.Ano = ano;
            this.NumeroEpisodios = numeroEpisodios;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Ano: " + this.Ano;
            retorno += ", QtdEpisódios: " + this.NumeroEpisodios;
            retorno += ", Descrição: " + this.Descricao; 
            return retorno;
        }

        public string retornaDescrição() 
        {
            return this.Descricao;
        }

        public int retornaAno()
        {
            return this.Ano;
        }

        public int retornaNumeroEpisodios()
        {
            return this.NumeroEpisodios;
        }

    }
}