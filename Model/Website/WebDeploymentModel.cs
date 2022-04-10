using System.Collections.Generic;
using Model.Website.Enums;

namespace Model.Website;

public class WebDeploymentModel
{
    public static WebDeploymentType DeploymentType { get; set; } = WebDeploymentType.Private;

    public static List<string> Get()
    {
        return DeploymentType == WebDeploymentType.Immortal ? GetImmortal() : new List<string>();
    }


    public static List<string> GetImmortal()
    {
        return new List<string>
        {
            "",
            "build-calculator",
            "comparison-charts",
            "database"
        };
    }
}