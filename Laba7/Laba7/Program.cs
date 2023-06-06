using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba7
{
    class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();
            QueueS<int> Deq = new QueueS<int>();
            Console.WriteLine(" N =");
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                Deq.Add(R.Next(1, 100));
            }
            for (int i = 0; i < Deq.Count(); i++)
            {
                int K = Deq.Del();
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
            RingQueue<int> DeqR = new RingQueue<int>();
            Console.WriteLine(" N =");
            N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                Deq.Add(R.Next(1, 100));
            }
            for (int i = 0; i < Deq.Count(); i++)
            {
                int K = Deq.Del();
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
            Console.WriteLine(" N =");
            MixedQueue<int> Deq3 = new MixedQueue<int>(N);
            N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                Deq.Add(R.Next(1, 100));
            }
            for (int i = 0; i < Deq.Count(); i++)
            {
                int K = Deq.Del();
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
    class Element<T>
    {
        public Element(T data)
        {
            Data = data;
        }
        public T Data;
        public Element<T> Next;
    }
    class ElementP<T>
    {
        public ElementP(T data, int pr=1)
        {
            Data = data;
            Priority = pr;
        }
        public T Data;
        public int Priority;
        public ElementP<T> Next;
    }
    class QueueS <T>
    {
        Element<T> head; // головной/первый элемент
        Element<T> tail; // последний/хвостовой элемент
        int count;
        // добавление в очередь
        /// <summary>
        /// Добавление в очередь указанного элемента
        /// </summary>
        /// <param name="data">элемент, который необходимо добавить</param>
        public void Add(T data)
        {
            Element<T> node = new Element<T>(data); //новый элемент
            Element<T> cur = tail; //последний элемент
            tail = node; //новый становится последним
            if (count == 0) //если очередь пуста, то последний элемент становится началом
                head = tail;
            else
                cur.Next = tail; //обновление ссылки на добавленный элемент
            count++;
        }
        // удаление из очереди
        /// <summary>
        /// Чтение и удаление элемента из очереди
        /// </summary>
        /// <returns>первый элемент в очереди</returns>
        public T Del()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data; //значение первого элемента в очереди
            head = head.Next; //головным элементом становится следующий
            count--;
            return output;
        }
        public int Count() { return count; }
        public bool IsEmpty() { return count == 0; }
    }
    public class RingQueue<T>
    {
        public RingQueue(int capacity = 16)
        {
            Q = new T[16];
            head = -1;
            tail = -1;
        }

        private T[] Q;

        /// <summary>
        /// Последний возвращённый элемент. На tail+1 находится ближайший элемент для возврата.
        /// </summary>
        private int tail;

        /// <summary>
        /// Последний добавленный элемент
        /// </summary>
        private int head;

        public bool IsEmpty => head == tail;

        public T Del()
        {
            if (IsEmpty)
                throw new InvalidOperationException("В очереди нет элементов");
            tail++;
            if (tail >= Q.Length)
                tail = 0;
            var el = Q[tail];
            return el;
        }

        public void Add(T el)
        {
            if (head + 1 == tail)
            {
                // очередь забита
                var newArr = new T[Q.Length + 8];
                int l = Q.Length - tail - 1;
                Array.Copy(Q, tail + 1, newArr, 0, l);
                Array.Copy(Q, 0, newArr, l, head);
                head = l + head;
                tail = -1;

                head++;
                Q[head] = el;
                return;

            }
            head++;
            Q[head] = el;
        }
    }
    public class QueueP<T>
    {

        ElementP<T> head; // головной/первый элемент
        ElementP<T> tail; // последний/хвостовой элемент
        int count;
        // добавление в очередь
        /// <summary>
        /// Добавление в очередь указанного элемента
        /// </summary>
        /// <param name="data">элемент, который необходимо добавить</param>
        public void Add(T data, int prior=1)
        {
            ElementP<T> node = new ElementP<T>(data, prior); //новый элемент
            ElementP<T> cur = tail; //последний элемент
            tail = node; //новый становится последним
            if (count == 0) //если очередь пуста, то последний элемент становится началом
                head = tail;
            else
                cur.Next = tail; //обновление ссылки на добавленный элемент
            count++;
        }
        // удаление из очереди
        /// <summary>
        /// Чтение и удаление элемента из очереди
        /// </summary>
        /// <returns>первый элемент в очереди</returns>
        public T Del()
        {
            ElementP<T> cur = head;
            ElementP<T> found=head;
            int maxPrior = 0;
            if (count == 0)
                throw new InvalidOperationException();
            for (int i = 0; i < count; i++)
            {
                if (cur.Priority > maxPrior)
                {
                    found = cur;
                    cur = cur.Next;
                }
            } //головным элементом становится следующий
            count--;
            return found.Data;
        }
        public int Count() { return count; }
        public bool IsEmpty() { return count == 0; }
    }
    public class MixedQueue<T>
    {
        public MixedQueue(int count)
        {
            
            queue = new QueueS<T>[count];
        }

        private QueueS<T>[] queue;

        public bool HasElements => queue.All(x => x.IsEmpty());

        /// <summary>
        /// Получает следующий элемент с наивысшим приоритетом.
        /// </summary>
        /// <returns>Элемент из очереди.</returns>
        public T Del()
        {
            for (int i = 0; i < queue.Length; i++)
            {
                if (!queue[i].IsEmpty())
                    return queue[i].Del();
            }

            return default;
        }

        /// <summary>
        /// Помещает элемент в очередь.
        /// </summary>
        /// <param name="el">Элемент для сохранения.</param>
        /// <param name="priority">Приоритет. Меньшее число - больший приоритет. Наивысший дотсупный - 0.</param>
        public void Add(T el, int priority)
        {
            if (priority < 0)
                throw new ArgumentOutOfRangeException(nameof(priority);
            if (priority >= queue.Length)
                priority = queue.Length - 1;
            queue[priority].Add(el);
        }
    }
}
