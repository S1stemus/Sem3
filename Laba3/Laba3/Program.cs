using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laba3
{
    class Program
    {
        static void Main(string[] args)
        {
            int op = 1;
            while (op != 5)
            {
                Console.WriteLine();
                Console.WriteLine("***************");
                Console.WriteLine("Алгоритмы работы со строками");
                Console.WriteLine("1. Поиск подстроки в тексте");
                Console.WriteLine("2. Алгоритм Рабина");
                Console.WriteLine("3. Алгоритм Кнута-Морриса-Пратта");
                Console.WriteLine("4. Стемминг");
                Console.WriteLine("5. Выход");
                Console.Write("Введите номер операции:");
                op = int.Parse(Console.ReadLine());
                Console.Write("Введите строку для поиска:");
                List<string> output = new List<string>();
                int count = 0;
                switch (op)
                {
                    case 1:
                        {
                            string input = Console.ReadLine();
                            string[] text = File.ReadAllLines("Test.txt");
                            for (int i = 0; i < text.Length; i++)
                            {
                                string[] pred = text[i].Split('.');
                                for (int j = 0; j < pred.Length; j++)
                                {
                                    if (pred[j].Contains(input))
                                    {
                                        output.Add(pred[j]);
                                        count++;
                                    }
                                }
                            }
                            foreach (string x in output)
                            {
                                Console.WriteLine($"{x}");
                            }
                                Console.WriteLine($"Строка '{input}' встречается в тексте {count} раз");
                            break;
                        }
                    case 2:
                        {
                            count = 0;
                            string input = Console.ReadLine();
                            string[] text=File.ReadAllLines("Test.txt");
                            for (int i = 0; i < text.Length; i++)
                            {
                                string[] pred = text[i].Split('.');
                                for (int j = 0; j < pred.Length; j++)
                                {
                                    pred[j] += " ";
                                    Rabina(input, pred[j]).TrimEnd();
                                    if(Rabina(input, pred[j]) != "")
                                   {
                                        Console.WriteLine($"{pred[j].TrimEnd()}");
                                        count++;
                                        if(Rabina(input, pred[j]).Contains(", "))count++;
                                    }
                                }
                            }
                            Console.WriteLine($"Строка '{input}' встречается в тексте {count} раз");
                            break;
                        }
                    case 3:
                        {
                            count = 0;
                            string input = Console.ReadLine();
                            string[] text = File.ReadAllLines("Test.txt");
                            for (int i = 0; i < input.Length; i++)
                            {
                                string[] pred = text[i].Split('.');
                            for (int j = 0; j < pred.Length; j++)
                            {
                            pred[j] += " ";
                            KMP(input, pred[j]).TrimEnd();
                            if (KMP(input, pred[j]) != "")
                            {
                              Console.WriteLine($"{pred[j].TrimEnd()}");
                             count++;
                              if (KMP(input, pred[j]).Contains(", ")) count++;
                            }
                            }
                            }
                            Console.WriteLine($"Строка '{input}' встречается в тексте {count} раз");
                            break;
                        }
                    case 4:
                        {
                            string input = Console.ReadLine();
                            break;
                        }
                }
            }
        }
        //Хеш-функция для алгоритма Рабина-Карпа
        public static int Hash(string x)
        {
            int p = 31; //Простое число
            int rez = 0; //Результат вычисления 
            for (int i = 0; i < x.Length; i++)
            {
                rez += (int)Math.Pow(p, x.Length - 1 - i) * (int)(x[i]);//Подсчет хеш-функции
            }
            return rez;
        }
        //Функция поиска алгоритмом Рабина-Карпа
        public static string Rabina(string x, string s)
        {
            string nom = ""; //Номера всех вхождений образца в строку
            if (x.Length > s.Length) return nom; //Если искомая строка больше исходной – возврат пустого поиска
            int xhash = Hash(x); //Вычисление хеш-функции искомой строки
            int shash = Hash(s.Substring(0, x.Length)); //Вычисление хеш-функции первого слова длины образца в строке S
            bool flag;
            int j;
            for (int i = 0; i < s.Length - x.Length; i++)
            {
                if (xhash == shash)//Если значения хеш-функций совпадают
                {
                    flag = true;
                    j = 0;
                    while ((flag == true) && (j < x.Length))
                    {
                        if (x[j] != s[i + j]) flag = false;
                        j++;
                    }
                    if (flag == true) //Если искомая строка совпала с частью исходной
                        nom = nom + Convert.ToString(i) + ", "; //Добавление номера вхождения
                }
                else //Иначе вычисление нового значения хеш-функции
                    shash = (shash - (int)Math.Pow(31, x.Length - 1) * (int)(s[i])) * 31 + (int)(s[i + x.Length]);
            }
            if (nom != "") //Если вхождение найдено
            {
                nom = nom.Substring(0, nom.Length - 2); //Удаление запятой и пробела
            }
            return nom; //Возвращение результата поиска
        }
//Префикс-функция для КМП возвращает максимальной длине совпадающих префикса и суффикса подстроки
public static int[] PrefFunc(string x) // 
        {
            //Инициализация массива-результата длиной X
            int[] res = new int[x.Length];
            int i = 0;
            int j = -1;
            res[0] = -1;
            while (i < x.Length - 1) //проверяем всю строку 
            {
                while ((j >= 0) && (x[j] != x[i]))  //если не совпало, возвращаем длину префикса
                    j = res[j];
                i++;
                j++;
                if (x[i] == x[j]) 
                    res[i] = res[j];
                else
                    res[i] = j;
            }
            return res;//Возвращение префикс
        }

        //Функция поиска алгоритмом КМП
        public static string KMP(string x, string s)
        {
            string nom = ""; //Объявление строки с номерами позиций
            if (x.Length > s.Length) return nom; //Возвращает 0 поиск если образец больше исходной строки
                                                 //Вызов префикс-функции
            int[] d = PrefFunc(x);
            int i = 0, j;
            while (i < s.Length)
            {
                for (j = 0; (i < s.Length) && (j < x.Length); i++, j++)
                    while ((j >= 0) && (x[j] != s[i]))
                        j = d[j];
                if (j == x.Length)
                    nom = nom + Convert.ToString(i - j) + ", ";
            }
            if (nom != "")
            {
                nom = nom.Substring(0, nom.Length - 2); //Удаление последней запятой и пробела
            }
            return nom; //Возвращение результата поиска
        }
        
    }
}
