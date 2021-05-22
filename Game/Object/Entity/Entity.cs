using System;
using System.Collections.Generic;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Entity
{
  [Serializable]
  public abstract class Entity : IEntity
  {
    public string Name { get; set; }
    public int Level { get; set; }
    public Entity()
    {
      Skills = new List<ISkill>();
      Buffs = new List<IBuffSkill>();
    }
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
    public List<ISkill> Skills { get; set; }
    public List<IBuffSkill> Buffs { get; set; }
    protected double hp;
    protected double maxHp;
    protected double attDmg;
    protected double defPer;
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
        }
        return resultBuff;
      }
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
  }
}