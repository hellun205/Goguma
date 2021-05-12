namespace Goguma.Game.Object.Skill
{
  class AttackSkill : Skill, IAttackSkill
  {
    public double Damage { get; set; }
    public double IgnoreDef
    {
      get => ignoreDef;
      set
      {
        if (value <= 0)
          ignoreDef = 0;
        else
          ignoreDef = value;
      }
    }

    private double ignoreDef;
  }
}