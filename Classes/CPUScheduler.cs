using Queues;

namespace Lab2.Classes
{
    public class CPUScheduler
    {
        Resource Session(Resource cpu, PriorityQueue<Process, IQueueable<Process>> readyQueue)
        {
            if (readyQueue != null)
            {
                cpu.ActiveProcess = readyQueue.Item();
            } 
            return cpu;
        }
    }
}