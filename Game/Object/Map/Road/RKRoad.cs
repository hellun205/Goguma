using System.Collections.Generic;
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

    public RKRoad()
    {
      SummonMonsters = new List<Road.RoadMonster>()
      {
        new RoadMonster(MonsterList.TestMonster, 100)
      };
    }
  }
}
