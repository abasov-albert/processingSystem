using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Diagnostics.Contracts;

namespace Structures
{
    public class SimpleArray<T> : QueueableList<T>
        where T: IComparable<T>
    {
        public override T Item()
        {
            return this[maxPriorityNo];
        }
        public override void Remove()
        {
            this.RemoveAt(maxPriorityNo);
            if (this.Count == 0)
                return;
            T max = this[0];
            maxPriorityNo = 0;
            for (int i = 1; i < this.Count; i++)
            {
                if (this[i].CompareTo(max) > 0)
                {
                    max = this[i];
                    maxPriorityNo = i;
                }
            }
        }
        public override void Put(T t)
        {
            base.Put(t);
            if (this.Count == 1)
                maxPriorityNo = 0;
            else
                if(t.CompareTo(this[maxPriorityNo]) > 0)
                    maxPriorityNo = this.Count - 1;
        }
       
        private int maxPriorityNo;
    }
}
