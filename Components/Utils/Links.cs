namespace Components.Utils;

public static class Links
{
    public static string GetTarget(string link)
    {
        if (link.StartsWith("https://")) return "_blank";

        return "_self";
    }
}