using System.Linq;

namespace AdventOfCode2018.Core
{
    public static class Day02_InventoryManagementSystem
    {
        public static int Process(string[] ids)
        {
            var twos = 0;
            var threes = 0;

            foreach (var id in ids)
            {
                var chars = id.GroupBy(x => x).ToList();
                if (chars.Any(x => x.Count() == 2))
                    twos++;
                if (chars.Any(x => x.Count() == 3))
                    threes++;
            }

            return twos * threes;
        }
    }
}
