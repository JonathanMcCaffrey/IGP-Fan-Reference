namespace TestAutomation; 

public class Website {
    public IWebDriver WebDriver { get; }

    public HarassCalculatorPage HarassCalculatorPage { get; }
    
    public Website(IWebDriver webDriver) {
        WebDriver = webDriver;

        HarassCalculatorPage = new HarassCalculatorPage(this);
    }
    
    public IWebElement Find(string byId) {
        return WebDriver.FindElement(By.Id(byId));
    }

    public IList<IWebElement> FindChildren(string ofId, string tagname) {
        return WebDriver.FindElements(By.CssSelector($"#{ofId} {tagname}"));
    }
    
    public string FindText(string byId) {
        return WebDriver.FindElement(By.Id(byId)).Text;
    }
    
    
    public int FindInt(string byId) {
        return int.Parse(WebDriver.FindElement(By.Id(byId)).Text);
    }

    
    public IWebElement EnterInput<T>(IWebElement element, T input) {
        element.Clear();
        element.SendKeys(input!.ToString());
        element.SendKeys(Keys.Enter);
        return element;
    }

    
    public IWebElement EnterInput<T>(string byId, T input) {
        var element = Find(byId);
        element.Clear();
        element.SendKeys(input!.ToString());
        element.SendKeys(Keys.Enter);
        return element;
    }

    public string GetLabel(string byId) {
        return Find(byId).Text;
    }
}