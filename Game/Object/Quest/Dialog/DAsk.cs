using Goguma.Game.Object.Npc;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest.Dialog
{
  class DAsk : Dialog
  {
    public bool Answer { get; protected set; }
    public override DialogType Type => DialogType.ASK;

    public DAsk(NpcList npc, DialogText text) : base(npc, text) { }
    public override string Show(string playerAns = "")
    {
      Answer = ReadYesOrNo(NpcText(playerAns), "수락", "거절");
      return "";
    }
    public bool ShowAsk()
    {
      Show();
      return Answer;
    }
  }
}