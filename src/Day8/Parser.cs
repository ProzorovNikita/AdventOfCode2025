namespace Day8;

public static class Parser {
    public static Box[] GetInput() {
        return File.ReadLines("input.txt")
            .Select(line => {
                var split = line.Split(',');
                return new Box(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
            })
            .ToArray();
    }
}