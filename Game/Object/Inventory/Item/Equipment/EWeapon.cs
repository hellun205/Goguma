using System;
using Colorify;
using static Goguma.Game.Console.ConsoleFunction;
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

    public override void DescriptionItem()
    {
      var player = InGame.player;
      if (Effect.AttDmg != 0)
      {
        PrintCText($"{{\n공격력: }} {{{player.AttDmg}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(Effect.AttDmg));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(Effect.AttDmg + player.AttDmg));
      }
      if (Effect.IgnoreDef != 0)
      {
        PrintCText($"{{\n방어율 무시: }} {{{player.IgnoreDef}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(Effect.IgnoreDef));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(Effect.IgnoreDef + player.IgnoreDef));
      }
      if (Effect.CritDmg != 0)
      {
        PrintCText($"{{\n크리티컬 데미지: }} {{{player.CritDmg}, {Colors.txtWarning}}} {{ % [ }}");
        PrintCText(NumberColor(Effect.CritDmg));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(Effect.CritDmg + player.CritDmg));
      }
      if (Effect.CritPer != 0)
      {
        PrintCText($"{{\n크리티컬 확률: }} {{{player.CritPer}, {Colors.txtWarning}}} {{ % [ }}");
        PrintCText(NumberColor(Effect.CritPer));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(Effect.CritPer + player.CritPer));
      }
    }
  }
}