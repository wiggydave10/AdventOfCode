using AdventOfCode2018.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day05_AlchemicalReductionTests
    {
        [TestMethod]
        [DynamicData(nameof(Part1_TestData))]
        public void Day05_AlchemicalReductionTests_Part1_Test(string polymer, int expectedChainLength)
        {
            var chainResult = Day05_AlchemicalReduction.Process_Part1(polymer);
            chainResult.ShouldBe(expectedChainLength);
        }
        [TestMethod]
        public void Day05_AlchemicalReductionTests_Part1_Answer()
        {
            var testData = TestResourceService.GetFileContentsByFile("Day05.txt");

            var result = Day05_AlchemicalReduction.Process_Part1(testData[0]);
            result.ShouldBe(0);
        }


        [TestMethod]
        [DynamicData(nameof(Part2_TestData))]
        public void Day05_AlchemicalReductionTests_Part2_Test(string polymer, int expectedChainLength)
        {
            var chainResult = Day05_AlchemicalReduction.Process_Part2(polymer);
            chainResult.ShouldBe(expectedChainLength);
        }
        [TestMethod]
        public void Day05_AlchemicalReductionTests_Part2_Answer()
        {
            var testData = TestResourceService.GetFileContentsByFile("Day05.txt");

            var result = Day05_AlchemicalReduction.Process_Part2(testData[0]);
            result.ShouldBe(0);
        }



        public static IEnumerable<object[]> Part1_TestData => new List<object[]>
        {
            new object[] { "aA", 0 },
            new object[] { "abBA", 0 },
            new object[] { "abAB", 4 },
            new object[] { "aabAAB", 6 },
            new object[] { "dabAcCaCBAcCcaDA", 10 },
        };

        public static IEnumerable<object[]> Part2_TestData => new List<object[]>
        {
            new object[] { "dabAcCaCBAcCcaDA", 4 },
        };
    }
}