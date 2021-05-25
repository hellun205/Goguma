using Colorify;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  abstract class EEquip : EquipmentItem
  {
    public EquipEffect Effect { get; set; }

    public EEquip() : base()
    {
      Effect = new EquipEffect()
      {
        DefPer = 0,
        MaxEp = 0,
        MaxHp = 0
      };
    }

    public EEquip(EEquip item) : base(item)
    {
      Effect = item.Effect;
    }

    public override void DescriptionItem()
    {
      var player = InGame.player;
      if (Effect.MaxHp != 0)
      {
        PrintCText($"{{\nMAX HP }} {{{player.MaxHp}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(Effect.MaxHp));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(Effect.MaxHp + player.MaxHp));
      }
      if (Effect.MaxEp != 0)
      {
        PrintCText($"{{\nMAX EP }} {{{player.MaxEp}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(Effect.MaxEp));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(Effect.MaxEp + player.MaxEp));
      }
      if (Effect.DefPer != 0)
      {
        PrintCText($"{{\nDEF }} {{{player.DefPer}, {Colors.txtWarning}}} {{ % [ }}");
        PrintCText(NumberColor(Effect.DefPer));
        PrintCText("{ % ] → }");
        PrintCText(NumberColor(Effect.DefPer + player.DefPer));
        PrintCText("{ %}");
      }
    }
  }
}