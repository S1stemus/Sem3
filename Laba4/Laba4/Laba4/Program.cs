using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    class Program
    {
        static void Main(string[] args)
        {
            int P = 0;
            while (P != 65)
            {
                Random R = new Random();
                //Создание массива
                Console.Write("Введите длину массива:");
                int len = int.Parse(Console.ReadLine());
                int[] array = new int[len];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = R.Next(0, 100);
                    Console.Write($"{array[i]} ");
                }
                Console.WriteLine();
                //Вввод данных
                Console.WriteLine("Введите элемент, кoторый необходимо найти:");
                int El = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("1. Линейный поиск");
                Console.WriteLine("2. Бинарный поиск");
                Console.WriteLine("3. Интерполяционный поиск");
                Console.WriteLine("4. Поиск прыжками");
                Console.WriteLine("5. Рекурсивный бинарный поиск");
                Console.WriteLine("Введите номер варианта поика:");
                P = int.Parse(Console.ReadLine());
                switch (P)
                {
                     case 1:
                        int index=LinearSearch(array,El);
                        if (index != -1)
                        {
                            Console.WriteLine($"Заданный элемент имеет индекс: {index}");
                        }
                        else
                        {
                            Console.WriteLine("Заданный элемент не найден");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Отсортированный массив:");
                        //сортировка массива
                        Quicksort(array, 0, array.Length - 1);
                        foreach(int x in array)
                        {
                            Console.Write($"{x} ");
                        }
                        Console.WriteLine();
                        index = BinSearch(array, El);
                        if (index != -1)
                        {
                            Console.WriteLine($"Заданный элемент имеет индекс: {index}");
                        }
                        else
                        {
                            Console.WriteLine("Заданный элемент не найден");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Отсортированный массив:");
                        //Сортировка массива
                        Quicksort(array, 0, array.Length - 1);
                        foreach (int x in array)
                        {
                            Console.Write($"{x} ");
                        }
                        Console.WriteLine();
                        index = InterpolationSearch(array, El);
                        if (index != -1)
                        {
                            Console.WriteLine($"Заданный элемент имеет индекс: {index}");
                        }
                        else
                        {
                            Console.WriteLine("Заданный элемент не найден");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Отсортированный массив:");
                        //Сортировка массива
                        Quicksort(array, 0, array.Length - 1);
                        foreach (int x in array)
                        {
                            Console.Write($"{x} ");
                        }
                        Console.WriteLine();
                        index = JumpSearch(array, El);
                        if (index != -1)
                        {
                            Console.WriteLine($"Заданный элемент имеет индекс: {index}");
                        }
                        else
                        {
                            Console.WriteLine("Заданный элемент не найден");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Отсортированный массив:");
                        //Сортировка массива
                        Quicksort(array, 0, array.Length - 1);
                        foreach (int x in array)
                        {
                            Console.Write($"{x} ");
                        }
                        Console.WriteLine();
                        index = BinSearch2(array,0, array.Length-1, El);
                        if (index != -1)
                        {
                            Console.WriteLine($"Заданный элемент имеет индекс: {index}");
                        }
                        else
                        {
                            Console.WriteLine("Заданный элемент не найден");
                        }
                        break;
                    case 65:
                        return;
                }

            }
        }
        /// <summary>
        /// Линейный поиск
        /// </summary>
        /// <param name="arr">массив, в котором осуществляется поиск элемента</param>
        /// <param name="el">искомый элемент</param>
        /// <returns>индекс искомого элемента</returns>
        public static int LinearSearch(int[] arr, int el)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == el) { return i; }
            }
            return -1;
        } 
        /// <summary>
        /// Бинарный поиск элемента в массив.
        /// Массив должен быть отсортирован
        /// </summary>
        /// <param name="arr">массив, в котором осуществляется поиск элемента</param>
        /// <param name="el">искомый элемент</param>
        /// <returns>индекс искомого элемента</returns>
        public static int BinSearch(int []arr, int el)
        {
           int end = arr.Length - 1; //последний индекс для поиска
            int start = 0; //первый индекс для поиска
            while (true)
            {
                double mid = ((end+start) / 2); //индекс среднего элемента в указанном диапазоне
                int middle = (int)Math.Round(mid);
                if (el < arr[middle]) //если искомый элемент меньше середины, сдвигаем правую границу
                {
                    end = middle - 1;
                }
                else if (el > arr[middle]) //если элемент больше середины, сдвигаем левую границу
                {
                    start = middle + 1;
                }
                else //иначе элемент найден
                {
                    return middle;
                }
                if (end < start) 
                {
                    return -1;
                }
            }
        }
        /// <summary>
        /// Рекурсивный бинарный поиск.
        /// Массив должен быть отсортирован
        /// </summary>
        /// <param name="arr">массив для поиска элемента</param>
        /// <param name="end">индекс правой границы поиска</param>
        /// <param name="start">индекс левой границы поиска</param>
        /// <param name="El">искомый элемент</param>
        /// <returns>индекс искомого элемента</returns>
        public static int BinSearch2(int [] arr, int end, int start, int El)
        {
            if (end >= start)
            {
                int mid = start + (end- start) / 2;
                // если средний элемент - искомый, то возвращаем его индекс
                if (arr[mid] == El)
                    return mid;
                // если средний элемент больше искомого
                // вызываем метод рекурсивно по суженным данным
                if (arr[mid] > El)
                    return BinSearch2(arr, start, mid - 1, El);

                // Иначе также, вызываем метод рекурсивно по суженным данным
                return BinSearch2(arr, mid + 1, end, El);
            }
            return -1; //элемент не найден
        }
        /// <summary>
        /// Интерполяционный поиск.
        /// Массив должен быть отсортирован.
        /// Эффективен при большом кол-ве данных.
        /// </summary>
        /// <param name="array">массив, в котором осуществляется поиск</param>
        /// <param name="Element">искомый элемент</param>
        /// <returns>индекс искомого элемента</returns>
        public static int InterpolationSearch(int[] array, int Element)
        {
            int start = 0;
            int end = (array.Length - 1);
            while ((start <= end) && (Element >= array[start]) &&(Element <= array[end])) //пока искомый элемент находится в указанном диапазоне
            {
                // используем формулу интерполяции для поиска возможной лучшей позиции для существующего элемента
                int pos = start + (((end - start) /(array[end] - array[start])) *(Element - array[start]));
                if (array[pos] == Element) // если элемент найден
                    return pos;
                if (array[pos] < Element) // если текущий элемент меньше, чем заданный для поиска, меняем индекс
                    start = pos + 1;
                else
                    end = pos - 1;
            }
            return -1; //элемент не найден
        }
        /// <summary>
        /// Поиск прыжками.
        /// Массив должен быть отсортирован
        /// </summary>
        /// <param name="array">массив, в котором осуществляется поиск</param>
        /// <param name="El">искомый элемент</param>
        /// <returns>индекс искомого элемента</returns>
        public static int JumpSearch(int [] array, int El)
        {
            int Step = (int)Math.Sqrt(array.Length);
            int prev = 0;
            while (array[Step - 1] < El) //находим такое расстояние, при котором элемент для поиска был бы
                                                                 //меньше элемента с индексом step
            {
                prev = Step;
                Step += (int)Math.Sqrt(array.Length);  //увеличиваем step. 
                if (prev >= array.Length)
                    return -1;
            }
            while (array[prev] < El) //осуществляем линейный поиск от prev до step
            {
                prev++;
                if (prev == Step)
                    return -1;
            }
            if (array[prev] == El)
                return prev;
            return -1;
        }
        //Быстрая сортировка
        public static int Partition(int[] array, int start, int end)
        {
            int marker = start; //
            for (int i = start; i < end; i++) //сортировка в указанном диапазоне
            {
                if (array[i] < array[end]) //если текущий элемент меньше последнего
                {
                    Swap(array, marker, i);
                    //меняем местами элементы массива. Текущий 
                    marker += 1; //увеличиваем индекс
                }
            }
            Swap(array,marker, end);
            return marker;
        }
        public static void Swap(int[] array, int i, int j)
        {
            int T = array[i];
            array[i] = array[j];
            array[j] = T;
        }

        public static void Quicksort(int[] array, int start, int end)
        {
            if (start >= end)
                return;
            int pivot = Partition(array, start, end);
            Quicksort(array, start, pivot - 1);
            Quicksort(array, pivot + 1, end);
        }
    }
}
