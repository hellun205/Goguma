using System;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Quest
{
  public struct QuestRequirements
  {
    public int Min { get; set; }
    public int Max { get; set; }

    public QuestRequirements(int min, int max = Int32.MaxValue)
    {
      Min = min;
      Max = max;
    }
    public bool Check(IPlayer player)
    {
      return (Min <= player.Level && player.Level <= Max);
    }
  }
}