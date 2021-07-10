using System;
using Goguma.Game.Object.Quest.Quests;

namespace Goguma.Game.Object.Quest
{
  public static class Questss
  {
    public static IQuest GetQuestInstance(QuestList quest)
    {
      switch (quest)
      {
        case QuestList.TEST_QUEST: return Qst_TestQuest.Instance;

        default: throw new NotImplementedException();
      }
    }

    public static IQuest GetNewQuest(QuestList quest)
    {
      switch (quest)
      {
        case QuestList.TEST_QUEST: return new Qst_TestQuest();

        default: throw new NotImplementedException();
      }
    }
  }
}