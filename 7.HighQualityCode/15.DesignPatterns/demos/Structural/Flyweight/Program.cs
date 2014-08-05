namespace Flyweight
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        internal static void Main()
        {
            // Build a document with text
            const string Document = "AAZZBBZB";
            var chars = Document.ToCharArray();

            var factory = new CharacterFactory();

            // extrinsic state
            int pointSize = 10;

            // For each character use a flyweight object
            var list = new List<Character>();
            foreach (char c in chars)
            {
                pointSize++;
                var character = factory.GetCharacter(c);
                character.Display(pointSize);
                list.Add(character);
            }

            // Wait for user
            Console.ReadKey();
            Console.WriteLine();
            foreach (var c in list)
            {
                Console.WriteLine(c.PointSize);
            }
        }
    }
}
