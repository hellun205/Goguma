using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Npc;

namespace Goguma.Game.Object.Quest.Dialog
{
  public abstract class Dialog : IDialog
  {
    public Npc.Npc Npc { get; set; }
    public DialogText Text { get; set; }
    public bool isCancelled { get; set; }

    public Dialog(NpcList npc, DialogText text)
    {
      Npc = Npcs.GetTraderByEnum(npc);
      Text = text;
    }

    public abstract DialogType Type { get; }

    public abstract string Show(string playerAns = "");

    protected CTexts NpcText(string pan)
    {
      return new CTexts().Append($"{{  {Npc.TypeString} ,{Colors.txtWarning}}}{{{Npc.Name},{Colors.txtInfo}}}{{ : }}").Append(Text.Get(pan));
    }

    public static void ShowDialogs(List<IDialog> dialogs, DNpcSay cancelledDialog)
    {
      string ans = "";
      foreach (var dialog in dialogs)
      {
        ans = dialog.Show(ans);
        if (dialog.isCancelled)
        {
          cancelledDialog.Show();
          break;
        }
      }
    }

    public static bool ShowDialogs(List<IDialog> dialogs, DAsk askDialog, DNpcSay cancelledDialog)
    {
      ShowDialogs(dialogs, cancelledDialog);
      return askDialog.ShowAsk();
    }
  }
}