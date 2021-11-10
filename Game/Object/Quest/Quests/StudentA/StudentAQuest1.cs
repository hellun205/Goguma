using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest.Quests
{
  [Serializable]
  public class StudentAQuest1 : QBringItem
  {
    static public readonly IQuest Instance = new StudentAQuest1();

    public override string Name => "배고픈 아이";

    public override Npc.Npc ReceiveNpc => Npcs.Get(NpcList.TraderK);

    public override List<IDialog> Dialogs => new()
    {
      new DNpcSay(ReceiveNpc, "{(꼬르륵...)}", "(꼬르륵 하는거보니 배가 고픈가 보군..)"),
      new DNpcSay(ReceiveNpc, "{(꼬르르륵....)}", "학생.. 배고프니?"),
      new DNpcSay(ReceiveNpc, "{ㄴ...네.. 돈이 없어서... (꼬르륵...)}", "..."),
    };

    public override List<IDialog> OnCompleteDialog => new()
    {
      new DNpcSay(ReceiveNpc, "{(꿀꺽꿀꺽) 흐아.. 감사해요..}", "그래.. 뭐..")
    };

    public override QuestList Material => QuestList.TestQuest;

    public override DNpcAsk AskDialog => new DNpcAsk(ReceiveNpc, "{저... 사과가 너무 먹고싶어요..}");

    public override DNpcSay CancelledDialog => new DNpcSay(ReceiveNpc, "{(꼬르륵...))}", "(...)");

    public override DNpcSay AcceptDialog => new DNpcSay(ReceiveNpc, $"{{오..! {(InGame.player.Gender == Entity.Player.Gender.Male ? "형" : "누나")} 감사해요... 저.. 그럼.. }}{{사과 10개,{Colors.txtInfo}}}{{만 가져와주세요..}}", "그래");

    public override DNpcSay DeclineDialog => CancelledDialog;

    public override QuestRequirements QRequirements => new QuestRequirements(Material) { MinLv = 1 };

    public override double GivingExp => 20;

    public override int GivingGold => 0;

    public override List<ItemPair> GivingItems => new() { };

    public override List<ItemPair> ItemsToBring => new()
    {
      new ItemPair(ItemList.Apple, 10)
    };

    public StudentAQuest1() : base() { }
  }
}