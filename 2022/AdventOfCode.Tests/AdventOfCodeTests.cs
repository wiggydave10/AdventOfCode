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

	[Fact]
	public async Task Day02_Morning()
	{
		var day02 = new Day02();
		await day02.PrepData();
		var result = day02.RunMorning();
		Assert.Equal(0, result);
	}
	[Fact]
	public async Task Day02_Evening()
	{
		var day02 = new Day02();
		await day02.PrepData();
		var result = day02.RunEvening();
		Assert.Equal(0, result);
	}
}