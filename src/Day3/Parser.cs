namespace Day3;

public static class Parser {
    public static IEnumerable<IEnumerable<int>> GetInput() {
        const int zeroAsciiNumber = 48;
        var content = File.ReadLines("input.txt")
            .Select(
                line => line.Select(c => c - zeroAsciiNumber)
            );

        return content;
    }
}