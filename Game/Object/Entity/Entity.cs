using System;
using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Skill;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Entity
{
  [Serializable]
  public abstract class Entity : IEntity
  {
    public string Name { get; set; }
    public abstract EntityType Type { get; }
    public int Level { get; set; }
    public double Hp
    {
      get => Math.Round(hp, 2);
      set => hp = Math.Min(value, MaxHp);
    }
    public double MaxHp
    {
      get => Math.Round(maxHp + BuffsIncrease.MaxHp, 2);
      set => maxHp = Math.Max(1, value);
    }
    public double AttDmg
    {
      get => Math.Round(attDmg + BuffsIncrease.AttDmg, 2);
      set => attDmg = Math.Max(1, value);
    }

    public double DefPer
    {
      get => Math.Round(defPer + BuffsIncrease.DefPer, 2);
      set => defPer = Math.Max(0, value);
    }
    public double IgnoreDef
    {
      get => Math.Round(ignoreDef + BuffsIncrease.IgnoreDef, 2);
      set => ignoreDef = Math.Max(0, value);
    }
    public double CritDmg
    {
      get => Math.Round(critDmg + BuffsIncrease.CritDmg, 2);
      set => critDmg = Math.Max(1, value);
    }
    public double CritPer
    {
      get => Math.Floor(critPer + BuffsIncrease.CritPer);
      set => critPer = Math.Max(1, value);
    }
    public List<ISkill> Skills { get; set; }
    public List<IBuffSkill> Buffs { get; set; }
    protected double hp;
    protected double maxHp;
    protected double attDmg;
    protected double critDmg;
    protected double critPer;
    protected double defPer;
    protected double ignoreDef;
    protected Buff BuffsIncrease
    {
      get
      {
        var resultBuff = new Buff();
        foreach (var bf in Buffs)
        {
          resultBuff.MaxHp += Math.Max(0, bf.buff.MaxHp);
          resultBuff.MaxEp += Math.Max(0, bf.buff.MaxEp);
          resultBuff.AttDmg += Math.Max(0, bf.buff.AttDmg);
          resultBuff.DefPer += Math.Max(0, bf.buff.DefPer);
          resultBuff.CritPer += Math.Max(0, bf.buff.CritPer);
          resultBuff.CritDmg += Math.Max(0, bf.buff.CritDmg);
          resultBuff.IgnoreDef += Math.Max(0, bf.buff.IgnoreDef);
        }
        return resultBuff;
      }
    }
    public Entity()
    {
      Skills = new List<ISkill>();
      Buffs = new List<IBuffSkill>();
    }

    public void AddBuff(IBuffSkill skill)
    {
      Buffs.Add(skill);
      if (skill.buff.Hp != 0)
        Hp += skill.buff.Hp;
    }

    public void RemoveBuff(IBuffSkill skill)
    {
      Buffs.Remove(skill);
    }

    public abstract void Information();

    public double CalAttDmg(IAttackSkill attackSkill, IEntity entity, out bool isCrit)
    {
      var dmg = DamageByLevel((AttDmg + attackSkill.Damage), Level, entity.Level) * (1 - ((entity.DefPer / 100) - ((IgnoreDef + attackSkill.IgnoreDef) / 100)));
      return CalCritDmg(dmg, out isCrit);
    }

    public double CalAttDmg(IEntity entity, out bool isCrit)
    {
      var dmg = DamageByLevel(AttDmg, Level, entity.Level) * (1 - ((entity.DefPer / 100) - ((IgnoreDef) / 100)));
      return CalCritDmg(dmg, out isCrit);
    }

    protected double CalCritDmg(double dmg, out bool isCrit)
    {
      var rand = Math.Round(new Random().NextDouble(), 2);
      var crtiPer = Math.Round(CritPer / 100, 2);
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

    public CTexts GetHpBar(bool withPercentage = true)
    {
      var bar = GetPerStr(Hp, MaxHp, ColorByHp(Hp, MaxHp));
      if (withPercentage)
        return bar.Combine(CTexts.Make($"{{ [ }}{{{Hp} / {MaxHp},{ColorByHp(Hp, MaxHp)}}}{{ ]}}"));
      else
        return bar;
    }

    public bool IsDead => (Hp <= 0);
  }
}