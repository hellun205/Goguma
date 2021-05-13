using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory;
using Goguma.Game.Object.Skill;
using System.Linq;
using static Goguma.Game.Console.ConsoleFunction;
namespace Goguma.Game.Object.Battle
{
  static class BattleScene
  {
    static public class PvE
    {
      static public class Meet
      {
        static public SelectScene Scean(IPlayer player, IMonster monster)
        {
          return new SelectScene(GetQText(player, monster), GetSSI());
        }
        static public CTexts GetQText(IPlayer player, IMonster monster)
        {
          return CTexts.Make($"{{「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{(을)를 만났다! 무엇을 하시겠습니까?}}");
        }
        static public SelectSceneItems GetSSI()
        {
          var resultSSI = new SelectSceneItems();
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{싸우기, {Colors.txtSuccess}}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{플레이어 정보 보기}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{몬스터 정보 보기}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{도망 가기, {Colors.txtDanger}}}")));
          return resultSSI;
        }
      }
      static public void Run()
      {
        PrintText(CTexts.Make($"{{\n싸움에서}} {{ 도망,{Colors.txtDanger}}} {{쳤습니다.\n}}"));
      }
      static public class Main
      {
        static public SelectScene Scean(IPlayer player, IMonster monster, bool first = false)
        {
          return new SelectScene(GetQText(player, monster, first), GetSSI());
        }
        static public CTexts GetQText(IPlayer player, IMonster monster, bool first = false)
        {
          if (first)
            return CTexts.Make($"{{「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{(이)랑 싸우기 시작했다. 무엇을 하시겠습니까?}}");
          else
            return CTexts.Make($"{{「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{한테 무엇을 하시겠습니까?}}");
        }
        static public SelectSceneItems GetSSI()
        {
          var resultSSI = new SelectSceneItems();
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{공격 하기}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{인벤토리 열기}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{플레이어 정보 보기}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{몬스터 정보 보기}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{도망 가기, {Colors.txtDanger}}}")));
          return resultSSI;
        }
      }
      static public class Attack
      {
        static public SelectScene Scean()
        {
          return new SelectScene(GetQText(), GetSSI());
        }
        static public CTexts GetQText()
        {
          return CTexts.Make($"{{어떻게 공격하시겠습니까?}}");
        }
        static public SelectSceneItems GetSSI()
        {
          var resultSSI = new SelectSceneItems();
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{공격 하기}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{스킬 사용}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
          return resultSSI;
        }
      }
      static public class GeneralAttack
      {
        static public void Scean(IPlayer player, IMonster monster, int damage)
        {
          PrintText(GetText(player, monster, damage, new Random().Next(0, 3)));
          Pause();
        }
        static public CTexts GetText(IPlayer player, IMonster monster, int damage, int random = 0)
        {
          var rText = "";
          switch (random)
          {
            case 0:
            default:
              rText = "(을)를 공격해서";
              break;
            case 1:
              rText = "에게 주먹을 날려서";
              break;
            case 2:
              rText = "에게 발차기를 해서";
              break;
          }
          if (monster.Hp - damage <= 0)
            return CTexts.Make($"{{\n\n「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{{rText} }} {{{damage},{Colors.txtDanger}}} {{의 피해를 입혀 }} {{죽었습니다,{Colors.txtDanger}}}{{.\n}}");
          else
            return CTexts.Make($"{{\n\n「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{{rText} }} {{{damage},{Colors.txtDanger}}} {{의 피해를 입혔습니다.\n    남은 체력: }} {{[ {monster.Hp - damage} / {monster.MaxHp} ]\n, {Battle.ColorByHp(monster.Hp - damage, monster.MaxHp)}}}");
        }

      }
      static public class SkillAttack
      {
        static public void Scean(IPlayer player, IMonster monster, IAttackSkill aSkill, int damage)
        {
          PrintText(CTexts.Make($"{{\n  {player.Name},{Colors.txtSuccess}}}{{ : }}"));
          PrintText(aSkill.Text);
          PrintText("\n\n");
          Pause();
          PrintText(GetQText(player, monster, aSkill, damage));
          Pause();
        }
        static public CTexts GetQText(IPlayer player, IMonster monster, IAttackSkill aSkill, int damage)
        {
          if (monster.Hp - damage <= 0)
            return CTexts.Make($"{{\n\n「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{(이)가 }}{{{aSkill.Name},{Colors.txtInfo}}}{{(을)를 맞아 }} {{{damage},{Colors.txtDanger}}} {{의 피해를 입고 }} {{죽었습니다,{Colors.txtDanger}}}{{.\n}}");
          else
            return CTexts.Make($"{{\n\n「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{(이)가 }}{{{aSkill.Name},{Colors.txtInfo}}}{{(을)를 맞아 }} {{{damage},{Colors.txtDanger}}} {{의 피해를 입었습니다. \n    남은 체력: }}{{[ {monster.Hp - damage} / {monster.MaxHp} ]\n, {Battle.ColorByHp(monster.Hp - damage, monster.MaxHp)}}}");
        }
      }
      static public class BuffSkill
      {
        static public void Scean(IPlayer player, IBuffSkill bSkill)
        {
          PrintText(CTexts.Make($"{{\n  {player.Name},{Colors.txtSuccess}}}{{ : }}"));
          PrintText(bSkill.Text);
          PrintText("\n\n");
          Pause();
          PrintText(GetQText(player, bSkill));
          Pause();
        }
        static public CTexts GetQText(IPlayer player, IBuffSkill bSkill)
        {
          return CTexts.Make($"{{\n  {Skill.Skill.GetTypeString(bSkill.Type)} 스킬 ,{Colors.txtWarning}}} {{{bSkill.Name},{Colors.txtInfo}}} {{(을)를 사용했습니다.\n}}");
        }
      }
      static public class LackOfEP
      {
        static public void Scene(IPlayer player, ISkill skill)
        {
          PrintText(CTexts.Make($"{{\n  EP,{Colors.txtWarning}}}{{가 부족하여 }}{{{skill.Name}, {Colors.txtInfo}}}{{(을)를 사용 할 수 없습니다.\n    현재 EP: }}{{[{player.Ep}/{player.MaxEp}],{Colors.txtWarning}}} {{\n    필요한 EP: }} {{{skill.useEp}\n,{Colors.txtWarning}}}"));
          Pause();
        }
      }
      static public class Kill
      {
        static public void Scene(IMonster monster)
        {
          PrintText(CTexts.Make($"{{\n\n  {monster.GivingGold} G,{Colors.txtWarning}}}{{를 획득했습니다.\n}}"));
          Pause();
          PrintText(CTexts.Make($"{{\n\n  {monster.GivingExp} Exp,{Colors.txtSuccess}}}{{를 획득했습니다.\n}}"));
          Pause();
          foreach (var item in monster.DroppingItems.Items)
          {
            PrintText(CTexts.Make($"{{\n\n  {InvenInfo.HavingInven.GetTypeString(item.Item.Type)} 아이템 ,{Colors.txtWarning}}}{{{item.Item.Name},{Colors.txtSuccess}}}{{(을)를 획득했습니다.\n}}"));
          }
          Pause();
        }
      }
      static public class SelSkill
      {
        static public SelectScene Scean()
        {
          return new SelectScene(GetQText(), GetSSI());
        }
        static public SelectScene Scean(IPlayer player, SkillType sType)
        {
          return new SelectScene(GetQText(sType), GetSSI(player, sType));
        }

        static public CTexts GetQText()
        {
          return CTexts.Make($"{{무슨 스킬을 사용하시겠습니까?}}");
        }
        static public SelectSceneItems GetSSI()
        {
          var resultSSI = new SelectSceneItems();
          for (var i = 0; i < Enum.GetValues(typeof(SkillType)).Length; i++)
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{{Skill.Skill.GetTypeString((SkillType)i)} 스킬}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
          return resultSSI;
        }
        static public CTexts GetQText(SkillType sType)
        {
          return CTexts.Make($"{{무슨 스킬을 사용하시겠습니까? }} {{[ {Skill.Skill.GetTypeString(sType)} 스킬 ],{Colors.txtWarning}}}");
        }
        static public SelectSceneItems GetSSI(IPlayer player, SkillType sType)
        {
          var resultSSI = new SelectSceneItems();
          var skill = from sk in player.Skills
                      where sk.Type == sType
                      select sk;
          foreach (var sk in skill)
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{{sk.Name}}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
          return resultSSI;
        }
      }
    }
  }
}