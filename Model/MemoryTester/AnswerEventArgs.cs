namespace Model.MemoryTester;

public class AnswerEventArgs
{
    public string Name { get; set; }
    public bool IsCorrect { get; set; }
    public int Guess { get; set; }
}