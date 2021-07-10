using System;
using System.Collections.Generic;

namespace Goguma.Game.Object.Quest
{
  public class QuestRequirements
  {
    public QuestList Quest { get; private set; }
    public int MinLv { get; set; }
    public int MaxLv { get; set; }
    public bool Disposable { get; set; }
    public List<QuestList> CompletedQuests { get; set; }

    public QuestRequirements(QuestList quest)
    {
      MinLv = 0;
      MaxLv = Int32.MaxValue;
      CompletedQuests = new();
      Quest = quest;
      Disposable = true;
    }
    public bool Check()
    {
      var player = InGame.player;
      var cq = true;
      var eq = true;
      var dq = true;
      foreach (var cqs in CompletedQuests)
        if (!player.CompletedQuests.Contains(cqs))
        {
          cq = false;
          break;
        }

      eq = !player.Quest.QType.Contains(Quest);

      if (Disposable) dq = !player.CompletedQuests.Contains(Quest);

      return (MinLv <= player.Level && player.Level <= MaxLv && cq && eq && dq);
    }
  }
}