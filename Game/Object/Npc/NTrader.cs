using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory;
using Goguma.Game.Object.Inventory.Item;
using System.Linq;
using static Goguma.Game.Console.ConsoleFunction;

namespace Gogu_Remaster.Game.Object.Npc
{
  public class NTrader : Npc
  {
    public List<IItem> ItemsForSale = new List<IItem>()
    {
      Items.Get(ItemList.POTION_1)
    };

    public override string Name
    {
      get => "상인";
    }

    public override void OnUse()
    {
      Action BuyItem = () =>
      {
        while (true)
        {
          var htSSI = new SelectSceneItems();
          for (var i = 0; i < Enum.GetValues(typeof(HavingType)).Length; i++)
            htSSI.Add($"{{{InvenInfo.HavingInven.GetTypeString((HavingType)i)} 아이템}}");
          htSSI.Add($"{{뒤로 가기, {Colors.txtMuted}}}");
          var htSS = new SelectScene(CTexts.Make("{구매 할 아이템 종류를 선택 하세요.}"), htSSI);
          if (htSS.getString == "뒤로 가기") return;
          while (true)
          {
            var itemSSI = new SelectSceneItems();
            var items = from it in ItemsForSale
                        where it.Type == (HavingType)htSS.getIndex
                        select it;
            foreach (var item in items.ToList<IItem>())
              itemSSI.Add($"{{{item.Name} }} {{[ {item.BuyPrice}G ],{Colors.txtWarning}}}");
            itemSSI.Add($"{{뒤로 가기, {Colors.txtMuted}}}");
            var sItem = new SelectScene(CTexts.Make($"{{구매 할 아이템을 선택 하세요. 현재 보유한 GOLD: {InGame.player.Gold}}}"), itemSSI);
            if (sItem.getString == "뒤로 가기") break;

            var itemToBuy = items.ToList<IItem>()[sItem.getIndex];
            if (InGame.player.Gold >= itemToBuy.BuyPrice)
            {
              var sItemSSI = new SelectSceneItems();
              sItemSSI.Add("{구매}");
              sItemSSI.Add("{아이템 정보}");
              sItemSSI.Add($"{{아니오,{Colors.txtMuted}}}");
              var sItemSS = new SelectScene(CTexts.Make($"{{{itemToBuy.Name},{Colors.txtInfo}}}{{(을)를 구매하시겠습니까?}}"), sItemSSI);
              switch (sItemSS.getString)
              {
                case "구매":
                  var count = ReadIntScean(CTexts.Make($"{{{itemToBuy.Name},{Colors.txtInfo}}}{{(을)를 몇개 구매하시겠습니까? }}{{[ {(int)(InGame.player.Gold / itemToBuy.BuyPrice)}개 구매 가능 ],{Colors.txtSuccess}}}{{\n  0을 입력하면 구매를 취소합니다.}}"), 0, (int)(InGame.player.Gold / itemToBuy.BuyPrice));
                  if (count == 0) break;
                  InGame.player.Inventory.GetItem(itemToBuy, count);
                  InGame.player.Gold -= itemToBuy.BuyPrice * count;
                  PrintText($"{{\n{InvenInfo.HavingInven.GetTypeString(itemToBuy.Type)} 아이템,{Colors.txtWarning}}}{{ {itemToBuy.Name} {count}개를 }}{{{itemToBuy.BuyPrice * count}G,{Colors.txtWarning}}}{{에 구매했습니다.}}");
                  Pause();
                  break;
                case "아이템 정보":
                  itemToBuy.DescriptionItem();
                  break;
              }
            }
            else
            {
              PrintText($"\nGOLD가 부족하여 아이템을 구매할 수 없습니다.");
              Pause();
            }
          }
        }
      };
      Action SellItem = () =>
      {
        var itemInfo = InGame.player.Inventory.Select();
        if (itemInfo == null) return;
        var iInfo = (ItemInfo)itemInfo;
        var count = ReadIntScean(CTexts.Make($"아이템 {iInfo.Item.Name}(이)가 총 {iInfo.Item.Count}개 있습니다. 몇개를 판매하시겠습니까?\n 판매 가격: {iInfo.Item.SellPrice}\n 0을 입력하면 취소 됩니다."), 0, iInfo.Item.Count);
        if (count == 0) return;
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
      };
      while (true)
      {
        var ssi = new SelectSceneItems();
        ssi.Add("{아이템 구매}");
        ssi.Add("{아이템 판매}");
        ssi.Add($"{{대화 종료, {Colors.txtMuted}}}");
        var ss = new SelectScene(CTexts.Make($"{{{Name}(와)과 대화 중 입니다. 무엇을 하시겠습니까?}}"), ssi);

        if (ss.getString == "대화 종료") return;
        switch (ss.getString)
        {
          case "아이템 구매":
            BuyItem();
            break;
          case "아이템 판매":
            SellItem();
            break;
        }
      }
    }
  }
}
