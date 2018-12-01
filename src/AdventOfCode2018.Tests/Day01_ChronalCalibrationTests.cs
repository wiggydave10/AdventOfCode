using AdventOfCode2018.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.IO;
using System.Linq;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day01_ChronalCalibrationTests
    {
        [TestMethod]
        public void Day01_ChronalCalibrationTests_Part1_Test()
        {
            var startingFreq = 0;
            var frequencyChanges = new[] { +1, -2, +3, +1 };
            var result = Day01_ChronalCalibration.Process_Part1(startingFreq, frequencyChanges);

            result.ShouldBe(3);
        }

        [TestMethod]
        public void Day01_ChronalCalibrationTests_Part1_Answer()
        {
            var stringNumbers = File.ReadAllLines(TestResourceService.GetFilePath("Day01.txt"));

            var startingFreq = 0;
            var frequencyChanges = stringNumbers.Select(int.Parse).ToArray();
            var result = Day01_ChronalCalibration.Process_Part1(startingFreq, frequencyChanges);

            result.ShouldBe(0);
        }

        [TestMethod]
        public void Day01_ChronalCalibrationTests_Part2_Test()
        {
            //var startingFreq = 0;
            //var frequencyChanges = new[] { +1, -2, +3, +1 };
            //var result = Day01_ChronalCalibration.Process(startingFreq, frequencyChanges);

            //result.ShouldBe(3);
        }

        [TestMethod]
        public void Day01_ChronalCalibrationTests_Part2_Answer()
        {
            //var stringNumbers = File.ReadAllLines(TestResourceService.GetFilePath("Day01.txt"));

            //var startingFreq = 0;
            //var frequencyChanges = stringNumbers.Select(int.Parse).ToArray();
            //var result = Day01_ChronalCalibration.Process(startingFreq, frequencyChanges);

            //result.ShouldBe(0);
        }
    }
}