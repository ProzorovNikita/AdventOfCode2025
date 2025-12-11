var input = Parser.GetInput();

var binaryStateResult = input.Sum(Solver.GetMinButtonClicksCountForBinaryState);

Console.WriteLine($"Binary machine result: {binaryStateResult}");
