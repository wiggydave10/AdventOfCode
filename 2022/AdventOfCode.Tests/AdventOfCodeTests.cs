namespace AdventOfCode.Tests;

public class AdventOfCodeTests
{
	[Fact]
	public async Task Day01_Morning()
	{
		var day01 = new Day01();
		await day01.PrepData();
		var result = day01.RunMorning();
		Assert.Equal(0, result);
	}
	[Fact]
	public async Task Day01_Evening()
	{
		var day01 = new Day01();
		await day01.PrepData();
		var result = day01.RunEvening();
		Assert.Equal(0, result);
	}
}