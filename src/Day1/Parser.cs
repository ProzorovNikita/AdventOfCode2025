using System.Diagnostics;

namespace Day1;

public static class Parser {
    public static IEnumerable<int> GetInput() {
        var content = File.ReadAllLines("input.txt");

        return ParseInput(content.Where(s => !string.IsNullOrWhiteSpace(s)));
    }

    private static List<int> ParseInput(IEnumerable<string> input) {
        return input
            .Select(s => {
                var direction = s[0];
                var number = int.Parse(s.AsSpan()[1..]);
            
                return direction switch {
                    'R' => number,
                    'L' => number * -1,
                    _ => throw new UnreachableException(),
                };
            })
            .ToList();
    }
}