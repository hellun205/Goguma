using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Consume
{
  [Serializable]
  public abstract class ConsumeItem : Item, IConsumeItem
  {
    public override CTexts DisplayName => Name.Combine($"{{ ( {CTypeString} ),{Colors.txtSuccess}}}");
    public override HavingType Type => HavingType.Consume;
    public abstract ConsumeItemType CType { get; }
    public override int MaxCount => 64;
    public int LoseCount { get; set; }
    public string CTypeString => GetCTypeText(CType);

    public ConsumeItem() : base()
    {
      LoseCount = 1;
    }

    public abstract void UseItem(IPlayer player);

    public override CTexts Info(bool showCount = true)
    {
      var player = InGame.player;
      var resCT = new CTexts();
      resCT.Append($"{{\n{GetSep(45, $"{Name.ToString()}{(showCount ? $" [ {Count}개 ]" : "")}")}}}")
      .Append($"{{\n  {TypeString} 아이템,{Colors.txtWarning}}}{{ {CTypeString}\n,{Colors.txtSuccess}}}")
      .Append(Descriptions)
      .Append($"{{\n{GetSep(45)}}}")
      .Append(EffectInfo());
      resCT.Append($"{{\n{GetSep(45)}}}");
      return resCT;
    }

    public abstract CTexts EffectInfo();
    public abstract CTexts UsedText();

    public static string GetCTypeText(ConsumeItemType cType)
    {
      switch (cType)
      {
        case ConsumeItemType.POTION:
          return "포션";
        case ConsumeItemType.SKILL_BOOK:
          return "스킬 북";
        default:
          throw new NotImplementedException();
      }
    }
  }
}