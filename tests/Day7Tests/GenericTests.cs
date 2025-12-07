using Day7;

namespace Day7Tests;

public class GenericTests {
    [Fact]
    public void Solver_Should_Count_Splits() {
        var input = Parser.GetField();
        
        var result = Solver.CountSplits(input);
        
        Assert.Equal(21, result);
    }
    
    [Fact]
    public void Solver_Should_Count_Quantum_Splits() {
        var input = Parser.GetField();
        
        var result = Solver.CountQuantumSplits(input);
        
        Assert.Equal(40, result);
    }
}