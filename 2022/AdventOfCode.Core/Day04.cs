namespace AdventOfCode.Core;

public class Day04 : IAdventOfCodeDay<int, int>
{
	private const string dataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\04.txt";
	private const string testDataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\t04.txt";

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
		var rangePairs = GetRangePairs();
		return rangePairs.Count(x => RangeWithinRange(x.elf1, x.elf2) || RangeWithinRange(x.elf2, x.elf1));
	}

	public int RunEvening()
	{
		var rangePairs = GetRangePairs();
		return rangePairs.Count(x => RangesOverlap(x.elf1, x.elf2) || RangesOverlap(x.elf2, x.elf1));
	}

	private IEnumerable<(Range elf1, Range elf2)> GetRangePairs()
	{
		var results = new List<(Range elf1, Range elf2)>();
		foreach (var line in data)
		{
			var elves = line.Split(',');
			var elf1Data = elves[0].Split("-");
			var elf2Data = elves[1].Split("-");
			var elf1 = new Range(int.Parse(elf1Data[0]), int.Parse(elf1Data[1]));
			var elf2 = new Range(int.Parse(elf2Data[0]), int.Parse(elf2Data[1]));
			results.Add((elf1, elf2));
		}
		return results;
	}

	private static bool RangesOverlap(Range range1, Range range2)
	{
		return range1.Start.Value >= range2.Start.Value && range1.Start.Value <= range2.End.Value
			|| range1.End.Value >= range2.Start.Value && range1.End.Value <= range2.End.Value;
	}
	private static bool RangeWithinRange(Range main, Range toCheck)
	{
		return main.Start.Value <= toCheck.Start.Value && main.End.Value >= toCheck.End.Value;
	}
}