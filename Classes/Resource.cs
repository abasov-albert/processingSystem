namespace Lab2.Classes
{
    public class Resource
    {
        public Process ActiveProcess { get; set; }

        public void WorkingCycle()
        {
            if (ActiveProcess != null)
            {
                ActiveProcess.IncreaseWorkTime();
            }
        }

        public Resource Clear()
        {
            ActiveProcess = null;
            return this;
        }

        public bool Free()
        {
            return ActiveProcess == null;
        }
    }
}