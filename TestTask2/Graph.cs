namespace Packt.Shared;


internal class Graph
{
    // Обявление словаря нод
    private List<Node> nodes = new();

    // Конструктор
    public Graph(List<Node> nodes)
    {
        this.nodes = nodes;
    }


    // Свойства начальной и конечной ноды
    // самого короткого пути, где имеются первое общее пересечение
    public string? StartPathToCommodNode { get; private set; } = null;

    public string? EndPathToCommodNode { get; private set; } = null;


    // Метод для расчета
    // самого короткого пути, где имеются первое общее пересечение
    public void CalcShortPathToCommodNode(string[] startedNodesNames) // "a", "b"
    {
        Dictionary<string,List<Node>> checkedNodes = new();
        Queue<List<Node>> searchQueue = new();

        foreach(string startedNodeName in startedNodesNames)
        {
            List<Node?> startNode = new() { GetStartNodeByName(startedNodeName) };

            if (startNode.Count >= 1)
            {
                searchQueue.Enqueue(startNode);
                while (searchQueue.Count > 0)
                {
                    List<Node> nodeFromQuene = searchQueue.Dequeue();
                    if (nodeFromQuene is not null)
                    {
                        foreach (Node node in nodeFromQuene)
                        {

                            if (!checkedNodes.TryAdd(node.Name, new() { node }))
                            {
                                checkedNodes[node.Name].Add(node);

                                if (checkedNodes[node.Name].Count >= startedNodesNames.Count())
                                {

                                    StartPathToCommodNode = startedNodeName;
                                    EndPathToCommodNode = node.Name;
                                    return;
                                }
                            }
                            searchQueue.Enqueue(node.Children);
                        }
                    }
                    
                }

            }
        }
    }

    private Node? GetStartNodeByName(string name)
    {
        foreach (Node node in nodes)
        {
            if (node.Name == name)
            {
                return node;
            }
        }
        return null;
    }
}