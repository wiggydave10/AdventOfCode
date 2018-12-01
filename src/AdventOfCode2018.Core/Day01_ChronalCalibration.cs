// ReSharper disable InconsistentNaming

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

        //public static void Process_Part2()
        //{

        //}
    }
}
