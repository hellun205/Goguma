using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest.Dialog
{
  public class DInformationAsk : Dialog
  {
    public bool Answer { get; protected set; }
    public override DialogType Type => DialogType.INFORMATION_ASK;
    public DInformationAsk(CTexts prefix, CTexts text) : base(prefix, text) { }
    public DInformationAsk(CTexts prefix, string text) : this(prefix, CTexts.Make(text)) { }
    public DInformationAsk(string prefix, string text) : this(CTexts.Make(prefix), CTexts.Make(text)) { }
    public DInformationAsk(string prefix, CTexts text) : this(CTexts.Make(prefix), text) { }

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