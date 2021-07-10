using Goguma.Game.Console;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  public abstract class EEquip : EquipmentItem
  {
    public abstract EquipEffect Effect { get; }

    public EEquip() : base() { }

    public override CTexts EffectInfo(bool isMinus = false)
    {
      var player = InGame.player;
      var resCT = new CTexts();

      if (Effect.MaxHp != 0) resCT.Append($"{{\n최대 체력 {SMP(isMinus)} : }}").Append(NumberColor(DMP(Effect.MaxHp, isMinus))).Append($"{{ ( {player.MaxHp} }}").Append(NumberColor(DMP(Effect.MaxHp, isMinus))).Append("{ → }").Append(NumberColor(player.MaxHp + DMP(Effect.MaxHp, isMinus))).Append("{ )}");

      if (Effect.MaxEp != 0) resCT.Append($"{{\n최대 에너지 {SMP(isMinus)} : }}").Append(NumberColor(DMP(Effect.MaxEp, isMinus))).Append($"{{ ( {player.MaxEp} }}").Append(NumberColor(DMP(Effect.MaxEp, isMinus))).Append("{ → }").Append(NumberColor(player.MaxEp + DMP(Effect.MaxEp, isMinus))).Append("{ )}");

      if (Effect.DefPer != 0) resCT.Append($"{{\n방어율 {SMP(isMinus)} : }}").Append(NumberColor(DMP(Effect.DefPer, isMinus), "%")).Append($"{{ ( {player.DefPer} % }}").Append(NumberColor(DMP(Effect.DefPer, isMinus), "%")).Append("{ → }").Append(NumberColor(player.DefPer + DMP(Effect.DefPer, isMinus), "%")).Append("{ )}");

      return resCT;
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}