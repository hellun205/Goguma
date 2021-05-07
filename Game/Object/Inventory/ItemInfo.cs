using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goguma.Game.Object.Interface;
using Goguma.Game.Object.Enum;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Inventory
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
          SelectItemAnswers.Add(CTexts.Make("{착용}"));
          break;
        case ItemType.Consume:
          SelectItemAnswers.Add(CTexts.Make("{사용}"));
          break;

        case ItemType.Other:

          break;

      }
      SelectItemAnswers.Add(CTexts.Make("{뒤로 가기, Gray}"));
    }



  }
}
