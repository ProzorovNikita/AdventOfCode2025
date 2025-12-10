using System.Diagnostics;
using System.Drawing;

namespace Day9;

public record struct Line {
    public Point Start { get; private init; }
    public Point End { get;  private init; }
    
    public Line(Point Start, Point End) {
        Debug.Assert(Start.X == End.X || Start.Y == End.Y);
        
        this.Start = Start;
        this.End = End;
    }
    
    public readonly void Deconstruct(out Point start, out Point end) {
        start = this.Start;
        end = this.End;
    }

    public int MaxX => Math.Max(Start.X, End.X);
    public int MinX => Math.Min(Start.X, End.X);
    public int MaxY => Math.Max(Start.Y, End.Y);
    public int MinY => Math.Min(Start.Y, End.Y);
    
    public bool IsVertical() => Start.X == End.X;
    
    public bool IsHorizontal() => Start.Y == End.Y;
    
    public bool HasPoint(Point p) => (IsHorizontal() && p.Y == Start.Y && p.X >= MinX && p.X <= MaxX)
                                     || (IsVertical() && p.X == Start.X && p.Y >= MinY && p.Y <= MaxY);

    public Point Intersection(Line other) {
        if (Start == End) {
            return other.HasPoint(Start) ? Start : default;
        }

        if (other.Start == other.End) {
            return HasPoint(other.Start) ? other.Start : default;
        }
        
        if (IsVertical() == other.IsVertical()) {
            return default;
        }

        var verticalLine = IsVertical() ? this : other;
        var horizontalLine = IsHorizontal() ? this : other;

        var xmin = Math.Min(horizontalLine.Start.X, horizontalLine.End.X);
        var xmax = Math.Max(horizontalLine.Start.X, horizontalLine.End.X);
        var ymin = Math.Min(verticalLine.Start.Y, verticalLine.End.Y);
        var ymax = Math.Max(verticalLine.Start.Y, verticalLine.End.Y);

        if (verticalLine.Start.X > xmax || verticalLine.Start.X < xmin) {
            return default;
        }

        if (horizontalLine.Start.Y > ymax || horizontalLine.End.Y < ymin) {
            return default;
        }

        return new Point(verticalLine.Start.X, horizontalLine.Start.Y);
    }
};