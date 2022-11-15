// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;

string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";

SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione);

try
{
connessioneSql.Open();
string insertQuery = "INSERT INTO libri (isbn,titolo,anno,settore,autore,numero_pagine) VALUES(@Isbn,@Titolo,@Anno,@Settore,@Autore,@Numero_pagine)";
SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);
insertCommand.Parameters.Add(new SqlParameter("@Isbn", "1234567891257"));
insertCommand.Parameters.Add(new SqlParameter("@Titolo", "Libro bruttissimo"));
insertCommand.Parameters.Add(new SqlParameter("@Anno", "01/01/2015"));
insertCommand.Parameters.Add(new SqlParameter("@Settore", "Finanza"));
insertCommand.Parameters.Add(new SqlParameter("@Autore", "Simone"));
insertCommand.Parameters.Add(new SqlParameter("@Numero_pagine", 375));
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


try
{
    connessioneSql.Open();
    string query = "SELECT * FROM libri where titolo=@Titolo";

    // creo il comando ed eseguo la query
    SqlCommand cmd = new SqlCommand(query, connessioneSql);
    cmd.Parameters.Add(new SqlParameter("@Titolo", "Libro bellissimo"));

    //reader 
    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader.GetString(1));
        Console.WriteLine(reader.GetString(2));
        Console.WriteLine(reader.GetString(4));
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
