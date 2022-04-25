
namespace TestAutomation;

public class Tests
{
    private IWebDriver _webDriver = default!;


    private readonly string localhost = "https://localhost:7234";
    private readonly string develop = "https://calm-mud-04916b210.1.azurestaticapps.net/";


    private Website Website { get; }

    public Tests() {
        //var options = new FirefoxOptions();
        var options = new ChromeOptions();

        options.AcceptInsecureCertificates = true;

#if !DEBUG
    options.AddArgument("--headless");
#endif

        options.AddArgument("--start-maximized");

        //_webDriver = new FirefoxDriver(options);
        _webDriver = new ChromeDriver(options);

        Website = new Website(_webDriver);
    }

    [OneTimeSetUp]
    public void Setup()
    {
        _webDriver.Navigate().GoToUrl(localhost);
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _webDriver.Quit();
    }

    [Test]
    public void HarassCalculator()
    {
        _webDriver.Navigate().GoToUrl(localhost + "/harass-calculator");

        int expectedTotalAlloyHarassment = 240;

        Website.HarassCalculatorPage
            .SetWorkersLostToHarass(3)
            .SetNumberOfTownHallsExisting(2)
            .SetTownHallTravelTime(0, 30)
            .GetTotalAlloyHarassment(out var foundTotalAlloyHarassment);
        
        Assert.True(expectedTotalAlloyHarassment.Equals(foundTotalAlloyHarassment), 
            $"expectTotalAlloyHarassment of {expectedTotalAlloyHarassment} " +
            "does not equal " +
            $"foundTotalAlloyHarassment of {foundTotalAlloyHarassment} ");

    }
    
    [Test]
    public void HarassCalculatorInformation()
    {
        _webDriver.Navigate().GoToUrl(localhost + "/harass-calculator");
        
        int expectedExampleTotalAlloyLoss = 720;
        int expectedExampleWorkerCost = 300;
        int expectedExampleMiningTimeCost = 420;
        int expectedExampleTotalAlloyLossDifference =  300;
        int expectedExampleTotalAlloyLossAccurate = 450;
        int expectedExampleTotalAlloyLossAccurateDifference = 270;

        Website.HarassCalculatorPage
            .GetExampleTotalAlloyLoss(out var foundTotalAlloyLoss)
            .GetExampleWorkerCost(out var foundExampleWorkerCost)
            .GetExampleMiningTimeCost(out var foundExampleMiningTimeCost)
            .GetExampleTotalAlloyLossAccurate(out var foundExampleTotalAlloyLossAccurate)
            .GetExampleTotalAlloyLossDifference(out var foundGetExampleTotalAlloyLossDifference)
            .GetExampleTotalAlloyLossAccurateDifference(out var foundExampleTotalAlloyLossAccurateDifference);
        
        Assert.True(expectedExampleTotalAlloyLoss.Equals(foundTotalAlloyLoss), 
            $"expectedExampleTotalAlloyLoss of {expectedExampleTotalAlloyLoss} " +
            "does not equal " +
            $"foundTotalAlloyLoss of {foundTotalAlloyLoss} ");
        
        Assert.True(expectedExampleWorkerCost.Equals(foundExampleWorkerCost), 
            $"expectedExampleWorkerCost of {expectedExampleWorkerCost} " +
            "does not equal " +
            $"foundExampleWorkerCost of {foundExampleWorkerCost} ");

        
        Assert.True(expectedExampleMiningTimeCost.Equals(foundExampleMiningTimeCost), 
            $"expectedExampleMiningTimeCost of {expectedExampleMiningTimeCost} " +
            "does not equal " +
            $"foundExampleMiningTimeCost of {foundExampleMiningTimeCost} ");
        
        
        Assert.True(expectedExampleTotalAlloyLossAccurate.Equals(foundExampleTotalAlloyLossAccurate), 
            $"expectedExampleTotalAlloyLossAccurate of {expectedExampleTotalAlloyLossAccurate} " +
            "does not equal " +
            $"foundExampleTotalAlloyLossAccurate of {foundExampleTotalAlloyLossAccurate} ");
        
        
        Assert.True(expectedExampleTotalAlloyLossDifference.Equals(foundGetExampleTotalAlloyLossDifference), 
            $"expectedExampleTotalAlloyLossDifference of {expectedExampleTotalAlloyLossDifference} " +
            "does not equal " +
            $"foundGetExampleTotalAlloyLossDifference of {foundGetExampleTotalAlloyLossDifference} ");
        
        
        Assert.True(expectedExampleTotalAlloyLossAccurateDifference.Equals(foundExampleTotalAlloyLossAccurateDifference), 
            $"expectedExampleTotalAlloyLossAccurateDifference of {expectedExampleTotalAlloyLossAccurateDifference} " +
            "does not equal " +
            $"foundExampleTotalAlloyLossAccurateDifference of {foundExampleTotalAlloyLossAccurateDifference} ");
    }
}