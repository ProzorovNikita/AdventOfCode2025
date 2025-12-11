public static class Solver {
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