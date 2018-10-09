using System.IO;
using System.Xml.Serialization;

namespace InventoryManagement
{
  public static class InventoryHelper
  {
    private static string Filename = "inventory.txt";

    public static Inventory LoadFromStore(CommandStore store)
    {
      Inventory result = new Inventory(store);

      foreach (var item in store)
      {
        result.ProcessCommand(item);
      }

      return result;
    }

    public static Inventory Load(CommandStore commandStore)
    {
      Inventory result;
      if (!File.Exists(Filename))
      {
        result = new Inventory(commandStore);
      }
      else
      {
        var xs = new XmlSerializer(typeof(Inventory));

        using (FileStream fs = File.OpenRead(Filename))
        {
          result = (Inventory)xs.Deserialize(fs);
        }
      }

      result.CommandStore = commandStore;

      return result;
    }

    public static void Save(Inventory toSave)
    {
      var xs = new XmlSerializer(typeof(Inventory));
      using (var fs = File.OpenWrite(Filename))
      {
        xs.Serialize(fs, toSave);
      }
    }
  }
}
