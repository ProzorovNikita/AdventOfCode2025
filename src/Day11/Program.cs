using Day11;

var input = Parser.GetInput(File.ReadLines("input.txt"));

var pathsCount = Solver.GetPathsCount(input["you"], []);
var pathsCountWithRestriction = Solver.GetPathsCount(input["svr"], ["dac", "fft"]);

Console.WriteLine($"Paths count: {pathsCount}");
Console.WriteLine($"Paths with restriction: {pathsCountWithRestriction}");