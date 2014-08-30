using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace _05.GetImages
{
    using System.Collections;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Server=DIRTYBOOK; Database=NORTHWND;Integrated Security=true");
            con.Open();

            SqlCommand command = new SqlCommand(
                "SELECT Picture FROM Categories", con);
            var reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                var pic = (byte[])reader["Picture"];
                var file = new FileStream("..//..//img"+i+".jpg",FileMode.Create);
                using (file)
                {
                    file.Write(pic, 78, pic.Length-78);
                }
                i++;

            }
        }
    }
}
