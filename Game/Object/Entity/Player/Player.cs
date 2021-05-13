using System;
using System.Collections.Generic;
using System.Text;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Map;
using Goguma.Game.Object.Skill;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Entity.Player
{
  [Serializable]
  class Player : IPlayer
  {
    public string Name { get; set; }
    public Inventory.Inventory Inventory { get; set; }
    public MapList Map { get; set; }
    public double Hp
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
    public double Ep
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
    public double MaxHp { get => maxHp + ItemMaxHp; set => maxHp = value; }
    public double MaxEp { get => maxEp + ItemMaxEp; set => maxEp = value; }

    public int Level { get; set; }

    public double Exp
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
    public double MaxExp { get; set; }

    public double IncreaseMaxExp
    {
      get => IncreaseMul(increaseMaxExp);
      set => increaseMaxExp = value;
    }
    public double IncreaseAttDmg
    {
      get => IncreaseMul(increaseAttDmg);
      set => increaseAttDmg = value;
    }
    // public int IncreaseDefPer
    // {
    //   get => IncreaseMul(increaseDefPer);
    //   set => increaseDefPer = value;
    // }
    public double IncreaseMaxHp
    {
      get => IncreaseMul(increaseMaxHp);
      set => increaseMaxHp = value;
    }
    public double IncreaseMaxEp
    {
      get => IncreaseMul(increaseMaxEp);
      set => increaseMaxEp = value;
    }
    public double Gold { get; set; }

    public double AttDmg
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

    public double DefPer
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
    private double attDmg { get; set; }
    private double defPer { get; set; }

    private double ItemAttDmg { get => Inventory.Items.wearing.ItemsAtt; }
    private double ItemDefPer { get => Inventory.Items.wearing.ItemsDef; }
    private double ItemMaxHp { get => Inventory.Items.wearing.ItemsMaxHp; }
    private double ItemMaxEp { get => Inventory.Items.wearing.ItemsMaxEp; }
    private double increaseMaxExp;
    private double increaseAttDmg;
    // private int increaseDefPer;
    private double increaseMaxHp;
    private double increaseMaxEp;
    private double IncreaseMul(double i) { return i * (Level); }
    private double hp;
    private double ep;
    private double exp;
    private double maxHp;
    private double maxEp;
    public List<ISkill> Skills { get; set; }

    public Player()
    {
      Inventory = new Inventory.Inventory(this);
      Skills = new List<ISkill>();
    }

    public Player(string name)
    {
      Name = name;
      Inventory = new Inventory.Inventory(this);
      Skills = new List<ISkill>();
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

    private string GetSep(int length, string txt = "")
    {
      var sb = new StringBuilder();

      if (txt == "")
      {
        for (var i = 0; i < length; i++) sb.Append("=");
      }
      else if (txt.Length % 2 == 0)
      {
        var l = (length - txt.Length) / 2 - 1;
        for (var i = 0; i < l; i++) sb.Append("=");
        sb.Append($" {txt} ");
        for (var i = 0; i < l; i++) sb.Append("=");
      }
      else
      {
        var l = (length - txt.Length - 1) / 2 - 1;
        for (var i = 0; i < l; i++) sb.Append("=");
        sb.Append($" {txt} ");
        for (var i = 0; i < l + 1; i++) sb.Append("=");
      }

      return sb.ToString();
    }

    public void PrintAbout()
    {
      PrintText(this.ToString());
      Pause();
    }

    public override string ToString()
    {
      return new StringBuilder($"\n{GetSep(30, $"{Name}")}")
        .Append(CTexts.Make($"{{\nLv. : }} {{{Level}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nExp : }} {{{Exp} / {MaxExp}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nGOLD : }} {{{Gold}, {Colors.txtWarning}}}"))
        .Append(($"\n{GetSep(30)}"))
        .Append(CTexts.Make($"{{\nHP : }} {{{Hp} / {MaxHp}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nEP : }} {{{Ep} / {MaxEp}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nATT : }} {{{AttDmg}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nDEF : }} {{{defPer} %, {Colors.txtWarning}}}"))
        .Append($"\n{GetSep(30)}")
        .ToString();
    }

    public double RequiredForLevelUp()
    {
      return MaxExp - Exp;
    }
  }
}
