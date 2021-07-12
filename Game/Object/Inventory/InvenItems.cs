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
    public class Wearing
    {
      public List<ItemList?> Items { get; set; }

      public Wearing()
      {
        Items = new();
        for (var i = 0; i < Enum.GetValues(typeof(WearingType)).Length; i++)
          Items.Add(null);
      }

      public ItemList? this[WearingType wType] => Items[(int)wType];
      public ItemList? this[int wType] => Items[wType];

      public EquipEffect GetEquipEffect
      {
        get
        {
          var resultEffect = new EquipEffect();
          foreach (var item in Items)
          {
            if (item != null)
            {
              var itemInstance = (IEquipmentItem)Itemss.GetInstance((ItemList)item);
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
              var itemInstance = (IEquipmentItem)Itemss.GetInstance((ItemList)item);
              if (itemInstance.EType == WearingType.Weapon)
              {
                resultEffect.AttDmg += ((EWeapon)itemInstance).Effect.AttDmg;
                resultEffect.CritDmg += ((EWeapon)itemInstance).Effect.CritDmg;
                resultEffect.CritPer += ((EWeapon)itemInstance).Effect.CritPer;
                resultEffect.IgnoreDef += ((EWeapon)itemInstance).Effect.IgnoreDef;
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

      public ItemPair this[int index] => Items[index];

      public Having()
      {
        Items = new();
      }

      public List<ItemPair> this[HavingType hType] => (from item in Items
                                                       where item.ItemM.Type == hType
                                                       select item).ToList();

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
          return null;
      }
    }
  }
}