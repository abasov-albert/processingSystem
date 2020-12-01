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
            var processCharacteristics = process.toArray();
            foreach (var i in processCharacteristics)
            {
                Console.WriteLine(i);
            }
        }
    }
}