using Newtonsoft.Json;

namespace Packt.Shared;


internal class Json2Nodes
{
    public List<Node> Nodes { get; private set; }
    public Json2Nodes(string json)
    {
        Nodes = CreateNodes(json);
    }

    private List<Node> CreateNodes(string json)
    {
        List<Node> nodes = new();

        Dictionary<string, object> parseJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

        foreach (KeyValuePair<string, object> entry in parseJson)
        {
            nodes.Add(RecurseReadJson(entry.Key, entry.Value.ToString()));
        }

        return nodes;
    }

    private Node RecurseReadJson(string nodeName, string jsonLayer, int level = 0)
    {
        Node node = new() { Name = nodeName, Level = level };
        level++;

        Dictionary<string, object> parseJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonLayer);

        foreach (KeyValuePair<string, object> entry in parseJson)
        {
            if (entry.Value is not null)
            {
                node.Children.Add(RecurseReadJson(entry.Key, entry.Value.ToString(), level));
            }
            else
            {
                node.Children.Add(new Node { Name = entry.Key, Level = level });
            }
        }

        return node;
    }
}
