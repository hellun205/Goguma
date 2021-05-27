using System;
using Goguma.Game.Console;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  class EWeapon : EquipmentItem
  {
    public override WearingType EType => WearingType.Weapon;
    public WeaponEffect Effect { get; set; }

    public EWeapon() : base()
    {
      Effect = new WeaponEffect()
      {
        AttDmg = 0,
        CritDmg = 0,
        CritPer = 0,
        IgnoreDef = 0
      };
    }

    public EWeapon(EWeapon item) : base(item)
    {
      Effect = item.Effect;
    }

    public override IItem GetInstance()
    {
      return new EWeapon(this);
    }

    public override string ToString()
    {
      return base.ToString();
    }

    public override CTexts EffectInfo(bool isMinus = false)
    {
      var player = InGame.player;
      var resCT = new CTexts();

      if (Effect.AttDmg != 0) resCT.Append($"{{\n공격력 {SMP(isMinus)} : }}").Append(NumberColor(DMP(Effect.AttDmg, isMinus))).Append($"{{ ( {player.AttDmg} }}").Append(NumberColor(DMP(Effect.AttDmg, isMinus))).Append("{ → }").Append(NumberColor(player.AttDmg + DMP(Effect.AttDmg, isMinus))).Append("{ )}");

      if (Effect.IgnoreDef != 0) resCT.Append($"{{\n방어율 무시 {SMP(isMinus)} : }}").Append(NumberColor(DMP(Effect.IgnoreDef, isMinus), "%")).Append($"{{ ( {player.IgnoreDef} % }}").Append(NumberColor(DMP(Effect.IgnoreDef, isMinus), "%")).Append("{ → }").Append(NumberColor(player.IgnoreDef + DMP(Effect.IgnoreDef, isMinus), "%")).Append("{ )}");

      if (Effect.CritDmg != 0) resCT.Append($"{{\n크리티컬 데미지 {SMP(isMinus)} : }}").Append(NumberColor(DMP(Effect.CritDmg, isMinus), "%")).Append($"{{ ( {player.CritDmg} % }}").Append(NumberColor(DMP(Effect.CritDmg, isMinus), "%")).Append("{ → }").Append(NumberColor(player.CritDmg + DMP(Effect.CritDmg, isMinus), "%")).Append("{ )}");

      if (Effect.CritPer != 0) resCT.Append($"{{\n크리티컬 확률 {SMP(isMinus)} : }}").Append(NumberColor(DMP(Effect.CritPer, isMinus), "%")).Append($"{{ ( {player.CritPer} % }}").Append(NumberColor(DMP(Effect.CritPer, isMinus), "%")).Append("{ → }").Append(NumberColor(player.CritPer + DMP(Effect.CritPer, isMinus), "%")).Append("{ )}");

      return resCT;
    }
  }
}