using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Core
{
    public class Day06_ChronalCoordinates
    {
        public static int Process_Part1(string[] coordinateList)
        {
            var claims = GetClaims(coordinateList);
            var grid = GetPopulatedGridPoints(claims);

            var points = grid.Occupied.Where(x => x.Value.Count == 1);
            var dict = new Dictionary<Point, int>();
            foreach (var point in points)
            {
                var claim = point.Value.First();
                if (dict.ContainsKey(claim.ClosestPoint.Value))
                    dict[claim.ClosestPoint.Value]++;
                else
                    dict.Add(claim.ClosestPoint.Value, 1);
            }

            return dict.Where(x => !grid.EdgeCoordinates().Contains(x.Key.Coordinate)).Select(x => x.Value).Max();
        }

        public static int Process_Part2(string[] coordinateList, int maxDistance)
        {
            var claims = GetClaims(coordinateList);
            var grid = GetPopulatedGridPoints(claims, true);

            var points = grid.Occupied.Where(x => x.Value.Last().Distance < maxDistance);

            return points.Where(x => !grid.EdgeCoordinates().Contains(x.Key)).Count();
        }


        private static IEnumerable<ChronalClaim> GetClaims(string[] coordinateList)
        {
            return coordinateList.Select((x, index) =>
            {
                var values = x.Split(',');
                var point = new Point(int.Parse(values[0].Trim()), int.Parse(values[1].Trim()));
                var claim = new ChronalClaim(point, 0, point);
                return claim;
            }).ToList();
        }

        private static ChronalGrid GetPopulatedGridPoints(IEnumerable<ChronalClaim> mainChronalClaims, bool sumDistances = false)
        {
            var grid = new ChronalGrid(mainChronalClaims);

            for (int x = grid.MinX; x <= grid.MaxX; x++)
            {
                for (int y = grid.MinY; y <= grid.MaxY; y++)
                {
                    var checkingPoint = new Point(x, y);
                    var distances = mainChronalClaims.Select(c => new KeyValuePair<Point, int>(c.Point, checkingPoint.GetManhattanDistance(c.Point))).ToArray();

                    if (sumDistances)
                    {
                        var totalDistance = distances.Sum(d => d.Value);
                        grid.AddOccupiedCoordinate(new ChronalClaim(checkingPoint, totalDistance, null));
                    }
                    else
                    {
                        var minDistance = distances.Min(d => d.Value);
                        if (minDistance == 0)
                            continue;

                        var points = distances.Where(d => d.Value == minDistance).ToArray();

                        var totalPoints = points.Count();
                        foreach (var point in points)
                        {
                            grid.AddOccupiedCoordinate(new ChronalClaim(checkingPoint, point.Value, totalPoints == 1 ? point.Key : (Point?)null));
                        }
                    }
                }
            }

            return grid;
        }
    }

    internal class ChronalGrid
    {
        private readonly Dictionary<Coordinate, List<ChronalClaim>> occupiedCoords;
        private readonly HashSet<Coordinate> edgeCoords;

        public ChronalGrid(int width, int height, IEnumerable<ChronalClaim> coordinateDetails)
        {
            Width = width;
            Height = height;

            occupiedCoords = new Dictionary<Coordinate, List<ChronalClaim>>();
            edgeCoords = new HashSet<Coordinate>();
            foreach (var coordinateDetail in coordinateDetails)
            {
                AddOccupiedCoordinate(coordinateDetail);
            }

            MinX = occupiedCoords.Select(x => x.Key.X).Min();
            MaxX = occupiedCoords.Select(x => x.Key.X).Max();
            MinY = occupiedCoords.Select(x => x.Key.Y).Min();
            MaxY = occupiedCoords.Select(x => x.Key.Y).Max();
        }
        public ChronalGrid(IEnumerable<ChronalClaim> coordinateDetails)
        {
            var maxX = 0;
            var maxY = 0;

            occupiedCoords = new Dictionary<Coordinate, List<ChronalClaim>>();
            edgeCoords = new HashSet<Coordinate>();
            foreach (var coordinateDetail in coordinateDetails)
            {
                AddOccupiedCoordinate(coordinateDetail);

                if (coordinateDetail.Coordinate.X > maxX)
                    maxX = coordinateDetail.Coordinate.X;
                if (coordinateDetail.Coordinate.Y > maxY)
                    maxY = coordinateDetail.Coordinate.Y;
            }

            Width = maxX;
            Height = maxY;

            MinX = occupiedCoords.Select(x => x.Key.X).Min();
            maxX = occupiedCoords.Select(x => x.Key.X).Max();
            MinY = occupiedCoords.Select(x => x.Key.Y).Min();
            maxY = occupiedCoords.Select(x => x.Key.Y).Max();
        }

        public int Width { get; }
        public int Height { get; }

        public int MinX { get; private set; }
        public int MaxX { get; private set; }
        public int MinY { get; private set; }
        public int MaxY { get; private set; }


        public IReadOnlyDictionary<Coordinate, List<ChronalClaim>> Occupied => occupiedCoords;
        public int OverlappingCoordinates => occupiedCoords.Count(x => x.Value?.Count > 1);

        public void AddOccupiedCoordinate(ChronalClaim chronalClaim)
        {
            if (occupiedCoords.ContainsKey(chronalClaim.Coordinate))
                occupiedCoords[chronalClaim.Coordinate].Add(chronalClaim);
            else
                occupiedCoords.Add(chronalClaim.Coordinate, new List<ChronalClaim>() { chronalClaim });

            if (chronalClaim.ClosestPoint.HasValue && IsCoordinateOnEdge(chronalClaim.Point.Coordinate))
                edgeCoords.Add(chronalClaim.ClosestPoint.Value.Coordinate);

            CheckMinAndMax(chronalClaim.Coordinate);
        }

        public bool IsCoordinateOnEdge(Coordinate coordinate)
        {
            return coordinate.X == MinX || coordinate.X == MaxX || coordinate.Y == MinY || coordinate.Y == MaxY;
        }


        public IEnumerable<ChronalClaim> NoOverlapping()
        {
            var singleOccupiedPoint = occupiedCoords.Where(x => x.Value.Count == 1).SelectMany(x => x.Value);
            return singleOccupiedPoint;
        }
        public IEnumerable<Coordinate> EdgeCoordinates()
        {
            return edgeCoords;
        }


        private void CheckMinAndMax(Coordinate coord)
        {
            if (coord.X < MinX)
                MinX = coord.X;
            else if (coord.X > MaxX)
                MaxX = coord.X;

            if (coord.Y < MinY)
                MinY = coord.Y;
            else if (coord.Y > MaxY)
                MaxY = coord.Y;
        }
    }


    internal struct Point
    {
        public Point(int x, int y)
        {
            Coordinate = new Coordinate(x, y);
        }

        public int X => Coordinate.X;
        public int Y => Coordinate.Y;
        public Coordinate Coordinate { get; }
    }


    internal class ChronalClaim
    {
        public ChronalClaim(Point point, int distance, Point? closestPoint)
        {
            Point = point;
            Distance = distance;
            ClosestPoint = closestPoint;
        }

        public Point Point { get; }

        public int Distance { get; }
        public Point? ClosestPoint { get; }

        public Coordinate Coordinate => Point.Coordinate;

        public override string ToString()
        {
            return $"Position is [{Point.X}, {Point.Y}], is closest to {(ClosestPoint.HasValue ? $"[{ClosestPoint.Value.X}, {ClosestPoint.Value.Y}] with distance of {Distance}" : "None")}";
        }
    }
}