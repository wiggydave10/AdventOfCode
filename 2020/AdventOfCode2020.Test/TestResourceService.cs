using System;
using System.IO;

namespace AdventOfCode2020.Test
{
    public static class TestResourceService
    {
        private const string resourcePath = "..\\..\\..\\..\\AdventOfCode2020.Core\\";

        public static string GetFilePath(int dayNumber, int part)
        {
            var fileName = $"Day {dayNumber:0#}\\part{part}_input.txt";
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(basePath, resourcePath, fileName);
        }

        public static string[] GetFileContentsByFile(int dayNumber, int part)
        {
            return GetFileContents(GetFilePath(dayNumber, part));
        }

        public static string[] GetFileContents(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}