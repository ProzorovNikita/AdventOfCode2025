using Day1;

namespace Day1Tests;

public class GeneralTests {
    [Fact]
    public void Solver_Solves_Correctly_For_Simple_Method() {
        var input = Parser.GetInput().ToList();

        var result = Solver.SimpleMethod(input);
        
        Assert.Equal(3, result);
    }
    
    [Fact]
    public void Solver_Solves_Correctly_For_Click_Method() {
        var input = Parser.GetInput().ToList();

        var result = Solver.ClickMethod(input);
        
        Assert.Equal(6, result);
    }
}