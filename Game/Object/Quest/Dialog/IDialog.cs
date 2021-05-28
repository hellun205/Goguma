using Goguma.Game.Console;

namespace Goguma.Game.Object.Quest.Dialog
{
  public interface IDialog
  {
    DialogText Text { get; set; }
    DialogType Type { get; }
    string Show(string playerAns = "");

    bool isCancelled { get; set; }
  }
}