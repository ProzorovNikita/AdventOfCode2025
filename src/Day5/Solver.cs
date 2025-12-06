namespace Day5;

public static class Solver {
    public static int GetFreshIdCount(Range[] ranges, IEnumerable<long> ids) {
        return ids.Count(id => ranges.Any(r => r.IsInRange(id)));
    }

    public static long GetAllRangesCount(IEnumerable<Range> ranges) {
        var nonIntersectingRanges = new List<Range>();
        var orderedRanges = ranges.OrderBy(r => r.From);
        
        foreach (var range in orderedRanges) {
            var isAdded = false;
            foreach (var existingRange in nonIntersectingRanges) {
                if (existingRange.TryAddRange(range)) {
                    isAdded = true;
                    break;
                }
            }

            if (!isAdded) {
                nonIntersectingRanges.Add(range);
            }
        }
        
        return nonIntersectingRanges.Sum(r => r.CountIds());
    }
}