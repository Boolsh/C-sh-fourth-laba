using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace шарпы_4_лаба
{
    internal class Program
    {
        static void fill_matrix(int size, int[,] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    arr[i, j] = rnd.Next(-10, 10);
        }
        static void print_matrix(int size, int[,] arr)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        static void special_print_row(int size, int[] arr)
        {
            if (arr[0] == 0 && arr[1] == 0)
                Console.WriteLine("Нет локальных максимумов");
            else
            {                
                for (int i = 0;i < size; i++)
                {
                    if (i > 0 && arr[i] == 0)
                        break;
                    else Console.Write(arr[i] + " ");

                }
                    Console.WriteLine();
            }
        }

        static int[,] create_matrix(out int n)
        {
            Console.Write("Введите размер n матрицы nxn: ");

            
            int.TryParse(Console.ReadLine(), out n);

            int[] row = new int[n];
            int[,] arr = new int[n, n];

            fill_matrix(n, arr);
            return arr;
        }
        static int[] task(int number, int size,ref int[,] mat)
        {
            int[] result = new int[size];

            int curr_ind = 0; 

            for (int i = 1; i < size-1; ++i)
            {
                if (mat[number, i] > mat[number, i+1] && mat[number, i] > mat[number, i - 1])
                    result[curr_ind++] = 1 + i++;
            }
            return result;
        }
        
        static void Main(string[] args)
        {
            int size;
            int [,] mat = create_matrix(out size);


            Console.WriteLine("\nПроизвольно заданная матрица: ");
            print_matrix(size, mat);

            Console.WriteLine("\nПозиции локальных максимумов для каждой строки: ");

            for (int i = 0; i < size; ++i)
            {
                Console.Write($"{i+1}) ");
                special_print_row(size, task(i, size, ref mat));
            }

            Console.WriteLine();


        }
    }
}
