// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;

public class Biblioteca
{
    private SqlConnection connessioneSql;

    public Biblioteca()
    {
        string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";
        connessioneSql = new SqlConnection(stringaDiConnessione);
    }

    public Libro RicercaLibro(string titolo)
    {
        try
        {
            connessioneSql.Open();
            string query = "SELECT * FROM libri where titolo=@Titolo";
            SqlCommand cmd = new SqlCommand(query, connessioneSql);
            cmd.Parameters.Add(new SqlParameter("@Titolo", titolo));
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string codice = reader.GetString(1);
                string titoloLibro = reader.GetString(2);
                string anno = Convert.ToString(reader.GetDateTime(3));
                string settore = reader.GetString(4);
                string autore = reader.GetString(5);
                int n_pagine = reader.GetInt32(6);
                return new Libro(titoloLibro, codice, anno, settore, autore, true, n_pagine);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connessioneSql.Close();
        }
        return null;
    }
    public Dvd RicercaDvd(string titolo)
    {
        try
        {
            connessioneSql.Open();
            string query = "SELECT * FROM dvd where titolo=@Titolo";
            SqlCommand cmd = new SqlCommand(query, connessioneSql);
            cmd.Parameters.Add(new SqlParameter("@Titolo", titolo));
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string codice = reader.GetString(1);
                string titoloLibro = reader.GetString(2);
                string anno = Convert.ToString(reader.GetDateTime(3));
                string settore = reader.GetString(4);
                string autore = reader.GetString(5);
                int durata = reader.GetInt32(6);
                return new Dvd(titoloLibro, codice, anno, settore, autore, true, durata);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connessioneSql.Close();
        }
        return null;
    }

    public void NuovoLibro(Libro libro)
    {
        try
        {
            connessioneSql.Open();
            string insertQuery = "INSERT INTO libri (isbn,titolo,anno,settore,autore,numero_pagine) VALUES(@Isbn,@Titolo,@Anno,@Settore,@Autore,@Numero_pagine)";
            SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);
            insertCommand.Parameters.Add(new SqlParameter("@Isbn", libro.Codice));
            insertCommand.Parameters.Add(new SqlParameter("@Titolo", libro.Titolo));
            insertCommand.Parameters.Add(new SqlParameter("@Anno", libro.Anno));
            insertCommand.Parameters.Add(new SqlParameter("@Settore", libro.Settore));
            insertCommand.Parameters.Add(new SqlParameter("@Autore", libro.Autore));
            insertCommand.Parameters.Add(new SqlParameter("@Numero_pagine", libro.NumeroPagine));
            int affectedRows = insertCommand.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

        }
        finally
        {
            connessioneSql.Close();
        }
    }
    public void NuovoDvd(Dvd dvd)
    {
        try
        {
            connessioneSql.Open();
            string insertQuery = "INSERT INTO dvd (seriale,titolo,anno,settore,autore,durata) VALUES(@Seriale,@Titolo,@Anno,@Settore,@Autore,@Durata)";
            SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);
            insertCommand.Parameters.Add(new SqlParameter("@Seriale", dvd.Codice));
            insertCommand.Parameters.Add(new SqlParameter("@Titolo", dvd.Titolo));
            insertCommand.Parameters.Add(new SqlParameter("@Anno", dvd.Anno));
            insertCommand.Parameters.Add(new SqlParameter("@Settore", dvd.Settore));
            insertCommand.Parameters.Add(new SqlParameter("@Autore", dvd.Autore));
            insertCommand.Parameters.Add(new SqlParameter("@Durata", dvd.Durata));
            int affectedRows = insertCommand.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

        }
        finally
        {
            connessioneSql.Close();
        }
    }
    public List<Libro> RaccoltaLibri()
    {
        try
        {
            List<Libro> libri = new List<Libro>();
            connessioneSql.Open();
            string query = "SELECT * FROM libri";
            SqlCommand cmd = new SqlCommand(query, connessioneSql);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string codice = reader.GetString(1);
                string titolo = reader.GetString(2);
                string anno = Convert.ToString(reader.GetDateTime(3));
                string settore = reader.GetString(4);
                string autore = reader.GetString(5);
                int n_pagine = reader.GetInt32(6);
                libri.Add(new Libro(titolo, codice, anno, settore, autore, true, n_pagine));
            }
            return libri;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connessioneSql.Close();
        }
        return null;
    }
    public List<Dvd> RaccoltaDvd()
    {
        try
        {
            List<Dvd> dvd = new List<Dvd>();
            connessioneSql.Open();
            string query = "SELECT * FROM dvd";
            SqlCommand cmd = new SqlCommand(query, connessioneSql);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string codice = reader.GetString(1);
                string titolo = reader.GetString(2);
                string anno = Convert.ToString(reader.GetDateTime(3));
                string settore = reader.GetString(4);
                string autore = reader.GetString(5);
                int durata = reader.GetInt32(6);
                dvd.Add(new Dvd(titolo, codice, anno, settore, autore, true, durata));
            }
            return dvd;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connessioneSql.Close();
        }
        return null;
    }

    public List<Prestito> ElencoPrestitiLibri() {
        try
        {
            List<Prestito> prestiti = new List<Prestito>();
            connessioneSql.Open();
            string query = "SELECT libri.isbn,libri.titolo,prestitiLibri.inizio, prestitiLibri.fine FROM prestitiLibri " +
                "INNER JOIN libri ON prestitiLibri.libro_id = libri.id";
            SqlCommand cmd = new SqlCommand(query, connessioneSql);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string isbn = reader.GetString(0);
                string titolo = reader.GetString(1);
                string inizio = Convert.ToString(reader.GetDateTime(2));
                string fine = Convert.ToString(reader.GetDateTime(3));
                prestiti.Add(new Prestito(isbn,titolo,inizio,fine));
            }
            return prestiti;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connessioneSql.Close();
        }
        return null;
    }

    public List<Prestito> ElencoPrestitiDvd()
    {
        try
        {
            List<Prestito> prestiti = new List<Prestito>();
            connessioneSql.Open();
            string query = "SELECT dvd.seriale,dvd.titolo,prestitiDvd.inizio, prestitiDvd.fine FROM prestitiDvd " +
                "INNER JOIN dvd ON prestitiDvd.dvd_id = dvd.id";
            SqlCommand cmd = new SqlCommand(query, connessioneSql);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string seriale = reader.GetString(0);
                string titolo = reader.GetString(1);
                string inizio = Convert.ToString(reader.GetDateTime(2));
                string fine = Convert.ToString(reader.GetDateTime(3));
                prestiti.Add(new Prestito(seriale, titolo, inizio, fine));
            }
            return prestiti;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connessioneSql.Close();
        }
        return null;
    }
}
