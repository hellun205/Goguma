using System.Text;
using Colorify;
using Gogu_Remaster.Game.Object.Map;
using Gogu_Remaster.Game.Object.Map.Road;
using Gogu_Remaster.Game.Object.Map.Town;
using Gogu_Remaster.Game.Object.Npc;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Skill;
using System.Linq;
using static Goguma.Game.Console.ConsoleFunction;
using Goguma.Game.Object.Inventory.Item;

namespace Goguma.Game.Object.Entity.Player
{
  class PlayerAct
  {
    static public class Scene
    {
      static public SelectScene SelPlayerAct(Location loc, bool isAdmin = false)
      {
        Func<Location, CTexts> GetQText = (Location loc) =>
        {
          var map = Maps.GetMapByName(loc.Loc);
          string colors;

          if (loc.InTown)
            colors = Colors.txtSuccess;
          else
            colors = Colors.txtDanger;

          return CTexts.Make($"{{[ {map.Name} ] , {colors}}} {{무엇을 하시겠습니까?}}");
        };

        Func<bool, SelectSceneItems> GetSSI = (bool isAdmin) =>
        {
          var resultSSI = new SelectSceneItems();

          resultSSI.Add("{캐릭터 정보 보기}");
          resultSSI.Add("{인벤토리 열기}");
          resultSSI.Add("{스킬 보기}");
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
        };
        return new SelectScene(GetQText(loc), GetSSI(isAdmin));
      }
      static public SelectScene SelAdminAct()
      {
        Func<CTexts> GetQText = () =>
        {
          return CTexts.Make($"{{작업을 선택하세요.}}");
        };
        Func<SelectSceneItems> GetSSI = () =>
        {
          var resultSSI = new SelectSceneItems();
          resultSSI.Add("{Test Inventory}");
          resultSSI.Add("{Player Level Up}");
          resultSSI.Add("{Battle with test monster}");
          resultSSI.Add("{Add Test Skill}");
          resultSSI.Add("{Add Item}");
          resultSSI.Add($"{{뒤로 가기, {Colors.txtMuted}}}");
          return resultSSI;
        };
        return new SelectScene(GetQText(), GetSSI());
      }
      static public SelectScene SelSkillType(IPlayer player, out SkillType skType)
      {
        Func<CTexts> GetQText = () =>
        {
          return CTexts.Make($"{{스킬을 선택하세요.}}");
        };
        Func<SelectSceneItems> GetSSI = () =>
        {
          var resultSSI = new SelectSceneItems();
          for (var i = 0; i < Enum.GetValues(typeof(SkillType)).Length; i++)
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{{Skill.Skill.GetTypeString((SkillType)i)} 스킬}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
          return resultSSI;
        };
        skType = (SkillType)0;
        var skillTypeSc = new SelectScene(GetQText(), GetSSI());
        if (skillTypeSc.getString == "뒤로 가기") return null;
        skType = (SkillType)(skillTypeSc.getIndex);
        var skills = from sk in player.Skills
                     where sk.Type == (SkillType)(skillTypeSc.getIndex)
                     select sk;
        var selIndexSc = SelSkill(player, skType);
        return selIndexSc;
      }
      static public SelectScene SelSkill(IPlayer player, SkillType sType)
      {
        Func<SkillType, CTexts> GetQText = (SkillType sType) =>
         {
           return CTexts.Make($"{{스킬을 선택하세요.}} {{[ {Skill.Skill.GetTypeString(sType)} 스킬 ],{Colors.txtWarning}}}");
         };
        Func<SkillType, SelectSceneItems> GetSSI = (SkillType sType) =>
        {
          var resultSSI = new SelectSceneItems();
          var skill = from sk in player.Skills
                      where sk.Type == sType
                      select sk;
          foreach (var sk in skill)
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{{sk.Name}}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
          return resultSSI;
        };
        var scene = new SelectScene(GetQText(sType), GetSSI(sType));
        if (scene.getString == "뒤로 가기") return null;
        return scene;
      }
    }
    static public void Act(string actText)
    {
      switch (actText)
      {
        case "캐릭터 정보 보기":
          InGame.player.PrintAbout();
          break;
        case "ADMIN":
          AdminOption(InGame.player, true);
          break;
        case "인벤토리 열기":
          InGame.player.Inventory.Open();
          break;
        case "스킬 보기":
          ViewSkill();
          break;
        case "이동하기":
          InGame.player.Loc.Move();
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
      if (!InGame.player.Loc.InTown) return;
      var town = (Town)Maps.GetMapByName(InGame.player.Loc.Loc);

      var ssi = new SelectSceneItems();

      if (town.Npcs.Count < 1)
        ssi.Add("{없음}");
      else
        foreach (var n in town.Npcs)
          ssi.Add($"{{{Npcs.GetTraderByEnum(n).Name}}}");

      var s = new SelectScene(CTexts.Make("{누구와 대화하시겠습니까?}"), ssi);

      Npcs.GetTraderByEnum(town.Npcs[s.getIndex]).OnUse();
    }
    
    static private void ViewSkill()
    {
      IPlayer player = InGame.player;
      while (true)
      {
        SkillType skillType;
        var skSc = Scene.SelSkillType(InGame.player, out skillType);
        if (skSc == null) return;
        var skills = from sk in player.Skills
                     where sk.Type == skillType
                     select sk;
        var skill = skills.ToList<ISkill>()[skSc.getIndex];
        skill.Information();
      }
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
          var ss = Scene.SelAdminAct();
          switch (ss.getString)
          {
            case "Test Inventory":
              // InGame.TestInventory(player);
              break;
            case "Player Level Up":
              player.Exp += player.RequiredForLevelUp();
              break;
            case "Battle with test monster":
              var testMonster = Monsters.Get(MonsterList.TEST_MONSTER);
              Battle.Battle.PvE(testMonster);
              break;
            case "Add Test Skill":
              player.Skills.Add(Skills.GetPlayerSkill(SkillList.TestSkill1));
              player.Skills.Add(Skills.GetPlayerSkill(SkillList.TestSkill2));
              player.Skills.Add(Skills.GetPlayerSkill(SkillList.TestBuffSkill1));
              break;
            case "Add Item":
              var ssi = new SelectSceneItems();
              for (var i = 0; i < Enum.GetValues(typeof(ItemList)).Length; i++)
                ssi.Add(new SelectSceneItem(Items.Get((ItemList)i).Name));
              ssi.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기,{Colors.txtMuted}}}")));
              var itemSelectSS = new SelectScene(CTexts.Make("{아이템을 선택하시오.}"), ssi);
              if (itemSelectSS.getString == "뒤로 가기") return;
              player.Inventory.GetItem(Items.Get((ItemList)itemSelectSS.getIndex));
              PrintText($"\n아이템 {Items.Get((ItemList)itemSelectSS.getIndex).Name}(을)를 얻었습니다.\n");
              Pause();
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