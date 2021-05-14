using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill
{
  public interface ISkill
  {
    string Name { get; set; }
    CTexts Text { get; set; }
    SkillType Type { get; set; }
    double useEp { get; set; }
  }
}