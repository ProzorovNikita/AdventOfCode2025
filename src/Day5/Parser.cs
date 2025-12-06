namespace Day5;

public static class Parser {
    public static IEnumerable<Range> GetRanges() {
        var lines = File.ReadAllLines("input.txt");
        var ranges = lines
            .TakeWhile(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => {
                var split = l.Split('-');
                return new Range(long.Parse(split[0]), long.Parse(split[1]));
            })
            .ToArray();
        
        return ranges;
    }

    public static IEnumerable<long> GetIds() {
        var lines = File.ReadAllLines("input.txt");
        var ids = lines
            .SkipWhile(l => !string.IsNullOrWhiteSpace(l))
            .Skip(1)
            .Select(long.Parse)
            .ToArray();
        
        return ids;
    }
}