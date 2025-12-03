using Day3;

namespace Day3Tests;

public class GeneralTests {
    [Fact]
    public void Solver_Should_Evaluate_Max_Jolts_For_2_Numbers() 
    {
        var input = Parser.GetInput();

        var result = Solver.JoltsSum(input, 2);
        
        Assert.Equal(357, result);
    }
    
    [Fact]
    public void Solver_Should_Evaluate_Max_Jolts_For_12_Numbers() 
    {
        var input = Parser.GetInput();

        var result = Solver.JoltsSum(input, 12);
        
        Assert.Equal(3121910778619, result);
    }
}