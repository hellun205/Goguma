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

    public abstract DialogType Type { get; }

    public abstract string Show(string playerAns = "");

    // protected CTexts NpcText(string pan)
    // {
    //   return new CTexts().Append($"{{  {Npc.TypeString} ,{Colors.txtWarning}}}{{{Npc.Name},{Colors.txtInfo}}}{{ : }}").Append(Text[pan]);
    // }

    public static void ShowDialogs(List<IDialog> dialogs, DNpcSay cancelledDialog = null)
    {
      string ans = "";
      foreach (var dialog in dialogs)
      {
        ans = dialog.Show(ans);
        PrintText("\n\n");
        if (dialog.IsCancelled)
        {
          if (cancelledDialog != null) cancelledDialog.Show();
          return;
        }
      }
    }

    public static bool ShowDialogs(List<IDialog> dialogs, DNpcAsk askDialog, DNpcSay cancelledDialog = null)
    {
      ShowDialogs(dialogs, cancelledDialog);
      return askDialog.ShowAsk();
    }
  }
}