using System.Collections.Generic;
using Goguma.Game.Object.Quest;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Npc.NpcGeneral
{
  public class Dirt0 : NGeneral
  {
    public static readonly Npc Instance = new Dirt0();
    public override string Name => "흙";

    public override NpcList Material => NpcList.DIRT0;

    public override DNpcSay[] MeetDialog => throw new System.NotImplementedException();

    public override DNpcSay[] ConversationDialog => throw new System.NotImplementedException();

    public override DNpcSay[] QuestReceiveDialog => throw new System.NotImplementedException();

    public override DNpcSay[] QuestCompleteDialog => throw new System.NotImplementedException();

    public override List<QuestList> Quests => throw new System.NotImplementedException();
  }
}