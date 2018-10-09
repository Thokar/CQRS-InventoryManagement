using System.IO;
using System.Xml.Serialization;

namespace InventoryManagement
{
  public static class CommandStoreHelper
  {
    private static string Filename = "commandstore.txt";
    public static CommandStore Load()
    {
      CommandStore result;

      if (!File.Exists(Filename))
      {
        result = new CommandStore();
      }
      else
      {
        var xs = new XmlSerializer(typeof(CommandStore));
        using (FileStream fs = File.OpenRead(Filename))
        {
          result = (CommandStore)xs.Deserialize(fs);
        }
      }
      return result;
    }

    public static void Save(CommandStore toSave)
    {
      var xs = new XmlSerializer(typeof(CommandStore));
      using (var fs = File.OpenWrite(Filename))
      {
        xs.Serialize(fs, toSave);
      }
    }
  }
}
