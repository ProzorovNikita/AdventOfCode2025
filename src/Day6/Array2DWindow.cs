namespace Day6;

public class Array2DWindow {
    private readonly string[] _initialArray;
    private readonly int _x1;
    private readonly int _y1;
    private readonly int _x2;
    private readonly int _y2;

    public Array2DWindow(string[] initialArray, int x1, int y1, int x2, int y2) {
        _initialArray = initialArray;
        _x1 = x1;
        _y1 = y1;
        _x2 = x2;
        _y2 = y2;
    }

    public IEnumerable<IEnumerable<char>> EnumerateColumns() {
        for (int j = _x1; j <= _x2; j++) {
            yield return EnumerateColumn(j);
        }
    }

    public OperationType GetOperation() {
        return _initialArray[_y2 + 1][_x1] switch {
            '*' => OperationType.Multiply,
            '+' => OperationType.Add,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private IEnumerable<char> EnumerateColumn(int columnIndex) {
        for (int i = _y1; i <= _y2; i++) {
            var currentChar = _initialArray[i][columnIndex];
            if (currentChar is not ' ') {
                yield return  currentChar;
            }
        }
    }
}