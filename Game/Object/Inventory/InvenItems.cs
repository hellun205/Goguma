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
      public ItemIncrease Increase
      {
        get
        {
          var resultIncrease = new ItemIncrease();
          foreach (var item in Items)
          {
            resultIncrease.MaxHp += item.Increase.MaxHp;
            resultIncrease.MaxEp += item.Increase.MaxEp;
            resultIncrease.AttDmg += item.Increase.AttDmg;
            resultIncrease.DefPer += item.Increase.DefPer;
          }
          return resultIncrease;
        }
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