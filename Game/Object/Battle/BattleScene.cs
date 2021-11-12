using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Skill;
using System.Linq;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;
using System.Collections.Generic;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Entity;
using Goguma.Game.Object.Skill.Buff;
using Goguma.Game.Object.Skill.Attack;

namespace Goguma.Game.Object.Battle
{
  static class BattleScene
  {
    static public class PvE
    {
      static public Entity.Player.Player player = InGame.player;
      static public SelectScene Meet(IMonster monster)
      {
        Func<CTexts> getQText = () =>
        {
          return CTexts.Make($"{{「{monster.Name} [Lv. {monster.Level}]」,{ColorByLevel(player.Level, monster.Level)}}} {{(을)를 만났다! 무엇을 하시겠습니까?}}");
        };
        Func<SelectSceneItems> getSsi = () =>
        {
          var resultSsi = new SelectSceneItems();
          resultSsi.Add($"{{싸우기, {Colors.txtSuccess}}}");
          resultSsi.Add($"{{플레이어 정보 보기}}");
          resultSsi.Add($"{{몬스터 정보 보기}}");
          resultSsi.Add($"{{도망 가기, {Colors.txtDanger}}}");
          return resultSsi;
        };
        return new SelectScene(getQText(), getSsi());
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
        return CTexts.Make($"{{{skill.TypeString} 스킬 , {Colors.txtWarning}}}{{{skill.Name},{Colors.txtInfo}}}");
      }

      static private CTexts MonsterText(IMonster monster)
      {
        return CTexts.Make($"{{「{monster.Name} [Lv. {monster.Level}]」,{ColorByLevel(player.Level, monster.Level)}}}");
      }
      static private CTexts CasterText(IEntity caster)
      {
        return caster.Type == EntityType.PLAYER ? CTexts.Make($"{{당신,{Colors.txtInfo}}}") : MonsterText((IMonster)caster);
      }

      static private CTexts ItemText(IItem item)
      {
        return CTexts.Make($"{{{item.TypeString} 아이템 ,{Colors.txtWarning}}}{{{item.Name},{Colors.txtSuccess}}}");
      }

      static private void UseSkillText(IEntity caster, ISkill skill)
      {

        var ct = CTexts.Make($"{{\n  }}").Combine(CasterText(caster)).Combine("{(이)가 }").Combine(SkillText(skill)).Combine($"{{(을)를 사용했습니다.}}");
        if (caster.Type == EntityType.PLAYER)
          PrintCText(ct.Combine($"{{\n    남은 에너지: }}").Combine(((Player)caster).GetEpBar()).Combine($"{{\n    사용한 에너지: }}{{{skill.UseEp}\n, {Colors.txtWarning}}}"));
        else PrintCText(ct);

        Pause();
        SkillText(caster, skill);
      }

      static public void SkillAttack(IEntity caster, IEntity target, IAttackSkill skill, double damage, bool isCrit = false)
      {


        Func<CTexts> getText = () =>
        {
          var dText = new CTexts();
          if (target.IsDead)
            dText = CTexts.Make($"{{{(isCrit ? "의 치명타 피해를 입고" : "의 피해를 입고")} }}{{죽었습니다,{Colors.txtDanger}}}{{.\n}}");
          else
            dText = CTexts.Make($"{{{(isCrit ? "의 치명타 피해를 입었습니다" : "의 피해를 입었습니다")}.\n    }}").Combine(CasterText(target)).Combine($"{{의 체력: }}").Combine(target.GetHpBar()).Combine($"{{.\n}}");

          return CasterText(target).Combine($"{{(이)가 }}").Combine(CasterText(caster)).Combine($"{{(이)가 사용 한 }}").Combine(SkillText(skill)).Combine($"{{(을)를 맞아 }}{{{Math.Round(damage, 2)},{Colors.txtDanger}}}").Combine(dText);
        };

        UseSkillText(caster, skill);
        PrintCText(getText());
        Pause();
      }

      static public void BuffSkill(IEntity caster, IBuffSkill skill)
      {
        Func<CTexts> getBfEftTxt = () =>
        {
          var resCt = new CTexts();

          Func<string, bool, CTexts> getText = (string str, bool isHeal) =>
            {
              var firstCt = CTexts.Make("{\n  }").Combine(CasterText(caster)).Combine("{의 }");
              var lastCt = isHeal ? CTexts.Make("{만큼 회복했습니다.}") : CTexts.Make("{만큼 증가했습니다.}");
              return firstCt.Combine(CTexts.Make(str)).Combine(lastCt);
            };
          bool isBuff = false;
          resCt.Add("\n");

          if (skill.Effect.Hp != 0)
          {
            isBuff = true;
            resCt.Append(getText($"{{체력을 }}{{{skill.Effect.Hp},{Colors.txtInfo}}}", true));
          }

          if (skill.Effect.Ep != 0 && caster.Type == EntityType.PLAYER)
          {
            isBuff = true;
            resCt.Append(getText($"{{에너지를 }}{{{skill.Effect.Ep},{Colors.txtInfo}}}", true));
          }

          if (skill.Effect.MaxHp != 0)
          {
            isBuff = true;
            resCt.Append(getText($"{{최대 체력이 }}{{{skill.Effect.MaxHp},{Colors.txtWarning}}}", false));
          }

          if (skill.Effect.MaxEp != 0 && caster.Type == EntityType.PLAYER)
          {
            isBuff = true;
            resCt.Append(getText($"{{최대 에너지가 }}{{{skill.Effect.MaxEp},{Colors.txtWarning}}}", false));
          }

          if (skill.Effect.PhysicalDamage != 0)
          {
            isBuff = true;
            resCt.Append(getText($"{{물리 공격력이 }}{{{skill.Effect.PhysicalDamage},{Colors.txtDanger}}}", false));
          }

          if (skill.Effect.MagicDamage != 0)
          {
            isBuff = true;
            resCt.Append(getText($"{{마법 공격력이 }}{{{skill.Effect.MagicDamage},{Colors.txtInfo}}}", false));
          }

          if (skill.Effect.PhysicalPenetration != 0)
          {
            isBuff = true;
            resCt.Append(getText($"{{물리 관통력이 }}{{{skill.Effect.PhysicalPenetration} %,{Colors.txtDanger}}}", false));
          }

          if (skill.Effect.MagicPenetration != 0)
          {
            isBuff = true;
            resCt.Append(getText($"{{마법 관통력이 }}{{{skill.Effect.MagicPenetration} %,{Colors.txtInfo}}}", false));
          }

          if (skill.Effect.PhysicalDefense != 0)
          {
            isBuff = true;
            resCt.Append(getText($"{{물리 방어력이 }}{{{skill.Effect.PhysicalDefense} %,{Colors.txtDanger}}}", false));
          }

          if (skill.Effect.MagicDefense != 0)
          {
            isBuff = true;
            resCt.Append(getText($"{{마법 방어력이 }}{{{skill.Effect.MagicDefense} %,{Colors.txtInfo}}}", false));
          }

          if (skill.Effect.CriticalDamage != 0)
          {
            isBuff = true;
            resCt.Append(getText($"{{치명타 데미지가 }}{{{skill.Effect.CriticalDamage} %,{Colors.txtWarning}}}", false));
          }

          if (skill.Effect.CriticalPercent != 0)
          {
            isBuff = true;
            resCt.Append(getText($"{{치명타 확률이 }}{{{skill.Effect.CriticalPercent} %,{Colors.txtWarning}}}", false));
          }

          if (!isBuff)
            resCt.Append(CTexts.Make("{아무런 효과가 없었습니다.}"));
          resCt.Append(CTexts.Make("{\n}"));
          return resCt;
        };
        UseSkillText(caster, skill);
        PrintCText(getBfEftTxt());
        Pause();
        // PrintBuffEffect();
        // Pause();
      }

      static public void DeleteBuff(IEntity caster, List<IBuffSkill> skill)
      {

        foreach (var sk in skill)
        {
          PrintCText(CTexts.Make("{\n}").Combine(CasterText(caster)).Combine("{의 }").Combine(SkillText(sk)).Combine($"{{의 지속시간이 끝났습니다.}}"));
        }
        PrintText("\n");
        Pause();
      }

      static public void GeneralAttack(IEntity caster, IEntity target, double damage, bool isCrit = false)
      {


        Func<CTexts> getText = () =>
        {
          var dText = new CTexts();
          if (target.IsDead)
            dText = CTexts.Make($"{{{(isCrit ? "의 치명타 피해를 입고" : "의 피해를 입고")} }}{{죽었습니다,{Colors.txtDanger}}}{{.\n}}");
          else
            dText = CTexts.Make($"{{{(isCrit ? "의 치명타 피해를 입혔습니다." : "의 피해를 입혔습니다.")}\n    }}").Combine(CasterText(target)).Combine($"{{의 체력: }}").Combine(target.GetHpBar()).Combine($"{{.\n}}");

          return CasterText(caster).Combine($"{{(이)가 }}").Combine(CasterText(target)).Combine($"{{(을)를 공격해서 }}{{{Math.Round(damage, 2)},{Colors.txtDanger}}}").Combine(dText);
        };
        PrintCText(getText());
        Pause();
      }

      static public class Playerm
      {
        static public void Run()
        {
          PrintCText($"{{\n싸움에서}} {{ 도망,{Colors.txtDanger}}} {{쳤습니다.\n}}");
        }
        static public SelectScene Main(IMonster monster, bool first = false)
        {
          Func<bool, CTexts> getQText = (bool first) =>
           {
             string txt;
             if (first)
               txt = "{(이)랑 싸우기 시작했다! 무엇을 하시겠습니까?\n    }";
             else
               txt = "{(이)랑 싸우고 있다. 무엇을 하시겠습니까?\n    }";
             return MonsterText(monster).Combine($"{txt}").Combine(MonsterText(monster)).Combine("{의 체력: }").Combine(monster.GetHpBar()).Combine("\n");
           };
          Func<SelectSceneItems> getSsi = () =>
            {
              var resultSsi = new SelectSceneItems();
              resultSsi.Add($"{{공격 하기, {Colors.txtSuccess}}}");
              resultSsi.Add($"{{스킬 사용, {Colors.txtSuccess}}}");
              resultSsi.Add($"{{인벤토리 열기}}");
              resultSsi.Add($"{{플레이어 정보 보기}}");
              resultSsi.Add($"{{몬스터 정보 보기}}");
              resultSsi.Add($"{{도망 가기, {Colors.txtDanger}}}");
              return resultSsi;
            };

          return new SelectScene(getQText(first), getSsi());
        }
        static public SelectScene Attack()
        {
          Func<CTexts> getQText = () =>
          {
            return CTexts.Make($"{{어떻게 공격하시겠습니까?}}");
          };
          Func<SelectSceneItems> getSsi = () =>
          {
            var resultSsi = new SelectSceneItems();
            resultSsi.Add($"{{일반 공격,{Colors.txtSuccess}}}");
            resultSsi.Add($"{{스킬 공격,{Colors.txtSuccess}}}");
            return resultSsi;
          };
          return new SelectScene(getQText(), getSsi(), true);
        }

        static public void LackOfEp(ISkill skill)
        {
          PrintCText(CTexts.Make($"{{\n  에너지가 부족하여 }}").Combine(SkillText(skill)).Combine($"{{(을)를 사용 할 수 없습니다.\n    남은 에너지: }}").Combine(player.GetEpBar()).Combine($"{{\n    필요한 에너지: }}{{{skill.UseEp}\n, {Colors.txtWarning}}}"));
          Pause();
        }
        static public void AlreadyUsingBuff(IBuffSkill skill)
        {
          PrintCText(CTexts.Make($"{{\n이미 }}").Combine(SkillText(skill)).Combine(CTexts.Make($"{{의 효과를 받고 있습니다.\n}}")));
          Pause();
        }

        // static public void Kill(IMonster monster, List<IItem> dropItemList)
        // {
        //   PrintCText($"{{\n\n  {monster.GivingGold} G,{Colors.txtWarning}}}{{를 획득했습니다.\n}}");
        //   PrintCText($"{{\n  {monster.GivingExp} Exp,{Colors.txtSuccess}}}{{를 획득했습니다.\n}}");
        //   Pause();
        //   foreach (var item in dropItemList)
        //   {
        //     PrintCText(CTexts.Make($"{{\n\n  }}").Combine(ItemText(item)).Combine($"{{(을)를 획득했습니다.}}"));
        //   }
        //   Pause();
        // }

        static public SelectScene SelSkillType(out SkillType skType)
        {
          Func<CTexts> getQText = () =>
          {
            return CTexts.Make($"{{무슨 스킬을 사용하시겠습니까?}}");
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
          var selIndexSc = SelSkill(skType);
          return selIndexSc;
        }
        static public SelectScene SelSkill(SkillType sType)
        {
          Func<SkillType, CTexts> getQText = (SkillType sType) =>
           {
             return CTexts.Make($"{{무슨 스킬을 사용하시겠습니까? }} {{[ {Skill.Skill.GetTypeString(sType)} 스킬 ],{Colors.txtWarning}}}");
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
        static public SelectScene SkillAction(ISkill skill)
        {
          Func<ISkill, CTexts> getQText = (ISkill skill) =>
          {
            return CTexts.Make($"{{{skill.TypeString} 스킬,{Colors.txtWarning}}}{{ 「{skill.Name}」}}");
          };
          Func<SelectSceneItems> getSsi = () =>
          {
            var resultSsi = new SelectSceneItems();
            resultSsi.Add($"{{사용 하기,{Colors.txtSuccess}}}");
            resultSsi.Add($"{{정보 보기,{Colors.txtSuccess}}}");
            return resultSsi;
          };
          var scene = new SelectScene(getQText(skill), getSsi(), true);
          if (scene.isCancelled) return null;
          return scene;
        }
      }
    }
  }
}