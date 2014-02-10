//Write a program that fills and prints a matrix of size (n, n)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FillAndPrintMatrixNxN
{
    class InitializeMatrix
    {
        static void Main(string[] args)
        {
            Console.Write("n:");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("element at[{0}][{1}]=",i,j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.Write("Choose option for output(1-4):");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                default: Console.WriteLine("Bad input!");
                    break;
                case 1: for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[j, i] > 9)
                            {
                                Console.Write(matrix[j, i] + " ");
                            }
                            else
                            {
                                Console.Write(matrix[j, i] + "  ");
                            }
                            
                        }
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    int p = 1;
                    int move = 1;
                    int num = 10;
                   for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                      
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] >= num)
                            {
                                move = move + matrix[i, j].ToString().Length - 1;
                                num = num * 10;
                            }
                            Console.Write(matrix[i,j]);
                            Console.SetCursorPosition(Console.CursorLeft-move, Console.CursorTop+p);
                        }
                      
                        Console.SetCursorPosition(Console.CursorLeft +move+1,Console.CursorTop-p);
                        p = -p;
                    }
                    break;
                case 3:
                    int count = 2 * n - 1;
                    int col = 0; //i
                    int row = 1; //j
                    int top = 1;
                    int left = 0;
                    int m = 10;
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop+n);
                    Console.Write(matrix[0,0]);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop +1);
                    for (int i = 1; i < count; i++)
                    {
                        int j;
                        if (i >= n)
                        {
                            j = (count - i) ;
                          
                        }
                        else
                        {
                            j = i + 1;
                        }
                        if (i >= n)
                        {
                            if (matrix[col, row] >= m)
                            {
                                left--;
                            }
                            Console.SetCursorPosition(Console.CursorLeft - left , Console.CursorTop - top );
                            left--;
                            top--;

                        }
                        else
                        {
                            if (Console.CursorLeft - left > 0)
                            {
                                left++;
                            }
 
                            top++;
                            if (matrix[col, row] >= m && Console.CursorLeft - left > 0)
                            {
                                left++;
                                
                            }
                            Console.SetCursorPosition(Console.CursorLeft - left, Console.CursorTop - top);
                        }
                        
                        
                        
                        while (j>0)
                        {

                                Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);

                            Console.Write(matrix[col,row]);
                            if (matrix[col, row] >= m && Console.CursorLeft > 0)
                            {
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                            }
                            else
                            {
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                            }
                            j--;
                            if (row + 1 == n)
                            {
                                col++;
                                row = 0;
                            }
                            else
                            {
                                row++;
                            }
                            
                        }

                    }
                    break;
                case 4:
                    int[,] spiral = new int[n, n];
                    int c = 0;
                    int r = 0;
                    int jay;
                    int g;
                    for (int i = 0; i <= n/2-1; i++)
            {
                for (jay = i; jay < n-i; jay++)
                {
                    spiral[i, jay] = matrix[c, r]; 
                    if (r + 1 == n)
                    {
                        c++;
                        r = 0;
                    }
                    else
                    {
                        r++;
                    }
                }
                for (int k = i+1; k <jay ; k++)
                {
                    spiral[k, jay - 1] = matrix[c, r];
                    if (r + 1 == n)
                    {
                        c++;
                        r = 0;
                    }
                    else
                    {
                        r++;
                    }
                }
                for (g = jay-1; g > i; g--)
                {
                    spiral[jay - 1, g - 1] = matrix[c, r];
                    if (r + 1 == n)
                    {
                        c++;
                        r = 0;
                    }
                    else
                    {
                        r++;
                    }
                }
                for (int t = jay-2; t >=i+1 ; t--)
                {
                    spiral[t, g] = matrix[c, r];
                    if (r + 1 == n)
                    {
                        c++;
                        r = 0;
                    }
                    else
                    {
                        r++;
                    }
                }
            }
            if (n % 2 != 0)
            {
                spiral[n / 2, n / 2] = matrix[c, r];
                if (r + 1 == n)
                {
                    c++;
                    r = 0;
                }
                else
                {
                    r++;
                }
            }

            for (int h = 0; h < n; h++)
            {
                for (int l = 0; l < n; l++)
                {
                    Console.Write("{0,4}",spiral[h,l]);
                }
                Console.WriteLine();
            }
            break;
            }
        }
    }
}
