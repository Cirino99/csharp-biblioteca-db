// See https://aka.ms/new-console-template for more information

Biblioteca biblioteca = new Biblioteca();
bool esci = false;
do
{
    Console.WriteLine("Scegli:");
    Console.WriteLine("1) Aggiungi un nuovo libro");
    Console.WriteLine("2) Aggiungi un nuovo dvd");
    Console.WriteLine("3) Cerca un libro");
    Console.WriteLine("4) Cerca un dvd");
    Console.WriteLine("5) Stampa tutti i libri presenti");
    Console.WriteLine("6) Stampa tutti i dvd presenti");
    Console.WriteLine("7) Stampa tutti i prestiti dei Libri");
    Console.WriteLine("8) Stampa tutti i prestiti dei Dvd");
    Console.WriteLine("9) esci");
    string scelta = Console.ReadLine();
    switch (scelta)
    {
        case "1":
            Console.WriteLine("Inserisci isbn del libro da inserire");
            string isbn1 = Console.ReadLine();
            Console.WriteLine("Inserisci il titolo del libro da inserire");
            string titolo1 = Console.ReadLine();
            Console.WriteLine("Inserisci l'anno del libro da inserire (dd/mm/yyyy)");
            string anno1 = Console.ReadLine();
            Console.WriteLine("Inserisci il settore del libro da inserire");
            string settore1 = Console.ReadLine();
            Console.WriteLine("Inserisci l'autore del libro da inserire");
            string autore1 = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di pagine del libro da inserire");
            int n_pagine1 = Convert.ToInt32(Console.ReadLine());
            Libro libro1 = new Libro(titolo1, isbn1, anno1, settore1, autore1, true, n_pagine1);
            biblioteca.NuovoLibro(libro1);
            break;
        case "2":
            Console.WriteLine("Inserisci il seriale del dvd da inserire");
            string seriale2 = Console.ReadLine();
            Console.WriteLine("Inserisci il titolo del dvd da inserire");
            string titolo2 = Console.ReadLine();
            Console.WriteLine("Inserisci l'anno del dvd da inserire (dd/mm/yyyy)");
            string anno2 = Console.ReadLine();
            Console.WriteLine("Inserisci il settore del dvd da inserire");
            string settore2 = Console.ReadLine();
            Console.WriteLine("Inserisci l'autore del dvd da inserire");
            string autore2 = Console.ReadLine();
            Console.WriteLine("Inserisci la durata del dvd da inserire");
            int durata2 = Convert.ToInt32(Console.ReadLine());
            Dvd dvd2 = new Dvd(titolo2, seriale2, anno2, settore2, autore2, true, durata2);
            biblioteca.NuovoDvd(dvd2);
            break;
        case "3":
            Console.WriteLine("inserisci il titolo del libro da cercare");
            string titolo3 = Console.ReadLine();
            Libro libro3 = biblioteca.RicercaLibro(titolo3);
            if (libro3 != null)
                Console.WriteLine(libro3.ToString());
            break;
        case "4":
            Console.WriteLine("inserisci il titolo del dvd da cercare");
            string titolo4 = Console.ReadLine();
            Dvd dvd4 = biblioteca.RicercaDvd(titolo4);
            if (dvd4 != null)
                Console.WriteLine(dvd4.ToString());
            break;
        case "5":
            List<Libro> libri6 = biblioteca.RaccoltaLibri();
            foreach (Libro libro in libri6)
                Console.WriteLine(libro.ToString());
            break;
        case "6":
            List<Dvd> dvd6 = biblioteca.RaccoltaDvd();
            foreach (Dvd dvd in dvd6)
                Console.WriteLine(dvd.ToString());
            break;
        case "7":
            List<Prestito> prestiti7 = biblioteca.ElencoPrestitiLibri();
            foreach (Prestito prestito in prestiti7)
                Console.WriteLine(prestito.ToString());
            break;
        case "8":
            List<Prestito> prestiti8 = biblioteca.ElencoPrestitiDvd();
            foreach (Prestito prestito in prestiti8)
                Console.WriteLine(prestito.ToString());
            break;
        default:
            esci = true;
            break;
    }
} while (!esci);