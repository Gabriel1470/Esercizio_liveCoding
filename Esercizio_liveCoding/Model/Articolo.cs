
namespace Esercizio_liveCoding.Model
{
    internal class Articolo
    {
        public string Categoria { get; set; }
        public string Nome { get; set; }
        public double Prezzo { get; set; }

        public Articolo(string categoria, string nome, double prezzo)
        {
            this.Categoria = categoria;
            this.Nome = nome;
            this.Prezzo = prezzo;
        }

        public override string ToString()
        {
            return $"Nome {Nome} , Prezzo {Prezzo}$";
        }
    }
}
