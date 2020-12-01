using Queues;

namespace Lab2.Classes
{
    public class DeviceScheduler
    {
        Resource Session(Resource device, FIFOQueue<Process, IQueueable<Process>> deviceQueue)
        {
            if (deviceQueue != null)
            {
                device.ActiveProcess = deviceQueue.Item();
            }

            return device;
        }
    }
}