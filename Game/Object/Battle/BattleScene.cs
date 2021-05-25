using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory;
using Goguma.Game.Object.Skill;
using System.Linq;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;
using System.Collections.Generic;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Entity;

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
          return CTexts.Make($"{{「{monster.Name} [Lv. {monster.Level}]」,{ColorByLevel(player.Level, monster.Level)}}} {{(을)를 만났다! 무엇을 하시겠습니까?}}");
        };
        Func<SelectSceneItems> GetSSI = () =>
        {
          var resultSSI = new SelectSceneItems();
          resultSSI.Add($"{{싸우기, {Colors.txtSuccess}}}");
          resultSSI.Add($"{{플레이어 정보 보기}}");
          resultSSI.Add($"{{몬스터 정보 보기}}");
          resultSSI.Add($"{{도망 가기, {Colors.txtDanger}}}");
          return resultSSI;
        };
        return new SelectScene(GetQText(), GetSSI());
      }

      static private void SkillText(IEntity caster, ISkill skill)
      {
        if (skill.Text != null)
        {
          PrintCText($"{{\n\n  {caster.Name},{Colors.txtSuccess}}}{{ : }}");
          PrintCText(skill.Text);
          PrintText("\n");
          Pause();
        }
      }

      static private CTexts SkillText(ISkill skill)
      {
        return CTexts.Make($"{{{Skill.Skill.GetTypeString(skill.Type)} 스킬 , {Colors.txtWarning}}}{{{skill.Name},{Colors.txtInfo}}}");
      }

      static private CTexts MonsterText(IPlayer player, IMonster monster)
      {
        return CTexts.Make($"{{「{monster.Name} [Lv. {monster.Level}]」,{ColorByLevel(player.Level, monster.Level)}}}");
      }
      static private CTexts CasterText(IEntity caster)
      {
        return caster.Type == EntityType.PLAYER ? CTexts.Make($"{{당신,{Colors.txtInfo}}}") : MonsterText(InGame.player, (IMonster)caster);
      }

      static private void UseSkillText(IEntity caster, ISkill skill)
      {
        var cName = CasterText(caster);
        var ct = CTexts.Make($"{{\n  }}").Combine(cName).Combine("{(이)가 }").Combine(SkillText(skill)).Combine($"{{(을)를 사용했습니다.");
        if (caster.Type == EntityType.PLAYER)
          PrintCText(ct.Combine($"{{\n    남은 에너지: }}").Combine(((IPlayer)caster).GetEpBar()).Combine($"{{\n    사용한 에너지: }}{{{skill.UseEp}\n, {Colors.txtWarning}}}"));
        else PrintCText(ct);

        Pause();
        SkillText(caster, skill);
      }

      static public void SkillAttack(IEntity caster, IEntity target, IAttackSkill skill, double damage, bool isCrit = false)
      {
        var cName = CasterText(caster);
        var tName = CasterText(target);
        var sName = SkillText(skill);
        Func<CTexts> GetText = () =>
        {
          var dText = new CTexts();
          if (target.IsDead)
            dText = CTexts.Make($"{{{(isCrit ? "의 치명타 피해를 입고" : "의 피해를 입고")} }}{{죽었습니다,{Colors.txtDanger}}}{{.\n}}");
          else
            dText = CTexts.Make($"{{{(isCrit ? "의 치명타 피해를 입었습니다" : "의 피해를 입었습니다")}.\n    }}").Combine(tName).Combine($"{{의 체력: }}").Combine(target.GetHpBar()).Combine($"{{.\n}}");

          return tName.Combine($"{{(이)가 }}").Combine(cName).Combine($"{{(이)가 사용 한}}").Combine(sName).Combine($"{{(을)를 맞아 }}{{{Math.Round(damage, 2)},{Colors.txtDanger}}}").Combine($"{dText}");
        };

        UseSkillText(caster, skill);
        PrintCText(GetText());
        Pause();
      }

      static public void BuffSkill(IEntity caster, IBuffSkill skill)
      {
        Func<CTexts> GetBfEftTxt = () =>
        {
          var resCT = new CTexts();
          var cName = CasterText(caster);
          Func<string, bool, CTexts> GetText = (string str, bool isHeal) =>
            {
              var firstCT = CTexts.Make("{\n  }").Combine(cName).Combine("{의 }");
              var lastCT = isHeal ? CTexts.Make("{만큼 회복했습니다.}") : CTexts.Make("{만큼 증가했습니다.}");
              return firstCT.Combine(CTexts.Make(str)).Combine(lastCT);
            };
          bool isBuff = false;
          resCT.Add("\n");
          if (skill.buff.MaxHp != 0)
          {
            isBuff = true;
            resCT.Append(GetText($"{{최대 체력이 }}{{{skill.buff.MaxHp},{Colors.txtInfo}}}", false));
          }
          if (skill.buff.MaxEp != 0 && caster.Type == EntityType.PLAYER)
          {
            isBuff = true;
            resCT.Append(GetText($"{{최대 에너지가 }}{{{skill.buff.MaxEp},{Colors.txtInfo}}}", false));
          }
          if (skill.buff.AttDmg != 0)
          {
            isBuff = true;
            resCT.Append(GetText($"{{공격력이 }}{{{skill.buff.AttDmg},{Colors.txtDanger}}}", false));
          }
          if (skill.buff.CritDmg != 0)
          {
            isBuff = true;
            resCT.Append(GetText($"{{크리티컬 데미지가 }}{{{skill.buff.CritDmg} %,{Colors.txtDanger}}}", false));
          }
          if (skill.buff.CritPer != 0)
          {
            isBuff = true;
            resCT.Append(GetText($"{{크리티컬 확률이 }}{{{skill.buff.CritPer} %,{Colors.txtDanger}}}", false));
          }
          if (skill.buff.IgnoreDef != 0)
          {
            isBuff = true;
            resCT.Append(GetText($"{{방어율 무시가 }}{{{skill.buff.IgnoreDef} %,{Colors.txtDanger}}}", false));
          }
          if (skill.buff.DefPer != 0)
          {
            isBuff = true;
            resCT.Append(GetText($"{{방어율이 }}{{{skill.buff.DefPer} %,{Colors.txtInfo}}}", false));
          }
          if (skill.buff.Hp != 0)
          {
            isBuff = true;
            resCT.Append(GetText($"{{체력을 }}{{{skill.buff.Hp} %,{Colors.txtInfo}}}", true));
          }
          if (skill.buff.Ep != 0 && caster.Type == EntityType.PLAYER)
          {
            isBuff = true;
            resCT.Append(GetText($"{{에너지를 }}{{{skill.buff.Ep} %,{Colors.txtInfo}}}", true));
          }
          if (!isBuff)
            resCT.Append(CTexts.Make("{아무런 효과가 없었습니다.}"));
          resCT.Append(CTexts.Make("{\n}"));
          return resCT;
        };
        UseSkillText(caster, skill);
        PrintCText(GetBfEftTxt());
        Pause();
        // PrintBuffEffect();
        // Pause();
      }

      static public void DeleteBuff(IEntity caster, List<IBuffSkill> bSkills)
      {
        var cName = CasterText(caster);
        foreach (var sk in bSkills)
        {
          var sName = SkillText(sk);
          PrintCText(CTexts.Make("{\n}").Combine(cName).Combine("{의 }").Combine(sName).Combine($"{{의 지속시간이 끝났습니다.}}"));
        }
        PrintText("\n");
        Pause();
      }

      static public void GeneralAttack(IEntity caster, IEntity target, double damage, bool isCrit = false)
      {
        var cName = CasterText(caster);
        var tName = CasterText(target);
        Func<CTexts> GetText = () =>
        {
          var dText = new CTexts();
          if (target.IsDead)
            dText = CTexts.Make($"{{{(isCrit ? "의 치명타 피해를 입고" : "의 피해를 입고")} }}{{죽었습니다,{Colors.txtDanger}}}{{.\n}}");
          else
            dText = CTexts.Make($"{{{(isCrit ? "의 치명타 피해를 입혔습니다." : "의 피해를 입혔습니다.")}\n    }}").Combine(tName).Combine($"{{의 체력: }}").Combine(target.GetHpBar()).Combine($"{{.\n}}");

          return cName.Combine($"{{(이)가 }}").Combine(tName).Combine($"{{(을)를 공격해서 }}{{{Math.Round(damage, 2)},{Colors.txtDanger}}}").Combine($"{dText}");
        };
        PrintCText(GetText());
        // Pause();
      }

      static public class Player
      {
        static public void Run()
        {
          PrintCText($"{{\n싸움에서}} {{ 도망,{Colors.txtDanger}}} {{쳤습니다.\n}}");
        }
        static public SelectScene Main(IPlayer player, IMonster monster, bool first = false)
        {
          Func<bool, CTexts> GetQText = (bool first) =>
           {
             var mName = CTexts.Make($"{{「{monster.Name} [Lv. {monster.Level}]」,{ColorByLevel(player.Level, monster.Level)}}}");
             string txt;
             if (first)
               txt = "{(이)랑 싸우기 시작했다! 무엇을 하시겠습니까?\n    }";
             else
               txt = "{(이)랑 싸우고 있다. 무엇을 하시겠습니까?\n    }";

             return mName.Combine($"{txt}").Combine(mName.Combine("{의 체력: }").Combine(monster.GetHpBar()).Combine("\n"));
           };
          Func<SelectSceneItems> GetSSI = () =>
            {
              var resultSSI = new SelectSceneItems();
              resultSSI.Add($"{{공격 하기, {Colors.txtSuccess}}}");
              resultSSI.Add($"{{스킬 사용, {Colors.txtSuccess}}}");
              resultSSI.Add($"{{인벤토리 열기}}");
              resultSSI.Add($"{{플레이어 정보 보기}}");
              resultSSI.Add($"{{몬스터 정보 보기}}");
              resultSSI.Add($"{{도망 가기, {Colors.txtDanger}}}");
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
            resultSSI.Add($"{{일반 공격,{Colors.txtSuccess}}}");
            resultSSI.Add($"{{스킬 공격,{Colors.txtSuccess}}}");
            resultSSI.Add($"{{뒤로 가기, {Colors.txtMuted}}}");
            return resultSSI;
          };
          return new SelectScene(GetQText(), GetSSI());
        }

        static public void LackOfEP(IPlayer player, ISkill skill)
        {
          var sName = SkillText(skill);
          PrintCText(CTexts.Make($"{{\n  에너지가 부족하여 }}").Combine(sName).Combine($"{{(을)를 사용 할 수 없습니다.\n    남은 에너지: }}").Combine(player.GetEpBar()).Combine($"{{\n    사용한 에너지: }}{{{skill.UseEp}\n, {Colors.txtWarning}}}"));
          Pause();
        }
        static public void AlreadyUsingBuff(IBuffSkill skill)
        {
          var sName = SkillText(skill);
          PrintCText(CTexts.Make($"{{\n이미 }}").Combine(sName).Combine(CTexts.Make($"{{의 효과를 받고 있습니다.\n}}")));
          Pause();
        }

        static public void Kill(IMonster monster, List<IItem> dropItemList)
        {
          PrintCText($"{{\n\n  {monster.GivingGold} G,{Colors.txtWarning}}}{{를 획득했습니다.\n}}");
          PrintCText($"{{\n\n  {monster.GivingExp} Exp,{Colors.txtSuccess}}}{{를 획득했습니다.\n}}");
          Pause();
          foreach (var item in dropItemList)
          {
            var iName = CTexts.Make($"{InvenInfo.HavingInven.GetTypeString(item.Type)} 아이템 ,{Colors.txtWarning}}}{{{item.Name},{Colors.txtSuccess}}}");
            PrintCText(CTexts.Make($"{{\n  }}").Combine(iName).Combine($"{{(을)를 획득했습니다.}}"));
          }
          // Pause();
        }

        static public SelectScene SelSkillType(IPlayer player, out SkillType skType)
        {
          Func<CTexts> GetQText = () =>
          {
            return CTexts.Make($"{{무슨 스킬을 사용하시겠습니까?}}");
          };
          Func<SelectSceneItems> GetSSI = () =>
          {
            var resultSSI = new SelectSceneItems();
            for (var i = 0; i < Enum.GetValues(typeof(SkillType)).Length; i++)
              resultSSI.Add($"{{{Skill.Skill.GetTypeString((SkillType)i)} 스킬}}");
            resultSSI.Add($"{{뒤로 가기, {Colors.txtMuted}}}");
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
             return CTexts.Make($"{{무슨 스킬을 사용하시겠습니까? }} {{[ {Skill.Skill.GetTypeString(sType)} 스킬 ],{Colors.txtWarning}}}");
           };
          Func<SkillType, SelectSceneItems> GetSSI = (SkillType sType) =>
          {
            var resultSSI = new SelectSceneItems();
            var skill = from sk in player.Skills
                        where sk.Type == sType
                        select sk;
            foreach (var sk in skill)
              resultSSI.Add($"{{{sk.Name}}}");
            resultSSI.Add($"{{뒤로 가기, {Colors.txtMuted}}}");
            return resultSSI;
          };
          var scene = new SelectScene(GetQText(sType), GetSSI(sType));
          if (scene.getString == "뒤로 가기") return null;
          return scene;
        }
        static public SelectScene SkillAction(ISkill skill)
        {
          Func<ISkill, CTexts> GetQText = (ISkill skill) =>
          {
            return CTexts.Make($"{{{Skill.Skill.GetTypeString(skill.Type)} 스킬,{Colors.txtWarning}}}{{ 「{skill.Name}」}}");
          };
          Func<SelectSceneItems> GetSSI = () =>
          {
            var resultSSI = new SelectSceneItems();
            resultSSI.Add($"{{사용 하기,{Colors.txtSuccess}}}");
            resultSSI.Add($"{{정보 보기,{Colors.txtSuccess}}}");
            resultSSI.Add($"{{뒤로 가기, {Colors.txtMuted}}}");
            return resultSSI;
          };
          var scene = new SelectScene(GetQText(skill), GetSSI());
          if (scene.getString == "뒤로 가기") return null;
          return scene;
        }
      }
    }
  }
}