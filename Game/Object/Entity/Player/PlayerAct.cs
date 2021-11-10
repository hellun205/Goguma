using System.Text;
using Colorify;
using Goguma.Game.Object.Map;
using Goguma.Game.Object.Map.Road;
using Goguma.Game.Object.Map.Town;
using Goguma.Game.Object.Npc;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Skill;
using System.Linq;
using static Goguma.Game.Console.ConsoleFunction;
using Goguma.Game.Object.Inventory.Item;
using System;
using Goguma.Game.Object.Skill.Skills;

namespace Goguma.Game.Object.Entity.Player
{
  class PlayerAct
  {
    public static class Scene
    {
      public static SelectScene SelPlayerAct(Location loc, bool isAdmin = false)
      {
        Func<Location, CTexts> getQText = (Location loc) =>
        {
          var map = Maps.GetMapByName(loc.Loc);
          string colors;

          if (loc.InTown)
            colors = Colors.txtSuccess;
          else
            colors = Colors.txtDanger;

          return CTexts.Make($"{{[ {map.Name} ] , {colors}}} {{무엇을 하시겠습니까?}}");
        };

        Func<bool, SelectSceneItems> getSsi = (bool isAdmin) =>
        {
          var resultSsi = new SelectSceneItems();

          resultSsi.Add("{캐릭터 정보 보기}");
          if (InGame.player.PartyCount != 0)
          {
            resultSsi.Add("{파티원 정보 보기}");
          }

          resultSsi.Add("{인벤토리 열기}");
          resultSsi.Add("{스킬 보기}");
          resultSsi.Add("{스탯 보기}");
          resultSsi.Add("{퀘스트 보기}");
          resultSsi.Add("{이동하기}");
          resultSsi.Add($"{{{InGame.player.Loc.Loc} 살펴보기}}");

          if (InGame.player.Loc.InTown)
          {
            resultSsi.Add("{시설 이용하기}");
            resultSsi.Add("{NPC와 대화하기}");
          }
          else
            resultSsi.Add("{전투하기}");

          if (isAdmin)
            resultSsi.Add($"{{A,{Colors.txtWarning}}} {{D,{Colors.txtDanger}}} {{M,{Colors.txtSuccess}}} {{I,{Colors.txtInfo}}} {{N,{Colors.txtPrimary}}}");
          resultSsi.Add($"{{게임 종료, {Colors.txtMuted}}}");
          return resultSsi;
        };
        return new SelectScene(getQText(loc), getSsi(isAdmin));
      }
      public static SelectScene SelAdminAct()
      {
        Func<CTexts> getQText = () =>
        {
          return CTexts.Make($"{{작업을 선택하세요.}}");
        };
        Func<SelectSceneItems> getSsi = () =>
        {
          var resultSsi = new SelectSceneItems();
          resultSsi.Add("{Test Inventory}");
          resultSsi.Add("{Player Level Up}");
          resultSsi.Add("{Battle with test monster}");
          resultSsi.Add("{Add Test Skill}");
          resultSsi.Add("{Add Item}");
          resultSsi.Add("{Add Gold}");
          return resultSsi;
        };
        return new SelectScene(getQText(), getSsi(), true);
      }
      public static SelectScene SelSkillType(Player player, out SkillType skType)
      {
        Func<CTexts> getQText = () =>
        {
          return CTexts.Make($"{{스킬을 선택하세요.}}");
        };
        Func<SelectSceneItems> getSsi = () =>
        {
          var resultSsi = new SelectSceneItems();
          for (var i = 0; i < Enum.GetValues(typeof(SkillType)).Length; i++)
            resultSsi.Add($"{{{Skill.Skill.GetTypeString((SkillType)i)} 스킬}}");
          return resultSsi;
        };
        skType = (SkillType)0;
        var skillTypeSc = new SelectScene(getQText(), getSsi(), true);
        if (skillTypeSc.isCancelled) return null;
        skType = (SkillType)(skillTypeSc.getIndex);
        var skills = from sk in player.Skills
                     where sk.Type == (SkillType)(skillTypeSc.getIndex)
                     select sk;
        var selIndexSc = SelSkill(player, skType);
        return selIndexSc;
      }
      public static SelectScene SelSkill(Player player, SkillType sType)
      {
        Func<SkillType, CTexts> getQText = (SkillType sType) =>
         {
           return CTexts.Make($"{{스킬을 선택하세요.}} {{[ {Skill.Skill.GetTypeString(sType)} 스킬 ],{Colors.txtWarning}}}");
         };
        Func<SkillType, SelectSceneItems> getSsi = (SkillType sType) =>
        {
          var resultSsi = new SelectSceneItems();
          var skill = from sk in player.Skills
                      where sk.Type == sType
                      select sk;
          foreach (var sk in skill)
            resultSsi.Add($"{{{sk.Name}}}");
          return resultSsi;
        };
        var scene = new SelectScene(getQText(sType), getSsi(sType), true);
        if (scene.isCancelled) return null;
        return scene;
      }
    }
    public static void Act(string actText)
    {
      switch (actText)
      {
        case "캐릭터 정보 보기":
          InGame.player.Information();
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
        case "퀘스트 보기":
          InGame.player.Quest.ShowQuests();
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
        case "파티원 정보 보기":
          // TO DO .
          break;
        case "스탯 보기":
          ViewStat();
          break;
        default:
          if (actText.StartsWith(InGame.player.Loc.Loc))
            InsepctLoc();
          break;
      }
    }

    private static void TalkWithNpc()
    {
      if (!InGame.player.Loc.InTown) return;
      var town = (Town)Maps.GetMapByName(InGame.player.Loc.Loc);

      var ssi = new SelectSceneItems();

      if (town.Npcs.Count < 1)
        ssi.Add("{없음}", false);
      else
        foreach (var n in town.Npcs)
          ssi.Add(Npcs.Get(n).DisplayName);

      var s = new SelectScene(CTexts.Make("{누구와 대화하시겠습니까?}"), ssi, true);
      if (s.isCancelled) return;

      Npcs.Get(town.Npcs[s.getIndex]).OnDialogOpen();
    }

    private static void ViewSkill()
    {
      Player player = InGame.player;
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

    private static void InsepctLoc()
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
            sb.Append($"\n{Monster.Monster.GetNew(m.Monster).Name}");
      }

      sb.Append("\n" + StringFunction.GetSep(30));
      PrintText(sb.ToString());
      Pause();
    }

    private static void UseFacility()
    {
      if (!InGame.player.Loc.InTown) return;
      var town = (Town)Maps.GetMapByName(InGame.player.Loc.Loc);
      var ssi = new SelectSceneItems();

      foreach (var f in town.Facilities)
        ssi.Add($"{{{f.Name} - {f.Fee}원 필요}}");

      var select = new SelectScene("{무엇을 하시겠습니까}", ssi, true);
      if (select.isCancelled) return;
      town.Facilities[select.getIndex].OnUse();
    }

    private static void StartRoadPvE()
    {
      if (InGame.player.Loc.InTown) return;

      var road = (Road)Maps.GetMapByName(InGame.player.Loc.Loc);
      var monster = road.SummonMonster();

      Battle.Battle.PvE(monster);
    }

    private static void AdminOption(Player player, bool isAdmin = false)
    {
      if (isAdmin)
      {
        while (true)
        {
          var ss = Scene.SelAdminAct();
          if (ss.isCancelled) return;
          switch (ss.getString)
          {
            case "Test Inventory":
              // InGame.TestInventory(player);
              break;
            case "Player Level Up":
              player.Exp += player.RequiredForLevelUp();
              break;
            case "Battle with test monster":
              var testMonster = Monster.Monster.GetNew(MonsterList.TestMonster);
              Battle.Battle.PvE(testMonster);
              break;
            case "Add Test Skill":
              player.Skills.Add(PlayerSkills.GetNew(SkillList.TestSkill1));
              player.Skills.Add(PlayerSkills.GetNew(SkillList.TestSkill2));
              player.Skills.Add(PlayerSkills.GetNew(SkillList.TestBuffSkill1));
              break;
            case "Add Item":
              var ssi = new SelectSceneItems();
              for (var i = 0; i < Enum.GetValues(typeof(ItemList)).Length; i++)
                ssi.Add(Itemss.GetInstance((ItemList)i).DisplayName);
              var itemSelectSs = new SelectScene(CTexts.Make("{아이템을 선택하시오.}"), ssi, true);
              if (itemSelectSs.isCancelled) return;
              int rCount;
              if (ReadInt("{수량을 입력하세요.}", out rCount, 0, 0)) break;
              player.Inventory.GetItem(new ItemPair((ItemList)itemSelectSs.getIndex, rCount));
              PrintCText(CTexts.Make("{\n아이템 }").Combine(Itemss.GetInstance((ItemList)itemSelectSs.getIndex).DisplayName).Combine($"{{{rCount}개를 얻었습니다.\n}}"));
              Pause();
              break;
            case "Add Gold":
              int count;
              if (ReadInt("{수량을 입력하세요.}", out count, 0, 0)) break;
              InGame.player.Gold += count;
              PrintText($"\n{count}G를 얻었습니다.");
              Pause();
              break;
            default: throw new NotImplementedException();
          }
          PrintCText($"{{\nSuccess : {ss.getString}, {Colors.txtSuccess}}}");
          Pause();
        }
      }
    }

    private static void ViewStat()
    {
      
    }
  }
}