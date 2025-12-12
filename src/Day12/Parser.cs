using System.ComponentModel;

namespace Day12;

public static class Parser {
    public static Input GetInput() {
        var lines = File.ReadAllLines("input.txt");

        var currentSegment = lines.AsSpan();
        var shapes = new List<Shape>();
        
        while (true) {
            var (shape, linesRead) = ParseNextShape(currentSegment);
            shapes.Add(shape);
            
            if (linesRead == 0) {
                break;
            }
            
            currentSegment = currentSegment[linesRead..];
        }
        
        var cases = new List<Case>();
        foreach (var line in currentSegment) {
            var split = line.Split(':');
            var dimensionsSplit = split[0].Split('x');
            
            var width = int.Parse(dimensionsSplit[0]);
            var height = int.Parse(dimensionsSplit[1]);
            
            var shapesCountSplit = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var shapesCounts = shapesCountSplit.Select(int.Parse).ToList();
            
            var newCase = new Case(width, height, shapesCounts);
            
            cases.Add(newCase);
        }

        return new Input {
            Shapes = shapes,
            Cases = cases,
        };

    }

    private static (Shape Shape, int LinesRead) ParseNextShape(Span<string> segment) {
        List<List<bool>> shapeLayout = [];
        var linesCount = 0;
        foreach (var s in segment) {
            if (s.Contains('x')) {
                break;
            }
            
            linesCount++;
            
            if (string.IsNullOrWhiteSpace(s)) {
                break;
            }

            if (s[^1] is ':') {
                continue;
            }

            var layoutLine = s.Select(c => c switch {
                    '.' => false,
                    '#' => true,
                    _ => throw new InvalidEnumArgumentException(),
                })
                .ToList();
            shapeLayout.Add(layoutLine);
        }

        if (shapeLayout == null) {
            throw new InvalidOperationException();
        }
        
        return (new Shape(shapeLayout), linesCount);
    }
}