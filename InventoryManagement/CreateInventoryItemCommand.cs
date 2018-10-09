using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement
{
  public class CreateInventoryItemCommand : InventoryItemCommand
  {
    public InventoryItem Item;

    public CreateInventoryItemCommand()
    {
      inventoryItemCommandType = InventoryItemCommandType.Create;
    }

    public CreateInventoryItemCommand(InventoryItem item)
      : this()
    {
      this.Item = item;
    }
  }
}
