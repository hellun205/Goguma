using System;

namespace Goguma.Game.Object.Quest
{
  struct RequireLevel
  {
    public int Min { get; set; }
    public int Max { get; set; }

    public RequireLevel(int min, int max = Int32.MaxValue)
    {
      Min = min;
      Max = max;
    }
    public bool Check(int level)
    {
      return (Min <= level && level <= Max);
    }
  }
}