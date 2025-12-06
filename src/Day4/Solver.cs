namespace Day4;

public static class Solver {
    public static int CountMovable(byte[][] input, bool repeatProcess = false) {
        var previousSum = -1;
        var sum = 0;
        
        var changes = new List<(int, int)>();
        while (sum != previousSum) {
            previousSum = sum;
            
            for (int i = 0; i < input.Length; i++) {
                for (int j = 0; j < input[i].Length; j++) {
                    if (input[i][j] == 0 
                        || CountNeighbours(input, i, j) >= 4) {
                        continue;
                    }

                    changes.Add((i, j));
                    sum++;
                }
            }

            if (!repeatProcess) {
                break;
            }
            
            foreach (var (i, j) in changes) {
                input[i][j] = 0;
            }
            
            changes.Clear();
        }

        return sum;
    }

    private static byte CountNeighbours(byte[][] input, int i, int j) {
        byte neighboursCount = 0;
        
        neighboursCount += GetValue(input, i - 1, j - 1);
        neighboursCount += GetValue(input, i, j - 1);
        neighboursCount += GetValue(input, i - 1, j);
        neighboursCount += GetValue(input, i - 1, j + 1);
        neighboursCount += GetValue(input, i + 1, j - 1);
        neighboursCount += GetValue(input, i + 1, j + 1);
        neighboursCount += GetValue(input, i, j + 1);
        neighboursCount += GetValue(input, i + 1, j);
        
        return neighboursCount;
    }

    private static byte GetValue(byte[][] input, int i, int j) {
        if (i < 0 || j < 0 || i >= input.Length || j >= input[i].Length) {
            return 0;
        }

        return input[i][j];
    }
}