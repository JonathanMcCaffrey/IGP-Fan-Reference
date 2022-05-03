using TestAutomation.Utils;

namespace TestAutomation.Shared;

public abstract class BaseElement
{
    protected readonly Website Website;

    protected BaseElement(Website website)
    {
        Website = website;
    }
}