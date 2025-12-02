using Day2;

namespace Day2Tests;

public class GeneralTests {
    [Fact]
    public void Solver_Solves_Correctly_For_Two_Repetitions() {
        var input = Parser.GetInput();
        
        var result = Solver.CountForTwoRepetitions(input);
        
        Assert.Equal(1227775554, result);
    }
    
    [Fact]
    public void Solver_Solves_Correctly_For_Any_Repetitions() {
        var input = Parser.GetInput();
        
        var result = Solver.CountForAnyRepetitions(input);
        
        Assert.Equal(4174379265, result);
    }
}