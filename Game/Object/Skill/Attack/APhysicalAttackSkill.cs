namespace Goguma.Game.Object.Skill.Attack
{
  public abstract class APhysicalAttackSkill : AttackSkill
  {
    public override AttackType DamageType => AttackType.PHYSICAL;

    public override string DamageTypeString => "물리 공격 스킬";

    public APhysicalAttackSkill()
    {
      Effect = new AttackEffect()
      {
        PhysicalDamage = Effect.PhysicalDamage,
        PhysicalPenetration = Effect.PhysicalPenetration,
        MagicDamage = 0,
        MagicPenetration = 0,
        CriticalDamage = Effect.CriticalDamage,
        CriticalPercent = Effect.CriticalPercent
      };
    }
  }
}