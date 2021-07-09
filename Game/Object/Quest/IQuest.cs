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
    QuestList QuestEnum { get; }
    DNpcAsk AskDialog { get; }
    DNpcSay CancelledDialog { get; }
    DNpcSay AcceptDialog { get; }
    DNpcSay DeclineDialog { get; }
    string Name { get; }
    NpcList Npc { get; }
    QuestRequirements QRequirements { get; }
    bool MeetTheRequirements { get; }
    bool IsCompleted { get; }
    double GivingExp { get; }
    double GivingGold { get; }
    List<GivingItem> GivingItems { get; }
    bool ShowDialog();
    void Exe(IPlayer player);
    void OnCompleted();
    CTexts Information();
  }
}