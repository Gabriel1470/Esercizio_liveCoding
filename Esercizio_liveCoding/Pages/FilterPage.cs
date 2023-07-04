
using Esercizio_liveCoding.Exceptions;
using Esercizio_liveCoding.Model;

namespace Esercizio_liveCoding.Pages
{
    internal class FilterPage
    {

        private Supermercato _supermercato;

        public FilterPage(Supermercato supermercato)
        {
            _supermercato = supermercato;
        }

        public void View()
        {
            Console.WriteLine("Premi 1 per filtrare il nome");
            Console.WriteLine("Premi 2 per filtrare la categoria");
            Console.WriteLine("Premi 3 per filtrare la prezzo");
            string? input = Console.ReadLine();

            List<Articolo>? filteredList = null;

            switch (input)
            {
                case "1":
                    filteredList = Helper
                        .FilterRequest("Scegli nome articolo", (value) => _supermercato.FilterByName(value));
                    break;

                case "2":
                    filteredList = Helper
                        .FilterRequest("Scegli categoria articolo", (value) => _supermercato.FilterByCategory(value));
                    break;

                case "3":
                    filteredList = Helper
                        .FilterRequest("Scegli prezzo articolo", (value) => _supermercato.FilterByPrice(double.Parse(value)));
                    break;

                default:
                    throw new InvalidInputException();
            }

            filteredList.ForEach(Console.WriteLine);
        }
    }
}
