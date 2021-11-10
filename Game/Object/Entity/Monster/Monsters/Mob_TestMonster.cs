using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttackSystem;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;
using Goguma.Game.Object.Skill;
using Goguma.Game.Object.Skill.Skills;

namespace Goguma.Game.Object.Entity.Monster.Monsters
{
  public class MobTestMonster : Mob
  {
    public override string Name => "테스트 몬스터";
    public override MonsterList Material => MonsterList.TestMonster;

    public override CTexts Descriptions => CTexts.Make("{테스트용으로 사용되는 몬스터이다.}");

    public override double GivingGold => 120 + new Random().Next(0, 100);

    public override double GivingExp => 120;

    public override DroppingItems DroppingItems => new(new()
    {
      new(new(ItemList.TestItem1), 70),
      new(new(ItemList.TestItem2), 30)
    });

    public MobTestMonster() : base()
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
          new(this, MSkillList.TestmonsterTestPunch, Cond.PlayerHpPer, ">=", 0, 100, 1),
          new(this, MSkillList.TestmonsterTestFireball, Cond.PlayerHpPer, ">=", 0, 100, 1),
          new(this, MSkillList.TestmonsterTestAttackSkill, Cond.PlayerHpPer, "<=", 0.5, 50, 1),
          new(this, MSkillList.TestmonsterDefensivePosture, Cond.MonsterHpPer, "<=", 0.5, 1, 0)
        }
      };
    }

  }
}