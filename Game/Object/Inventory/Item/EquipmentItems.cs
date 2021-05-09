using System;
using System.Collections.Generic;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  class EquipmentItems
  {
    public List<IItem> Items { get; set; }

    public IItem GetItem(EquipmentType type)
    {
      return Items[(int)type];
    }

    public void SetItem(EquipmentType type, EquipmentItem item)
    {
      Items[(int)type] = item;
    }

    public EquipmentItems()
    {
      Items = new List<IItem>();
      foreach (var i in Enum.GetValues(typeof(EquipmentType)))
      {
        Items.Add(Item.GetAir());
      }
    }

    public string GetTypeString(EquipmentType type)
    {
      switch (type)
      {
        case EquipmentType.Head:
          return "머리";
        case EquipmentType.Chestplate:
          return "상체";
        case EquipmentType.Leggings:
          return "하체";
        case EquipmentType.Boots:
          return "신발";
        case EquipmentType.Weapon:
          return "무기";
        default:
#pragma warning disable CS8603
          return null;
      }
    }
  }
}