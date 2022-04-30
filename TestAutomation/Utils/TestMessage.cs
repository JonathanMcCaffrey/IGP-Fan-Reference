namespace TestAutomation.Utils;

public class TestMessage
{
    public string Title { get; set; } = "Name...";
    public string Description { get; set; } = "";
    public string Color { get; set; } = "FFFFFF";

    public static TestMessage CreateFailedMessage(string description)
    {
        return new TestMessage { Title = "Check Failed", Description = description, Color = "FF0000" };
    }
}