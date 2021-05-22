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
  public class Player : Entity, IPlayer
  {
    public Inventory.Inventory Inventory { get; set; }
    public Location Loc { get; set; }

    public double Ep
    {
      get => Math.Round(ep, 2);
      set => ep = Math.Min(value, MaxEp);
    }
    public double MaxEp
    {
      get => Math.Round(maxEp + ItemsIncrease.MaxEp + BuffsIncrease.MaxEp, 2);
      set => maxEp = Math.Max(0, value);
    }
    new public double MaxHp
    {
      get => Math.Round(maxHp + ItemsIncrease.MaxHp + BuffsIncrease.MaxHp, 2);
      set => maxHp = Math.Max(0, value);
    }
    new public double AttDmg
    {
      get => Math.Round(attDmg + ItemsIncrease.AttDmg + BuffsIncrease.AttDmg, 2);
      set => attDmg = Math.Max(1, value);
    }
    new public double DefPer
    {
      get => Math.Round(defPer + ItemsIncrease.DefPer + BuffsIncrease.DefPer, 2);
      set => defPer = Math.Max(1, value);
    }

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
          Exp = Math.Max(0, value - MaxExp);
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

    private ItemIncrease ItemsIncrease => Inventory.Items.wearing.Increase;
    private double increaseMaxExp;
    private double increaseAttDmg;
    //private int increaseDefPer;
    private double increaseMaxHp;
    private double increaseMaxEp;
    private double IncreaseMul(double i) { return i * (Level * 0.1); }
    private double ep;
    private double exp;
    private double maxEp;

    public Player() : base()
    {
      Inventory = new Inventory.Inventory(this);
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

    public override void Information()
    {
      PrintText(this.ToString());
      Pause();
    }

    new public void AddBuff(IBuffSkill skill)
    {
      Buffs.Add(skill);
      if (skill.buff.Hp != 0)
        Hp += skill.buff.Hp;
      if (skill.buff.Ep != 0)
        Ep += skill.buff.Ep;
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


  }
}
