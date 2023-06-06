using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Random R = new Random();
                SList<int> list = new SList<int>();
                SList<int> list2 = new SList<int>();
                Console.WriteLine("Введите кол-во элементов в списке");
                int N= int.Parse(Console.ReadLine());
                for (int i = 0; i < N; i++)
                {
                    list.Add(R.Next(1, 100));
                }
                int[] array = new int[list.Count()];
                Console.Write($"{list.First()}-{list.Last()}");
                Console.WriteLine();
                Console.WriteLine("1. Добавление элемента");
                Console.WriteLine("2. Удаление элемента");
                Console.WriteLine("3. Копирование в массив");
                Console.WriteLine("4. Копирование в список");
                Console.WriteLine("5. Слияние двух списков без создания нового списка");
                Console.WriteLine("6. Слияние двух списков с созданием нового списка");
                Console.WriteLine("7. Проверка на пустоту");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Write("Введите элемент для добавления: ");
                        list.Add(int.Parse(Console.ReadLine()));
                        for (int i = 0; i < list.Count(); i++)
                        {
                            Console.Write($"{list.Show()} ");
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        SList<int> list3 = list;
                        list.CopyTo(array, 0);
                        foreach (int x in array)
                        {
                            Console.Write($"{x} ");
                        }
                        Console.WriteLine();
                        Console.Write("Введите элемент для удаления: ");
                        list.Remove(int.Parse(Console.ReadLine()));
                        for (int i = 0; i < list.Count(); i++)
                        {
                            Console.Write($"{list.Show()} ");
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        list.CopyTo(array, 0);
                        foreach (int x in array)
                        {
                            Console.Write($"{x} ");
                        }
                        Console.WriteLine();
                        list.CopyTo(array, 0);
                        foreach(int x in array)
                        {
                            Console.Write( $"{x} ");
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        
                        for (int i = 0; i < N; i++)
                        {
                            list2.Add(R.Next(1, 100));
                        }
                        Console.WriteLine("Изначальный список:");
                        list.CopyTo(array, 0);
                        foreach (int x in array)
                        {
                            Console.Write($"{x} ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Список, который будет скопирован в изначальный:");
                        list2.CopyTo(array, 0);
                        foreach (int x in array)
                        {
                            Console.Write($"{x} ");
                        }
                        Console.WriteLine();
                        SList<int> list5 = new SList<int>(); 
                        list5=list.CopyList(int.Parse(Console.ReadLine()));
                        Console.WriteLine();
                        for (int i = 0; i < list5.Count(); i++)
                        {
                            Console.Write($"{list5.Show()} ");
                        }
                        break;
                    case 5:
                        for (int i = 0; i < N; i++)
                        {
                            list2.Add(R.Next(1, 100));
                        }
                        Console.WriteLine();
                        Console.WriteLine("Изначальный список:");
                        list.CopyTo(array, 0);
                        foreach (int x in array)
                        {
                            Console.Write($"{x} ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Список, который будет помещён в изначальный:");
                        list2.CopyTo(array, 0);
                        foreach (int x in array)
                        {
                            Console.Write($"{x} ");
                        }
                        list.Unite(list2);
                        Console.WriteLine();
                        for (int i = 0; i < list.Count(); i++)
                        {
                            Console.Write($"{list.Show()} ");
                        }
                        break;
                    case 6:
                        for (int i = 0; i < N; i++)
                        {
                            list2.Add(R.Next(1, 100));
                        }
                        Console.WriteLine();
                        Console.WriteLine("Изначальный список:");
                        list.CopyTo(array, 0);
                        foreach (int x in array)
                        {
                            Console.Write($"{x} ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Список, который будет помещён в изначальный:");
                        list2.CopyTo(array, 0);
                        foreach (int x in array)
                        {
                            Console.Write($"{x} ");
                        }
                        Console.WriteLine();
                        list5 = list.UniteList(list2);
                        for (int i = 0; i <list5.Count(); i++)
                        {
                            Console.Write($"{list5.Show()} ");
                        }
                        list2.Clear();
                        break;
                    case 7:
                        if (list.IsEmpty())
                        {
                            Console.WriteLine("Список пуст(true)");
                        }
                        else
                        {
                            Console.WriteLine("Список заполнен (false)");
                        }
                        break;
                }
                
                
                Console.WriteLine();
            }
        }
    }
    public class Element<T>
    {
        public Element(T data) // присваивает полю Data заданное значение
        {
            Data = data;
        }
        public T Data; // поле класса Element, хранит значение элемента
        public Element<T> Next; // поле, которое хранит ссылку на следующий элемент
    }
    class SList<T>// односвязный список
    {
        Element<T> head; // первый элемент
        Element<T> tail; // последний элемент
        int count;  // количество элементов в списке
        public SList()
        {
            head=null;
            tail = null;
            count = 0;
        }
        public SList(Element<T> key)
        {
            head = key;
        }
        /// <summary>
        /// Добавление в список элемента
        /// </summary>
        /// <param name="data">элемент для добавления</param>
        public void Add(T data)
        {
            Element<T> next = new Element<T>(data);
            if (head == null) //если список пуст
                head = next; //заполняем первый элемент списка
            else
                tail.Next = next; //ссылка на следующий элемент обновляется
            tail = next; // новый элемент становится последним
            count++;// кол-во элементов в списке обновляется
        }

        /// <summary>
        /// Удаление всех элементов указанного значения
        /// </summary>
        /// <param name="data">значение элемента, которое необходимо удалить</param>
        public void Remove(T data)
        {
            Element<T> current = head;// текущий элемент списка. В начале является первым
            Element<T> previous = null; //предыдущий элемент списка
            while (current != null) //пока текущий элемент существует
            {
                if (current.Data.Equals(data)) // если значение текущего элемента совкадает с заданным значением для удаления
                {
                    if (previous != null) //если предыдущий элемент существует (не начало)
                    {
                        previous.Next = current.Next; //меняем ссылку на следующий элемент. Теперь ссылка указывает на элемент, следующий за удаляемым
                        if (current.Next == null) //если нет ссылки на элемент следующий за удаляемым, то предыдущий элемент становится последним
                            tail = previous;
                    }
                    else //если удаляемый элемент первый
                    {
                        head = head.Next; // первым элементом становится следующий
                        if (head == null) // если после удаления список пуст
                            tail = null; // конец зануляем
                    }
                    count--;//кол-во элементов уменьшаем
                }
                previous = current; //предыдущий элемент становится текущим
                current = current.Next; //текущий элемент становится следующим
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>количество элементов в списке</returns>
        public int Count() {  return count;}
        /// <summary>
        /// Проверка списка на пустоту
        /// </summary>
        /// <returns>значение true, если список пуст</returns>
        public bool IsEmpty() {return count == 0;}

        /// <summary>
        /// Осуществляет удаление всех элементов в списке
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        /// <summary>
        /// Осуществляет копирование части списка в одномерный массив, начиная с указанного индекса
        /// </summary>
        /// <param name="array">массив для копирования</param>
        /// <param name="arrayIndex">индекс, с которого будут копироваться элементы списка</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (head == null)//если список пуст
            {
                return;
            }
            if (count > array.Length-arrayIndex) //если длина списка больше, чем размер массива
            {
                throw new IndexOutOfRangeException();
            }
            Element<T> current = head; //текущий элемент списка
            int i = arrayIndex;
            while(current!=null &&i<=array.Length)
            {
                array[i] = current.Data; //элемент массива получает значение элемента списка
                current = current.Next;
                i++;//текущий элемент списка становится следущим
            }
        }
        /// <summary>
        /// Копирование части одного списка в другой, начиная с указанного элемента
        /// </summary>
        /// <param name="data">элемент, с которого начинается копирование</param>
        /// <returns>новый список, содержащий значения исходного листа</returns>
        public SList<T> CopyList(T data)
        {
            SList<T> list = new SList<T>();
            Element<T> current = head;
            Element<T> current2 = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    current2 = current;
                }
                current = current.Next;
            }
            while (current2.Next != null)
            {
                list.Add(current2.Data);
                current2 = current2.Next;
            }
            list.Add(tail.Data);
            return  list;
        }
        /// <summary>
        /// Осуществляет объединение двух списков
        /// </summary>
        /// <param name="list2">список, который добавляется в исходный</param>
        /// <returns></returns>
        public void Unite(SList<T> list2)
        {
            while (list2.head.Next!= null)
            {
                Add(list2.head.Data);
                list2.head = list2.head.Next;
            }
            Add(list2.tail.Data);
        }
        /// <summary>
        /// Осуществляет создание списка, объединяющий изначальный и заданный списки
        /// </summary>
        /// <param name="list2">заданный пользователем список</param>
        /// <returns>список, содержащий в себе элементы обоих списков</returns>
        public SList<T> UniteList(SList<T> list2)
        {
            Element<T> head1 = head;
            Element<T> head2 = list2.head;
            Element<T> tail1 = tail;
            Element<T> tail2 = list2.tail;
            SList<T> current = new SList<T>();
            while (head1.Next != null)
            {
                current.Add(head1.Data);
                head1 = head1.Next;
            }
            while (head2.Next != null)
            {
                current.Add(head2.Data);
                head2 = head2.Next;
            }
            current.Add(tail2.Data);
            return current;
        }
        public T Show()
        {
            Element<T> cur = head;
            head = head.Next;
            return cur.Data;
        }
        public T First()
        {
            return head.Data;
        }
        public T Last()
        {
            return tail.Data;
        }

    }
    public class ElementS<T>
    {
        public ElementS(T data) // присваивает полю Data заданное значение
        {
            Data = data;
        }
        public T Data; // поле класса Element, хранит значение элемента
        public ElementS<T> Next; // поле, которое хранит ссылку на следующий элемент
        public ElementS<T> Prev; 
    }
    class DList<T>
    {

        ElementS<T> head; // первый элемент
        ElementS<T> tail; // последний элемент
        int count;  // количество элементов в списке
        public DList()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public DList(ElementS<T> key)
        {
            head = key;
        }
        /// <summary>
        /// Добавление в список элемента
        /// </summary>
        /// <param name="data">элемент для добавления</param>
        public void Add(T data)
        {
            ElementS<T> next = new ElementS<T>(data);
            if (head == null) //если список пуст
                head = next; //заполняем первый элемент списка
            else
                tail.Next = next; //ссылка на следующий элемент обновляется
            tail = next;// новый элемент становится последним
            next.Prev = tail;
            count++;// кол-во элементов в списке обновляется
        }

        /// <summary>
        /// Удаление всех элементов указанного значения
        /// </summary>
        /// <param name="data">значение элемента, которое необходимо удалить</param>
        public void Remove(T data)
        {
            ElementS<T> current = head;// текущий элемент списка. В начале является первым
            ElementS<T> previous = null; //предыдущий элемент списка
            while (current != null) //пока текущий элемент существует
            {
                if (current.Data.Equals(data)) // если значение текущего элемента совкадает с заданным значением для удаления
                {
                    if (previous != null) //если предыдущий элемент существует (не начало)
                    {
                        previous.Next = current.Next; //меняем ссылку на следующий элемент. Теперь ссылка указывает на элемент, следующий за удаляемым
                       
                        if (current.Next == null) //если нет ссылки на элемент следующий за удаляемым, то предыдущий элемент становится последним
                            tail = previous;
                        else current.Next.Prev = previous;

                    }
                    else //если удаляемый элемент первый
                    {
                        head = head.Next; // первым элементом становится следующий
                        head.Next.Prev = null;
                        if (head == null) // если после удаления список пуст
                            tail = null; // конец зануляем
                    }
                    count--;//кол-во элементов уменьшаем
                }
                previous = current; //предыдущий элемент становится текущим
                current = current.Next; //текущий элемент становится следующим
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>количество элементов в списке</returns>
        public int Count() { return count; }
        /// <summary>
        /// Проверка списка на пустоту
        /// </summary>
        /// <returns>значение true, если список пуст</returns>
        public bool IsEmpty() { return count == 0; }

        /// <summary>
        /// Осуществляет удаление всех элементов в списке
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        /// <summary>
        /// Осуществляет копирование части списка в одномерный массив, начиная с указанного индекса
        /// </summary>
        /// <param name="array">массив для копирования</param>
        /// <param name="arrayIndex">индекс, с которого будут копироваться элементы списка</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (head == null)//если список пуст
            {
                return;
            }
            if (count > array.Length - arrayIndex) //если длина списка больше, чем размер массива
            {
                throw new IndexOutOfRangeException();
            }
            ElementS<T> current = head; //текущий элемент списка
            int i = arrayIndex;
            while (current != null && i <= array.Length)
            {
                array[i] = current.Data; //элемент массива получает значение элемента списка
                current = current.Next;
                i++;//текущий элемент списка становится следущим
            }
        }
        /// <summary>
        /// Копирование части одного списка в другой, начиная с указанного элемента
        /// </summary>
        /// <param name="data">элемент, с которого начинается копирование</param>
        /// <returns>новый список, содержащий значения исходного листа</returns>
        public DList<T> CopyList(T data)
        {
            DList<T> list = new DList<T>();
            ElementS<T> current = head;
            ElementS<T> current2 = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    current2 = current;
                }
                current = current.Next;
            }
            while (current2.Next != null)
            {
                list.Add(current2.Data);
                current2 = current2.Next;
            }
            list.Add(tail.Data);
            return list;
        }
        /// <summary>
        /// Осуществляет объединение двух списков
        /// </summary>
        /// <param name="list2">список, который добавляется в исходный</param>
        /// <returns></returns>
        public void Unite(DList<T> list2)
        {
            while (list2.head.Next != null)
            {
                Add(list2.head.Data);
                list2.head = list2.head.Next;
            }
            Add(list2.tail.Data);
        }
        /// <summary>
        /// Осуществляет создание списка, объединяющий изначальный и заданный списки
        /// </summary>
        /// <param name="list2">заданный пользователем список</param>
        /// <returns>список, содержащий в себе элементы обоих списков</returns>
        public DList<T> UniteList(DList<T> list2)
        {
            ElementS<T> head1 = head;
            ElementS<T> head2 = list2.head;
            ElementS<T> tail1 = tail;
            ElementS<T> tail2 = list2.tail;
            DList<T> current = new DList<T>();
            while (head1.Next != null)
            {
                current.Add(head1.Data);
                head1 = head1.Next;
            }
            while (head2.Next != null)
            {
                current.Add(head2.Data);
                head2 = head2.Next;
            }
            current.Add(tail2.Data);
            return current;
        }
        public T Show()
        {
            ElementS<T> cur = head;
            head = head.Next;
            return cur.Data;
        }
        public T First()
        {
            return head.Data;
        }
        public T Last()
        {
            return tail.Data;
        }
    }
}
