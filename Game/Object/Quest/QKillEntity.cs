using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Quest.Exceptions;

namespace Goguma.Game.Object.Quest
{
  class QKillEntity : Quest
  {
    public List<MonsterList> Entitys { get; protected set; }
    public List<int> Counts { get; protected set; }
    public List<int> KilledCounts { get; set; }

    public QKillEntity() : base()
    {
      Entitys = new List<MonsterList>();
      Counts = new List<int>();
      KilledCounts = new List<int>();
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

    public override bool IsCompleted
    {
      get
      {
        foreach (var c in Counts)
          if (c != KilledCounts[Counts.IndexOf(c)]) return false;
        return true;
      }
    }

    protected override CTexts InfoDetails()
    {
      var resCT = new CTexts();
      foreach (var entity in Entitys)
      {
        var ent = Monsters.Get(entity);
        var index = Entitys.IndexOf(entity);
        resCT.Append(ent.Name)
        .Append($"{{ {Counts[index]} 마리 처치 - ( {KilledCounts[index]}/{Counts[index]} )\n,{(KilledCounts[index] >= Counts[index] ? Colors.txtSuccess : Colors.txtDefault)}}}");
      }
      return resCT;
    }
  }
}