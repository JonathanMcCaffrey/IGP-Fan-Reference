using Discord.Rest;
using TestAutomation.Utils;

namespace TestAutomation.Shared;

public class WebsiteSearchDialog : BaseElement
{
    public WebsiteSearchDialog(Website website) : base(website)
    {
    }

    public IWebElement SearchBackground => Website.Find("searchBackground");
    
    public IWebElement SearchInput => Website.Find("searchInput");

    public NavigationBar CloseDialog()
    {
        Website.ClickTopLeft();
        return Website.NavigationBar;
    }

    public WebsiteSearchDialog Search(string throne)
    {
        Website.EnterInput(SearchInput, throne);
        return this;
    }

    public DatabaseSinglePage SelectSearchEntity(string throne)
    {
        Website.Click(Website.FindButtonWithLabel(throne));
        return Website.DatabaseSinglePage;
    }
}