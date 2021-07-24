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
        case QuestList.TEST_QUEST: return QstTestQuest.Instance;

        case QuestList.TEST_QUEST2: return QstTestQuest2.Instance;

        case QuestList.TEST_QUEST3: return QstTestQuest3.Instance;

        case QuestList.TEST_QUEST4: return QstTestQuest4.Instance;

        case QuestList.STUDENT_A_QUEST1: return StudentAQuest1.Instance;

        default: throw new NotImplementedException();
      }
    }

    public static IQuest GetNewQuest(QuestList quest)
    {
      switch (quest)
      {
        case QuestList.TEST_QUEST: return new QstTestQuest();

        case QuestList.TEST_QUEST2: return new QstTestQuest2();

        case QuestList.TEST_QUEST3: return new QstTestQuest3();

        case QuestList.TEST_QUEST4: return new QstTestQuest4();

        case QuestList.STUDENT_A_QUEST1: return new StudentAQuest1();

        default: throw new NotImplementedException();
      }
    }
  }
}