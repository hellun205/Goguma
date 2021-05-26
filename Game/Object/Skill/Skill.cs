using System;
using Colorify;
using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Skill
{
  [Serializable]
  public abstract class Skill : ISkill
  {
    public string Name { get; set; }
    public CTexts Text { get; set; }
    public CTexts Descriptions { get; set; }
    public abstract SkillType Type { get; }
    public double UseEp { get; set; }

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
    public void Information(bool IsPause)
    {
      PrintCText(Info());
      if (IsPause) Pause();
    }

    public override string ToString()
    {
      return Info().ToString();
    }

    public CTexts Info()
    {
      return new CTexts()
        .Append($"{{\n{GetSep(40, $"{Name}")}}}")
        .Append($"{{\n{GetTypeString(Type)} 스킬,{Colors.txtWarning}}} {{  {UseEp} 에너지 소모\n,{Colors.txtInfo}}}")
        .Append(Descriptions)
        .Append($"{{\n{GetSep(40)}}}");
    }
  }
}