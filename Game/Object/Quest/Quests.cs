using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest
{
  class Quests
  {
    public static IQuest GetNewQuest(QuestList quest)
    {
      switch (quest)
      {
        case QuestList.TEST_QUEST:
          var resQus = new QKillEntity();
          var npc = NpcList.TRADER_K;

          resQus.Name = "테스트 퀘스트";
          resQus.QRequirements = new QuestRequirements(1);
          resQus.Dialogs.Add(new DNpcSay(npc, CTexts.Make("{슬라임이 잡고싶군}"), "음 그렇네요.."));
          resQus.Dialogs.Add(new DNpcSay(npc, CTexts.Make("{기분나쁜 슬라임을 퇴치해줄 용사는 어디없나?}"), "음..."));
          resQus.Dialogs.Add(new DNpcSay(npc, CTexts.Make("{오 혹시 자네 용사인 것인가??}"), "ㄴ  ㅔ 그렇죠뭐"));

          resQus.AskDialog = new DNpcAsk(npc, CTexts.Make("{그렇다면 혹 시 나대신 슬라임좀 잡아줄 수 있겠나 ?}"));
          resQus.AcceptDialog = new DNpcSay(npc, CTexts.Make("{고맙네!! 그럼 부탁하네}"), "네");
          resQus.DeclineDialog = new DNpcSay(npc, CTexts.Make("{알겠네.. 마음이 바뀌면 다시 찾아오게나..}"), "...");
          resQus.CancelledDialog = new DNpcSay(npc, CTexts.Make("{알겠다네..}"), "...");

          resQus.GivingExp = 20;

          resQus.Add(MonsterList.SLIME, 5);
          return resQus;
        default:
          return null;
      }
    }
  }

}


