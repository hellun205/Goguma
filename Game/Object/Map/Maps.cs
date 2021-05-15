using Gogu_Remaster.Game.Object.Map.Road;
using Gogu_Remaster.Game.Object.Map.Town;

namespace Gogu_Remaster.Game.Object.Map
{
  public class Maps
  {
    public static IMap GetMapByName(string name)
    {
      if (name == Roads.kRoad.Name) return Roads.kRoad;
      else if (name == Towns.kks.Name) return Towns.kks;
      else if (name == Towns.hellun.Name) return Towns.hellun;
      else return null;
    }
  }
}
