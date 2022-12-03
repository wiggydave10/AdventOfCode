namespace AdventOfCode.Tests;

public class TestAdventOfCodeTests
{
    [Fact]
    public async Task Day01()
    {
        var day01 = new Day01();
        await day01.PrepTestData();
        var result = day01.RunDay();
        Assert.Equal(24000, result);
    }
}