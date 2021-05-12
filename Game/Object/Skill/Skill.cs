using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill
{
  class Skill : ISkill
  {
    public string Name { get; set; }
    public CTexts Text { get; set; }
    public SkillType Type { get; set; }

    static public string GetTypeString(SkillType sType)
    {
      switch (sType)
      {
        case SkillType.AttackSkill:
          return "공격";
        default:
          return null;
      }
    }
  }
}