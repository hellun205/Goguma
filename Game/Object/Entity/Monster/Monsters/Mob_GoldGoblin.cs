using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttackSystem;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;
using Goguma.Game.Object.Skill;
using Goguma.Game.Object.Skill.Skills;

namespace Goguma.Game.Object.Entity.Monster.Monsters
{
  public class Mob_GoldGoblin : Mob
  {
    public override string Name => "황금 고블린";
    public override MonsterList Material => MonsterList.GOLD_GOBLIN;

    public override CTexts Descriptions => CTexts.Make("{황금색 고블린이다. 죽이면 고가의 아이템을 얻을 수 있을지도 모른다.}");

    public override double GivingGold => 1000 + new Random().Next(10, 350);

    public override double GivingExp => 26;

    public override DroppingItems DroppingItems => new(new()
    {
      new(new(ItemList.GOBLINS_ARMOR), 30),
      new(new(ItemList.GOLD_GOBLINS_SWORD), 20),
      new(new(ItemList.GOLD_GOBLIN_COIN), 10),
      new(new(ItemList.DIAMOND), 6),
      new(new(ItemList.RED_DIAMOND), 2),
      new(new(ItemList.EMERALD), 9),
      new(new(ItemList.GOLD_INGOT), 16),
      new(new(ItemList.POTION_1), 80),
    });


    public Mob_GoldGoblin() : base()
    {
      MaxHp = 80;
      Hp = 80;
      AttDmg = 4.7;
      DefPer = 2;
      Level = 17;

      AttSystem = new()
      {
        Items = new()
        {
          new(this, MSkillList.GOLD_GOBLIN_SWORD_SWING, Cond.PlayerHpPer, ">=", 0, 100, 1),
          new(this, MSkillList.GOLD_GOBLIN_SWORD_STING, Cond.PlayerHpPer, "<=", 0.5, 10, 1),
          new(this, MSkillList.GOLD_GOBLIN_SWORD_SWING, Cond.MonsterHpPer, "<=", 0.5, 1, 0)
        }
      };
    }

  }
}