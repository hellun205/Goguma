using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill
{
  public interface ISkill
  {
    string Name { get; set; }
    CTexts Text { get; set; }
    SkillType Type { get; }
    double UseEp { get; set; }
    void Information(bool IsPause = true);
    CTexts Info();
  }
}