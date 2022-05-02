using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using TestAutomation.Enums;
using TestAutomation.Shared;

namespace TestAutomation.Utils;

public class Website
{
    public static readonly DeploymentType DeploymentType =
        Environment.GetEnvironmentVariable("TEST_HOOK")!.Contains("localhost") 
            ? DeploymentType.Local
            : DeploymentType.Dev;

    public static readonly string Url =
        DeploymentType.Equals(DeploymentType.Dev)
            ? "https://calm-mud-04916b210.1.azurestaticapps.net"
            : "https://localhost:7234";

    public readonly ScreenType ScreenType = ScreenType.Desktop;

    public TestReport TestReport { get; set; }

    public Website(IWebDriver webDriver, TestReport testReport)
    {
        WebDriver = webDriver;
        TestReport = testReport;

        // Pages
        HarassCalculatorPage = new HarassCalculatorPage(this);
        DatabasePage = new DatabasePage(this);
        DatabaseSinglePage = new DatabaseSinglePage(this);

        // Navigation
        NavigationBar = new NavigationBar(this);

        // Dialogs
        WebsiteSearchDialog = new WebsiteSearchDialog(this);
    }

    public IWebDriver WebDriver { get; }

    public HarassCalculatorPage HarassCalculatorPage { get; }
    public DatabaseSinglePage DatabaseSinglePage { get; }
    public DatabasePage DatabasePage { get; }
    public NavigationBar NavigationBar { get; }
    public WebsiteSearchDialog WebsiteSearchDialog { get; }

    public IWebElement FindScreenSpecific(string byId)
    {
        var screenSpecificId = $"{ScreenType.ToString().ToLower()}-{byId}";

        try
        {
            return WebDriver.FindElement(By.Id(screenSpecificId));
        }
        catch (Exception e)
        {
            throw new Exception($"Couldn't find {screenSpecificId}. Element does not exist on current page. " +
                                "\n\nPerhaps an Id is missing.");
        }
    }


    public IWebElement Find(string byId, string withParentId)
    {
        IWebElement parent;

        try
        {
            parent = WebDriver.FindElement(By.Id(withParentId));
        }
        catch (Exception e)
        {
            throw new Exception($"Couldn't find parent {withParentId}. Element does not exist on current page. " +
                                "\n\nPerhaps an Id is missing.");
        }

        try
        {
            return parent.FindElement(By.Id(byId));
        }
        catch (Exception e)
        {
            throw new Exception($"Couldn't find {byId}. Element does not exist on current page. " +
                                "\n\nPerhaps an Id is missing.");
        }
    }

    public IWebElement Find(string byId)
    {
        try
        {
            return WebDriver.FindElement(By.Id(byId));
        }
        catch (Exception e)
        {
            throw new Exception($"Couldn't find {byId}. Element does not exist on current page. " +
                                "\n\nPerhaps an Id is missing.");
        }
    }

    public ReadOnlyCollection<IWebElement> FindAll(string byId)
    {
        try
        {
            return WebDriver.FindElements(By.Id(byId));
        }
        catch (Exception e)
        {
            throw new Exception($"Couldn't find {byId}. Element does not exist on current page. " +
                                "\n\nPerhaps an Id is missing.");
        }
    }

    public ReadOnlyCollection<IWebElement> FindAllWithTag(string tag)
    {
        return WebDriver.FindElements(By.TagName(tag));
    }
    
    public ReadOnlyCollection<IWebElement> FindAllWithTag(IWebElement parent, string tag)
    {
        return parent.FindElements(By.TagName(tag));
    }


    public IWebElement FindButtonWithLabel(string label)
    {
        try
        {
            return WebDriver.FindElement(By.XPath($"//button[@label='{label}']"));
        }
        catch (Exception e)
        {
            throw new Exception($"Couldn't find with label: {label}. Element does not exist on current page. ");
        }
    }

    //@FindBy(xpath = "//div[@label='First Name']")

    public IList<IWebElement> FindChildren(string ofId, string tagname)
    {
        return WebDriver.FindElements(By.CssSelector($"#{ofId} {tagname}"));
    }

    public string FindText(string byId)
    {
        return WebDriver.FindElement(By.Id(byId)).Text;
    }


    public int FindInt(string byId)
    {
        return int.Parse(WebDriver.FindElement(By.Id(byId)).Text);
    }


    public void ClickTopLeft()
    {
        new Actions(WebDriver)
            .MoveByOffset(32, 32)
            .Click()
            .Perform();
    }

    public IWebElement Click(IWebElement element)
    {
        try
        {
            element.Click();
        }
        catch
        {
            throw new Exception($"Couldn't click on {element.GetDomProperty("id")}. ");
        }

        return element;
    }


    public IWebElement EnterInput<T>(IWebElement element, T input)
    {
        element.Clear();
        element.SendKeys(input!.ToString());
        element.SendKeys(Keys.Enter);
        return element;
    }


    public IWebElement EnterInput<T>(string byId, T input)
    {
        var element = Find(byId);
        element.Clear();
        element.SendKeys(input!.ToString());
        element.SendKeys(Keys.Enter);
        return element;
    }

    public string GetLabel(string byId)
    {
        return Find(byId).Text;
    }

    public Website Goto()
    {
        WebDriver.Navigate().GoToUrl($"{Url}");
        return this;
    }

    public void Goto(string path)
    {
        var url = $"{Url}/{path}";
        
        WebDriver.Navigate().GoToUrl($"{url}");
    }
}