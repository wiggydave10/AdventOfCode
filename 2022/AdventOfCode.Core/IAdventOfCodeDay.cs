namespace AdventOfCode.Core;

public interface IAdventOfCodeDay<TMorning, TEvening>
{
    Task PrepData();
    Task PrepTestData();
    TMorning RunMorning();
    TEvening RunEvening();
}
