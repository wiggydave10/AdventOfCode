using AdventOfCode2018.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day02_InventoryManagementSystemTests
    {
        [TestMethod]
        public void Day02_InventoryManagementSystemTests_Part1_Test()
        {
            var inputs = new[] { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" };

            var result = Day02_InventoryManagementSystem.Process_Part1(inputs);
            result.ShouldBe(12);
        }

        [TestMethod]
        public void Day02_InventoryManagementSystemTests_Part1_Answer()
        {
            var ids = TestResourceService.GetFileContentsByFile("Day02.txt");

            var result = Day02_InventoryManagementSystem.Process_Part1(ids);
            result.ShouldBe(0);
        }

        [TestMethod]
        public void Day02_InventoryManagementSystemTests_Part2_Test()
        {
            var inputs = new[] { "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz" };

            var result = Day02_InventoryManagementSystem.Process_Part2(inputs);
            result.ShouldBe("fgij");
        }

        [TestMethod]
        public void Day02_InventoryManagementSystemTests_Part2_Answer()
        {
            var ids = TestResourceService.GetFileContentsByFile("Day02.txt");

            var result = Day02_InventoryManagementSystem.Process_Part2(ids);
            result.ShouldBe("");
        }
    }
}
