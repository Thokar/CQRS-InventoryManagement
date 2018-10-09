using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace InventoryManagement
{
  public class Inventory
  {
    [XmlIgnore]
    public CommandStore CommandStore { get; set; }

    public Inventory()
    {
    }

    public Inventory(CommandStore commandStore)
    {
      this.CommandStore = commandStore;
    }

    public uint InventoryItemSeed
    {
      get { return InventoryItem.Seed; }
      set { InventoryItem.Seed = value; }
    }

    public void AddItem(InventoryItem item)
    {
      itemsByKey.Add(item.Id, item);
      CommandStore.Add(new CreateInventoryItemCommand(item));
    }

    public List<InventoryItem> Items
    {
      get { return itemsByKey.Values.ToList(); }
      set { itemsByKey = value.ToDictionary(i => i.Id, i => i); }
    }

    [XmlIgnore]
    private Dictionary<uint, InventoryItem> itemsByKey = new Dictionary<uint, InventoryItem>();

    public void ProcessCommand(InventoryItemCommand inventoryItemCommand)
    {
      var command = inventoryItemCommand as CreateInventoryItemCommand;

      if (command != null)
      {
        var item = command.Item;
        itemsByKey.Add(item.Id, item);
      }
    }
  }
}
