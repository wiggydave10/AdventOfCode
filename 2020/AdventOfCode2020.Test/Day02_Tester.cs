using AdventOfCode2020.Core;
using AdventOfCode2020.Core.Day_02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdventOfCode2020.Test
{
	[TestClass]
	public class Day02_Tester
	{
		private static readonly IProblem problem = new Day02();
		private static readonly string[] input = TestResourceService.GetFileContentsByFile(2);
		private static readonly string[] testInput = new string[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };
		private static readonly int test1Output = 2;
		private static readonly int test2Output = 1;

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