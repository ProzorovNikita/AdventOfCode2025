
using Day2;

var input = Parser.GetInput();

var invalidCountForTwoRepetitions = Solver.CountForTwoRepetitions(input);
var invalidCountForAnyRepetitions = Solver.CountForAnyRepetitions(input);

Console.WriteLine($"invalid ids count for two repetitions: {invalidCountForTwoRepetitions}");
Console.WriteLine($"invalid ids count for any repetitions: {invalidCountForAnyRepetitions}");