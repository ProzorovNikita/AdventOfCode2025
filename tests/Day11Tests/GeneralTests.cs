using Day11;

namespace Day11Tests;

public class GeneralTests {
    [Fact]
    public void Test1() {
        var input = Parser.GetInput(File.ReadLines("input.txt"));
        
        var result = Solver.GetPathsCount(input["you"], []);
        
        Assert.Equal(5, result);
    }
    
    [Fact]
    public void Test2() {
        var input = Parser.GetInput(File.ReadLines("input2.txt"));
        
        var result = Solver.GetPathsCount(input["svr"], ["dac", "fft"]);
        
        Assert.Equal(2, result);
    }
}