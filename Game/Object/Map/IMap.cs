using System.Collections.Generic;

namespace Gogu_Remaster.Game.Object.Map
{
  public interface IMap
  {
    public string Name { get; }
    public string Desc { get; }
    public bool IsTown { get; }
    public List<IMap> Adjacents { get; }
  }
}
