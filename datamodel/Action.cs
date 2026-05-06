namespace dnd_allies;

public class Action
{
    public Action()
    {
        
    }

    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    [System.Text.Json.Serialization.JsonConverter(typeof(PoolJsonConverter))]
    public Pool? Pool { get; set; } = null;

}