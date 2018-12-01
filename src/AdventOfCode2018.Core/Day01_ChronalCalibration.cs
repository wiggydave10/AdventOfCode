// ReSharper disable InconsistentNaming

using System.Collections.Generic;

namespace AdventOfCode2018.Core
{
    public class Day01_ChronalCalibration
    {
        public static int Process_Part1(int startingFrequency, int[] frequencyChanges)
        {
            foreach (var frequencyChange in frequencyChanges)
            {
                startingFrequency += frequencyChange;
            }

            return startingFrequency;
        }

        public static int Process_Part2(int startingFrequency, int[] frequencyChanges)
        {
            var foundFrequencies = new HashSet<int>();

            var foundDuplicate = false;
            while (!foundDuplicate)
            {
                foreach (var frequencyChange in frequencyChanges)
                {
                    startingFrequency += frequencyChange;
                    if (!foundFrequencies.Contains(startingFrequency))
                        foundFrequencies.Add(startingFrequency);
                    else
                    {
                        foundDuplicate = true;
                        break;
                    }
                }
            }

            return startingFrequency;
        }
    }
}
