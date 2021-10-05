using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;
using Colorify;

namespace Goguma.Game.Object.Entity.Npc 
{
  public class PartyNpc : Entity
  {
    public override EntityType Type => EntityType.NPC;

    public bool AddPartyMember()
    {
      PrintCText($"{{{Name},{Colors.txtDefault}}}");
      return false;
      // TO DO
    }
  }
} 