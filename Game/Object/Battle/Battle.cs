using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Entity.Monster;
using static Goguma.Game.Console.ConsoleFunction;
using Colorify;
using System.Linq;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Battle
{
  class Battle
  {
    static public void PvE(IPlayer player, IMonster monster)
    {
      while (true)
      {
        var scene = BattleScene.PvE.Meet.Scean(player, monster);
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
      while (true)
      {
        var skip = false;
        var scene = BattleScene.PvE.Main.Scean(player, monster, first);
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
            var attackScene = BattleScene.PvE.Attack.Scean();
            switch (attackScene.getString)
            {
              case "공격 하기":
                skip = GeneralAttack(player, monster);
                if (monster.Hp == 0) return;
                break;
              case "스킬 사용":
                skip = UseSkill(player, monster);
                if (monster.Hp == 0) return;
                break;
              case "뒤로 가기":
                break;
            }
            break;
          case "도망 가기":
            BattleScene.PvE.Run();
            return;
        }
        if (skip)
        {
          PrintText("SKIP\n");
          // TO DO
          // Monster Attack to Player
        }
      }
    }
    static private bool GeneralAttack(IPlayer player, IMonster monster)
    {
      double damage = DamageByLevel(player.AttDmg, player.Level, monster.Level) * (1 - (monster.DefPer / 100));
      BattleScene.PvE.GeneralAttack.Scean(player, monster, (int)damage);

      if (monster.Hp - damage <= 0)
      {
        monster.Hp = 0;
        Kill(player, monster);
      }
      else
      {
        monster.Hp -= damage;
      }
      return true;
    }
    static private bool UseSkill(IPlayer player, IMonster monster)
    {
      var skillTypeSc = BattleScene.PvE.SelSkill.Scean();
      SkillType skillType;
      if (skillTypeSc.getString == "뒤로 가기") return false;
      else skillType = (SkillType)(skillTypeSc.getIndex - 1);
      var skills = from sk in player.Skills
                   where sk.Type == skillType
                   select sk;

      var selIndexSc = BattleScene.PvE.SelSkill.Scean(player, skillType);
      int selIndex;
      if (selIndexSc.getString == "뒤로 가기") return false;
      else selIndex = selIndexSc.getIndex - 1;
      var skill = skills.ToList<ISkill>()[selIndex];

      switch (skill.Type)
      {
        case SkillType.AttackSkill:
          return SkillAttack(player, monster, (AttackSkill)skill);
        default:
          return false;
      }
    }
    static private bool SkillAttack(IPlayer player, IMonster monster, IAttackSkill skill)
    {
      double damage = DamageByLevel((player.AttDmg + skill.Damage), player.Level, monster.Level) * (1 - ((monster.DefPer / 100) - skill.IgnoreDef)); // TO DO
      BattleScene.PvE.SkillAttack.Scean(player, monster, skill, (int)damage);

      if (monster.Hp - damage <= 0)
      {
        monster.Hp = 0;
        Kill(player, monster);
        return true;
      }
      else
      {
        monster.Hp -= damage;
        return false;
      }
    }
    static private void Kill(IPlayer player, IMonster monster)
    {
      BattleScene.PvE.Kill.Scene(monster);
      player.Gold += GoldByLevel(monster.GivingGold, player.Level, monster.Level);
      player.Exp += ExpByLevel(monster.GivingExp, player.Level, monster.Level);
      foreach (var item in monster.DroppingItems.Items)
        player.Inventory.GetItem(item.Item);
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