//Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.EncodingOrDecoding
{
    class EorD
    {
        static string EncodeorDecode(string str, string key)
        {
            StringBuilder b = new StringBuilder();
            int encoded;
            int keyIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                keyIndex = i % key.Length;
                encoded = str[i] ^ key[keyIndex];
                b.Append((char)encoded);
            }
            return b.ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("The string to encode/decode: ");
            string str = Console.ReadLine();
            Console.Write("Key: ");
            string key = Console.ReadLine();
            Console.WriteLine(EncodeorDecode(str, key));

        }
    }
}
