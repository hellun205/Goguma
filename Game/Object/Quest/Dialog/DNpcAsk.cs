using Goguma.Game.Console;
using Goguma.Game.Object.Npc;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest.Dialog
{
  public class DNpcAsk : Dialog
  {
    public bool Answer { get; protected set; }
    private string YesText;
    private string NoText;
    public override DialogType Type => DialogType.NPC_ASK;

    public DNpcAsk(Npc.Npc npc, CTexts text, string yesText = "수락", string noText = "거절") : base(npc, text)
    {
      YesText = yesText;
      NoText = noText;
    }
    public DNpcAsk(Npc.Npc npc, string text, string yesText = "수락", string noText = "거절") : this(npc, CTexts.Make(text), yesText, noText) { }
    public DNpcAsk(NpcList npc, string text, string yesText = "수락", string noText = "거절") : this(Npcs.Get(npc), CTexts.Make(text), yesText, noText) { }
    public DNpcAsk(NpcList npc, CTexts text, string yesText = "수락", string noText = "거절") : this(Npcs.Get(npc), text, yesText, noText) { }

    public override string Show(string playerAns = "")
    {
      Answer = ReadYesOrNo(Text.DisplayText(playerAns), YesText, NoText);
      return (Answer ? YesText : NoText);
    }
    public bool ShowAsk()
    {
      Show();
      return Answer;
    }
  }
}