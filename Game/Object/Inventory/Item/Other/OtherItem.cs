using System;
using Colorify;
using Goguma.Game.Console;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Other
{
  [Serializable]
  class OtherItem : Item, IOtherItem
  {
    public override HavingType Type => HavingType.Other;
    public override int MaxCount => 64;
    public OtherItem() : base() { }
    public OtherItem(in OtherItem item) : base(item)
    {

    }

    public override IItem GetInstance()
    {
      return new OtherItem(this);
    }

    public override CTexts Info(bool showCount = true)
    {
      return new CTexts().Append($"{{\n{GetSep(40, $"〔 {Name.ToString()}{(showCount ? $" [ {Count}개 ]" : "")} 〕")}}}")
      .Append($"{{\n  {InvenInfo.GetTypeString(Type)} 아이템\n,{Colors.txtWarning}}}")
      .Append(Descriptions)
      .Append($"{{\n{GetSep(40)}}}");
    }
  }
}