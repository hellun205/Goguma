using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Skill
{
  [Serializable]
  public abstract class AttackSkill : Skill, IAttackSkill
  {
    public abstract WeaponEffect Effect { get; }

    public override SkillType Type => SkillType.AttackSkill;

    public override CTexts EffectInfo()
    {
      var player = InGame.player;
      var resCT = new CTexts();

      if (Effect.AttDmg != 0) resCT.Append($"{{\n스킬 공격력 : }}").Append(NumberColor(Effect.AttDmg)).Append($"{{ ( {player.AttDmg} }}").Append(NumberColor(Effect.AttDmg)).Append("{ → }").Append(NumberColor(player.AttDmg + Effect.AttDmg)).Append("{ )}");

      if (Effect.CritDmg != 0) resCT.Append($"{{\n크리티컬 데미지 : }}").Append(NumberColor(Effect.CritDmg, "%")).Append($"{{ ( {player.CritDmg} % }}").Append(NumberColor(Effect.CritDmg, "%")).Append("{ → }").Append(NumberColor(player.CritDmg + Effect.CritDmg, "%")).Append("{ )}");

      if (Effect.CritPer != 0) resCT.Append($"{{\n크리티컬 확률 : }}").Append(NumberColor(Effect.CritPer, "%")).Append($"{{ ( {player.CritPer} % }}").Append(NumberColor(Effect.CritPer, "%")).Append("{ → }").Append(NumberColor(player.CritPer + Effect.CritPer, "%")).Append("{ )}");

      if (Effect.IgnoreDef != 0) resCT.Append($"{{\n방어율 무시 : }}").Append(NumberColor(Effect.IgnoreDef, "%")).Append($"{{ ( {player.IgnoreDef} % }}").Append(NumberColor(Effect.IgnoreDef, "%")).Append("{ → }").Append(NumberColor(player.IgnoreDef + Effect.IgnoreDef, "%")).Append("{ )}");

      return resCT;
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}