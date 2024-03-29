﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        private static string[] _input => File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Puzzles", "puzzle2_0.txt")).Split(",");

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            if (await VerifyTestInputsPart1() == false)
                return;

            
            int[] intCodes = _input.Select(v => int.Parse(v)).ToArray();

            // First part
            // Replace value at position 1 with 12 and position 2 with 2
            intCodes[1] = 12;
            intCodes[2] = 2;

            intCodes = await RunPart1(intCodes);

            Console.WriteLine($"Part1 - Value at position 0: {intCodes[0]}");

            var foundPart2 = false;
            for (var i = 0; i < 100; i++)
            {
                if (foundPart2 == true)
                    break;

                for (var j = 0; j < 100; j++)
                {
                    var result = await RunPart2(i, j);
                    if (result.Contains("True"))
                    {
                        foundPart2 = true;
                        Console.WriteLine(result);
                    }
                }
            }

            Console.Read();
        }

        static Task<int[]> RunPart1(int[] intCodes)
        {
            int currentPos = 0;

            while (true)
            {
                int opCode;
                opCode = intCodes[currentPos];
                if (opCode == 99)
                    break;

                int storePos = intCodes[currentPos + 3];
                int pos1 = intCodes[currentPos + 1];
                int pos2 = intCodes[currentPos + 2];

                // Addition
                if (opCode == 1)
                {
                    intCodes[storePos] = intCodes[pos1] + intCodes[pos2];
                }
                else if (opCode == 2) // Multiplication
                {
                    intCodes[storePos] = intCodes[pos1] * intCodes[pos2];
                }

                currentPos = currentPos += 4;

            }

            return Task.FromResult(intCodes);
        }

        static async Task<bool> VerifyTestInputsPart1()
        {
            int[] intCodesTest1 = new int[] { 1, 0, 0, 0, 99 };
            if ((await RunPart1(intCodesTest1)).SequenceEqual(new int[] { 2, 0, 0, 0, 99 }) == false)
                return false;

            int[] intCodesTest2 = new int[] { 2, 3, 0, 3, 99 };
            if ((await RunPart1(intCodesTest2)).SequenceEqual(new int[] { 2, 3, 0, 6, 99 }) == false)
                return false;

            int[] intCodesTest3 = new int[] { 2, 4, 4, 5, 99, 0 };
            if ((await RunPart1(intCodesTest3)).SequenceEqual(new int[] { 2, 4, 4, 5, 99, 9801 }) == false)
                return false;

            int[] intCodesTest4 = new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
            if ((await RunPart1(intCodesTest4)).SequenceEqual(new int[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 }) == false)
                return false;

            return true;

        }

        static Task<string> RunPart2(int noun, int verb)
        {
            int[] intCodes = _input.Select(v => int.Parse(v)).ToArray();

            intCodes[1] = noun;
            intCodes[2] = verb;

            int currentPos = 0;

            while (true)
            {
                int opCode;
                opCode = intCodes[currentPos];
                if (opCode == 99)
                    break;

                int storePos = intCodes[currentPos + 3];
                int pos1 = intCodes[currentPos + 1];
                int pos2 = intCodes[currentPos + 2];

                // Addition
                if (opCode == 1)
                {
                    intCodes[storePos] = intCodes[pos1] + intCodes[pos2];
                }
                else if (opCode == 2) // Multiplication
                {
                    intCodes[storePos] = intCodes[pos1] * intCodes[pos2];
                }

                currentPos = currentPos += 4;

            }

            string result = "False";

            if (intCodes[0] == 19690720)
            {
                result = $"True: 100 * {noun} + {verb} = {100*noun+verb}";
            }

            return Task.FromResult(result);
        }
    }
}
