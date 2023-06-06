using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Laba6
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Введите данные: ");
                string [] T = Console.ReadLine().Split();
                StackArr<string> spisok = new StackArr<string> (T.Length);
                for (int i = 0; i < T.Length; i++)
                {
                    spisok.push(T[i]);
                }
                    Console.WriteLine("Записанные даннные:");
                for (int i = 0; i < T.Length; i++)
                {
                    string El = spisok.pick();
                    Console.Write($" {El} ");
                    spisok.pop();
                }
                Console.WriteLine();
                if (spisok.IsEmpty())
                {
                    Console.WriteLine("Операции прошли успешно. Стек пуст");
                }

            }
        }
    }
}
