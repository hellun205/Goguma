using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Inventory.Item.Drop;
using Goguma.Game.Object.Skill;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Entity.Monster
{
  public class Monster : Entity, IMonster
  {
    public CTexts Descriptions { get; set; }
    public double GivingGold { get; set; }
    public double GivingExp { get; set; }
    public DroppingItems DroppingItems { get; set; }
    public AttackSyss AttSystem { get; set; }

    public Monster() : base()
    {
      DroppingItems = new DroppingItems();
      AttSystem = new AttackSyss(InGame.player, this);
    }
    public Monster(Monster monster) : this()
    {
      Name = monster.Name;
      Descriptions = monster.Descriptions;
      Level = monster.Level;
      MaxHp = monster.MaxHp;
      Hp = monster.Hp;
      AttDmg = monster.AttDmg;
      DefPer = monster.DefPer;
      GivingExp = monster.GivingExp;
      GivingGold = monster.GivingGold;

      var dropItem = new List<DroppingItem>();

      foreach (var i in monster.DroppingItems.Items)
      {
        var di = new DroppingItem(i.Item.GetInstance(), i.DropChance);
        dropItem.Add(di);
      }

      DroppingItems = new DroppingItems(dropItem);
    }
    public override void Information()
    {
      var player = InGame.player;
      PrintText($"\n{GetSep(40, $"{Name}")}");
      PrintText("\n");
      PrintText(Descriptions);
      PrintText($"\n{GetSep(40)}");
      if (player != null) PrintText(CTexts.Make($"{{\nLv. : }} {{{Level}, {ColorByLevel(player.Level, Level)}}}"));
      else PrintText(CTexts.Make($"{{\nLv. : }} {{{Level}, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\nHP : }} {{[{Hp} / {MaxHp}], {ColorByHp(Hp, MaxHp)}}}"));
      PrintText(CTexts.Make($"{{\nATT : }} {{{AttDmg}, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\nDEF : }} {{{DefPer} %, {Colors.txtWarning}}}"));
      PrintText($"\n{GetSep(40)}");
      Pause();
    }

    public Monster GetInstance()
    {
      return new Monster(this);
    }
  }
}
