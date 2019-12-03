using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string[] massInput = await File.ReadAllLinesAsync(Path.Combine(Directory.GetCurrentDirectory(), "Puzzles", "puzzle1_0.txt"));

            // First part
            int result = massInput.Select(m => CalculateFuel(int.Parse(m))).Sum();
            Console.WriteLine($"Total sum of fuel: {result}");

            // Second part
            int result2 = massInput.Select(m => CalculateFuelPart2(int.Parse(m))).Sum();
            Console.WriteLine($"Total sum of fuel part 2: {result2}");
        }

        private static int CalculateFuel(int mass)
        {
            return (int)Math.Floor((decimal)mass / 3) - 2;
        }

        private static int CalculateFuelPart2(int mass)
        {
            int fuel = 0;
            int currentMass = mass;
            while (currentMass >= 0)
            {
                currentMass = (int)Math.Floor((decimal)currentMass / 3) - 2;
                if (currentMass <= 0)
                    break;

                fuel += currentMass;
            }

            return fuel;
        }
    }
}
