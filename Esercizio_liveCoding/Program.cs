
//Abbiamo un supermercato  che avra degli oggetti in vendita divisi in categoria, nome e prezzo.
//Sarà possibile vedere l'elenco e filtrarlo per categoria e fascia di prezzo.
//Avremo un carrello dove inserire gli articoli. Dove l'ultimo articolo del carrello sarà il primo ad andare in cassa.

//Come primo step andiamo a definire la classe Articolo con le sue proprietà

using Esercizio_liveCoding;
using Esercizio_liveCoding.Exceptions;
using Esercizio_liveCoding.Model;
using Esercizio_liveCoding.Pages;

var _supermercato = new Supermercato();
Stack<Articolo> carrello = new Stack<Articolo>();

while (true)
{
    try
    {
        Console.WriteLine("Premi 1 per visualizzare la lista");
        Console.WriteLine("Premi 2 per filtrare la lista");
        Console.WriteLine("Premi 3 per aggiungere al carrello");
        Console.WriteLine("Premi 4 per andare in cassa");

        string input = Console.ReadLine();

        if (input == "1")
        {
            _supermercato.GetArticoli().ForEach(Console.WriteLine);
        }
        else if (input == "2")
        {
            new FilterPage(_supermercato).View();
        }
        else if (input == "3")
        {
            Console.WriteLine("Inserisci nome articolo");
            input = Console.ReadLine();

            var articolo = _supermercato.GetArticoli()
                            .Where(articolo => articolo.Nome == input)
                            .FirstOrDefault();

            if (articolo == null)
            {
                Console.WriteLine("Articolo non trovato");
                continue;
            }

            carrello.Push(articolo);
            Console.WriteLine("Articolo aggiunto");
        }

        else if (input == "4")
        {
            List<string> scontrino = new List<string>();
            double tot = 0;
            while (carrello.Count > 0)
            {
                await Task.Delay(3000);
                var rimosso = carrello.Pop();
                scontrino.Add($"{rimosso.Nome}\t\t\t\t{rimosso.Prezzo}");
                tot += rimosso.Prezzo;
                Console.WriteLine("BEEP");
                Console.Beep();

            }
            foreach (var x in scontrino)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("____________");
            Console.WriteLine($"Totale\t\t\t\t{tot}");
            Environment.Exit(0);
        }
    }
    catch (InvalidInputException e)
    {
        Console.WriteLine(e.Message);
    }
    catch (Exception e)
    {
        Console.WriteLine("Si è verificato un errore");
    }
}