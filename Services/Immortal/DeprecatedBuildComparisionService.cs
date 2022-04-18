using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Model.BuildOrders;
using Model.Entity;
using YamlDotNet.Serialization;

namespace Services.Immortal;

public class DeprecatedBuildComparisionService : IBuildComparisonService
{
    private BuildToCompareModel buildToCompare = new();

    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange -= action;
    }

    public void SetBuilds(BuildToCompareModel buildToCompareModel)
    {
        buildToCompare = buildToCompareModel;
        NotifyDataChanged();
    }

    public BuildToCompareModel Get()
    {
        return buildToCompare;
    }

    public string AsJson()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        options.Converters.Add(new JsonStringEnumConverter());
        return JsonSerializer.Serialize(buildToCompare, options);
    }

    public bool LoadJson(string data)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            buildToCompare = JsonSerializer.Deserialize<BuildToCompareModel>(data, options)!;

            // Must Hydrate because not loaded with Parts
            HydratedLoadedJson();

            NotifyDataChanged();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public string BuildOrderAsYaml()
    {
        var stringBuilder = new StringBuilder();
        var serializer = new Serializer();
        stringBuilder.AppendLine(serializer.Serialize(buildToCompare));
        var buildOrderText = stringBuilder.ToString();
        return buildOrderText;
    }

    private event Action OnChange = default!;

    private void NotifyDataChanged()
    {
        OnChange?.Invoke();
    }


    public void HydratedLoadedJson()
    {
    }
}