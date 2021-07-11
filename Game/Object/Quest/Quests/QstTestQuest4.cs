using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest.Quests
{
  [Serializable]
  public class QstTestQuest4 : QBringItem
  {
    public static readonly IQuest Instance = new QstTestQuest4();
    public override string Name => "K의 테스트 퀘스트4";
    public override Npc.Npc ReceiveNpc => Npcs.Get(NpcList.TRADER_K);

    public override List<ItemPair> ItemsToBring => new()
    {
      new ItemPair(ItemList.STICKY_LIQUID, 4)
    };

    public override List<IDialog> Dialogs => new()
    {
      new DNpcSay(ReceiveNpc, "{흐음...}", "이번엔 무슨 일이죠.. ?"),
      new DNpcSay(ReceiveNpc, "{슬라임의 액체가 필요해,,}", "..."),
    };

    public override List<IDialog> OnCompleteDialog => new()
    {
      new DNpcSay(ReceiveNpc, "{고맙군!}", "넵")
    };

    public override QuestList Material => QuestList.TEST_QUEST4;

    public override DNpcAsk AskDialog => new DNpcAsk(ReceiveNpc, $"{{끈적끈적한 액체 4개,{Colors.txtInfo}}}{{를 가져와 줄 수 있나?}}");
    public override DNpcSay CancelledDialog => new DNpcSay(ReceiveNpc, "{알겠네.}", "다음에 또 오겠습니다.");
    public override DNpcSay AcceptDialog => new DNpcSay(ReceiveNpc, "{매번 고맙네!}", "이 정도야 뭐..");
    public override DNpcSay DeclineDialog => CancelledDialog;
    public override QuestRequirements QRequirements => new QuestRequirements(Material)
    {
      MinLv = 0,
      CompletedQuests = new()
      {
        QuestList.TEST_QUEST3
      }
    };

    public override double GivingExp => 20;
    public override int GivingGold => 270;

    public override List<ItemPair> GivingItems => new()
    {
      new(ItemList.POTION_1, 35)
    };


    public QstTestQuest4() : base() { }
  }
}