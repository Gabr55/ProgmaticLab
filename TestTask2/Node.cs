namespace Packt.Shared
{
    // Класс для создания ноды
    internal class Node
    {
        public string Name { get; set; } = "";
        public string Parent { get; set; } = "";
        public int Level { get; set; } = 0;
        public List<Node>? Children { get; set; } = new();
    }
}
