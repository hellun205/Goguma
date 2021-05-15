using System;
using Goguma.Game.Console;

namespace Gogu_Remaster.Game.Object.Map
{
  [Serializable]
  public class Location
  {
    public string Loc { get; set; }
    public bool InTown { get; set; }

    public Location(string loc, bool isTown)
    {
      Loc = Maps.GetMapByName(loc).Name;

      InTown = isTown;
    }

    public void Move()
    {
      var qt = $"이동 (현재 : ${Loc}";
      var ssi = new SelectSceneItems();


    }
  }
}
