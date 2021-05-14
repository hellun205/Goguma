using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory.Item;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Entity.Monster
{
  class Monster : IMonster
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
    public AttackSyss AttSystem { get; set; }

    public Monster()
    {
      Skills = new List<Skill.Skill>();
      DroppingItems = new DroppingItems();
      AttSystem = new AttackSyss();
    }
    public void PrintAbout(IPlayer player = null)
    {
      PrintText($"\n{GetSep(40, $"{Name}")}");
      if (player != null) PrintText(CTexts.Make($"{{\nLv. : }} {{{Level}\n, {ColorByLevel(player.Level, Level)}}}"));
      else PrintText(CTexts.Make($"{{\nLv. : }} {{{Level}\n, {Colors.txtWarning}}}"));
      PrintText(Descriptions);
      PrintText($"\n{GetSep(40)}");
      PrintText(CTexts.Make($"{{\nHP : }} {{{Hp} / {MaxHp}, {ColorByHp(Hp, MaxHp)}}}"));
      PrintText(CTexts.Make($"{{\nATT : }} {{{AttDmg}, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\nDEF : }} {{{DefPer} %, {Colors.txtWarning}}}"));
      PrintText($"\n{GetSep(40)}");
      Pause();
    }
  }
}