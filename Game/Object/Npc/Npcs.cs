using System;

namespace Goguma.Game.Object.Npc
{
  public class Npcs
  {
    public static NTrader trader = new NTrader();
    public static NTrader tK = new NTrader();

    public static NTrader GetTraderByName(string name)
    {
      if (name == trader.Name) return trader;
      else return null;
    }

    public static NTrader GetTraderByEnum(NpcList npc)
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
