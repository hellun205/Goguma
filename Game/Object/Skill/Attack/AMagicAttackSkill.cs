namespace Goguma.Game.Object.Skill.Attack
{
  public abstract class AMagicAttackSkill : AttackSkill
  {
    public override AttackType DamageType => AttackType.Magic;

    public override string DamageTypeString => "마법 공격 스킬";

  }
}