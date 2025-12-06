namespace Day6;

public class ColumnBuffer {
    public OperationType? Operation { get; set; }
    private readonly List<long> _numbers = [];

    public void Add(long number) {
        _numbers.Add(number);
    }

    public long Count() {
        return Operation switch {
            OperationType.Add => _numbers.Sum(),
            OperationType.Multiply => _numbers.Aggregate((a, b) => a * b),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}