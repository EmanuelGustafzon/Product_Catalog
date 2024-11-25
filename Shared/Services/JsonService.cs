using Shared.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Shared.Services;
public class JsonService<TEntity> : IJsonService<TEntity> where TEntity : class
{
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.Preserve,
        Converters = { new JsonStringEnumConverter() }
    };
    public List<TEntity>? Deserialize(string json)
    {
        List<TEntity>? deserilizedList = JsonSerializer.Deserialize<List<TEntity>>(json, options);
        return deserilizedList ?? null;
    }
    public string Serialize(List<TEntity> listOfObjects)
    {
        string json = JsonSerializer.Serialize(listOfObjects, options);
        return json;
    }
}
