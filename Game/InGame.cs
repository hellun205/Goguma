using Colorify;
using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;
using Goguma.Game.Object.Entity.Player;
using System;

namespace Goguma.Game
{
  public static class InGame
  {
    public static Player player;
    public static void Go()
    {
      while (true)
      {
        SetPlayerData();
        PlayerActScene();
      }
    }

    public static void PlayerActScene()
    {
      if (player == null) return;
      while (true)
      {
        var ss = PlayerAct.Scene.SelPlayerAct(player.Loc, true /*Admin*/);
        PlayerAct.Act(ss.getString);
      }
    }

    public static void SetPlayerData()
    {
      Player playerData;
      var pc = PlayerSave.GetPlayerList().Count;

      var qt = CTexts.Make($"{{고구마 게임,{Colors.bgWarning}}}");

      var ssi = new SelectSceneItems();
      ssi.Add("{새로 시작}");
      if (pc > 0)
        ssi.Add("{이어서 시작}");
      ssi.Add("{게임 종료}");

      Func<bool> keepPlay = () =>
      {
        playerData = PlayerSave.GetPlayerData();
        if (playerData != null)
        {
          player = playerData;
          return true;
        }
        else return false;
      };

      var ss = new SelectScene(qt, ssi);
      switch (ss.getString)
      {
        case "새로 시작":
          playerData = PlayerSave.CreatePlayerData();
          if (playerData != null)
          {
            player = playerData;
            return;
          }
          break;
        case "이어서 시작":
          if (keepPlay()) return;
          break;
        case "게임 종료":
          ExitGame();
          break;
      }
    }

    public static void ExitGame()
    {
      if (ReadYesOrNo(CTexts.Make("{진짜로 종료하시겠습니까?}")))
        Environment.Exit(0);
    }

    public static T Rand<T>(T[] array)
    {
      return array[new Random().Next(0, array.Length)];
    }
  }
}
