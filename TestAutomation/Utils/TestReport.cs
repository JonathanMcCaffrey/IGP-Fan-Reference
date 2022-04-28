using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace TestAutomation.Utils;

public class TestReport {
    private List<Test> Tests { get; } = new();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Test CreateTest() {
        var testName = new StackTrace().GetFrame(1)!.GetMethod()!.Name!;
        Tests.Add(new Test { Name = testName });
        return Tests.Last();
    }

    public void CheckPassed(bool passed, TestMessage message) {
        if (passed) return;
        Tests.Last().Result = false;
        Tests.Last().Messages.Add(message);
    }

    public bool DidTestsPass() {
        foreach (var test in Tests) {
            if (test.Result) continue;

            return false;
        }


        return true;
    }

    public List<object> GetMessages() {
        if (DidTestsPass())
            return new List<object> {
                new {
                    title = "Passed",
                    color = int.Parse("00FF00", NumberStyles.HexNumber),
                    description = $"All {Tests.Count} tests passed."
                }
            };

        var messageList = new List<object>();
        foreach (var test in Tests)
        foreach (var message in test.Messages)
            messageList.Add(
                new {
                    title = message.Title,
                    color = int.Parse(message.Color, NumberStyles.HexNumber),
                    description = message.Description
                });


        return messageList;
    }
}