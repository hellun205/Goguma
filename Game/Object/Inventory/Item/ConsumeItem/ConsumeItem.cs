using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.ConsumeItem
{
  [Serializable]
  abstract class ConsumeItem : Item, IConsumeItem
  {
    public int LoseCount { get; set; }
    public override HavingType Type => HavingType.Consume;
    public override int MaxCount => 64;
    public ConsumeItem()
    {
      Count = 1;
      LoseCount = 1;
    }
  }
}