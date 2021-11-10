using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory;
using Goguma.Game.Object.Inventory.Item;
using System.Linq;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.InGame;
using Goguma.Game.Object.Quest.Dialog;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Npc.NpcTrader
{
  public abstract class NTrader : Npc
  {
    public abstract List<IItem> ItemsForSale { get; }

    public override NpcType NpcType => NpcType.Trader;

    public abstract DNpcSay[] OpenShopDialog { get; }

    public override string[] SsItems => new[] { "상점 열기" };

    public override void OnSelectedSSI(string selectedSsi)
    {
      switch (selectedSsi)
      {
        case "상점 열기":
          OpenShop();
          break;
      }
    }

    public NTrader() : base() { }

    public void OpenShop()
    {
      void BuyItem()
      {
        while (true)
        {
          var htSsi = new SelectSceneItems();
          for (var i = 0; i < Enum.GetValues(typeof(HavingType)).Length; i++)
            htSsi.Add($"{{{Item.GetTypeString((HavingType)i)} 아이템}}");
          var htSs = new SelectScene(CTexts.Make("{구매 할 아이템 종류를 선택 하세요.}"), htSsi, true);
          if (htSs.isCancelled) return;
          while (true)
          {
            var itemSsi = new SelectSceneItems();
            var items = from it in ItemsForSale
                        where it.Type == (HavingType)htSs.getIndex
                        select it;
            foreach (var item in items.ToList<IItem>())
              itemSsi.Add($"{{{item.Name} }} {{[ {item.PurchasePrice}G ],{Colors.txtWarning}}}");
            var sItem = new SelectScene(CTexts.Make($"{{구매 할 아이템을 선택 하세요. 현재 }}{{{InGame.player.Gold} G,{Colors.txtWarning}}}{{를 보유하고 있습니다.}}"), itemSsi, true);
            if (sItem.isCancelled) break;

            var itemToBuy = items.ToList<IItem>()[sItem.getIndex];
            if (InGame.player.Gold >= itemToBuy.PurchasePrice)
            {
              var sItemSsi = new SelectSceneItems();
              sItemSsi.Add("{구매}");
              sItemSsi.Add("{아이템 정보}");
              var sItemSs = new SelectScene(CTexts.Make($"{{{itemToBuy.Name},{Colors.txtInfo}}}{{(을)를 구매하시겠습니까?}}"), sItemSsi, true, CTexts.Make($"{{아니오,{Colors.txtMuted}}}"));
              switch (sItemSs.getString)
              {
                case "구매":
                  int count;
                  if (ReadInt(CTexts.Make($"{{{itemToBuy.Name},{Colors.txtInfo}}}{{(을)를 몇개 구매하시겠습니까? }}{{[ {(int)(InGame.player.Gold / itemToBuy.PurchasePrice)}개 구매 가능 ],{Colors.txtSuccess}}}"), out count, 0, 0, (int)(InGame.player.Gold / itemToBuy.PurchasePrice))) break;
                  InGame.player.Inventory.GetItem(new ItemPair(itemToBuy.Material, count));
                  InGame.player.Gold -= itemToBuy.PurchasePrice * count;
                  PrintCText($"{{\n{Item.GetTypeString(itemToBuy.Type)} 아이템,{Colors.txtWarning}}}{{ {itemToBuy.Name} {count}개를 }}{{{itemToBuy.PurchasePrice * count}G,{Colors.txtWarning}}}{{에 구매했습니다.}}");
                  Pause();
                  break;
                case "아이템 정보":
                  itemToBuy.Information(false);
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
      void SellItem()
      {
        InvenType invenType;
        var item = InGame.player.Inventory.Select(out invenType);
        if (item == null) return;
        var itemP = (ItemPair)item;
        int count = 1;
        if (invenType == InvenType.Having)
          if (ReadInt(CTexts.Make($"{{아이템 }}").Combine(itemP.ItemM.DisplayName).Combine($"{{(이)가 총 {itemP.Count}개 있습니다. 몇개를 판매하시겠습니까?\n 판매 가격: {itemP.ItemM.SalePrice}}}"), out count, 0, 0, itemP.Count)) return;

        var sell = ReadYesOrNo(CTexts.Make($"{{아이템 }}").Combine(itemP.ItemM.DisplayName).Combine($"{{{(count == 1 ? "(을)를}}" : $" {count}개,{Colors.txtSuccess}}}{{를}}")}{{{itemP.ItemM.SalePrice * count}G,{Colors.txtWarning}}}{{에 판매하시겠습니까?}}"));
        if (sell)
        {
          if (invenType == InvenType.Having)
            InGame.player.Inventory.RemoveItem(new ItemPair(itemP.Item, count));
          else
            InGame.player.Inventory.RemoveItem(((EquipmentItem)itemP.ItemM).EType);
          InGame.player.Gold += itemP.ItemM.SalePrice * count;
          PrintCText(CTexts.Make($"{{\n아이템 }}").Combine(itemP.ItemM.DisplayName).Combine($"{{ {count}개,{Colors.txtSuccess}}}{{를 판매하여 }}{{{itemP.ItemM.SalePrice * count}G,{Colors.txtWarning}}}{{를 얻었습니다.}}"));
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
        var ss = new SelectScene(Rand(OpenShopDialog).Text.DisplayText(String.Empty), ssi, true);
        if (ss.isCancelled) return;
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
