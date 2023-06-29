//Abbiamo un supermercato  che avra degli oggetti in vendita divisi in categoria, nome e prezzo.
//Sarà possibile vedere l'elenco e filtrarlo per categoria e fascia di prezzo.
//Avremo un carrello dove inserire gli articoli. Dove l'ultimo articolo del carrello sarà il primo ad andare in cassa.

//Come primo step andiamo a definire la classe Articolo con le sue proprietà

using Esercizio_liveCoding;
using System.ComponentModel.Design;

List<Articolo> listArt = new List<Articolo>()
{
    new Articolo("latticini","Latte",1.20),
    new Articolo("colazione","Biscotti",1.50),
    new Articolo("surgelati","Gelato",1.70),
    new Articolo("latticini","Ricotta",1.00),
    new Articolo("animali","Croccantini",2.00),
    new Articolo("latticini","Parmiggiani",1.99)
};

Stack<Articolo> carrello = new Stack<Articolo>();

while (true)
{

    Console.WriteLine("Premi 1 per visualizzare la lista");
    Console.WriteLine("Premi 2 per filtrare la lista");
    Console.WriteLine("Premi 3 per aggiungere al carrello");
    Console.WriteLine("Premi 4 per andare in cassa");

    string input = Console.ReadLine();

    if (input == "1")
    {
        //listArt.ForEach(articolo => Console.WriteLine(articolo));
        foreach (var articolo in listArt)
        {
            Console.WriteLine(articolo);
        }
    }
    else if (input == "2")
    {

        Console.WriteLine("Premi 1 per filtrare il nome");
        Console.WriteLine("Premi 2 per filtrare la categoria");
        Console.WriteLine("Premi 3 per filtrare la prezzo");
        Console.WriteLine("Premi 4 per terminare");
        input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("Scegli nome articolo");
                input = Console.ReadLine();
                foreach (var articolo in listArt)
                {
                    if (articolo.Nome.ToLower().Contains(input.ToLower()))
                    {
                        Console.WriteLine(articolo);
                    }
                }
                break;
            case "2":
                Console.WriteLine("Scegli categoria articolo");
                input = Console.ReadLine();
                foreach (var articolo in listArt)
                {
                    if (articolo.Categoria.ToLower().Contains(input.ToLower()))
                    {
                        Console.WriteLine(articolo);
                    }
                }
                break;

            case "3":
                Console.WriteLine("Scegli prezzo articolo");
                double prezzo = double.Parse(Console.ReadLine());
                foreach (var articolo in listArt)
                {
                    if (articolo.Prezzo <= prezzo)
                    {
                        Console.WriteLine(articolo);
                    }
                }
                break;

            case "4":

                break;

            default:
                Console.WriteLine("Error insert");
                break;

        }

    }
    else if (input == "3")
    {
        Console.WriteLine("Inserisci nome articolo");
        input = Console.ReadLine();
        foreach (var articolo in listArt)
        {
            if (articolo.Nome == input)
            {
                carrello.Push(articolo);
                Console.WriteLine("Articolo aggiunto");
                break;
            }

        }

    }
    
    else if(input == "4")
    {
        List<string> scontrino = new List<string>();
        double tot = 0;
        while(carrello.Count > 0)
        {
            await Task.Delay(3000);
            var rimosso = carrello.Pop();
            scontrino.Add($"{rimosso.Nome}\t\t\t\t{rimosso.Prezzo}");
            tot += rimosso.Prezzo;
            Console.WriteLine("BEEP");
            Console.Beep();

        }
        foreach(var x in scontrino)
        {
            Console.WriteLine(x);
        }
        Console.WriteLine("____________");
        Console.WriteLine($"Totale\t\t\t\t{tot}" );
        Environment.Exit(0);
    }
}
