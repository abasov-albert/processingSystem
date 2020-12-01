using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queues;

namespace Structures
{
    class SortedAndUnsortedLinkedLists<T>: IQueueable<T> //, IEnumerable<T>
        where T: IComparable<T>
    {
        public SortedAndUnsortedLinkedLists()
        {
            unsortedBody = new LinkedList<T>();
            sortedBody = new SortedLinkedList<T>();
        }
        public T Item()
        {
            return sortedBody.Item();
        }
        public void Remove()
        {
            sortedBody.Remove();
            if (sortedBody.Count == 0)
                sort();            
        }        
        public void Put(T t)
        {
			if(this.Count == 0 || sortedBody.Count != 0 && t.CompareTo(sortedBody.Last.Value) > 0)
            /*if (sortedBody.Count == 0 && unsortedBody.Count == 0)*/
                sortedBody.Put(t);
            else
                unsortedBody.AddLast(t);
        }        
        public int Count
        {
            get
            {
                return sortedBody.Count + unsortedBody.Count;
            }
        }
        public void Clear()
        {
            sortedBody.Clear();
            unsortedBody.Clear();
        }
        public T[] ToArray()
        {
            T[] arr= new T[this.Count];
            int i = sortedBody.Count;
            Array.Copy(sortedBody.ToArray(), arr, i);
            foreach (T k in unsortedBody)
                arr[i++] = k;
            return arr;
        }

        private LinkedList<T> unsortedBody;
        private SortedLinkedList<T> sortedBody;

        private void sort()
        {
            foreach(T i in unsortedBody)
            {
                sortedBody.Put(i);                
            }
            unsortedBody.Clear();            
        }
    }
}
