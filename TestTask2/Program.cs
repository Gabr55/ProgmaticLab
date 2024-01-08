using static System.Console;
using System.Text;

using Packt.Shared;
using System.Text.Json.Nodes;
using System.Xml.Linq;



// Импорт из файла * Json должен лежать рядом с бинарником
string json = "";
using (StreamReader streamReader = new StreamReader(@".\Graph.json", Encoding.UTF8))
{
    json = streamReader.ReadToEnd();
}

// Инициализация нод из json
List<Node> nodes = new Json2Nodes(json).Nodes;

// Инициализация графа
Graph graph = new(nodes);

graph.CalcShortPathToCommodNode(new string[] { "a", "b" });

if (graph.StartPathToCommodNode is not null && graph.EndPathToCommodNode is not null)
{
    WriteLine($"Ближайший общий узел {graph.StartPathToCommodNode} >> {graph.EndPathToCommodNode}");
}
else
{
    WriteLine("Общий узел не найден");
}
