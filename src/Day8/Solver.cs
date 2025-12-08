namespace Day8;

public static class Solver {
    public static long GetLastJunctionXCoordProduct(Box[] boxes) {
        InitializeCircuits(boxes);
        var distanceMatrix = InitializeDistanceMatrix(boxes);
        var circuitsCount = boxes.Length;

        while (true) {
            var (minDistancei, minDistancej) = GetMinimumDistance(distanceMatrix);

            distanceMatrix[minDistancei, minDistancej] = 0;
            distanceMatrix[minDistancej, minDistancei] = 0;

            var box1 = boxes[minDistancei];
            var box2 = boxes[minDistancej];
            if (JoinCircuits(boxes, box1, box2)) {
                circuitsCount--;
            }

            if (circuitsCount == 1) {
                return (long) box1.X * (long) box2.X;
            }
        }
    }

    public static long GetCircuitProduct(Box[] boxes, int junctionsCount, int circuitsCount) {
        InitializeCircuits(boxes);
        var distanceMatrix = InitializeDistanceMatrix(boxes);
        for (var i = 0; i < junctionsCount; i++) {
            var (minDistancei, minDistancej) = GetMinimumDistance(distanceMatrix);

            distanceMatrix[minDistancei, minDistancej] = 0;
            distanceMatrix[minDistancej, minDistancei] = 0;

            var box1 = boxes[minDistancei];
            var box2 = boxes[minDistancej];
            JoinCircuits(boxes, box1, box2);
        }    
        
        return boxes
            .GroupBy(box => box.Circuit)
            .Select(group => group.Count())
            .OrderByDescending(c => c)
            .Take(circuitsCount)
            .Aggregate((a, b) => a * b);
    }

    private static void InitializeCircuits(Box[] boxes) {
        for (var i = 0; i < boxes.Length; i++) {
            boxes[i].Circuit = i + 1;
        }
    }

    private static double[,] InitializeDistanceMatrix(Box[] boxes) {
        var distanceMatrix = new double[boxes.Length, boxes.Length];
        for (int i = 0; i < boxes.Length; i++) {
            for (int j = i; j < boxes.Length; j++) {
                var distance = GetDistance(boxes[i], boxes[j]);
                distanceMatrix[i, j] = distance;
                distanceMatrix[j, i] = distance;
            }
        }

        return distanceMatrix;
    }

    private static (int minDistancei, int minDistancej) GetMinimumDistance(double[,] distanceMatrix) {
        var minDistance = double.MaxValue;
        var (minDistancei, minDistancej) = (-1, -1);
        for (var i = 0; i < distanceMatrix.GetLength(0); i++) {
            for (int j = i; j < distanceMatrix.GetLength(1); j++) {
                var distance = distanceMatrix[i, j];
                if (distance != 0 && distance < minDistance) {
                    minDistance = distance;
                    minDistancei = i;
                    minDistancej = j;
                }
            }
        }

        return (minDistancei, minDistancej);
    }

    private static bool JoinCircuits(Box[] boxes, Box box1, Box box2) {
        if (box1.Circuit == box2.Circuit) {
            return false;
        }
        
        var otherCircuit = box1.Circuit;
        foreach (var box in boxes.Where(c => c.Circuit == otherCircuit)) {
            box.Circuit = box2.Circuit;
        }

        return true;
    }

    private static double GetDistance(Box b1, Box b2) {
        if (b1 == b2) {
            return 0;
        }

        return Math.Sqrt(Math.Pow(b1.X - b2.X, 2) + Math.Pow(b1.Y - b2.Y, 2) + Math.Pow(b1.Z - b2.Z, 2));
    }
}