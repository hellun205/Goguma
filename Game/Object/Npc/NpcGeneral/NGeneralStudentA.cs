using System;
using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Quest;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Npc.NpcGeneral
{
  public class NGeneralStudentA : NGeneral
  {
    public static Npc Instance = new NGeneralStudentA();
    public override string Name => "지나가던 학생 A";

    public override NpcList Material => NpcList.GENERAL_STUDENT_A;

    public override DNpcSay[] MeetDialog => new[]
    {
      new DNpcSay(this, CTexts.Make($"{{{(InGame.player.Gender == Entity.Player.Gender.MALE ? "형아" : "누나")} 안녕!!}}"), String.Empty),
      new DNpcSay(this, CTexts.Make($"{{{(InGame.player.Gender == Entity.Player.Gender.MALE ? "형" : "누나")}!! 반가워!!!}}"), String.Empty),
      new DNpcSay(this, CTexts.Make($"{{{(InGame.player.Gender == Entity.Player.Gender.MALE ? "형" : "누나")} 오랜만!}}"), String.Empty)
    };

    public override DNpcSay[] ConversationDialog => new[]
    {
      new DNpcSay(this, CTexts.Make($"{{{(InGame.player.Gender == Entity.Player.Gender.MALE ? "형아" : "누나")} 뭐해??}}"), String.Empty),
      new DNpcSay(this, CTexts.Make($"{{{(InGame.player.Gender == Entity.Player.Gender.MALE ? "형" : "누나")} 나 심심해!}}"), String.Empty),
      new DNpcSay(this, CTexts.Make($"{{{(InGame.player.Gender == Entity.Player.Gender.MALE ? "형아" : "누나")} 안녕!!}}"), String.Empty),
      new DNpcSay(this, CTexts.Make($"{{{(InGame.player.Gender == Entity.Player.Gender.MALE ? "형" : "누나")}!! 반가워!!!}}"), String.Empty),
      new DNpcSay(this, CTexts.Make($"{{{(InGame.player.Gender == Entity.Player.Gender.MALE ? "형" : "누나")} 오랜만!}}"), String.Empty)
    };

    public override DNpcSay[] QuestReceiveDialog => new[]
    {
      new DNpcSay(this, CTexts.Make($"{{와!! {(InGame.player.Gender == Entity.Player.Gender.MALE ? "형" : "누나")}덕분에 살겠네 고마워!!}}"), String.Empty),
      new DNpcSay(this, CTexts.Make($"{{고마워 {(InGame.player.Gender == Entity.Player.Gender.MALE ? "형" : "누나")}!!}}"), String.Empty),
      new DNpcSay(this, CTexts.Make($"{{부탁할게! {(InGame.player.Gender == Entity.Player.Gender.MALE ? "형" : "누나")}!}}"), String.Empty),
    };

    public override DNpcSay[] QuestCompleteDialog => throw new NotImplementedException();

    public override List<QuestList> Quests => new()
    {
      QuestList.STUDENT_A_QUEST1,
    };
  }
}