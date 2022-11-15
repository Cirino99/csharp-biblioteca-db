// See https://aka.ms/new-console-template for more information

public class Prestito
{
    public string Codice { get; private set; }
    public string Titolo { get; private set; }
    public string Inizio { get; private set; }
    public string Fine { get; private set; }

    public Prestito(string codice, string titolo, string inizio, string fine)
    {
        Codice = codice;
        Titolo = titolo;
        Inizio = inizio;
        Fine = fine;
    }

    public override string ToString()
    {
        return Codice + " - " + Titolo + " - " + Inizio + " - " + Fine;
    }
}
