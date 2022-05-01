using System.Text;
using Newtonsoft.Json;

namespace TestAutomation;

[SetUpFixture]
public class Tests : BaseTest
{
    [OneTimeSetUp]
    public void Setup()
    {
        Website.WebDriver.Navigate().GoToUrl(WebsiteUrl);
        Website.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        HttpClient HttpClient = new();

        Website.WebDriver.Quit();

        var message = new
        {
            content = "Test Report " + DateTime.Now.ToString("dd/MM/yyyy"),
            embeds = TestReport.GetMessages()
        };

        var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");

        if (Environment.GetEnvironmentVariable("TEST_HOOK") == null) return;

        HttpClient.PostAsync(Environment.GetEnvironmentVariable("TEST_HOOK"), content).Wait();
    }
}