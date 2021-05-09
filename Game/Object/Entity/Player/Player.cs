using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Map;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Entity.Player
{
  [Serializable]
  class Player : IPlayer
  {
    private int hp;
    private int ep;
    private int exp;
    public string Name { get; set; }
    public Inventory.Inventory Inventory { get; set; }
    public MapList Map { get; set; }
    public int Hp
    {
      get => hp;
      set
      {
        if (MaxHp >= value)
          hp = value;
        else if (MaxHp < value)
          hp = MaxHp;
      }
    }
    public int Ep
    {
      get => ep;
      set
      {
        if (MaxEp >= value)
          ep = value;
        else if (MaxEp < value)
          ep = MaxEp;
      }
    }
    public int MaxHp { get; set; }
    public int MaxEp { get; set; }

    public int Level { get; set; }

    public int Exp
    {
      get => exp;
      set
      {
        if (MaxExp >= value)
          exp = value;
        else if (MaxExp < value)
        {
          Level += 1;
          MaxExp += IncreaseMaxExp;
          PrintText(CTexts.Make($"{{\nLevel UP! Lv. }} {{{Level}\n, {Colors.txtInfo}}}"));
          Pause();
          Exp = value - MaxExp;
        }
      }
    }
    public int MaxExp { get; set; }
    private int increaseMaxExp;
    public int IncreaseMaxExp
    {
      get => increaseMaxExp * (Level / 2);
      set => increaseMaxExp = value;
    }
    public int Gold { get; set; }

    public int AttDmg { get => PAttDmg + ItemDmg; }
    public int PAttDmg { get; set; }
    public int ItemDmg { get; set; }
    public int DefPer { get; set; }
    public object Skill { get; set; }

    public Player()
    {
      Inventory = new Inventory.Inventory(this);
    }

    public Player(string name)
    {
      Name = name;
      Inventory = new Inventory.Inventory(this);
      MaxHp = 50;
      MaxEp = 30;
      Hp = MaxHp;
      Ep = MaxEp;
      Level = 1;
      Exp = 0;
      MaxExp = 20;
      PAttDmg = 4;
      ItemDmg = 4; // e
      DefPer = 0;
      IncreaseMaxExp = 2;
      // InGame.TestInventory(this);
    }
    public void AttackMonster(IMonster moster)
    {

    }


    public void UseSkill()
    {

    }
    public void PrintAbout()
    {
      PrintText(CTexts.Make($"{{\n{Name}, {Colors.txtInfo}}} {{의 정보 =====================}}"));
      PrintText(CTexts.Make($"{{\nLv. : }} {{{Level}, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\nExp : }} {{{Exp} / {MaxExp}, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\nGOLD : }} {{{Gold}, {Colors.txtWarning}}}"));
      PrintText("\n=====================");
      PrintText(CTexts.Make($"{{\nHP : }} {{{Hp} / {MaxHp}, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\nEP : }} {{{Ep} / {MaxEp}, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\nATT : }} {{{AttDmg}, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\nDEF : }} {{{DefPer} %, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\n{Name}, {Colors.txtInfo}}} {{의 정보 =====================}}"));
      Pause();
    }
  }
}