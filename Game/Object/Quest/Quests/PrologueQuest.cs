using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest.Quests
{
  public class PrologueQuest : QGeneral
  {
    public static readonly IQuest Instance = new PrologueQuest();

    public override List<IDialog> Dialogs => new()
    {
      new DInformation("{???}", "{...}"),
      new DInformation("{???}", "{드디어... 세상에 나왔군...}"),
      new DPlayerSay("{나는.. 고구마다.}"),
      new DPlayerSay("{그건 그렇고 여긴 어디지..?}"),
      new DPlayerSay("{뭘 해야 하지 ?}"),
      new DNpcSay(NpcList.DIRT0, $"{{안녕.. 새로운 }}{{고구마,{Colors.txtWarning}}}{{군}}"),
      new DPlayerSay("{어... 흙이 말하네.. ? (앗 그러고보니 나도 말할수가 있구나!)}"),
    };

    public override List<IDialog> OnCompleteDialog => new()
    {
      // TO DO : 게임 설명
    };

    public override QuestList Material => QuestList.PROLOGUE_QUEST;

    public override DNpcAsk AskDialog => new DNpcAsk(NpcList.DIRT0,
      $"{{고구마,{Colors.txtWarning}}}{{군. 혹시 이 세계에 대해 궁금하면 내가 알려줄까?}}", "응 알려줘", "아니야 안 안알려줘도 될 것 같아");
    public override List<IDialog> CancelledDialog => null;

    public override List<IDialog> DeclineDialog => throw new NotImplementedException(); /*new List<IDialog>()
    {
      // TO DO : 프롤로그 진행
    }*/
    public override QuestRequirements QRequirements => new QuestRequirements(Material)
    {
      MinLv = 0,
      CompletedQuests = new()
      {
        QuestList.TEST_QUEST2
      }
    };
    
    public override double GivingExp => 0;
    public override int GivingGold => 0;

    public override List<ItemPair> GivingItems => new()
    {
      
    };

    public PrologueQuest() : base() { }
  }
}