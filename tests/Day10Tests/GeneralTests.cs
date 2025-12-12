using Day10;

namespace Day10Tests;

public class GeneralTests {
    [Fact]
    public void Solver_Should_Solve_For_Binary_State() {
        var input = Parser.GetInput().ToList();

        var result = input.Sum(Solver.GetMinButtonClicksCountForBinaryState);

        Assert.Equal(7, result);
    }
    
    [Fact]
    public void Solver_Should_Solve_For_Complex_State() {
        var input = Parser.GetInput().ToList();

        var result = input.Sum(Solver.GetMinButtonClicksCountForComplexState);

        Assert.Equal(38, result);
    }
    
    // [.##..#] (1,2,5) (0,1,2,3) (0,4,5) (0,3) {17,21,21,17,0,5}
    [Fact]
    public void Solver_Should_Solve_For_Complex_State_2() {
        var input = new MachineInfo {
            Joltages = [17, 21, 21, 17, 0, 5],
            Buttons = [0b100110, 0b001111, 0b110001, 0b001001],
            FinalStateLength = 6,
            FinalBinaryState = 0,
        };

        var result = Solver.GetMinButtonClicksCountForComplexState(input);

        Assert.Equal(38, result);
    }
    
    // [.##..#] (1,2,5) (0,1,2,3) (0,4,5) (0,3) {17,21,21,17,0,5}
    [Fact]
    public void Solver_Should_Solve_For_Complex_State_3() {
        var input = new MachineInfo {
            Joltages = [17, 21, 21, 17, 0, 5],
            Buttons = [0b100110, 0b001111, 0b110001, 0b001001],
            FinalStateLength = 6,
            FinalBinaryState = 0,
        };

        var result = Solver.GetMinButtonClicksCountForComplexState(input);

        Assert.Equal(22, result);
    }
}