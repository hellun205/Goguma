
namespace Goguma.Game.Object.Quest.Dialog
{
  public interface IDialog
  {
    DialogText Text { get; set; }
    DialogType Type { get; }
    string Show(string playerAns = "");

    bool IsCancelled { get; set; }
  }
}