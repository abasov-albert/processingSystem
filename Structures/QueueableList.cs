using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queues;

namespace Structures
{
    public class QueueableList<T> : List<T>, IQueueable<T> 
    {
        public virtual T Item()
        {
            return this[0];
        }
        public virtual void Remove()
        {
            try
            {
                this.RemoveAt(0);
            }
            catch (ArgumentOutOfRangeException)
            {
                new QueueException();
            }
        }
        public virtual void Put(T t)
        {
            this.Add(t);
        }       
    }
}
