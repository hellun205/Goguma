using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest.Dialog
{
  public class DNpcAsk : Dialog
  {
    public bool Answer { get; protected set; }
    public override DialogType Type => DialogType.NpcAsk;
    public DNpcAsk(Npc.Npc npc, CTexts text) : base(npc, text) { }
    public DNpcAsk(Npc.Npc npc, string text) : this(npc, CTexts.Make(text)) { }

    public override string Show(string playerAns = "")
    {
      Answer = ReadYesOrNo(Text.DisplayText(playerAns), "수락", "거절");
      return (Answer ? "수락" : "거절");
    }
    public bool ShowAsk()
    {
      Show();
      return Answer;
    }
  }
}