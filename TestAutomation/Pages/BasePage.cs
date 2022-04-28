using TestAutomation.Utils;

namespace TestAutomation.Pages;

public class BasePage {
    public Website website;

    public BasePage(Website website) {
        this.website = website;
    }
}