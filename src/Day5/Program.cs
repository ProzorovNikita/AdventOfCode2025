using Day5;

var reshIdsFromList = Solver.GetFreshIdCount(Parser.GetRanges().ToArray(), Parser.GetIds());
var allFreshIds = Solver.GetAllRangesCount(Parser.GetRanges());

Console.WriteLine($"fresh ids from list: {reshIdsFromList}");
Console.WriteLine($"all fresh ids: {allFreshIds}");