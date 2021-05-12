using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory;
using static Goguma.Game.Console.ConsoleFunction;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Entity.Player;
using System;

namespace Goguma.Game
{
  static class InGame
  {
    public static Player player;
    public static void Go()
    {
      SetPlayerDataScene();
      PlayerActScene(player);
    }

    static public void PlayerActScene(Player player)
    {
      while (true)
      {
        var qt = PlayerAct.Scene.SelPlayerAct.GetQText(player.Map);
        var ssi = PlayerAct.Scene.SelPlayerAct.GetSSI(player.Map, true /*Admin*/);
        var ss = new SelectScene(qt, ssi);
        PlayerAct.Act(player, ss.GetString);
      }
    }

    static public void SetPlayerDataScene()
    {
      while (true)
      {
        Player playerData;
        var questionText = CTexts.Make($"{{고구마 게임,{Colors.bgWarning}}}");
        var selectSceneItems = new SelectSceneItems();
        selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{새로 시작}")));
        selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{이어서 시작}")));
        selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{게임 종료}")));
        var ss = new SelectScene(questionText, selectSceneItems);
        switch (ss.GetIndex)
        {
          case 1:
            playerData = PlayerSave.CreatePlayerData();
            if (playerData != null)
            {
              player = playerData;
              return;
            }
            break;
          case 2:
            playerData = PlayerSave.GetPlayerData();
            if (playerData != null)
            {
              player = playerData;
              return;
            }
            break;
          case 3:
            ExitGame();
            break;
        }
      }
    }

    static public void ExitGame()
    {
      if (ReadYesOrNoScean(CTexts.Make("{진짜로 종료하시겠습니까?}")))
      {
        Environment.Exit(0);
      }
    }
    public static void TestInventory(IPlayer player)
    {
      Inventory myInventory = player.Inventory;

      myInventory.Items.having.GetItems(HavingType.Equipment).Add(new EquipmentItem()
      {
        Name = CTexts.Make("{테스트아이템1}"),
        Lore = "테스트용으로 만들어진 아이템이다. 번호는 1이다.",
        Type = ItemType.Equipment,
        Descriptions = CTexts.Make("{착용하면 아무런 효과도 얻을 수 없다.}")
      });

      myInventory.Items.having.GetItems(HavingType.Equipment).Add(new EquipmentItem()
      {
        Name = CTexts.Make("{테스트아이템2}"),
        Lore = "테스트용으로 만들어진 아이템이다. 번호는 2이다.",
        Type = ItemType.Equipment,
        Descriptions = CTexts.Make("{착용하면 여러가지 효과를 얻을 수 있다.}"),
        Increase = new ItemIncrease() { MaxHp = 500, MaxEp = 20, AttDmg = -5, DefPer = 1 }
      });

      myInventory.Items.having.GetItems(HavingType.Consume).Add(new ConsumeItem()
      {
        Name = CTexts.Make("{테스트 소비 아이템1}"),
        Lore = "{테스트용으로 만들어진 아이템이다. C2",
        Descriptions = CTexts.Make("{사용하면 여러가지 효과를 볼 수 있다.}"),
        Type = ItemType.Consume,
        Effect = new ItemEffect() { Hp = 10, Ep = -10, AttDmg = 5, DefPer = 2, Exp = 4040, Gold = -10 },
        Count = 2,
        LoseCount = 1
      });

      myInventory.Items.having.GetItems(HavingType.Other).Add(new ConsumeItem()
      {
        Name = CTexts.Make("{테스트포션1}"),
        Lore = "테스트용으로 만들어진 포션이다. C1",
        Descriptions = CTexts.Make("{사용하면 Hp를 회복하는 효과를 볼 수 있다.}"),
        Effect = new ItemEffect() { Hp = 500 },
        Type = ItemType.Consume,
        Count = 1,
        LoseCount = 1
      });

      myInventory.Items.having.GetItems(HavingType.Other).Add(new OtherItem()
      {
        Name = CTexts.Make("{테스트 기타 아이템}"),
        Type = ItemType.Other,
        Lore = "테스트용으로 만들어진 기타아이템이다. C1",
        Descriptions = CTexts.Make("{그냥 아이템이다. 이걸로 아무것도 할 수 있는 것은 없다.}"),
        Count = 10
      });
    }
  }
}