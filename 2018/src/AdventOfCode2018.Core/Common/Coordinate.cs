using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Core
{
    public struct Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }



        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinate coord && Equals(coord);
        }

        public bool Equals(Coordinate coord)
        {
            return X == coord.X && Y == coord.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }

    internal static class CoordinateExtensions
    {
        public static IEnumerable<Coordinate> GetOccupiedCoordinates(this Coordinate coordinate, int width, int height)
        {
            for (var yRow = 0; yRow < height; yRow++)
                for (var xRow = 0; xRow < width; xRow++)
                    yield return new Coordinate(coordinate.X + xRow, coordinate.Y + yRow);
        }

        public static int GetManhattanDistance(this Point point1, Point point2)
        {
            return Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);
        }
        public static int GetManhattanDistance(this Coordinate coordinate1, Coordinate coordinate2)
        {
            return Math.Abs(coordinate1.X - coordinate2.X) + Math.Abs(coordinate1.Y - coordinate2.Y);
        }
    }
}