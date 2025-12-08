using Day8;

var input = Parser.GetInput();

Console.WriteLine($"circuits size {Solver.GetCircuitProduct(input, 1000, 3)}");
Console.WriteLine($"product of X coord of last boxes {Solver.GetLastJunctionXCoordProduct(input)}");