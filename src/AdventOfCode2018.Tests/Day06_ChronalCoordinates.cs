using AdventOfCode2018.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day06_ChronalCoordinatesTests
    {
        [TestMethod]
        [DynamicData(nameof(Part1_TestData))]
        public void Day06_ChronalCoordinatesTests_Part1_Test(string[] coordinates, int mostClaimedSpace)
        {
            var maxSpace = Day06_ChronalCoordinates.Process_Part1(coordinates);
            maxSpace.ShouldBe(mostClaimedSpace);
        }

        [TestMethod]
        public void Day06_ChronalCoordinatesTests_Part1_Answer()
        {
            var testData = TestResourceService.GetFileContentsByFile("Day06.txt");

            var maxSpace = Day06_ChronalCoordinates.Process_Part1(testData);
            maxSpace.ShouldBe(0);
        }


        public static IEnumerable<object[]> Part1_TestData => new List<object[]>
        {
            new object[] { new string[] { "1, 1", "1, 6", "8, 3", "3, 4", "5, 5", "8, 9" }, 17 }
        };
    }
}