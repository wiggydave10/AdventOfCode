using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Core.Day_02
{
	public class Day02 : IProblem
	{
		public object SolvePart1(string[] input)
		{
			return CorrectPasswordSecurity(input);
		}

		public object SolvePart2(string[] input)
		{
			return CorrectPasswordSecurityPart2(input);
		}

		private int CorrectPasswordSecurity(string[] passwords) 
		{
			var passwordSecuritys = GetPasswords(passwords);
			return passwordSecuritys.Count(x => x.IsValid);
		}
		private int CorrectPasswordSecurityPart2(string[] passwords)
		{
			var passwordSecuritys = GetPasswords(passwords);
			return passwordSecuritys.Count(x => x.IsValidAndSecure);
		}

		private PasswordSecurity[] GetPasswords(string[] passwords)
		{
			var result = new List<PasswordSecurity>();
			foreach (var password in passwords)
			{
				var sections = password.Split(' ');
				// 1-3 a: abcde
				var amount = GetAmount(sections[0]);
				var positions = GetPositions(sections[0]);
				var character = sections[1].First();
				var enteredPassword = sections[2];
				result.Add(new PasswordSecurity()
				{
					AmountOfTimes = amount,
					Positions = positions,
					Character = character,
					Password = enteredPassword
				});
			}
			return result.ToArray();
		}

		private int[] GetAmount(string amount)
		{
			var amounts = amount.Split('-');
			var min = int.Parse(amounts[0]);
			var max = int.Parse(amounts[1]);
			return Enumerable.Range(min, max - min + 1).ToArray();
		}
		private int[] GetPositions(string amount)
		{
			var amounts = amount.Split('-');
			var min = int.Parse(amounts[0]);
			var max = int.Parse(amounts[1]);
			return new[] { min - 1, max - 1 };
		}
	}

	public class PasswordSecurity
	{
		public int[] AmountOfTimes { get; set; }
		public int[] Positions { get; set; }
		public char Character { get; set; }
		public string Password { get; set; }

		public bool IsValid => AmountOfTimes.Contains(Password.Count(x => Character == x));
		public bool IsValidAndSecure => (Password[Positions[0]] == Character && Password[Positions[1]] != Character)
											|| (Password[Positions[0]] != Character && Password[Positions[1]] == Character);
	}
}