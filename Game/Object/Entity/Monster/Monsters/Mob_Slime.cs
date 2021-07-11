using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttackSystem;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Entity.Monster.Monsters
{
  public class Mob_Slime : Mob
  {
    public override string Name => "슬라임";
    public override MonsterList Material => MonsterList.SLIME;

    public override CTexts Descriptions => CTexts.Make("{끈적끈적하니 기분이 더럽다.}");

    public override double GivingGold => 10 + new Random().Next(0, 10);

    public override double GivingExp => 7.5;

    public override DroppingItems DroppingItems => new(new()
    {
      new(new(ItemList.STICKY_LIQUID), 70),
      new(new(ItemList.POTION_1), 30)
    });

    public Mob_Slime() : base()
    {
      MaxHp = 5;
      Hp = 5;
      AttDmg = 2;
      DefPer = 0.2;
      Level = 2;

      AttSystem = new()
      {
        Items = new()
        {
          new(this, MSkillList.SLIME_STICKY_ATTACK, Cond.PlayerHpPer, ">=", 0, 100),
          new(this, MSkillList.SLIME_SPOUT_STICKY_LIQUID, Cond.PlayerHpPer, "<=", 0.5, 10),
        }
      };
    }

  }
}