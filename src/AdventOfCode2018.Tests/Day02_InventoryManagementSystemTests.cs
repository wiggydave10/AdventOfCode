using AdventOfCode2018.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day02_InventoryManagementSystemTests
    {
        [TestMethod]
        public void Day02_InventoryManagementSystemTests_Test()
        {
            var inputs = new string[] { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" };

            var result = Day02_InventoryManagementSystem.Process(inputs);
            result.ShouldBe(12);
        }

        [TestMethod]
        public void Day02_InventoryManagementSystemTests_Answer()
        {
            var ids = TestResourceService.GetFileContentsByFile("Day02.txt");

            var result = Day02_InventoryManagementSystem.Process(ids);
            result.ShouldBe(0);
        }
    }
}
