namespace Goguma.Game.Object.Skill
{
  public interface IAttackSkill : ISkill
  {
    double Damage { get; set; }
    double IgnoreDef { get; set; }
  }
}