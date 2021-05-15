using System;
using Colorify;
using Gogu_Remaster.Game.Object.Map;
using Gogu_Remaster.Game.Object.Map.Town;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Skill;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Entity.Player
{
  class PlayerAct
  {
    static public class Scene
    {
      static public class SelPlayerAct
      {
        static public CTexts GetQText(Location loc)
        {
          var map = Maps.GetMapByName(loc.Loc);
          string colors;

          if (loc.InTown)
            colors = Colors.txtSuccess;
          else
            colors = Colors.txtDanger;

          return CTexts.Make($"{{[ {map.Name} ] , {colors}}} {{무엇을 하시겠습니까?}}");
        }

        static public SelectSceneItems GetSSI(bool isAdmin = false)
        {
          var resultSSI = new SelectSceneItems();

          resultSSI.Add("{캐릭터 정보 보기}");
          resultSSI.Add("{인벤토리 열기}");
          resultSSI.Add("{이동하기}");

          if (InGame.player.Loc.InTown)
            resultSSI.Add(new SelectSceneItem(CTexts.Make("{시설 이용하기}")));
          else
            resultSSI.Add("{전투하기}");

          if (isAdmin)
            resultSSI.Add($"{{A,{Colors.txtWarning}}} {{D,{Colors.txtDanger}}} {{M,{Colors.txtSuccess}}} {{I,{Colors.txtInfo}}} {{N,{Colors.txtPrimary}}}");
          resultSSI.Add($"{{게임 종료, {Colors.txtMuted}}}");
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
          resultSSI.Add("{Test Inventory}");
          resultSSI.Add("{Player Level Up}");
          resultSSI.Add("{Battle with test monster}");
          resultSSI.Add("{Add Test Skill}");
          resultSSI.Add($"{{뒤로 가기, {Colors.txtMuted}}}");
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
        case "이동하기":
          player.Loc.Move();
          break;
        case "시설 이용하기":
          UseFacility();
          break;
        case "전투하기":
          StartRoadPvE();
          break;
        case "게임 종료":
          InGame.ExitGame();
          break;
      }
    }

    static private void UseFacility()
    {
      if (!InGame.player.Loc.InTown) return;
      var town = (Town)Maps.GetMapByName(InGame.player.Loc.Loc);
      var ssi = new SelectSceneItems();

      foreach (var f in town.Facilities)
        ssi.Add($"{{{f.Name} - {f.Fee}원 필요}}");

      var select = new SelectScene(CTexts.Make("{무엇을 하시겠습니까}"), ssi);
      town.Facilities[select.getIndex].OnUse();
    }

    static private void StartRoadPvE()
    {
      throw new NotImplementedException();
    }

    static private void AdminOption(Player player, bool isAdmin = false)
    {
      if (isAdmin)
      {
        while (true)
        {
          var ss = new SelectScene(Scene.SelAdminAct.GetQText(), Scene.SelAdminAct.GetSSI());
          switch (ss.getString)
          {
            case "Test Inventory":
              // InGame.TestInventory(player);
              break;
            case "Player Level Up":
              player.Exp += player.RequiredForLevelUp();
              break;
            case "Battle with test monster":
              var testMonster = Monsters.Get(MonsterList.TestMonster);
              Battle.Battle.PvE(player, testMonster);
              break;
            case "Add Test Skill":
              player.Skills.Add(Skills.GetPlayerSkill(SkillList.TestSkill1));
              player.Skills.Add(Skills.GetPlayerSkill(SkillList.TestSkill2));
              player.Skills.Add(Skills.GetPlayerSkill(SkillList.TestBuffSkill1));
              break;
            default:
              return;
          }
          PrintText(CTexts.Make($"{{\nSuccess : {ss.getString}, {Colors.txtSuccess}}}"));
          Pause();
        }
      }
    }

  }
}