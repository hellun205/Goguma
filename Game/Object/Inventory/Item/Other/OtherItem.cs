using System;
using Colorify;
using Goguma.Game.Console;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Other
{
  [Serializable]
  public abstract class OtherItem : Item, IOtherItem
  {
    public override CTexts DisplayName => Name;
    public override HavingType Type => HavingType.Other;
    public override int MaxCount => 64;
    public OtherItem() : base() { }

    public override CTexts Info(bool showCount = true)
    {
      return new CTexts().Append($"{{\n{GetSep(45, $"{Name.ToString()}{(showCount ? $" [ {Count}개 ]" : "")}")}}}")
      .Append($"{{\n  {TypeString} 아이템\n,{Colors.txtWarning}}}")
      .Append(Descriptions)
      .Append($"{{\n{GetSep(45)}}}");
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}