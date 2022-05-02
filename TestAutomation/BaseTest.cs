using TestAutomation.Utils;

namespace TestAutomation;

public enum DeploymentType
{
    Dev,
    Local
}

public class BaseTest
{
    protected static readonly TestReport TestReport = new();


    protected static Website WebsiteInstance = default!;
    protected readonly HttpClient HttpClient = new();

    protected static Website Website
    {
        get
        {
            if (WebsiteInstance == null)
            {
                var options = new FirefoxOptions();

                options.AcceptInsecureCertificates = true;

                if (Website.DeploymentType.Equals(DeploymentType.Dev)) options.AddArgument("--headless");
                options.AddArgument("--ignore-certificate-errors");
                options.AddArgument("--start-maximized");
                options.AddArgument("--test-type");
                options.AddArgument("--allow-running-insecure-content");

                IWebDriver webDriver = new FirefoxDriver(Environment.CurrentDirectory, options);

                WebsiteInstance = new Website(webDriver, TestReport);
            }

            return WebsiteInstance;
        }
    }

}