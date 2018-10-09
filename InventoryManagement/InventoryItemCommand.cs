using System.Xml.Serialization;

namespace InventoryManagement
{
  [XmlInclude(typeof(CreateInventoryItemCommand))]
  public class InventoryItemCommand
  {
    public InventoryItemCommandType inventoryItemCommandType { get; set; }
  }
}
