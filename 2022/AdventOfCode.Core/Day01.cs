namespace AdventOfCode.Core;

public class Day01 : IAdventOfCodeDay<int>
{
    private const string dataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\01.txt";
    private const string testDataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\t01.txt";

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

    public int RunDay()
    {
        var dict = new Dictionary<int, int>();
        var currentElf = 1;

        dict.Add(currentElf, 0);
        foreach (var line in data)
        {
            if (string.IsNullOrWhiteSpace(line))
            { 
                currentElf++;
                dict.Add(currentElf, 0);
                continue;
            }

            dict[currentElf] += int.Parse(line);
        }
        return dict.OrderByDescending(x => x.Value).First().Value;
    }
}
