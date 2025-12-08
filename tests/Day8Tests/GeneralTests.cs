using Day8;

namespace Day8Tests;

public class GeneralTests {
    [Fact]
    public void Solver_Should_Get_Circuit_Product() {
        var input = Parser.GetInput();

        var result = Solver.GetCircuitProduct(input, 10, 3);
        
        Assert.Equal(40, result);
    }
    
    [Fact]
    public void Solver_Should_Get_Last_Boxes_X_Coord_Product() {
        var input = Parser.GetInput();

        var result = Solver.GetLastJunctionXCoordProduct(input);
        
        Assert.Equal(25272, result);
    }
}