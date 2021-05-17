using System;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  public struct ItemInfo
  {
    public IItem Item;
    public InvenType InvenType;
    public WearingType wType;
    public HavingType hType;
    public int havingIndex;

  }
}