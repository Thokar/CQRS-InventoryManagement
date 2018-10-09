namespace InventoryManagement
{
  public class InventoryItem
  {
    public static uint Seed = 0;
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }

    public InventoryItem()
    {

    }
    public InventoryItem(string name, string category)
    {
      this.Name = name;
      this.Category = category;
      Id = ++Seed;
    }
  }
}
