using Goguma.Game.Object.Enum;
using Goguma.Game.Object.Interface;

namespace Goguma.Game.Object.Inventory
{
  class Item : IItem
  {
    public string Name { get; set; }
    public int Count { get; set; }

    public ItemType Type { get; set; }
    public string Lore { get; set; }
    public bool IsAir { get; set; }

    static public IItem GetAir()
    {
      Item resultItem = new Item();

      resultItem.IsAir = true;

      return resultItem;
    }

  }
}
