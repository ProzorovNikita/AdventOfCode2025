using Day1;

var input = Parser.GetInput().ToList();

Console.WriteLine($"simple method result: {Solver.SimpleMethod(input)}");
Console.WriteLine($"click method result: {Solver.ClickMethod(input)}");
