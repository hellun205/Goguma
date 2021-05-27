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
    public abstract WearingType EType { get; }
    public string ETypeString => InvenInfo.GetTypeString(EType);

    public EquipmentItem() : base() { }

    public EquipmentItem(in EquipmentItem item) : base(item) { }

    public override CTexts Info(bool showCount = true)
    {
      var player = InGame.player;
      var resCT = new CTexts();
      resCT.Append($"{{\n{GetSep(45, $"{Name.ToString()}{(showCount ? $" [ {Count}개 ]" : "")}")}}}")
      .Append($"{{\n  {InvenInfo.GetTypeString(Type)} 아이템,{Colors.txtWarning}}}{{ {InvenInfo.GetTypeString(EType)}\n,{Colors.txtSuccess}}}")
      .Append(Descriptions)
      .Append($"{{\n{GetSep(45)}}}")
      .Append(EffectInfo());
      resCT.Append($"{{\n{GetSep(45)}}}");
      return resCT;
    }

    public override string ToString()
    {
      return base.ToString();
    }

    public abstract CTexts EffectInfo(bool isMinus = false);

    public CTexts EquipedText()
    {
      return EffectInfo()
      .Combine($"{{\n\n위 능력치들이 {SMP(false)}하였습니다.\n}}");
    }

    public CTexts UnEquipedText()
    {
      return EffectInfo(true)
      .Combine($"{{\n\n위 능력치들이 {SMP(true)}하였습니다.\n}}");
    }

    protected double DMP(double dob, bool isMinus)
    {
      return (isMinus ? dob * -1 : dob);
    }

    protected string SMP(bool isMinus, string minusStr = "감소", string plusStr = "증가")
    {
      return (isMinus ? minusStr : plusStr);
    }
  }
}