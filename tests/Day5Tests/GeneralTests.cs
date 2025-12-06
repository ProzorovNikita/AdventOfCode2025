using Day5;

namespace Day5Tests;

public class GeneralTests {
    [Fact]
    public void Solver_Should_Count_Fresh_Ids_From_List() {
        var ranges = Parser.GetRanges();
        var ids = Parser.GetIds();

        var result = Solver.GetFreshIdCount(ranges.ToArray(), ids);

        Assert.Equal(3, result);
    }

    [Fact]
    public void Solver_Should_Count_All_Fresh_Ids() {
        var ranges = Parser.GetRanges();

        var result = Solver.GetAllRangesCount(ranges);

        Assert.Equal(14, result);
    }
}