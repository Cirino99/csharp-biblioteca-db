// See https://aka.ms/new-console-template for more information

public class Dvd : Documento
{
    public int Durata { get; set; } //espressa in minuti
    public Dvd(string titolo, string codice, string anno, string settore, string autore, bool disponibile, int durata) : base(titolo, codice, anno, settore, autore, disponibile)
    {
        Durata = durata;
    }

    public override string ToString()
    {
        return "Numero Seriale: " + Codice + ", Titolo: " + Titolo;
    }
}
