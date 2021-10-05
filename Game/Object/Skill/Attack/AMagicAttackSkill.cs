namespace Goguma.Game.Object.Skill.Attack
{
  public abstract class AMagicAttackSkill : AttackSkill
  {
    public override AttackType DamageType => AttackType.MAGIC;

    public override string DamageTypeString => "마법 공격 스킬";

    public AMagicAttackSkill()
    {
      Effect = new AttackEffect()
      {
        PhysicalDamage = 0,
        PhysicalPenetration = 0,
        MagicDamage = Effect.MagicDamage,
        MagicPenetration = Effect.MagicDamage,
        CriticalDamage = Effect.CriticalDamage,
        CriticalPercent = Effect.CriticalPercent
      };
    }
  }
}