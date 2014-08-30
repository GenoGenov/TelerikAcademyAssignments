using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.FindProductsContainingString
{
    using System.Data.SqlClient;

    internal class Program
    {
        private static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Server=DIRTYBOOK; Database=NORTHWND;Integrated Security=true");
            con.Open();
            using (con)
            {
                
                Console.Write("Search string:");
                var str = Console.ReadLine();
                var strEscaped = string.Join("",str.TakeWhile(x => x != '%' && x != '_' && x != '\'' && x != '"'));
                SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE ProductName LIKE @str", con);
                strEscaped = "%" + strEscaped + "%";
                command.Parameters.AddWithValue("@str", strEscaped);
                Console.WriteLine(command.CommandText.Replace("@str",strEscaped));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0}. {1}", (int)reader[0], (string)reader[1]);

                }
            }
        }
    }
}
