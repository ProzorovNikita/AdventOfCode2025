using Day10;

var input = Parser.GetInput().ToList();

var binaryStateResult = input.Sum(Solver.GetMinButtonClicksCountForBinaryState);

Console.WriteLine($"Binary machine result: {binaryStateResult}");

var complexStateResult = input.Sum(Solver.GetMinButtonClicksCountForComplexState);

Console.WriteLine($"Complex state machine result: {complexStateResult}");
