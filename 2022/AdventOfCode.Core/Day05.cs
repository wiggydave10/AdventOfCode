namespace AdventOfCode.Core;

public class Day05 : IAdventOfCodeDay<string, int>
{
	private const string dataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\05.txt";
	private const string testDataFile = "C:\\Dev\\AdventOfCode\\2022\\AdventOfCode.Core\\data\\t05.txt";

	private string[] data;
	private string[] configData => data.TakeWhile(x => !string.IsNullOrWhiteSpace(x)).ToArray();
	private string[] commandData => data.SkipWhile(x => !string.IsNullOrWhiteSpace(x)).Skip(1).ToArray();

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

	public string RunMorning()
	{
		var stacks = GetStacks();
		stacks = RunCommands(stacks);
		return string.Join("", stacks.Select(x => x.Peek()));
	}

	public int RunEvening()
	{
		throw new NotImplementedException();
	}

	private IEnumerable<Stack<char>> RunCommands(IEnumerable<Stack<char>> stacks)
	{
		foreach (var command in commandData)
		{
			//move 1 from 2 to 1
			var data = command.Split(' ');
			var amount = int.Parse(data[1]);
			var from = int.Parse(data[3]) - 1;
			var to = int.Parse(data[5]) - 1;
			
			var fromStack = stacks.ElementAt(from);
			var toStack = stacks.ElementAt(to);
			for (int i = 0; i < amount; i++)
			{
				var container = fromStack.Pop();
				toStack.Push(container);
			}
		}
		return stacks;
	}

	private IEnumerable<Stack<char>> GetStacks()
	{
		var results = new List<Stack<char>>();
		foreach (var line in configData.Reverse().Skip(1))
		{
			var config = line.Split(' ').ToList();
			var count = 0;
			while (count < config.Count)
			{
				if (string.IsNullOrWhiteSpace(config[count]))
				{
					config.RemoveRange(count + 1, 3);
				}
				count++;
			}

			if (!results.Any())
			{
				foreach (var conf in config)
				{
					var stack = new Stack<char>();
					var character = conf.Trim('[', ']').FirstOrDefault(' ');
					if (character != ' ')
						stack.Push(character);
					results.Add(stack);
				}
			}
			else
			{
				for (int i = 0; i < config.Count; i++)
				{
					var character = config[i].Trim('[', ']').FirstOrDefault(' ');
					if (character != ' ')
						results.ElementAt(i).Push(character);
				}
			}
		}
		return results;
	}
}
