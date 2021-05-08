using System.Collections.Generic;
using Goguma.Game.Object.Inventory;
using Goguma.Game.Console;
using Colorify;

namespace Goguma.Game.Object.Inventory.Item
{
  class ItemInfo
  {
    public List<CTexts> SelectItemAnswers { get; set; }

    public ItemInfo(ItemType itemType)
    {
      SelectItemAnswers = new List<CTexts>
      {
        CTexts.Make("{아이템 정보 보기}")
      };
      switch (itemType)
      {
        case ItemType.Equipment:
          SelectItemAnswers.Add(CTexts.Make("{착용 하기}"));
          break;
        case ItemType.Consume:
          SelectItemAnswers.Add(CTexts.Make("{사용 하기}"));
          break;
        case ItemType.Other:

          break;
      }
      SelectItemAnswers.Add(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}"));
    }
  }
}
