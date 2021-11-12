namespace Goguma.Game.Object.Skill.Attack
{
  public abstract class AMixAttackSkill : AttackSkill
  {
    public override AttackType DamageType => AttackType.MIX;

    public override string DamageTypeString => "물리/마법 공격 스킬";

  }
}