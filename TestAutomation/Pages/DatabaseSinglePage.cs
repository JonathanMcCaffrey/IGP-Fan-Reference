using TestAutomation.Shared;
using TestAutomation.Utils;

namespace TestAutomation.Pages;

public class DatabaseSinglePage : BaseElement
{
    public DatabaseSinglePage(Website website) : base(website)
    {
    }

    private IWebElement EntityName => Website.Find("entityName");
    private IWebElement EntityHealth => Website.Find("entityHealth");

    private IWebElement InvalidSearch => Website.Find("invalidSearch");
    private IWebElement ValidSearch => Website.Find("validSearch");


    public DatabaseSinglePage GetEntityName(out string result)
    {
        result = EntityName.Text;
        return this;
    }

    public DatabaseSinglePage GetEntityHealth(out string result)
    {
        result = EntityHealth.Text;
        return this;
    }

    public DatabaseSinglePage GetInvalidSearch(out string result)
    {
        result = InvalidSearch.Text;
        return this;
    }

    public DatabaseSinglePage GetValidSearch(out string result)
    {
        result = ValidSearch.Text;
        return this;
    }
}