
var input = GetInput();

var ids = input
    .SelectMany(x => {
        var split =  x.Split("-");
        var start =  long.Parse(split[0]);
        var end =  long.Parse(split[1]);

        return LongRange(start, end).Select(n => n.ToString());
    })
    .ToList();

var invalidCountForTwoRepetitions = ids.Where(x => !IsValidForTwoRepetitions(x)).Sum(long.Parse);
var invalidCountForAnyRepetitions = ids.Where(x => !IsValidForAnyRepetitions(x)).Sum(long.Parse);

Console.WriteLine($"invalid ids count for two repetitions: {invalidCountForTwoRepetitions}");
Console.WriteLine($"invalid ids count for any repetitions: {invalidCountForAnyRepetitions}");

return;

static bool IsValidForTwoRepetitions(string id) {
    if (id.Length % 2 != 0) {
        return true;
    }
    
    return IsValidForRepetitions(id,  id.Length / 2);
}

static bool IsValidForAnyRepetitions(string id) {
    for (var i = 1; i < id.Length; i++) {
        if (!IsValidForRepetitions(id, i)) {
            return false;
        }
    }

    return true;
}

static bool IsValidForRepetitions(string id, int charsInRepetitions) {
    if (id.Length % charsInRepetitions != 0) {
        return true;
    }

    var firstChunk = id[..charsInRepetitions];

    return id
        .Chunk(charsInRepetitions)
        .Skip(1)
        .Any(chunk => !chunk.SequenceEqual(firstChunk));
}

IEnumerable<long> LongRange(long start, long end) {
    for (var i = start; i < end + 1; i++) {
        yield return i;
    }
}

string[] GetInput() {
    var content = File.ReadAllText("input.txt");
    return content.Split(",");
}



