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

        case QuestList.TEST_QUEST2: return Qst_TestQuest2.Instance;

        default: throw new NotImplementedException();
      }
    }

    public static IQuest GetNewQuest(QuestList quest)
    {
      switch (quest)
      {
        case QuestList.TEST_QUEST: return new Qst_TestQuest();

        case QuestList.TEST_QUEST2: return new Qst_TestQuest2();

        default: throw new NotImplementedException();
      }
    }
  }
}