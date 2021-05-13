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
        PlayerAct.Act(player, ss.getString);
      }
    }

    static public void SetPlayerDataScene()
    {
      Player playerData;
      var pc = PlayerSave.GetPlayerList().Count;

      var questionText = CTexts.Make($"{{고구마 게임,{Colors.bgWarning}}}");

      var selectSceneItems = new SelectSceneItems();
      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{새로 시작}")));
      if (pc > 0)
        selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{이어서 시작}")));
      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{게임 종료}")));

      while (true)
      {
        Action keepPlay = () =>
        {
          playerData = PlayerSave.GetPlayerData();
          if (playerData != null)
          {
            player = playerData;
            return;
          }
        };

        var ss = new SelectScene(questionText, selectSceneItems);
        switch (ss.getIndex)
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
            if (pc > 0)
              keepPlay();
            else
              ExitGame();

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
        Environment.Exit(0);
    }
  }
}