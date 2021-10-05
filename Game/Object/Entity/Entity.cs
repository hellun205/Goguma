using System;
using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Skill;
using static Goguma.Game.Console.StringFunction;
using static Goguma.Game.Console.ConsoleFunction;
using Colorify;
using Goguma.Game.Object.Inventory.Item.Equipment;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Skill.Skills;
using Goguma.Game.Object.Skill.Attack;

namespace Goguma.Game.Object.Entity
{
  [Serializable]
  public abstract class Entity : IEntity
  {
    public virtual string Name { get; set; }

    public virtual CTexts DisplayName => CTexts.Make($"{{{Name}}}");

    public abstract EntityType Type { get; }

    public virtual ClassType Class => ClassType.WARRIOR;

    public virtual int Level { get; set; }

    public virtual double Hp
    {
      get => Math.Round(hp, 2);
      set => hp = Math.Min(value, MaxHp);
    }

    public virtual double MaxHp
    {
      get => Math.Round(maxHp + BuffsIncrease.MaxHp, 2);
      set => maxHp = Math.Max(1, value);
    }

    public virtual double PhysicalDamage
    {
      get => Math.Round(physicalDamage + BuffsIncrease.PhysicalDamage, 2);
      set => physicalDamage = Math.Max(0, value);
    }

    public virtual double PhysicalDefense
    {
      get => Math.Round(physicalDefense + BuffsIncrease.PhysicalDefense, 2);
      set => physicalDefense = Math.Max(0, value);
    }

    public virtual double PhysicalPenetration
    {
      get => Math.Round(physicalPenetration + BuffsIncrease.PhysicalPenetration, 2);
      set => physicalPenetration = Math.Max(0, value);
    }

    public virtual double CriticalDamage
    {
      get => Math.Round(criticalDamage + BuffsIncrease.CriticalDamage, 2);
      set => criticalDamage = Math.Max(0, value);
    }

    public virtual double CriticalPercent
    {
      get => Math.Floor(criticalPercent + BuffsIncrease.CriticalPercent);
      set => criticalPercent = Math.Max(0, value);
    }

    public virtual double MagicDamage
    {
      get => Math.Round(magicDamage + BuffsIncrease.MagicDamage, 2);
      set => magicDamage = Math.Max(0, value);
    }

    public virtual double MagicDefense
    {
      get => Math.Round(magicDefense + BuffsIncrease.MagicDefense, 2);
      set => magicDefense = Math.Max(0, value);
    }

    public virtual double MagicPenetration
    {
      get => Math.Round(magicPenetration + BuffsIncrease.MagicPenetration, 2);
      set => magicPenetration = Math.Max(0, value);
    }

    public List<ISkill> Skills { get; set; }

    public List<IBuffSkill> Buffs { get; set; }

    protected double hp;
    protected double maxHp;
    protected double physicalDamage;
    protected double physicalDefense;
    protected double physicalPenetration;
    protected double magicDamage;
    protected double magicDefense;
    protected double magicPenetration;
    protected double criticalDamage;
    protected double criticalPercent;
    protected virtual Buff BuffsIncrease
    {
      get
      {
        var resultBuff = new Buff();
        return resultBuff.Plus(Buffs.ToArray());
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
      PhysicalDamage = entity.PhysicalDamage;
      PhysicalDefense = entity.PhysicalDefense;
      CriticalDamage = entity.CriticalDamage;
      CriticalPercent = entity.CriticalPercent;
      PhysicalPenetration = entity.PhysicalPenetration;
      MaxHp = entity.MaxHp;
    }

    public virtual void AddBuff(IBuffSkill skill)
    {
      Buffs.Add(skill);
      if (skill.buff.Hp != 0)
        Hp += skill.buff.Hp;
    }

    public virtual void RemoveBuff(IBuffSkill skill)
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

    protected virtual CTexts Info()
    {
      return new CTexts()
        .Append($"{{\n{GetSep(40, $"{Name} [ Lv. {Level} ]")}}}")
        .Append("{\n체력 : }")
        .Append(GetHpBar())
        .Append($"{{\n공격력 : }}{{{PhysicalDamage},{Colors.txtDanger}}}")
        .Append($"{{\n크리티컬 데미지 : }}{{{CriticalDamage} %,{Colors.txtDanger}}}")
        .Append($"{{\n크리티컬 확률 : }}{{{CriticalPercent} %,{Colors.txtDanger}}}")
        .Append($"{{\n방어율 무시 : }}{{{PhysicalPenetration} %,{Colors.txtDanger}}}")
        .Append($"{{\n방어율 : }}{{{PhysicalDefense} %,{Colors.txtInfo}}}")
        .Append($"{{\n{GetSep(40)}}}");
    }

    public virtual double CalAttDmg(IAttackSkill aSkill, IEntity entity, out bool isCrit)
    {
      var dmg = DamageByLevel((PhysicalDamage + aSkill.Effect.AttDmg), Level, entity.Level) * (1 - ((entity.PhysicalDefense / 100) - ((PhysicalPenetration + aSkill.Effect.IgnoreDef) / 100)));
      return CalCritDmg(dmg, out isCrit, aSkill.Effect);
    }

    public virtual double CalAttDmg(IEntity entity, out bool isCrit)
    {
      var dmg = DamageByLevel(PhysicalDamage, Level, entity.Level) * (1 - ((entity.PhysicalDefense / 100) - ((PhysicalPenetration) / 100)));
      return CalCritDmg(dmg, out isCrit);
    }

    protected virtual double CalCritDmg(double dmg, out bool isCrit, WeaponEffect wEffect)
    {
      var rand = new Random().Next(0, 101);
      var critPer = Math.Round(CriticalPercent + wEffect.CritPer, 2);
      if (critPer >= rand)
      {
        isCrit = true;
        return Math.Round(dmg * (1 + ((CriticalDamage + wEffect.CritDmg) / 100)), 2);
      }
      else
      {
        isCrit = false;
        return Math.Round(dmg, 2);
      }
    }

    protected virtual double CalCritDmg(double dmg, out bool isCrit)
    {
      var rand = new Random().Next(0, 101);
      var critPer = Math.Round(CriticalPercent, 2);
      if (critPer >= rand)
      {
        isCrit = true;
        return Math.Round(dmg * (1 + (CriticalDamage / 100)), 2);
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