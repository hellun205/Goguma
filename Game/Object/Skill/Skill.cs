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
    public abstract string Name { get; }
    public abstract CTexts Text { get; }
    public abstract CTexts Descriptions { get; }
    public string TypeString => Skill.GetTypeString(Type);
    public abstract SkillType Type { get; }
    public virtual double UseEp => 0;

    public static string GetTypeString(SkillType type)
    {
      switch (type)
      {
        case SkillType.AttackSkill:
          return "공격";
        case SkillType.BuffSkill:
          return "버프";
        default:
          throw new NotImplementedException();
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

    public CTexts Info(int sepLen = 40)
    {
      return new CTexts()
        .Append($"{{\n{GetSep(sepLen, $"{Name}")}}}")
        .Append($"{{\n{TypeString} 스킬,{Colors.txtWarning}}} {{  {UseEp} 에너지 소모\n,{Colors.txtInfo}}}")
        .Append(Descriptions)
        .Append($"{{\n{GetSep(sepLen)}}}")
        .Append(EffectInfo())
        .Append($"{{\n{GetSep(sepLen)}}}");
    }

    public abstract CTexts EffectInfo();
  }
}