using OpenQA.Selenium;

namespace TestAutomation.Pages; 

public class BasePage {

    public  Website website;
    
    public BasePage(Website website) {
        this.website = website;
    }
    
}