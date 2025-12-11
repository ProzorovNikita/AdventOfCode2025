namespace Day10Tests;

public class GeneralTests {
    [Fact]
    public void Solver_Should_Solve_For_Binary_State() {
        var input = Parser.GetInput().ToList();

        var result = input.Sum(Solver.GetMinButtonClicksCountForBinaryState);

        Assert.Equal(7, result);
    }
}