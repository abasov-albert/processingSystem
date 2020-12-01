using System;
using Lab2.Classes;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process(DateTime.UtcNow.Millisecond, 1, 11001);
            Console.WriteLine(process.ToString());
            Console.WriteLine();
            foreach (var i in process.toArray())
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            
            Settings settings = new Settings();
            settings.Intensity = 12.7;
            settings.RAMSize = 32;
            settings.MaxValueOfAddrSpace = 11;
            
            foreach (var i in settings.toArray())
            {
                Console.WriteLine(i);    
            }
            
            // Izi Kura 
        }
    }
}