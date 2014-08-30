using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GetProducts
{
    using System.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Server=DIRTYBOOK; Database=NORTHWND;Integrated Security=true");
            con.Open();
            using (con)
            {
                SqlCommand command = new SqlCommand(
                "SELECT c.CategoryName, p.ProductName FROM Products p INNER JOIN Categories c ON c.CategoryID=p.CategoryID GROUP BY c.CategoryName, p.ProductName ", con);
                var reader = command.ExecuteReader();
                var dict = new Dictionary<string, string>();
                while (reader.Read())
                {
                    var name = (string)reader[0];
                    if (dict.ContainsKey(name))
                    {
                        dict[name] += ','+(string)reader[1];
                    }
                    else
                    {
                        dict[name] = (string)reader[1];
                    }
                    
                }
                foreach (var cat in dict)
                {
                    Console.WriteLine("{0} - {1}",cat.Key, cat.Value);
                    Console.WriteLine();
                }


            }
        }
    }
}
