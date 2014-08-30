using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GetAllCategoties
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
                "SELECT * FROM Categories", con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var name = (string)reader[1];
                    Console.WriteLine("{0}. {1} - {2}", (int)reader[0],(string)reader[1],(string)reader[2]);
                }
                

            }
        }
    }
}
