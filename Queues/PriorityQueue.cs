using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class PriorityQueue<TItem, TStruct> : FIFOQueue<TItem, TStruct>
        where TStruct : IQueueable<TItem>
        where TItem : IComparable<TItem>
    {
        public PriorityQueue(TStruct structure) : base(structure) { }
    }
}
