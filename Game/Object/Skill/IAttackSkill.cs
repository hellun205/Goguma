namespace Goguma.Game.Object.Skill
{
  interface IAttackSkill : ISkill
  {
    double Damage { get; set; }
    double IgnoreDef { get; set; }
  }
}