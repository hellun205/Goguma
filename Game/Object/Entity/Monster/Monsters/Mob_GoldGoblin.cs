using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttackSystem;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;
using Goguma.Game.Object.Skill;
using Goguma.Game.Object.Skill.Skills;

namespace Goguma.Game.Object.Entity.Monster.Monsters
{
  public class MobGoldGoblin : Mob
  {
    public override string Name => "황금 고블린";
    public override MonsterList Material => MonsterList.GoldGoblin;

    public override CTexts Descriptions => CTexts.Make("{황금색 고블린이다. 죽이면 고가의 아이템을 얻을 수 있을지도 모른다.}");

    public override double GivingGold => 1000 + new Random().Next(10, 350);

    public override double GivingExp => 26;

    public override DroppingItems DroppingItems => new(new()
    {
      new(new(ItemList.GoblinsArmor), 30),
      new(new(ItemList.GoldGoblinsSword), 20),
      new(new(ItemList.GoldGoblinCoin), 10),
      new(new(ItemList.Diamond), 6),
      new(new(ItemList.RedDiamond), 2),
      new(new(ItemList.Emerald), 9),
      new(new(ItemList.GoldIngot), 16),
      new(new(ItemList.Potion1), 80),
    });


    public MobGoldGoblin() : base()
    {
      MaxHp = 80;
      Hp = 80;
      PhysicalDamage = 4.7;
      PhysicalDefense = 2;
      Level = 17;

      AttSystem = new()
      {
        Items = new()
        {
          new(this, MSkillList.GoldGoblinSwordSwing, Cond.PlayerHpPer, ">=", 0, 100, 1),
          new(this, MSkillList.GoldGoblinSwordSting, Cond.PlayerHpPer, "<=", 0.5, 10, 1),
          new(this, MSkillList.GoldGoblinSwordSwing, Cond.MonsterHpPer, "<=", 0.5, 1, 0)
        }
      };
    }

  }
}