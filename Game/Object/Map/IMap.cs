using System.Collections.Generic;

namespace Goguma.Game.Object.Map
{
  public interface IMap
  {
    public string Name { get; }
    public string Desc { get; }
    public bool IsTown { get; }
    public List<MapList> Adjacents { get; }
  }
}
