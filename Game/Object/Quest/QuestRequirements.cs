using System;
using System.Collections.Generic;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Quest
{
  public class QuestRequirements
  {
    public int MinLv { get; set; }
    public int MaxLv { get; set; }
    public List<QuestList> CompletedQuests { get; set; }

    public QuestRequirements()
    {
      MinLv = 0;
      MaxLv = Int32.MaxValue;
      CompletedQuests = new();
    }
    public bool Check()
    {
      var player = InGame.player;
      var cq = true;
      foreach (var cqs in CompletedQuests)
        if (!player.CompletedQuests.Contains(cqs))
        {
          cq = false;
          break;
        }

      return (MinLv <= player.Level && player.Level <= MaxLv && cq);
    }
  }
}