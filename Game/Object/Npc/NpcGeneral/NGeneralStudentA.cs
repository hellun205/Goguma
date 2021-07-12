using System;
using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Quest;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Npc.NpcGeneral
{
  public class NGeneralStudentA : NGeneral
  {
    public override string Name => "지나가던 학생 A";

    public override NpcList Material => NpcList.GENERAL_STUDENT_A;

    public override DNpcSay[] MeetDialog => throw new NotImplementedException();

    public override DNpcSay[] ConversationDialog => throw new NotImplementedException();

    public override DNpcSay[] QuestReceiveDialog => throw new NotImplementedException();

    public override DNpcSay[] QuestCompleteDialog => throw new NotImplementedException();

    public override List<QuestList> Quests => throw new NotImplementedException();
  }
}