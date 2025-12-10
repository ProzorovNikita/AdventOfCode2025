using System.Drawing;
using Day9;

namespace Day9Tests;

public class GenericTests {
    [Fact]
    public void Solver_Should_Find_Largest_Rectangle_Area() {
        var input = Parser.GetInput();
        
        var result = Solver.GetLargestRectangleArea(input.ToArray());
        
        Assert.Equal(50, result);
    }
    
    [Fact]
    public void Solver_Should_Find_Largest_Rectangle_Area_In_Green_Zone() {
        var input = Parser.GetInput();
        
        var result = Solver.GetLargestRectangleAreaInGreenZone(input.ToArray());
        
        Assert.Equal(24, result);
    }
    
    /* #XXX#.
     * X...X.
     * X...X.
     * X...##
     * #XXXX# 
     */
    [Fact]
    public void Solver_Should_Find_Largest_Rectangle_Area_In_Green_Zone_2() {
        Point[] input = [
            new(1, 1),
            new(5, 1),
            new(5, 5),
            new(6, 5),
            new(6, 6),
            new(1, 6),
        ];
        
        var result = Solver.GetLargestRectangleAreaInGreenZone(input.ToArray());
        
        Assert.Equal(30, result);
    }
    
    /*
     * ##.......##
     * XX.......XX
     * XX.......XX
     * X#XXXXXXX#X
     * #XXXXXXXXX#
     */
    [Fact]
    public void Solver_Should_Find_Largest_Rectangle_Area_In_Green_Zone_4() {
        Point[] input = [
            new(1, 1),
            new(2, 1),
            new(2, 4),
            new(10, 4),
            new(10, 1),
            new(11, 1),
            new(11, 5),
            new(1, 5),
        ];
        
        var result = Solver.GetLargestRectangleAreaInGreenZone(input.ToArray());
        
        Assert.Equal(20, result);
    }
}