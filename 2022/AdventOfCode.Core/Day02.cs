namespace AdventOfCode.Core;

public class Day02 : IAdventOfCodeDay<int, int>
{
	private const string dataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\02.txt";
	private const string testDataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\t02.txt";
	private static readonly RockPaperScissorType[] playTypes = Enum.GetValues<RockPaperScissorType>();
	private static readonly IDictionary<RockPaperScissorType, RockPaperScissorType> winning
		= new Dictionary<RockPaperScissorType, RockPaperScissorType>() {
			{ RockPaperScissorType.Rock, RockPaperScissorType.Paper },
			{ RockPaperScissorType.Paper, RockPaperScissorType.Scissors },
			{ RockPaperScissorType.Scissors, RockPaperScissorType.Rock },
		};

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
		var games = GetGames(false);
		return games.Sum(x => (int)x.self + (int)x.result);
	}

	public int RunEvening()
	{
		var games = GetGames(true);
		return games.Sum(x => (int)x.self + (int)x.result);
	}

	private List<(RockPaperScissorType opponent, RockPaperScissorType self, RoundResultType result)> GetGames(bool isGameResult)
	{
		var result = new List<(RockPaperScissorType opponent, RockPaperScissorType self, RoundResultType result)>();
		foreach (var line in data)
		{
			var round = line.Split(' ');
			var opponent = GetPlayType(round[0].Trim());
			RockPaperScissorType self;
			RoundResultType roundResult;
			if (isGameResult)
			{
				roundResult = GetRoundResult(round[1].Trim());
				self = GetPlayType(opponent, roundResult);
			}
			else
			{
				self = GetPlayType(round[1].Trim());
				roundResult = GetRoundResult(opponent, self);
			}
			result.Add((opponent, self, roundResult));
		}
		return result;
	}

	private static RoundResultType GetRoundResult(RockPaperScissorType opponent, RockPaperScissorType self)
	{
		if (opponent == self)
			return RoundResultType.Draw;

		if (winning[opponent] == self)
			return RoundResultType.Win;
		return RoundResultType.Loss;
	}

	private static RoundResultType GetRoundResult(string result)
	{
		return result switch
		{
			"X" => RoundResultType.Loss,
			"Y" => RoundResultType.Draw,
			"Z" => RoundResultType.Win,
			_ => throw new ArgumentOutOfRangeException(nameof(result), "Incorrect value"),
		};
	}

	private static RockPaperScissorType GetPlayType(string play)
	{
		return play switch
		{
			"A" or "X" => RockPaperScissorType.Rock,
			"B" or "Y" => RockPaperScissorType.Paper,
			"C" or "Z" => RockPaperScissorType.Scissors,
			_ => throw new ArgumentOutOfRangeException(nameof(play), "Incorrect value"),
		};
	}

	private static RockPaperScissorType GetPlayType(RockPaperScissorType opponent, RoundResultType result)
	{
		if (result == RoundResultType.Draw)
			return opponent;

		var winnerPlay = winning[opponent];
		if (result == RoundResultType.Win)
			return winnerPlay;
		return playTypes.Where(x => x != opponent && x != winnerPlay).First();
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