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
      public List<IEquipmentItem> Items { get; set; }
      public Wearing()
      {
        Items = new List<IEquipmentItem>();
        for (var i = 0; i < Enum.GetValues(typeof(WearingType)).Length; i++)
          Items.Add(null);
      }
      public IEquipmentItem GetItem(WearingType wType)
      {
        return Items[(int)wType];
      }
      public EquipEffect GetEquipEffect
      {
        get
        {
          var resultEffect = new EquipEffect();
          foreach (var item in Items)
          {
            if (item != null)
            {
              if (item.EquipmentType == WearingType.Head || item.EquipmentType == WearingType.Chestplate || item.EquipmentType == WearingType.Leggings || item.EquipmentType == WearingType.Boots)
              {
                resultEffect.MaxHp += ((EEquip)item).Effect.MaxHp;
                resultEffect.MaxEp += ((EEquip)item).Effect.MaxEp;
                resultEffect.DefPer += ((EEquip)item).Effect.DefPer;
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
              if (item.EquipmentType == WearingType.Weapon)
              {
                resultEffect.AttDmg += ((EWeapon)item).Effect.AttDmg;
                resultEffect.CritDmg += ((EWeapon)item).Effect.CritDmg;
                resultEffect.CritPer += ((EWeapon)item).Effect.CritPer;
                resultEffect.IgnoreDef += ((EWeapon)item).Effect.IgnoreDef;
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