using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest.Quests
{
  class Qst_TestQuest : QKillEntity
  {
    static public Qst_TestQuest Instance => new Qst_TestQuest();
    public override string Name => "K의 테스트 퀘스트";

    public override NpcList Npc => NpcList.TRADER_K;

    public override List<IDialog> Dialogs { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public override QuestList QuestEnum => QuestList.TEST_QUEST;

    public override DNpcAsk AskDialog => new DNpcAsk(Npc, CTexts.Make("{그렇다면 혹시 나 대신 슬라임좀 잡아줄 수 있겠나 ?}"));
    public override DNpcSay CancelledDialog => new DNpcSay(Npc, CTexts.Make("{알겠다네..}"), "...");
    public override DNpcSay AcceptDialog => new DNpcSay(Npc, CTexts.Make("{고맙네!! 그럼 부탁하네}"), "네");
    public override DNpcSay DeclineDialog => new DNpcSay(Npc, CTexts.Make("{알겠네.. 마음이 바뀌면 다시 찾아오게나..}"), "...");
    public override QuestRequirements QRequirements => new QuestRequirements() { MinLv = 0 };
    public override double GivingExp => 20;
    public override double GivingGold => 10;
    public override List<Entitys> Entitys { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
    public override List<GivingItem> GivingItems => throw new System.NotImplementedException();

    public Qst_TestQuest()
    {

    }
  }
}