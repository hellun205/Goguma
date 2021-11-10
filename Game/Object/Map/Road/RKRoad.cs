using System.Collections.Generic;
using Goguma.Game.Object.Map.Town;
using Goguma.Game.Object.Entity.Monster;

namespace Goguma.Game.Object.Map.Road
{
  public class RkRoad : Road
  {
    public override string Name
    {
      get => "K길";
    }

    public override string Desc
    {
      get => "K-로드";
    }

    internal RkRoad()
    {
      SummonMonsters = new List<Road.RoadMonster>()
      {
        new RoadMonster(MonsterList.Slime, 100),
        new RoadMonster(MonsterList.Goblin, 100),
        new RoadMonster(MonsterList.GoldGoblin, 10)
      };

      Adjacents = new List<MapList>()
      {
        MapList.KksTown,
        MapList.HellunTown
      };
    }
  }
}
