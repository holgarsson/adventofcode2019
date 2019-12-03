using System;
using System.IO;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string[] input = await File.ReadAllLinesAsync(Path.Combine(Directory.GetCurrentDirectory(), "Puzzles", "puzzle2_0.txt"));

            // First part

        }
    }
}
