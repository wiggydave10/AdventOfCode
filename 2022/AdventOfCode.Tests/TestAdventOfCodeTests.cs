namespace AdventOfCode.Tests;

public class TestAdventOfCodeTests
{
    [Fact]
    public async Task Day01_Morning()
    {
        var day01 = new Day01();
        await day01.PrepTestData();
        var result = day01.RunMorning();
        Assert.Equal(24000, result);
    }
	[Fact]
	public async Task Day01_Evening()
	{
		var day01 = new Day01();
		await day01.PrepTestData();
		var result = day01.RunEvening();
		Assert.Equal(45000, result);
	}

	[Fact]
	public async Task Day02_Morning()
	{
		var day02 = new Day02();
		await day02.PrepTestData();
		var result = day02.RunMorning();
		Assert.Equal(15, result);
	}
	[Fact]
	public async Task Day02_Evening()
	{
		var day02 = new Day02();
		await day02.PrepTestData();
		var result = day02.RunEvening();
		Assert.Equal(12, result);
	}
}