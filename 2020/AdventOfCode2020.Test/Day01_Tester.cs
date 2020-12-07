using AdventOfCode2020.Core;
using AdventOfCode2020.Core.Day_01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdventOfCode2020.Test
{
	[TestClass]
	public class Day01_Tester
	{
		private static IProblem problem = new Day01();
		private static string[] input = TestResourceService.GetFileContentsByFile(1, 1);
		private static string[] testInput = new string[] { "1721", "979", "366", "299", "675", "1456" };
		private static int test1Output = 514579;
		private static int test2Output = 241861950;

		[TestMethod]
		public void Answer_1()
		{
			var result = problem.SolvePart1(input);
			result.ShouldBe(0);
		}
		[TestMethod]
		public void Answer_2()
		{
			var result = problem.SolvePart2(input);
			result.ShouldBe(0);
		}

		[TestMethod]
		public void Test_1()
		{
			var result = problem.SolvePart1(testInput);
			result.ShouldBe(test1Output);
		}
		[TestMethod]
		public void Test_2()
		{
			var result = problem.SolvePart2(testInput);
			result.ShouldBe(test2Output);
		}
	}
}