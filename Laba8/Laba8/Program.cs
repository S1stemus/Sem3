using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();
            Deque<int> Deq = new Deque<int>();
            Console.WriteLine(" N =");
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i <N; i++)
            {
                Deq.AddLast(R.Next(1, 100));
            }
            for (int i = 0; i <Deq.Count(); i++)
            {
                int K = Deq.ShowEndToFirst();
                Console.Write($"{K} ");
            }
            Console.WriteLine();
            Console.WriteLine("new element = ");
            int ad = int.Parse(Console.ReadLine());
            Deq.AddLast(ad * 2);
            Deq.AddFirst(ad);
            for (int i = 0; i < Deq.Count(); i++)
            {
                int K = Deq.ShowFirstToEnd();
                Console.Write($"{K} ");
            }
            Console.WriteLine();
            if (Deq.IsEmpty())
            {
                Console.WriteLine("Is empty");
            }
            else
            {
                Console.WriteLine("Isn't empty");
            }
            Console.ReadKey();
        }
    }
    class Element <T>
    {
        public Element(T data)
        {
            Data = data;
        }
        public T Data;
        public Element<T> Previous; //ссылка на предыдущий элемент
        public Element<T> Next; //ссылка на следующий элемент
    }
    class Deque <T>
    {
        Element<T> head; // головной/первый элемент
        Element<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке
        Element<T> current;

        /// <summary>
        /// Добавление в конец дека
        /// </summary>
        /// <param name="data">элемент, который необходимо добавить</param>
        public void AddLast(T data)
        {
            Element<T> node = new Element<T>(data);

            if (head == null)//если дек пуст, то добавляется в начало
                head = node;
            else
            {
                tail.Next = node; //ссылка на новый элемент
                node.Previous = tail; //добавление ссылки на конец дека (соединение элемента)
            }
            tail = node; //последний элемент - добавленный
            count++; //увеличение количества элементов
            current = node;
        }
        /// <summary>
        /// Добавление элемента в начало дека
        /// </summary>
        /// <param name="data">элемент, который необходимо добавить</param>
        public void AddFirst(T data)
        {
            Element<T> node = new Element<T>(data);
            Element<T> temp = head;
            node.Next = temp;//ссылка на начало дека
            head = node; //головным элементом становится новый
            if (count == 0) //если дек пуст конец становится головой
                tail = head;
            else
                temp.Previous = node; //иначе бывший первый элемент получает ссылку на новый
            count++;
            current = node;
        }
        /// <summary>
        /// удаление первого элемента из дека
        /// </summary>
        /// <returns> значение первого элемента</returns>
        public T RemoveFirst()
        {
            if (count == 0) //если дек пуст
                throw new InvalidOperationException();
            T output = head.Data; //значение первого в деке элемента
            if (count == 1)//если в деке есть только один элемент
            {
                head = tail = null;
            }
            else
            {
                head = head.Next; //головным элементом становится следующий
                head.Previous = null;//зануление ссылки на прошлый элемент
            }
            count--;
            return output; //удалённый элемент
        }
        /// <summary>
        /// Удаление посследнего элемента
        /// </summary>
        /// <returns>значение последнего элемента в деке</returns>
        public T RemoveLast()
        {
            if (count == 0) //если дек пуст
                throw new InvalidOperationException();
            T output = tail.Data; //значение последнего элемента
            if (count == 1) //если в деке был один элемент, то ссылки обнуляются
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous; //последний становится предыдущим
                tail.Next = null; //ссылка на следующий элемент зануляется
            }
            count--;
            return output;
        }
        /// <summary>
        /// Получение первого элемента в деке
        /// </summary>
        /// <returns>значение первого элемента</returns>
        public T First()
        {
                if (IsEmpty())
                    throw new InvalidOperationException();
                return head.Data;
        }
        /// <summary>
        /// Получение последнего элемента в деке
        /// </summary>
        /// <returns>значение последнего элемента в деке</returns>
        public T Last()
        {
                if (IsEmpty())
                    throw new InvalidOperationException();
                return tail.Data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Количество элементов в деке</returns>
        public int Count() { return count;}
        /// <summary>
        /// Проверка дека на пустоту
        /// </summary>
        /// <returns>true- если пуст, false - если полон</returns>
        public bool IsEmpty() { return count == 0; }

        /// <summary>
        /// очищает все элементы дека
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// показывает с текущего по последний элемент в деке
        /// </summary>
        /// <returns> значение текущего элемента</returns>
        public T ShowFirstToEnd()
        {
            T data = current.Data;
            current = current.Next;
            return data ;
        }
        /// <summary>
        /// показывает с текущего до первого элемента в деке
        /// </summary>
        /// <returns>значение текущего элемента</returns>
        public T ShowEndToFirst()
        {
            T data = current.Data;
            current = current.Previous;
            return data;
        }

    }
}
