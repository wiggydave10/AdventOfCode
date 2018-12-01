using System;
using System.IO;

namespace AdventOfCode2018.Tests
{
    public static class TestResourceService
    {
        private const string resourcePath = "..\\..\\..\\Files";

        public static string GetFilePath(string filename)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(basePath, resourcePath, filename);
        }
    }
}