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
      public MonsterList Monster { get; }
      public byte Prob { get; } // 1 ~ 100
    }
    public List<RoadMonster> SummonMonsters { get; }

    public IMonster SummonMonster()
    {
      var rand = new Random();

      while (true)
      {
        var index = rand.Next(0, SummonMonsters.Count);
        var prob = rand.Next(0, 101);

        if (SummonMonsters[index].Prob >= prob)
          return Monsters.Get(SummonMonsters[index].Monster);
      }
    }
  }
}