using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttackSystem;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;

namespace Goguma.Game.Object.Entity.Monster.Monsters
{
  public class MobGoblin : Mob
  {
    public override string Name => "고블린";
    public override MonsterList Material => MonsterList.GOBLIN;

    public override CTexts Descriptions => CTexts.Make("{못생겼다.}");

    public override double GivingGold => 17 + new Random().Next(0, 16);

    public override double GivingExp => 8.4;

    public override DroppingItems DroppingItems => new(new()
    {
      new(new(ItemList.GOBLINS_SWORD), 35),
      new(new(ItemList.GOBLINS_ARMOR), 30),
      new(new(ItemList.POTION1), 80),
    });

    public MobGoblin() : base()
    {
      MaxHp = 7;
      Hp = 7;
      PhysicalDamage = 2.3;
      PhysicalDefense = 0.4;
      Level = 3;
    }

  }
}