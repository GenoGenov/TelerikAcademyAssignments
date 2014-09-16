namespace _3.SupermarketQueue
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
            var result = new StringBuilder();
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
                        result.AppendLine("OK");
                        break;
                    case "Insert":
                        var index = int.Parse(commandParts[1]);
                        if (index > queue.Count)
                        {
                            result.AppendLine("Error");
                            break;
                        }
                        result.AppendLine("OK");
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
                            result.AppendLine("0"); break;
                        }
                        result.AppendLine(names[commandParts[1]].ToString());
                        break;
                    case "Serve":
                        var count = int.Parse(commandParts[1]);
                        if (count > queue.Count)
                        {
                            result.AppendLine("Error");
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
                        result.AppendLine(served.ToString().Trim());
                        break;
                }

                commandParts = Console.ReadLine().Split(' ');
            }

            Console.WriteLine(result.ToString());
        }
    }
}