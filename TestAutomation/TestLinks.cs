namespace TestAutomation;

[TestFixture]
public class TestLinks : BaseTest
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
    public void VerifyPageLinks()
    {
        Website.HarassCalculatorPage.Goto();
        TestReport.VerifyLinks(Website.HarassCalculatorPage).Wait();

        Website.DatabasePage.Goto();
        TestReport.VerifyLinks(Website.DatabasePage).Wait();

        Website.DatabaseSinglePage.Goto("throne");
        TestReport.VerifyLinks(Website.DatabaseSinglePage).Wait();
    }
}