using System;
using System.Collections.Generic;
using Goguma.Game.Object.Inventory.Item;

namespace Goguma.Game.Object.Inventory
{
  [Serializable]
  class InvenItems
  {
    [Serializable]
    public class Wearing
    {
      public List<IEquipmentItem> Items { get; set; }
      public Wearing()
      {
        Items = new List<IEquipmentItem>();
        for (var i = 0; i < Enum.GetValues(typeof(WearingType)).Length; i++)
          Items.Add(EquipmentItem.GetAir());
      }
      public IEquipmentItem GetItem(WearingType wType)
      {
        return Items[(int)wType];
      }
      public double ItemsAtt
      {
        get => GetItem(WearingType.Head).Increase.AttDmg + GetItem(WearingType.Chestplate).Increase.AttDmg + GetItem(WearingType.Leggings).Increase.AttDmg + GetItem(WearingType.Boots).Increase.AttDmg + GetItem(WearingType.Weapon).Increase.AttDmg;
      }
      public double ItemsDef
      {
        get => GetItem(WearingType.Head).Increase.DefPer + GetItem(WearingType.Chestplate).Increase.DefPer + GetItem(WearingType.Leggings).Increase.DefPer + GetItem(WearingType.Boots).Increase.DefPer + GetItem(WearingType.Weapon).Increase.DefPer;
      }
      public double ItemsMaxHp
      {
        get => GetItem(WearingType.Head).Increase.MaxHp + GetItem(WearingType.Chestplate).Increase.MaxHp + GetItem(WearingType.Leggings).Increase.MaxHp + GetItem(WearingType.Boots).Increase.MaxHp + GetItem(WearingType.Weapon).Increase.MaxHp;
      }
      public double ItemsMaxEp
      {
        get => GetItem(WearingType.Head).Increase.MaxEp + GetItem(WearingType.Chestplate).Increase.MaxEp + GetItem(WearingType.Leggings).Increase.MaxEp + GetItem(WearingType.Boots).Increase.MaxEp + GetItem(WearingType.Weapon).Increase.MaxEp;
      }
    }
    [Serializable]
    public class Having
    {
      public List<List<IItem>> Items { get; set; }
      public Having()
      {
        Items = new List<List<IItem>>();
        for (var i = 0; i < Enum.GetValues(typeof(HavingType)).Length; i++)
          Items.Add(new List<IItem>());
      }
      public List<IItem> GetItems(HavingType hType)
      {
        return Items[(int)hType];
      }
    }
    public Wearing wearing;
    public Having having;
    public InvenItems()
    {
      wearing = new Wearing();
      having = new Having();
    }
  }
}