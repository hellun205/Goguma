namespace Goguma.Game.Object.Map
{
  class MapInfo
  {
    public string Text { get; set; }
    public MapList Map { get; set; }

    public MapInfo(MapList map)
    {
      Map = map;

      switch (map)
      {
        case MapList.Not:
          Text = "아무 것 도 없는";
          break;
          // default:
          //   Text = "알 수 없음";
      }
    }
  }
}