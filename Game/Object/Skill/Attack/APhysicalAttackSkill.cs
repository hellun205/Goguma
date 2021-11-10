namespace Goguma.Game.Object.Skill.Attack
{
  public abstract class APhysicalAttackSkill : AttackSkill
  {
    public override AttackType DamageType => AttackType.PHYSICAL;

    public override string DamageTypeString => "물리 공격 스킬";

  }
}