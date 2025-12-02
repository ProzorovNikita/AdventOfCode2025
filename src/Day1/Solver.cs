namespace Day1;

public static class Solver {
    public static int SimpleMethod(IEnumerable<int> input) {
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

    public static int ClickMethod(IEnumerable<int> input) {
        var result = 0;
        var currentPoint = 50;

        foreach (var i in input) {
            var clicks = CountClicks(currentPoint, i);

            result += clicks;
            currentPoint += i;
        }

        return result;
    }


    private static int CountClicks(int initialPosition, int rotateValue) {
        var distance = Math.Abs(rotateValue);
    
        var clicks = distance / 100;

        var normalizeInitialPosition = Normalize(initialPosition);
        var newNormalizePosition = normalizeInitialPosition + (rotateValue % 100);
        if (newNormalizePosition is >= 100 or <= 0 && normalizeInitialPosition != 0) {
            clicks++;
        }

        return clicks;
    }
    
    private static int Normalize(int value) {
        value %= 100;
        return value < 0 ? value + 100 : value;
    }
}