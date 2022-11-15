// See https://aka.ms/new-console-template for more information

public class Libro : Documento
{
    public int NumeroPagine { get; set; }
    public Libro(string titolo, string codice, string anno, string settore, string autore, bool disponibile, int numeroPagine) : base(titolo, codice, anno, settore, autore, disponibile)
    {
        NumeroPagine = numeroPagine;
    }

    public override string ToString()
    {
        return "ISBN: " + Codice + ", Titolo: " + Titolo;
    }
}
