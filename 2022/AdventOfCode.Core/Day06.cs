namespace AdventOfCode.Core;

public class Day06 : IAdventOfCodeDay<int[], int>
{
	private const string dataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\06.txt";
	private const string testDataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\t06.txt";

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

	public int[] RunMorning()
	{
		var results = new List<int>();
		foreach (var line in data)
		{
			var queue = new Queue<char>();
			var totalChars = line.Length;
			var i = 0;
			do
			{
				if (queue.Count >= 4)
					queue.Dequeue();
				queue.Enqueue(line[i]);
				i++;
			} while (queue.Distinct().Count() != 4 && i < totalChars);
			results.Add(i);
		}
		return results.ToArray();
	}

	public int RunEvening()
	{
		throw new NotImplementedException();
	}
}
