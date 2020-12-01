namespace Lab2.Classes
{
    public class Settings
    {
        public double Intensity { get; set; }
        public int MinValueOfBurstTime { get; set; }
        public int MaxValueOfBurstTime { get; set; }
        public int MinValueOfAddrSpace { get; set; }
        public int MaxValueOfAddrSpace { get; set; }
        public int RAMSize { get; set; }

        public void Save(double intens, int btMin, int btMax)
        {
            Intensity = intens;
            MinValueOfBurstTime = btMin;
            MaxValueOfBurstTime = btMax;
        }

        public void Clear()
        {
            Intensity = 0;
            MinValueOfBurstTime = 0;
            MaxValueOfBurstTime = 0;
            MinValueOfAddrSpace = 0;
            MaxValueOfAddrSpace = 0;
        }

        public string[] toArray()
        {
            return ToString().Split(", ");
        }

        public override string ToString()
        {
            return
                $"{nameof(Intensity)}: {Intensity}," +
                $" {nameof(MinValueOfBurstTime)}: {MinValueOfBurstTime}," +
                $" {nameof(MaxValueOfBurstTime)}: {MaxValueOfBurstTime}," +
                $" {nameof(MinValueOfAddrSpace)}: {MinValueOfAddrSpace}," +
                $" {nameof(MaxValueOfAddrSpace)}: {MaxValueOfAddrSpace}," +
                $" {nameof(RAMSize)}: {RAMSize}";
        }
    }
}