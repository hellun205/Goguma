using System.Collections.Generic;
using Goguma.Game.Object.Map.Facility;
using Goguma.Game.Object.Npc;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Map.Town
{
  public abstract class Town : IMap
  {
    public abstract string Name { get; }
    public abstract string Desc { get; }
    public bool IsTown
    {
      get => true;
    }
    public List<MapList> Adjacents { get; protected set; }
    public List<NpcList> Npcs { get; protected set; }

    public List<IFacility> Facilities { get; }

    public Town()
    {
      Facilities = new List<IFacility>();
    }

    public void AddFacility(IFacility facility)
    {
      if (Facilities.Count == 0 || Facilities.Find(f => f.Name == facility.Name) == null)
        Facilities.Add(facility);
    }

    public void UseFacility()
    {
      var q = new SelectSceneItems();

      foreach (var f in Facilities)
        q.Add(new SelectSceneItem(CTexts.Make(f.Name)));

      var select = new SelectScene(CTexts.Make("이용할 시설을 선택하세요."), q);

      foreach (var f in Facilities)
      {
        if (f.Name == select.getString)
        {
          f.OnUse();
          return;
        }
      }
    }
  }
}
