using System.Collections.Generic;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest
{
  abstract partial class Quest
  {
    public List<IDialog> Dialogs { get; protected set; }
    public DAsk AskDialog { get; protected set; }
    public DNpcSay CancelledDialog { get; protected set; }
    public DNpcSay AcceptDialog { get; protected set; }
    public DNpcSay DeclineDialog { get; protected set; }
    public string Name { get; protected set; }
    public RequireLevel RequireLv { get; protected set; }
    public bool IsCompleted { get; set; }
    public double GivingExp { get; protected set; }
    public double GivingGold { get; protected set; }
    public List<IItem> GivingItems { get; protected set; }
    public List<int> GivingItemCounts { get; protected set; }

    public Quest()
    {
      Dialogs = new List<IDialog>();
      GivingItems = new List<IItem>();
      GivingItemCounts = new List<int>();
    }

    public bool ShowDialog()
    {
      var ask = Dialog.Dialog.ShowDialogs(Dialogs, AskDialog, CancelledDialog);
      if (ask)
        AcceptDialog.Show();
      else
        DeclineDialog.Show();

      return ask;
    }

    public void Exe(IPlayer player)
    {
      var ask = ShowDialog();
    }

    public void OnCompleted()
    {
      InGame.player.Gold += GivingGold;
      InGame.player.Exp += GivingExp;
      foreach (var item in GivingItems)
        InGame.player.Inventory.GetItem(item.GetInstance(), GivingItemCounts[GivingItems.IndexOf(item)]);

    }
  }
}