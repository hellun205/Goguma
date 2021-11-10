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
        case QuestList.TestQuest: return QstTestQuest.Instance;

        case QuestList.TestQuest2: return QstTestQuest2.Instance;

        case QuestList.TestQuest3: return QstTestQuest3.Instance;

        case QuestList.TestQuest4: return QstTestQuest4.Instance;

        case QuestList.StudentAQuest1: return StudentAQuest1.Instance;

        default: throw new NotImplementedException();
      }
    }

    public static IQuest GetNewQuest(QuestList quest)
    {
      switch (quest)
      {
        case QuestList.TestQuest: return new QstTestQuest();

        case QuestList.TestQuest2: return new QstTestQuest2();

        case QuestList.TestQuest3: return new QstTestQuest3();

        case QuestList.TestQuest4: return new QstTestQuest4();

        case QuestList.StudentAQuest1: return new StudentAQuest1();

        default: throw new NotImplementedException();
      }
    }
  }
}