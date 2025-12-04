using Day4;

namespace Day4Tests;

public class GeneralTests {
    [Fact]
    public void Solver_Should_Solve_For_One_Repeat() {
        var input = Parser.GetInput();

        var result = Solver.CountMovable(input, false);
        
        Assert.Equal(13, result);
    }
    
    [Fact]
    public void Solver_Should_Solve_For_Many_Repeats() {
        var input = Parser.GetInput();

        var result = Solver.CountMovable(input, true);
        
        Assert.Equal(43, result);
    }
}