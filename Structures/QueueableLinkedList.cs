using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queues;

namespace Structures
{
    public class QueueableLinkedList<T> : LinkedList<T>, IQueueable<T>       
    {
        public virtual T Item()
        {
            return this.First.Value;
        }
        public virtual void Remove()
        {
            this.RemoveFirst();
        }
        public virtual void Put(T t)
        {
            this.AddLast(t);
        }
        public T[] ToArray()
        {
            T[] result = new T[this.Count];
            int i = 0;
            foreach (T k in this)
                result[i++] = k;
            return result;
        }
    }
}
