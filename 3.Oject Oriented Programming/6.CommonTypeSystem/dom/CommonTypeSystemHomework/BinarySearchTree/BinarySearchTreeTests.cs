using System;
using System.Linq;

namespace BinarySearchTree
{
    public class BinarySearchTreeTests
    {
        private static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Add(4);
            tree.Add(2);
            tree.Add(8);
            tree.Add(9);

            Console.WriteLine(tree);
            Console.WriteLine();
            var tree2 = tree.Clone();
            tree.Add(12);

            Console.WriteLine();
            Console.WriteLine(tree);
            Console.WriteLine();

            Console.WriteLine(tree2);
        }
    }
}