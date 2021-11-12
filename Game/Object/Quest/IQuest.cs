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
    List<IDialog> Dialogs { get; }
    QuestType Type { get; }
    QuestList Material { get; }
    DNpcAsk AskDialog { get; }
    List<IDialog> CancelledDialog { get; }
    List<IDialog> AcceptDialog { get; }
    List<IDialog> DeclineDialog { get; }
    string Name { get; }
    bool IsCancellable { get; }
    Npc.Npc ReceiveNpc { get; }
    Npc.Npc CompleteNpc { get; }
    QuestRequirements QRequirements { get; }
    bool MeetTheRequirements { get; }
    bool IsCompleted { get; }
    double GivingExp { get; }
    int GivingGold { get; }
    List<ItemPair> GivingItems { get; }
    bool ShowDialog();
    void Exe(Player player);
    void OnCompleted();
    CTexts Information();
  }
}