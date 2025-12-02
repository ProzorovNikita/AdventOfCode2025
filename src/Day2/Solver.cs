namespace Day2;

public static class Solver {
    public static long CountForTwoRepetitions(IEnumerable<string> idRanges) {
        var ids = ExplodeRanges(idRanges);

        return ids.Where(x => !IsValidForTwoRepetitions(x)).Sum(long.Parse);
    }

    public static long CountForAnyRepetitions(IEnumerable<string> idRanges) {
        var ids = ExplodeRanges(idRanges);

        return ids.Where(x => !IsValidForAnyRepetitions(x)).Sum(long.Parse);
    }

    private static List<string> ExplodeRanges(IEnumerable<string> idRanges) {
        var ids = idRanges
            .SelectMany(x => {
                var split =  x.Split("-");
                var start =  long.Parse(split[0]);
                var end =  long.Parse(split[1]);

                return LongRange(start, end).Select(n => n.ToString());
            })
            .ToList();
        return ids;
    }

    private static bool IsValidForTwoRepetitions(string id) {
        if (id.Length % 2 != 0) {
            return true;
        }
    
        return IsValidForRepetitions(id,  id.Length / 2);
    }

    private static bool IsValidForAnyRepetitions(string id) {
        for (var i = 1; i < id.Length; i++) {
            if (!IsValidForRepetitions(id, i)) {
                return false;
            }
        }

        return true;
    }

    private static IEnumerable<long> LongRange(long start, long end) {
        for (var i = start; i < end + 1; i++) {
            yield return i;
        }
    }

    private static bool IsValidForRepetitions(string id, int charsInRepetitions) {
        if (id.Length % charsInRepetitions != 0) {
            return true;
        }

        var firstChunk = id[..charsInRepetitions];

        return id
            .Chunk(charsInRepetitions)
            .Skip(1)
            .Any(chunk => !chunk.SequenceEqual(firstChunk));
    }
}