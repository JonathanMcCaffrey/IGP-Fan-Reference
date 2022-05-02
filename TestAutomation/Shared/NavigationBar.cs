using TestAutomation.Utils;

namespace TestAutomation.Shared;

public class NavigationBar : BaseElement
{
    public NavigationBar(Website website) : base(website)
    {
    }

    private IWebElement HomeLink => Website.FindScreenSpecific("homeLink");
    private IWebElement SearchButton => Website.FindScreenSpecific("searchButton");

    public NavigationBar ClickHomeLink()
    {
        Website.Click(HomeLink);
        return this;
    }

    public WebsiteSearchDialog ClickSearchButton()
    {
        Website.Click(SearchButton);
        return Website.WebsiteSearchDialog;
    }
}