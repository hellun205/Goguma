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
  }
}
