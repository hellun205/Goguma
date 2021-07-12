using System;
using Colorify;
using Goguma.Game.Console;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  public abstract class EquipmentItem : Item, IEquipmentItem
  {
    public override CTexts DisplayName => CTexts.Make($"{{[ {TypeString} ],{Colors.txtWarning}}}{{ }}{{[ {ETypeString} ],{Colors.txtSuccess}}}{{ }}").Combine(Name);

    public override HavingType Type => HavingType.Equipment;

    public abstract WearingType EType { get; }

    public string ETypeString => GetETypeString(EType);

    public override int MaxCount => 1;

    public EquipmentItem() : base() { }

    public override CTexts Info()
    {
      var player = InGame.player;
      var resCT = new CTexts();
      resCT.Append($"{{\n{GetSep(45, $"{Name.ToString()}")}}}")
      .Append($"{{\n  {TypeString} 아이템,{Colors.txtWarning}}}{{ {ETypeString}\n,{Colors.txtSuccess}}}")
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

    static public string GetETypeString(WearingType wType)
    {
      switch (wType)
      {
        case WearingType.Head:
          return "머리";
        case WearingType.Chestplate:
          return "상체";
        case WearingType.Leggings:
          return "하체";
        case WearingType.Boots:
          return "신발";
        case WearingType.Weapon:
          return "무기";
        default:
          return null;
      }
    }
  }
}