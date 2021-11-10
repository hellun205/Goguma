using System;
using System.Collections.Generic;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest.Quests
{
  [Serializable]
  public class QstTestQuest2 : QMeetNpc
  {
    public static  readonly IQuest Instance = new QstTestQuest2();
    public override string Name => "K의 테스트 퀘스트2";

    public override Npc.Npc ReceiveNpc => Npcs.Get(NpcList.TraderK);

    public override List<IDialog> Dialogs => new()
    {
      new DNpcSay(ReceiveNpc, "{하...}", "무슨 일 있으셔요?"),
    };

    public override List<IDialog> OnCompleteDialog => new()
    {
      new DNpcSay(ReceiveNpc, "{그래 좋아.}", ".. ?")
    };

    public override QuestList Material => QuestList.TestQuest2;

    public override DNpcAsk AskDialog => new DNpcAsk(ReceiveNpc, "{나에게 다시 찾아와 다오.}");
    public override DNpcSay CancelledDialog => new DNpcSay(ReceiveNpc, "{그려}", "넵");
    public override DNpcSay AcceptDialog => CancelledDialog;
    public override DNpcSay DeclineDialog => CancelledDialog;
    public override QuestRequirements QRequirements => new QuestRequirements(Material)
    {
      MinLv = 0,
      CompletedQuests = new()
      {
        QuestList.TestQuest
      }
    };
    public override double GivingExp => 10;
    public override int GivingGold => 200;
    public override List<ItemPair> GivingItems => new()
    {
      new(ItemList.Potion1, 15)
    };

    public QstTestQuest2() : base()
    {

    }
  }
}