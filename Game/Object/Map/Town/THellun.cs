using System.Collections.Generic;
using Gogu_Remaster.Game.Object.Map.Road;

namespace Gogu_Remaster.Game.Object.Map.Town
{
  public class THellun : Town
  {
    public override string Name
    {
      get => "Hellun 마을";
    }
    public override string Desc
    {
      get => "제작자 Hellun을 기리기 위한 마을";
    }

    internal THellun()
    {
      base.AddFacility(Facility.Facilities.hospital);

      Adjacents = new List<MapList>()
      {
        MapList.KRoad
      };
    }
  }
}
