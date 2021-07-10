using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;
using Goguma.Game.Object.Skill;
using Goguma.Game.Object.Skill.Skills;

namespace Goguma.Game.Object.Entity.Monster.Monsters
{
  public class Mob_TestMonster : Mob
  {
    public override string Name => "테스트 몬스터";
    public override MonsterList MType => MonsterList.TEST_MONSTER;

    public override CTexts Descriptions => CTexts.Make("{테스트용으로 사용되는 몬스터이다.}");

    public override double GivingGold => 120 + new Random().Next(0, 100);

    public override double GivingExp => 120;

    public override DroppingItems DroppingItems => new(new()
    {
      new(ItemList.TEST_ITEM1, 70),
      new(ItemList.TEST_ITEM2, 30)
    });

    public override AttackSyss AttSystem => new(this);

    public Mob_TestMonster()
    {
      MaxHp = 100;
      Hp = 100;
      AttDmg = 4;
      DefPer = 20;
      Level = 10;


      AttSystem.Add(MonsterSkills.GetNew(MSkillList.TestMonster_TestPunch), new AttCondition(Cond.MonsterHpPer, ">=", 0.7));
      AttSystem.Add(MonsterSkills.GetNew(MSkillList.TestMonster_TestFireBall), new AttCondition(Cond.PlayerHpPer, "<=", 0.3));
      AttSystem.Add(MonsterSkills.GetNew(MSkillList.TestMonster_TestAttackSkill), new AttCondition(Cond.MonsterHpPer, ">=", 0.7));
      AttSystem.Add(MonsterSkills.GetNew(MSkillList.TestMonster_DefensivePosture), new AttCondition(Cond.MonsterHpPer, "<=", 0.4));
    }

    public override IMonster GetInstance()
    {
      throw new System.NotImplementedException();
    }
  }
}