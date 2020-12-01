using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Queues;

namespace Structures
{
    public enum OrderHeap
    {
        increase, // возрастание, минимум в корне
        decrease  // убывание, максимум в корне
    }
    public class BinaryHeap<T>: IQueueable<T> // : IEnumerable<T>
        where T : IComparable<T>
    {
        public BinaryHeap(OrderHeap ht = OrderHeap.decrease)
        {
            heap = new List<T>();
            typeOfBinaryHeap = ht;
        }        
        public void Put(T t)
        {
            heap.Add(t);
            int p = Count - 1;
            // пока предок меньше потомка, убывающая (decreasing) пирамида
            while (p > 0 && (typeOfBinaryHeap == OrderHeap.decrease ? heap[(p - 1) >> 1].CompareTo(t) < 0 : heap[(p - 1) >> 1].CompareTo(t) > 0))
            {
                int c = p;
                p = (p - 1) >> 1; // parent(p)
                heap[c] = heap[p];
            }
            if (Count > 1)
                heap[p] = t;
        }
        [Pure]
        public T Item()
        {
            return heap[0];            
        }
        public void Remove()
        {
                T max = heap[0];
                heap[0] = heap[Count - 1];
                heap.RemoveAt(Count - 1);
                if (Count > 1)
                    Heapify(0);           
        }
        
        private void Heapify(int i)
        {
            int left = (i + 1) << 1 - 1, right = left + 1, largest;
            largest = left < Count && (typeOfBinaryHeap == OrderHeap.decrease ? heap[left].CompareTo(heap[i]) > 0 : heap[left].CompareTo(heap[i]) < 0) /* > heap[i] */ ? left : i; // !!!!!!!!!!!!!!!!!!!!!
            if (right < Count && (typeOfBinaryHeap == OrderHeap.decrease ? heap[right].CompareTo(heap[largest]) > 0 : heap[right].CompareTo(heap[largest]) < 0) /* > heap[largest] */) // !!!!!!!!!!!!!!!!!!!!!
                largest = right;
            if (largest != i)
            {
                T tmp = heap[i];
                heap[i] = heap[largest];
                heap[largest] = tmp;
                Heapify(largest);
            }
        }
        
        public int Count
        {
            get
            {
                return heap.Count;
            }
        }
        public void Clear()
        {
            heap.Clear();
        }

        /*IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return heap.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // В данном примере не реализован
            throw new NotImplementedException();
            //return body.GetEnumerator();
        }*/
        //[Pure]
        public T[] ToArray()
        {
            return heap.ToArray();
        }

        private List<T> heap;
        private OrderHeap typeOfBinaryHeap;
    }
}
