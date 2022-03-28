using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Model.Immortal.BuildOrders;
using Model.Immortal.Entity;
using Model.Immortal.Entity.Data;
using YamlDotNet.Serialization;

namespace Services.Immortal;

public class BuildComparisionService : IBuildComparisonService {
    private BuildComparisonModel buildComparison = new() {
        Builds = new List<BuildOrderModel> {
            new() {
                Name = "one base",
                Orders = new Dictionary<int, List<EntityModel>> {
                    {
                        0, new List<EntityModel> {
                            new(DataType.STARTING_Bastion, EntityType.Building)
                        }
                    }
                }
            },
            new() {
                Name = "two base",
                Orders = new Dictionary<int, List<EntityModel>> {
                    {
                        0, new List<EntityModel> {
                            new(DataType.STARTING_Bastion, EntityType.Building),
                            new(DataType.STARTING_Bastion, EntityType.Building)
                        }
                    }
                }
            }
        }
    };

    public void Subscribe(Action action) {
        onChange += action;
    }

    public void Unsubscribe(Action action) {
        onChange -= action;
    }

    public void SetBuilds(BuildComparisonModel buildComparison) {
        this.buildComparison = buildComparison;
        NotifyDataChanged();
    }

    public BuildComparisonModel Get() {
        return buildComparison;
    }

    public string AsJson() {
        var options = new JsonSerializerOptions {
            WriteIndented = true
        };
        options.Converters.Add(new JsonStringEnumConverter());
        return JsonSerializer.Serialize(buildComparison, options);
    }

    public bool LoadJson(string data) {
        try {
            var options = new JsonSerializerOptions {
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            buildComparison = JsonSerializer.Deserialize<BuildComparisonModel>(data, options);

            // Must Hydrate because not loaded with Parts
            HydratedLoadedJson();

            NotifyDataChanged();
            return true;
        }
        catch {
            return false;
        }
    }

    public string BuildOrderAsYaml() {
        var stringBuilder = new StringBuilder();
        var serializer = new Serializer();
        stringBuilder.AppendLine(serializer.Serialize(buildComparison));
        var buildOrderText = stringBuilder.ToString();
        return buildOrderText;
    }

    private event Action onChange;

    private void NotifyDataChanged() {
        onChange?.Invoke();
    }

    public Action OnChange() {
        return onChange;
    }

    public void HydratedLoadedJson() {
        foreach (var build in buildComparison.Builds)
        foreach (var orders in build.Orders.Values)
        foreach (var order in orders)
            order.Copy(EntityModel.Get(order.DataType));
    }
}