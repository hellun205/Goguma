using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Npc;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest
{
  class QuestSys
  {
    public List<IQuest> Quests { get; set; }

    public void ShowQuests()
    {
      while (true)
      {
        var ssi = new SelectSceneItems();
        foreach (var quest in Quests)
        {
          ssi.Add(CTexts.Make($"{{{quest.Name} - }}{{{Npcs.GetTraderByEnum(quest.Npc).Name},{Colors.txtInfo}}}{{ ( {(quest.IsCompleted ? $"완료 가능 ),{Colors.txtSuccess}" : $"진행 중 ), {Colors.txtWarning}")}}}"));
        }
        var ss = new SelectScene($"{{정보를 확인 할 퀘스트를 선택하세요. 총 {Quests.Count}개의 퀘스트가 진행 중입니다.}}", ssi, true);
        if (ss.isCancelled) return;

        var qst = Quests[ss.getIndex];
        PrintCText(qst.Information());
        ssi = new SelectSceneItems();
        ssi.Add("{퀘스트 포기}");

        ss = new SelectScene(null, ssi, true, null, false);

        switch (ss.getString)
        {
          case "퀘스트 포기":
            if (ReadYesOrNo($"{{진행 중인 퀘스트 {qst.Name}(을)를 포기하시겠습니까?}}"))
            {
              PrintText("\n퀘스트를 포기했습니다.");
              Pause();
              Quests.RemoveAt(ss.getIndex);
            }
            break;

        }
      }
    }
  }
}