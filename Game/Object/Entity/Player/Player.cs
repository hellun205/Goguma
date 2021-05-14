using System;
using System.Collections.Generic;
using System.Text;
using Colorify;
using Gogu_Remaster.Game.Object.Map;
using Goguma.Game.Console;
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
    public Location Loc { get; }
    public double Hp
    {
      get => hp;
      set
      {
        hp = Math.Min(value, MaxHp);
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
    public double MaxHp
    {
      get => maxHp + ItemsIncrease.MaxHp + BuffsIncrease.MaxHp;
      set => maxHp = value;
    }
    public double MaxEp
    {
      get => maxEp + ItemsIncrease.MaxEp + BuffsIncrease.MaxEp;
      set => maxEp = value;
    }

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
          MaxExp += IncreaseMaxExp;
          PrintText(CTexts.Make($"{{\nLevel UP! Lv. }} {{{Level}\n, {Colors.txtInfo}}}"));
          Exp = value - MaxExp;
          Pause();
        }
      }
    }
    public bool IsDead
    {
      get => Hp <= 0;
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
      get => attDmg + ItemsIncrease.AttDmg + BuffsIncrease.AttDmg;
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
      get => defPer + ItemsIncrease.DefPer + BuffsIncrease.DefPer;
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

    private ItemIncrease ItemsIncrease { get => Inventory.Items.wearing.Increase; }
    private Buff BuffsIncrease
    {
      get
      {
        var resultBuff = new Buff();
        foreach (var bf in Buffs)
        {
          resultBuff.MaxHp += bf.buff.MaxHp;
          resultBuff.MaxEp += bf.buff.MaxEp;
          resultBuff.AttDmg += bf.buff.AttDmg;
          resultBuff.DefPer += bf.buff.DefPer;
        }
        return resultBuff;
      }
    }
    private double increaseMaxExp;
    private double increaseAttDmg;
    //private int increaseDefPer;
    private double increaseMaxHp;
    private double increaseMaxEp;
    private double IncreaseMul(double i) { return i * (Level * 0.1); }
    private double hp;
    private double ep;
    private double exp;
    private double maxHp;
    private double maxEp;
    public List<ISkill> Skills { get; set; }
    public List<IBuffSkill> Buffs { get; set; }

    public Player()
    {
      Inventory = new Inventory.Inventory(this);
      Skills = new List<ISkill>();
      Buffs = new List<IBuffSkill>();
    }

    public Player(string name)
    {
      Name = name;
      Inventory = new Inventory.Inventory(this);
      Skills = new List<ISkill>();
      Buffs = new List<IBuffSkill>();
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

    public void Heal(double heal)
    {
      Hp = Hp + heal;
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
