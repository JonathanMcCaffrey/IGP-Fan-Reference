using System.Text;
using Newtonsoft.Json;
using TestAutomation.Utils;

namespace TestAutomation;

public class Tests {
    private readonly IWebDriver _webDriver = default!;
    private readonly string develop = "https://calm-mud-04916b210.1.azurestaticapps.net/";

    private readonly HttpClient httpClient = new();


    private readonly string localhost = "https://localhost:7234";

    private readonly TestReport testReport = new();

    public Tests() {
        var options = new FirefoxOptions();

        options.AcceptInsecureCertificates = true;
        options.AddArgument("--headless");
        options.AddArgument("--ignore-certificate-errors");
        options.AddArgument("--start-maximized");
        options.AddArgument("--test-type");
        options.AddArgument("--allow-running-insecure-content");

        _webDriver = new FirefoxDriver(Environment.CurrentDirectory, options);

        Website = new Website(_webDriver);
    }

    private Website Website { get; }

    [OneTimeSetUp]
    public void Setup() {
        _webDriver.Navigate().GoToUrl(develop);
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
    }

    [OneTimeTearDown]
    public void TearDown() {
        _webDriver.Quit();


        var message = new {
            content = "Test Report " + DateTime.Now.ToString("dd/MM/yyyy"),
            embeds = testReport.GetMessages()
        };

        var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");

        httpClient.PostAsync(Environment.GetEnvironmentVariable("TEST_HOOK"), content).Wait();
    }

    [Test]
    public void HarassCalculator() {
        testReport.CreateTest();

        _webDriver.Navigate().GoToUrl(develop + "/harass-calculator");

        var expectedTotalAlloyHarassment = 240;

        try {
            Website.HarassCalculatorPage
                .SetWorkersLostToHarass(3)
                .SetNumberOfTownHallsExisting(2)
                .SetTownHallTravelTime(0, 30)
                .GetTotalAlloyHarassment(out var foundTotalAlloyHarassment);

            testReport.CheckPassed(expectedTotalAlloyHarassment.Equals(foundTotalAlloyHarassment),
                TestMessage.CreateFailedMessage($"expectTotalAlloyHarassment of {expectedTotalAlloyHarassment} " +
                                                "does not equal " +
                                                $"foundTotalAlloyHarassment of {foundTotalAlloyHarassment} "));
        }
        catch (Exception e) {
            testReport.CheckPassed(false,
                TestMessage.CreateFailedMessage(e.StackTrace!));
        }
    }

    [Test]
    public void HarassCalculatorInformation() {
        testReport.CreateTest();

        _webDriver.Navigate().GoToUrl(develop + "/harass-calculator");

        var expectedExampleTotalAlloyLoss = 720;
        var expectedExampleWorkerCost = 300;
        var expectedExampleMiningTimeCost = 420;
        var expectedExampleTotalAlloyLossDifference = 300;
        var expectedExampleTotalAlloyLossAccurate = 450;
        var expectedExampleTotalAlloyLossAccurateDifference = 270;

        Website.HarassCalculatorPage
            .GetExampleTotalAlloyLoss(out var foundTotalAlloyLoss)
            .GetExampleWorkerCost(out var foundExampleWorkerCost)
            .GetExampleMiningTimeCost(out var foundExampleMiningTimeCost)
            .GetExampleTotalAlloyLossAccurate(out var foundExampleTotalAlloyLossAccurate)
            .GetExampleTotalAlloyLossDifference(out var foundGetExampleTotalAlloyLossDifference)
            .GetExampleTotalAlloyLossAccurateDifference(out var foundExampleTotalAlloyLossAccurateDifference);

        testReport.CheckPassed(expectedExampleTotalAlloyLoss.Equals(foundTotalAlloyLoss),
            TestMessage.CreateFailedMessage($"expectedExampleTotalAlloyLoss of {expectedExampleTotalAlloyLoss} " +
                                            "does not equal " +
                                            $"foundTotalAlloyLoss of {foundTotalAlloyLoss} "));

        testReport.CheckPassed(expectedExampleWorkerCost.Equals(foundExampleWorkerCost),
            TestMessage.CreateFailedMessage($"expectedExampleWorkerCost of {expectedExampleWorkerCost} " +
                                            "does not equal " +
                                            $"foundExampleWorkerCost of {foundExampleWorkerCost} "));


        testReport.CheckPassed(expectedExampleMiningTimeCost.Equals(foundExampleMiningTimeCost),
            TestMessage.CreateFailedMessage($"expectedExampleMiningTimeCost of {expectedExampleMiningTimeCost} " +
                                            "does not equal " +
                                            $"foundExampleMiningTimeCost of {foundExampleMiningTimeCost} "));


        testReport.CheckPassed(expectedExampleTotalAlloyLossAccurate.Equals(foundExampleTotalAlloyLossAccurate),
            TestMessage.CreateFailedMessage(
                $"expectedExampleTotalAlloyLossAccurate of {expectedExampleTotalAlloyLossAccurate} " +
                "does not equal " +
                $"foundExampleTotalAlloyLossAccurate of {foundExampleTotalAlloyLossAccurate} "));


        testReport.CheckPassed(expectedExampleTotalAlloyLossDifference.Equals(foundGetExampleTotalAlloyLossDifference),
            TestMessage.CreateFailedMessage(
                $"expectedExampleTotalAlloyLossDifference of {expectedExampleTotalAlloyLossDifference} " +
                "does not equal " +
                $"foundGetExampleTotalAlloyLossDifference of {foundGetExampleTotalAlloyLossDifference} "));


        testReport.CheckPassed(
            expectedExampleTotalAlloyLossAccurateDifference.Equals(foundExampleTotalAlloyLossAccurateDifference),
            TestMessage.CreateFailedMessage(
                $"expectedExampleTotalAlloyLossAccurateDifference of {expectedExampleTotalAlloyLossAccurateDifference} " +
                "does not equal " +
                $"foundExampleTotalAlloyLossAccurateDifference of {foundExampleTotalAlloyLossAccurateDifference} "));
    }
}