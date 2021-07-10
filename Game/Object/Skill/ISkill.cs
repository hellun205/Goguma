using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill
{
  public interface ISkill
  {
    string Name { get; }
    CTexts Text { get; }
    CTexts Descriptions { get; }
    SkillType Type { get; }
    string TypeString { get; }
    double UseEp { get; }
    void Information(bool IsPause = true);
    CTexts Info(int sepLen = 40);
    CTexts EffectInfo();
  }
}