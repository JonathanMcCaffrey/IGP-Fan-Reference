using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IGP_API;

public class HoverInfo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


    public int X { get; set; }
    public int Y { get; set; }

}