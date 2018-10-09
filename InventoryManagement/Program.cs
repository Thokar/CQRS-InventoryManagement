using System;

namespace InventoryManagement
{
  public class Program
  {
    private static Inventory Inventory;
    private static CommandStore CommandStore;

    public static void Main(string[] args)
    {

      Replay();

      //InsertTest();

      Console.WriteLine("Hello World!");
      Console.ReadLine();
    }

    private static void InsertTest()
    {
      CommandStore = CommandStoreHelper.Load();
      Inventory = InventoryHelper.Load(CommandStore);

      var phone = new InventoryItem("Blackberry Q10", "mobile phone");
      var phone1 = new InventoryItem("Blackberry Q10", "mobile phone");
      Inventory.AddItem(phone);
      Inventory.AddItem(phone1);

      InventoryHelper.Save(Inventory);
      CommandStoreHelper.Save(CommandStore);
    }

    private static void Replay()
    {
      CommandStore = CommandStoreHelper.Load();
      Inventory = InventoryHelper.LoadFromStore(CommandStore);
   
      InventoryHelper.Save(Inventory);
      CommandStoreHelper.Save(CommandStore);
    }
  }
}
