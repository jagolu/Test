namespace WebTreeViewBack.Model
{
    public class Item
    {
        public string Name { get; set; } = string.Empty;
        public List<Item> Children { get; set; } = new List<Item>();
    }
}
