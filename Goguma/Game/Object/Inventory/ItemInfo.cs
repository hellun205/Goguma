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
          
          break;
        case ItemType.Consume:
          break;

        case ItemType.Other:

          break;

      }
    }



  }
}
