using System.Collections.Generic;
using Colorify;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Quest;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Npc.NpcTrader
{
  public class NTraderK : NTrader
  {
    public static Npc instance = new NTraderK();
    public override List<IItem> ItemsForSale => new() { };

    public override string Name => "K";

    public override string NameColor => Colors.txtInfo;

    public override NpcList Material => NpcList.TRADER_K;

    public override DNpcSay[] MeetDialog => new[] { new DNpcSay(this, "{어서 옵쇼~}") };

    public override DNpcSay[] ConversationDialog => new[] { new DNpcSay(this, "{어이쿠 손님 안녕하신가~ !}") };

    public override List<QuestList> Quests => new()
    {
      QuestList.TEST_QUEST,
      QuestList.TEST_QUEST2,
      QuestList.TEST_QUEST3,
    };

    public override DNpcSay[] OpenShopDialog => new[] { new DNpcSay(this, "{물건 많이 있수다!}") };

    public override DNpcSay[] QuestReceiveDialog => new[] { new DNpcSay(this, "{부탁좀 하겠네!}") };

    public override DNpcSay[] QuestCompleteDialog => QuestReceiveDialog;
  }
}