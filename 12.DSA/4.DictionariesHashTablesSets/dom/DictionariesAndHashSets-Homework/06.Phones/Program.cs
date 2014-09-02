namespace _06.Phones
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class Program
    {
        private static Phonebook book = new Phonebook(ParseEntries());

        private static void Main(string[] args)
        {
            ExecuteCommands();
        }

        private static List<PhonebookEntry> ParseEntries()
        {
            var reader = new StreamReader("..//..//Records.txt");
            var result = new List<PhonebookEntry>();
            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] data =
                        line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                    result.Add(
                        new PhonebookEntry(
                            data[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries),
                            data[1],
                            data[2]));
                    line = reader.ReadLine();
                }
            }
            return result;
        }

        private static void ExecuteCommands()
        {
            var reader = new StreamReader("..//..//Commands.txt");
            string line = reader.ReadLine();
            using (reader)
            {
                while (line != null)
                {
                    string[] data =
                        line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

                    var commandName = data[0];
                    if (commandName.ToLower() == "find")
                    {
                        Console.WriteLine(
                            "The command 'find' with parameters {0} returned the following results:",
                            data.Length == 3 ? string.Join(",", new[] { data[1], data[2] }) : data[1]);
                        if (data.Length == 3)
                        {
                            var result = book.Find(data[1], data[2]);
                            Console.WriteLine(string.Join("\n", result));
                        }
                        else
                        {
                            Console.WriteLine(string.Join("\n", book.Find(data[1])));
                        }
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }
}