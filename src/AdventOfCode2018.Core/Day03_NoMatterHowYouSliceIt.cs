using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018.Core
{
    public class Day03_NoMatterHowYouSliceIt
    {
        public static int Process_Part1(string[] data)
        {
            var fabricClaims = GetClaims(data);
            var fabric = new Fabric(1000, 1000, fabricClaims);
            return fabric.OverlappingCoordinates;
        }
        public static int Process_Part2(string[] data)
        {
            var fabricClaims = GetClaims(data);
            var fabric = new Fabric(1000, 1000, fabricClaims);
            var noOverlapping = fabric.NoOverlapping();
            return noOverlapping.Single().Id;
        }

        private static IList<FabricClaim> GetClaims(IEnumerable<string> entries)
        {
            var fabrics = new List<FabricClaim>();
            foreach (var entry in entries)
            {
                var numbers = Regex.Matches(entry, @"(\d+)");

                var requiredNumbers = new List<int>();
                foreach (Match number in numbers)
                {
                    if (int.TryParse(number.Value, out var val))
                        requiredNumbers.Add(val);
                }

                var claim = new FabricClaim(requiredNumbers.ElementAt(0), requiredNumbers.ElementAt(1),
                    requiredNumbers.ElementAt(2), requiredNumbers.ElementAt(3), requiredNumbers.ElementAt(4));
                fabrics.Add(claim);
            }
            return fabrics;
        }
    }

    internal class Fabric
    {
        public Fabric(int width, int height, IList<FabricClaim> fabricClaims)
        {
            Width = width;
            Height = height;
            FabricClaims = fabricClaims;

            occupiedCoords = new Dictionary<Coordinate, List<FabricClaim>>();
            foreach (var fabricClaim in fabricClaims)
            {
                foreach (var coordinate in fabricClaim.Occupied)
                {
                    if (occupiedCoords.ContainsKey(coordinate))
                        occupiedCoords[coordinate].Add(fabricClaim);
                    else
                        occupiedCoords.Add(coordinate, new List<FabricClaim>() { fabricClaim });
                }
            }

        }

        private readonly Dictionary<Coordinate, List<FabricClaim>> occupiedCoords;

        public int Width { get; }
        public int Height { get; }
        public IEnumerable<FabricClaim> FabricClaims { get; }
        public int OverlappingCoordinates => occupiedCoords.Count(x => x.Value?.Count > 1);

        public IEnumerable<FabricClaim> NoOverlapping()
        {
            var overlappingFabricClaims = occupiedCoords.Where(x => x.Value.Count > 1).SelectMany(x => x.Value);
            return FabricClaims.Except(overlappingFabricClaims);
        }
    }

    internal struct FabricClaim
    {
        public FabricClaim(int id, int x, int y, int width, int height)
        {
            Id = id;
            Width = width;
            Height = height;
            Coordinates = new Coordinate(x, y);

            Occupied = Coordinates.GetOccupiedCoordinates(width, height);
        }

        public int Id { get; }
        public int Width { get; }
        public int Height { get; }
        public Coordinate Coordinates { get; }

        public IEnumerable<Coordinate> Occupied { get; }


        public override bool Equals(object obj)
        {
            return obj is FabricClaim fabSize && Equals(fabSize);
        }

        public bool Equals(FabricClaim fabSize)
        {
            return Id == fabSize.Id
                   && Width == fabSize.Width
                   && Height == fabSize.Height
                   && Coordinates.Equals(fabSize.Coordinates);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode() ^ Coordinates.GetHashCode();
        }
    }    
}