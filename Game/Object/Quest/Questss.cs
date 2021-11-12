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
        case QuestList.PROLOGUE_QUEST: return PrologueQuest.Instance;



        default: throw new NotImplementedException();
      }
    }

    public static IQuest GetNewQuest(QuestList quest)
    {
      switch (quest)
      {
        case QuestList.PROLOGUE_QUEST: return new PrologueQuest();
      


        default: throw new NotImplementedException();
      }
    }
  }
}