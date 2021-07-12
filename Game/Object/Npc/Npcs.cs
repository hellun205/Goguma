using System;
using Goguma.Game.Object.Npc.NpcTrader;

namespace Goguma.Game.Object.Npc
{
  public class Npcs
  {
    public static NTrader trader = new NTraderDefault();
    public static NTrader tK = new NTraderK();

    public static Npc Get(string name)
    {
      if (name == trader.Name) return trader;
      else if (name == tK.Name) return tK;
      else return null;
    }

    public static Npc Get(NpcList npc)
    {
      switch (npc)
      {
        case NpcList.TRADER_K: return tK;
        default: throw new NotImplementedException();
      }
    }

    public static string GetNpcTypeToString(NpcType type)
    {
      switch (type)
      {
        case NpcType.TRADER: return "상인";

        case NpcType.GENERAL: return "일반";
        default: throw new NotImplementedException();
      }
    }
  }
}
