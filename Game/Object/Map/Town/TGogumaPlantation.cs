using System.Collections.Generic;
using Goguma.Game.Object.Npc;

namespace Goguma.Game.Object.Map.Town
{
  public class TGogumaPlantation : Town
  {
    public override string Name
    {
      get => "고구마 재배지";
    }
    public override string Desc
    {
      get => "고구마가 재배되는 곳이다.";
    }

    internal TGogumaPlantation()
    {
      base.AddFacility(Facility.Facilities.hospital);

      Adjacents = new List<MapList>()
      {
        
      };
      Npcs = new List<NpcList>()
      {
        
      };
    }
  }
}