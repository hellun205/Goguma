using System;
using System.Collections.Generic;
using Goguma.Game.Object.Entity.Monster;

namespace Gogu_Remaster.Game.Object.Map.Road
{
  public abstract class Road : IMap
  {
    public abstract string Name { get; }
    public abstract string Desc { get; }
    public bool IsTown
    {
      get => false;
    }

    public struct RoadMonster
    {
      public Monster Monster { get; }
      public byte Prob { get; } // 1 ~ 100
    }
    public List<RoadMonster> Monsters { get; }

    public Monster SummonMonster()
    {
      var rand = new Random();

      while (true)
      {
        var index = rand.Next(0, Monsters.Count);
        var prob = rand.Next(0, 101);

        if (Monsters[index].Prob >= prob)
          return Monsters[index].Monster.GetInstace();
      }
    }
  }
}
