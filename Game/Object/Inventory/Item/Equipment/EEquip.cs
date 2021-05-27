using Goguma.Game.Console;
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

    public override CTexts EffectInfo()
    {
      var player = InGame.player;
      var resCT = new CTexts();

      if (Effect.MaxHp != 0) resCT.Append($"{{\n최대 체력 증가 : }}").Append(NumberColor(Effect.MaxHp)).Append($"{{ ( {player.MaxHp} }}").Append(NumberColor(Effect.MaxHp)).Append("{ → }").Append(NumberColor(player.MaxHp + Effect.MaxHp)).Append("{ )}");

      if (Effect.MaxEp != 0) resCT.Append($"{{\n최대 에너지 증가 : }}").Append(NumberColor(Effect.MaxEp)).Append($"{{ ( {player.MaxEp} }}").Append(NumberColor(Effect.MaxEp)).Append("{ → }").Append(NumberColor(player.MaxEp + Effect.MaxEp)).Append("{ )}");

      if (Effect.DefPer != 0) resCT.Append($"{{\n방어율 증가 : }}").Append(NumberColor(Effect.DefPer, "%")).Append($"{{ ( {player.DefPer} % }}").Append(NumberColor(Effect.DefPer, "%")).Append("{ → }").Append(NumberColor(player.DefPer + Effect.DefPer, "%")).Append("{ )}");

      return resCT;
    }
  }
}