namespace Day7;

public static class Parser {
    public static CellType[][] GetField() {
        var lines = File.ReadAllLines("input.txt");

        return lines
            .Select(line => line
                .Select(c => c switch {
                    '.' => CellType.Empty,
                    '^' => CellType.Splitter,
                    'S' => CellType.Start,
                    _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
                })
                .ToArray())
            .ToArray();
    }
}