using System;
using System.Collections.Generic;
using Goguma.Game.Object.Inventory.Item;

namespace Goguma.Game.Object.Inventory
{
  [Serializable]
  class Equipment
  {
    public EquipmentItems Items { get; set; }
    public Equipment()
    {
      Items = new EquipmentItems();
    }
    private EquipmentItem GetItem(EquipmentType type)
    {
      return (EquipmentItem)Items.GetItem(type);
    }
    public int ItemsAtt
    {
      get => GetItem(EquipmentType.Head).Increase.AttDmg + GetItem(EquipmentType.Chestplate).Increase.AttDmg + GetItem(EquipmentType.Leggings).Increase.AttDmg + GetItem(EquipmentType.Boots).Increase.AttDmg + GetItem(EquipmentType.Weapon).Increase.AttDmg;
    }
    public int ItemsDef
    {
      get => GetItem(EquipmentType.Head).Increase.DefPer + GetItem(EquipmentType.Chestplate).Increase.DefPer + GetItem(EquipmentType.Leggings).Increase.DefPer + GetItem(EquipmentType.Boots).Increase.DefPer + GetItem(EquipmentType.Weapon).Increase.DefPer;
    }
    public int ItemsMaxHp
    {
      get => GetItem(EquipmentType.Head).Increase.MaxHp + GetItem(EquipmentType.Chestplate).Increase.MaxHp + GetItem(EquipmentType.Leggings).Increase.MaxHp + GetItem(EquipmentType.Boots).Increase.MaxHp + GetItem(EquipmentType.Weapon).Increase.MaxHp;
    }
    public int ItemsMaxEp
    {
      get => GetItem(EquipmentType.Head).Increase.MaxEp + GetItem(EquipmentType.Chestplate).Increase.MaxEp + GetItem(EquipmentType.Leggings).Increase.MaxEp + GetItem(EquipmentType.Boots).Increase.MaxEp + GetItem(EquipmentType.Weapon).Increase.MaxEp;
    }
  }
}
