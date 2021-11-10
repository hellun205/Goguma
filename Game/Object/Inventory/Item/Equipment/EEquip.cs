using System;
using Goguma.Game.Console;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  public abstract class EEquip : EquipmentItem
  {
    public abstract EquipEffect Effect { get; }

    public EEquip() : base() { }

    public override CTexts EffectInfo(bool isMinus = false)
    {
      var player = InGame.player;
      var resCt = new CTexts();

      if (Effect.MaxHp != 0) resCt.Append($"{{\n최대 체력 {Smp(isMinus)} : }}").Append(NumberColor(Dmp(Effect.MaxHp, isMinus))).Append($"{{ ( {player.MaxHp} }}").Append(NumberColor(Dmp(Effect.MaxHp, isMinus))).Append("{ → }").Append(NumberColor(player.MaxHp + Dmp(Effect.MaxHp, isMinus))).Append("{ )}");

      if (Effect.MaxEp != 0) resCt.Append($"{{\n최대 에너지 {Smp(isMinus)} : }}").Append(NumberColor(Dmp(Effect.MaxEp, isMinus))).Append($"{{ ( {player.MaxEp} }}").Append(NumberColor(Dmp(Effect.MaxEp, isMinus))).Append("{ → }").Append(NumberColor(player.MaxEp + Dmp(Effect.MaxEp, isMinus))).Append("{ )}");

      if (Effect.DefPer != 0) resCt.Append($"{{\n방어율 {Smp(isMinus)} : }}").Append(NumberColor(Dmp(Effect.DefPer, isMinus), "%")).Append($"{{ ( {player.PhysicalDefense} % }}").Append(NumberColor(Dmp(Effect.DefPer, isMinus), "%")).Append("{ → }").Append(NumberColor(player.PhysicalDefense + Dmp(Effect.DefPer, isMinus), "%")).Append("{ )}");

      return resCt;
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}