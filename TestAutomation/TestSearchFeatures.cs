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
    [Ignore("Not completed")]
    public void DesktopSearchForThrone()
    {
        TestReport.CreateTest();

        Website.WebDriver.Navigate().GoToUrl(WebsiteUrl + "/");

        Website.NavigationBar
            .ClickSearchButton()
            .Search("Throne")
            .SelectSearchEntity("Throne");
        //    .GetName(out var name);
        
 //       TestReport.CheckPassed(name.Equals("Throne"), "Couldn't find Throne via search.");
    }
}