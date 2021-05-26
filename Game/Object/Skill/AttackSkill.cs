using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Skill
{
  [Serializable]
  class AttackSkill : Skill, IAttackSkill
  {
    public WeaponEffect Effect { get; set; }

    public override SkillType Type { get => SkillType.AttackSkill; }

    new public CTexts Info()
    {
      var player = InGame.player;
      var resCT = new CTexts()
        .Append($"{{\n{GetSep(40, $"{Name}")}}}")
        .Append($"{{\n{GetTypeString(Type)} 스킬,{Colors.txtWarning}}} {{  {UseEp} 에너지 소모\n,{Colors.txtInfo}}}")
        .Append(Descriptions)
        .Append($"{{\n{GetSep(40)}}}");

      if (Effect.AttDmg != 0) resCT.Append($"{{\n스킬 공격력 : }}").Append(NumberColor(Effect.AttDmg)).Append($"{{ ( {player.AttDmg} }}").Append(NumberColor(Effect.AttDmg)).Append("{ → }").Append(NumberColor(player.AttDmg + Effect.AttDmg)).Append("{ )}");

      if (Effect.CritDmg != 0) resCT.Append($"{{\n크리티컬 데미지 : }}").Append(NumberColor(Effect.CritDmg, "%")).Append($"{{ ( {player.CritDmg} % }}").Append(NumberColor(Effect.CritDmg, "%")).Append("{ → }").Append(NumberColor(player.CritDmg + Effect.CritDmg, "%")).Append("{ )}");

      if (Effect.CritPer != 0) resCT.Append($"{{\n크리티컬 확률 : }}").Append(NumberColor(Effect.CritPer, "%")).Append($"{{ ( {player.CritPer} % }}").Append(NumberColor(Effect.CritPer, "%")).Append("{ → }").Append(NumberColor(player.CritPer + Effect.CritPer, "%")).Append("{ )}");

      if (Effect.IgnoreDef != 0) resCT.Append($"{{\n방어율 무시 : }}").Append(NumberColor(Effect.IgnoreDef, "%")).Append($"{{ ( {player.IgnoreDef} % }}").Append(NumberColor(Effect.IgnoreDef, "%")).Append("{ → }").Append(NumberColor(player.IgnoreDef + Effect.IgnoreDef, "%")).Append("{ )}");

      resCT.Append($"{{\n{GetSep(40)}}}");
      return resCT;
    }

    new public void Information(bool IsPause)
    {
      PrintCText(Info());
      if (IsPause) Pause();
    }

    public override string ToString()
    {
      return Info().ToString();
    }
  }
}