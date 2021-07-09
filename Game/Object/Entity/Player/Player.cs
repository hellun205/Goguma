using System;
using Colorify;
using Goguma.Game.Object.Map;
using Goguma.Game.Console;
using Goguma.Game.Object.Skill;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;
using Goguma.Game.Object.Map.Town;
using Goguma.Game.Object.Inventory.Item.Equipment;
using Goguma.Game.Object.Quest;
using System.Collections.Generic;

namespace Goguma.Game.Object.Entity.Player
{
  [Serializable]
  public class Player : Entity, IPlayer
  {
    public override EntityType Type => EntityType.PLAYER;
    public Inventory.Inventory Inventory { get; set; }
    public QuestSys Quest { get; set; }
    public List<QuestList> CompletedQuests { get; set; }
    public Location Loc { get; set; }

    public double Ep
    {
      get => Math.Round(ep, 2);
      set => ep = Math.Min(value, MaxEp);
    }
    public double MaxEp
    {
      get => Math.Round(maxEp + GetEquipEffect.MaxEp + BuffsIncrease.MaxEp, 2);
      set => maxEp = Math.Max(0, value);
    }
    new public double MaxHp
    {
      get => Math.Round(maxHp + GetEquipEffect.MaxHp + BuffsIncrease.MaxHp, 2);
      set => maxHp = Math.Max(0, value);
    }
    new public double DefPer
    {
      get => Math.Round(defPer + GetEquipEffect.DefPer + BuffsIncrease.DefPer, 2);
      set => defPer = Math.Max(0, value);
    }
    new public double AttDmg
    {
      get => Math.Round(attDmg + GetWeaponEffect.AttDmg + BuffsIncrease.AttDmg, 2);
      set => attDmg = Math.Max(0, value);
    }
    new public double CritDmg
    {
      get => Math.Round(critDmg + GetWeaponEffect.CritDmg + BuffsIncrease.CritDmg, 2);
      set => critDmg = Math.Max(0, value);
    }
    new public double CritPer
    {
      get => Math.Round(critPer + GetWeaponEffect.CritPer + BuffsIncrease.CritPer, 2);
      set => critPer = Math.Max(0, value);
    }
    new public double IgnoreDef
    {
      get => Math.Round(ignoreDef + GetWeaponEffect.IgnoreDef + BuffsIncrease.IgnoreDef, 2);
      set => ignoreDef = Math.Max(0, value);
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
          PrintCText($"{{\nLevel UP! Lv. }} {{{Level}\n, {Colors.txtInfo}}}");
          Exp = Math.Max(0, value - MaxExp);
          Pause();
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

    private EquipEffect GetEquipEffect => Inventory.Items.wearing.GetEquipEffect;
    private WeaponEffect GetWeaponEffect => Inventory.Items.wearing.GetWeaponEffect;
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
      Quest = new();
      CompletedQuests = new();
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

    new public void AddBuff(IBuffSkill skill)
    {
      Buffs.Add(skill);
      if (skill.buff.Hp != 0)
        Hp += skill.buff.Hp;
      if (skill.buff.Ep != 0)
        Ep += skill.buff.Ep;
    }

    new public void Information()
    {
      PrintCText(Info());
      Pause();
    }

    new protected CTexts Info()
    {
      return new CTexts()
      .Append($"{{\n{GetSep(40, $"{Name} [ Lv. {Level} ]")}}}")
      .Append("{\n경험치 : }")
      .Append(GetExpBar())
      .Append($"{{\n골드 : }}{{{Gold} G,{Colors.txtWarning}}}")
      .Append($"{{\n위치 : }}{{{Loc.Loc},{Colors.txtInfo}}}")
      .Append($"{{\n{GetSep(40)}}}")
      .Append("{\n체력 : }")
      .Append(GetHpBar())
      .Append("{\n에너지 : }")
      .Append(GetEpBar())
      .Append($"{{\n공격력 : }}{{{AttDmg},{Colors.txtDanger}}}")
      .Append($"{{\n크리티컬 데미지 : }}{{{CritDmg} %,{Colors.txtDanger}}}")
      .Append($"{{\n크리티컬 확률 : }}{{{CritPer} %,{Colors.txtDanger}}}")
      .Append($"{{\n방어율 무시 : }}{{{IgnoreDef} %,{Colors.txtDanger}}}")
      .Append($"{{\n방어율 : }}{{{DefPer} %,{Colors.txtInfo}}}")
      .Append($"{{\n{GetSep(40)}}}");
    }

    public double RequiredForLevelUp()
    {
      return MaxExp - Exp;
    }

    public override string ToString()
    {
      return base.ToString();
    }

    public CTexts GetEpBar(bool withPercentage = true, double plus = 0)
    {
      var bar = GetPerStr(Ep + plus, MaxEp, ColorByHp(Ep + plus, MaxEp));
      if (withPercentage)
        return bar.Combine(CTexts.Make($"{{ [ }}{{{Ep + plus} / {MaxEp},{ColorByHp(Ep + plus, MaxEp)}}}{{ ]}}"));
      else
        return bar;
    }

    public CTexts GetExpBar(bool withPercentage = true, double plus = 0)
    {
      var bar = GetPerStr(Exp + plus, MaxExp);
      if (withPercentage)
        return bar.Combine(CTexts.Make($"{{ [ }}{{{Exp + plus} / {MaxExp},{Colors.txtWarning}}}{{ ]}}"));
      else
        return bar;
    }

    new public double CalAttDmg(IAttackSkill aSkill, IEntity entity, out bool isCrit)
    {
      var dmg = DamageByLevel((AttDmg + aSkill.Effect.AttDmg), Level, entity.Level) * (1 - ((entity.DefPer / 100) - ((IgnoreDef + aSkill.Effect.IgnoreDef) / 100)));
      return CalCritDmg(dmg, out isCrit, aSkill.Effect);
    }

    new public double CalAttDmg(IEntity entity, out bool isCrit)
    {
      var dmg = DamageByLevel(AttDmg, Level, entity.Level) * (1 - ((entity.DefPer / 100) - ((IgnoreDef) / 100)));
      return CalCritDmg(dmg, out isCrit);
    }

    new protected double CalCritDmg(double dmg, out bool isCrit, WeaponEffect wEffect)
    {
      var rand = new Random().Next(0, 101);
      var critPer = Math.Round(CritPer + wEffect.CritPer, 2);
      if (critPer >= rand)
      {
        isCrit = true;
        return Math.Round(dmg * (1 + ((CritDmg + wEffect.CritDmg) / 100)), 2);
      }
      else
      {
        isCrit = false;
        return Math.Round(dmg, 2);
      }
    }

    new protected double CalCritDmg(double dmg, out bool isCrit)
    {
      var rand = new Random().Next(0, 101);
      var critPer = Math.Round(CritPer, 2);
      if (critPer >= rand)
      {
        isCrit = true;
        return Math.Round(dmg * (1 + (CritDmg / 100)), 2);
      }
      else
      {
        isCrit = false;
        return Math.Round(dmg, 2);
      }
    }
  }
}
