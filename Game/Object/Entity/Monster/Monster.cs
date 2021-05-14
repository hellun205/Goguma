using System.Collections.Generic;
using Colorify;
using Gogu_Remaster.Game.Object.Inventory.Item;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory.Item;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Entity.Monster
{
  public class Monster : IMonster
  {
    public string Name { get; set; }
    public CTexts Descriptions { get; set; }
    public double Hp { get; set; }
    public double MaxHp { get; set; }
    public int Level { get; set; }
    public double AttDmg { get; set; }
    public double DefPer { get; set; }
    public List<Skill.Skill> Skills { get; set; }
    public double GivingGold { get; set; }
    public double GivingExp { get; set; }
    public DroppingItems DroppingItems { get; set; }

    public Monster()
    {
      Skills = new List<Skill.Skill>();
      DroppingItems = new DroppingItems();
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

    public void AttackPlayer(IPlayer player)
    {

    }

    public Monster GetInstace()
    {
      return new Monster(this);
    }

    public void PrintAbout()
    {
      PrintText(CTexts.Make($"{{\n{Name}, {Colors.txtInfo}}} {{의 정보 =====================}}"));
      PrintText(CTexts.Make($"{{\nLv. : }} {{{Level}, {Colors.txtWarning}}} {{\n}}"));
      PrintText(CTexts.Make($"{{\nHP : }} {{{Hp} / {MaxHp}, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\nATT : }} {{{AttDmg}, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\nDEF : }} {{{DefPer} %, {Colors.txtWarning}}}"));
      PrintText("\n=====================\n");
      PrintText(Descriptions);
      PrintText(CTexts.Make($"{{\n{Name}, {Colors.txtInfo}}} {{의 정보 =====================}}"));
      Pause();
    }
  }
}