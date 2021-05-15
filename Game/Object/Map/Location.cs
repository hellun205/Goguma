using System;
using Goguma.Game;
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
      var qt = $"{{이동 (현재 : {InGame.player.Loc.Loc})}}";
      var ssi = new SelectSceneItems();

      // ConsoleFunction.PrintText(Maps.GetMapByName(InGame.player.Loc.Loc).Adjacents[0].Name);

      foreach (var a in Maps.GetMapByName(InGame.player.Loc.Loc).Adjacents)
      {
        var map = Maps.GetMapByEnum(a);
        ssi.Add($"{{{map.Name}}}");
      }


      var ss = new SelectScene(CTexts.Make(qt), ssi);
      var to = Maps.GetMapByName(ss.getString);

      InGame.player.Loc = new Location(to.Name, to.IsTown);
    }
  }
}
