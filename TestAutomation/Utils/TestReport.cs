using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace TestAutomation.Utils;

public class TestReport
{
    private List<Test> Tests { get; } = new();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Test CreateTest()
    {
        Tests.Add(new Test
        {
            Name = TestContext.CurrentContext.Test.Name
        });
        return Tests.Last();
    }

    public void ThrowErrors()
    {
        if (!Tests.Last().Result)
        {
            string messages = string.Join("\n", Tests.Last().Messages.Select(x => x.Description).ToList());
            
            throw new Exception(
                $"{Tests.Last().Name} test failed with {Tests.Last().Messages.Count} messages.\n\n{messages}");
        }
        
    }

    public async Task VerifyLinks(BasePage page)
    {
        foreach (var link in page.GetLinks())
            try
            {
                if(link.StartsWith("mailto")) continue;
                
                using var client = new HttpClient();
                var response = await client.GetAsync(link);

                if (!response.IsSuccessStatusCode)
                {
                    CheckPassed(false,
                        new TestMessage
                        {
                            Color = "red", Title = "Bad Link",
                            Description = $"{link} failed on page {page.Url} with status code {response.StatusCode}"
                        });
                    Console.WriteLine(response.StatusCode.ToString());
                }
            }
            catch (Exception e)
            {
                CheckPassed(false,
                    new TestMessage
                    {
                        Color = "red", Title = "Bad Link",
                        Description = $"{link} failed on page {page.Url} with stacktrace {e.StackTrace}"
                    });
            }
    }


    public void CheckPassed(bool passed, TestMessage message)
    {
        if (passed) return;
        Tests.Last().Result = false;
        Tests.Last().Messages.Add(message);
    }

    public bool DidTestsPass()
    {
        foreach (var test in Tests)
        {
            if (test.Result) continue;

            return false;
        }


        return true;
    }

    public List<object> GetMessages()
    {
        if (DidTestsPass())
            return new List<object>
            {
                new
                {
                    title = "Passed",
                    color = int.Parse("00FF00", NumberStyles.HexNumber),
                    description = $"All {Tests.Count} tests passed."
                }
            };

        var messageList = new List<object>();
        foreach (var test in Tests)
        foreach (var message in test.Messages)
            messageList.Add(
                new
                {
                    title = message.Title,
                    color = int.Parse(message.Color, NumberStyles.HexNumber),
                    description = message.Description
                });


        return messageList;
    }
}