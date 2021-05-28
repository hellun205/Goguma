using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest
{
  public interface IQuest
  {
    List<IDialog> Dialogs { get; set; }
    DAsk AskDialog { get; set; }
    DNpcSay CancelledDialog { get; set; }
    DNpcSay AcceptDialog { get; set; }
    DNpcSay DeclineDialog { get; set; }
    string Name { get; set; }
    NpcList Npc { get; set; }
    RequireLevel RequireLv { get; set; }
    bool IsCompleted { get; set; }
    double GivingExp { get; set; }
    double GivingGold { get; set; }
    List<IItem> GivingItems { get; set; }
    List<int> GivingItemCounts { get; set; }

    bool CheckCompleted();
    bool ShowDialog();
    void Exe(IPlayer player);
    void OnCompleted();
    CTexts Information();
  }
}