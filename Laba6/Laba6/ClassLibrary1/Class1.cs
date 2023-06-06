using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class StackArr<T>
    {
        int top=-1;
        T[] arr;
        /// <summary>
        /// конструктор. Создаёт стек, зная его длину
        /// </summary>
        /// <param name="Len">длина стека</param>
        public StackArr(int Len)
        {
            arr =new T[Len];
        }
        /// <summary>
        /// добавляет элемент в стек
        /// </summary>
        /// <param name="El">элемент, который необходимо добавить</param>
        public void push(T El)
        {
            arr[++top] = El;
        }
        /// <summary>
        /// </summary>
        /// <returns>верхний элемент стека</returns>
        public T pick()
        {
            return arr[top];
        }
        /// <summary>
        /// удаляет верхний элемент стека
        /// </summary>
        /// <returns></returns>
        public T pop()
        {
            T El = arr[top];
            arr[top] = default;
            top--;
            return El;
        }
        /// <summary>
        /// проверяет пуст ли стек
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return (top == -1);
        }
    }
}
