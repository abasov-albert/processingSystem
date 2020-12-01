namespace Lab2.Classes
{
    public class SystemClock
    {
        private long Clock { get; set; }

        public void WorkingCycle()
        {
            Clock++;
        } 

        public void Clear()
        {
            Clock = 0;
        }
    }
}