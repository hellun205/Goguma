using System;
using Goguma.Game.Console;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  class EWeapon : EquipmentItem
  {
    public override WearingType EquipmentType => WearingType.Weapon;
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

    public override CTexts EffectInfo()
    {
      var player = InGame.player;
      var resCT = new CTexts();

      if (Effect.AttDmg != 0) resCT.Append($"{{\n공격력 증가 : }}").Append(NumberColor(Effect.AttDmg)).Append($"{{ ( {player.AttDmg} }}").Append(NumberColor(Effect.AttDmg)).Append("{ → }").Append(NumberColor(player.MaxHp + Effect.AttDmg)).Append("{ )}");

      if (Effect.IgnoreDef != 0) resCT.Append($"{{\n방어율 무시 증가 : }}").Append(NumberColor(Effect.IgnoreDef, "%")).Append($"{{ ( {player.IgnoreDef} % }}").Append(NumberColor(Effect.IgnoreDef, "%")).Append("{ → }").Append(NumberColor(player.DefPer + Effect.IgnoreDef, "%")).Append("{ )}");

      if (Effect.CritDmg != 0) resCT.Append($"{{\n크리티컬 데미지 증가 : }}").Append(NumberColor(Effect.CritDmg, "%")).Append($"{{ ( {player.CritDmg} % }}").Append(NumberColor(Effect.CritDmg, "%")).Append("{ → }").Append(NumberColor(player.CritDmg + Effect.CritDmg, "%")).Append("{ )}");

      if (Effect.CritPer != 0) resCT.Append($"{{\n크리티컬 확률 증가 : }}").Append(NumberColor(Effect.CritPer, "%")).Append($"{{ ( {player.CritPer} % }}").Append(NumberColor(Effect.CritPer, "%")).Append("{ → }").Append(NumberColor(player.CritPer + Effect.CritPer, "%")).Append("{ )}");

      return resCT;
    }
  }
}