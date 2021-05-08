using System;
using Goguma.Game.Object.Inventory.Item;

namespace Goguma.Game.Object.Inventory
{
  [Serializable]
  class Equipment
  {
    public IEquipmentItem HeadEquipment { get; set; }
    public IEquipmentItem ChestplateEquipment { get; set; }
    public IEquipmentItem LeggingsEquipment { get; set; }
    public IEquipmentItem BootsEquipment { get; set; }
    public IEquipmentItem WeaponEquipment { get; set; }

    public int ItemsAtt
    {
      get
      {
        return 0;
      }
    }
    public int ItemsDef
    {
      get
      {
        return 0;
      }
    }
    public int ItemsMaxHp
    {
      get
      {
        return 0;
      }
    }
    public int ItemsMaxEp
    {
      get
      {
        return 0;
      }
    }
  }
}
