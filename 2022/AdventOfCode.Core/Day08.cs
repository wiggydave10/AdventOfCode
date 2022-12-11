namespace AdventOfCode.Core;

public class Day08 : IAdventOfCodeDay<int, int>
{
	private const string dataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\08.txt";
	private const string testDataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\t08.txt";

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
		var forest = GetForest();
		var outerTrees = CalculateOuterTrees(forest);
		var visibleInnerTrees = CalculateVisibleInnerTrees(forest);
		return outerTrees + visibleInnerTrees;
	}

	public int RunEvening()
	{
		throw new NotImplementedException();
	}

	private int CalculateVisibleInnerTrees(int[][] forest)
	{
		var totalTrees = 0;
		var maxX = forest[0].Length - 1;
		var maxY = forest.Length - 1;

		for (int yI = 1; yI < maxY; yI++)
		{
			int[] item = forest[yI];
			for (int xI = 1; xI < maxX; xI++)
			{
				var tree = item[xI];
				var tallestXLeft = GetTallestTreeInX(forest, xI, yI, false);
				var tallestXRight = GetTallestTreeInX(forest, xI, yI, true);
				var tallestYTop = GetTallestTreeInY(forest, xI, yI, false);
				var tallestYBottom = GetTallestTreeInY(forest, xI, yI, true);
				if (tree > tallestXLeft || tree > tallestXRight || tree > tallestYTop || tree > tallestYBottom)
					totalTrees++;
			}
		}
		return totalTrees;
	}

	private int CalculateOuterTrees(int[][] forest)
	{
		var row = forest[0].Length;
		var column = forest.Length;
		// Top + Left (- top left 1) + Bottom (- bottom left 1) + Right (- top and bottom 1)
		return row + (column - 1) + (row - 1) + (column - 2);
	}

	private static int GetTallestTreeInX(int[][] forest, int x, int y, bool fromRight)
	{
		var row = forest[y];
		return row.Where((t, index) => fromRight ? index > x : index < x).Max();
	}
	private static int GetTallestTreeInY(int[][] forest, int x, int y, bool fromBottom)
	{
		var column = forest.Where((t,index) => fromBottom ? index > y : index < y).Select(t => t[x]);
		return column.Max();
	}

	private int[][] GetForest()
	{
		var firstLineLength = data.First().Length;
		var result = new int[data.Count()][];
		for (int lI = 0; lI < data.Length; lI++)
		{
			string? line = data[lI];
			var rowData = new int[firstLineLength];
			for (int tI = 0; tI < line.Length; tI++)
			{
				char tree = line[tI];
				rowData[tI] = int.Parse(tree.ToString());
			}
			result[lI] = rowData;
		}
		return result;
	}
}
