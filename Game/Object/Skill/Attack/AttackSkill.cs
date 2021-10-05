using System;
using Colorify;
using Goguma.Game.Console;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Skill.Attack
{
  [Serializable]
  public abstract class AttackSkill : Skill, IAttackSkill
  {
    public abstract AttackType DamageType { get; }

    public abstract string DamageTypeString { get; }

    public abstract AttackEffect Effect { get; protected set; }

    public override SkillType Type => SkillType.AttackSkill;

    public override CTexts EffectInfo()
    {
      var resCT = new CTexts();

      if (Effect.PhysicalDamage != 0) resCT.Append($"{{물리 공격력 : ,{Colors.txtDanger}}}").Append(NumberColor(Effect.PhysicalDamage)).Append("{\n}");

      if (Effect.MagicDamage != 0) resCT.Append($"{{마법 공격력 : ,{Colors.txtInfo}}}").Append(NumberColor(Effect.MagicDamage)).Append("{\n}");

      if (Effect.PhysicalPenetration != 0) resCT.Append($"{{물리 관통력 : ,{Colors.txtDanger}}}").Append(NumberColor(Effect.PhysicalPenetration)).Append("{\n}");

      if (Effect.MagicPenetration != 0) resCT.Append($"{{마법 관통력 : ,{Colors.txtInfo}}}").Append(NumberColor(Effect.MagicPenetration)).Append("{\n}");

      if (Effect.CriticalPercent != 0) resCT.Append($"{{치명타 확률 : ,{Colors.txtWarning}}}").Append(NumberColor(Effect.CriticalPercent)).Append("{%\n}");

      if (Effect.CriticalDamage != 0) resCT.Append($"{{치명타 데미지 : ,{Colors.txtWarning}}}").Append(NumberColor(Effect.CriticalDamage)).Append("{\n}");

      return resCT;
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}