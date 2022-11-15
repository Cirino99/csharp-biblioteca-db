// See https://aka.ms/new-console-template for more information

public class Documento
{
    public string Codice { get; set; }
    public string Titolo { get; set; }
    public string Anno { get; set; }
    public string Settore { get; set; }
    public bool Disponibile { get; set; }
    public string Autore { get; set; }

    public Documento(string titolo, string codice, string anno, string settore, string autore, bool disponibile)
    {
        Titolo = titolo;
        Codice = codice;
        Anno = anno;
        Settore = settore;
        Autore = autore;
        Disponibile = disponibile;
    }

    public override string ToString()
    {
        return "Codice: " + Codice + ", Titolo: " + Titolo;
    }
}
