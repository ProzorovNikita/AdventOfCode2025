using Day9;

var input = Parser.GetInput().ToArray();

Console.WriteLine($"Largest rectangle is: {Solver.GetLargestRectangleArea(input)}");
Console.WriteLine($"Largest rectangle in green zone is: {Solver.GetLargestRectangleAreaInGreenZone(input)}");