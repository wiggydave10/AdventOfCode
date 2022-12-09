namespace AdventOfCode.Tests;

public class AdventOfCodeTests
{
	[Fact]
	public Task Day01_Morning()
	{
		return RunMorning(new Day01(), 0);
	}
	[Fact]
	public Task Day01_Evening()
	{
		return RunEvening(new Day01(), 0);
	}

	[Fact]
	public Task Day02_Morning()
	{
		return RunMorning(new Day02(), 0);
	}
	[Fact]
	public Task Day02_Evening()
	{
		return RunEvening(new Day02(), 0);
	}

	[Fact]
	public Task Day03_Morning()
	{
		return RunMorning(new Day03(), 0);
	}
	[Fact]
	public Task Day03_Evening()
	{
		return RunEvening(new Day03(), 0);
	}
  
	[Fact]
	public Task Day04_Morning()
	{
		return RunMorning(new Day04(), 0);
	}
	[Fact]
	public Task Day04_Evening()
	{
		return RunEvening(new Day04(), 0);
	}

	[Fact]
	public Task Day05_Morning()
	{
		return RunMorning(new Day05(), "");
	}
	[Fact]
	public Task Day05_Evening()
	{
		return RunEvening(new Day05(), "");
	}

	[Fact]
	public Task Day06_Morning()
	{
		return RunMorning(new Day06(), new[] { 0 });
	}
	[Fact]
	public Task Day06_Evening()
	{
		return RunEvening(new Day06(), new[] { 0 });
	}


	private async Task RunMorning<TMorning, TEvening>(IAdventOfCodeDay<TMorning, TEvening> day,
		TMorning expectedResult)
	{
		await day.PrepData();
		var result = day.RunMorning();
		Assert.Equal(expectedResult, result);
	}
	private async Task RunEvening<TMorning, TEvening>(IAdventOfCodeDay<TMorning, TEvening> day,
		TEvening expectedResult)
	{
		await day.PrepData();
		var result = day.RunEvening();
		Assert.Equal(expectedResult, result);
	}
}