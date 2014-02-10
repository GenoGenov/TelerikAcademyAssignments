using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public static class PathStorage
    {
        #region Private methods

        private static int Parse(ref int start, string str)
        {
            int digit;
            bool flag = false;
            var num = new StringBuilder();

            while (int.TryParse(str[start].ToString(), out digit))
            {
                num.Insert(0, digit);
                start++;
                flag = true;
            }

            if (flag)
            {
                start++;
                return int.Parse(num.ToString());
            }


            throw new InvalidDataException();
        }

        private static Point3D TryParse(string str)
        {
            try
            {
                int i = 1;
                int x = Parse(ref i, str);
                int y = Parse(ref i, str);
                int z = Parse(ref i, str);

                return new Point3D(x, y, z);
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        #endregion

        #region Public Methods

        public static void SavePath(Path path, string filename)
        {
            var writer = new StreamWriter(filename);

            for (int i = 0; i < path.Count; i++)
            {
                writer.WriteLine(path[i].ToString());
            }
            writer.Close();
        }


        public static Path LoadPath(string filename)
        {
            Path path = new Path();
            try
            {
                var reader = new StreamReader(filename);

                string line = reader.ReadLine();

                while (line != null)
                {
                    path.Add(TryParse(line));

                    line = reader.ReadLine();
                }
                return path;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File could not be found");
                return null;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Parsing from file failed!");
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error");
                return null;
            }
        }

        #endregion
    }
}