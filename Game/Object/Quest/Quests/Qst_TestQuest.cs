using System;
using System.Collections.Generic;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest.Quests
{
  [Serializable]
  public class Qst_TestQuest : QKillEntity
  {
    static public readonly Qst_TestQuest Instance = new Qst_TestQuest();
    public override string Name => "K의 테스트 퀘스트";

    public override Npc.Npc ReceiveNpc => Npcs.Get(NpcList.TRADER_K);

    public override List<IDialog> Dialogs => new()
    {
      new DNpcSay(ReceiveNpc, "{하...}", "무슨 일 있으셔요?"),
      new DNpcSay(ReceiveNpc, "{그게 말이다.. 슬라임 때문에 손님이 너무없어~}", "슬라임?"),
      new DNpcSay(ReceiveNpc, "{그렇다.. 손님이 없어서야 원.. 장사를 할수가 있나}", "제가 잡아드릴까요?"),
    };

    public override List<IDialog> OnCompleteDialog => new()
    {
      new DNpcSay(ReceiveNpc, "{고맙네 정말!!}", "이 정도는 간단하죠!")
    };

    public override QuestList Material => QuestList.TEST_QUEST;

    public override DNpcAsk AskDialog => new DNpcAsk(ReceiveNpc, "{오! 슬라임좀 잡아줄 수 있겠나 ?}");
    public override DNpcSay CancelledDialog => new DNpcSay(ReceiveNpc, "{그려 잘가시게}", "넵");
    public override DNpcSay AcceptDialog => new DNpcSay(ReceiveNpc, "{고맙네!! 그럼 부탁하네}", "네");
    public override DNpcSay DeclineDialog => new DNpcSay(ReceiveNpc, "{알겠네.. 슬라임이 잡고 싶다 생각하면 찾아오게나}", "알겠수다");
    public override QuestRequirements QRequirements => new QuestRequirements(Material) { MinLv = 0 };
    public override double GivingExp => 20;
    public override int GivingGold => 10;
    public override List<ItemPair> GivingItems => new()
    {
      new(ItemList.POTION_1, 10)
    };

    public Qst_TestQuest() : base()
    {
      Entitys = new()
      {
        new(Entity.Monster.MonsterList.SLIME, 3)
      };
    }
  }
}