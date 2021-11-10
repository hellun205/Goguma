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
      var resCt = new CTexts();

      if (Effect.PhysicalDamage != 0) resCt.Append($"{{\n공격력 {Smp(isMinus)} : }}").Append(NumberColor(Dmp(Effect.PhysicalDamage, isMinus))).Append($"{{ ( {player.PhysicalDamage} }}").Append(NumberColor(Dmp(Effect.PhysicalDamage, isMinus))).Append("{ → }").Append(NumberColor(player.PhysicalDamage + Dmp(Effect.PhysicalDamage, isMinus))).Append("{ )}");

      if (Effect.PhysicalPenetration != 0) resCt.Append($"{{\n방어율 무시 {Smp(isMinus)} : }}").Append(NumberColor(Dmp(Effect.PhysicalPenetration, isMinus), "%")).Append($"{{ ( {player.PhysicalPenetration} % }}").Append(NumberColor(Dmp(Effect.PhysicalPenetration, isMinus), "%")).Append("{ → }").Append(NumberColor(player.PhysicalPenetration + Dmp(Effect.PhysicalPenetration, isMinus), "%")).Append("{ )}");

      if (Effect.CritDmg != 0) resCt.Append($"{{\n크리티컬 데미지 {Smp(isMinus)} : }}").Append(NumberColor(Dmp(Effect.CritDmg, isMinus), "%")).Append($"{{ ( {player.CriticalDamage} % }}").Append(NumberColor(Dmp(Effect.CritDmg, isMinus), "%")).Append("{ → }").Append(NumberColor(player.CriticalDamage + Dmp(Effect.CritDmg, isMinus), "%")).Append("{ )}");

      if (Effect.CritPer != 0) resCt.Append($"{{\n크리티컬 확률 {Smp(isMinus)} : }}").Append(NumberColor(Dmp(Effect.CritPer, isMinus), "%")).Append($"{{ ( {player.CriticalPercent} % }}").Append(NumberColor(Dmp(Effect.CritPer, isMinus), "%")).Append("{ → }").Append(NumberColor(player.CriticalPercent + Dmp(Effect.CritPer, isMinus), "%")).Append("{ )}");

      return resCt;
    }
  }
}