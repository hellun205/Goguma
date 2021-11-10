using System;

namespace Goguma.Game.Object.Skill.Buff
{
  [Serializable]
  public struct BuffEffect
  {
    public int Turn { get; set; }
    public double MaxHp { get; set; }
    public double MaxEp { get; set; }
    public double PhysicalDamage { get; set; }
    public double PhysicalDefense { get; set; }
    public double PhysicalPenetration { get; set; }
    public double MagicDamage { get; set; }
    public double MagicDefense { get; set; }
    public double MagicPenetration { get; set; }
    public double Hp { get; set; }
    public double Ep { get; set; }
    public double CriticalDamage { get; set; }
    public double CriticalPercent { get; set; }

    public BuffEffect Plus(BuffEffect buffToCombine)
    {
      return new BuffEffect()
      {
        MaxHp = this.MaxHp + buffToCombine.MaxHp,
        MaxEp = this.MaxEp + buffToCombine.MaxEp,
        PhysicalDamage = this.PhysicalDamage + buffToCombine.PhysicalDamage,
        PhysicalDefense = this.PhysicalDefense + buffToCombine.PhysicalDefense,
        PhysicalPenetration = this.PhysicalPenetration + buffToCombine.PhysicalPenetration,
        MagicDamage = this.MagicDamage + buffToCombine.MagicDamage,
        MagicDefense = this.MagicDefense + buffToCombine.MagicDefense,
        MagicPenetration = this.MagicPenetration + buffToCombine.MagicPenetration,
        Hp = this.Hp + buffToCombine.Hp,
        Ep = this.Ep + buffToCombine.Ep,
        CriticalDamage = this.CriticalDamage + buffToCombine.CriticalDamage,
      };
    }

    public BuffEffect Plus(BuffEffect[] buffsToCombine)
    {
      var resBuf = new BuffEffect()
      {
        MaxHp = this.MaxHp,
        MaxEp = this.MaxEp,
        PhysicalDamage = this.PhysicalDamage,
        PhysicalDefense = this.PhysicalDefense,
        PhysicalPenetration = this.PhysicalPenetration,
        MagicDamage = this.MagicDamage,
        MagicDefense = this.MagicDefense,
        MagicPenetration = this.MagicPenetration,
        Hp = this.Hp,
        Ep = this.Ep,
        CriticalDamage = this.CriticalDamage
      };

      foreach (var buff in buffsToCombine)
      {
        resBuf.MaxHp += buff.MaxHp;
        resBuf.MaxEp += buff.MaxEp;
        resBuf.PhysicalDamage += buff.PhysicalDamage;
        resBuf.PhysicalDefense += buff.PhysicalDefense;
        resBuf.PhysicalPenetration += buff.PhysicalPenetration;
        resBuf.MagicDamage += buff.MagicDamage;
        resBuf.MagicDefense += buff.MagicDefense;
        resBuf.MagicPenetration += buff.MagicPenetration;
        resBuf.Hp += buff.Hp;
        resBuf.Ep += buff.Ep;
        resBuf.CriticalDamage += buff.CriticalDamage;
      }
      return resBuf;
    }

    public BuffEffect Plus(IBuffSkill[] buffsToCombine)
    {
      var resBuf = new BuffEffect()
      {
        MaxHp = this.MaxHp,
        MaxEp = this.MaxEp,
        PhysicalDamage = this.PhysicalDamage,
        PhysicalDefense = this.PhysicalDefense,
        PhysicalPenetration = this.PhysicalPenetration,
        MagicDamage = this.MagicDamage,
        MagicDefense = this.MagicDefense,
        MagicPenetration = this.MagicPenetration,
        Hp = this.Hp,
        Ep = this.Ep,
        CriticalDamage = this.CriticalDamage
      };

      foreach (var buff in buffsToCombine)
      {
        resBuf.MaxHp += buff.Effect.MaxHp;
        resBuf.MaxEp += buff.Effect.MaxEp;
        resBuf.PhysicalDamage += buff.Effect.PhysicalDamage;
        resBuf.PhysicalDefense += buff.Effect.PhysicalDefense;
        resBuf.PhysicalPenetration += buff.Effect.PhysicalPenetration;
        resBuf.MagicDamage += buff.Effect.MagicDamage;
        resBuf.MagicDefense += buff.Effect.MagicDefense;
        resBuf.MagicPenetration += buff.Effect.MagicPenetration;
        resBuf.Hp += buff.Effect.Hp;
        resBuf.Ep += buff.Effect.Ep;
        resBuf.CriticalDamage += buff.Effect.CriticalDamage;
      }
      return resBuf;
    }
  }
}
