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
        new RoadMonster(MonsterList.SLIME, 100),
        new RoadMonster(MonsterList.GOBLIN, 100),
        new RoadMonster(MonsterList.GOLD_GOBLIN, 10)
      };

      Adjacents = new List<MapList>()
      {
        MapList.KKS_TOWN,
        MapList.HELLUN_TOWN
      };
    }
  }
}
