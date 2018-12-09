using AdventOfCode2018.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day04_ReposeRecordTests
    {
        [TestMethod]
        public void Day04_ReposeRecordTests_Part1_Test()
        {
            var testData = new[]
            {
                "[1518 - 11 - 01 00:00] Guard #10 begins shift",
                "[1518 - 11 - 01 00:05] falls asleep",
                "[1518 - 11 - 01 00:25] wakes up",
                "[1518 - 11 - 01 00:30] falls asleep",
                "[1518 - 11 - 01 00:55] wakes up",
                "[1518 - 11 - 01 23:58] Guard #99 begins shift",
                "[1518 - 11 - 02 00:40] falls asleep",
                "[1518 - 11 - 02 00:50] wakes up",
                "[1518 - 11 - 03 00:05] Guard #10 begins shift",
                "[1518 - 11 - 03 00:24] falls asleep",
                "[1518 - 11 - 03 00:29] wakes up",
                "[1518 - 11 - 04 00:02] Guard #99 begins shift",
                "[1518 - 11 - 04 00:36] falls asleep",
                "[1518 - 11 - 04 00:46] wakes up",
                "[1518 - 11 - 05 00:03] Guard #99 begins shift",
                "[1518 - 11 - 05 00:45] falls asleep",
                "[1518 - 11 - 05 00:55] wakes up"
            };
            var result = Day04_ReposeRecord.Process_Part1(testData);
            result.ShouldBe(240);
        }
        [TestMethod]
        public void Day04_ReposeRecordTests_Part1_Answer()
        {
            var testData = TestResourceService.GetFileContentsByFile("Day04.txt");

            var result = Day04_ReposeRecord.Process_Part1(testData);
            result.ShouldBe(0);
        }

        [TestMethod]
        public void Day04_ReposeRecordTests_Part2_Test()
        {
            var testData = new[]
            {
                "[1518 - 11 - 01 00:00] Guard #10 begins shift",
                "[1518 - 11 - 01 00:05] falls asleep",
                "[1518 - 11 - 01 00:25] wakes up",
                "[1518 - 11 - 01 00:30] falls asleep",
                "[1518 - 11 - 01 00:55] wakes up",
                "[1518 - 11 - 01 23:58] Guard #99 begins shift",
                "[1518 - 11 - 02 00:40] falls asleep",
                "[1518 - 11 - 02 00:50] wakes up",
                "[1518 - 11 - 03 00:05] Guard #10 begins shift",
                "[1518 - 11 - 03 00:24] falls asleep",
                "[1518 - 11 - 03 00:29] wakes up",
                "[1518 - 11 - 04 00:02] Guard #99 begins shift",
                "[1518 - 11 - 04 00:36] falls asleep",
                "[1518 - 11 - 04 00:46] wakes up",
                "[1518 - 11 - 05 00:03] Guard #99 begins shift",
                "[1518 - 11 - 05 00:45] falls asleep",
                "[1518 - 11 - 05 00:55] wakes up"
            };
            var result = Day04_ReposeRecord.Process_Part2(testData);
            result.ShouldBe(4455);
        }
        [TestMethod]
        public void Day04_ReposeRecordTests_Part2_Answer()
        {
            var testData = TestResourceService.GetFileContentsByFile("Day04.txt");

            var result = Day04_ReposeRecord.Process_Part2(testData);
            result.ShouldBe(0);
        }
    }
}