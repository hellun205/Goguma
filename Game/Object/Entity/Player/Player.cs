using System;
using System.Collections.Generic;
using System.Text;
using Colorify;
using Gogu_Remaster.Game.Object.Map;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory;
using Goguma.Game.Object.Skill;
using static Goguma.Game.Console.ConsoleFunction;
using Gogu_Remaster.Game.Object.Map.Town;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Entity.Player
{
  [Serializable]
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public Inventory.Inventory Inventory { get; set; }
    public Location Loc { get; set; }
    public double Hp
    {
      get => hp;
      set => hp = Math.Min(value, MaxHp);
    }
    public double Ep
    {
      get => ep;
      set => Math.Min(value, MaxEp);
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
      Loc = new Location(Towns.kks.Name, true);
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

    public Player(string name) : this()
    {
      Name = name;
    }

    public void Heal(double heal)
    {
      Hp = Hp + heal;
    }

    public void PrintAbout()
    {
      PrintText(this.ToString());
      Pause();
    }

    public override string ToString()
    {
      return new StringBuilder($"\n{StringFunction.GetSep(30, $"{Name}")}")
        .Append(CTexts.Make($"{{\nLv. : }} {{{Level}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nExp : }} {{{Exp} / {MaxExp}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nGOLD : }} {{{Gold}, {Colors.txtWarning}}}"))
        .Append(($"\n{StringFunction.GetSep(30)}"))
        .Append(CTexts.Make($"{{\nHP : }} {{{Hp} / {MaxHp}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nEP : }} {{{Ep} / {MaxEp}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nATT : }} {{{AttDmg}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nDEF : }} {{{defPer} %, {Colors.txtWarning}}}"))
        .Append($"\n{StringFunction.GetSep(30)}")
        .Append($"\n위치 : {Loc.Loc}")
        .Append($"\n{StringFunction.GetSep(30)}")
        .ToString();
    }

    public double RequiredForLevelUp()
    {
      return MaxExp - Exp;
    }

    public void AddBuff(IBuffSkill skill)
    {
      Buffs.Add(skill);
      if (skill.buff.Hp != 0)
        Hp += skill.buff.Hp;
      if (skill.buff.Ep != 0)
        Ep += skill.buff.Ep;
    }
    public void RemoveBuff(IBuffSkill skill)
    {
      Buffs.Remove(skill);
    }
  }
}
