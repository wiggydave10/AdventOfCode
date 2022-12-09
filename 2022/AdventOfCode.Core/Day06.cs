namespace AdventOfCode.Core;

public class Day06 : IAdventOfCodeDay<int[], int[]>
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
		return GetMarkers(4);
	}

	public int[] RunEvening()
	{
		return GetMarkers(14);
	}

	private int[] GetMarkers(int markerLength)
	{
		var results = new List<int>();
		foreach (var line in data)
		{
			var queue = new Queue<char>();
			var totalChars = line.Length;
			var i = 0;
			do
			{
				if (queue.Count >= markerLength)
					queue.Dequeue();
				queue.Enqueue(line[i]);
				i++;
			} while (queue.Distinct().Count() != markerLength && i < totalChars);
			results.Add(i);
		}
		return results.ToArray();
	}
}
