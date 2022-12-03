namespace AdventOfCode.Tests;

public class AdventOfCodeTests
{
	[Fact]
	public async Task Day01()
	{
		var day01 = new Day01();
		await day01.PrepData();
		var result = day01.RunDay();
		Assert.Equal(0, result);
	}
}