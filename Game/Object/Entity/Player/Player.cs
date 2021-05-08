using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Map;

namespace Goguma.Game.Object.Entity.Player
{
  [Serializable]
  class Player : IPlayer
  {
    public string Name { get; set; }
    public Inventory.Inventory Inventory { get; set; }
    public MapList Map { get; set; }
    public int Hp { get; set; }
    public int Ep { get; set; }
    public int MaxHp { get; set; }
    public int MaxEp { get; set; }

    public int Level { get; }

    public int Exp { get; set; }
    public int Gold { get; set; }

    public int AttDmg { get; }

    public int ItemDmg { get; set; }
    public int DefPer { get; set; }
    public object Skill { get; set; }

    public Player()
    {
      Inventory = new Inventory.Inventory();
    }

    public Player(string name)
    {
      Name = name;
      Inventory = new Inventory.Inventory();
    }
    public void AttackMonster(IMonster moster)
    {

    }

    public void UseConsumedItem()
    {

    }

    public void UseSkill()
    {

    }
  }
}