using System;
using System.Collections.Generic;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest.Quests
{
  [Serializable]
  public class QstTestQuest3 : QGeneral
  {
    public static readonly IQuest Instance = new QstTestQuest3();
    public override string Name => "K의 테스트 퀘스트3";
    public override Npc.Npc ReceiveNpc => Npcs.Get(NpcList.TRADER_K);

    public override List<IDialog> Dialogs => new()
    {
      new DNpcSay(ReceiveNpc, "{흐음...}", "..? ( 또 뭐지..?)"),
    };

    public override List<IDialog> OnCompleteDialog => new()
    {
      new DNpcSay(ReceiveNpc, "{그래 좋아.}", ".. ?")
    };

    public override QuestList Material => QuestList.TEST_QUEST3;

    public override DNpcAsk AskDialog => new DNpcAsk(ReceiveNpc, "{나한테좀 찾아와 줄래?}");
    public override DNpcSay CancelledDialog => new DNpcSay(ReceiveNpc, "{알겠네.}", "...");
    public override DNpcSay AcceptDialog => CancelledDialog;
    public override DNpcSay DeclineDialog => CancelledDialog;
    public override QuestRequirements QRequirements => new QuestRequirements(Material)
    {
      MinLv = 0,
      CompletedQuests = new()
      {
        QuestList.TEST_QUEST2
      }
    };
    
    public override double GivingExp => 18;
    public override int GivingGold => 250;

    public override List<ItemPair> GivingItems => new()
    {
      new(ItemList.POTION_1, 25)
    };

    public QstTestQuest3() : base() { }
  }
}