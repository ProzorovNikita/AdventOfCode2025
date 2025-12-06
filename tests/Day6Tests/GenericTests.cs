using Day6;

namespace Day6Tests;

public class GenericTests {
    [Fact]
    public void Solver_Should_Count_Sum_Of_Answers() {
        var result = Solver.GetAnswersSum();
        
        Assert.Equal(4277556, result);
    }
    
    [Fact]
    public void Solver_Should_Count_Sum_Of_Answers_For_Individual_Columns() {
        var result = Solver.GetAnswersSumForIndividualColumns();
        
        Assert.Equal(3263827, result);
    }
}