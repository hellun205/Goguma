using System;
using System.Linq;

namespace Goguma.Game.Object.Npc
{
  public class Npcs
  {
    public static Npc Get(string name)
    {
      var item = (from NpcList npc in Enum.GetValues(typeof(NpcList))
                  where Get(npc).Name == name
                  select Get(npc)).ToList();

      if (item.Count > 0)
      {
        return item[0];
      }
      else
      {
        return null;
      }
    }

    public static Npc Get(NpcList npc)
    {
      switch (npc)
      {
        case NpcList.TRADER_K: return NpcTrader.NTraderK.Instance;

        case NpcList.GENERAL_STUDENT_A: return NpcGeneral.NGeneralStudentA.Instance;

        default:
          throw new NotImplementedException();
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
