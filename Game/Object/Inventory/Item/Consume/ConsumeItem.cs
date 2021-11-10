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
    public override CTexts DisplayName => CTexts.Make($"{{[ {TypeString} ],{Colors.txtWarning}}}{{ }}{{[ {CTypeString} ],{Colors.txtSuccess}}}{{ }}").Combine(Name);
    public override HavingType Type => HavingType.Consume;
    public abstract ConsumeItemType CType { get; }
    public int LoseCount { get; set; }
    public string CTypeString => GetCTypeText(CType);

    public ConsumeItem() : base()
    {
      LoseCount = 1;
    }

    public abstract void UseItem(Player player);

    public override CTexts Info()
    {
      var player = InGame.player;
      var resCt = new CTexts();
      resCt.Append($"{{\n{GetSep(45, $"{Name.ToString()}")}}}")
      .Append($"{{\n  {TypeString} 아이템,{Colors.txtWarning}}}{{ {CTypeString}\n,{Colors.txtSuccess}}}")
      .Append(Descriptions)
      .Append($"{{\n{GetSep(45)}}}")
      .Append(EffectInfo());
      resCt.Append($"{{\n{GetSep(45)}}}");
      return resCt;
    }

    public abstract CTexts EffectInfo();
    public abstract CTexts UsedText();

    public static string GetCTypeText(ConsumeItemType cType)
    {
      switch (cType)
      {
        case ConsumeItemType.Potion:
          return "포션";
        case ConsumeItemType.SkillBook:
          return "스킬 북";
        default:
          throw new NotImplementedException();
      }
    }
  }
}