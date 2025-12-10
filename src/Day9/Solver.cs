using System.Drawing;
using System.Runtime.InteropServices;

namespace Day9;

public static class Solver {
    public static long GetLargestRectangleAreaInGreenZone(Point[] redTiles) {
        List<Line> greenLines = new(redTiles.Length);
        for (var i = 1; i < redTiles.Length; i++) {
            greenLines.Add(new Line(redTiles[i-1], redTiles[i]));
        }
        greenLines.Add(new Line(redTiles[^1], redTiles[0]));

        var verticalGreenLines = greenLines
            .Where(l => l.IsVertical())
            .OrderBy(l => l.MinX)
            .ToArray();
        
        var horizontalGreenLines = greenLines
            .Where(l => l.IsHorizontal())
            .OrderBy(l => l.MinY)
            .ToArray();

        var border = greenLines.SelectMany(GetLinePoints);
        var inGreenZoneCache = border.Distinct().ToDictionary(p => p, _ => true);
        
        var areas = 
            from p1 in redTiles
            from p2 in redTiles
            where p1 != p2 
            select (p1, p2, RectangleArea(p1, p2));
        
        return areas
            .Select(x => {
                var rect = new Rectangle(
                    Math.Min(x.p1.X, x.p2.X),
                    Math.Min(x.p1.Y, x.p2.Y),
                    Math.Abs(x.p1.X - x.p2.X),
                    Math.Abs(x.p1.Y - x.p2.Y)
                );
                return (rect, Area: x.Item3);
            })
            .Distinct()
            .OrderByDescending(x => x.Area)
            .First(x => RectInGreenZone(x.rect))
            .Area;

        bool RectInGreenZone(Rectangle rect) {
            var l1 = new Line(new Point(rect.X, rect.Y), new Point(rect.Right, rect.Y));
            var l2 = new Line(new Point(rect.Right, rect.Y), new Point(rect.Right, rect.Bottom));
            var l3 = new Line(new Point(rect.Right, rect.Bottom), new Point(rect.X, rect.Bottom));
            var l4 = new Line(new Point(rect.X, rect.Bottom), new Point(rect.X, rect.Y));

            return GetLinePoints(l1)
                .Concat(GetLinePoints(l2))
                .Concat(GetLinePoints(l3))
                .Concat(GetLinePoints(l4))
                .Distinct()
                .All(PointInGreenZone);
        }

        bool PointInGreenZone(Point p) {
            ref var cacheValue = ref CollectionsMarshal.GetValueRefOrAddDefault(inGreenZoneCache, p, out var isCacheHit);
            if (isCacheHit) {
                return cacheValue;
            }

            cacheValue = IntersectionsCount(new Line(new Point(0, p.Y), p)) % 2 != 0;
            return cacheValue;
        }

        int IntersectionsCount(Line r) {
            var intersectionsCounter = 0;
            
            while (true) {
                Point intersection = default;
                Line verticalLine = default;
                for (var i = 0; i < verticalGreenLines.Length; i++) {
                    verticalLine = verticalGreenLines[i];
                    intersection = verticalLine.Intersection(r);
                    if (intersection != default) {
                        break;
                    }
                }

                if (intersection == default) {
                    break;
                }
                
                var horizontalLine = horizontalGreenLines.FirstOrDefault(l => l.HasPoint(intersection));
                intersectionsCounter++;
                
                if (horizontalLine == default) {
                    r = new Line(new Point(intersection.X + 1, intersection.Y), r.End);
                }
                else {
                    var currentPoint = new Point(horizontalLine.MaxX, intersection.Y);

                    if (horizontalLine.MaxX >= r.End.X) {
                        break;
                    }
                    
                    var enterFromBelow = false;
                    var finishToBelow = false;

                    if (verticalLine.MaxY > intersection.Y) {
                        enterFromBelow = true;
                    }
                    
                    var nextVertical = verticalGreenLines.First(l => l.Start == currentPoint || l.End == currentPoint);
                    if (nextVertical.MaxY > currentPoint.Y) {
                        finishToBelow = true;
                    }

                    if (finishToBelow == enterFromBelow) {
                        intersectionsCounter++;
                    }
                    
                    r = new Line(new Point(horizontalLine.MaxX + 1, intersection.Y), r.End);
                }

                if (r.Start.X >= r.End.X) {
                    break;
                }
            }

            return intersectionsCounter;
        }
    }

    private static IEnumerable<Point> GetLinePoints(Line line) {
        return line.IsHorizontal()
            ? Enumerable.Range(line.MinX, line.MaxX - line.MinX + 1).Select(x => new Point(x, line.MaxY))
            : Enumerable.Range(line.MinY, line.MaxY - line.MinY + 1).Select(y => new Point(line.MaxX, y));
    }

    public static long GetLargestRectangleArea(Point[] redTiles) {
        redTiles = redTiles.ToArray();
        
        var areas = 
            from p1 in redTiles
            from p2 in redTiles
            where p1 != p2
            select RectangleArea(p1, p2);

        return areas.Max();
    }

    private static long RectangleArea(Point p1, Point p2) {
        return (long) (Math.Abs(p1.X - p2.X) + 1) * (long) (Math.Abs(p1.Y - p2.Y) + 1);
    }
}