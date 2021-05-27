using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill
{
  public interface ISkill
  {
    string Name { get; set; }
    CTexts Text { get; set; }
    SkillType Type { get; }
    string TypeString { get; }
    double UseEp { get; set; }
    void Information(bool IsPause = true);
    CTexts Info(int sepLen = 40);
    CTexts EffectInfo();
  }
}