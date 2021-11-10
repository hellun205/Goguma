using Goguma.Game.Object.Entity.Monster;
using static Goguma.Game.Console.StringFunction;
using System.Linq;
using Goguma.Game.Object.Skill;
using System.Collections.Generic;
using System;
using Goguma.Game.Object.Skill.Attack;
using Goguma.Game.Object.Skill.Buff;

namespace Goguma.Game.Object.Battle
{
  public static class Battle
  {
    public static void PvE(IMonster monster)
    {
      var player = InGame.player;
      while (true)
      {
        var scene = BattleScene.PvE.Meet(monster);
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
            BattleScene.PvE.Playerm.Run();
            return;
        }
      }
    }
    private static void PvEStart(IMonster monster)
    {
      var player = InGame.player;
      var first = true;
      var turn = 0;
      var buffs = player.Buffs;
      var buffTurns = new List<int>();
      var mBuffTurns = new List<int>();

      Action kill = () =>
      {
        var drop = monster.DroppingItems.Drop();
        // BattleScene.PvE.Player.Kill(monster, drop);

        player.ReceiveGold(GoldByLevel(monster.GivingGold, player.Level, monster.Level));
        player.ReceiveExp(ExpByLevel(monster.GivingExp, player.Level, monster.Level));
        player.ReceiveItems(drop.ToArray());

        player.KillMob(monster.Material);
      };
      Func<IAttackSkill, bool> useAttackSkill = (IAttackSkill skill) =>
      {
        if (player.Ep < skill.UseEp)
        {
          BattleScene.PvE.Playerm.LackOfEp((ISkill)skill);
          return false;
        }
        bool isCrit;
        double damage = player.CalAttDmg(skill, monster, out isCrit);
        player.Ep -= skill.UseEp;
        if (monster.Hp - damage <= 0)
          monster.Hp = 0;
        else
          monster.Hp -= damage;

        BattleScene.PvE.SkillAttack(player, monster, skill, damage, isCrit);
        return true;
      };
      Func<IBuffSkill, bool> useBuffSkill = (IBuffSkill skill) =>
      {
        if (player.Ep < skill.UseEp)
        {
          BattleScene.PvE.Playerm.LackOfEp((ISkill)skill);
          return false;
        }
        if (buffs.Contains(skill))
        {
          BattleScene.PvE.Playerm.AlreadyUsingBuff(skill);
          return false;
        }
        player.Ep -= skill.UseEp;
        BattleScene.PvE.BuffSkill(player, skill);
        player.AddBuff(skill);
        buffTurns.Add(turn);
        return true;
      };
      Func<bool> selectAttSkill = () =>
      {
        while (true)
        {
          var skSc = BattleScene.PvE.Playerm.SelSkill(SkillType.AttackSkill);
          if (skSc == null) return false;
          var skills = from sk in player.Skills
                       where sk.Type == SkillType.AttackSkill
                       select sk;
          var skill = skills.ToList<ISkill>()[skSc.getIndex];
          while (true)
          {
            var skActSc = BattleScene.PvE.Playerm.SkillAction(skill);
            if (skActSc == null) break;
            switch (skActSc.getString)
            {
              case "사용 하기":
                return useAttackSkill((IAttackSkill)skill);
              case "정보 보기":
                skill.Information();
                break;
            }
          }
        }
      };
      Func<bool> useSkill = () =>
      {
        while (true)
        {
          SkillType skillType;
          var skSc = BattleScene.PvE.Playerm.SelSkillType(out skillType);
          if (skSc == null) return false;
          var skills = from sk in player.Skills
                       where sk.Type == skillType
                       select sk;
          var skill = skills.ToList<ISkill>()[skSc.getIndex];
          while (true)
          {
            var skActSc = BattleScene.PvE.Playerm.SkillAction(skill);
            if (skActSc == null) break;
            switch (skActSc.getString)
            {
              case "사용 하기":
                switch (skill.Type)
                {
                  case SkillType.AttackSkill:
                    return useAttackSkill((IAttackSkill)skill);
                  case SkillType.BuffSkill:
                    return useBuffSkill((IBuffSkill)skill);
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
      Action<bool> endBuff = (bool all) =>
      {
        IEnumerable<IBuffSkill> endBuffs;
        if (buffs.Count == 0) return;
        if (!all)
          endBuffs = from bf in buffs
                     where (bf.Effect.Turn + buffTurns[buffs.IndexOf(bf)]) == turn
                     select bf;
        else
          endBuffs = from bf in buffs
                     select bf;

        BattleScene.PvE.DeleteBuff(player, endBuffs.ToList<IBuffSkill>());
        foreach (var eBf in endBuffs.ToList<IBuffSkill>())
        {
          buffTurns.RemoveAt(buffs.IndexOf(eBf));
          player.RemoveBuff(eBf);
        }
      };
      Func<bool> generalAttack = () =>
      {
        bool isCrit;
        double damage = player.CalAttDmg(monster, out isCrit);
        monster.Hp = Math.Max(0, monster.Hp - damage);

        BattleScene.PvE.GeneralAttack(player, monster, damage, isCrit);
        return true;
      };
      Action<bool> mEndBuff = (bool all) =>
        {
          IEnumerable<IBuffSkill> endBuffs;
          if (!all)
            endBuffs = from bf in monster.Buffs
                       where (bf.Effect.Turn + mBuffTurns[monster.Buffs.IndexOf(bf)]) == turn
                       select bf;
          else
            endBuffs = from bf in monster.Buffs
                       select bf;

          BattleScene.PvE.DeleteBuff(monster, endBuffs.ToList<IBuffSkill>());
          foreach (var eBf in endBuffs.ToList<IBuffSkill>())
          {
            mBuffTurns.RemoveAt(monster.Buffs.IndexOf(eBf));
            monster.RemoveBuff(eBf);
          }
        };
      Action monsterTurn = () =>
      {
        ISkill skill = null;
        Action kill = () =>
        {
          // TO DO: Player Warp Town
        };
        Action generalAttack = () =>
        {
          bool isCrit;
          double damage = monster.CalAttDmg(player, out isCrit);
          player.Hp -= damage;

          BattleScene.PvE.GeneralAttack(monster, player, damage, isCrit);
        };
        Func<bool> skillAttack = () =>
        {
          var aSkill = (IAttackSkill)skill;
          bool isCrit;
          double damage = monster.CalAttDmg(aSkill, player, out isCrit);
          player.Hp -= damage;

          BattleScene.PvE.SkillAttack(monster, player, aSkill, damage, isCrit);
          return true;
        };
        Func<bool> buffSkill = () =>
        {
          var bSkill = (IBuffSkill)skill;
          if (monster.Buffs.Contains(skill)) return false;
          BattleScene.PvE.BuffSkill(monster, bSkill);
          monster.AddBuff(bSkill);
          mBuffTurns.Add(turn);
          return true;
        };

        while (true)
        {
          skill = monster.AttSystem.Exe();
          if (skill != null)
          {
            switch (skill.Type)
            {
              case SkillType.AttackSkill:
                if (skillAttack()) return;
                break;
              case SkillType.BuffSkill:
                if (buffSkill()) return;
                break;
            }
          }
          else
          {
            generalAttack();
            return;
          }
        }
      };

      while (true)
      {
        var skip = false;
        var scene = BattleScene.PvE.Playerm.Main(monster, first);
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
            var attackScene = BattleScene.PvE.Playerm.Attack();
            switch (attackScene.getString)
            {
              case "일반 공격":
                skip = generalAttack();
                break;
              case "스킬 공격":
                skip = selectAttSkill();
                break;
            }
            break;
          case "스킬 사용":
            skip = useSkill();
            break;
          case "도망 가기":
            BattleScene.PvE.Playerm.Run();
            return;
        }
        if (skip)
        {
          if (monster.Hp == 0)
          {
            kill();
            endBuff(true);
            return;
          }
          endBuff(false);
          monsterTurn();
          if (player.Hp <= 0)
          {
            endBuff(true);
            mEndBuff(true);
            return;
          }
          mEndBuff(false);
          turn += 1;
        }
      }
    }


  }
}