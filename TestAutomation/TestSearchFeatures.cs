using TestAutomation.Utils;

namespace TestAutomation;

[TestFixture]
public class TestSearchFeatures : BaseTest
{
    [Test]
    public void DesktopOpenCloseSearchDialog()
    {
        TestReport.CreateTest();

        Website.WebDriver.Navigate().GoToUrl(WebsiteUrl + "/");

        Website.NavigationBar
            .ClickSearchButton()
            .CloseDialog()
            .ClickHomeLink();
    }
    
    [Test]
    public void DesktopSearchForThrone()
    {
        TestReport.CreateTest();

        Website.WebDriver.Navigate().GoToUrl(WebsiteUrl + "/");

        Website.NavigationBar
            .ClickSearchButton()
            .Search("Throne")
            .SelectSearchEntity("Throne")
            .GetEntityName(out var name)
            .GetEntityHealth(out var health);
        
        TestReport.CheckPassed(name.Equals("Throne"), new TestMessage(){ Description = "Couldn't find Throne via search."});
        TestReport.CheckPassed(!health.Trim().Equals(""), new TestMessage(){ Description = "Throne has no visible health!"});
    }
    
    [Test]
    public void DesktopFilterForThrone()
    {
        TestReport.CreateTest();

        Website.WebDriver.Navigate().GoToUrl(WebsiteUrl + "/database");
        
        Website.DatabasePage
            .FilterName("Throne")
            .GetEntityName(0, out var name);
        
        TestReport.CheckPassed(name.Equals("Throne"), 
            new TestMessage(){ Description = "Couldn't find Throne via filter."});
    }
    
    [Test]
    public void SeeThroneByDefault()
    {
        TestReport.CreateTest();
        
        Website.WebDriver.Navigate().GoToUrl(WebsiteUrl + "/database");
        
        Website.DatabasePage
            .GetEntityName( "army", "throne", out var name);
        
        TestReport.CheckPassed(name.Equals("Throne"), 
            new TestMessage(){ Description = "Couldn't find Throne on the page by default."});
    }
    
    [Test]
    public void DirectLinkNotThroneFailure()
    {
        TestReport.CreateTest();
        
        Website.WebDriver.Navigate().GoToUrl(WebsiteUrl + "/database/not throne");

        Website.DatabaseSinglePage
            .GetInvalidSearch(out var invalidSearch)
            .GetValidSearch(out var validSearch);

        TestReport.CheckPassed(invalidSearch.Equals("not throne"), 
            new TestMessage(){ Description = "Couldn't find invalid search text on the page."});
        TestReport.CheckPassed(validSearch.Equals("Throne"), 
            new TestMessage(){ Description = "Couldn't find valid search text on the page."});
        
        Website.WebDriver.Navigate().GoToUrl(WebsiteUrl + "/database/not throne");
    }
}