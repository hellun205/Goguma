using System.Collections.Generic;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Quest
{
  class Quests
  {
    public static Quest TestQuest = new QKillEntity(QuestList.TEST_QUEST);

    public static Quest GetQuest(QuestList quest)
    {
      switch (quest)
      {
        case QuestList.TEST_QUEST: return TestQuest;
        default: return null;
      }
    }

  }
}