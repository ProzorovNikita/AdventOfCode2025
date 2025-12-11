using System.Text;

public record MachineInfo {
    public required int FinalBinaryState { get; init; }
    public required List<int> Buttons { get; init; }
    public required List<int> Joltages { get; init; }
    public int FinalStateLength { get; set; }

    public static string Decode(int number, int length) {
        return string.Concat(Convert.ToString(number, 2).Reverse()).PadRight(length, '0');
    }

    public override string ToString() {
        var sb = new StringBuilder();
        sb.Append($"[{Decode(FinalBinaryState, FinalStateLength)}]");
        
        foreach (var button in Buttons) {
            sb.Append(' ');
            sb.Append(Decode(button, FinalStateLength));
        }
        
        return sb.ToString();
    }
}