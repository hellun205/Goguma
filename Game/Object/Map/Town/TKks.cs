using System.Collections.Generic;
using Goguma.Game.Object.Map.Road;
using Goguma.Game.Object.Npc;

namespace Goguma.Game.Object.Map.Town
{
  public class TKks : Town
  {
    public override string Name
    {
      get => "KKS 마을";
    }
    public override string Desc
    {
      get => "제작자 KKS를 기리기 위한 마을";
    }

    internal TKks()
    {
      base.AddFacility(Facility.Facilities.hospital);
      Adjacents = new List<MapList>()
      {
        MapList.KRoad
      };
      Npcs = new List<NpcList>()
      {
        NpcList.TraderK,
        NpcList.GeneralStudentA
      };
    }
  }
}
