// See https://aka.ms/new-console-template for more information
using System;
using System.Data.SqlClient;


Console.WriteLine("Question 02 - Lab 04");
string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\fmell\\OneDrive\\Centenial Progress\\FALL 23\\Programing 3\\Lab4\\Template\\Q2Lab4\\Database\\Books.mdf\";Integrated Security=True";

// Invokes methods
Question2_1();
Question2_2();
Question2_3();

//1.Get a list of all the titles and the authors who wrote them. Sort the results by title. [2 marks]
void Question2_1()
{
    string query = @"SELECT t.Title, a.FirstName, a.LastName
                     FROM Titles t
                     JOIN AuthorISBN ai ON t.ISBN = ai.ISBN
                     JOIN Authors a ON ai.AuthorID = a.AuthorID
                     ORDER BY t.Title ASC;";

    Console.WriteLine($"Question 2_1:");
    Console.WriteLine("List of all the titles and the authors who wrote them. Sort the results by title");
    Console.WriteLine();
    try
    { 
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string title = reader["Title"].ToString();
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();

                Console.WriteLine($"TIttle: {title} || by {firstName} {lastName}");
            }
        }
    }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred when executing the query: {ex.Message}");
    }
    Console.WriteLine($"\n");
    Console.ReadLine();
}

//2.Get a list of all the titles and the authors who wrote them. Sort the results by title.  Each title sort the authors alphabetically by last name, then first name[4 marks]
void Question2_2()
{
    string query = @"SELECT t.Title, a.FirstName, a.LastName
                     FROM Titles t
                     JOIN AuthorISBN ai ON t.ISBN = ai.ISBN
                     JOIN Authors a ON ai.AuthorID = a.AuthorID
                     ORDER BY t.Title ASC, a.LastName ASC, a.FirstName ASC;";

    
    Console.WriteLine($"Question 2.2:");
    Console.WriteLine("List of all the titles and the authors who wrote them. Sort the results by title.  Each title sort the authors alphabetically by last name, then first name");
    Console.WriteLine();
    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string title = reader["Title"].ToString();
                    string firstName = reader["FirstName"].ToString();
                    string lastName = reader["LastName"].ToString();

                    Console.WriteLine($"Title: {title} || by {lastName}, {firstName}");
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Se produjo un error al ejecutar la consulta: {ex.Message}");
    }
    Console.WriteLine($"\n");
    Console.ReadLine();
}

//3.Get a list of all the authors grouped by title, sorted by title; for a given title sort the author names alphabetically by last name then first name.[4 marks]
    void Question2_3()
    {
        string query = @"SELECT t.Title, a.FirstName, a.LastName
                     FROM Titles t
                     JOIN AuthorISBN ai ON t.ISBN = ai.ISBN
                     JOIN Authors a ON ai.AuthorID = a.AuthorID
                     GROUP BY t.Title, a.FirstName, a.LastName
                     ORDER BY t.Title ASC, a.LastName ASC, a.FirstName ASC;";

    Console.WriteLine("List of all the authors grouped by title, sorted by title");
    Console.WriteLine($"Question 2_3:");
        Console.WriteLine();
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    string currentTitle = "";
                    while (reader.Read())
                    {
                        string title = reader["Title"].ToString();
                        string firstName = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();

                        if (title != currentTitle)
                        {
                            Console.WriteLine($"\n{title}:");
                            currentTitle = title;
                        }

                        Console.WriteLine($"\t{lastName}, {firstName}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se produjo un error al ejecutar la consulta: {ex.Message}");
        }
        Console.WriteLine($"\n");
        Console.ReadLine();
    }
