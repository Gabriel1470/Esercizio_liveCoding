

using Esercizio_liveCoding.Model;

namespace Esercizio_liveCoding
{
    internal class Supermercato
    {
        public List<Articolo> listArt = new List<Articolo>()
        {
                new Articolo("latticini","Latte",1.20),
                new Articolo("colazione","Biscotti",1.50),
                new Articolo("surgelati","Gelato",1.70),
                new Articolo("latticini","Ricotta",1.00),
                new Articolo("animali","Croccantini",2.00),
                new Articolo("latticini","Parmiggiani",1.99)
        };


        public List<Articolo> GetArticoli()
        {
            return listArt;
        }

        public List<Articolo> FilterByName(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return listArt;
            }

            return listArt
                    .Where(articolo => ConditionName(articolo, input))
                    .ToList();
        }
        public List<Articolo> FilterByCategory(string? input)
        {
            if (input == null)
            {
                return listArt;
            }

            return listArt
                    .Where(articolo => ConditionCategory(articolo, input))
                    .ToList();
        }
        public List<Articolo> FilterByPrice(double? prezzo)
        {
            if (prezzo == null)
            {
                return listArt;
            }

            return listArt
                    .Where(articolo => ConditionPrice(articolo, prezzo))
                    .ToList();
        }

        public bool ConditionName(Articolo articolo, string input)
        {
             return articolo.Nome.ToLower().Contains(input.ToLower());
        }
        public bool ConditionCategory(Articolo articolo, string input)
        {
            return articolo.Categoria.ToLower().Contains(input.ToLower());
        }
        public bool ConditionPrice(Articolo articolo, double? prezzo)
        {
            return articolo.Prezzo <= prezzo;
        }
    }
}
