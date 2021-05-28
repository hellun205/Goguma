using Goguma.Game.Console;
using Goguma.Game.Object.Npc;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest.Dialog
{
  public class DAsk : Dialog
  {
    public bool Answer { get; protected set; }
    public override DialogType Type => DialogType.ASK;

    public DAsk(NpcList npc, DialogText text) : base(npc, text) { }
    public DAsk(NpcList npc, CTexts text) : base(npc, new DialogText(text)) { }

    public override string Show(string playerAns = "")
    {
      Answer = ReadYesOrNo(NpcText(playerAns), "수락", "거절");
      return (Answer ? "수락" : "거절");
    }
    public bool ShowAsk()
    {
      Show();
      return Answer;
    }
  }
}