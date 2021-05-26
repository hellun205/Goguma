using System;
using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Skill;
using static Goguma.Game.Console.StringFunction;
using static Goguma.Game.Console.ConsoleFunction;
using Colorify;

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
      set => attDmg = value;
    }

    public double DefPer
    {
      get => Math.Round(defPer + BuffsIncrease.DefPer, 2);
      set => defPer = value;
    }
    public double IgnoreDef
    {
      get => Math.Round(ignoreDef + BuffsIncrease.IgnoreDef, 2);
      set => ignoreDef = Math.Max(0, value);
    }
    public double CritDmg
    {
      get => Math.Round(critDmg + BuffsIncrease.CritDmg, 2);
      set => critDmg = Math.Max(0, value);
    }
    public double CritPer
    {
      get => Math.Floor(critPer + BuffsIncrease.CritPer);
      set => critPer = Math.Max(0, value);
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
          resultBuff.MaxHp += bf.buff.MaxHp;
          resultBuff.MaxEp += bf.buff.MaxEp;
          resultBuff.AttDmg += bf.buff.AttDmg;
          resultBuff.DefPer += bf.buff.DefPer;
          resultBuff.CritPer += bf.buff.CritPer;
          resultBuff.CritDmg += bf.buff.CritDmg;
          resultBuff.IgnoreDef += bf.buff.IgnoreDef;
        }
        return resultBuff;
      }
    }
    public Entity()
    {
      Skills = new List<ISkill>();
      Buffs = new List<IBuffSkill>();
    }

    public Entity(IEntity entity) : this()
    {
      Level = entity.Level;
      Hp = entity.Hp;
      AttDmg = entity.AttDmg;
      DefPer = entity.DefPer;
      CritDmg = entity.CritDmg;
      CritPer = entity.CritPer;
      IgnoreDef = entity.IgnoreDef;
      MaxHp = entity.MaxHp;
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

    public void Information()
    {
      PrintCText(Info());
      Pause();
    }

    public override string ToString()
    {
      return Info().ToString();
    }

    protected CTexts Info()
    {
      return new CTexts()
        .Append($"{{\n{GetSep(40, $"{Name} [ Lv. {Level} ]")}}}")
        .Append("{\n체력 : }")
        .Append(GetHpBar())
        .Append($"{{\n공격력 : }}{{{AttDmg},{Colors.txtDanger}}}")
        .Append($"{{\n크리티컬 데미지 : }}{{{CritDmg} %,{Colors.txtDanger}}}")
        .Append($"{{\n크리티컬 확률 : }}{{{CritPer} %,{Colors.txtDanger}}}")
        .Append($"{{\n방어율 무시 : }}{{{IgnoreDef} %,{Colors.txtDanger}}}")
        .Append($"{{\n방어율 : }}{{{DefPer} %,{Colors.txtInfo}}}")
        .Append($"{{\n{GetSep(40)}}}");
    }

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

    public CTexts GetHpBar(bool withPercentage = true, double plus = 0)
    {
      var bar = GetPerStr(Hp + plus, MaxHp, ColorByHp(Hp + plus, MaxHp));
      if (withPercentage)
        return bar.Combine(CTexts.Make($"{{ [ }}{{{Hp + plus} / {MaxHp},{ColorByHp(Hp + plus, MaxHp)}}}{{ ]}}"));
      else
        return bar;
    }

    public bool IsDead => (Hp <= 0);
  }
}