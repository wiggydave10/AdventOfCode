using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Core
{
    public static class Day02_InventoryManagementSystem
    {
        public static int Process_Part1(string[] ids)
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

        public static string Process_Part2(string[] ids)
        {
            string similarId = null;
            var idIndex = 0;
            while (similarId == null && idIndex < ids.Length - 1)
            {
                var id = ids[idIndex];
                var nextIdIndex = idIndex + 1;
                while (similarId == null && nextIdIndex < ids.Length)
                {
                    var compareId = ids[nextIdIndex];
                    var incorrectCharIndexes = new List<int>();

                    var nextCharIndex = 0;
                    while (incorrectCharIndexes.Count < 2 && nextCharIndex < id.Length)
                    {
                        var match = id[nextCharIndex] == compareId[nextCharIndex];
                        if (!match)
                            incorrectCharIndexes.Add(nextCharIndex);
                        nextCharIndex++;
                    }

                    if (incorrectCharIndexes.Count == 1)
                        similarId = string.Join(string.Empty,
                            id.Where((x, index) => !incorrectCharIndexes.Contains(index)));
                    nextIdIndex++;
                }
                idIndex++;
            }

            return similarId;
        }

        //  First Idea
        //public static string Process_Part2(string[] ids)
        //{
        //    var similarIds = new List<string>();
        //    for (var i1 = 0; i1 < ids.Length - 1; i1++)
        //    {
        //        var id = ids[i1];

        //        for (var i2 = i1 + 1; i2 < ids.Length; i2++)
        //        {
        //            var compareId = ids[i2];
        //            var incorrectCharIndexes = new List<int>();
        //            for (var idI = 0; idI < id.Length; idI++)
        //            {
        //                var match = id[idI] == compareId[idI];
        //                if (!match)
        //                    incorrectCharIndexes.Add(idI);
        //            }

        //            if (incorrectCharIndexes.Count == 1)
        //            {
        //                similarIds.Add(string.Join(string.Empty, id.Where((x, index) => !incorrectCharIndexes.Contains(index))));
        //            }
        //        }
        //    }

        //    return similarIds.Single();
        //}
    }
}
