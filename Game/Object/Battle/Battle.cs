using Goguma.Game.Object.Entity.Monster;
using static Goguma.Game.Console.StringFunction;
using System.Linq;
using Goguma.Game.Object.Skill;
using System.Collections.Generic;
using System;

namespace Goguma.Game.Object.Battle
{
  class Battle
  {
    static public void PvE(IMonster monster)
    {
      var player = InGame.player;
      while (true)
      {
        var scene = BattleScene.PvE.Meet(player, monster);
        switch (scene.getString)
        {
          case "플레이어 정보 보기":
            player.Information();
            break;
          case "몬스터 정보 보기":
            monster.Information();
            break;
          case "싸우기":
            PvEStart(monster);
            return;
          case "도망 가기":
            BattleScene.PvE.Player.Run();
            return;
        }
      }
    }
    static private void PvEStart(IMonster monster)
    {
      var player = InGame.player;
      var first = true;
      var turn = 0;
      var buffs = player.Buffs;
      var buffTurns = new List<int>();
      var mBuffTurns = new List<int>();

      Action Kill = () =>
      {
        var drop = monster.DroppingItems.Drop();
        BattleScene.PvE.Player.Kill(monster, drop);
        player.Gold += GoldByLevel(monster.GivingGold, player.Level, monster.Level);
        player.Exp += ExpByLevel(monster.GivingExp, player.Level, monster.Level);
        foreach (var item in drop)
          player.Inventory.GetItem(item);
      };
      Func<IAttackSkill, bool> UseAttackSkill = (IAttackSkill skill) =>
      {
        if (player.Ep < skill.UseEp)
        {
          BattleScene.PvE.Player.LackOfEP(player, (ISkill)skill);
          return false;
        }
        double damage = Math.Round(DamageByLevel((player.AttDmg + skill.Damage), player.Level, monster.Level) * (1 - ((monster.DefPer / 100) - (skill.IgnoreDef / 100))), 2);
        BattleScene.PvE.Player.SkillAttack(player, monster, skill, damage);
        player.Ep -= skill.UseEp;
        if (monster.Hp - damage <= 0)
          monster.Hp = 0;
        else
          monster.Hp -= damage;
        return true;
      };
      Func<IBuffSkill, bool> UseBuffSkill = (IBuffSkill skill) =>
      {
        if (player.Ep < skill.UseEp)
        {
          BattleScene.PvE.Player.LackOfEP(player, (ISkill)skill);
          return false;
        }
        if (buffs.Contains(skill))
        {
          BattleScene.PvE.Player.AlreadyUsingBuff(skill);
          return false;
        }
        BattleScene.PvE.Player.BuffSkill(player, skill);
        player.Ep -= skill.UseEp;
        player.AddBuff(skill);
        buffTurns.Add(turn);
        return true;
      };
      Func<bool> SelectAttSkill = () =>
      {
        while (true)
        {
          var skSc = BattleScene.PvE.Player.SelSkill(player, SkillType.AttackSkill);
          if (skSc == null) return false;
          var skills = from sk in player.Skills
                       where sk.Type == SkillType.AttackSkill
                       select sk;
          var skill = skills.ToList<ISkill>()[skSc.getIndex];
          while (true)
          {
            var skActSC = BattleScene.PvE.Player.SkillAction(skill);
            if (skActSC == null) break;
            switch (skActSC.getString)
            {
              case "사용 하기":
                return UseAttackSkill((IAttackSkill)skill);
              case "정보 보기":
                skill.Information();
                break;
            }
          }
        }
      };
      Func<bool> UseSkill = () =>
      {
        while (true)
        {
          SkillType skillType;
          var skSc = BattleScene.PvE.Player.SelSkillType(player, out skillType);
          if (skSc == null) return false;
          var skills = from sk in player.Skills
                       where sk.Type == skillType
                       select sk;
          var skill = skills.ToList<ISkill>()[skSc.getIndex];
          while (true)
          {
            var skActSC = BattleScene.PvE.Player.SkillAction(skill);
            if (skActSC == null) break;
            switch (skActSC.getString)
            {
              case "사용 하기":
                switch (skill.Type)
                {
                  case SkillType.AttackSkill:
                    return UseAttackSkill((IAttackSkill)skill);
                  case SkillType.BuffSkill:
                    return UseBuffSkill((IBuffSkill)skill);
                  default:
                    return false;
                }
              case "정보 보기":
                skill.Information();
                break;
            }
          }
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

        BattleScene.PvE.Player.DeleteBuff(endBuffs.ToList<IBuffSkill>());
        foreach (var eBf in endBuffs.ToList<IBuffSkill>())
        {
          buffTurns.RemoveAt(buffs.IndexOf(eBf));
          player.RemoveBuff(eBf);
        }
      };
      Func<bool> GeneralAttack = () =>
      {
        double damage = Math.Round(DamageByLevel(player.AttDmg, player.Level, monster.Level) * (1 - (monster.DefPer / 100)), 2);
        BattleScene.PvE.Player.GeneralAttack(player, monster, damage);

        monster.Hp = Math.Max(0, monster.Hp - damage);

        return true;
      };
      Action<bool> MEndBuff = (bool all) =>
        {
          IEnumerable<IBuffSkill> endBuffs;
          if (!all)
            endBuffs = from bf in monster.Buffs
                       where (bf.buff.turn + mBuffTurns[monster.Buffs.IndexOf(bf)]) == turn
                       select bf;
          else
            endBuffs = from bf in monster.Buffs
                       select bf;

          BattleScene.PvE.Monster.DeleteBuff(monster, player, endBuffs.ToList<IBuffSkill>());
          foreach (var eBf in endBuffs.ToList<IBuffSkill>())
          {
            mBuffTurns.RemoveAt(monster.Buffs.IndexOf(eBf));
            monster.RemoveBuff(eBf);
          }
        };
      Action MonsterTurn = () =>
      {
        ISkill skill = null;
        Action Kill = () =>
        {
          // TO DO: Player Warp Town
        };
        Action GeneralAttack = () =>
        {
          double damage = DamageByLevel(monster.AttDmg, monster.Level, player.Level) * (1 - (player.DefPer / 100));
          BattleScene.PvE.Monster.GeneralAttack(monster, player, damage);
          player.Hp -= damage;
        };
        Func<bool> SkillAttack = () =>
        {
          var aSkill = (IAttackSkill)skill;
          double damage = DamageByLevel((monster.AttDmg + aSkill.Damage), monster.Level, player.Level) * (1 - ((player.DefPer / 100) - (aSkill.IgnoreDef / 100))); // TO DO
          BattleScene.PvE.Monster.SkillAttack(monster, player, aSkill, damage);
          player.Hp -= damage;
          return true;
        };
        Func<bool> BuffSkill = () =>
        {
          var bSkill = (IBuffSkill)skill;
          if (monster.Buffs.Contains(skill)) return false;
          BattleScene.PvE.Monster.BuffSkill(monster, player, bSkill);
          monster.AddBuff(bSkill);
          mBuffTurns.Add(turn);
          return true;
        };

        while (true)
        {
          List<ISkill> sList;
          skill = monster.AttSystem.Get(out sList);
          if (skill != null)
          {
            switch (skill.Type)
            {
              case SkillType.AttackSkill:
                if (SkillAttack()) return;
                break;
              case SkillType.BuffSkill:
                if (BuffSkill()) return;
                else if (sList.Count == 1)
                {
                  GeneralAttack();
                  return;
                }
                break;
            }
          }
          else
          {
            GeneralAttack();
            return;
          }
        }
      };

      while (true)
      {
        var skip = false;
        var scene = BattleScene.PvE.Player.Main(player, monster, first);
        first = false;
        switch (scene.getString)
        {
          case "플레이어 정보 보기":
            player.Information();
            break;
          case "몬스터 정보 보기":
            monster.Information();
            break;
          case "인벤토리 열기":
            skip = player.Inventory.Open();
            break;
          case "공격 하기":
            var attackScene = BattleScene.PvE.Player.Attack();
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
            BattleScene.PvE.Player.Run();
            return;
        }
        if (skip)
        {
          if (monster.Hp == 0)
          {
            Kill();
            EndBuff(true);
            return;
          }
          EndBuff(false);
          MonsterTurn();
          if (player.Hp <= 0)
          {
            EndBuff(true);
            MEndBuff(true);
            return;
          }
          MEndBuff(false);
          turn += 1;
        }
      }
    }


  }
}