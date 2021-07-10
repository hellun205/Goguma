using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;
using Goguma.Game.Object.Skill;
using Goguma.Game.Object.Skill.Skills;

namespace Goguma.Game.Object.Entity.Monster.Monsters
{
  public class Mob_GoldGoblin : Mob
  {
    public override string Name => "황금 고블린";
    public override MonsterList MType => MonsterList.SLIME;

    public override CTexts Descriptions => CTexts.Make("{황금색 고블린이다. 죽이면 고가의 아이템을 얻을 수 있을지도 모른다.}");

    public override double GivingGold => 1000 + new Random().Next(10, 350);

    public override double GivingExp => 26;

    public override DroppingItems DroppingItems => new(new()
    {
      new(ItemList.GOBLINS_ARMOR, 30),
      new(ItemList.GOLD_GOBLINS_SWORD, 20),
      new(ItemList.GOLD_GOBLIN_COIN, 10),
      new(ItemList.DIAMOND, 6),
      new(ItemList.RED_DIAMOND, 2),
      new(ItemList.EMERALD, 9),
      new(ItemList.GOLD_INGOT, 16),
      new(ItemList.POTION_1, 80),
    });

    public override AttackSyss AttSystem => new(this);

    public Mob_GoldGoblin()
    {
      MaxHp = 80;
      Hp = 80;
      AttDmg = 4.7;
      DefPer = 2;
      Level = 17;

      AttSystem.Add(MonsterSkills.GetNew(MSkillList.GOLD_GOBLIN_SWORD_SWING), new AttCondition(Cond.MonsterHpPer, ">=", 0.6));
      AttSystem.Add(MonsterSkills.GetNew(MSkillList.GOLD_GOBLIN_SWORD_STING), new AttCondition(Cond.MonsterHpPer, ">=", 0.6));
      AttSystem.Add(MonsterSkills.GetNew(MSkillList.GOLD_GOBLIN_ANGER), new AttCondition(Cond.MonsterHpPer, "<=", 0.5));
    }

    public override IMonster GetInstance()
    {
      throw new System.NotImplementedException();
    }
  }
}