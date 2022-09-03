using Discord;
using TestAutomation.Utils;

namespace TestAutomation;

[TestFixture]
public class TestSearchFeatures : BaseTest
{
    
    [SetUp]
    public void SetUp()
    {
        TestReport.CreateTest();
    }

    [TearDown]
    public void TearDown()
    {
        TestReport.ThrowErrors();
    }

    [Test]
    public void DesktopOpenCloseSearchDialog()
    {
        Website
            .Goto()
            .NavigationBar
            .ClickSearchButton()
            .CloseDialog()
            .ClickHomeLink();
    }

    [Test]
    public void DesktopSearchForThrone()
    {
      
        Website
            .Goto()
            .NavigationBar.ClickSearchButton()
            .Search("Throne")
            .SelectSearchEntity("Throne")
            .GetEntityName(out var name)
            .GetEntityHealth(out var health);

        TestReport.CheckPassed(name.Equals("Throne"),
            new TestMessage { Description = "Couldn't find Throne via search." });
        TestReport.CheckPassed(!health.Trim().Equals(""),
            new TestMessage { Description = "Throne has no visible health!" });
        
    }

    [Test]
    public void DesktopFilterForThrone()
    {
        

        Website.DatabasePage
            .Goto()
            .FilterName("Throne")
            .GetEntityName(0, out var name);

        TestReport.CheckPassed(name.Equals("Throne"),
            new TestMessage { Description = "Couldn't find Throne via filter." });
        
        
    }

    [Test]
    public void SeeThroneByDefault()
    {
        

        Website.DatabasePage
            .Goto()
            .GetEntityName("army", "throne", out var name);

        TestReport.CheckPassed(name.Equals("Throne"),
            new TestMessage { Description = "Couldn't find Throne on the page by default." });
        
        
    }

    [Test]
    public void DirectLinkNotThroneFailure()
    {
        

        Website.DatabaseSinglePage
            .Goto("not throne")
            .GetInvalidSearch(out var invalidSearch)
            .GetValidSearch(out var validSearch);

        TestReport.CheckPassed(invalidSearch.Equals("not throne"),
            new TestMessage { Description = "Couldn't find invalid search text on the page." });
        TestReport.CheckPassed(validSearch.Equals("Throne"),
            new TestMessage { Description = "Couldn't find valid search text on the page." });
        
        
    }
}