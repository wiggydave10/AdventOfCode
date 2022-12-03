namespace AdventOfCode.Core;

public interface IAdventOfCodeDay<T>
{
    Task PrepData();
    Task PrepTestData();
    T RunDay();
}
