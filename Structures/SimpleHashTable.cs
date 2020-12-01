using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Queues;

namespace Structures
{
    class SimpleHashTable<T>: IQueueable<T>
        //where T : IComparable<T>
    {
        // размер хеш-таблицы определяется диапазоном приоритетов
        // минимальное и максимальное значения приоритетов можно хранить в классе Model
        public SimpleHashTable(int size)
        {
            Contract.Requires<QueueException>(size > 0, "Нарушение контракта: недопустимый размер хеш-таблицы");

            body = new LinkedList<T>[size];
            nQueues = size;
            for (int i = 0; i < size; i++)
                body[i] = new LinkedList<T>();
        }
        public T Item()
        {
            //Contract.Requires<QueueException>(Count > 0, "Нарушение контракта: попытка чтения из пустой хеш-таблицы");

            return body[highest].First.Value;
        }
        public void Put(T t)
        {
            int index = t.GetHashCode() % nQueues; // после реализации GetHashCode возможно, остаток от деления не потребуется
            body[index].AddLast(t);
            count++;
            if (highest < index)
                highest = index;            
        }
        public void Remove()
        {
            body[highest].RemoveFirst();
            count--;
            while (highest >= 0 && body[highest].Count == 0)
                highest--;
        }

        public int Count // количество элементов в хеш-таблице
        {
            get
            {
                return count;
            }
        }
        public void Clear()
        {
            for (int i = 0; i <= highest; i++)
                body[i].Clear();
            count = 0;
            highest = 0;
        }

        // метод для отображения хеш-таблицы в ListBox'е
        // заглушка. Правильно реализовать интерфейс IEnumerable<T>
        public T[] ToArray() // метод для отображения хеш-таблицы в ListBox'е
        {
            T[] result = new T[Count];
            int j = 0;
            for (int i = highest; i >= 0; i--)
                for (LinkedListNode<T> lln = body[i].First; lln != null; lln = lln.Next)
                {
                    result[j] = lln.Value;
                    j++;
                }
            return result;
        }

        private LinkedList<T>[] body;
        private int nQueues; // размер хеша
        private int highest; // наивысший приоритет
        private int count;   // общее количество элементов в хеше
    }
}
