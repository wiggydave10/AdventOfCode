using AdventOfCode2018.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day03_NoMatterHowYouSliceItTests
    {
        [TestMethod]
        public void Day03_NoMatterHowYouSliceIt_Part1_Test()
        {
            var testData = new[] { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };

            var result = Day03_NoMatterHowYouSliceIt.Process_Part1(testData);
            result.ShouldBe(4);
        }
        [TestMethod]
        public void Day03_NoMatterHowYouSliceIt_Part1_Answer()
        {
            var testData = TestResourceService.GetFileContentsByFile("Day03.txt");

            var result = Day03_NoMatterHowYouSliceIt.Process_Part1(testData);
            result.ShouldBe(0);
        }

        [TestMethod]
        public void Day03_NoMatterHowYouSliceIt_Part2_Test()
        {
            var testData = new[] { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };

            var result = Day03_NoMatterHowYouSliceIt.Process_Part2(testData);
            result.ShouldBe(3);
        }
        [TestMethod]
        public void Day03_NoMatterHowYouSliceIt_Part2_Answer()
        {
            var testData = TestResourceService.GetFileContentsByFile("Day03.txt");

            var result = Day03_NoMatterHowYouSliceIt.Process_Part2(testData);
            result.ShouldBe(0);
        }
    }
}