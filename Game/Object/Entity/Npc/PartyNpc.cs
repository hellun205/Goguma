using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;
using Colorify;

namespace Goguma.Game.Object.Entity.Npc 
{
  public class PartyNpc : Entity
  {
    public void AddPartyMember()
    {
      PrintCText($"{{,{Colors}}}");
    }
  }
} 