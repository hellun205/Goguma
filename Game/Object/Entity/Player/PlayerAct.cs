using System.Text;
using Colorify;
using Gogu_Remaster.Game.Object.Map;
using Gogu_Remaster.Game.Object.Map.Road;
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
          resultSSI.Add($"{{{InGame.player.Loc.Loc} 살펴보기}}");

          if (InGame.player.Loc.InTown)
          {
            resultSSI.Add("{시설 이용하기}");
            resultSSI.Add("{NPC와 대화하기}");
          }
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
        case "NPC와 대화하기":
          TalkWithNpc();
          break;
        case "전투하기":
          StartRoadPvE();
          break;
        case "게임 종료":
          InGame.ExitGame();
          break;
        default:
          if (actText.StartsWith(InGame.player.Loc.Loc))
            InsepctLoc();
          break;
      }
    }

    static private void TalkWithNpc()
    {

    }

    static private void InsepctLoc()
    {
      var sb = new StringBuilder();
      sb.Append(StringFunction.GetSep(30, InGame.player.Loc.Loc));


      if (InGame.player.Loc.InTown)
      {
        sb.Append("\n\n편의 시설");

        var town = (Town)Maps.GetMapByName(InGame.player.Loc.Loc);

        if (town.Facilities.Count < 1)
          sb.Append("\n없음");
        else
          foreach (var f in town.Facilities)
            sb.Append($"\n{f.Name}");
      }
      else
      {
        sb.Append("\n\n출현 몬스터");

        var road = (Road)Maps.GetMapByName(InGame.player.Loc.Loc);

        if (road.SummonMonsters.Count < 1)
          sb.Append("\n없음");
        else
          foreach (var m in road.SummonMonsters)
            sb.Append($"\n{Monsters.Get(m.Monster).Name}");
      }

      sb.Append("\n" + StringFunction.GetSep(30));
      PrintText(sb.ToString());
      Pause();
    }

    static private void UseFacility()
    {
      if (!InGame.player.Loc.InTown) return;
      var town = (Town)Maps.GetMapByName(InGame.player.Loc.Loc);
      var ssi = new SelectSceneItems();

      foreach (var f in town.Facilities)
        ssi.Add($"{{{f.Name} - {f.Fee}원 필요}}");
      ssi.Add($"{{뒤로 가기, {Colors.txtMuted}}}");

      var select = new SelectScene(CTexts.Make("{무엇을 하시겠습니까}"), ssi);
      if (select.getString == "뒤로 가기") return;
      town.Facilities[select.getIndex].OnUse();
    }

    static private void StartRoadPvE()
    {
      if (InGame.player.Loc.InTown) return;

      var road = (Road)Maps.GetMapByName(InGame.player.Loc.Loc);
      var monster = road.SummonMonster();

      Battle.Battle.PvE(monster);
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
              Battle.Battle.PvE(testMonster);
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