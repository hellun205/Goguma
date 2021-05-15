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
        new RoadMonster(MonsterList.TestMonster, 100)
      };

      Adjacents = new List<IMap>()
      {
        Towns.kks,
        Towns.hellun
      };
    }
  }
}
