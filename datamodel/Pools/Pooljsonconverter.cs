using System.Text.Json;
using System.Text.Json.Serialization;

namespace dnd_allies;

public class PoolJsonConverter : JsonConverter<Pool>
{
    public override Pool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("Type", out var typeProp))
            return JsonSerializer.Deserialize<GenericPool>(root.GetRawText(), options);

        var poolType = JsonSerializer.Deserialize<PoolType>(typeProp.GetRawText(), options);

        return poolType switch
        {
            PoolType.HP => JsonSerializer.Deserialize<Hp>(root.GetRawText(), options),
            PoolType.Counter => JsonSerializer.Deserialize<CounterPool>(root.GetRawText(), options),
            PoolType.Generic => JsonSerializer.Deserialize<GenericPool>(root.GetRawText(), options),
            _ => null
        };
    }

    // gotta have this but currently jsons are only read in
    // TODO: update this when custom ally creation is implemented
    public override void Write(Utf8JsonWriter writer, Pool value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}