using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Skill
{
  [Serializable]
  public abstract class BuffSkill : Skill, IBuffSkill
  {
    public abstract Buff buff { get; }
    public override SkillType Type => SkillType.BuffSkill;

    public override CTexts EffectInfo()
    {
      var player = InGame.player;
      var resCT = new CTexts();

      if (buff.MaxHp != 0) resCT.Append($"{{\n최대 체력 증가 : }}").Append(NumberColor(buff.MaxHp)).Append($"{{ ( {player.MaxHp} }}").Append(NumberColor(buff.MaxHp)).Append("{ → }").Append(NumberColor(player.MaxHp + buff.MaxHp)).Append("{ )}");

      if (buff.MaxEp != 0) resCT.Append($"{{\n최대 에너지 증가 : }}").Append(NumberColor(buff.MaxEp)).Append($"{{ ( {player.MaxEp} }}").Append(NumberColor(buff.MaxEp)).Append("{ → }").Append(NumberColor(player.MaxEp + buff.MaxEp)).Append("{ )}");

      if (buff.AttDmg != 0) resCT.Append($"{{\n공격력 증가 : }}").Append(NumberColor(buff.AttDmg)).Append($"{{ ( {player.AttDmg} }}").Append(NumberColor(buff.AttDmg)).Append("{ → }").Append(NumberColor(player.AttDmg + buff.AttDmg)).Append("{ )}");

      if (buff.CritDmg != 0) resCT.Append($"{{\n크리티컬 데미지 증가 : }}").Append(NumberColor(buff.CritDmg, "%")).Append($"{{ ( {player.CritDmg} % }}").Append(NumberColor(buff.CritDmg, "%")).Append("{ → }").Append(NumberColor(player.CritDmg + buff.CritDmg, "%")).Append("{ )}");

      if (buff.CritPer != 0) resCT.Append($"{{\n크리티컬 확률 증가 : }}").Append(NumberColor(buff.CritPer, "%")).Append($"{{ ( {player.CritPer} % }}").Append(NumberColor(buff.CritPer)).Append("{ → }").Append(NumberColor(player.CritPer + buff.CritPer, "%")).Append("{ )}");

      if (buff.IgnoreDef != 0) resCT.Append($"{{\n방어율 무시 증가 : }}").Append(NumberColor(buff.IgnoreDef, "%")).Append($"{{ ( {player.IgnoreDef} % }}").Append(NumberColor(buff.IgnoreDef, "%")).Append("{ → }").Append(NumberColor(player.IgnoreDef + buff.IgnoreDef, "%")).Append("{ )}");

      if (buff.DefPer != 0) resCT.Append($"{{\n방어율 증가 : }}").Append(NumberColor(buff.DefPer, "%")).Append($"{{ ( {player.DefPer} % }}").Append(NumberColor(buff.DefPer, "%")).Append("{ → }").Append(NumberColor(player.DefPer + buff.DefPer, "%")).Append("{ )}");

      if (buff.Hp != 0) resCT.Append($"{{\n체력 회복 : }}").Append(NumberColor(buff.Hp)).Append($"{{ ( {player.Hp} }}").Append(NumberColor(buff.Hp)).Append("{ → }").Append(NumberColor(player.Hp + buff.Hp)).Append("{ )}");

      if (buff.Ep != 0) resCT.Append($"{{\n에너지 회복 : }}").Append(NumberColor(buff.Ep)).Append($"{{ ( {player.Ep} }}").Append(NumberColor(buff.Ep)).Append("{ → }").Append(NumberColor(player.Ep + buff.Ep)).Append("{ )}");

      return resCT;
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}