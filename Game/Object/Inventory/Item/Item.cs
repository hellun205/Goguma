using Goguma.Game.Object.Enum;
using Goguma.Game.Object.Interface;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Inventory
{
  class Item : IItem
  {
    public CTexts Name { get; set; }
    public int Count { get; set; }

    public ItemType Type { get; set; }
    public CTexts Lore { get; set; }
    public CTexts Description { get; set; }
    public bool IsAir { get; set; }

    static public IItem GetAir()
    {
      Item resultItem = new Item { IsAir = true };

      return resultItem;
    }

    public void UseItem(IPlayer player)
    {
      // TO DO
    }

    public void DescriptionItem()
    {
      // TODO
    }
  }
}
