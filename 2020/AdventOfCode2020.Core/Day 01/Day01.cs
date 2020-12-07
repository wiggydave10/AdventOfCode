using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Core.Day_01
{
	public class Day01 : IProblem
	{
		public object SolvePart1(string[] input)
		{
			var numbers = GetNumbers(input);
			var counter = 0;
			int? result = null;
			do
			{
				var number = numbers.ElementAt(counter);
				var remainder = 2020 - number;
				if (numbers.Contains(remainder))
					result = number * remainder;
				counter++;
			} while (!result.HasValue);
			return result.Value;
		}

		public object SolvePart2(string[] input)
		{
			var numbers = GetNumbers(input);
			int? result = null;
			for (int i1 = 0; !result.HasValue && i1 < numbers.Count; i1++)
			{
				var number = numbers.ElementAt(i1);
				for (int i2 = i1 + 1; !result.HasValue && i2 < numbers.Count; i2++)
				{
					var number2 = numbers.ElementAt(i2);
					var remainder = 2020 - number - number2;
					if (numbers.Contains(remainder))
						result = number * number2 * remainder;
				}
			}
			return result.Value;
		}

		private ISet<int> GetNumbers(string[] input)
		{
			return input.Select(int.Parse).ToHashSet();
		}
	}
}