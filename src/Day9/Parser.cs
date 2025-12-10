using System.Drawing;

namespace Day9;

public static class Parser {
    public static IEnumerable<Point> GetInput() {
        return File.ReadLines("input.txt")
            .Select(l => {
                var split = l.Split(',');
                return new Point(int.Parse(split[0]), int.Parse(split[1]));
            });
    }
}