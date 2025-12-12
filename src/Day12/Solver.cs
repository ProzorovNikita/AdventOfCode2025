namespace Day12;

public static class Solver {
    public static int GetValidRegionsCount(Input input) {
        var validRegionsCount = 0;
        foreach (var c in input.Cases) {
            // we know that input contains only 3x3 shapes.
            var box3X3InLine = c.Width / 3;
            var box3X3InColumn = c.Height / 3;
            var box3X3Available = box3X3InLine *  box3X3InColumn;

            var boxes3X3Needed = c.ShapesCount.Sum();
            

            if (box3X3Available >= boxes3X3Needed) {
                validRegionsCount++;
                continue;
            }

            var shapesCapacity = c.ShapesCount.Index().Sum(t => t.Item * GetCapacity(input.Shapes[t.Index]));
            var totalCapacity = c.Height * c.Width;
            
            if (shapesCapacity > totalCapacity) {
                continue;
            }

            throw new NotImplementedException("What the hell should I do here?");
        }

        return validRegionsCount;
    }

    private static int GetCapacity(Shape shape) {
        return shape.Layout.SelectMany(l => l).Count(c => c);
    }
}