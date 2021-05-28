using Goguma.Game.Console;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest
{
  partial class Quest
  {
    public Quest(QuestList quest) : this()
    {
      switch (quest)
      {
        case QuestList.TEST_QUEST:
          var npc = NpcList.TRADER_K;
          Name = "테스트 퀘스트";
          RequireLv = new RequireLevel(1);
          Dialogs.Add(new DNpcSay(npc, CTexts.Make("{하 날씨 좋군...}"), "음 그렇네요.."));
          Dialogs.Add(new DNpcSay(npc, CTexts.Make("{이런 날에는 풀밭에 누워서 쉬면 정말 좋을텐데..}"), "그것만큼 좋은 건 없죠!"));

          var askDT = new DialogText(CTexts.Make("{자네가 대신 내 소원을 들어주겠나..?}"));
          AskDialog = new DAsk(npc, askDT);

          AcceptDialog = new DNpcSay(npc, CTexts.Make("{고맙네!! 그럼 부탁하네}"), "네");
          DeclineDialog = new DNpcSay(npc, CTexts.Make("{알겠네.. 마음이 바뀌면 다시 찾아오게나..}"), "...");
          CancelledDialog = new DNpcSay(npc, CTexts.Make("{알겠다네..}"), "...");

          GivingExp = 20;
          break;
      }
    }

  }
}