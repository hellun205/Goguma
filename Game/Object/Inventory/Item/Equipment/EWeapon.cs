using System;
using Goguma.Game.Console;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  public abstract class EWeapon : EquipmentItem
  {
    public override WearingType EType => WearingType.Weapon;
    public abstract WeaponEffect Effect { get; }

    public EWeapon() : base()
    {
    }

    public override string ToString()
    {
      return base.ToString();
    }

    public override CTexts EffectInfo(bool isMinus = false)
    {
      var player = InGame.player;
      var resCT = new CTexts();

      if (Effect.PhysicalDamage != 0) resCT.Append($"{{\n공격력 {SMP(isMinus)} : }}").Append(NumberColor(DMP(Effect.PhysicalDamage, isMinus))).Append($"{{ ( {player.PhysicalDamage} }}").Append(NumberColor(DMP(Effect.PhysicalDamage, isMinus))).Append("{ → }").Append(NumberColor(player.PhysicalDamage + DMP(Effect.PhysicalDamage, isMinus))).Append("{ )}");

      if (Effect.PhysicalPenetration != 0) resCT.Append($"{{\n방어율 무시 {SMP(isMinus)} : }}").Append(NumberColor(DMP(Effect.PhysicalPenetration, isMinus), "%")).Append($"{{ ( {player.PhysicalPenetration} % }}").Append(NumberColor(DMP(Effect.PhysicalPenetration, isMinus), "%")).Append("{ → }").Append(NumberColor(player.PhysicalPenetration + DMP(Effect.PhysicalPenetration, isMinus), "%")).Append("{ )}");

      if (Effect.CritDmg != 0) resCT.Append($"{{\n크리티컬 데미지 {SMP(isMinus)} : }}").Append(NumberColor(DMP(Effect.CritDmg, isMinus), "%")).Append($"{{ ( {player.CriticalDamage} % }}").Append(NumberColor(DMP(Effect.CritDmg, isMinus), "%")).Append("{ → }").Append(NumberColor(player.CriticalDamage + DMP(Effect.CritDmg, isMinus), "%")).Append("{ )}");

      if (Effect.CritPer != 0) resCT.Append($"{{\n크리티컬 확률 {SMP(isMinus)} : }}").Append(NumberColor(DMP(Effect.CritPer, isMinus), "%")).Append($"{{ ( {player.CriticalPercent} % }}").Append(NumberColor(DMP(Effect.CritPer, isMinus), "%")).Append("{ → }").Append(NumberColor(player.CriticalPercent + DMP(Effect.CritPer, isMinus), "%")).Append("{ )}");

      return resCT;
    }
  }
}