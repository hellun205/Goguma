using Goguma.Game.Console;

namespace Goguma.Game.Object.Quest.Dialog
{
  interface IDialog
  {
    DialogText Text { get; set; }
    DialogType Type { get; }
    string Show(string playerAns = "");
  }
}