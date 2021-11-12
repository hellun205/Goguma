using System.Collections.Generic;
using Colorify;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Quest;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Npc.NpcTrader
{
  public class NTraderDefault : NTrader
  {
    public static Npc instance = new NTraderDefault();
    public override List<IItem> ItemsForSale => new() { };

    public override string Name => "상인 A";

    public override NpcList Material => NpcList.TRADER_DEFAULT;

    public override DNpcSay[] MeetDialog => new[] { new DNpcSay(this, "{어서오시오}") };

    public override DNpcSay[] ConversationDialog => new[] { new DNpcSay(this, "{싼 물건 많이 있소!}") };

    public override List<QuestList> Quests => new()
    {
    };

    public override DNpcSay[] OpenShopDialog => ConversationDialog;

    public override DNpcSay[] QuestReceiveDialog => throw new System.NotImplementedException();

    public override DNpcSay[] QuestCompleteDialog => throw new System.NotImplementedException();
  }
}