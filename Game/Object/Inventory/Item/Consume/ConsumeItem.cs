using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Consume
{
  [Serializable]
  abstract class ConsumeItem : Item, IConsumeItem
  {
    public override HavingType Type => HavingType.Consume;
    public override int MaxCount => 64;
    public int LoseCount { get; set; }
    public abstract string GetString { get; }

    public ConsumeItem() : base()
    {
      LoseCount = 1;
    }

    public ConsumeItem(in ConsumeItem item) : base(item)
    {
      LoseCount = item.LoseCount;
    }

    public abstract void UseItem(IPlayer player);

    public override CTexts Info(bool showCount = true)
    {
      var player = InGame.player;
      var resCT = new CTexts();
      resCT.Append($"{{\n{GetSep(45, $"{Name.ToString()}{(showCount ? $" [ {Count}개 ]" : "")}")}}}")
      .Append($"{{\n  {InvenInfo.GetTypeString(Type)} 아이템,{Colors.txtWarning}}}{{ {GetString}\n,{Colors.txtSuccess}}}")
      .Append(Descriptions)
      .Append($"{{\n{GetSep(45)}}}")
      .Append(EffectInfo());
      resCT.Append($"{{\n{GetSep(45)}}}");
      return resCT;
    }

    public abstract CTexts EffectInfo();
    public abstract CTexts UsedText();
  }
}