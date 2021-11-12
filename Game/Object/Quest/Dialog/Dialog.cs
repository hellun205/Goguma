using System.Collections.Generic;
using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest.Dialog
{
  public abstract class Dialog : IDialog
  {
    public Npc.Npc Npc { get; set; }
    public DialogText Text { get; set; }
    public bool IsCancelled { get; set; }

    public Dialog(Npc.Npc npc, CTexts text)
    {
      Npc = npc;
      Text = new DialogText(text, Npc.DisplayName);
    }

    public Dialog(CTexts text)
    {
      Text = new DialogText(text);
    }
    
    public Dialog(CTexts prefix, CTexts text)
    {
      Text = new DialogText(text, prefix);
    }

    public abstract DialogType Type { get; }

    public abstract string Show(string playerAns = "");

    // protected CTexts NpcText(string pan)
    // {
    //   return new CTexts().Append($"{{  {Npc.TypeString} ,{Colors.txtWarning}}}{{{Npc.Name},{Colors.txtInfo}}}{{ : }}").Append(Text[pan]);
    // }

    public static void ShowDialogs(List<IDialog> dialogs, bool isCancellable = true, List<IDialog> cancelledDialog = null)
    {
      string ans = "";
      foreach (var dialog in dialogs)
      {
        if (dialog != null)
        {
          ans = dialog.Show(ans);
          PrintText("\n\n");
          if (dialog.IsCancelled && isCancellable)
          {
            if (cancelledDialog != null) ShowDialogs(cancelledDialog);
            return;
          }
        }
      }
    }

    public static bool ShowDialogs(List<IDialog> dialogs, DNpcAsk askDialog, bool isCancellable = true, List<IDialog> cancelledDialog = null)
    {
      ShowDialogs(dialogs, isCancellable, cancelledDialog);
      return askDialog.ShowAsk();
    }
  }
}