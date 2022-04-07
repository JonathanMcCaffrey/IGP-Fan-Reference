using System.Collections.Generic;

namespace Model.MemoryTester;

public class MemoryQuestionModel
{
    public static List<MemoryQuestionModel> TestData = new()
    {
        new MemoryQuestionModel { Id = 1, MemoryEntityModelId = 1, Name = "Range", Answer = 600, IsRevealed = false },
        new MemoryQuestionModel { Id = 2, MemoryEntityModelId = 2, Name = "Range", Answer = 600, IsRevealed = false },
        new MemoryQuestionModel { Id = 3, MemoryEntityModelId = 3, Name = "Range", Answer = 600, IsRevealed = false },
        new MemoryQuestionModel { Id = 4, MemoryEntityModelId = 4, Name = "Range", Answer = 600, IsRevealed = false }
    };

    public int Id { get; set; }
    public int MemoryEntityModelId { get; set; }

    public string Name { get; set; }
    public int Guess { get; set; }
    public int Answer { get; set; }
    public bool IsRevealed { get; set; }
}