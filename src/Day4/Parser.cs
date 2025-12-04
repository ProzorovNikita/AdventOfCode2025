using System.Diagnostics;

namespace Day4;

public static class Parser {
    public static byte[][] GetInput() {
        var content = File.ReadLines("input.txt")
            .Select(line => line
                .Where(c => c is '.' or '@')
                .Select(c => c switch {
                    '.' => (byte) 0,
                    '@' => (byte) 1,
                    _ => throw new UnreachableException(),
                })
                .ToArray()
            )
            .ToArray();

        return content;
    }
}