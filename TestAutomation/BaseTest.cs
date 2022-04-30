using TestAutomation.Utils;

namespace TestAutomation;

public enum DeploymentType
{
    Dev,
    Local
}

public class BaseTest
{
    protected static readonly DeploymentType DeploymentType =
        Environment.GetEnvironmentVariable("TEST_HOOK") != null
            ? DeploymentType.Dev
            : DeploymentType.Local;

    protected static readonly string WebsiteUrl =
        DeploymentType.Equals(DeploymentType.Dev)
            ? "https://calm-mud-04916b210.1.azurestaticapps.net/"
            : "https://localhost:7234";

    protected static readonly TestReport TestReport = new();


    protected static Website WebsiteInstance = default!;

    protected static Website Website
    {
        get
        {
            if (WebsiteInstance == null)
            {
                var options = new FirefoxOptions();

                options.AcceptInsecureCertificates = true;
                //   options.AddArgument("--headless");
                options.AddArgument("--ignore-certificate-errors");
                options.AddArgument("--start-maximized");
                options.AddArgument("--test-type");
                options.AddArgument("--allow-running-insecure-content");

                IWebDriver webDriver = new FirefoxDriver(Environment.CurrentDirectory, options);

                WebsiteInstance = new Website(webDriver);
            }

            return WebsiteInstance;
        }
    }
}