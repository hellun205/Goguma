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

      var qt = CTexts.Make($"{{고구마,{Colors.bgWarning}}}");

      var ssi = new SelectSceneItems();
      ssi.Add("{새로운 고구마}");
      if (pc > 0)
        ssi.Add("{이미 있는 고구마}");
      ssi.Add("{종료}");

      bool KeepPlay()
      {
        playerData = PlayerSave.GetPlayerData();
        if (playerData != null)
        {
          player = playerData;
          return true;
        }
        else
          return false;
      }

      var ss = new SelectScene(qt, ssi);
      switch (ss.getString)
      {
        case "새로운 고구마":
          playerData = PlayerSave.CreatePlayerData();
          if (playerData != null)
          {
            player = playerData;
            return;
          }
          break;
        case "이미 있는 고구마":
          if (KeepPlay()) return;
          break;
        case "종료":
          ExitGame();
          break;
      }
    }

    public static void ExitGame()
    {
      if (ReadYesOrNo(CTexts.Make("{고구마를 내버려두고 가시는 겁니까?}"), "고구마를 내버려두고 종료한다", "아니다, 고구마를 키우러 간다"))
        Environment.Exit(0);
    }

    public static T Rand<T>(T[] array)
    {
      return array[new Random().Next(0, array.Length)];
    }
  }
}
