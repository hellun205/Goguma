using System;
using Colorify;
using Goguma.Game.Console;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  abstract class EquipmentItem : Item, IEquipmentItem
  {
    public override HavingType Type => HavingType.Equipment;
    public override int MaxCount => 1;
    public abstract WearingType EquipmentType { get; }

    public EquipmentItem() : base() { }

    public EquipmentItem(in EquipmentItem item) : base(item) { }

    public override CTexts Info(bool showCount = true)
    {
      var player = InGame.player;
      var resCT = new CTexts();
      resCT.Append($"{{\n{GetSep(40, $"〔 {Name.ToString()}{(showCount ? $" [ {Count}개 ]" : "")} 〕")}}}")
      .Append($"{{\n  {InvenInfo.GetTypeString(Type)} 아이템,{Colors.txtWarning}}}{{ {InvenInfo.GetTypeString(EquipmentType)},{Colors.bgSuccess}}}")
      .Append(Descriptions)
      .Append($"{{\n{GetSep(40)}}}")
      .Append(EffectInfo());
      resCT.Append($"{{\n{GetSep(40)}}}");
      return resCT;
    }

    public override string ToString()
    {
      return base.ToString();
    }

    public abstract CTexts EffectInfo();
  }
}