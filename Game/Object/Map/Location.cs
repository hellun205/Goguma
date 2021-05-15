using System;
using Gogu_Remaster.Game.Object.Map.Road;
using Gogu_Remaster.Game.Object.Map.Town;

namespace Gogu_Remaster.Game.Object.Map
{
  [Serializable]
  public class Location
  {
    public string Loc { get; set; }
    public bool InTown { get; set; }

    public Location(string loc, bool isTown)
    {
      if (isTown)
        Loc = Towns.GetTownByName(loc).Name;
      else
        Loc = Roads.GetRoadByName(loc).Name;

      InTown = isTown;
    }
  }
}
