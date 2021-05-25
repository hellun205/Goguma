using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Inventory.Item.Drop;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Entity.Monster
{
  public class Monster : Entity, IMonster
  {
    public override EntityType Type => EntityType.MONSTER;
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
      PrintText($"{{\n{GetSep(40, $"{Name}")}}}");
      PrintText("\n");
      PrintCText(Descriptions);
      PrintText($"{{\n{GetSep(40)}}}");
      if (player != null) PrintText($"{{\nLv. : }} {{{Level}, {ColorByLevel(player.Level, Level)}}}");
      else PrintText($"{{\nLv. : }} {{{Level}, {Colors.txtWarning}}}");
      PrintText($"{{\nHP : }} {{[{Hp} / {MaxHp}], {ColorByHp(Hp, MaxHp)}}}");
      PrintText($"{{\nATT : }} {{{AttDmg}, {Colors.txtWarning}}}");
      PrintText($"{{\nDEF : }} {{{DefPer} %, {Colors.txtWarning}}}");
      PrintText($"{{\n{GetSep(40)}}}");
      Pause();
    }

    public Monster GetInstance()
    {
      return new Monster(this);
    }
  }
}
