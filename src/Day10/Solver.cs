using System.Diagnostics;

namespace Day10;
using GoogleMipSolver = Google.OrTools.LinearSolver.Solver;

public static class Solver {
    public static int GetMinButtonClicksCountForComplexState(MachineInfo machine) {
        var joltageSum = machine.Joltages.Sum();

        var solver = GoogleMipSolver.CreateSolver("SAT_INTEGER_PROGRAMMING");

        for (var i = 0; i < machine.Buttons.Count; i++) {
            solver.MakeIntVar(0, joltageSum, $"b{i}");
        }

        for (var i = 0; i < machine.Joltages.Count; i++) {
            var buttonsForJoltage = machine.Buttons.Index().Where(t => (t.Item & (1 << i)) != 0).ToList();
            var constraint = solver.MakeConstraint(machine.Joltages[i], machine.Joltages[i], $"joltage {i} is {machine.Joltages[i]}");
            foreach (var (buttonIndex, _) in buttonsForJoltage) {
                constraint.SetCoefficient(solver.variables()[buttonIndex], 1);
            }
        }

        var objective = solver.Objective();
        objective.SetMinimization();
        foreach (var variable in solver.variables()) {
            objective.SetCoefficient(variable, 1);
        }

        Debug.Assert(solver.variables().Count == machine.Buttons.Count());
        Debug.Assert(solver.constraints().Count == machine.Joltages.Count());
        
        var result = solver.Solve();

        if (result is not GoogleMipSolver.ResultStatus.OPTIMAL) {
            throw new Exception(result.ToString());
        }

        Debug.Assert(IsSolutionValid());

        return (int) solver.Objective().Value();

        bool IsSolutionValid() {
            for (var i = 0; i < machine.Joltages.Count; i++) {
                var joltage = machine.Joltages[i];
                var buttonsForJoltage = machine.Buttons.Index().Where(t => (t.Item & (1 << i)) != 0).ToList();
                var solutionJoltage = buttonsForJoltage.Sum(b => (int) solver.Variable(b.Index).SolutionValue());
                if (solutionJoltage != joltage) {
                    return false;
                }
            }

            return true;
        }
    } 
    
    public static int GetMinButtonClicksCountForBinaryState(MachineInfo machine) {
        HashSet<int> explored = [];
        var iterationsCount = 1;
        Queue<int> queue = [];
        Queue<int> nextQueue = [];
        queue.Enqueue(0);
        
        while (true) {
            while (queue.Count != 0) {
                var currentState = queue.Dequeue();
                foreach (var button in machine.Buttons) {
                    var buttonResult = currentState ^ button;
                    if (buttonResult == machine.FinalBinaryState) {
                        return iterationsCount;
                    }

                    if (!explored.Contains(buttonResult)) {
                        nextQueue.Enqueue(buttonResult);
                        explored.Add(buttonResult);
                    }
                }
            }

            queue = nextQueue;
            nextQueue = new Queue<int>();
            iterationsCount++;
        }
    }
}