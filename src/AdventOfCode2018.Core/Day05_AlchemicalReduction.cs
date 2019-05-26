using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Core
{
    public class Day05_AlchemicalReduction
    {
        public static int Process_Part1(string entry)
        {
            var characters = new List<char>();
            characters.AddRange(entry);

            var index = 0;
            while(index < characters.Count - 1)
            {
                var chars = characters.GetRange(index, 2);
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
                    characters.RemoveRange(index, 2);
                    index = index == 0 ? 0 : index - 1;
                }
                else
                {
                    index++;
                }
            }
            return characters.Count;
        }
    }
}