using System;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill
{
  [Serializable]
  public abstract class Skill : ISkill
  {
    public string Name { get; set; }
    public CTexts Text { get; set; }
    public CTexts Descriptions { get; set; }
    public abstract SkillType Type { get; }
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
    public abstract void Information();
  }
}