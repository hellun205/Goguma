using System;
using Goguma.Game.Console;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Skill.Buff
{
  [Serializable]
  public abstract class BuffSkill : Skill, IBuffSkill
  {
    public abstract BuffEffect Effect { get; }
    public override SkillType Type => SkillType.BuffSkill;

    public override CTexts EffectInfo()
    {
      var player = InGame.player;
      var resCt = new CTexts();

      if (Effect.MaxHp != 0) resCt.Append($"{{\n최대 체력 증가 : }}").Append(NumberColor(Effect.MaxHp)).Append($"{{ ( {player.MaxHp} }}").Append(NumberColor(Effect.MaxHp)).Append("{ → }").Append(NumberColor(player.MaxHp + Effect.MaxHp)).Append("{ )}");

      if (Effect.MaxEp != 0) resCt.Append($"{{\n최대 에너지 증가 : }}").Append(NumberColor(Effect.MaxEp)).Append($"{{ ( {player.MaxEp} }}").Append(NumberColor(Effect.MaxEp)).Append("{ → }").Append(NumberColor(player.MaxEp + Effect.MaxEp)).Append("{ )}");

      if (Effect.PhysicalDamage != 0) resCt.Append($"{{\n물리 공격력 증가 : }}").Append(NumberColor(Effect.PhysicalDamage)).Append($"{{ ( {player.PhysicalDamage} }}").Append(NumberColor(Effect.PhysicalDamage)).Append("{ → }").Append(NumberColor(player.PhysicalDamage + Effect.PhysicalDamage)).Append("{ )}");

      if (Effect.PhysicalDamage != 0) resCt.Append($"{{\n마법 공격력 증가 : }}").Append(NumberColor(Effect.MagicDamage)).Append($"{{ ( {player.MagicDamage} }}").Append(NumberColor(Effect.MagicDamage)).Append("{ → }").Append(NumberColor(player.MagicDamage + Effect.MagicDamage)).Append("{ )}");

      if (Effect.PhysicalPenetration != 0) resCt.Append($"{{\n물리 관통력 증가 : }}").Append(NumberColor(Effect.PhysicalPenetration, "%")).Append($"{{ ( {player.PhysicalPenetration} % }}").Append(NumberColor(Effect.PhysicalPenetration, "%")).Append("{ → }").Append(NumberColor(player.PhysicalPenetration + Effect.PhysicalPenetration, "%")).Append("{ )}");

      if (Effect.PhysicalPenetration != 0) resCt.Append($"{{\n마법 관통력 증가 : }}").Append(NumberColor(Effect.MagicPenetration, "%")).Append($"{{ ( {player.MagicPenetration} % }}").Append(NumberColor(Effect.MagicPenetration, "%")).Append("{ → }").Append(NumberColor(player.MagicPenetration + Effect.MagicPenetration, "%")).Append("{ )}");

      if (Effect.PhysicalDefense != 0) resCt.Append($"{{\n물리 방어력 증가 : }}").Append(NumberColor(Effect.PhysicalDefense, "%")).Append($"{{ ( {player.PhysicalDefense} % }}").Append(NumberColor(Effect.PhysicalDefense, "%")).Append("{ → }").Append(NumberColor(player.PhysicalDefense + Effect.PhysicalDefense, "%")).Append("{ )}");

      if (Effect.PhysicalDefense != 0) resCt.Append($"{{\n마법 방어력 증가 : }}").Append(NumberColor(Effect.MagicDefense, "%")).Append($"{{ ( {player.MagicDefense} % }}").Append(NumberColor(Effect.MagicDefense, "%")).Append("{ → }").Append(NumberColor(player.MagicDefense + Effect.MagicDefense, "%")).Append("{ )}");

      if (Effect.CriticalDamage != 0) resCt.Append($"{{\n크리티컬 데미지 증가 : }}").Append(NumberColor(Effect.CriticalDamage, "%")).Append($"{{ ( {player.CriticalDamage} % }}").Append(NumberColor(Effect.CriticalDamage, "%")).Append("{ → }").Append(NumberColor(player.CriticalDamage + Effect.CriticalDamage, "%")).Append("{ )}");

      if (Effect.CriticalPercent != 0) resCt.Append($"{{\n크리티컬 확률 증가 : }}").Append(NumberColor(Effect.CriticalPercent, "%")).Append($"{{ ( {player.CriticalPercent} % }}").Append(NumberColor(Effect.CriticalPercent)).Append("{ → }").Append(NumberColor(player.CriticalPercent + Effect.CriticalPercent, "%")).Append("{ )}");

      if (Effect.Hp != 0) resCt.Append($"{{\n체력 회복 : }}").Append(NumberColor(Effect.Hp)).Append($"{{ ( {player.Hp} }}").Append(NumberColor(Effect.Hp)).Append("{ → }").Append(NumberColor(player.Hp + Effect.Hp)).Append("{ )}");

      if (Effect.Ep != 0) resCt.Append($"{{\n에너지 회복 : }}").Append(NumberColor(Effect.Ep)).Append($"{{ ( {player.Ep} }}").Append(NumberColor(Effect.Ep)).Append("{ → }").Append(NumberColor(player.Ep + Effect.Ep)).Append("{ )}");

      return resCt;
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}