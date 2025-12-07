using System.Runtime.InteropServices;

namespace Day7;

public static class Solver {
    public static long CountQuantumSplits(CellType[][] cells) {
        var start = GetStartLocation(cells);

        Dictionary<int, long> currentBeams = new();
        currentBeams.Add(start.j, 1);
        long counter = 1;
        
        foreach (var (i, _) in cells.Skip(start.i + 1).Index()) {
            foreach (var (j, _) in currentBeams.ToList()) {
                if (cells[i][j] != CellType.Splitter) {
                    continue;
                }

                var currentBeamValue = currentBeams[j];
                if (j + 1 < cells[i].Length) {
                    IncrementBeam(j + 1, currentBeamValue);
                }

                if (j - 1 >= 0) {
                    IncrementBeam(j - 1, currentBeamValue);
                }

                counter += currentBeamValue;
                currentBeams.Remove(j);
            }
        }

        return counter;

        void IncrementBeam(int j, long increament) {
            ref var counter = ref CollectionsMarshal.GetValueRefOrAddDefault(currentBeams, j, out var _);
            counter += increament;
        }
    }

    public static int CountSplits(CellType[][] cells) {
        var start = GetStartLocation(cells);

        HashSet<int> currentBeams = [start.j];
        var splitsCounter = 0;
        foreach (var (i, _) in cells.Skip(start.i + 1).Index()) {
            foreach (var j in currentBeams.ToList()) {
                if (cells[i][j] != CellType.Splitter) {
                    continue;
                }

                splitsCounter++;
                
                if (j + 1 < cells[i].Length) {
                    currentBeams.Add(j + 1);
                }

                if (j - 1 >= 0) {
                    currentBeams.Add(j - 1);
                }

                currentBeams.Remove(j);
            }
        }

        return splitsCounter;
    }
    
    private static (int i, int j) GetStartLocation(CellType[][] cells) {
        return (from line in cells.Index()
                from cell in line.Item.Index().Select(cell => (line.Index, cell.Index, cell.Item))
                where cell.Item == CellType.Start
                select (i: cell.Item1, j: cell.Item2))
            .First();
    }
}