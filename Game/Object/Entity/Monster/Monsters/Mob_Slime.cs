using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttackSystem;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Entity.Monster.Monsters
{
  public class MobSlime : Mob
  {
    public override string Name => "슬라임";
    public override MonsterList Material => MonsterList.SLIME;

    public override CTexts Descriptions => CTexts.Make("{끈적끈적하니 기분이 더럽다.}");

    public override double GivingGold => 10 + new Random().Next(0, 10);

    public override double GivingExp => 7.5;

    public override DroppingItems DroppingItems => new(new()
    {
      new(new(ItemList.STICKY_LIQUID), 70),
      new(new(ItemList.POTION1), 30)
    });

    public MobSlime() : base()
    {
      MaxHp = 5;
      Hp = 5;
      PhysicalDamage = 2;
      PhysicalDefense = 0.2;
      Level = 2;

      AttSystem = new()
      {
        Items = new()
        {
          new(this, MSkillList.SLIME_STICKY_ATTACK, Cond.PLAYER_HP_PER, ">=", 0, 100),
          new(this, MSkillList.SLIME_SPOUT_STICKY_LIQUID, Cond.PLAYER_HP_PER, "<=", 0.5, 10),
        }
      };
    }

  }
}