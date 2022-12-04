namespace AdventOfCode.Core;

public class Day02 : IAdventOfCodeDay<int, int>
{
	private const string dataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\02.txt";
	private const string testDataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\t02.txt";

	private string[] data;

	public async Task PrepData()
	{
		var lines = await File.ReadAllLinesAsync(dataFile);
		data = lines;
	}

	public async Task PrepTestData()
	{
		var lines = await File.ReadAllLinesAsync(testDataFile);
		data = lines;
	}

	public int RunMorning()
	{
		var games = GetGames();
		return games.Sum(x => (int)x.self + (int)x.result);
	}

	public int RunEvening()
	{
		throw new NotImplementedException();
	}

	private List<(RockPaperScissorType opponent, RockPaperScissorType self, RoundResultType result)> GetGames()
	{
		var result = new List<(RockPaperScissorType opponent, RockPaperScissorType self, RoundResultType result)>();
		foreach (var line in data)
		{
			var round = line.Split(' ');
			var opponent = GetPlayType(round[0].Trim()); 
			var self = GetPlayType(round[1].Trim());
			var roundResult = GetRoundResult(opponent, self);
			result.Add((opponent, self, roundResult));
		}

		return result;

		RoundResultType GetRoundResult(RockPaperScissorType opponent, RockPaperScissorType self)
		{
			if (opponent == self)
				return RoundResultType.Draw;

			return opponent switch
			{
				RockPaperScissorType.Rock when self == RockPaperScissorType.Paper => RoundResultType.Win,
				RockPaperScissorType.Paper when self == RockPaperScissorType.Scissors => RoundResultType.Win,
				RockPaperScissorType.Scissors when self == RockPaperScissorType.Rock => RoundResultType.Win,
				_ => RoundResultType.Loss
			};
		}
		RockPaperScissorType GetPlayType(string play)
		{
			return play switch
			{
				"A" or "X" => RockPaperScissorType.Rock,
				"B" or "Y" => RockPaperScissorType.Paper,
				"C" or "Z" => RockPaperScissorType.Scissors,
				_ => throw new ArgumentOutOfRangeException(nameof(play), "Incorrect value"),
			};
		}

	}
}

internal enum RockPaperScissorType
{
	Rock = 1,
	Paper = 2,
	Scissors = 3,
}
internal enum RoundResultType
{
	Loss = 0,
	Draw = 3,
	Win = 6
}