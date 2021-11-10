using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttackSystem;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;
using Goguma.Game.Object.Skill;
using Goguma.Game.Object.Skill.Skills;

namespace Goguma.Game.Object.Entity.Monster.Monsters
{
  public class Mob_TestMonster : Mob
  {
    public override string Name => "테스트 몬스터";
    public override MonsterList Material => MonsterList.TEST_MONSTER;

    public override CTexts Descriptions => CTexts.Make("{테스트용으로 사용되는 몬스터이다.}");

    public override double GivingGold => 120 + new Random().Next(0, 100);

    public override double GivingExp => 120;

    public override DroppingItems DroppingItems => new(new()
    {
      new(new(ItemList.TEST_ITEM1), 70),
      new(new(ItemList.TEST_ITEM2), 30)
    });

    public Mob_TestMonster() : base()
    {
      MaxHp = 100;
      Hp = 100;
      PhysicalDamage = 4;
      PhysicalDefense = 20;
      Level = 10;

      AttSystem = new()
      {
        Items = new()
        {
          new(this, MSkillList.TESTMONSTER_TEST_PUNCH, Cond.PlayerHpPer, ">=", 0, 100, 1),
          new(this, MSkillList.TESTMONSTER_TEST_FIREBALL, Cond.PlayerHpPer, ">=", 0, 100, 1),
          new(this, MSkillList.TESTMONSTER_TEST_ATTACK_SKILL, Cond.PlayerHpPer, "<=", 0.5, 50, 1),
          new(this, MSkillList.TESTMONSTER_DEFENSIVE_POSTURE, Cond.MonsterHpPer, "<=", 0.5, 1, 0)
        }
      };
    }

  }
}