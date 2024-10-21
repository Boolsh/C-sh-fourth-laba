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
        static void special_print_row(int size, int[] arr, int size_arr)
        {
            if (arr[0] == 0 && arr[1] == 0)
                Console.WriteLine("Нет локальных максимумов");
            else
            {
                for (int i = 0; i < size_arr; i++)
                    Console.Write(arr[i] + " ");
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
        static int[] task(int number, int size,ref int[,] mat, out int size_arr)
        {
            int[] result = new int[size];

            int curr_ind = 0; 

            for (int i = 1; i < size-1; ++i)
            {
                if (mat[number, i] > mat[number, i+1] && mat[number, i] > mat[number, i - 1])
                    result[curr_ind++] = 1 + i++;
            }
            size_arr = curr_ind;
            return result;
        }
        
        static void Main(string[] args)
        {
            int size, size_arr;
            int [,] mat = create_matrix(out size);


            Console.WriteLine("\nПроизвольно заданная матрица: ");
            print_matrix(size, mat);

            Console.WriteLine("\nПозиции локальных максимумов для каждой строки: ");

            for (int i = 0; i < size; ++i)
            {
                Console.Write($"{i+1}) ");
                special_print_row(size, task(i, size, ref mat, out size_arr), size_arr);
            }

            Console.WriteLine();


        }
    }
}
