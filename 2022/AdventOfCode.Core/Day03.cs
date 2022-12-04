namespace AdventOfCode.Core;

public class Day03 : IAdventOfCodeDay<int, int>
{
	private const string dataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\03.txt";
	private const string testDataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\t03.txt";

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
		var rucksacks = GetRucksacks().ToList();
		var commonItems = GetCommonItems(rucksacks).ToList();
		var sum = commonItems.Sum(x => char.IsUpper(x) ? (int)x - 38 : (int)x - 96);
		return sum;
	}

	public int RunEvening()
	{
		throw new NotImplementedException();
	}

	public IEnumerable<char> GetCommonItems(IEnumerable<(string frontCompartment, string backCompartment)> rucksacks)
	{
		var items = new List<char>();
		foreach (var rucksack in rucksacks)
		{
			var item = rucksack.frontCompartment.Where(x => rucksack.backCompartment.Contains(x, StringComparison.InvariantCulture)).First();
			items.Add(item);
		}
		return items;
	}
	public IEnumerable<(string frontCompartment, string backCompartment)> GetRucksacks()
	{
		var rucksacks = new List<(string frontCompartment, string backCompartment)>();
		foreach (var line in data)
		{
			var count = line.Count();
			var half = count / 2;
			var front = line.Substring(0, half);
			var back = line.Substring(half, half);
			rucksacks.Add((front, back));
		}
		return rucksacks;
	}
}