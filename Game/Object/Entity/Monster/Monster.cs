using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory.Item;
using static Goguma.Game.Console.ConsoleFunction;

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

    public Monster()
    {
      Skills = new List<Skill.Skill>();
      DroppingItems = new DroppingItems();
    }
    public void AttackPlayer(IPlayer player)
    {

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