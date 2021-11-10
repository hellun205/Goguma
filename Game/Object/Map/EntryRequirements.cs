using System.Collections.Generic;
using System.Linq;
using Goguma.Game.Object.Quest;

namespace Goguma.Game.Object.Map
{
  public class EntryRequirements
  {
    public int MinLevel { get; set; }
    public int MaxLevel { get; set; }
    public List<QuestList> CompletedQuests { get; set; }
    public List<QuestList> QuestsInProgress { get; set; }
    
    public EntryRequirements()
    {
      CompletedQuests = new List<QuestList>();
      QuestsInProgress = new List<QuestList>();
    }
    
    public bool Check()
    {
      var cq = true;
      var qp = true;
      var qpList = new List<QuestList>();
      
      if (CompletedQuests.Count != 0)
        foreach (var completedQuests in (from completedQuests in CompletedQuests where !InGame.player.CompletedQuests.Contains(completedQuests) select completedQuests).ToList())
        {
          cq = false;
          break;
        }

      foreach (var a in InGame.player.Quest.Quests)
        qpList.Add(a.Material);
      
      if (QuestsInProgress.Count != 0)
        foreach (var questsInProgress in (from questsInProgress in QuestsInProgress where !qpList.Contains(questsInProgress) select questsInProgress).ToList())
        {
         qp = false;
         break;
       }

      return (InGame.player.Level >= MinLevel && InGame.player.Level <= MaxLevel && cq && qp);
    }

    public static EntryRequirements Empty => new EntryRequirements();
  }
}