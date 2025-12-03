namespace Day3;

public static class Solver {
    public static long JoltsSum(IEnumerable<IEnumerable<int>> input, int numberCount) {
        return input.Sum(
            x => MaxJolts(x.ToArray(), new List<int>(numberCount), numberCount)
        );
    }

    private static long MaxJolts(ArraySegment<int> line, List<int> solutionBuffer, int numberCount) {
        if (numberCount == 0) {
            return SumByDigits(solutionBuffer);
        }

        var (nextSolutionNumberIndex, nextSolutionNumber) = line
            .SkipLast(numberCount - 1)
            .Index()
            .MaxBy(x => x.Item);
        solutionBuffer.Add(nextSolutionNumber);

        return MaxJolts(line.Slice(nextSolutionNumberIndex + 1), solutionBuffer, numberCount - 1);
    }

    private static long SumByDigits(IEnumerable<int> digits) {
        return digits
            .Reverse()
            .Index()
            .Sum<(int index, int digit)>(t => (long)(t.digit * Math.Pow(10, t.index)));
    }
}