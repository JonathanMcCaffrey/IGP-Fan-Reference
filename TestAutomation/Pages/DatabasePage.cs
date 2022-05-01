using System.Collections.ObjectModel;
using TestAutomation.Shared;
using TestAutomation.Utils;

namespace TestAutomation.Pages;

public class DatabasePage : BaseElement
{
    
    private IWebElement FilterNameInput => Website.Find("filterName");

    
    private ReadOnlyCollection<IWebElement> EntityNames() => 
        Website.FindAll("entityName");

    
    private IWebElement EntityName(string entityType, string entityName) => 
        Website.Find("entityName", 
            $"{entityType.ToLower()}-{entityName.ToLower()}");
    
    
    public DatabasePage(Website website) : base(website) { }

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
    
    public DatabasePage GetEntityName(int index,out string result)
    {
        result = EntityNames()[index].Text;
        return this;
    }


}