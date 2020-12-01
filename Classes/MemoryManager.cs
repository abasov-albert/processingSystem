namespace Lab2.Classes
{
    public class MemoryManager
    {
        public bool Allocate(long size)
        {
            Memory memory = new Memory(size);
            return true;
        }

        public void Free()
        {
            
        }
    }
}