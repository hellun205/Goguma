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
    public int MaxHp { get => maxHp + ItemMaxHp; set => maxHp = value; }
    public int MaxEp { get => maxEp + ItemMaxEp; set => maxEp = value; }

    public int Level { get; set; }

    public int Exp
    {
      get => exp;
      set
      {
        if (MaxExp > value)
          exp = value;
        else if (MaxExp <= value)
        {
          Level += 1; // Level Up
          AttDmg += IncreaseAttDmg;
          MaxHp += IncreaseMaxHp;
          MaxEp += IncreaseMaxEp;
          Hp = MaxHp;
          Ep = MaxEp;
          Exp = value - MaxExp;
          MaxExp += IncreaseMaxExp;
          PrintText(CTexts.Make($"{{\nLevel UP! Lv. }} {{{Level}\n, {Colors.txtInfo}}}"));
          Pause();
          PrintAbout();
        }
      }
    }
    public int MaxExp { get; set; }

    public int IncreaseMaxExp
    {
      get => IncreaseMul(increaseMaxExp);
      set => increaseMaxExp = value;
    }
    public int IncreaseAttDmg
    {
      get => IncreaseMul(increaseAttDmg);
      set => increaseAttDmg = value;
    }
    // public int IncreaseDefPer
    // {
    //   get => IncreaseMul(increaseDefPer);
    //   set => increaseDefPer = value;
    // }
    public int IncreaseMaxHp
    {
      get => IncreaseMul(increaseMaxHp);
      set => increaseMaxHp = value;
    }
    public int IncreaseMaxEp
    {
      get => IncreaseMul(increaseMaxEp);
      set => increaseMaxEp = value;
    }
    public int Gold { get; set; }

    public int AttDmg
    {
      get => attDmg + ItemAttDmg;
      set
      {
        if (value > 0)
          attDmg = value;
        else
          attDmg = 0;
      }
    }

    public int DefPer
    {
      get => defPer + ItemDefPer;
      set
      {
        if (value > 0)
          defPer = value;
        else
          defPer = 0;
      }
    }
    private int attDmg { get; set; }
    private int defPer { get; set; }

    private int ItemAttDmg { get => Inventory.Equipment.ItemsAtt; }
    private int ItemDefPer { get => Inventory.Equipment.ItemsDef; }
    private int ItemMaxHp { get => Inventory.Equipment.ItemsMaxHp; }
    private int ItemMaxEp { get => Inventory.Equipment.ItemsMaxEp; }
    private int increaseMaxExp;
    private int increaseAttDmg;
    // private int increaseDefPer;
    private int increaseMaxHp;
    private int increaseMaxEp;
    private int IncreaseMul(int i) { return i * (Level); }
    private int hp;
    private int ep;
    private int exp;
    private int maxHp;
    private int maxEp;
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
      MaxExp = 20;
      Exp = 0;
      attDmg = 4;
      defPer = 0;
      IncreaseMaxExp = 2;
      IncreaseAttDmg = 2;
      IncreaseMaxHp = 10;
      IncreaseMaxEp = 5;
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
      PrintText(CTexts.Make($"{{\nDEF : }} {{{defPer} %, {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\n{Name}, {Colors.txtInfo}}} {{의 정보 =====================}}"));
      Pause();
    }

    public int RequiredForLevelUp()
    {
      return MaxExp - Exp;
    }
  }
}