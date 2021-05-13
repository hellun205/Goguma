using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Entity.Monster;
using static Goguma.Game.Console.ConsoleFunction;
using Colorify;
using System.Linq;
using Goguma.Game.Object.Skill;
using System.Collections.Generic;
using System;

namespace Goguma.Game.Object.Battle
{
  class Battle
  {
    static public void PvE(IPlayer player, IMonster monster)
    {
      while (true)
      {
        var scene = BattleScene.PvE.Meet(player, monster);
        switch (scene.getString)
        {
          case "플레이어 정보 보기":
            player.PrintAbout();
            break;
          case "몬스터 정보 보기":
            monster.PrintAbout();
            break;
          case "싸우기":
            PvEStart(player, monster);
            return;
          case "도망 가기":
            BattleScene.PvE.Run();
            return;
        }
      }
    }
    static private void PvEStart(IPlayer player, IMonster monster)
    {
      var first = true;
      var turn = 0;
      var buffs = player.Buffs;
      var buffTurns = new List<int>();

      Action Kill = () =>
      {
        BattleScene.PvE.Kill(monster);
        player.Gold += GoldByLevel(monster.GivingGold, player.Level, monster.Level);
        player.Exp += ExpByLevel(monster.GivingExp, player.Level, monster.Level);
        foreach (var item in monster.DroppingItems.Drop())
          player.Inventory.GetItem(item);
      };
      Func<IAttackSkill, bool> UseAttackSkill = (IAttackSkill skill) =>
      {
        if (player.Ep < skill.useEp)
        {
          BattleScene.PvE.LackOfEP(player, (ISkill)skill);
          return false;
        }
        double damage = DamageByLevel((player.AttDmg + skill.Damage), player.Level, monster.Level) * (1 - ((monster.DefPer / 100) - skill.IgnoreDef)); // TO DO
        BattleScene.PvE.SkillAttack(player, monster, skill, (int)damage);
        player.Ep -= skill.useEp;
        if (monster.Hp - damage <= 0)
          monster.Hp = 0;
        else
          monster.Hp -= damage;
        return true;
      };
      Func<IBuffSkill, bool> UseBuffSkill = (IBuffSkill skill) =>
      {
        if (player.Ep < skill.useEp)
        {
          BattleScene.PvE.LackOfEP(player, (ISkill)skill);
          return false;
        }
        if (buffs.Contains(skill))
        {
          BattleScene.PvE.AlreadyUsingBuff(skill);
          return false;
        }
        BattleScene.PvE.BuffSkill(player, skill);
        player.Ep -= skill.useEp;
        buffs.Add(skill);
        buffTurns.Add(turn);
        return true;
      };
      Func<bool> SelectAttSkill = () =>
      {
        var skSc = BattleScene.PvE.SelSkill.Scean(player, SkillType.AttackSkill);
        if (skSc == null) return false;
        var skills = from sk in player.Skills
                     where sk.Type == SkillType.AttackSkill
                     select sk;
        var skill = skills.ToList<ISkill>()[skSc.getIndex - 1];
        return UseAttackSkill((AttackSkill)skill);
      };
      Func<bool> UseSkill = () =>
      {
        var skSc = BattleScene.PvE.SelSkill.Scean(player);
        if (skSc == null) return false;
        var skills = from sk in player.Skills
                     where sk.Type == BattleScene.PvE.SelSkill.skType
                     select sk;
        var skill = skills.ToList<ISkill>()[skSc.getIndex - 1];
        switch (skill.Type)
        {
          case SkillType.AttackSkill:
            return UseAttackSkill((AttackSkill)skill);
          case SkillType.BuffSkill:
            return UseBuffSkill((BuffSkill)skill);
          default:
            return false;
        }
      };
      Action<bool> EndBuff = (bool all) =>
      {
        IEnumerable<IBuffSkill> endBuffs;
        if (!all)
          endBuffs = from bf in buffs
                     where (bf.buff.turn + buffTurns[buffs.IndexOf(bf)]) == turn
                     select bf;
        else
          endBuffs = from bf in buffs
                     select bf;

        BattleScene.PvE.DeleteBuff(endBuffs.ToList<IBuffSkill>());
        foreach (var eBf in endBuffs.ToList<IBuffSkill>())
        {
          buffTurns.RemoveAt(buffs.IndexOf(eBf));
          buffs.Remove(eBf);
        }
      };
      Func<bool> GeneralAttack = () =>
      {
        double damage = DamageByLevel(player.AttDmg, player.Level, monster.Level) * (1 - (monster.DefPer / 100));
        BattleScene.PvE.GeneralAttack(player, monster, (int)damage);

        if (monster.Hp - damage <= 0)
        {
          monster.Hp = 0;
          Kill();
        }
        else
        {
          monster.Hp -= damage;
        }
        return true;
      };

      while (true)
      {
        var skip = false;
        var scene = BattleScene.PvE.Main(player, monster, first);
        first = false;
        switch (scene.getString)
        {
          case "플레이어 정보 보기":
            player.PrintAbout();
            break;
          case "몬스터 정보 보기":
            monster.PrintAbout();
            break;
          case "인벤토리 열기":
            skip = player.Inventory.Print();
            break;
          case "공격 하기":
            var attackScene = BattleScene.PvE.Attack();
            switch (attackScene.getString)
            {
              case "일반 공격":
                skip = GeneralAttack();
                break;
              case "스킬 공격":
                skip = SelectAttSkill();
                break;
              case "뒤로 가기":
                break;
            }
            break;
          case "스킬 사용":
            skip = UseSkill();
            break;
          case "도망 가기":
            BattleScene.PvE.Run();
            return;
        }
        if (skip)
        {
          PrintText("SKIP\n");
          if (monster.Hp == 0)
          {
            Kill();
            EndBuff(true);
            return;
          }
          EndBuff(false);
          turn += 1;
          // TO DO
          // Monster Attack to Player
        }
      }
    }

    static public string ColorByHp(double hp, double maxHp)
    {
      if (hp >= (maxHp * 0.6))
        return Colors.txtSuccess;
      else if (hp >= (maxHp * 0.3))
        return Colors.txtWarning;
      else
        return Colors.txtDanger;
    }
    static public string ColorByLevel(int playerLevel, int monsterLevel)
    {
      if (playerLevel < monsterLevel && monsterLevel - playerLevel > 10)
        return Colors.txtDanger;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 10)
        return Colors.txtWarning;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 5 || playerLevel > monsterLevel && playerLevel - monsterLevel <= 5 || playerLevel == monsterLevel)
        return Colors.txtSuccess;
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel <= 10)
        return Colors.txtPrimary;
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel > 10)
        return Colors.txtPrimary;
      else
        return Colors.txtDefault;
    }
    static public double DamageByLevel(double damage, int playerLevel, int monsterLevel)
    {
      if (playerLevel < monsterLevel && monsterLevel - playerLevel > 10)
        return damage * 0.3;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 10)
        return damage * 0.5;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 5 || playerLevel > monsterLevel && playerLevel - monsterLevel <= 5 || playerLevel == monsterLevel)
        return damage * 1;
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel <= 10)
        return damage * 1.5;
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel > 10)
        return damage * 3;
      else
        return damage;
    }
    static public int ExpByLevel(double exp, int playerLevel, int monsterLevel)
    {
      if (playerLevel < monsterLevel && monsterLevel - playerLevel > 10)
        return (int)(exp * 0.2);
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 10)
        return (int)(exp * 0.8);
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 5 || playerLevel > monsterLevel && playerLevel - monsterLevel <= 5 || playerLevel == monsterLevel)
        return (int)(exp * 1);
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel <= 10)
        return (int)(exp * 0.8);
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel > 10)
        return (int)(exp * 0.2);
      else
        return (int)exp;
    }
    static public int GoldByLevel(double gold, int playerLevel, int monsterLevel)
    {
      if (playerLevel < monsterLevel && monsterLevel - playerLevel > 10)
        return (int)(gold * 0.1);
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 10)
        return (int)(gold * 0.9);
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 5 || playerLevel > monsterLevel && playerLevel - monsterLevel <= 5 || playerLevel == monsterLevel)
        return (int)(gold * 1);
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel <= 10)
        return (int)(gold * 0.9);
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel > 10)
        return (int)(gold * 0.1);
      else
        return (int)gold;
    }
  }
}