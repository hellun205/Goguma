using System.Collections.Generic;
using Gogu_Remaster.Game.Object.Map.Town;
using Goguma.Game.Object.Entity.Monster;

namespace Gogu_Remaster.Game.Object.Map.Road
{
  public class RKRoad : Road
  {
    public override string Name
    {
      get => "K길";
    }

    public override string Desc
    {
      get => "K-로드";
    }

    internal RKRoad()
    {
      SummonMonsters = new List<Road.RoadMonster>()
      {
        new RoadMonster(MonsterList.SLIME, 100),
        new RoadMonster(MonsterList.GOBLIN, 100),
        new RoadMonster(MonsterList.GOLD_GOBLIN, 10)
      };

      Adjacents = new List<MapList>()
      {
        MapList.KksTown,
        MapList.HellunTown
      };
    }
  }
}
