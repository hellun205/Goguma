using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill
{
  interface ISkill
  {
    string Name { get; set; }
    CTexts Text { get; set; }
    SkillType Type { get; set; }
  }
}