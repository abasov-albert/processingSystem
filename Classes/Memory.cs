namespace Lab2.Classes
{
    public class Memory
    {
        private long Size { get; set; }

        public Memory(long size)
        {
            Size = size;
        }

        public void Clear()
        {
            Size = 0;
        }
    }
}