using System.Globalization;

public static class Parser {
    public static IEnumerable<MachineInfo> GetInput() {
        var lines = File.ReadLines("input.txt");

        return lines.Select(ReadMachineInfo);

        MachineInfo ReadMachineInfo(string line) {
            var split = line.Split(' ');

            var sumString = split[0]
                .Skip(1)
                .TakeWhile(c => c is not ']')
                .Reverse()
                .Select(c => c switch {
                    '.' => '0',
                    '#' => '1',
                    _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
                })
                .ToList();
            var sumLength = sumString.Count;
            var sum = int.Parse(string.Concat(sumString), NumberStyles.BinaryNumber);

            var buttons = split[1..^1]
                .Select(bs => bs[1..^1]
                    .Split(',')
                    .Select(int.Parse)
                    .Aggregate(0, (acc, b) => acc + (int)Math.Pow(2, b)))
                .ToList();

            var joltages = split[^1][1..^1]
                .Split(',')
                .Select(int.Parse);

            return new MachineInfo {
                FinalBinaryState = sum,
                FinalStateLength = sumLength,
                Buttons = buttons,
                Joltages = joltages.ToList(),
            };
        }
    }    
}