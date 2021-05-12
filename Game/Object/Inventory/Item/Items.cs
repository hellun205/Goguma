using Goguma.Game.Console;

namespace Goguma.Game.Object.Inventory.Item
{
  static class Items
  {
    static public IItem Get(ItemList item)
    {
      IItem resultItem;
      switch (item)
      {
        case ItemList.TestItem1:
          resultItem = new OtherItem()
          {
            Name = CTexts.Make("{테스트용 아이템 A}"),
            Descriptions = CTexts.Make("{테스트용으로 사용되는 아이템이다.}"),
            Type = HavingType.Other
          };
          return resultItem;
        case ItemList.TestItem2:
          resultItem = new EquipmentItem()
          {
            Name = CTexts.Make("{테스트용 모자 B}"),
            Descriptions = CTexts.Make("{테스트용으로 사용되는 아이템이다.}"),
            Type = HavingType.Equipment,
            EquipmentType = WearingType.Head,
            Increase = new ItemIncrease()
            {
              MaxHp = 20,
              DefPer = 0.2,
            }
          };
          return resultItem;
        default:
          return null;
      }
    }
  }
}