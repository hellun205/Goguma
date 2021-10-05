using System;

namespace Goguma.Game.Object.Skill.Attack
{
  [Serializable]
  public struct AttackEffect
  {
    public double PhysicalDamage { get; set; }

    public double PhysicalPenetration { get; set; }

    public double MagicDamage { get; set; }

    public double MagicPenetration { get; set; }

    public double CriticalDamage { get; set; }

    public double CriticalPercent { get; set; }
  }
}