using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Diagnostics.Contracts;

namespace Structures
{
    public class SimpleLinkedList<T> : QueueableLinkedList<T>
        where T: IComparable<T>
    {
        public override T Item()
        {
            return maxPriorityRef.Value;
        }
        public override void Remove()
        {
            this.Remove(maxPriorityRef);
            if (this.Count == 0)
            {
                maxPriorityRef = null;
                return;
            }
            T max = this.First.Value;
            LinkedListNode < T > i = this.First;
            maxPriorityRef = i;
            for (; i != null; i = i.Next)
            {
                if (i.Value.CompareTo(max) > 0)
                {
                    max = i.Value;
                    maxPriorityRef = i;
                }
            }            
        }
        public override void Put(T t)
        {           
            base.Put(t);
            if (this.Count == 1)
                maxPriorityRef = this.First;
            else
                if(t.CompareTo(maxPriorityRef.Value) > 0)
                    maxPriorityRef = this.Last;
        }
        
        LinkedListNode<T> maxPriorityRef;
    }
}
