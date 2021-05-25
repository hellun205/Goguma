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
          var equipItems = from item in Items
                           where item.EquipmentType == WearingType.Head || item.EquipmentType == WearingType.Chestplate || item.EquipmentType == WearingType.Leggings || item.EquipmentType == WearingType.Boots
                           select item;
          foreach (var item in equipItems.ToList<IEquipmentItem>())
          {
            resultEffect.MaxHp += ((EEquip)item).Effect.MaxHp;
            resultEffect.MaxEp += ((EEquip)item).Effect.MaxEp;
            resultEffect.DefPer += ((EEquip)item).Effect.DefPer;
          }
          return resultEffect;
        }
      }
      public WeaponEffect GetWeaponEffect
      {
        get
        {
          var resultEffect = new WeaponEffect();
          var weaponItems = from item in Items
                            where item.EquipmentType == WearingType.Weapon
                            select item;
          foreach (var item in weaponItems.ToList<IEquipmentItem>())
          {
            resultEffect.AttDmg += ((EWeapon)item).Effect.AttDmg;
            resultEffect.CriticalDmg += ((EWeapon)item).Effect.CriticalDmg;
            resultEffect.CriticalPer += ((EWeapon)item).Effect.CriticalPer;
            resultEffect.IgnoreDef += ((EWeapon)item).Effect.IgnoreDef;
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