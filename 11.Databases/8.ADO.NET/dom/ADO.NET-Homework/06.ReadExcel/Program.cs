using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReadExcel
{
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\file.xlsx; Extended Properties = \"Excel 12.0 Xml; HDR = YES; IMEX = 2\"");

            con.Open();
            using (con)
            {
                var dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"];
                var command = new OleDbCommand("SELECT * FROM " + "["+sheetName+"]", con);
                var reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    Console.WriteLine("{0} - {1}", (string)reader[0], (double)reader[1]);

                }
            }
            
        }
    }
}
