using System.Collections.Generic;
using Goguma.Game.Object.Inventory;
using Goguma.Game.Console;
using Colorify;
using System;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  class ItemInfo
  {
    public SelectSceneItems SelectItemAnswers { get; set; }

    public ItemInfo(ItemType itemType)
    {
      SelectItemAnswers = new SelectSceneItems();

      SelectItemAnswers.Items.Add(new SelectSceneItem(CTexts.Make("{아이템 정보 보기}")));

      switch (itemType)
      {
        case ItemType.Equipment:
          SelectItemAnswers.Items.Add(new SelectSceneItem(CTexts.Make("{착용 하기}")));
          break;
        case ItemType.Consume:
          SelectItemAnswers.Items.Add(new SelectSceneItem(CTexts.Make("{사용 하기}}")));
          break;
        case ItemType.Other:

          break;
      }
      SelectItemAnswers.Items.Add(new SelectSceneItem(CTexts.Make("{버리기}")));
      SelectItemAnswers.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로가기, {Colors.txtMuted}}}")));
    }
  }
}
