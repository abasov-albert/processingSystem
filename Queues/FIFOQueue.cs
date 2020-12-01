using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Queues
{
    public class FIFOQueue<TItem, TStruct>: IQueueable<TItem>
        where TStruct : IQueueable<TItem>//, IEnumerable<TItem>
    {
        /// <summary>
        /// constructor: Creation of the PriorityQueue
        /// </summary>
        public FIFOQueue(TStruct structure)
        {
            Contract.Requires<QueueException>(structure != null, "Нарушение контракта: использование пустой ссылки для создания очереди");

            body = structure;
        }

        /// <summary>
        /// require: !empty();
        /// </summary>
        /// <returns>самый приоритетный</returns>
        public TItem Item()
        {
            return body.Item();
        }
        /// <summary>
        /// require: !empty();
        /// ensure: удален 1 элемент с самым высоким приоритетом
        /// </summary>
        public /*FIFOQueue<TItem, TStruct>*/void Remove()
        {
            body.Remove();
            //return this;
        }
        /// <param name="t"></param>
        public /*FIFOQueue<TItem, TStruct>*/void Put(TItem t)
        {
            body.Put(t);
            //return this;
        }
        /// <returns>true если очередь пуста, иначе false </returns>
        [Pure]
        public bool Empty()
        {
            return body.Count == 0;
        }
        /// <returns>размер очереди</returns>
        public int Count
        {
            get
            {
                return body.Count;
            }
        }
        /// <summary>        
        /// ensure: очередь пуста
        /// </summary>
        public /*FIFOQueue<TItem, TStruct>*/void Clear()
        {
            body.Clear();
            //return this;
        }

        public TItem[] ToArray()
        {
            return body.ToArray();
        }

        private TStruct body;
    } 
}
