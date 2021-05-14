using System;

namespace Goguma.Game.Object.Map
{
  [Obsolete]
  class Map
  {
    public string Text { get; set; }
    public MapList Current { get; set; }

    public Map(MapList map)
    {
      Current = map;
      Text = GetText(map);
    }
    static public string GetText(MapList map)
    {
      switch (map)
      {
        case MapList.Not:
          return "아무 것 도 없는";
        default:
          return "알 수 없음";
      }
    }
  }
}