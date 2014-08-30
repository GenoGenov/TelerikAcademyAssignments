namespace _09.MySQLBooks
{
    using System;
    using System.Text;

    using MySql.Data.MySqlClient;

    internal class Program
    {
        public static void AddBook(string pass, string Title, string authorName, DateTime publish, string ISBN)
        {
            string connectionStr = "Server=localhost;Database=Books;Uid=root;Pwd=" + pass + ";";
            MySqlConnection connection = new MySqlConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                var addAuthorCommand = new MySqlCommand("INSERT INTO author(Name) VALUES(@name)", connection);
                addAuthorCommand.Parameters.AddWithValue("@name", authorName);
                addAuthorCommand.ExecuteNonQuery();

                var getAuthIDCommand = new MySqlCommand("SELECT idAuthor FROM author WHERE Name=" + "@name", connection);
                getAuthIDCommand.Parameters.AddWithValue("@name", authorName);

                var authID = (int)getAuthIDCommand.ExecuteScalar();

                var addBookCommand =
                    new MySqlCommand(
                        "INSERT INTO book(Name,date,ISBN,AuthorID) VALUES(@title,@publish,@ISBN,@authID)",
                        connection);
                addBookCommand.Parameters.AddWithValue("@title", Title);
                addBookCommand.Parameters.AddWithValue("@publish", publish);
                addBookCommand.Parameters.AddWithValue("@ISBN", ISBN);
                addBookCommand.Parameters.AddWithValue("@authID", authID);
                addBookCommand.ExecuteNonQuery();
            }
        }

        public static void ListAllBooks(string pass)
        {
            var result = new StringBuilder();

            string connectionStr = "Server=localhost;Database=Books;Uid=root;Pwd=" + pass + ";";
            var connection = new MySqlConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                var getBooks =
                    new MySqlCommand(
                        "SELECT b.idBook, b.Name, a.Name FROM book b INNER JOIN author a ON b.AuthorID = a.idAuthor",
                        connection);
                var reader = getBooks.ExecuteReader();
                result.AppendLine("All books:");
                while (reader.Read())
                {
                    result.AppendFormat("{0} - {1} - by {2}\n", (int)reader[0], (string)reader[1], (string)reader[2]);
                }
            }
            Console.WriteLine(result.ToString());
        }

        public static string FindBookByName(string pass, string name)
        {
            var result = new StringBuilder();

            string connectionStr = "Server=localhost;Database=Books;Uid=root;Pwd=" + pass + ";";
            MySqlConnection connection = new MySqlConnection(connectionStr);
            connection.Open();

            var getBooks =
                new MySqlCommand(
                    "SELECT b.idBook, b.Name, a.Name FROM book b INNER JOIN author a ON b.AuthorID = a.idAuthor WHERE b.Name="
                    + "\"" + name + "\"",
                    connection);
            var reader = getBooks.ExecuteReader();

            while (reader.Read())
            {
                result.AppendFormat("{0} - {1} - by {2}\n", (int)reader[0], (string)reader[1], (string)reader[2]);
            }

            return result.ToString();
        }

        private static void Main(string[] args)
        {
            Console.Write("Enter pass: ");
            string pass = Console.ReadLine();

            AddBook(pass, "how to live with a huge penis", "Hugh H.", DateTime.Now, "35СМ.");
            AddBook(pass, "Women psychology explained", "Nobody", DateTime.Now, "123F*CKLOGIC5673");
            ListAllBooks(pass);

            Console.WriteLine(FindBookByName(pass, "how to live with a huge penis"));
        }
    }
}