using System.Diagnostics;

var input = GetInput().ToList();

Console.WriteLine($"simple method result: {SimpleMethod(input)}");
Console.WriteLine($"click method result: {ClickMethod(input)}");

return;

static int SimpleMethod(IEnumerable<int> input) {
    var result = 0;
    var currentPoint = 50;

    foreach (var i in input) {
        currentPoint += i;

        if (currentPoint % 100 == 0) {
            result++;
        }
    }

    return result;
}

static int ClickMethod(IEnumerable<int> input) {
    var result = 0;
    var currentPoint = 50;

    foreach (var i in input) {
        var clicks = CountClicks(currentPoint, i);

        result += clicks;
        currentPoint += i;
    }

    return result;
}


static int CountClicks(int initialPosition, int rotateValue) {
    var distance = Math.Abs(rotateValue);
    
    var clicks = distance / 100;

    var normalizeInitialPosition = Normalize(initialPosition);
    var newNormalizePosition = normalizeInitialPosition + (rotateValue % 100);
    if (newNormalizePosition is >= 100 or <= 0 && normalizeInitialPosition != 0) {
        clicks++;
    }

    return clicks;
}

static List<int> ParseInput(IEnumerable<string> input) {
    return input
        .Select(s => {
            var direction = s[0];
            var number = int.Parse(s.AsSpan()[1..]);
            
            return direction switch {
                'R' => number,
                'L' => number * -1,
                _ => throw new UnreachableException(),
            };
        })
        .ToList();
}

static int Normalize(int value) {
    value %= 100;
    return value < 0 ? value + 100 : value;
}

static IEnumerable<int> GetInput() {
    var content = File.ReadAllLines("input.txt");

    return ParseInput(content.Where(s => !string.IsNullOrWhiteSpace(s)));
}