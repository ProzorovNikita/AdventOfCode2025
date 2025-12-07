using Day7;

var input = Parser.GetField();

Console.WriteLine($"splits count: {Solver.CountSplits(input)}");
Console.WriteLine($"quantum splits count: {Solver.CountQuantumSplits(input)}");