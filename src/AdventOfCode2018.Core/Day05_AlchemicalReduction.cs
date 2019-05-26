using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Core
{
    public class Day05_AlchemicalReduction
    {
        public static int Process_Part1(string entry)
        {
            var characters = new List<char>();
            characters.AddRange(entry);

            return ReactPolymer(characters).Count();
        }

        public static int Process_Part2(string entry)
        {
            var characters = new List<char>();
            characters.AddRange(entry);

            var minLength = int.MaxValue;
            var polymerTypes = Enumerable.Range(65, 26).Select(x => (char)x);

            foreach (var polymerType in polymerTypes)
            {
                var reducedPolymerParts = new List<char>(characters);
                var lowerPolymerType = char.ToLower(polymerType);
                reducedPolymerParts.RemoveAll(x => x == polymerType || x == lowerPolymerType);
                var reactedPolymerLength = ReactPolymer(reducedPolymerParts).Count();
                if (reactedPolymerLength < minLength)
                    minLength = reactedPolymerLength;
            }
            return minLength;
        }

        private static IEnumerable<char> ReactPolymer(List<char> polymerParts)
        {
            var index = 0;
            while (index < polymerParts.Count - 1)
            {
                var chars = polymerParts.GetRange(index, 2);
                var char1 = chars[0];
                var char2 = chars[1];

                var reactive = false;
                if (char.IsUpper(char1) && (char1 + 32) == char2)
                {
                    reactive = true;
                }
                else if (char.IsLower(char1) && (char1 - 32) == char2)
                {
                    reactive = true;
                }

                if (reactive)
                {
                    polymerParts.RemoveRange(index, 2);
                    index = index == 0 ? 0 : index - 1;
                }
                else
                {
                    index++;
                }
            }
            return polymerParts;
        }
    }
}