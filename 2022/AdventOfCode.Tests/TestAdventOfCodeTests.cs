namespace AdventOfCode.Tests;

public class TestAdventOfCodeTests
{
    [Fact]
    public Task Day01_Morning()
	{
		return RunMorning(new Day01(), 24000);
    }
	[Fact]
	public Task Day01_Evening()
	{
		return RunEvening(new Day01(), 45000);
	}

	[Fact]
	public Task Day02_Morning()
	{
		return RunMorning(new Day02(), 15);
	}
	[Fact]
	public Task Day02_Evening()
	{
		return RunEvening(new Day02(), 12);
	}

	[Fact]
	public Task Day03_Morning()
	{
		return RunMorning(new Day03(), 157);
	}
	[Fact]
	public Task Day03_Evening()
	{
		return RunEvening(new Day03(), 70);
	}
  
	[Fact]
	public Task Day04_Morning()
	{
		return RunMorning(new Day04(), 2);
	}
	[Fact]
	public Task Day04_Evening()
	{
		return RunEvening(new Day04(), 4);
	}

	[Fact]
	public Task Day05_Morning()
	{
		return RunMorning(new Day05(), "CMZ");
	}
	[Fact]
	public Task Day05_Evening()
	{
		return RunEvening(new Day05(), "MCD");
	}

	[Fact]
	public Task Day06_Morning()
	{
		return RunMorning(new Day06(), new[] { 7, 5, 6, 10, 11 });
	}
	[Fact]
	public Task Day06_Evening()
	{
		return RunEvening(new Day06(), new[] { 19, 23, 23, 29, 26 });
	}

	[Fact]
	public Task Day07_Morning()
	{
		return RunMorning(new Day07(), 95437);
	}
	[Fact]
	public Task Day07_Evening()
	{
		return RunEvening(new Day07(), 24933642);
	}

	[Fact]
	public Task Day08_Morning()
	{
		return RunMorning(new Day08(), 21);
	}
	[Fact]
	public Task Day08_Evening()
	{
		return RunEvening(new Day08(), 8);
	}

	private async Task RunMorning<TMorning, TEvening>(IAdventOfCodeDay<TMorning, TEvening> day,
		TMorning expectedResult)
	{
		await day.PrepTestData();
		var result = day.RunMorning();
		Assert.Equal(expectedResult, result);
	}
	private async Task RunEvening<TMorning, TEvening>(IAdventOfCodeDay<TMorning, TEvening> day,
		TEvening expectedResult)
	{
		await day.PrepTestData();
		var result = day.RunEvening();
		Assert.Equal(expectedResult, result);
	}
}