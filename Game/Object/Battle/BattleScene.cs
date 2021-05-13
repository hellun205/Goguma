using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory;
using Goguma.Game.Object.Skill;
using System.Linq;
using static Goguma.Game.Console.ConsoleFunction;
using System.Collections.Generic;

namespace Goguma.Game.Object.Battle
{
  static class BattleScene
  {
    static public class PvE
    {
      static public SelectScene Meet(IPlayer player, IMonster monster)
      {
        Func<CTexts> GetQText = () =>
        {
          return CTexts.Make($"{{「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{(을)를 만났다! 무엇을 하시겠습니까?}}");
        };
        Func<SelectSceneItems> GetSSI = () =>
        {
          var resultSSI = new SelectSceneItems();
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{싸우기, {Colors.txtSuccess}}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{플레이어 정보 보기}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{몬스터 정보 보기}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{도망 가기, {Colors.txtDanger}}}")));
          return resultSSI;
        };
        return new SelectScene(GetQText(), GetSSI());
      }
      static public void Run()
      {
        PrintText(CTexts.Make($"{{\n싸움에서}} {{ 도망,{Colors.txtDanger}}} {{쳤습니다.\n}}"));
      }
      static public SelectScene Main(IPlayer player, IMonster monster, bool first = false)
      {
        Func<bool, CTexts> GetQText = (bool first) =>
         {
           if (first)
             return CTexts.Make($"{{「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{(이)랑 싸우기 시작했다. 무엇을 하시겠습니까?\n    남은 체력: }}{{[ {monster.Hp} / {monster.MaxHp} ]\n, {Battle.ColorByHp(monster.Hp, monster.MaxHp)}}}");
           else
             return CTexts.Make($"{{「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{(와)과 싸우고 있다. 무엇을 하시겠습니까?\n    남은 체력: }}{{[ {monster.Hp } / {monster.MaxHp} ]\n, {Battle.ColorByHp(monster.Hp, monster.MaxHp)}}}");
         };
        Func<SelectSceneItems> GetSSI = () =>
          {
            var resultSSI = new SelectSceneItems();
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{공격 하기, {Colors.txtSuccess}}}")));
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{스킬 사용, {Colors.txtSuccess}}}")));
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{인벤토리 열기}}")));
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{플레이어 정보 보기}}")));
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{몬스터 정보 보기}}")));
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{도망 가기, {Colors.txtDanger}}}")));
            return resultSSI;
          };
        return new SelectScene(GetQText(first), GetSSI());
      }
      static public SelectScene Attack()
      {
        Func<CTexts> GetQText = () =>
        {
          return CTexts.Make($"{{어떻게 공격하시겠습니까?}}");
        };
        Func<SelectSceneItems> GetSSI = () =>
        {
          var resultSSI = new SelectSceneItems();
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{일반 공격,{Colors.txtSuccess}}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{스킬 공격,{Colors.txtSuccess}}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
          return resultSSI;
        };
        return new SelectScene(GetQText(), GetSSI());
      }
      static public void GeneralAttack(IPlayer player, IMonster monster, int damage)
      {
        Func<int, CTexts> GetText = (int random) =>
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
        };
        PrintText(GetText(new Random().Next(0, 3)));
        Pause();
      }
      static public void SkillAttack(IPlayer player, IMonster monster, IAttackSkill aSkill, int damage)
      {
        Func<CTexts> Text = () =>
        {
          if (monster.Hp - damage <= 0)
            return CTexts.Make($"{{\n\n「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{(이)가 }}{{{aSkill.Name},{Colors.txtInfo}}}{{(을)를 맞아 }} {{{damage},{Colors.txtDanger}}} {{의 피해를 입고 }} {{죽었습니다,{Colors.txtDanger}}}{{.\n}}");
          else
            return CTexts.Make($"{{\n\n「{monster.Name} [Lv. {monster.Level}]」,{Battle.ColorByLevel(player.Level, monster.Level)}}} {{(이)가 }}{{{aSkill.Name},{Colors.txtInfo}}}{{(을)를 맞아 }} {{{damage},{Colors.txtDanger}}} {{의 피해를 입었습니다. \n    남은 체력: }}{{[ {monster.Hp - damage} / {monster.MaxHp} ]\n, {Battle.ColorByHp(monster.Hp - damage, monster.MaxHp)}}}");
        };

        PrintText(CTexts.Make($"{{\n  {Skill.Skill.GetTypeString(aSkill.Type)} 스킬 ,{Colors.txtWarning}}} {{{aSkill.Name},{Colors.txtInfo}}} {{(을)를 사용했습니다.\n    남은 에너지: }}{{[ {player.Ep - aSkill.useEp} / {player.MaxEp} ], {Battle.ColorByHp(player.Ep - aSkill.useEp, player.MaxEp)}}}{{\n    사용한 에너지: }}{{{aSkill.useEp}\n, {Colors.txtWarning}}}"));
        Pause();
        PrintText(CTexts.Make($"{{\n  {player.Name},{Colors.txtSuccess}}}{{ : }}"));
        PrintText(aSkill.Text);
        PrintText("\n\n");
        Pause();
        PrintText(Text());
        Pause();
      }
      static public void BuffSkill(IPlayer player, IBuffSkill bSkill)
      {
        PrintText(CTexts.Make($"{{\n  {Skill.Skill.GetTypeString(bSkill.Type)} 스킬 ,{Colors.txtWarning}}} {{{bSkill.Name},{Colors.txtInfo}}} {{(을)를 사용했습니다.\n    남은 에너지: }}{{[ {player.Ep - bSkill.useEp} / {player.MaxEp} ], {Battle.ColorByHp(player.Ep - bSkill.useEp, player.MaxEp)}}}{{\n    사용한 에너지: }}{{{bSkill.useEp}\n, {Colors.txtWarning}}}"));
        Pause();
        PrintText(CTexts.Make($"{{\n  {player.Name},{Colors.txtSuccess}}}{{ : }}"));
        PrintText(bSkill.Text);
        PrintText("\n\n");
        Pause();
        // PrintBuffEffect();
        // Pause();
      }
      static public void LackOfEP(IPlayer player, ISkill skill)
      {
        PrintText(CTexts.Make($"{{\n  에너지,{Colors.txtWarning}}}{{가 부족하여 }}{{{skill.Name}, {Colors.txtInfo}}}{{(을)를 사용 할 수 없습니다.\n    남은 에너지: }}{{[ {player.Ep} / {player.MaxEp} ], {Battle.ColorByHp(player.Ep, player.MaxEp)}}}{{\n    필요한 에너지: }}{{{skill.useEp}\n, {Colors.txtWarning}}}"));
        Pause();
      }
      static public void AlreadyUsingBuff(IBuffSkill bSkill)
      {
        PrintText(CTexts.Make($"{{\n이미 }}{{{Skill.Skill.GetTypeString(bSkill.Type)} 스킬 , {Colors.txtWarning}}}{{{bSkill.Name},{Colors.txtInfo}}}{{의 효과를 받고 있습니다.\n}}"));
        Pause();
      }
      static public void DeleteBuff(List<IBuffSkill> bSkills)
      {
        foreach (var sk in bSkills)
          PrintText(CTexts.Make($"{{\n{Skill.Skill.GetTypeString(sk.Type)} 스킬 , {Colors.txtWarning}}}{{{sk.Name},{Colors.txtInfo}}}{{의 지속시간이 끝났습니다.}}"));
        PrintText("\n");
        Pause();
      }
      static public void Kill(IMonster monster)
      {
        PrintText(CTexts.Make($"{{\n\n  {monster.GivingGold} G,{Colors.txtWarning}}}{{를 획득했습니다.\n}}"));
        Pause();
        PrintText(CTexts.Make($"{{\n\n  {monster.GivingExp} Exp,{Colors.txtSuccess}}}{{를 획득했습니다.\n}}"));
        Pause();
        foreach (var item in monster.DroppingItems.Drop())
        {
          PrintText(CTexts.Make($"{{\n\n  {InvenInfo.HavingInven.GetTypeString(item.Type)} 아이템 ,{Colors.txtWarning}}}{{{item.Name},{Colors.txtSuccess}}}{{(을)를 획득했습니다.\n}}"));
        }
        Pause();
      }
      static public class SelSkill
      {
        static public SkillType skType { get; set; }
        static public SelectScene Scean(IPlayer player)
        {
          Func<CTexts> GetQText = () =>
          {
            return CTexts.Make($"{{무슨 스킬을 사용하시겠습니까?}}");
          };
          Func<SelectSceneItems> GetSSI = () =>
          {
            var resultSSI = new SelectSceneItems();
            for (var i = 0; i < Enum.GetValues(typeof(SkillType)).Length; i++)
              resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{{Skill.Skill.GetTypeString((SkillType)i)} 스킬}}")));
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
            return resultSSI;
          };
          var skillTypeSc = new SelectScene(GetQText(), GetSSI());
          if (skillTypeSc.getString == "뒤로 가기") return null;
          skType = (SkillType)(skillTypeSc.getIndex - 1);
          var skills = from sk in player.Skills
                       where sk.Type == skType
                       select sk;
          var selIndexSc = Scean(player, skType);
          return selIndexSc;
        }
        static public SelectScene Scean(IPlayer player, SkillType sType)
        {
          Func<SkillType, CTexts> GetQText = (SkillType sType) =>
           {
             return CTexts.Make($"{{무슨 스킬을 사용하시겠습니까? }} {{[ {Skill.Skill.GetTypeString(sType)} 스킬 ],{Colors.txtWarning}}}");
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
    }
  }
}