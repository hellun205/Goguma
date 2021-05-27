using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Npc;

namespace Goguma.Game.Object.Quest.Dialog
{
  abstract class Dialog : IDialog
  {
    public Npc.Npc Npc { get; set; }
    public DialogText Text { get; set; }
    public bool isCancelled { get; protected set; }

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

    public static void ShowDialogs(List<IDialog> dialogs)
    {
      foreach (var dialog in dialogs)
      {
        dialog.Show();
      }
    }

    public static bool ShowDialogs(List<IDialog> dialogs, DAsk askDialog)
    {
      ShowDialogs(dialogs);
      return askDialog.ShowAsk();
    }
  }
}