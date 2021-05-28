using System.Collections.Generic;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Quest.Exceptions;

namespace Goguma.Game.Object.Quest
{
  class QKillEntity : Quest
  {
    public List<MonsterList> Entitys { get; protected set; }
    public List<int> Counts { get; protected set; }
    public List<int> KilledCounts { get; set; }

    public QKillEntity(QuestList quest) : base(quest)
    {
      Entitys = new List<MonsterList>();
      Counts = new List<int>();
    }

    public void Add(MonsterList entity, int count)
    {
      if (Entitys.Contains(entity)) throw new AlreadyExistEntity();
      Entitys.Add(entity);
      Counts.Add(count);
      KilledCounts.Add(0);
    }

    public void OnKillEntity(MonsterList entity)
    {
      foreach (var item in Entitys)
        if (item == entity)
        {
          KilledCounts[Entitys.IndexOf(item)] += 1;
          return;
        }
      throw new EntityNotInEntityList();
    }

    public void CheckCompleted()
    {
      foreach (var c in Counts)
        if (c != KilledCounts[Counts.IndexOf(c)]) return;
      OnCompleted();
    }



  }
}