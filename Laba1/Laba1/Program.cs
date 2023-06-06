using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    class Program
    {
        static int N; //размер квадратной матрицы
        static Random R = new Random();
        static void Main(string[] args)
        {
            while (true)
            {
            N = int.Parse(Console.ReadLine()); //ввод размера квадратной матрицы
            int[,] mas = new int[N,N];
            int vec = ((N * N - N) / 2) + N+1; //вектор, в который ббудет упакована матрица
            int[] vector = new int[vec];
            for (int i = 0; i < N; i++)//заполнение симметричной матрицы
            {
                for (int j = 0; j < N; j++)
                {
                    if (mas[i, j] == 0)
                    {
                        mas[i, j] = R.Next(1, 100);
                        mas[j, i] = mas[i, j];
                    }
                }
            }
            for (int i = 0; i < N; i++)  
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{mas[i,j]} "); //вывод матрицы на консоль
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Packing(mas, vector); //упаковка симметричной матрицы

            int[,] aray = new int[N,N]; //создание матрицы, в которую будет распакован вектор

            aray = UnPacking(vector); //распаковка симметричной матрицы

            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write($"{vector[i]} "); //вывод упакованной матрицы на экран
            }
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{aray[i, j]} "); //вывод распакованной симметричной матрицы 
                }
                Console.WriteLine();
            }
            Console.ReadKey();

            }
        }
        /// <summary>
        /// Упаковка симметричной матрицы
        /// </summary>
        /// <param name="mas">симметричная матрица для упаковки</param>
        /// <param name="vector">упакованное представление симметричной матрицы</param>
        public static void Packing(int[,] mas, int [] vector)
        {
            vector[0] = N;
            int k = 1;
            for(int i=0; i<N; i++)
            {
                for(int j=0; j<N; j++)
                {
                    if (j >= i) //если элемент находится выше главной диагонали
                    {
                        vector[k] = mas[i, j];
                            k++;
                    }
                }
            }

        }
        /// <summary>
        /// распаковка симметричной матрицы
        /// </summary>
        /// <param name="vector">упакованное представление симметричной матрицы</param>
        /// <returns>распакованную симметричную матрицу</returns>
        public static int[,] UnPacking(int[] vector)
        {
            int[,] mas1 = new int[N, N];
            if (N != vector[0]) {Console.WriteLine("Произошла ошибка при упаковке матрицы. Невозможно распаковать"); return mas1; }
                int k = 1;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (mas1[i, j] == 0)
                        {
                            if (j >= i)
                            {
                                 mas1[i, j]=vector[k]; //заполнение матрицы
                                    k++;
                            }
                            mas1[j, i] = mas1[i, j];
                        }
                    }
                }
            return mas1;
        }
    }
}
