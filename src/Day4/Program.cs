using Day4;

var countForOneRepeat = Solver.CountMovable(Parser.GetInput());
var countForManyRepeat = Solver.CountMovable(Parser.GetInput(), true);

Console.WriteLine($"count for one repeat: {countForOneRepeat}");
Console.WriteLine($"count for many repeat: {countForManyRepeat}");
