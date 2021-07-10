using System;
using System.Collections.Generic;
using Goguma.Game.Object.Entity.Monster;

namespace Goguma.Game.Object.Map.Road
{
  public abstract class Road : IMap
  {
    public abstract string Name { get; }
    public abstract string Desc { get; }
    public bool IsTown
    {
      get => false;
    }
    public List<MapList> Adjacents { get; protected set; }

    public struct RoadMonster
    {
      public MonsterList Monster { get; }
      public byte Prob { get; } // 1 ~ 100

      public RoadMonster(MonsterList monster, byte prob)
      {
        Monster = monster;
        Prob = prob;
      }
    }
    public List<RoadMonster> SummonMonsters { get; protected set; }

    public IMonster SummonMonster()
    {
      var rand = new Random();

      while (true)
      {
        var index = rand.Next(0, SummonMonsters.Count);
        var prob = rand.Next(0, 101);

        if (SummonMonsters[index].Prob >= prob)
          return Monster.GetNew(SummonMonsters[index].Monster);
      }
    }
  }
}
