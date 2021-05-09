using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Console;
using System;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  class Item : IItem
  {
    public CTexts Name { get; set; }
    public int Count { get; set; }
    public ItemType Type { get; set; }
    public string Lore { get; set; }
    public bool IsAir { get; set; }
    public CTexts Description { get; set; }

    static public IItem GetAir()
    {
      Item resultItem = new Item { IsAir = true };
      return resultItem;
    }

    public void UseItem(IPlayer player) { }

    public void DescriptionItem() { }

    public void DescriptionItemAP(IPlayer player) { }

  }
}
