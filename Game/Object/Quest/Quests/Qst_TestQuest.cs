using System;
using System.Collections.Generic;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest.Quests
{
  [Serializable]
  public class Qst_TestQuest : QKillEntity
  {
    static public readonly Qst_TestQuest Instance = new Qst_TestQuest();
    public override string Name => "K의 테스트 퀘스트";

    public override Npc.Npc Npc => Npcs.Get(NpcList.TRADER_K);

    public override List<IDialog> Dialogs
    {
      get => new List<IDialog>()
      {
        new DNpcSay(Npc, "{하...}", "무슨 일 있으셔요?"),
        new DNpcSay(Npc, "{그게 말이다.. 슬라임 때문에 손님이 너무없어~}", "슬라임?"),
        new DNpcSay(Npc, "{그렇다.. 손님이 없어서야 원.. 장사를 할수가 있나}", "제가 잡아드릴까요?"),
      };
    }

    public override QuestList QType => QuestList.TEST_QUEST;

    public override DNpcAsk AskDialog => new DNpcAsk(Npc, "{오! 슬라임좀 잡아줄 수 있겠나 ?}");
    public override DNpcSay CancelledDialog => new DNpcSay(Npc, "{그려 잘가시게}", "넵");
    public override DNpcSay AcceptDialog => new DNpcSay(Npc, "{고맙네!! 그럼 부탁하네}", "네");
    public override DNpcSay DeclineDialog => new DNpcSay(Npc, "{알겠네.. 슬라임이 잡고 싶다 생각하면 찾아오게나}", "알겠수다");
    public override QuestRequirements QRequirements => new QuestRequirements(QType) { MinLv = 0 };
    public override double GivingExp => 20;
    public override double GivingGold => 10;
    public override List<Entitys> Entitys => new()
    {
      new Entitys(Entity.Monster.MonsterList.SLIME, 10)
    };
    public override List<GivingItem> GivingItems => new() { };

    public Qst_TestQuest()
    {

    }
  }
}