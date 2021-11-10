namespace Goguma.Game.Object.Skill.Attack
{
  public abstract class AMixAttackSkill : AttackSkill
  {
    public override AttackType DamageType => AttackType.Mix;

    public override string DamageTypeString => "물리/마법 공격 스킬";

  }
}