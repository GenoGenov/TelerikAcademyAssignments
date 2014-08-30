using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AddProduct
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
                SqlCommand cmd = new SqlCommand("INSERT INTO Products " +
                "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock) VALUES " +
                "(@name, @sID, @cID, @quantity,@price,@stock)", con);
                cmd.Parameters.AddWithValue("@name", "koza");
                cmd.Parameters.AddWithValue("@sID", 1);
                cmd.Parameters.AddWithValue("@cID", 1);
                cmd.Parameters.AddWithValue("@quantity", 5);
                cmd.Parameters.AddWithValue("@price", 200);
                cmd.Parameters.AddWithValue("@stock", 2000);
                cmd.ExecuteNonQuery();

            }
        }
    }
}
