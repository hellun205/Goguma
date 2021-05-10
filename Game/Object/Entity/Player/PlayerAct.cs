using System.Globalization;
using System.Threading;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Map;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Entity.Player
{
  class PlayerAct
  {
    static public class Scene
    {
      static public class SelPlayerAct
      {
        static public CTexts GetQText(MapList map)
        {
          return CTexts.Make($"{{[ {Map.Map.GetText(map)} ] , {Colors.bgSuccess}}} {{이 곳에서 무슨 작업을 하시겠습니까?}}");
        }
        static public SelectSceneItems GetSSI(MapList map, bool isAdmin = false)
        {
          var resultSSI = new SelectSceneItems();

          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{캐릭터 정보 보기}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{인벤토리 열기}")));
          switch (map)
          {
            case MapList.Not:
              // resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{}")));
              break;
          }
          if (isAdmin)
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{A,{Colors.txtWarning}}} {{D,{Colors.txtDanger}}} {{M,{Colors.txtSuccess}}} {{I,{Colors.txtInfo}}} {{N,{Colors.txtPrimary}}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{게임 종료, {Colors.txtMuted}}}")));
          return resultSSI;
        }
      }
      static public class SelAdminAct
      {
        static public CTexts GetQText()
        {
          return CTexts.Make($"{{작업을 선택하세요.}}");
        }
        static public SelectSceneItems GetSSI()
        {
          var resultSSI = new SelectSceneItems();

          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{Test Inventory}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{Player Level Up}")));

          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
          return resultSSI;
        }
      }
    }
    static public void Act(Player player, string actText)
    {
      switch (actText)
      {
        case "캐릭터 정보 보기":
          player.PrintAbout();
          break;
        case "ADMIN":
          AdminOption(player, true);
          break;
        case "인벤토리 열기":
          player.Inventory.Print();
          break;
        case "게임 종료":
          InGame.ExitGame();
          break;
      }
    }
    static private void AdminOption(Player player, bool isAdmin = false)
    {
      if (isAdmin)
      {
        while (true)
        {
          var ss = new SelectScene(Scene.SelAdminAct.GetQText(), Scene.SelAdminAct.GetSSI());
          switch (ss.GetString)
          {
            case "Test Inventory":
              InGame.TestInventory(player);
              break;
            case "Player Level Up":
              player.Exp += player.RequiredForLevelUp();
              break;
            default:
              return;
          }
          PrintText(CTexts.Make($"{{\nSuccess : {ss.GetString}, {Colors.txtSuccess}}}"));
          Pause();
        }
      }
    }

  }
}