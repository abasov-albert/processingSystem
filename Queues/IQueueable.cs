using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Queues
{
    /// <summary>
    /// Queue interface
    /// </summary>
    [ContractClass(typeof(QueueContract<>))]
    public interface IQueueable<T>
    {
        T Item();
        void Put(T t);
        void Remove();

        int Count { get; }
        void Clear();

        //temporary
        T[] ToArray();
    }
}
