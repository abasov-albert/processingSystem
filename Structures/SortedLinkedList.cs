using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Diagnostics.Contracts;

namespace Structures
{
    public class SortedLinkedList<T> : QueueableLinkedList<T>
        where T: IComparable<T>
    {
        public override void Put(T t)
        {
            if (this.Count == 0 || t.CompareTo(this.Last.Value) <= 0)
                base.Put(t);
            else
            {
                LinkedListNode<T> curr = this.First;
                for (; curr.Value.CompareTo(t) > 0; curr = curr.Next);
                this.AddBefore(curr, t);
            }
        }
    }
}
