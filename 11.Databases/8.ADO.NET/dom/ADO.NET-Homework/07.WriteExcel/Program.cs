using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.WriteExcel
{
    using System.Data.OleDb;

    class Program
    {
        static void Main(string[] args)
        {
            var con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\file.xlsx; Extended Properties = \"Excel 12.0 Xml; HDR = NO; IMEX = 2\"");

            con.Open();
            using (con)
            {
                var dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"];
                var writeCommand = new OleDbCommand("INSERT INTO " + "[" + sheetName + "]" +" VALUES(\"TestName\", 9999)", con);
                writeCommand.ExecuteNonQuery();

                var readCommand = new OleDbCommand("SELECT * FROM " + "[" + sheetName + "]", con);
                var reader = readCommand.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    Console.WriteLine("{0} - {1}", (string)reader[0], (double)reader[1]);

                }
            }
        }
    }
}
