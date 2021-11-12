using Goguma.Game.Object.Map.Road;
using Goguma.Game.Object.Map.Town;

namespace Goguma.Game.Object.Map
{
  public class Maps
  {
    public static IMap GetMap(string name)
    {
      if (name == Roads.kRoad.Name) return Roads.kRoad;
      else if (name == Towns.kks.Name) return Towns.kks;
      else if (name == Towns.hellun.Name) return Towns.hellun;
      else if (name == Towns.gogumaPlantation.Name) return Towns.gogumaPlantation;
      else return null;
    }

    public static IMap GetMap(MapList map)
    {
      switch (map)
      {
        case MapList.KKS_TOWN: return Towns.kks;
        case MapList.HELLUN_TOWN: return Towns.hellun;
        case MapList.K_ROAD: return Roads.kRoad;
        case MapList.GOGUMA_PLANTATION: return Towns.gogumaPlantation;
        default: return null;
      }
    }
  }
}
