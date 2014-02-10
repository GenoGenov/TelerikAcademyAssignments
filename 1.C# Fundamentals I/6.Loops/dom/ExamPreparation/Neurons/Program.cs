using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurons
{
    class Program
    {
        static void Main(string[] args)
        {
            long input=long.Parse(Console.ReadLine());
            List<string> rows=new List<string>();
            string row;
            bool flag = false;
            while (input != -1)
            {
                char[] neuronFiller = Convert.ToString(input, 2).PadLeft(32,'0').ToCharArray();
                for (int i = 0; i < neuronFiller.Length; i++)
                {
                    if (neuronFiller[i] == '1' && i<31 && neuronFiller[i+1]!='1')
                    {
                        for (int h = i+1; h < 32; h++)
                        {
                            if (neuronFiller[h] == '1')
                            {
                                flag = true; break;
                            }
                        }
                        if (flag)
                        {
                            neuronFiller[i] = '0';
                            int j = i + 1;
                            while (j < 32 && neuronFiller[j] != '1')
                            {
                                neuronFiller[j] = '1';
                                j++;
                            }
                            if (j < 32)
                            {
                                for (int g = j; g < 32; g++)
                                {
                                    neuronFiller[g] = '0';
                                }    
                            }
                            break;
                        }
                        else
                        {
                            neuronFiller[i]='0';
                        }
                    }
                    else if (neuronFiller[i] == '1')
                    {
                        neuronFiller[i] = '0';
                    }
                }
                row = new string(neuronFiller);
                rows.Add(row);
                input = long.Parse(Console.ReadLine());
                flag = false;
            }
            //for (int i = 0; i < rows.Count; i++)
            //{
            //    Console.WriteLine(rows.ElementAt(i));
            //}
            for (int i = 0; i < rows.Count; i++)
            {
                long num = Convert.ToInt64(rows.ElementAt(i), 2);
                Console.WriteLine(num);
            }
        }
    }
}
