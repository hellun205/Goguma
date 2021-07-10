using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Entity.Monster.Monsters
{
  public class Mob_Goblin : Mob
  {
    public override string Name => "고블린";
    public override MonsterList MType => MonsterList.GOBLIN;

    public override CTexts Descriptions => CTexts.Make("{못생겼다.}");

    public override double GivingGold => 17 + new Random().Next(0, 16);

    public override double GivingExp => 8.4;

    public override DroppingItems DroppingItems => new(new()
    {
      new(ItemList.GOBLINS_SWORD, 35),
      new(ItemList.GOBLINS_ARMOR, 30),
      new(ItemList.POTION_1, 80),
    });

    public override AttackSyss AttSystem => new(this);

    public Mob_Goblin()
    {
      MaxHp = 100;
      Hp = 100;
      AttDmg = 4;
      DefPer = 20;
      Level = 10;
    }

    public override IMonster GetInstance()
    {
      throw new System.NotImplementedException();
    }
  }
}