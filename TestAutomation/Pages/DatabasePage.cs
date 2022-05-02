using System.Collections.ObjectModel;
using TestAutomation.Utils;

namespace TestAutomation.Pages;

public class DatabasePage : BasePage
{
    public DatabasePage(Website website) : base(website)
    {
    }

    private IWebElement FilterNameInput => Website.Find("filterName");

    public override string Url { get; set; } = "database";


    private ReadOnlyCollection<IWebElement> EntityNames()
    {
        return Website.FindAll("entityName");
    }


    private IWebElement EntityName(string entityType, string entityName)
    {
        return Website.Find("entityName",
            $"{entityType.ToLower()}-{entityName.ToLower()}");
    }

    public DatabasePage FilterName(string name)
    {
        Website.EnterInput(FilterNameInput, name);

        return this;
    }

    public DatabasePage GetEntityName(string entityType, string entityName, out string result)
    {
        result = EntityName(entityType, entityName).Text;
        return this;
    }

    public DatabasePage GetEntityName(int index, out string result)
    {
        result = EntityNames()[index].Text;
        return this;
    }

    public DatabasePage Goto()
    {
        Website.Goto(Url);
        return this;
    }
}