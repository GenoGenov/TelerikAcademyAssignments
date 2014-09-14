namespace _03.SupermarketQueue
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Wintellect.PowerCollections;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var queue = new BigList<string>();
            var names = new Dictionary<string, int>();

            var commandParts = Console.ReadLine().Split(' ');

            while (commandParts[0] != "End")
            {
                switch (commandParts[0])
                {
                    case "Append":
                        queue.Add(commandParts[1]);
                        if (!names.ContainsKey(commandParts[1]))
                        {
                            names[commandParts[1]] = 0;
                        }
                        names[commandParts[1]]++;
                        Console.WriteLine("OK");
                        break;
                    case "Insert":
                        var index = int.Parse(commandParts[1]);
                        if (index > queue.Count)
                        {
                            Console.WriteLine("Error");
                            break;
                        }
                        Console.WriteLine("OK");
                         if (!names.ContainsKey(commandParts[2]))
                        {
                            names[commandParts[2]] = 0;
                        }
                        names[commandParts[2]]++;
                        if (index == queue.Count)
                        {
                            queue.Add(commandParts[2]);
                            break;
                        }
                        queue.Insert(index, commandParts[2]);
                        break;

                    case "Find":
                        if (!names.ContainsKey(commandParts[1]))
                        {
                            Console.WriteLine(0);break;
                        }
                        Console.WriteLine(names[commandParts[1]]);
                        break;
                    case "Serve":
                        var count = int.Parse(commandParts[1]);
                        if (count > queue.Count)
                        {
                            Console.WriteLine("Error");
                            break;
                        }
                        var served = new StringBuilder();
                        for (int i = 0; i < count; i++)
                        {
                            var person = queue[0];
                            names[person]--;
                            served.AppendFormat(" {0}", person);
                            queue.RemoveAt(0);
                        }
                        Console.WriteLine(served.ToString().Trim());
                        break;
                }

                commandParts = Console.ReadLine().Split(' ');
            }
        }
    }
}