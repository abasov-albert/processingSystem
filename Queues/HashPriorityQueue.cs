using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structures;

namespace Queues
{
    class HashPriorityQueue<TItem/*, TStruct*/>
        where TItem: IHavingPriority
        //where TStruct: IQueueable<TItem>, new()        
    {
        HashPriorityQueue(int priorityMax/*, TStruct structure*/)
        {
            this.priorityMax = priorityMax;
            body = new FIFOQueue<TItem, IQueueable<TItem>>[priorityMax + 1];
            //this.FIFOQueueStructure = structure;
            /*for (int i = 0; i < priorityRange; i++)
                //body[i] = new FIFOQueue<TItem, TStruct>(new TStruct());
                body[i] = null;*/
        }
        public TItem Item()
        {
            if (count == 0)
                throw new QueueException("Попытка чтения из пустой очереди");
            return body[highestPriority].Item();
        }
        public HashPriorityQueue<TItem/*, TStruct*/> Remove()
        {
            if (count == 0)
                throw new QueueException("Попытка удаления из пустой очереди");
            body[highestPriority].Remove();
            count--;
            if (body[highestPriority].Empty())
                //if (count > 0)
                    findHighestPriority();
            return this;
        }
        public HashPriorityQueue<TItem/*, TStruct*/> Put(TItem t)
        {
            int queueNum = t.Priority;
            if (body[queueNum] == null)
                body[queueNum] = new FIFOQueue<TItem, IQueueable<TItem>>(new QueueableLinkedList<TItem>());
            body[queueNum].Put(t);
            count++;
            if (count == 1)
                highestPriority = queueNum;
            else
            {
                /*if (queueNum < minPriorityNum)
                    minPriorityNum = queueNum;*/
                if (queueNum < highestPriority)
                    highestPriority = queueNum;
            }
            return this;
        }
        public bool Empty()
        {
            return count == 0;
        }
        public void Clear()
        {
            Array.Clear(body, 0,  priorityMax + 1);
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
        public TItem[] ToArray()
        {
            TItem[] arr = new TItem[count];
            int current = 0;
            for (int i = highestPriority; i <= priorityMax; i++)
                foreach (TItem t in body[i].ToArray())
                    arr[current++] = t;
            return arr;
        }

        FIFOQueue<TItem, IQueueable<TItem>>[] body;
        private int priorityMax;

        private int highestPriority;

        //private TStruct FIFOQueueStructure;
        private int count;        
        //private int minPriorityNum;

        private void findHighestPriority()
        {
            if(this.Empty())
                return;
            while (body[highestPriority] == null || body[highestPriority].Empty())
                highestPriority++;
        }
        /*private void findLowestPriority()
        {
            if (count == 0)
                return;
            while (body[highestPriority].Count == 0)
                highestPriority--;
        }*/
    }    
}
