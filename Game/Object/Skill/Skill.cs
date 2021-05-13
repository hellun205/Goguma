using System;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill
{
  [Serializable]
  class Skill : ISkill
  {
    public string Name { get; set; }
    public CTexts Text { get; set; }
    public SkillType Type { get; set; }
    public double useEp { get; set; }

    static public string GetTypeString(SkillType sType)
    {
      switch (sType)
      {
        case SkillType.AttackSkill:
          return "공격";
        case SkillType.BuffSkill:
          return "버프";
        default:
          return null;
      }
    }
  }
}