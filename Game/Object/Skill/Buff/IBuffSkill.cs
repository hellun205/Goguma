namespace Goguma.Game.Object.Skill.Buff
{
  public interface IBuffSkill : ISkill
  {
    BuffEffect Effect { get; }
  }
}