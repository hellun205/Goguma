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
    public int Hp { get; set; }
    public int MaxHp { get; set; }
    public int Level { get; set; }
    public int AttDmg { get; set; }
    public int DefPer { get; set; }
    public object Skill { get; set; }
    public int GivingGold { get; set; }
    public int GivingExp { get; set; }
    public List<IItem> DroppingItems { get; set; }

    public void AttackPlayer(IPlayer player)
    {

    }

    public void PrintAbout()
    {
      PrintText(CTexts.Make($"{{\n{Name}, {Colors.txtInfo}}} {{의 정보 =====================}}"));
      PrintText(CTexts.Make($"{{\nLv. : }} {{{Level}, {Colors.txtWarning}}} {{\n}}"));
      PrintText(Descriptions);
      PrintText("\n=====================");
      PrintText(CTexts.Make($"{{\nHP : }} {{{Hp} / {MaxHp}, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\nATT : }} {{{AttDmg}, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\nDEF : }} {{{DefPer} %, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\n{Name}, {Colors.txtInfo}}} {{의 정보 =====================}}"));
      Pause();
    }
  }
}