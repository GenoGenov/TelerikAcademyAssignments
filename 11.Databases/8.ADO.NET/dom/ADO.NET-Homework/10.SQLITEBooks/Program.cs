namespace _09.MySQLBooks
{
    using System;
    using System.Text;

    using System.Data.SQLite;

    internal class Program
    {
        public static void AddBook(string Title, string authorName, DateTime publish, string ISBN)
        {
            string connectionStr = "Data Source=..\\..\\book.db;Version=3;";
            var connection = new SQLiteConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                var addAuthorCommand = new SQLiteCommand("INSERT INTO author(Name) VALUES(@name)", connection);
                addAuthorCommand.Parameters.AddWithValue("@name", authorName);
                addAuthorCommand.ExecuteNonQuery();

                var getAuthIDCommand = new SQLiteCommand("SELECT idAuthor FROM author WHERE Name=" + "@name", connection);
                getAuthIDCommand.Parameters.AddWithValue("@name", authorName);

                var authID = getAuthIDCommand.ExecuteScalar();

                var addBookCommand =
                    new SQLiteCommand(
                        "INSERT INTO book(Name,date,ISBN,AuthorID) VALUES(@title,@publish,@ISBN,@authID)",
                        connection);
                addBookCommand.Parameters.AddWithValue("@title", Title);
                addBookCommand.Parameters.AddWithValue("@publish", publish);
                addBookCommand.Parameters.AddWithValue("@ISBN", ISBN);
                addBookCommand.Parameters.AddWithValue("@authID", authID);
                addBookCommand.ExecuteNonQuery();
            }
        }

        public static void ListAllBooks()
        {
            var result = new StringBuilder();

            string connectionStr = "Data Source=..\\..\\book.db;Version=3;";
            var connection = new SQLiteConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                var getBooks =
                    new SQLiteCommand(
                        "SELECT b.idBook, b.Name, a.Name FROM book b INNER JOIN author a ON b.AuthorID = a.idAuthor",
                        connection);
                var reader = getBooks.ExecuteReader();
                result.AppendLine("All books:");
                while (reader.Read())
                {
                    result.AppendFormat("{0} - {1} - by {2}\n", reader[0], (string)reader[1], (string)reader[2]);
                }
            }
            Console.WriteLine(result.ToString());
        }

        public static string FindBookByName(string name)
        {
            var result = new StringBuilder();

            const string ConnectionStr = "Data Source=..\\..\\book.db;Version=3;";
            var connection = new SQLiteConnection(ConnectionStr);
            connection.Open();

            var getBooks =
                new SQLiteCommand(
                    "SELECT b.idBook, b.Name, a.Name FROM book b INNER JOIN author a ON b.AuthorID = a.idAuthor WHERE b.Name="
                    + "\"" + name + "\"",
                    connection);
            var reader = getBooks.ExecuteReader();

            while (reader.Read())
            {
                result.AppendFormat("{0} - {1} - by {2}\n", reader[0], (string)reader[1], (string)reader[2]);
            }

            return result.ToString();
        }

        private static void Main(string[] args)
        {

            //AddBook(pass, "how to live with a huge penis", "Hugh H.", DateTime.Now, "35СМ.");
            //AddBook(pass, "Women psychology explained", "Nobody", DateTime.Now, "123F*CKLOGIC5673");
            ListAllBooks();

            Console.WriteLine(FindBookByName("how to live with a huge penis"));
        }
    }
}