using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Diagnostics.Contracts;
//using Queues;

namespace Structures
{
    public class SortedArray<T> : QueueableList<T>
        where T : IComparable<T>
    {
        public override void Put(T t)
        {
            if (this.Count == 0 || t.CompareTo(this[this.Count - 1]) <= 0)
                base.Put(t);
            else
                if (t.CompareTo(this[0]) > 0)
                    this.Insert(0, t);
                else
                    addOrdered(t, 0, this.Count - 1);
        }
        
        private void addOrdered(T t, int begin, int end)
        {
            if (begin >= end)
                if (this[begin].CompareTo(t) < 0)
                    this.Insert(end, t);
                else
                    this.Insert(end + 1, t);
            else
            {
                int middle = (end + begin) / 2;
                if (t.CompareTo(this[middle]) == 0)
                {
                    while (middle <= end && t.CompareTo(this[middle]) == 0)
                        middle++;
                    if (middle == end + 1)
                        this.Add(t);
                    else
                        this.Insert(middle, t);
                }
                else
                    if (t.CompareTo(this[middle]) < 0)
                        addOrdered(t, middle + 1, end);
                    else
                        addOrdered(t, begin, middle - 1);
            }
        }
    }
}
