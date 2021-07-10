using System;

namespace Goguma.Game.Object.Npc
{
  public class Npcs
  {
    public static INpc trader = new NTrader();
    public static INpc tK = new NTrader(NpcList.TRADER_K);

    public static INpc Get(string name)
    {
      if (name == trader.Name) return trader;
      else if (name == tK.Name) return tK;
      else return null;
    }

    public static INpc Get(NpcList npc)
    {
      switch (npc)
      {
        case NpcList.TRADER_K: return tK;
        default: return null;
      }
    }

    public static string GetNpcTypeToString(NpcType type)
    {
      switch (type)
      {
        case NpcType.TRADER: return "상인";
        default: throw new NotImplementedException();
      }
    }
  }
}
