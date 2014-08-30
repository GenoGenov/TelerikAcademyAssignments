namespace _01.CategoriesCount
{
    using System;
    using System.Data.SqlClient;

    internal class Program
    {
        private static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Server=DIRTYBOOK; Database=NORTHWND;Integrated Security=true");
            con.Open();
            using (con)
            {
                SqlCommand command = new SqlCommand(
                "SELECT COUNT(*) FROM Categories", con);
                var numberOfCategories = (int)command.ExecuteScalar();
                Console.WriteLine("Number of categories: {0}",numberOfCategories);

            }
        }
    }
}