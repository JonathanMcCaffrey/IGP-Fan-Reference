using TestAutomation.Shared;
using TestAutomation.Utils;

namespace TestAutomation.Pages;

public abstract class BasePage : BaseElement
{
    protected BasePage(Website website) : base(website)
    {
    }

    private IEnumerable<string> Links => 
        Website.FindAllWithTag(Website.Find("content"), "a")
        .Select(x => x.GetAttribute("href"));

    public abstract string Url { get; set; }

    public IEnumerable<string> GetLinks()
    {
        try
        {
            return Links;
        }
        catch (Exception e)
        {
            throw new Exception($"Couldn't get links on page {Url}");
        }
    }
}