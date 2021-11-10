using System;
using System.Collections.Generic;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Equipment;
using System.Linq;

namespace Goguma.Game.Object.Inventory
{
  [Serializable]
  public class InvenItems
  {
    [Serializable]
#nullable enable
    public class Wearing
    {
      public List<ItemPair?> Items { get; set; }

      public Wearing()
      {
        Items = new();
        for (var i = 0; i < Enum.GetValues(typeof(WearingType)).Length; i++)
          Items.Add(null);
      }

      public ItemPair? this[WearingType wType] => Items[(int)wType];
      public ItemPair? this[int wType] => Items[wType];

      public EquipEffect GetEquipEffect
      {
        get
        {
          var resultEffect = new EquipEffect();
          foreach (var item in Items)
          {
            if (item != null)
            {
              var itemInstance = (IEquipmentItem)((ItemPair)item).ItemM;
              if (itemInstance.EType == WearingType.Head || itemInstance.EType == WearingType.Chestplate ||
                  itemInstance.EType == WearingType.Leggings || itemInstance.EType == WearingType.Boots)
              {
                resultEffect.MaxHp += ((EEquip)itemInstance).Effect.MaxHp;
                resultEffect.MaxEp += ((EEquip)itemInstance).Effect.MaxEp;
                resultEffect.DefPer += ((EEquip)itemInstance).Effect.DefPer;
              }
            }
          }

          return resultEffect;
        }
      }

      public WeaponEffect GetWeaponEffect
      {
        get
        {
          var resultEffect = new WeaponEffect();
          foreach (var item in Items)
          {
            if (item != null)
            {
              var itemInstance = (IEquipmentItem)((ItemPair)item).ItemM;
              if (itemInstance.EType == WearingType.Weapon)
              {
                resultEffect.PhysicalDamage += ((EWeapon)itemInstance).Effect.PhysicalDamage;
                resultEffect.CritDmg += ((EWeapon)itemInstance).Effect.CritDmg;
                resultEffect.CritPer += ((EWeapon)itemInstance).Effect.CritPer;
                resultEffect.PhysicalPenetration += ((EWeapon)itemInstance).Effect.PhysicalPenetration;
              }
            }
          }

          return resultEffect;
        }
      }
    }

    [Serializable]
    public class Having
    {
      public List<ItemPair> Items { get; set; }

      public ItemPair this[ItemList item] => (from item2 in Items
                                              where item2.Item == item
                                              select item2).ToList()[0];

      public Having()
      {
        Items = new();
      }

      public List<ItemPair> this[HavingType hType, bool countTheorem = false]
      {
        get
        {
          if (countTheorem)
          {
            var resultList = new List<ItemPair>();
            var needTheoremList = (from item in Items
                                   where (item.Count > item.ItemM.MaxCount) && (item.ItemM.Type == hType)
                                   select item).ToList();

            var notNeedTheoremList = (from item in Items
                                      where (item.Count <= item.ItemM.MaxCount) && (item.ItemM.Type == hType)
                                      select item).ToList();

            foreach (var item in notNeedTheoremList)
            {
              resultList.Add(item);
            }
            foreach (var item in needTheoremList)
            {
              int rem;
              var div = Math.DivRem(item.Count, item.ItemM.MaxCount, out rem);

              for (var i = 0; i < div; i++)
              {
                resultList.Add(new(item.Item, item.ItemM.MaxCount));
              }
              if (rem != 0)
              {
                resultList.Add(new(item.Item, rem));
              }
            }

            var resList = resultList.OrderBy(item => item.ItemM.Name.ToString());
            return resList.ToList();

          }
          else
          {
            var resList = (from item in Items
                           where item.ItemM.Type == hType
                           orderby item.ItemM.Name.ToString()
                           select item);
            return resList.ToList();
          }
        }
      }

      public void RemoveItem(ItemPair item)
      {
        var items = (from it in Items
                     where it.Item == item.Item
                     select it).ToList();

        foreach (var item2 in items)
        {
          if (item.Count == items[0].Count)
            Items.Remove(item2);
          else
            Items[Items.IndexOf(item2)].Count -= item.Count;
        }


      }

    }

    public Wearing wearing;
    public Having having;

    public InvenItems()
    {
      wearing = new Wearing();
      having = new Having();
    }

    public static string GetTypeString(InvenType iType)
    {
      switch (iType)
      {
        case InvenType.Wearing:
          return "착용";
        case InvenType.Having:
          return "소지";
        default:
          return "null";
      }
    }
  }
}