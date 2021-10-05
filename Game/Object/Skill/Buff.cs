using System;

namespace Goguma.Game.Object.Skill
{
  [Serializable]
  public struct Buff
  {
    public int turn { get; set; }
    public double MaxHp { get; set; }
    public double MaxEp { get; set; }
    public double AttDmg { get; set; }
    public double DefPer { get; set; }
    public double Hp { get; set; }
    public double Ep { get; set; }
    public double CritDmg { get; set; }
    public double CritPer { get; set; }
    public double IgnoreDef { get; set; }

    public Buff Plus(Buff buffToCombine)
    {
      return new Buff()
      {
        MaxHp = this.MaxHp + buffToCombine.MaxHp,
        MaxEp = this.MaxEp + buffToCombine.MaxEp,
        AttDmg = this.AttDMg + buffToCombine.AttDmg,
        DefPer = this.DefPer + buffToCombine.DefPer,
        Hp = this.Hp + buffToCombine.Hp,
        Ep = this.Ep + buffToCombine.Ep,
        CritDmg = this.CritDmg + buffToCombine.CritDmg,
        IgnoreDef = this.IgnoreDef + buffToCombine.IgnoreDef,
      };
    }

    public Buff Plus(Buff[] buffsToCombine)
    {
      var resBuf = new Buff()
      {
        MaxHp = this.MaxHp,
        MaxEp = this.MaxEp,
        AttDmg = this.AttDMg,
        DefPer = this.DefPer,
        Hp = this.Hp,
        Ep = this.Ep,
        CritDmg = this.CritDmg,
        IgnoreDef = this.IgnoreDef
      };

      foreach (var buff in buffsToCombine)
      {
        resBuf.MaxHp += buff.MaxHp;
        resBuf.MaxEp += buff.MaxEp;
        resBuf.AttDmg += buff.AttDmg;
        resBuf.DefPer += buff.DefPer;
        resBuf.Hp += buff.Hp;
        resBuf.Ep += buff.Ep;
        resBuf.CritDmg += buff.CritDmg;
        resBuf.IgnoreDef += buff.IgnoreDef;
      }
      return resBuf;
    }
  }
}
