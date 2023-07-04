

using Esercizio_liveCoding.Model;

namespace Esercizio_liveCoding
{
    internal static class Helper
    {

        public static List<Articolo> FilterRequest(string msg, Func<string?, List<Articolo>> filterFunction)
        {
            Console.WriteLine(msg);
            string? input = Console.ReadLine();
            return filterFunction(input);
        }


    }
}
