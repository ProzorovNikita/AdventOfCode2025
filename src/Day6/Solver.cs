namespace Day6;

public static class Solver {
    public static long GetAnswersSumForIndividualColumns() {
        var lines = File.ReadAllLines("input.txt");

        var columnStartIndexes = GetColumnsStartIndexes(lines);
        var linesCount = lines.Length;

        var segments = columnStartIndexes
            .SkipLast(1)
            .Select((t, i) => new Array2DWindow(lines, columnStartIndexes[i], 0, columnStartIndexes[i + 1] - 2, linesCount - 2))
            .ToList();

        var numbers = segments
            .Select(s => s.EnumerateColumns().Select(NumberFromCharArray));

        return segments
            .Zip(numbers)
            .Sum(t => {
                return t.First.GetOperation() switch {
                    OperationType.Add => t.Second.Sum(),
                    OperationType.Multiply => t.Second.Aggregate((a, b) => a * b),
                    _ => throw new ArgumentOutOfRangeException()
                };
            });
    }

    public static long GetAnswersSum() {
        var lines = File.ReadLines("input.txt");

        var buffers = new List<ColumnBuffer>();
        foreach (var line in lines) {
            var lineSplit = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var isLineNumbers = long.TryParse(lineSplit[0], out var _);
            if (isLineNumbers) {
                foreach (var (columnIndex, number) in lineSplit.Select(long.Parse).Index()) {
                    if (buffers.Count <= columnIndex) {
                        buffers.Add(new ColumnBuffer());
                    }

                    buffers[columnIndex].Add(number);
                }
            }
            else {
                foreach (var (columnIndex, operation) in lineSplit.Index()) {
                    buffers[columnIndex].Operation = operation switch {
                        "+" => OperationType.Add,
                        "*" => OperationType.Multiply,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                }
            }
        }
        
        return buffers.Sum(b => b.Count());
    }

    private static long NumberFromCharArray(IEnumerable<char> chars) {
        return chars
            .Select(c => c - '0')
            .Reverse()
            .Index()
            .Sum(t => t.Item * (int)Math.Pow(10, t.Index));
    }
    
    private static List<int> GetColumnsStartIndexes(string[] lines) {
        List<int> startIndexes = [0];
        var lastLine = lines.Last();
        for (var i = 0; i < lastLine.Length; i++) {
            var currentChar = lastLine[i];
            if (currentChar is '*' or '+' && i != 0) {
                startIndexes.Add(i);
            }
        }

        startIndexes.Add(lastLine.Length + 1);
        
        return startIndexes;
    }
}