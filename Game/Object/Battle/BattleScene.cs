using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Entity.Player;
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
            return CTexts.Make($"{{\n「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{{rText} }} {{{damage},{Colors.txtDanger}}} {{의 피해를 입혀}} {{죽었습니다,{Colors.txtDanger}}}{{.}}");
          else
            return CTexts.Make($"{{\n「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{{rText} }} {{{damage},{Colors.txtDanger}}} {{의 피해를 입혔습니다.\n    남은 체력: }} {{[ {monster.Hp} / {monster.MaxHp} ], {Battle.ColorByHp(monster.Hp, monster.MaxHp)}}}");
        }

      }
      static public class SkillAttack
      {
        static public SelectScene Scean(IPlayer player)
        {
          return new SelectScene(GetQText(), GetSSI(player));
        }
        static public CTexts GetQText()
        {
          return CTexts.Make($"{{무슨 스킬을 사용하시겠습니까?}}");
        }
        static public SelectSceneItems GetSSI(IPlayer player)
        {
          var resultSSI = new SelectSceneItems();
          foreach (var skill in player.Skills)
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{{skill.Name}}} {{[ {Skill.Skill.GetTypeString(skill.Type)} ], {Colors.txtWarning}}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
          return resultSSI;
        }
      }
    }
  }
}