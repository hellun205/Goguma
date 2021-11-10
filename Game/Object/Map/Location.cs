using System;
using Colorify;
using Goguma.Game;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Map
{
  [Serializable]
  public class Location
  {
    public string Loc { get; set; }
    public bool InTown { get; set; }

    public Location(string loc, bool isTown)
    {
      Loc = Maps.GetMap(loc).Name;

      InTown = isTown;
    }

    public void Move()
    {
      while (true)
      {
        var qt = $"{{이동 (현재 : {InGame.player.Loc.Loc})}}";
        var ssi = new SelectSceneItems();

        // ConsoleFunction.PrintText(Maps.GetMapByName(InGame.player.Loc.Loc).Adjacents[0].Name);

        foreach (var a in Maps.GetMap(InGame.player.Loc.Loc).Adjacents)
        {
          var map = Maps.GetMap(a);
          ssi.Add($"{{{map.Name}, {(map.Requirements.Check() ? Colors.bgSuccess : Colors.bgDanger)}}}");
        
        }
        ssi.Add($"{{뒤로 가기, {Colors.txtMuted}}}");

        var ss = new SelectScene(CTexts.Make(qt), ssi);
        if (ss.getString == "뒤로 가기") return;

        var to = Maps.GetMap(ss.getString);

        if (to.Requirements.Check())
        {
          InGame.player.Loc = new Location(to.Name, to.IsTown);
          return;
        }
        else
        {
          ConsoleFunction.PrintCText($"{{\n\n{to.Name}에 들어 갈 수 없습니다. 다음 사항을 충족 하세요:\n  레벨 : {(to.Requirements.MinLevel != 0 ? $"{to.Requirements.MinLevel} 이상, " : "")}{(to.Requirements.MaxLevel != 0 ? $"{to.Requirements.MaxLevel} 이하" : "")}\n }}");
          if (to.Requirements.CompletedQuests.Count != 0)
          {
            ConsoleFunction.PrintCText("{퀘스트 완료: }");
            foreach (var quest in to.Requirements.CompletedQuests)
            {
              ConsoleFunction.PrintText($"{Quest.Questss.GetQuestInstance(quest).Name}, ");
            }
          }
          
          if (to.Requirements.QuestsInProgress.Count != 0)
          {
            ConsoleFunction.PrintCText("{진행 중인 퀘스트: }");
            foreach (var quest in to.Requirements.QuestsInProgress)
            {
              ConsoleFunction.PrintText($"{Quest.Questss.GetQuestInstance(quest).Name}, ");
            }
          }
          break;
        }
        
      }
    }
  }
}
