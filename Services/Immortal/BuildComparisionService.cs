using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Model.BuildOrders;
using Model.Entity;
using YamlDotNet.Serialization;

namespace Services.Immortal;

public class BuildComparisionService : IBuildComparisonService
{
    private BuildComparisonModel buildComparison = new();

    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange -= action;
    }

    public void SetBuilds(BuildComparisonModel buildComparisonModel)
    {
        buildComparison = buildComparisonModel;
        NotifyDataChanged();
    }

    public BuildComparisonModel Get()
    {
        return buildComparison;
    }

    public string AsJson()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        options.Converters.Add(new JsonStringEnumConverter());
        return JsonSerializer.Serialize(buildComparison, options);
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
            buildComparison = JsonSerializer.Deserialize<BuildComparisonModel>(data, options)!;

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
        stringBuilder.AppendLine(serializer.Serialize(buildComparison));
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
        foreach (var build in buildComparison.Builds)
        foreach (var orders in build.StartedOrders.Values)
        foreach (var order in orders)
            order.Copy(EntityModel.Get(order.DataType));
    }
}