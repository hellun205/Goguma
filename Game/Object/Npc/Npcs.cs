namespace Gogu_Remaster.Game.Object.Npc
{
  public class Npcs
  {
    public static NTrader trader = new NTrader();

    public static NTrader GetTraderByName(string name)
    {
      if (name == trader.Name) return trader;
      else return null;
    }

    public static NTrader GetTraderByEnum(NpcList npc)
    {
      switch (npc)
      {
        case NpcList.TRADER: return trader;
        default: return null;
      }
    }
  }
}
