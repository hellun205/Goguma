using System.Collections.Generic;
using Colorify;
using Goguma.Game;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory;
using Goguma.Game.Object.Inventory.Item;
using static Goguma.Game.Console.ConsoleFunction;

namespace Gogu_Remaster.Game.Object.Npc
{
  public class NTrader : Npc
  {
    public override string Name
    {
      get => "상인";
    }

    public override void OnUse()
    {
      while (true)
      {
        var ssi = new SelectSceneItems()
        {
          Items = new List<SelectSceneItem>()
        {
          new SelectSceneItem(CTexts.Make("{아이템 구매}")),
          new SelectSceneItem(CTexts.Make("{아이템 판매}")),
          new SelectSceneItem(CTexts.Make($"{{뒤로 가기,{Colors.txtMuted}}}"))
        }
        };
        var ss = new SelectScene(CTexts.Make("{}"), ssi);

        if (ss.getString == "뒤로 가기") return;
        switch (ss.getString)
        {
          case "아이템 구매":
            break;
          case "아이템 판매":
            var itemInfo = InGame.player.Inventory.Select();
            if (itemInfo == null) break;
            var iInfo = (ItemInfo)itemInfo;
            var count = ReadIntScean(CTexts.Make($"아이템 {iInfo.Item.Name}(이)가 총 {iInfo.Item.Count}개 있습니다. 몇개를 판매하시겠습니까?\n 판매 가격: {iInfo.Item.SellPrice}\n 0을 입력하면 취소 됩니다."), 0, iInfo.Item.Count);
            if (count == 0) break;
            var sell = ReadYesOrNoScean(CTexts.Make($"아이템 {iInfo.Item.Name} {count}개를 {iInfo.Item.SellPrice * count}G에 판매하시겠습니까?"));
            if (sell)
            {
              if (iInfo.InvenType == InvenType.Having)
                InGame.player.Inventory.RemoveItem(iInfo.hType, iInfo.havingIndex, count);
              else
                InGame.player.Inventory.RemoveItem(iInfo.wType, count);
              InGame.player.Gold += iInfo.Item.SellPrice * count;
              PrintText($"\n아이템 {iInfo.Item.Name} {count}개를 판매하여 {iInfo.Item.SellPrice * count}G를 얻었습니다.");
              Pause();
            }
            else
            {
              PrintText("\n아이템 판매를 취소했습니다.");
              Pause();
            }
            break;
        }
      }
    }
  }
}
