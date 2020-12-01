using System;
using System.Collections.Generic;

namespace Lab2.Classes
{
    public enum ProcessStatus
    {
        Ready,
        Running,
        Waiting
    }

    public class Process : IComparable<Process>
    {
        private long id;
        private string name;
        public long BurstTime { get; set; }
        public ProcessStatus Status { get; set; }
        private long workTime;
        private long commonWorkTime;
        private long ArrivalTime { get; }
        private long CommonWaitingTime { get; set; }
        private long ReadyQueueArrivalTime { get; set; }
        private long AddrSpace { get; }

        public Process(long startTime, long pId, long addrSpace)
        {
            ArrivalTime = startTime;
            id = pId;
            name = "process " + id;
            Status = ProcessStatus.Ready;
            AddrSpace = addrSpace;
        }

        public void IncreaseWorkTime()
        {
            workTime++;
        }

        public string[] toArray()
        {
            return ToString().Split(", ");
        }

        public int CompareTo(Process other)
        {
            return this.id.CompareTo(other.id);
        }

        public override string ToString()
        {
            return
                $"{nameof(id)}: {id}, " +
                $"{nameof(name)}: {name}, " +
                $"{nameof(workTime)}: {workTime}, " +
                $"{nameof(commonWorkTime)}: {commonWorkTime}, " +
                $"{nameof(BurstTime)}: {BurstTime}, " +
                $"{nameof(Status)}: {Status}, " +
                $"{nameof(ArrivalTime)}: {ArrivalTime}, " +
                $"{nameof(CommonWaitingTime)}: {CommonWaitingTime}, " +
                $"{nameof(ReadyQueueArrivalTime)}: {ReadyQueueArrivalTime}, " +
                $"{nameof(AddrSpace)}: {AddrSpace}";
        }
    }
}