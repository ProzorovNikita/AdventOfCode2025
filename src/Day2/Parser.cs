namespace Day2;

public static class Parser {
    public static string[] GetInput() {
        var content = File.ReadAllText("input.txt");
        return content.Split(",");
    }
}